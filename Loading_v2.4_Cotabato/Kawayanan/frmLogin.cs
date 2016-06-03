using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class;

namespace AlreySolutions
{
    public partial class frmLogin : Form
    {
        public clsUsers m_User = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_User = new clsUsers();
            if (m_User.Login(txtUserName.Text, txtPassword.Text))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (txtPassword.Text == "")
            {
                txtPassword.SelectAll();
                txtPassword.Focus();
            
            }
            else
            {
                MessageBox.Show("Invalid Username/Password", "Credentials", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            txtUserName.Focus();
            if (dbConnect.HaveAdmin()) btnRegister.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmLoginReg reg = new frmLoginReg();
            reg.ShowDialog();
        }

    }
}
