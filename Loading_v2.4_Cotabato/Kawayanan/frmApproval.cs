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
    public partial class frmApproval : Form
    {
        private int AccessLevel=1;
        public clsUsers m_User = null;

        public frmApproval(int accesslevel)
        {
            InitializeComponent();
            AccessLevel = accesslevel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_User = new clsUsers();
            if (m_User.Login(cboAccount.SelectedItem.ToString(), txtPassword.Text))
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

        private void frmApproval_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            int selidx = -1;
            List<clsUsers> lstUsers = clsUsers.GetUsers();
            foreach (clsUsers user in lstUsers)
            {
                if (user.LoginType <= AccessLevel)
                    cboAccount.Items.Add(user.UserName);
                if (user.LoginType > 1) selidx = cboAccount.Items.Count - 1;
            }
            if (selidx == -1) selidx = 0;
            if (cboAccount.Items.Count > 0) cboAccount.SelectedIndex = selidx;
        }

        private void cboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPassword.Focus();
            txtPassword.SelectAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(null, null);
            }
        }

       
    }
}
