using ModelsLibrary;
using System;
using System.Net;
using System.Net.Sockets;

namespace ClientLibrary
{
    /// <summary>
    /// This class represent chat client side
    /// </summary>
    public class Client
    {
        #region Events
        public event MessageTransferHandler OnMessageReseived;
        public event MessageTransferHandler OnMessageSent;
        public event EventHandler OnUserValidationError;
        public event EventHandler OnClientConnected;
        public event EventHandler OnClientDisconnected;
        public event EventHandler OnUserRemoved;
        public event ChatErrorHendler OnClientConnectionError;
        public event EventHandler OnUserRegistrationError;
        #endregion

        #region Properties
        private ChatUser _user;
        public ChatUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        private IPEndPoint _connectPoint;
        public IPEndPoint ConnectPoint
        {
            get
            {
                return _connectPoint;
            }

            set
            {
                _connectPoint = value;
            }
        }

        private Connection _clientConnection;
        public Connection ClientConnection
        {
            get
            {
                return _clientConnection;
            }
            set
            {
                _clientConnection = value;
            }
        }

        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; }
        }

        #endregion

        public Client()
        {
            _user = null;
            _connectPoint = null;
        }//c-tor

        //Create new Tcp connection
        private bool CreateClientConnection(IPEndPoint point)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(point);
                _clientConnection = new Connection(client);
                _clientConnection.OnChatMessageReceived += ClientConnection_OnMessageReceived;
                _clientConnection.OnDataTransferError += ClientConnection_OnDataTransferError;
                _clientConnection.Work();
                _isConnected = true;
                return true;
            }
            catch (Exception ex)
            {
                //Raise error event
                OnClientConnectionError?.Invoke(ex, new ChatErrorEventArgs("Connection error"));
                return false;
            }
        }

        //Register new chat user
        public void RegisterNewUser(IPEndPoint endPoint, ChatUser newUser)
        {
            User = newUser;
            //If connection created send new user to registrer
            if (CreateClientConnection(endPoint))
            {
                _connectPoint = endPoint;
                _clientConnection.SendPackage(newUser);
            }
        }

        //Connect to server
        public void LogIn(IPEndPoint point, string name, string password)
        {
            //If connection created send login message to server
            if (CreateClientConnection(point))
            {
                SendMessage(name, password);
            }
        }

        //Disconnect client from server
        public void LogOut()
        {
            SendMessage(MessageType.LogOut);
            Disconnect();
        }

        //Close client account and remove user
        private void RemoveUser()
        {
            _clientConnection.Disconnect();
            OnUserRemoved?.Invoke(_user, EventArgs.Empty);
            _isConnected = false;
            _clientConnection = null;
            _user = null;
        }

        //Close account
        public void CloseAccount(string name, string password)
        {
            if (_user.Name == name && _user.Password == password)
            {
                SendMessage(MessageType.Close);
                RemoveUser();
            }
        }

        //Disconnect client connection
        public void Disconnect()
        {
            if (!ClientConnection.IsStopped)
            {
                ClientConnection.Disconnect();
            }
            _isConnected = false;
            OnClientDisconnected?.Invoke(null, new ChatErrorEventArgs($"{User.Name} loged out"));
        }

        //Check received server message
        private void CheckReceived(ChatMessage responseMessage)
        {
            switch (responseMessage.Type)
            {
                case MessageType.ValidationError:
                    _clientConnection.Disconnect();
                    OnUserValidationError?.Invoke(User, EventArgs.Empty);
                    break;
                //Raise registration error event
                case MessageType.RegistrationError:
                    _clientConnection.Disconnect();
                    _user = null;
                    OnUserRegistrationError(User, EventArgs.Empty);
                    break;
                //Accept chat user
                case MessageType.Accept:
                    AddUser(responseMessage);
                    OnClientConnected(User, EventArgs.Empty);
                    break;
                //Close chat account
                case MessageType.Close:
                    RemoveUser();
                    break;
                //Logout chat
                case MessageType.LogOut:
                    Disconnect();
                    break;
                default:
                    break;
            }
        }

        //Update user data
        private void AddUser(ChatMessage message)
        {
            Guid userId = Guid.Parse(message.Recipient[0]);
            if (User == null)
            {
                User = new ChatUser();
                string[] userData = message.Text.Split('/');
                User.NickName = userData[0];
                User.Password = userData[1];
                User.Id = userId;
                User.Name = message.Recipient[1];
                User.TextColor = message.TextColor;
            }
            else
                User.Id = userId;
        }

        #region Connection events
        private void ClientConnection_OnDataTransferError(Exception exeption, ChatErrorEventArgs args)
        {
           // OnClientDisconnected?.Invoke(exeption, args);
        }

        private void ClientConnection_OnMessageReceived(object sender, object package)
        {
            ChatMessage msg = package as ChatMessage;
            if (msg == null)
                return;
            if (msg.Type == MessageType.Private || msg.Type == MessageType.BroadCast)
            {
                OnMessageReseived?.Invoke(null, msg);
                return;
            }
            CheckReceived(msg);
        }
        #endregion

        #region Send Messages
        public void SendMessage(ChatMessage msg)
        {
            if (msg.Recipient[1] == "admin")
                return;
            _clientConnection.SendPackage(msg);
            OnMessageSent?.Invoke(null, msg);
        }

        private void SendMessage(string userName, string password)
        {
            ChatMessage newMessage = new ChatMessage();
            newMessage.Sender[0] = new Guid().ToString();
            newMessage.Sender[1] = userName;
            newMessage.Type = MessageType.LogIn;
            newMessage.Text = password;
            _clientConnection.SendPackage(newMessage);
        }

        private void SendMessage(MessageType messageType)
        {
            ChatMessage newMessage = new ChatMessage();
            newMessage.Sender[0] = User.Id.ToString();
            newMessage.Sender[1] = User.Name;
            newMessage.Type = messageType;
            newMessage.Text = User.Password;
            _clientConnection.SendPackage(newMessage);
        }
        #endregion
    }//Client
}
