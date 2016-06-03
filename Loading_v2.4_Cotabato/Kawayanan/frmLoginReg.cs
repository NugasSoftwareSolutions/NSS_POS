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
    public partial class frmLoginReg : Form
    {
        private clsUsers m_user = null;
        public frmLoginReg(bool updatepassword=false,clsUsers user=null)
        {
            InitializeComponent();
            m_user = user;
            if (updatepassword && user != null)
            {
                txtUserName.Text = user.UserName;
                txtUserName.Enabled = false;
                cboUserType.SelectedIndex = user.LoginType-1;
                chkEnabled.Checked = user.Enabled;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            clsUsers m_User = new clsUsers();
            
            if (txtUserName.Text!="")
            {
                if (txtPassword.Text == txtPasswordConfirm.Text)
                {
                    if (txtPassword.Text != "")
                    {
                        m_User.UserName = txtUserName.Text;
                        m_User.Password = txtPassword.Text;
                        m_User.LoginType = cboUserType.SelectedIndex + 1;
                        m_User.Enabled = chkEnabled.Checked;
                        if (!m_User.Save())
                            MessageBox.Show("User Account not saved", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Must specify password.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Password Mismatched!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPasswordConfirm.Focus();
                    txtPasswordConfirm.SelectAll();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            txtUserName.Focus();
            cboUserType.SelectedIndex = 3;
        }
    }
}
