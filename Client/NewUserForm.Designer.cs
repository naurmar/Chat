namespace ClientSide
{
    partial class NewUserForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.inputErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblNameError = new System.Windows.Forms.Label();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.lblNicknameError = new System.Windows.Forms.Label();
            this.lblColorError = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.inputErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtName.Location = new System.Drawing.Point(36, 87);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(179, 23);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "שם משתמש";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(36, 142);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.Size = new System.Drawing.Size(179, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "סיסמה";
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(36, 199);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNickName.Size = new System.Drawing.Size(179, 23);
            this.txtNickName.TabIndex = 2;
            this.txtNickName.Text = "כינוי";
            this.txtNickName.TextChanged += new System.EventHandler(this.txtNickName_TextChanged);
            this.txtNickName.Validating += new System.ComponentModel.CancelEventHandler(this.txtNickName_Validating);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.btnOk.Location = new System.Drawing.Point(126, 300);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "הרשם";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // inputErrorProvider
            // 
            this.inputErrorProvider.ContainerControl = this;
            // 
            // lblNameError
            // 
            this.lblNameError.AutoSize = true;
            this.lblNameError.Font = new System.Drawing.Font("Tahoma", 6F);
            this.lblNameError.ForeColor = System.Drawing.Color.Red;
            this.lblNameError.Location = new System.Drawing.Point(36, 72);
            this.lblNameError.Name = "lblNameError";
            this.lblNameError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNameError.Size = new System.Drawing.Size(0, 12);
            this.lblNameError.TabIndex = 5;
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.Font = new System.Drawing.Font("Tahoma", 6F);
            this.lblPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordError.Location = new System.Drawing.Point(35, 127);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPasswordError.Size = new System.Drawing.Size(0, 12);
            this.lblPasswordError.TabIndex = 6;
            // 
            // lblNicknameError
            // 
            this.lblNicknameError.AutoSize = true;
            this.lblNicknameError.Font = new System.Drawing.Font("Tahoma", 6F);
            this.lblNicknameError.ForeColor = System.Drawing.Color.Red;
            this.lblNicknameError.Location = new System.Drawing.Point(35, 184);
            this.lblNicknameError.Name = "lblNicknameError";
            this.lblNicknameError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNicknameError.Size = new System.Drawing.Size(0, 12);
            this.lblNicknameError.TabIndex = 7;
            // 
            // lblColorError
            // 
            this.lblColorError.AutoSize = true;
            this.lblColorError.Font = new System.Drawing.Font("Tahoma", 6F);
            this.lblColorError.ForeColor = System.Drawing.Color.Red;
            this.lblColorError.Location = new System.Drawing.Point(36, 239);
            this.lblColorError.Name = "lblColorError";
            this.lblColorError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblColorError.Size = new System.Drawing.Size(0, 12);
            this.lblColorError.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 7.5F);
            this.btnCancel.Location = new System.Drawing.Point(36, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "ביטול";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "כדי להירשם מלא את השדות";
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(36, 249);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(178, 24);
            this.cmbColor.TabIndex = 11;
            this.cmbColor.SelectedIndexChanged += new System.EventHandler(this.cmbColor_SelectedIndexChanged);
            this.cmbColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbColor_KeyPress);
            this.cmbColor.Validating += new System.ComponentModel.CancelEventHandler(this.cmbColor_Validating);
            // 
            // NewUserForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(250, 358);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblColorError);
            this.Controls.Add(this.lblNicknameError);
            this.Controls.Add(this.lblPasswordError);
            this.Controls.Add(this.lblNameError);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewUserForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "משתמש חדש";
            this.Load += new System.EventHandler(this.NewUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ErrorProvider inputErrorProvider;
        private System.Windows.Forms.Label lblColorError;
        private System.Windows.Forms.Label lblNicknameError;
        private System.Windows.Forms.Label lblPasswordError;
        private System.Windows.Forms.Label lblNameError;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbColor;
    }
}