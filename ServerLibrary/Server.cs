using ChatConfiguration;
using ChatDAL.DisconnectedLayer;
using ClientLibrary;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerLibrary
{
    public delegate void ChatClientHandler(ChatUser user);

    /// <summary>
    /// This class represent chat server
    /// </summary>
    public class Server
    {
        #region Events
        public event ChatClientHandler OnClientConnected;//occurs when client connecte
        public event ChatClientHandler OnClientDisconnected;//occurs when client disconnected
        public event EventHandler OnServerStarted;//occurs when server start works
        public event EventHandler OnServerStoped;//occurs when server stop works
        public event ChatErrorHendler OnServerStartError;//occurs when server can not start works
        public event ChatErrorHendler OnDataTransferError;//occurs when something wrong with data transfer
        public event MessageTransferHandler OnMessageSent;//occurs when message sent
        public event MessageTransferHandler OnMessageReseived;//occurs when message reseived
        public event ChatClientHandler OnClientRemoved;//occurs when user removed from database
        public event MessageTransferHandler OnMessageAddedToDataSet;//occurs when message added to dataset
        #endregion

        #region Properties
        private IPEndPoint _endPoint;
        public IPEndPoint EndPoint
        {
            get
            {
                return _endPoint;
            }
            private set
            {
                _endPoint = value;
            }
        }
        public List<string> History
        {
            get { return _history; }
            set { _history = value; }
        }
        public ChatDataSet ChatDSet { get; set; }
        #endregion

        //private data members
        ChatUser _serverUser;
        private TcpListener _listener;
        private bool _isConnected;
        private static Dictionary<Guid, Client> _connectedClients;//storage for connected clients
        private List<string> _history;
        private ServerBLL _serverBll;//server logic
        private string _connectionString;
        private static Queue<ChatMessage> _messagesStorage;//storage for incoming messages

        public Server()
        {
            _messagesStorage = new Queue<ChatMessage>();
            _endPoint = ConfigProvider.ConnectionPoint;
            _connectedClients = new Dictionary<Guid, Client>();
            _history = new List<string>();
        }//c-tor
        public Server(string connectionString, string startPath) : this()
        {
            var stringBuilder = new SqlConnectionStringBuilder(connectionString);
            stringBuilder.AttachDBFilename = startPath + stringBuilder.AttachDBFilename;
            _connectionString = stringBuilder.ConnectionString;
            _serverBll = new ServerBLL(_connectionString, ConfigProvider.Provider);
            ChatDSet = new ChatDataSet(_connectionString, ConfigProvider.Provider);
        }//c-tor

        //Create tcp listener  and start listennig for chat users in background thread
        public void Start()
        {
            try
            {
                _listener = new TcpListener(EndPoint);
                _listener.Start();
                _isConnected = true;
                Thread listenerThread = new Thread(new ThreadStart(Listen));
                listenerThread.Name = "ListenerThread";
                listenerThread.IsBackground = true;
                listenerThread.Start();

            }
            catch (Exception ex)
            {
                OnServerStartError?.Invoke(ex, new ChatErrorEventArgs("Server start error."));
                return;
            }
            CreateServerUser();
            AddToHistory("Listennig...");
            OnServerStarted?.Invoke(EndPoint, EventArgs.Empty);

            Thread saveMessagesThread = new Thread(new ThreadStart(SaveMessages));
            saveMessagesThread.IsBackground = true;
            saveMessagesThread.Start();
            
            Thread addMessagesThread = new Thread(new ThreadStart(AddMessageToDataSet));
            addMessagesThread.IsBackground = true;
            addMessagesThread.Start();
        }

        //Add messages to dataset
        private void AddMessageToDataSet()
        {
            ChatMessage message;
            while (_isConnected)
            {
                while (_messagesStorage.Count != 0)
                {
                    lock (_messagesStorage)
                    {
                        message = _messagesStorage.Dequeue();
                        ChatDSet.AddMessage(message);
                        OnMessageAddedToDataSet?.Invoke(null, message);
                    }
                } 
            }
        }

        //Stop server to accept users 
        public void Stop()
        {
            DisconnectAllClients();
            _listener.Stop();
            _isConnected = false;
            AddToHistory("server stopped");
            OnServerStoped?.Invoke(this, new ChatErrorEventArgs("Server stopped."));
        }

        //Listining for new connection
        public void Listen()
        {
            try
            {
                while (_isConnected)
                {
                    //Accept new tcp client
                    TcpClient client = _listener.AcceptTcpClient();
                    //Create new tcp connecton in another thread
                    CreateNewConnection(client);
                }
            }
            catch (Exception )
            {
              //  OnServerStartError?.Invoke(ex, new ChatErrorEventArgs("Server cannot accept clients"));
            }
        }

        //Create new tcp connection
        private void CreateNewConnection(TcpClient newTcpClient)
        {
            Connection connection = new Connection(newTcpClient);
            connection.OnChatMessageReceived += Connection_OnMessageReceived;
            connection.OnDataTransferError += Connection_OnDataTransferError;
            connection.Work();
        }

        //Add new client to server
        private void AddNewClient(ChatUser user, Connection newConnection)
        {
            Client newClient = new Client();
            newClient.User = user;
            newClient.ClientConnection = newConnection;
            _connectedClients.Add(user.Id, newClient);
            ChatDSet.FillUsersTable();
            OnClientConnected(user);
        }

        //Try to registrate new user
        private void RegisterNewUser(ChatUser newUser, Connection connection)
        {
            //If new user name do not exist in server database
            //accept and add new user to server
            if (_serverBll.IsValidUserName(newUser.Name))
            {
                newUser.Id = Guid.NewGuid();
                SendAcceptMessage(connection, newUser);
                _serverBll.AddNewUser(newUser);
                AddNewClient(newUser, connection);
                AddToHistory($"{newUser.Name} registreted.");
            }
            else
            {
                SendErrorMessage(MessageType.RegistrationError, connection);
                connection.Disconnect();
            }
        }

        //Disconnect client connection via chat user id
        private void DisconnectClient(Guid id)
        {
            ChatUser disconnectedUser = null;
            lock (_connectedClients)
            {
                disconnectedUser = _connectedClients[id].User;
                _connectedClients[id].ClientConnection.Disconnect();
                _connectedClients.Remove(id);
            }
            ChatDSet.FillUsersTable();
            OnClientDisconnected(disconnectedUser);

        }//DisconnectClient

        //Disconnect all chat users
        public void DisconnectAllClients()
        {
            Guid userId;
            lock (_connectedClients)
            {
                while (_connectedClients.Count != 0)
                {
                    userId = _connectedClients.Last().Key;
                    SendLogOutMessage(userId, _connectedClients[userId].ClientConnection);
                    _connectedClients[userId].ClientConnection.Disconnect();
                    _connectedClients.Remove(userId);
                }
            }
            _serverBll.SetAllUsersDisconnected();
        }//DisconnectAllClients

        //Try to login user exist
        private void LogIn(ChatMessage msg, Connection connection)
        {
            ChatUser userExist;
            if (_serverBll.IsUserExist(msg, out userExist))
            {
                SendAcceptMessage(connection, userExist);
                _serverBll.SetUserConnected(userExist.Id);
                AddNewClient(userExist, connection);
                AddToHistory($"{userExist.Name} connected.");
            }
            else
            {
                SendErrorMessage(MessageType.ValidationError, connection);
                connection.Disconnect();
            }
        }

        //Disconnect user by server
        public void DisconnectUser(Guid userId)
        {
            lock (_connectedClients)
            {
                SendLogOutMessage(userId, _connectedClients[userId].ClientConnection);
            }
            _serverBll.SetUserDisconnected(userId);
            DisconnectClient(userId);
            AddToHistory($"{userId} disconnected.");
        }

        //Logout user
        private void LogOut(Guid userId)
        {
            _serverBll.SetUserDisconnected(userId);
            DisconnectClient(userId);
            AddToHistory($"{userId} disconnected.");
        }

        //Close chat user account by server
        public void UnregisterClient(Guid userId)
        {
          
            ChatUser removedUser = null;
            lock (_connectedClients)
            {
                if (_connectedClients.Keys.Contains(userId))
                {
                    SendCloseMessage(userId, _connectedClients[userId].ClientConnection);
                    removedUser = _connectedClients[userId].User;
                    _connectedClients[userId].ClientConnection.Disconnect();
                    _connectedClients.Remove(userId);
                    AddToHistory($"{removedUser.Name} removed.");
                    OnClientRemoved?.Invoke(removedUser);
                }
            }
            ChatDSet.UpdateMessagesTable();
            ChatDSet.UpdateUsersTable();
        }

        //Close chat user account by user
        private void CloseClientAccount(Guid userId)
        {
            if (_serverBll.DeleteUser(userId))
            {
                ChatUser removedUser = null;
                lock (_connectedClients)
                {
                    removedUser = _connectedClients[userId].User;
                    _connectedClients[userId].ClientConnection.Disconnect();
                    _connectedClients.Remove(userId);
                }
                ChatDSet.FillDataSet();
                AddToHistory($"{removedUser.Name} removed.");
                OnClientRemoved?.Invoke(removedUser);
            }
        }

        //Save messages to chat database via dataset
        private void SaveMessages()
        {         
            while (_isConnected)
            {
                ChatDSet.UpdateMessagesTable();
                Thread.Sleep(10000);
            }
        }

        #region Connection events
        //Raise event when data transfer error occurs
        private void Connection_OnDataTransferError(Exception ex, ChatErrorEventArgs arg)
        {
            OnDataTransferError?.Invoke(ex, arg);
        }

        //Choose actions via recieved package from connection
        private void Connection_OnMessageReceived(object connection, object package)
        {
            if (package is ChatMessage)
            {
                CheckMessageReceived((ChatMessage)package, (Connection)connection);
            }
            else if (package is ChatUser)
            {
                RegisterNewUser((ChatUser)package, (Connection)connection);
            }
            else
            {
                OnDataTransferError(null, new ChatErrorEventArgs("Invalid package received."));
            }
        }
        #endregion

        #region Send messages

        //Send error message to user
        private void SendErrorMessage(MessageType errorType, Connection connection)
        {
            connection.SendPackage(new ChatMessage { Type = errorType });
            AddToHistory($"{connection.ClientIpEndPoint} {errorType.ToString()}.");
        }

        //Send accept message when user pass registration or validation
        private void SendAcceptMessage(Connection connection, ChatUser user)
        {
            connection.SendPackage(new ChatMessage()
            {
                Type = MessageType.Accept,
                Recipient = new string[] { user.Id.ToString(), user.Name },
                TextColor = user.TextColor,
                Text = user.NickName + "/" + user.Password
            });
        }

        //Send message when user was removed
        private void SendCloseMessage(Guid id, Connection connection)
        {
            connection.SendPackage(new ChatMessage
            {
                Sender = new string[] { _serverUser.Id.ToString(), _serverUser.Name },
                Type = MessageType.Close,
                Recipient = new string[] { id.ToString(), string.Empty }
            });
        }

        //Send message when user connection was disconnected
        private void SendLogOutMessage(Guid id, Connection connection)
        {
            connection.SendPackage(new ChatMessage
            {
                Sender = new string[] { _serverUser.Id.ToString(), _serverUser.Name },
                Type = MessageType.LogOut,
                Recipient = new string[] { id.ToString(), string.Empty }
            });
        }

        //Send private message
        private void SendPrivateMessage(ChatMessage message)
        {
            Guid recipientId = Guid.Parse(message.Recipient[0]);
            lock (_connectedClients)
            {
                _connectedClients[recipientId].ClientConnection.SendPackage(message);
            }
            //   ChatDSet.AddMessage(message);
            AddToHistory(message.ToString());
        }//SendPrivateMessage

        //Send message to all chat users from user
        private void BroadCast(ChatMessage message)
        {
            Guid senderId = Guid.Parse(message.Sender[0]);
            foreach (var client in _connectedClients)
            {
                if (client.Key != senderId)
                {
                    client.Value.ClientConnection.SendPackage(message);
                }
            }
            AddToHistory(message.ToString());

        }//BroadCast

        //Send message to all chat users from server
        public void BroadCast(string messageText)
        {
            ChatMessage msg = new ChatMessage(_serverUser, messageText);
            BroadCast(msg);
            AddMessageToStorage(msg);
            OnMessageSent?.Invoke(null, msg);
        }

        //Send private message
        public ChatMessage SendPrivateMessage(string recipientId, string recipientName, string text)
        {
            ChatMessage newMessage = new ChatMessage(_serverUser, new string[] { recipientId, recipientName }, text);
            SendPrivateMessage(newMessage);
            AddMessageToStorage(newMessage);
            OnMessageSent?.Invoke(null, newMessage);
            return newMessage;
        }

        #endregion

        //Check received message from user
        private void CheckMessageReceived(ChatMessage msg, Connection connection)
        {
            Guid userId = Guid.Parse(msg.Sender[0]);
            switch (msg.Type)
            {
                case MessageType.Private:
                    AddMessageToStorage(msg);
                    OnMessageReseived?.Invoke(null, msg);
                    SendPrivateMessage(msg);
                    break;
                case MessageType.BroadCast:
                    AddMessageToStorage(msg);
                    OnMessageReseived?.Invoke(null, msg);
                    BroadCast(msg);
                    break;
                case MessageType.Close:
                    CloseClientAccount(userId);
                    return;
                case MessageType.LogOut:
                    LogOut(userId);
                    return;
                case MessageType.LogIn:
                    LogIn(msg, connection);
                    return;
            }
        }

        //Add received message to storage
        private void AddMessageToStorage(ChatMessage msg)
        {
                _messagesStorage.Enqueue(msg);
        }

        //Add action to history list
        private void AddToHistory(string str)
        {
            lock (_history)
            {
                _history.Add(str + "  " + DateTime.Now.ToShortTimeString());
            }
        }//AddToHistory

        //Create server user for chating with users
        private void CreateServerUser()
        {
            _serverUser = new ChatUser() { Name = "admin", NickName = "server", Password = "123456" };
            if (_serverBll.IsValidUserName("admin"))
            {
                _serverBll.AddNewUser(_serverUser);
            }
            else
                _serverBll.SetUserConnected(_serverUser.Id);
            ChatDSet.FillUsersTable();
        }

        //Get chat user IPAddress
        public string GetClientEndPoint(Guid id)
        {
            lock (_connectedClients)
            {
                return _connectedClients[id].ClientConnection.ClientIpEndPoint;
            }
        }
    }//Server
}
