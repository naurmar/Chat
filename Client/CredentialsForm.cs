using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    /// <summary>
    /// The form intended get credentials from user
    /// </summary>
    public partial class CredentialsForm : Form
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public CredentialsForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UserName = txtName.Text;
            Password = txtPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CredentialsForm_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }
    }
}
