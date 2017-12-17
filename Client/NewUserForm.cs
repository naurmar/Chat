using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelsLibrary;

namespace ClientSide
{
    /// <summary>
    /// This class represent new user form
    /// </summary>
    public partial class NewUserForm : Form
    {
        public ChatUser newUser = null;
        private bool _nameIsValid;
        private bool _colorIsValid;
        private bool _passwordIsValid;
        private bool _nickNameIsValid;

        public NewUserForm()
        {
            InitializeComponent();
        }//c-tor

        private void NewUserForm_Load(object sender, EventArgs e)
        {
            InitColors();
            cmbColor.Text = "Black";
        }

        #region Validation
        private void cmbColor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), cmbColor.Text));
                inputErrorProvider.SetError(cmbColor, "");
                _colorIsValid = true;
                lblColorError.Text = string.Empty;
            }
            catch (Exception)
            {
                inputErrorProvider.SetError(cmbColor, "בחור צבע מרשימה");
                lblColorError.Text = "בחור צבע מרשימה";
                _colorIsValid = false;
            }
        }

        private void txtNickName_Validating(object sender, CancelEventArgs e)
        {
            if (txtNickName.TextLength < 3)
            {
                inputErrorProvider.SetError(txtNickName, "כינוי חייב להיות לפחות שלוש אותיות");
                lblNicknameError.Text = "כינוי חייב להיות לפחות שלוש אותיות";
            }
            else
            {
                inputErrorProvider.SetError(txtNickName, "");
                lblNicknameError.Text = string.Empty;
                _nickNameIsValid = true;
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.TextLength < 6 || txtPassword.TextLength > 12)
            {
                inputErrorProvider.SetError(txtPassword, "סיסמה חייבת להיות מ-6 עד 12 אותיות");
                lblPasswordError.Text = "סיסמה חייבת להיות מ-6 עד 12 אותיות";
            }
            else
            {
                inputErrorProvider.SetError(txtPassword, "");
                lblPasswordError.Text = string.Empty;
                _passwordIsValid = true;
            }
        }
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.TextLength < 4)
            {
                inputErrorProvider.SetError(txtName, "שם חייב להיות לפחות ארבע אותיות");
                //txtName.Focus();
                //_nameIsValid = false;
                lblNameError.Text = "שם חייב להיות לפחות ארבע אותיות";
            }
            else
            {
                inputErrorProvider.SetError(txtName, "");
                lblNameError.Text = string.Empty;
                _nameIsValid = true;
            }
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (_nameIsValid && _colorIsValid && _passwordIsValid && _nickNameIsValid)
                {
                    newUser = new ChatUser();
                    newUser.Name = txtName.Text;
                    newUser.Password = txtPassword.Text;
                    newUser.NickName = txtNickName.Text;
                    newUser.TextColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), cmbColor.Text));
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        //Fill drop down box to choose user message font color
        private void InitColors()
        {
            foreach (string colorName in Enum.GetNames(typeof(KnownColor)))
            {
                cmbColor.Items.Add(colorName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtNickName_TextChanged(object sender, EventArgs e)
        {
            if (txtNickName.TextLength < 3)
            {
                inputErrorProvider.SetError(txtNickName, "כינוי חייב להיות לפחות שלוש אותיות");
                //txtNickName.Focus();
                _nickNameIsValid = false;
                lblNicknameError.Text = "כינוי חייב להיות לפחות שלוש אותיות";
            }
            else
            {
                inputErrorProvider.SetError(txtNickName, "");
                lblNicknameError.Text = string.Empty;
                _nickNameIsValid = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.TextLength < 6 || txtPassword.TextLength > 12)
            {
                inputErrorProvider.SetError(txtPassword, "סיסמה חייבת להיות מ-6 עד 12 אותיות");
                txtPassword.Focus();
                _passwordIsValid = false;
                lblPasswordError.Text = "סיסמה חייבת להיות מ-6 עד 12 אותיות";
            }
            else
            {
                inputErrorProvider.SetError(txtPassword, "");
                lblPasswordError.Text = string.Empty;
                _passwordIsValid = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.TextLength < 4)
            {
                inputErrorProvider.SetError(txtName, "שם חייב להיות לפחות ארבע אותיות");
                _nameIsValid = false;
                lblNameError.Text = "שם חייב להיות לפחות ארבע אותיות";
            }
            else
            {
                inputErrorProvider.SetError(txtName, "");
                lblNameError.Text = string.Empty;
                _nameIsValid = true;
            }
        }

        private void cmbColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsLetter(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbColor.ForeColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), cmbColor.Text));
                _colorIsValid = true;
                inputErrorProvider.SetError(cmbColor, "");
                lblColorError.Text = string.Empty;
            }
            catch (Exception)
            {
                _colorIsValid = false;
            }
        }
    }
}
