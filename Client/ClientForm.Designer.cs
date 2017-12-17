namespace ClientSide
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnPrivate = new System.Windows.Forms.Button();
            this.chatStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tssConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtNewMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lstMessages = new System.Windows.Forms.ListView();
            this.grbMessages = new System.Windows.Forms.GroupBox();
            this.lnkCloseAccount = new System.Windows.Forms.LinkLabel();
            this.chatStatusStrip.SuspendLayout();
            this.grbMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.btnConnect.Location = new System.Drawing.Point(223, 456);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(86, 28);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "התחבר";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.btnLogOut.Location = new System.Drawing.Point(126, 456);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(87, 28);
            this.btnLogOut.TabIndex = 1;
            this.btnLogOut.Text = "התנתק";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnPrivate
            // 
            this.btnPrivate.BackColor = System.Drawing.Color.Transparent;
            this.btnPrivate.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.btnPrivate.ForeColor = System.Drawing.Color.Black;
            this.btnPrivate.Location = new System.Drawing.Point(11, 363);
            this.btnPrivate.Name = "btnPrivate";
            this.btnPrivate.Size = new System.Drawing.Size(98, 27);
            this.btnPrivate.TabIndex = 3;
            this.btnPrivate.Text = "שלח פרטי";
            this.btnPrivate.UseVisualStyleBackColor = false;
            this.btnPrivate.Click += new System.EventHandler(this.btnSendPrivate_Click);
            // 
            // chatStatusStrip
            // 
            this.chatStatusStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.chatStatusStrip.Font = new System.Drawing.Font("Tahoma", 7.2F);
            this.chatStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.chatStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssConnectionStatus});
            this.chatStatusStrip.Location = new System.Drawing.Point(0, 493);
            this.chatStatusStrip.Name = "chatStatusStrip";
            this.chatStatusStrip.Size = new System.Drawing.Size(539, 22);
            this.chatStatusStrip.TabIndex = 4;
            this.chatStatusStrip.Text = "statusStrip1";
            // 
            // tssConnectionStatus
            // 
            this.tssConnectionStatus.Name = "tssConnectionStatus";
            this.tssConnectionStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // txtNewMessage
            // 
            this.txtNewMessage.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.txtNewMessage.Location = new System.Drawing.Point(117, 335);
            this.txtNewMessage.Multiline = true;
            this.txtNewMessage.Name = "txtNewMessage";
            this.txtNewMessage.Size = new System.Drawing.Size(386, 55);
            this.txtNewMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Location = new System.Drawing.Point(11, 335);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 27);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "שלח";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lstMessages
            // 
            this.lstMessages.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lstMessages.FullRowSelect = true;
            this.lstMessages.Location = new System.Drawing.Point(11, 25);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(491, 304);
            this.lstMessages.TabIndex = 4;
            this.lstMessages.UseCompatibleStateImageBehavior = false;
            this.lstMessages.View = System.Windows.Forms.View.Details;
            this.lstMessages.SelectedIndexChanged += new System.EventHandler(this.lstMessages_SelectedIndexChanged);
            // 
            // grbMessages
            // 
            this.grbMessages.BackColor = System.Drawing.Color.Transparent;
            this.grbMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grbMessages.Controls.Add(this.lstMessages);
            this.grbMessages.Controls.Add(this.txtNewMessage);
            this.grbMessages.Controls.Add(this.btnSend);
            this.grbMessages.Controls.Add(this.btnPrivate);
            this.grbMessages.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.grbMessages.ForeColor = System.Drawing.Color.White;
            this.grbMessages.Location = new System.Drawing.Point(9, 43);
            this.grbMessages.Name = "grbMessages";
            this.grbMessages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbMessages.Size = new System.Drawing.Size(517, 400);
            this.grbMessages.TabIndex = 5;
            this.grbMessages.TabStop = false;
            this.grbMessages.Text = "הודעות";
            // 
            // lnkCloseAccount
            // 
            this.lnkCloseAccount.AutoSize = true;
            this.lnkCloseAccount.BackColor = System.Drawing.Color.Transparent;
            this.lnkCloseAccount.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lnkCloseAccount.Location = new System.Drawing.Point(17, 18);
            this.lnkCloseAccount.Name = "lnkCloseAccount";
            this.lnkCloseAccount.Size = new System.Drawing.Size(82, 17);
            this.lnkCloseAccount.TabIndex = 9;
            this.lnkCloseAccount.TabStop = true;
            this.lnkCloseAccount.Text = "סגור חשבון";
            this.lnkCloseAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCloseAccount_LinkClicked);
            // 
            // ClientForm
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::ClientSide.Properties.Resources.abstract_wallpapers_backgrounds_for_powerpoint;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(539, 515);
            this.Controls.Add(this.lnkCloseAccount);
            this.Controls.Add(this.grbMessages);
            this.Controls.Add(this.chatStatusStrip);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnConnect);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "צ\'אט";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.Shown += new System.EventHandler(this.ClientForm_Shown);
            this.chatStatusStrip.ResumeLayout(false);
            this.chatStatusStrip.PerformLayout();
            this.grbMessages.ResumeLayout(false);
            this.grbMessages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.StatusStrip chatStatusStrip;
        private System.Windows.Forms.Button btnPrivate;
        private System.Windows.Forms.TextBox txtNewMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListView lstMessages;
        private System.Windows.Forms.GroupBox grbMessages;
        private System.Windows.Forms.ToolStripStatusLabel tssConnectionStatus;
        private System.Windows.Forms.LinkLabel lnkCloseAccount;
    }
}

