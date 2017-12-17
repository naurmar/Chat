using ChatDAL.ConnectedLayer;
using ChatDAL.DisconnectedLayer;
using ModelsLibrary;
using System;
using System.Data;
using ChatDAL.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatDAL;
using ChatDAL.Models;

namespace ServerLibrary
{
    /// <summary>
    /// This is class helper for server application logic
    /// </summary>
    public class ServerBLL
    {
        private static UserDAL _dal;//connected data access layer

        public ServerBLL(string connectionString, DataBaseProvider provider)
        {
            _dal = new UserDAL(connectionString, provider);
        } //c-tor

        #region Connected Data Access Layer
        //Check if new user name exist in server database
        internal bool IsValidUserName(string userName)
        {
            if (_dal.GetUserByName(userName) != null)
                return false;
            return true;
        }

        // Check if user exist in chat database
        internal bool IsUserExist(ChatMessage message, out ChatUser userExist)
        {
            userExist = _dal.GetUserByPasswordAndName(message.Sender[1], message.Text);
            if (userExist != null)
                return true;
            return false;
        }

        //Add new user to database
        internal void AddNewUser(ChatUser newUser)
        {
            _dal.AddUser(newUser);
        }

        //Set user connected status
        internal  void SetUserConnected(Guid id)
        {
            _dal.SetUserConnected(id);
        }

        //Set user disconnected status
        internal void SetUserDisconnected(Guid userId)
        {
            _dal.SetUserDisconnected(userId);
        }

        internal void SetAllUsersDisconnected()
        {
            _dal.SetUsersDisconnected();
        }

        public List<UserV> GetUsers()
        {
            return _dal.GetAllUsers();
        }

        //Delete user from database
        internal bool DeleteUser(Guid userId)
        {
            try
            {
                int result = _dal.DeleteUser(userId);
                if (result == 0)
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        #endregion
    }
}
