using ChatDAL.Data;
using ChatDAL.Models;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ChatDAL.ConnectedLayer
{
    /// <summary>
    /// This class represent connected layer to ChatDB
    /// </summary>
    public class UserDAL
    {
        DataProvider _dataProvider;
        DataBaseProvider _provider;//indicates SqlProvider, OleDbProvider, OdbcProvider

        public UserDAL(string connectionString, DataBaseProvider provider)
        {
            _provider = provider;
            _dataProvider = new DataProvider(provider, connectionString);
        }

        //Add new user to database
        public void AddUser(ChatUser newUser)
        {
            DbParameter id = DbFactory.GetParameter(_provider);
            id.ParameterName = "@id";
            id.Value = newUser.Id;
            id.DbType = DbType.Guid;
            DbParameter name = DbFactory.GetParameter(_provider);
            name.ParameterName = "@name";
            name.Value = newUser.Name;
            name.DbType = DbType.String;
            DbParameter nick = DbFactory.GetParameter(_provider);
            nick.ParameterName = "@nickName";
            nick.Value = newUser.NickName;
            nick.DbType = DbType.String;
            DbParameter color = DbFactory.GetParameter(_provider);
            color.ParameterName = "@textColor";
            color.Value = newUser.TextColor.ToString();
            color.DbType = DbType.String;
            DbParameter password = DbFactory.GetParameter(_provider);
            password.ParameterName = "@password";
            password.Value = newUser.Password;
            password.DbType = DbType.String;
            _dataProvider.ExecuteNonQuery("usp_AddUser", new DbParameter[] { id, name, nick, password, color });
        }

        //Get all users into list
        public List<UserV> GetAllUsers()
        {
            List<UserV> users = new List<UserV>();
            DbDataReader reader = _dataProvider.ExecuteReader("usp_GetAllUsers", null);
            while (reader.Read())
            {
                users.Add(new UserV
                {
                    Id = (Guid)reader["Id"],
                    Password = (string)reader["Password"],
                    Name = (string)reader["Name"],
                    NickName = (string)reader["NickName"],
                    LastConnectionDate = (DateTime)reader["LastConnectionDate"],
                    IsConnected = (bool)reader["IsConnected"]
                });
            }
            reader.Close();
            _dataProvider.CloseConnection();
            return users;
        }

        //Set all users disconnected
        public void SetUsersDisconnected()
        {
            _dataProvider.ExecuteNonQuery("usp_Set_All_Users_Disconnected", null);
        }

        //Get user by password and name if exist
        public ChatUser GetUserByPasswordAndName(string name, string password)
        {
            string command = $"Select * from Users where Name='{name}' and Password='{password}'";
            ChatUser userExist = null;
            DbDataReader reader = _dataProvider.ExecuteReader(command, null, CommandType.Text);
            while (reader.Read())
            {
                userExist = new ChatUser();
                userExist.Id = (Guid)reader["Id"];
                userExist.Password = (string)reader["Password"];
                userExist.Name = (string)reader["Name"];
                userExist.NickName = (string)reader["NickName"];
            }
            reader.Close();
            _dataProvider.CloseConnection();
            return userExist;
        }

        //Get user by name
        public UserV GetUserByName(string userName)
        {
            UserV user = null;
            DbParameter name = DbFactory.GetParameter(_provider);
            name.ParameterName = "@name";
            name.Value = userName;
            name.DbType = DbType.String;
            DbDataReader reader = _dataProvider.ExecuteReader("usp_SelectUserByName", new DbParameter[] { name });
            while (reader.Read())
            {
                user = new UserV();
                user.Id = (Guid)reader["Id"];
                user.Password = (string)reader["Password"];
                user.Name = (string)reader["Name"];
                user.NickName = (string)reader["NickName"];
                user.LastConnectionDate = (DateTime)reader["LastConnectionDate"];
                user.IsConnected = (bool)reader["IsConnected"];
            }
            reader.Close();
            _dataProvider.CloseConnection();
            return user;
        }

        //Get all users into datatable
        public DataTable GetAllUsersAsDataTable()
        {
            DataTable usersDataTable = new DataTable("Users");
            DbDataReader reader = _dataProvider.ExecuteReader("usp_GetAllUsers", null);
            usersDataTable.Load(reader);
            return usersDataTable;
        }

        //Delete user via userId
        public int DeleteUser(Guid userId)
        {
            DbParameter id = DbFactory.GetParameter(_provider);
            id.ParameterName = "@id";
            id.Value = userId;
            id.DbType = DbType.Guid;
            return _dataProvider.ExecuteNonQuery("usp_DeleteUser", new DbParameter[] { id });
        }

        //Set user connected via id
        public int SetUserConnected(Guid userId)
        {

            DbParameter id = DbFactory.GetParameter(_provider);
            id.ParameterName = "@id";
            id.Value = userId;
            id.DbType = DbType.Guid;
            return _dataProvider.ExecuteNonQuery("usp_Set_User_Connected", new DbParameter[] { id });
        }

        //Set user disconnected via id
        public int SetUserDisconnected(Guid userId)
        {
            DbParameter id = DbFactory.GetParameter(_provider);
            id.ParameterName = "@id";
            id.Value = userId;
            id.DbType = DbType.Guid;
            return _dataProvider.ExecuteNonQuery("usp_Set_User_Disconnected", new DbParameter[] { id });
        }
    }
}
