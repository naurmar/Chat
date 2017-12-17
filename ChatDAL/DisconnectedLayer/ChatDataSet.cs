using ChatDAL.Data;
using ModelsLibrary;
using System;
using System.Data;
using System.Data.Common;

namespace ChatDAL.DisconnectedLayer
{
    /// <summary>
    /// This class represent chat dataset
    /// </summary>
    public class ChatDataSet
    {
        private DataSet _chatDS;
        private DataTable _usersTable, _messagesTable;
        private DataView _usersDV, _messagesDV;
        private DataBaseProvider _provider;//enum point on Sql, OleDb, Odbc...
        private DbDataAdapter _usersDataAdapter;//adapter for users table
        private DbDataAdapter _messagesDataAdapter;//adapter for messages table

        #region Properties
        public DataSet ChatDS
        {
            get
            {
                return _chatDS;
            }

            set
            {
                _chatDS = value;
            }
        }
        public DataTable Users
        {
            get { return _usersTable; }
            set { _usersTable = value; }
        }
        public DataTable Messages
        {
            get { return _messagesTable; }
            set { _messagesTable = value; }
        } 
        #endregion

        public ChatDataSet(string connectionString, DataBaseProvider provider)
        {
            _provider = provider;
            ConfigurateUsersAdapter(connectionString, out _usersDataAdapter);
            ConfigurateMessagesAdapter(connectionString, out _messagesDataAdapter);
            CreateDataSet();
            FillDataSet();
            _usersDV = new DataView(_usersTable);
            _messagesDV = new DataView(_messagesTable);
        }//c-tor

        //Create new dataset ,tabels
        private void CreateDataSet()
        {
            _chatDS = new DataSet("ChatData");//new dataset
            _usersTable = new DataTable("Users");//new users table
            _messagesTable = new DataTable("Messages");//new messages table
            _chatDS.Tables.AddRange(new DataTable[] { _usersTable, _messagesTable });
        }

        //Create user data adapter via type of data provider
        private void ConfigurateUsersAdapter(string connectionString, out DbDataAdapter dataAdapter)
        {
            string commandText = "Select * From Users";
            dataAdapter = DbFactory.GetDataAdapter(_provider, commandText, connectionString);
            dataAdapter.TableMappings.Add("Users", "Users");
            var commandBuilder = DbFactory.GetCommandBuilder(_provider, dataAdapter);
            commandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
        }

        //Create messages data adapter via type of data provider
        private void ConfigurateMessagesAdapter(string connectionString, out DbDataAdapter dataAdapter)
        {
            string commandText = "Select * From Messages ";
            dataAdapter = DbFactory.GetDataAdapter(_provider, commandText, connectionString);
            dataAdapter.TableMappings.Add("Messages", "Messages");
            var commandBuilder = DbFactory.GetCommandBuilder(_provider, dataAdapter);
            commandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
        }

        //Update dataset
        public void UpdateData()
        {
            _usersDataAdapter.Update(_usersTable);
            _messagesDataAdapter.Update(_messagesTable);
        }

        //Get data to Users dataset tabke
        public DataTable GetUsersTable()
        {
            _usersDataAdapter.Fill(_usersTable);
            return _usersTable;
        }

        //Get data to Messages dataset table
        public DataTable GetMessagesTable()
        {
            _messagesDataAdapter.Fill(_messagesTable);
            return _messagesTable;
        }

        //Update messages table
        public void UpdateMessagesTable()
        {
            _messagesDataAdapter.Update(_messagesTable);
        }

        //Update users table
        public void UpdateUsersTable()
        {
            _usersDataAdapter.Update(_usersTable);
        }

        //Add new message to dataset
        public void AddMessage(ChatMessage newMessage)
        {
            DataRow newRow = _messagesTable.NewRow();
            newRow["Id"] = Guid.NewGuid().ToString();
            newRow["Text"] = newMessage.Text;
            newRow["UserId"] = newMessage.Sender[0];
            newRow["SentDate"] = newMessage.SentDate;
            if (newMessage.Recipient[0] == null)
            {
                newRow["RecipientId"] = new Guid();
            }
            else
            {
                newRow["RecipientId"] = newMessage.Recipient[0];
            }
            _chatDS.Tables[1].Rows.Add(newRow);
        }

        //Add new user to dataset
        public void AddUser(ChatUser newUser)
        {
            DataRow newRow = _usersTable.NewRow();
            newRow["Id"] = newUser.Id.ToString();
            newRow["Password"] = newUser.Password;
            newRow["Name"] = newUser.Name;
            newRow["NickName"] = newUser.NickName;
            newRow["TextColor"] = newUser.TextColor;
            newRow["LastConnectionDate"] = DateTime.Now;
            newRow["IsConnected"] = true;
            _chatDS.Tables[0].Rows.Add(newRow);
            _usersTable.AcceptChanges();
        }

        //Get data to dataset
        public void FillDataSet()
        {
            _chatDS.Clear();
            _chatDS.Relations.Clear();
            _usersDataAdapter.Fill(_usersTable);
            _messagesDataAdapter.Fill(_messagesTable);
            _chatDS.Tables[0].PrimaryKey = new DataColumn[] { _usersTable.Columns[0] };
            _chatDS.Tables[1].PrimaryKey = new DataColumn[] {_messagesTable.Columns[0],_messagesTable.Columns[4] };
            DataRelation chatDR = new DataRelation("User_Massages", _usersTable.Columns["Id"],_messagesTable.Columns["UserId"]);
            _chatDS.Relations.Add(chatDR);
            chatDR = new DataRelation("Recipient_Massages", _usersTable.Columns["Id"], _messagesTable.Columns["RecipientId"]);
            _chatDS.Relations.Add(chatDR);
        }

        //Get Users table data
        public void FillUsersTable()
        {
         //   _usersTable.Clear();
            _usersDataAdapter.Fill(_usersTable);
        }

        //Get Messages table data
        public void FillMessagesTable()
        {
            _messagesTable.Clear();
            _messagesDataAdapter.Fill(_messagesTable);
        }

        //Find user via row filter
        public DataView FindUser(string rowFilter)
        {
            _usersDV.RowFilter = rowFilter;
            return _usersDV;
        }

        //Find message via row filter
        public DataView FindMessage(string rowFilter)
        {
            _messagesDV.RowFilter = rowFilter;
            return _messagesDV;
        }
    }
}
