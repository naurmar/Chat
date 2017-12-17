using ChatConfiguration;
using ModelsLibrary;
using System;
using System.Configuration;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace ServerSide
{
   

    /// <summary>
    /// This class represent server UI 
    /// </summary>
    public partial class ServerForm : Form
    {
        //private members
        ServerLibrary.Server _server;
        private string _connectionString;
        private string _startPath;
        private List<Guid> _unregisterUsers = new List<Guid>();
        SoundPlayer _player = ConfigProvider.MessageReceivedPlayer;
        private BindingSource _usersTableSource, _messagesTableSource;

        public ServerForm()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["ChatDBConnectionString"].ConnectionString;
            _startPath = Application.StartupPath;
            _server = new ServerLibrary.Server(_connectionString, _startPath);
            _server.OnMessageReseived += Server_OnMessageReseived;
            _server.OnMessageSent += Server_OnMessageSent;
            _server.OnClientConnected += Server_OnClientConnected;
            _server.OnServerStoped += Server_OnServerStoped;
            _server.OnClientDisconnected += Server_OnClientDisconnected;
            _server.OnServerStarted += Server_OnServerStart;
            _server.OnServerStartError += Server_OnServerStartError;
            _server.OnClientRemoved += Server_OnClientRemoved;
            _server.OnMessageAddedToDataSet += Server_OnMessageAddedToDataSet;
        }//c-tor                   

        #region Form events
        private void ServerForm_Load(object sender, EventArgs e)
        {
            _usersTableSource = new BindingSource();
            _messagesTableSource = new BindingSource();
            _usersTableSource.DataSource = _server.ChatDSet.Users;
            dtgUsers.DataSource = _usersTableSource;
            _messagesTableSource.DataSource = _server.ChatDSet.Messages;
            dtgMessages.DataSource = _messagesTableSource;
            dtgUsers.UserDeletingRow += DtgUsers_UserDeletingRow;
            dtgUsers.UserDeletedRow += DtgUsers_UserDeletedRow;
            dtgUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgUsers.ScrollBars = ScrollBars.Vertical;
            dtgMessages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgMessages.ScrollBars = ScrollBars.Vertical;

            btnStop.Enabled = false;
            tbcServer.Enabled = false;
            tbcServer.SelectedTab = tbManagement;
            tsslCount.Text = "0";
            SetListViewHeight(lstMessages, 20);
            SetListViewHeight(lstHistory, 20);
        }

        //Get deleted users from users gridview
        private void DtgUsers_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Guid id = (Guid)e.Row.Cells[0].Value;
            string name = e.Row.Cells[2].Value.ToString();
            if (id == new Guid())
            {
                e.Cancel = true;
                MessageBox.Show("לא נתן למחוק משתמש של שרת");
            }
            else
            {
                if (MessageBox.Show($"בטוח?\n{name} ברצונך למחוק משתמש", "!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _unregisterUsers.Add(id);
                }
                else
                    e.Cancel = true;
            }
        }

        //After rows was deleted save changes
        private void DtgUsers_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            btnSaveUsers_Click(null, null);
        }

        //Start server
        private void bntStartServer_Click(object sender, EventArgs e)
        {
            _server.Start();
        }

        //Send message from server to all clients
        private void btnSend_Click(object sender, EventArgs e)
        {
            string messageText = txtNewMessage.Text;
            if (messageText == string.Empty)
                return;
            _server.BroadCast(messageText);
        }

        //Send privat message
        private void btnPrivate_Click(object sender, EventArgs e)
        {
            string msg = txtNewMessage.Text;
            if (msg == string.Empty)
            {
                MessageBox.Show("עליך לכתוב משהו");
                return;
            }

            if (lstMessages.SelectedItems.Count == 0)
            {
                MessageBox.Show("בחר נמען מהרשימת הודעות");
                return;
            }
            ChatMessage newMessage;
            foreach (ListViewItem item in lstMessages.SelectedItems)
            {
                newMessage = _server.SendPrivateMessage(item.SubItems[0].Text, item.SubItems[1].Text, txtNewMessage.Text);
                item.Selected = false;
            }
        }

        //Stop server
        private void btnStop_Click(object sender, EventArgs e)
        {
            _server.Stop();
        }

        //Disconnect user
        private void btnDisconnectClient_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count == 0)
            {
                MessageBox.Show("בחר נמען מהרשימת הודעות");
                return;
            }
            foreach (ListViewItem item in lstClients.SelectedItems)
            {
                _server.DisconnectUser(Guid.Parse(item.SubItems[3].Text));
                lstClients.Items.Remove(item);
            }
        }

        //Clear history
        private void btnClear_Click(object sender, EventArgs e)
        {
            lstHistory.Clear();
            _server.History.Clear();
        }

        //Update history list
        private void btnUpdateHistory_Click(object sender, EventArgs e)
        {
            UpdateHistoryList();
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcceptButton = btnDisconnectClient;
        }

        private void tbcCurrentUsers_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == tbHistory.Name)
            {
                UpdateHistoryList();
            }
            if (e.TabPage.Name == tbChat.Name)
            {
                AcceptButton = btnSend;
                txtNewMessage.Focus();
            }
            if (e.TabPage.Name == tbManagement.Name)
            {
                AcceptButton = btnSaveUsers;
            }
            if (e.TabPage.Name == tbUserSearch.Name)
            {
                AcceptButton = btnFindUser;
            }
            if (e.TabPage.Name == tbMessageSearch.Name)
            {
                AcceptButton = btnFindMessage;
            }
        }

        private void lstMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcceptButton = btnPrivate;
        }

        //Search user via user id or name
        private void btnFindUser_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text.Trim();
            string id = txtId.Text.Trim();
            if (name == string.Empty && id == string.Empty)
            {
                MessageBox.Show("אין לפי מה לחפש");
                return;
            }
            string filter;
            Guid userId;
            if (Guid.TryParse(id, out userId))
            {
                filter = $" Id ='{userId}'";
            }
            else
            {
                filter = $" Name = '{name}'";
            }
            dtgUser.DataSource = _server.ChatDSet.FindUser(filter);
            dtgUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtUserName.Clear();
            txtId.Clear();
        }

        //Search message via sent date and message text
        private void btnFindMessage_Click(object sender, EventArgs e)
        {
            string date = txtDate.Text.Trim();
            string content = txtContent.Text.Trim();
            if (date == string.Empty && content == string.Empty)
            {
                MessageBox.Show("אין לפי מה לחפש");
                return;
            }
            string filter = null, dateFilter = null, contentFilter = null;
            if (date != string.Empty)
            {
                DateTime startDate;
                if (DateTime.TryParse(date, CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal, out startDate))
                {
                    DateTime endDate = startDate.AddHours(24);
                    dateFilter = $"SentDate >= '{startDate}' and SentDate < '{endDate}'";
                }
            }
            if (content != string.Empty)
            {
                contentFilter = $"Text like '%{content}%'";
            }

            if (dateFilter != null && contentFilter != null)
            {
                filter = $"{contentFilter} and ({dateFilter})";
            }
            else if (dateFilter != null)
            {
                filter = dateFilter;
            }
            else if (contentFilter != null)
            {
                filter = contentFilter;
            }
            dtgMessage.DataSource = _server.ChatDSet.FindMessage(filter);
            dtgMessage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgMessage.ScrollBars = ScrollBars.Vertical;
            txtContent.Clear();
            txtDate.Clear();
        }

        //Save messages to database via dataadapter
        private void btnSaveUsers_Click(object sender, EventArgs e)
        {
            foreach (var userId in _unregisterUsers)
            {
                _server.UnregisterClient(userId);
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.DisconnectAllClients();
        }

        #endregion

        #region Server Events
        private void Server_OnServerStoped(object sender, EventArgs e)
        {
            ReloadDataGridView(dtgUsers, _usersTableSource);
            btnStartServer.Enabled = true;
            btnStop.Enabled = false;
            tbcServer.Enabled = false;
            lstClients.Items.Clear();
            tsslCount.Text = "0";
            Text = "שרת";
        }


        private void Server_OnServerStartError(Exception ex, ChatErrorEventArgs args)
        {
            MessageBox.Show(ex.Message, args.Error);
        }

        //When server start work
        private void Server_OnServerStart(object sender, EventArgs e)
        {
            Text = string.Format("Server running on " + _server.EndPoint);
            tbcServer.Enabled = true;
            btnStartServer.Enabled = false;
            btnStop.Enabled = true;
        }

        //When user connected to server
        private void Server_OnClientDisconnected(ChatUser user)
        {
            UpdateClientsList(user, ActionType.Remove);
            ReloadDataGridView(dtgUsers, _usersTableSource);
        }

        //When user removed from database
        private void Server_OnClientRemoved(ChatUser user)
        {
            ReloadDataGridView(dtgUsers, _usersTableSource);
            ReloadDataGridView(dtgMessages, _messagesTableSource);
            UpdateClientsList(user, ActionType.Remove);
        }

        //When client connected 
        private void Server_OnClientConnected(ChatUser user)
        {
            UpdateClientsList(user, ActionType.Add);
            ChangeClientsCount(lstClients.Items.Count);
            ReloadDataGridView(dtgUsers, _usersTableSource);
        }

        //When message receiced from user
        private void Server_OnMessageReseived(object sender, object msg)
        {
            UpdateMessagesView((ChatMessage)msg);
            if (_player != null)
                _player.Play();
        }

        //When message sent from server
        private void Server_OnMessageSent(object sender, object msg)
        {
            Invoke(new Action(() =>
            {
                UpdateMessagesView((ChatMessage)msg);
                txtNewMessage.Clear();
                txtNewMessage.Focus();
                AcceptButton = btnSend;
            }));
        }

        private void Server_OnMessageAddedToDataSet(object sender, object package)
        {
            Invoke((MethodInvoker)delegate
            {
                dtgMessages.Refresh();
                dtgMessages.ScrollBars = ScrollBars.Both;
            });
        }
        #endregion

        //Update connected client list
        private void UpdateClientsList(ChatUser user, ActionType action)
        {
            if (lstClients.InvokeRequired)
            {
                Invoke(new UpdateListView(UpdateClientsList), new object[] { user, action });
            }
            else
            {
                if (action == ActionType.Add)
                {
                    ListViewItem newClient = new ListViewItem(user.Name);
                    newClient.SubItems.Add(DateTime.Now.ToString());
                    newClient.SubItems.Add(_server.GetClientEndPoint(user.Id));
                    newClient.SubItems.Add(user.Id.ToString());
                    newClient.Name = user.Name;
                    lstClients.Items.Add(newClient);
                    lstClients.Items[lstClients.Items.Count - 1].EnsureVisible();
                }
                else
                {
                    foreach (ListViewItem item in lstClients.Items)
                    {
                        if (item.Name == user.Name)
                        {
                            lstClients.Items.Remove(item);
                            ChangeClientsCount(lstClients.Items.Count);
                        }
                    }
                }
            }
        }

        //Change clients count
        private void ChangeClientsCount(int count)
        {
            if (statusStrip1.InvokeRequired)
            {
                Invoke(new UpdateCounter(ChangeClientsCount), new object[] { count });
            }
            else
                tsslCount.Text = count.ToString();
        }

        //Update chat message view
        private void UpdateMessagesView(ChatMessage msg)
        {
            if (lstMessages.InvokeRequired)
            {
                Invoke(new UpdateViewHandler(UpdateMessagesView), new object[] { msg });
            }
            else
            {
                ListViewItem newItem = new ListViewItem(new string[]
                {
                    msg.Sender[0],
                    msg.Sender[1],
                    msg.Recipient[1],
                    msg.Text,
                    msg.SentDate.ToString(),
                    msg.Recipient[0]
                });
                newItem.ForeColor = msg.TextColor;
                lstMessages.Items.Add(newItem);
                lstMessages.Items[lstMessages.Items.Count - 1].EnsureVisible();
            }
        }

        private void SetListViewHeight(ListView list, int height)
        {
            ImageList il = new ImageList();
            il.ImageSize = new Size(1, height);
            list.SmallImageList = il;
        }

        //Update history list
        private void UpdateHistoryList()
        {
            if (_server.History.Count == 0)
                return;
            lstHistory.Clear();
            foreach (string str in _server.History)
            {
                lstHistory.Items.Add(str);
            }
            lstHistory.Items[lstHistory.Items.Count - 1].EnsureVisible();
        }

        //Reload datagridview
        private void ReloadDataGridView(DataGridView dataGridView, BindingSource source)
        {
            Invoke(new Action(() =>
            {
                dataGridView.DataSource = null;
                dataGridView.DataSource = source;
                dataGridView.Refresh();
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.ScrollBars = ScrollBars.Vertical;
            }));
        }

        // Set datagridview columns width
        //private void SetDataGridViewColumnsWidth(DataGridView dataGridView)
        //{
        //    int width = dataGridView.Width / dataGridView.ColumnCount - 15;
        //    for (int i = 0; i < dataGridView.ColumnCount; i++)
        //    {
        //        dataGridView.Columns[i].Width = width;
        //    }
        //    dataGridView.ScrollBars = ScrollBars.Both;
        //}
    }
}
