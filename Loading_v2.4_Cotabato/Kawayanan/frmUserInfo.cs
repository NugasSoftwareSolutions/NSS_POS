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
    public partial class frmUserInfo : Form
    {
        public frmUserInfo()
        {
            InitializeComponent();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            UpdateGrid();
        }
        List<clsUsers> lstUsers=null;
        private void UpdateGrid()
        {
            lstUsers = clsUsers.GetUsers();
            dgvUsers.Rows.Clear();
            foreach (clsUsers user in lstUsers)
            {
                AddItemToGrid(user);
            }
        }

        private void AddItemToGrid(clsUsers user)
        {
            int rowidx = dgvUsers.Rows.Add();
            string logintype = "";
            switch (user.LoginType)
            {
                case 1: logintype = "Admin"; break;
                case 2: logintype = "Manager"; break;
                case 3: logintype = "Supervisor"; break;
                case 4: logintype = "Cashier"; break;
            }
            dgvUsers.Rows[rowidx].Cells[0].Value = user.UserName;
            dgvUsers.Rows[rowidx].Cells[1].Value = logintype;
            dgvUsers.Rows[rowidx].Cells[2].Value = user.Enabled;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                clsUsers user = clsUsers.GetUser(dgvUsers.SelectedRows[0].Cells["UserName"].Value.ToString());
                if (user != null)
                {
                    frmLoginReg loginreg = new frmLoginReg(true, user);
                    loginreg.ShowDialog();
                    UpdateGrid();
                }
            }
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                foreach (clsUsers user in lstUsers)
                {
                    if (user.UserName == dgvUsers.SelectedRows[0].Cells[0].Value.ToString())
                    {
                        user.Enabled = !user.Enabled;
                        user.Save();
                        UpdateGrid();
                        break;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                frmLoginReg loginreg = new frmLoginReg();
                loginreg.ShowDialog();
                UpdateGrid();
            }
        }

        private void frmUserInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=true;
            this.Hide();
        }
    }
}
