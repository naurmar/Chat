namespace ServerSide
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.tbcServer = new System.Windows.Forms.TabControl();
            this.tbClients = new System.Windows.Forms.TabPage();
            this.btnDisconnectClient = new System.Windows.Forms.Button();
            this.lstClients = new System.Windows.Forms.ListView();
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbHistory = new System.Windows.Forms.TabPage();
            this.btnUpdateHistory = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lstHistory = new System.Windows.Forms.ListView();
            this.tbChat = new System.Windows.Forms.TabPage();
            this.tbMessages = new System.Windows.Forms.GroupBox();
            this.lstMessages = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtNewMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnPrivate = new System.Windows.Forms.Button();
            this.tbManagement = new System.Windows.Forms.TabPage();
            this.lblNotification3 = new System.Windows.Forms.Label();
            this.lblNotification2 = new System.Windows.Forms.Label();
            this.lblNotification1 = new System.Windows.Forms.Label();
            this.btnSaveUsers = new System.Windows.Forms.Button();
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.lblMessages = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.dtgMessages = new System.Windows.Forms.DataGridView();
            this.dtgUsers = new System.Windows.Forms.DataGridView();
            this.tbUserSearch = new System.Windows.Forms.TabPage();
            this.grpSerchByName = new System.Windows.Forms.GroupBox();
            this.lblAnd = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.dtgUser = new System.Windows.Forms.DataGridView();
            this.tbMessageSearch = new System.Windows.Forms.TabPage();
            this.dtgMessage = new System.Windows.Forms.DataGridView();
            this.grpSerchByDate = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNickName = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnFindMessage = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStop = new System.Windows.Forms.Button();
            this.chatDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbcServer.SuspendLayout();
            this.tbClients.SuspendLayout();
            this.tbHistory.SuspendLayout();
            this.tbChat.SuspendLayout();
            this.tbMessages.SuspendLayout();
            this.tbManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsers)).BeginInit();
            this.tbUserSearch.SuspendLayout();
            this.grpSerchByName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).BeginInit();
            this.tbMessageSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMessage)).BeginInit();
            this.grpSerchByDate.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcServer
            // 
            this.tbcServer.Controls.Add(this.tbClients);
            this.tbcServer.Controls.Add(this.tbHistory);
            this.tbcServer.Controls.Add(this.tbChat);
            this.tbcServer.Controls.Add(this.tbManagement);
            this.tbcServer.Controls.Add(this.tbUserSearch);
            this.tbcServer.Controls.Add(this.tbMessageSearch);
            resources.ApplyResources(this.tbcServer, "tbcServer");
            this.tbcServer.Name = "tbcServer";
            this.tbcServer.SelectedIndex = 0;
            this.tbcServer.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbcCurrentUsers_Selecting);
            // 
            // tbClients
            // 
            this.tbClients.Controls.Add(this.btnDisconnectClient);
            this.tbClients.Controls.Add(this.lstClients);
            resources.ApplyResources(this.tbClients, "tbClients");
            this.tbClients.Name = "tbClients";
            this.tbClients.UseVisualStyleBackColor = true;
            // 
            // btnDisconnectClient
            // 
            resources.ApplyResources(this.btnDisconnectClient, "btnDisconnectClient");
            this.btnDisconnectClient.Name = "btnDisconnectClient";
            this.btnDisconnectClient.UseVisualStyleBackColor = true;
            this.btnDisconnectClient.Click += new System.EventHandler(this.btnDisconnectClient_Click);
            // 
            // lstClients
            // 
            this.lstClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUser,
            this.colTime,
            this.colIp,
            this.columnHeader6});
            this.lstClients.FullRowSelect = true;
            resources.ApplyResources(this.lstClients, "lstClients");
            this.lstClients.Name = "lstClients";
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.Details;
            this.lstClients.SelectedIndexChanged += new System.EventHandler(this.lstClients_SelectedIndexChanged);
            // 
            // colUser
            // 
            resources.ApplyResources(this.colUser, "colUser");
            // 
            // colTime
            // 
            resources.ApplyResources(this.colTime, "colTime");
            // 
            // colIp
            // 
            resources.ApplyResources(this.colIp, "colIp");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // tbHistory
            // 
            this.tbHistory.Controls.Add(this.btnUpdateHistory);
            this.tbHistory.Controls.Add(this.btnClear);
            this.tbHistory.Controls.Add(this.lstHistory);
            resources.ApplyResources(this.tbHistory, "tbHistory");
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.UseVisualStyleBackColor = true;
            // 
            // btnUpdateHistory
            // 
            resources.ApplyResources(this.btnUpdateHistory, "btnUpdateHistory");
            this.btnUpdateHistory.Name = "btnUpdateHistory";
            this.btnUpdateHistory.UseVisualStyleBackColor = true;
            this.btnUpdateHistory.Click += new System.EventHandler(this.btnUpdateHistory_Click);
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lstHistory
            // 
            resources.ApplyResources(this.lstHistory, "lstHistory");
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.UseCompatibleStateImageBehavior = false;
            this.lstHistory.View = System.Windows.Forms.View.List;
            // 
            // tbChat
            // 
            this.tbChat.Controls.Add(this.tbMessages);
            resources.ApplyResources(this.tbChat, "tbChat");
            this.tbChat.Name = "tbChat";
            this.tbChat.UseVisualStyleBackColor = true;
            // 
            // tbMessages
            // 
            this.tbMessages.Controls.Add(this.lstMessages);
            this.tbMessages.Controls.Add(this.txtNewMessage);
            this.tbMessages.Controls.Add(this.btnSend);
            this.tbMessages.Controls.Add(this.btnPrivate);
            resources.ApplyResources(this.tbMessages, "tbMessages");
            this.tbMessages.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbMessages.Name = "tbMessages";
            this.tbMessages.TabStop = false;
            // 
            // lstMessages
            // 
            this.lstMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstMessages.FullRowSelect = true;
            resources.ApplyResources(this.lstMessages, "lstMessages");
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.UseCompatibleStateImageBehavior = false;
            this.lstMessages.View = System.Windows.Forms.View.Details;
            this.lstMessages.SelectedIndexChanged += new System.EventHandler(this.lstMessages_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // txtNewMessage
            // 
            resources.ApplyResources(this.txtNewMessage, "txtNewMessage");
            this.txtNewMessage.Name = "txtNewMessage";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Name = "btnSend";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnPrivate
            // 
            this.btnPrivate.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnPrivate, "btnPrivate");
            this.btnPrivate.ForeColor = System.Drawing.Color.Black;
            this.btnPrivate.Name = "btnPrivate";
            this.btnPrivate.UseVisualStyleBackColor = false;
            this.btnPrivate.Click += new System.EventHandler(this.btnPrivate_Click);
            // 
            // tbManagement
            // 
            this.tbManagement.Controls.Add(this.lblNotification3);
            this.tbManagement.Controls.Add(this.lblNotification2);
            this.tbManagement.Controls.Add(this.lblNotification1);
            this.tbManagement.Controls.Add(this.btnSaveUsers);
            this.tbManagement.Controls.Add(this.lblSelectedUser);
            this.tbManagement.Controls.Add(this.lblMessages);
            this.tbManagement.Controls.Add(this.lblUsers);
            this.tbManagement.Controls.Add(this.dtgMessages);
            this.tbManagement.Controls.Add(this.dtgUsers);
            resources.ApplyResources(this.tbManagement, "tbManagement");
            this.tbManagement.Name = "tbManagement";
            this.tbManagement.UseVisualStyleBackColor = true;
            // 
            // lblNotification3
            // 
            resources.ApplyResources(this.lblNotification3, "lblNotification3");
            this.lblNotification3.Name = "lblNotification3";
            // 
            // lblNotification2
            // 
            resources.ApplyResources(this.lblNotification2, "lblNotification2");
            this.lblNotification2.Name = "lblNotification2";
            // 
            // lblNotification1
            // 
            resources.ApplyResources(this.lblNotification1, "lblNotification1");
            this.lblNotification1.Name = "lblNotification1";
            // 
            // btnSaveUsers
            // 
            resources.ApplyResources(this.btnSaveUsers, "btnSaveUsers");
            this.btnSaveUsers.Name = "btnSaveUsers";
            this.btnSaveUsers.UseVisualStyleBackColor = true;
            this.btnSaveUsers.Click += new System.EventHandler(this.btnSaveUsers_Click);
            // 
            // lblSelectedUser
            // 
            resources.ApplyResources(this.lblSelectedUser, "lblSelectedUser");
            this.lblSelectedUser.Name = "lblSelectedUser";
            // 
            // lblMessages
            // 
            resources.ApplyResources(this.lblMessages, "lblMessages");
            this.lblMessages.Name = "lblMessages";
            // 
            // lblUsers
            // 
            resources.ApplyResources(this.lblUsers, "lblUsers");
            this.lblUsers.Name = "lblUsers";
            // 
            // dtgMessages
            // 
            this.dtgMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dtgMessages, "dtgMessages");
            this.dtgMessages.Name = "dtgMessages";
            this.dtgMessages.RowTemplate.Height = 24;
            // 
            // dtgUsers
            // 
            this.dtgUsers.AllowUserToAddRows = false;
            this.dtgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dtgUsers, "dtgUsers");
            this.dtgUsers.Name = "dtgUsers";
            this.dtgUsers.RowTemplate.Height = 24;
            // 
            // tbUserSearch
            // 
            this.tbUserSearch.Controls.Add(this.grpSerchByName);
            this.tbUserSearch.Controls.Add(this.dtgUser);
            resources.ApplyResources(this.tbUserSearch, "tbUserSearch");
            this.tbUserSearch.Name = "tbUserSearch";
            this.tbUserSearch.UseVisualStyleBackColor = true;
            // 
            // grpSerchByName
            // 
            this.grpSerchByName.Controls.Add(this.lblAnd);
            this.grpSerchByName.Controls.Add(this.lblId);
            this.grpSerchByName.Controls.Add(this.txtId);
            this.grpSerchByName.Controls.Add(this.lblUserName);
            this.grpSerchByName.Controls.Add(this.txtUserName);
            this.grpSerchByName.Controls.Add(this.btnFindUser);
            resources.ApplyResources(this.grpSerchByName, "grpSerchByName");
            this.grpSerchByName.Name = "grpSerchByName";
            this.grpSerchByName.TabStop = false;
            // 
            // lblAnd
            // 
            resources.ApplyResources(this.lblAnd, "lblAnd");
            this.lblAnd.Name = "lblAnd";
            // 
            // lblId
            // 
            resources.ApplyResources(this.lblId, "lblId");
            this.lblId.Name = "lblId";
            // 
            // txtId
            // 
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.Name = "txtId";
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.Name = "lblUserName";
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            // 
            // btnFindUser
            // 
            resources.ApplyResources(this.btnFindUser, "btnFindUser");
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.UseVisualStyleBackColor = true;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // dtgUser
            // 
            this.dtgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dtgUser, "dtgUser");
            this.dtgUser.Name = "dtgUser";
            this.dtgUser.RowTemplate.Height = 24;
            // 
            // tbMessageSearch
            // 
            this.tbMessageSearch.Controls.Add(this.dtgMessage);
            this.tbMessageSearch.Controls.Add(this.grpSerchByDate);
            resources.ApplyResources(this.tbMessageSearch, "tbMessageSearch");
            this.tbMessageSearch.Name = "tbMessageSearch";
            this.tbMessageSearch.UseVisualStyleBackColor = true;
            // 
            // dtgMessage
            // 
            this.dtgMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dtgMessage, "dtgMessage");
            this.dtgMessage.Name = "dtgMessage";
            this.dtgMessage.RowTemplate.Height = 24;
            // 
            // grpSerchByDate
            // 
            this.grpSerchByDate.Controls.Add(this.label1);
            this.grpSerchByDate.Controls.Add(this.lblNickName);
            this.grpSerchByDate.Controls.Add(this.txtDate);
            this.grpSerchByDate.Controls.Add(this.lblName);
            this.grpSerchByDate.Controls.Add(this.btnFindMessage);
            this.grpSerchByDate.Controls.Add(this.txtContent);
            resources.ApplyResources(this.grpSerchByDate, "grpSerchByDate");
            this.grpSerchByDate.Name = "grpSerchByDate";
            this.grpSerchByDate.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblNickName
            // 
            resources.ApplyResources(this.lblNickName, "lblNickName");
            this.lblNickName.Name = "lblNickName";
            // 
            // txtDate
            // 
            resources.ApplyResources(this.txtDate, "txtDate");
            this.txtDate.Name = "txtDate";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // btnFindMessage
            // 
            resources.ApplyResources(this.btnFindMessage, "btnFindMessage");
            this.btnFindMessage.Name = "btnFindMessage";
            this.btnFindMessage.UseVisualStyleBackColor = true;
            this.btnFindMessage.Click += new System.EventHandler(this.btnFindMessage_Click);
            // 
            // txtContent
            // 
            resources.ApplyResources(this.txtContent, "txtContent");
            this.txtContent.Name = "txtContent";
            // 
            // btnStartServer
            // 
            resources.ApplyResources(this.btnStartServer, "btnStartServer");
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.bntStartServer_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCount,
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // tsslCount
            // 
            this.tsslCount.Name = "tsslCount";
            resources.ApplyResources(this.tsslCount, "tsslCount");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chatDataSetBindingSource
            // 
            this.chatDataSetBindingSource.DataSource = typeof(ChatDAL.DisconnectedLayer.ChatDataSet);
            // 
            // ServerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbcServer);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.tbcServer.ResumeLayout(false);
            this.tbClients.ResumeLayout(false);
            this.tbHistory.ResumeLayout(false);
            this.tbChat.ResumeLayout(false);
            this.tbMessages.ResumeLayout(false);
            this.tbMessages.PerformLayout();
            this.tbManagement.ResumeLayout(false);
            this.tbManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsers)).EndInit();
            this.tbUserSearch.ResumeLayout(false);
            this.grpSerchByName.ResumeLayout(false);
            this.grpSerchByName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUser)).EndInit();
            this.tbMessageSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMessage)).EndInit();
            this.grpSerchByDate.ResumeLayout(false);
            this.grpSerchByDate.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbcServer;
        private System.Windows.Forms.TabPage tbClients;
        private System.Windows.Forms.TabPage tbHistory;
        private System.Windows.Forms.ListView lstClients;
        private System.Windows.Forms.ListView lstHistory;
        private System.Windows.Forms.Button btnDisconnectClient;
        private System.Windows.Forms.TabPage tbChat;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslCount;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox tbMessages;
        private System.Windows.Forms.ListView lstMessages;
        private System.Windows.Forms.TextBox txtNewMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnPrivate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnUpdateHistory;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colIp;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TabPage tbManagement;
        private System.Windows.Forms.DataGridView dtgUsers;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.DataGridView dtgMessages;
        private System.Windows.Forms.TabPage tbUserSearch;
        private System.Windows.Forms.GroupBox grpSerchByName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.DataGridView dtgUser;
        private System.Windows.Forms.TabPage tbMessageSearch;
        private System.Windows.Forms.GroupBox grpSerchByDate;
        private System.Windows.Forms.Button btnFindMessage;
        private System.Windows.Forms.DataGridView dtgMessage;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.BindingSource chatDataSetBindingSource;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblNickName;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnSaveUsers;
        private System.Windows.Forms.Label lblAnd;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNotification3;
        private System.Windows.Forms.Label lblNotification2;
        private System.Windows.Forms.Label lblNotification1;
    }
}

