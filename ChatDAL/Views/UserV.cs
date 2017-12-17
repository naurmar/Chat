using ModelsLibrary;
using System;

namespace ChatDAL.Models
{
    /// <summary>
    /// This class helps get chat users from database.
    /// </summary>
    public class UserV : ChatUser
    {
        private DateTime _lastConnectionDate;
        public DateTime LastConnectionDate
        {
            get { return _lastConnectionDate; }
            set { _lastConnectionDate = value; }
        }

        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; }
        }

        public UserV() : base()
        {
        }//c-tor
    }
}
