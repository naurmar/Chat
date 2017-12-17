using ChatConfiguration;
using ModelsLibrary;
using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace ClientSide
{
    /// <summary>
    /// Connection UI form to get connection point and user details from client
    /// </summary>
    public partial class ConnectForm : Form
    {
        #region Properties
        public ChatUser User = null;
        public IPEndPoint EndPoint { get; set; }
        private bool _nameIsValid;
        private bool _passwordIsValid;
        #endregion

        public ConnectForm()
        {
            InitializeComponent();
            txtIPAddress.Text = ConfigProvider.ConnectionPoint.Address.ToString();
        }//c-tor

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        //Register new chat user
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewUserForm newUserForm = new NewUserForm();
            //Get new user from NewUserForm
            newUserForm.ShowDialog();
            if (newUserForm.DialogResult == DialogResult.OK)
            {
                User = newUserForm.newUser;
                txtUserName.Text = User.Name;
                txtPassword.Text = User.Password;
                btnOk.Text = "הרשם";
            }
            lnkRegister.LinkVisited = true;
            btnOk.Select();
        }

        //Cancel connect to server
        private void btnCancel_Click(object sender, EventArgs e)
        {
            inputErrorProvider.Clear();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //Connect to server
        private void btnOk_Click(object sender, EventArgs e)
        {
            //Check for valid data
            if (ValidateChildren(ValidationConstraints.Enabled) && _passwordIsValid && _nameIsValid)
            {
                if (User == null)
                {
                    User = new ChatUser();
                    User.Name = txtUserName.Text;
                    User.Password = txtPassword.Text;
                    DialogResult = DialogResult.OK;
                }
                else if (User.Id != new Guid())
                {
                    DialogResult = DialogResult.OK;
                }
                else
                    DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                MessageBox.Show("עליך למלאות את השדות");
                txtUserName.Focus();
            }
        }
        #region Control Validation
        //Validate IP Adress
        private void txtIPAddress_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                EndPoint = new IPEndPoint(IPAddress.Parse(txtIPAddress.Text), (int)nmrPort.Value);
                inputErrorProvider.SetError(txtIPAddress, "");
                lblIPError.Text = string.Empty;
            }
            catch (Exception)
            {
                inputErrorProvider.SetError(txtIPAddress, "נקודת חיבור לא תקינה");
                lblIPError.Text = "נקודת חיבור לא תקינה";
                e.Cancel = true;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.TextLength < 6 || txtPassword.TextLength > 12)
            {
                inputErrorProvider.SetError(txtPassword, "סיסמה חייבת להיות מ-6 עד 12 אותיות");
               // txtUserName.Focus();
                _passwordIsValid = false;
                lblPasswordError.Text = "סיסמה חייבת להיות מ-6 עד 12 אותיות";
            }
            else
            {
                inputErrorProvider.SetError(txtPassword, string.Empty);
                lblPasswordError.Text = string.Empty;
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.TextLength < 4)
            {
                lblUserNameError.Text = "שם חייב להיות לפחות ארבע אותיות";
                _nameIsValid = false;
            }
            else
            {
                _nameIsValid = true;
                lblUserNameError.Text = string.Empty;
            }
        }

        //IP Address validation for key press
        private void txtIPAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        //User name validation for key press
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.TextLength < 4)
            {
                inputErrorProvider.SetError(txtUserName, "שם חייב להיות לפחות ארבע אותיות");
                txtUserName.Focus();
                _nameIsValid = false;
                lblUserNameError.Text = "שם חייב להיות לפחות ארבע אותיות";
            }
            else
            {
                inputErrorProvider.SetError(txtUserName, "");
                lblUserNameError.Text = string.Empty;
                _nameIsValid = true;
            }
        }

        //User password validation for key press
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.TextLength < 6|| txtPassword.TextLength >12)
            {
                inputErrorProvider.SetError(txtPassword, "סיסמה חייבת להיות מ-6 עד 12 אותיות");
                _passwordIsValid = false;
                lblPasswordError.Text = "סיסמה חייבת להיות מ-6 עד 12 אותיות";
            }
            else
            {
                inputErrorProvider.SetError(txtPassword, string.Empty);
                lblPasswordError.Text = string.Empty;
                _passwordIsValid = true;
            }
        }
        #endregion      
    }
}
