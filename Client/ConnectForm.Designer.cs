namespace ClientSide
{
    partial class ConnectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.nmrPort = new System.Windows.Forms.NumericUpDown();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.inputErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grbConnectPoint = new System.Windows.Forms.GroupBox();
            this.lblIPError = new System.Windows.Forms.Label();
            this.grbUserCredentials = new System.Windows.Forms.GroupBox();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.lblUserNameError = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblRegister = new System.Windows.Forms.Label();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputErrorProvider)).BeginInit();
            this.grbConnectPoint.SuspendLayout();
            this.grbUserCredentials.SuspendLayout();
            this.SuspendLayout();
            // 
            // nmrPort
            // 
            this.nmrPort.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrPort.Increment = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.nmrPort.Location = new System.Drawing.Point(33, 96);
            this.nmrPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nmrPort.Name = "nmrPort";
            this.nmrPort.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nmrPort.Size = new System.Drawing.Size(159, 23);
            this.nmrPort.TabIndex = 1;
            this.nmrPort.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPAddress.Location = new System.Drawing.Point(32, 47);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIPAddress.Size = new System.Drawing.Size(160, 23);
            this.txtIPAddress.TabIndex = 0;
            this.txtIPAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIPAddress_KeyPress);
            this.txtIPAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtIPAddress_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(34, 52);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserName.Size = new System.Drawing.Size(220, 23);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Text = "שם משתמש";
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(54, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ביטול";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.BackColor = System.Drawing.Color.Transparent;
            this.lblIp.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIp.ForeColor = System.Drawing.Color.Black;
            this.lblIp.Location = new System.Drawing.Point(217, 50);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(66, 17);
            this.lblIp.TabIndex = 3;
            this.lblIp.Text = "כתובת IP";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.BackColor = System.Drawing.Color.Transparent;
            this.lblPort.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.ForeColor = System.Drawing.Color.Black;
            this.lblPort.Location = new System.Drawing.Point(244, 102);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(39, 17);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "פורט";
            // 
            // inputErrorProvider
            // 
            this.inputErrorProvider.ContainerControl = this;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(33, 102);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(221, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "סיסמה";
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // grbConnectPoint
            // 
            this.grbConnectPoint.BackColor = System.Drawing.Color.Transparent;
            this.grbConnectPoint.Controls.Add(this.lblIPError);
            this.grbConnectPoint.Controls.Add(this.txtIPAddress);
            this.grbConnectPoint.Controls.Add(this.nmrPort);
            this.grbConnectPoint.Controls.Add(this.lblIp);
            this.grbConnectPoint.Controls.Add(this.lblPort);
            this.grbConnectPoint.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbConnectPoint.Location = new System.Drawing.Point(29, 25);
            this.grbConnectPoint.Name = "grbConnectPoint";
            this.grbConnectPoint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbConnectPoint.Size = new System.Drawing.Size(306, 147);
            this.grbConnectPoint.TabIndex = 3;
            this.grbConnectPoint.TabStop = false;
            this.grbConnectPoint.Text = "נקודת חיבור";
            // 
            // lblIPError
            // 
            this.lblIPError.AutoSize = true;
            this.lblIPError.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.lblIPError.ForeColor = System.Drawing.Color.Red;
            this.lblIPError.Location = new System.Drawing.Point(34, 30);
            this.lblIPError.Name = "lblIPError";
            this.lblIPError.Size = new System.Drawing.Size(0, 14);
            this.lblIPError.TabIndex = 2;
            // 
            // grbUserCredentials
            // 
            this.grbUserCredentials.BackColor = System.Drawing.Color.Transparent;
            this.grbUserCredentials.Controls.Add(this.lblPasswordError);
            this.grbUserCredentials.Controls.Add(this.lblUserNameError);
            this.grbUserCredentials.Controls.Add(this.txtPassword);
            this.grbUserCredentials.Controls.Add(this.txtUserName);
            this.grbUserCredentials.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbUserCredentials.Location = new System.Drawing.Point(29, 178);
            this.grbUserCredentials.Name = "grbUserCredentials";
            this.grbUserCredentials.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbUserCredentials.Size = new System.Drawing.Size(306, 151);
            this.grbUserCredentials.TabIndex = 0;
            this.grbUserCredentials.TabStop = false;
            this.grbUserCredentials.Text = "פרטי משתמש";
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.Font = new System.Drawing.Font("Tahoma", 7F);
            this.lblPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordError.Location = new System.Drawing.Point(35, 85);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.Size = new System.Drawing.Size(0, 14);
            this.lblPasswordError.TabIndex = 3;
            // 
            // lblUserNameError
            // 
            this.lblUserNameError.AutoSize = true;
            this.lblUserNameError.Font = new System.Drawing.Font("Tahoma", 7F);
            this.lblUserNameError.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameError.Location = new System.Drawing.Point(34, 34);
            this.lblUserNameError.Name = "lblUserNameError";
            this.lblUserNameError.Size = new System.Drawing.Size(0, 14);
            this.lblUserNameError.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(142, 409);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "הכנס";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.BackColor = System.Drawing.Color.Transparent;
            this.lblRegister.Font = new System.Drawing.Font("Tahoma", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblRegister.Location = new System.Drawing.Point(199, 354);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(131, 17);
            this.lblRegister.TabIndex = 5;
            this.lblRegister.Text = "? עדיין לא נרשמת";
            // 
            // lnkRegister
            // 
            this.lnkRegister.ActiveLinkColor = System.Drawing.Color.Turquoise;
            this.lnkRegister.AutoSize = true;
            this.lnkRegister.BackColor = System.Drawing.Color.Transparent;
            this.lnkRegister.Location = new System.Drawing.Point(151, 354);
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(47, 17);
            this.lnkRegister.TabIndex = 6;
            this.lnkRegister.TabStop = true;
            this.lnkRegister.Text = "הרשם";
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClientSide.Properties.Resources.abstract_wallpapers_backgrounds_for_powerpoint;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(365, 455);
            this.Controls.Add(this.lnkRegister);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grbUserCredentials);
            this.Controls.Add(this.grbConnectPoint);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "חיבור לשרת";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputErrorProvider)).EndInit();
            this.grbConnectPoint.ResumeLayout(false);
            this.grbConnectPoint.PerformLayout();
            this.grbUserCredentials.ResumeLayout(false);
            this.grbUserCredentials.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nmrPort;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ErrorProvider inputErrorProvider;
        private System.Windows.Forms.GroupBox grbUserCredentials;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.GroupBox grbConnectPoint;
        private System.Windows.Forms.Label lblPasswordError;
        private System.Windows.Forms.Label lblUserNameError;
        private System.Windows.Forms.Label lblIPError;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.Label lblRegister;
    }
}