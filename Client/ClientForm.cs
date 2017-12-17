using ClientLibrary;
using ModelsLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientSide
{
    /// <summary>
    ///This class represent client UI to chat with chat users 
    /// </summary>
    public partial class ClientForm : Form
    {
        private Client ChatClient;

        public ClientForm()
        {
            ChatClient = new Client();
            InitializeComponent();

        }//c-tor

        #region Form events
        private void ClientForm_Load(object sender, EventArgs e)
        {
            ChatClient.OnClientConnected += Client_OnClientConnected;
            ChatClient.OnClientDisconnected += Client_OnClientDisconnected;
            ChatClient.OnClientConnectionError += Client_OnClientConnectionError;
            ChatClient.OnUserRegistrationError += Client_OnUserRegistrationError;
            ChatClient.OnUserValidationError += Client_OnValidationError;
            ChatClient.OnMessageReseived += Client_OnClientMessageReseived;
            ChatClient.OnMessageSent += ChatClient_OnMessageSent;
            ChatClient.OnUserRemoved += ChatClient_OnUserRemoved;
            btnLogOut.Visible = false;
            grbMessages.Enabled = false;
            lnkCloseAccount.Enabled = false;
        }

        //Connect client to server
        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectForm newConnectForm = new ConnectForm();
            newConnectForm.ShowDialog();
            //If user login
            if (newConnectForm.DialogResult == DialogResult.OK)
            {
                ChatClient.LogIn(newConnectForm.EndPoint, newConnectForm.User.Name, newConnectForm.User.Password);
            }
            //If new user created, register
            if (newConnectForm.DialogResult == DialogResult.Yes)
            {
                ChatClient.RegisterNewUser(newConnectForm.EndPoint, newConnectForm.User);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ChatClient.LogOut();
        }

        //Close account
        private void lnkCloseAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ChatClient.IsConnected)
            {
                CredentialsForm privatDataForm = new CredentialsForm();
                privatDataForm.ShowDialog();
                if (privatDataForm.DialogResult == DialogResult.OK)
                {
                    string name = privatDataForm.UserName;
                    string password = privatDataForm.Password;
                    ChatClient.CloseAccount(name, password);
                }
            }
        }

        //Send message to all chat users
        private void btnSend_Click(object obj, EventArgs e)
        {
            string msg = txtNewMessage.Text;
            if (msg == string.Empty) return;
            string[] sender = new string[] { ChatClient.User.Id.ToString(), ChatClient.User.Name };
            ChatMessage newMessage = new ChatMessage()
            {
                Sender = sender,
                Text = msg,
                TextColor = ChatClient.User.TextColor
            };
            ChatClient.SendMessage(newMessage);
        }

        //Send private message
        private void btnSendPrivate_Click(object obj, EventArgs e)
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

            string[] sender = new string[] { ChatClient.User.Id.ToString(), ChatClient.User.Name };
            ChatMessage newMessage = null;
            foreach (ListViewItem item in lstMessages.SelectedItems)
            {
                newMessage = new ChatMessage(sender,
                    new string[] { item.SubItems[0].Text, item.SubItems[1].Text },
                    msg,
                    ChatClient.User.TextColor);
                ChatClient.SendMessage(newMessage);
                item.Selected = false;
            }
            AcceptButton = btnSend;
        }

        private void lstMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcceptButton = btnPrivate;
        }

        private void ClientForm_Shown(object sender, EventArgs e)
        {
            lstMessages.Columns.Add("id", 0);
            lstMessages.Columns.Add("שולח", 85);
            lstMessages.Columns.Add("שעה", 80);
            lstMessages.Columns.Add("תוכן", 225);
            ImageList il = new ImageList();
            il.ImageSize = new Size(1, 35);
            lstMessages.SmallImageList = il;
            btnConnect_Click(null, EventArgs.Empty);
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChatClient.IsConnected)
                ChatClient.LogOut();
        }
        #endregion

        #region Client events
        private void Client_OnClientMessageReseived(object sender, object msg)
        {
            UpdateMessagesList((ChatMessage)msg);
        }

        private void Client_OnClientDisconnected(object sender, EventArgs e)
        {
            ChatClient.User = null;
            Invoke(new Action(() =>
            {
                lnkCloseAccount.Enabled = false;
                tssConnectionStatus.Text = "לא מחובר";
                btnConnect.Visible = true;
                btnLogOut.Visible = false;
                grbMessages.Enabled = false;
                AcceptButton = btnConnect;
                MessageBox.Show("לקוח מנותק");
            }));
        }

        private void Client_OnClientConnected(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                Text = ChatClient.User.Name.ToUpper();
                tssConnectionStatus.Text = "מחובר ל" + ChatClient.ConnectPoint;
                grbMessages.Enabled = true;
                grbMessages.Enabled = true;
                btnConnect.Visible = false;
                btnLogOut.Visible = true;
                AcceptButton = btnSend;
                lnkCloseAccount.Enabled = true;
            }));
        }

        private void Client_OnValidationError(object sender, EventArgs args)
        {
            MessageBox.Show("שם משתמש או סיסמה שגויים");
            btnConnect_Click(null, null);
        }

        private void Client_OnUserRegistrationError(object sender, EventArgs args)
        {
            MessageBox.Show("שם משתמש כבר קיים\nבחור שם אחר");
            btnConnect_Click(null, null);
        }

        private void Client_OnSendPersonalDataError(Exception ex, ChatErrorEventArgs args)
        {
            MessageBox.Show("שגיית העברת נתונים פרטיים");
        }

        private void Client_OnClientConnectionError(Exception ex, ChatErrorEventArgs args)
        {
            MessageBox.Show("אין תקשורת עם השרת\nנסה להתחבר שוב", args.Error);
            ChatClient.User = null;
            btnConnect_Click(null, null);
        }

        private void ChatClient_OnUserRemoved(object sender, EventArgs e)
        {
            Invoke(new Action(() => { grbMessages.Enabled = false; }));
            btnConnect.Invoke(new Action(() => { btnConnect.Visible = true; }));
            btnLogOut.Invoke(new Action(() => { btnLogOut.Visible = false; }));
            btnLogOut.Invoke(new Action(() => { Text = "צ`אט"; }));
            btnLogOut.Invoke(new Action(() => { tssConnectionStatus.Text = "לא מחובר"; }));
            Invoke(new Action(() => { lnkCloseAccount.Enabled = false; }));
            Invoke(new Action(() => { AcceptButton = btnConnect; }));
            Invoke(new Action(() => { lstMessages.Items.Clear(); }));
            Invoke(new Action(() => { txtNewMessage.Clear(); }));
        }

        private void ChatClient_OnMessageSent(object sender, object msg)
        {
            UpdateMessagesList((ChatMessage)msg);
            AcceptButton = btnSend;
            txtNewMessage.Clear();
            txtNewMessage.Focus();
        }

        #endregion

        //Update messages list
        private void UpdateMessagesList(ChatMessage msg)
        {
            if (lstMessages.InvokeRequired)
            {
                Invoke(new UpdateViewHandler(UpdateMessagesList), new object[] { msg });
            }
            else
            {
                ListViewItem newItem = new ListViewItem(new string[]
                {
                    msg.Sender[0],
                    msg.Sender[1],
                    msg.SentDate.ToShortDateString()+" "+msg.SentDate.ToShortTimeString(),
                    msg.Text });
                newItem.ForeColor = msg.TextColor;
                lstMessages.Items.Add(newItem);
                lstMessages.Items[lstMessages.Items.Count - 1].EnsureVisible();
            }
        }
    }
}
