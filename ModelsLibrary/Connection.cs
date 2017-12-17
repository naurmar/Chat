using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ModelsLibrary
{
    public delegate void MessageTransferHandler(object sender, object package);

    /// <summary>
    /// This class represent connection between server and chat user
    /// </summary>
    public class Connection
    {
        public event MessageTransferHandler OnChatMessageReceived;
        public event ChatErrorHendler OnDataTransferError;

        private TcpClient _client;
        private NetworkStream _stream;
        private BinaryFormatter _formatter;
        private bool _isStopped;

        #region Properties
        public string ClientIpEndPoint
        {
            get
            {
                IPEndPoint ep = _client.Client.RemoteEndPoint as IPEndPoint;
                if (ep == null)
                    return ("unknown");
                return ep.Address.ToString();
            }
        }
        public bool IsStopped
        {
            get
            {
                return _isStopped;
            }

            set
            {
                _isStopped = value;
            }
        }
        #endregion

        public Connection()
        {
        }//c-tor

        public Connection(TcpClient client)
        {
            _client = client;
            _stream = _client.GetStream();
            _formatter = new BinaryFormatter();

        }//c-tor

        //Receive messages via network stream
        public void Work()
        {
            Thread newThread = new Thread(new ThreadStart(() =>
            {
                while (!_isStopped)
                {
                    try
                    {
                        object msg = _formatter.Deserialize(_stream);                       
                        OnChatMessageReceived?.Invoke(this,msg);
                    }
                    catch (Exception ex)
                    {
                       // IsStopped = true;
                        Disconnect();
                        OnDataTransferError?.Invoke(ex, new ChatErrorEventArgs("Connection error"));
                    }
                }
            }
            ));
            newThread.IsBackground = true;
            newThread.Start();
        }

        public void Connect()
        {
            IsStopped = false;
            Work();
        }

        //Close connection
        public void Disconnect()
        {
            IsStopped = true;
            _stream.Close();
            _client.Close();
        }

        //Send package 
        public void SendPackage(object obj)
        {
            try
            {
                _formatter.Serialize(_stream, obj);
            }
            catch (Exception ex)
            {
                Disconnect();
                OnDataTransferError?.Invoke(ex, new ChatErrorEventArgs("Send message error"));
            }
        }
    }//Connection
}
