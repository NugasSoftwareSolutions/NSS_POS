using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class;
using AlreySolutions.Class.Load;

namespace AlreySolutions
{
    public partial class frmSelectCustomer : Form
    {
        clsLoadAccount m_loadaccount = null;
        public frmSelectCustomer(clsLoadAccount act, string name)
        {
            InitializeComponent();
            m_loadaccount = act;
            txtName.Text = name;
        }
        public clsSubDAccount SelectedAccount = null;
        List<clsSubDAccount> accounts = new List<clsSubDAccount>();

        private void DisplayAccounts()
        {
            if (txtName.Text.Trim() == "") return;
            accounts = clsSubDAccount.GetSubDAccounts(m_loadaccount.LoadId, txtName.Text.Trim());
            if (accounts != null)
            {
                if (accounts.Count == 1)
                {
                    SelectedAccount = accounts[0];
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    dgvAccounts.Rows.Clear();
                    foreach (clsSubDAccount a in accounts)
                    {
                        AddItemToGrid(a);
                    }
                }

            }
        }

        private void AddItemToGrid(clsSubDAccount act)
        {
            int rowidx = dgvAccounts.Rows.Add();
            dgvAccounts.Rows[rowidx].Cells[0].Value = act.Id_subdAccounts;
            dgvAccounts.Rows[rowidx].Cells[1].Value = act.Name;
            dgvAccounts.Rows[rowidx].Cells[2].Value = act.MobileNum;
            dgvAccounts.Rows[rowidx].Cells[3].Value = act.Balance;
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            DisplayAccounts();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                SelectAcnt();
            }
        }

        private clsSubDAccount GetAccountInfo(int accountid)
        {
            foreach (clsSubDAccount a in accounts)
            {
                if (a.Id_subdAccounts == accountid) return a;
            }
            return null;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayAccounts();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgvAccounts.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
                SelectAcnt();
            }
        }

        private void SelectAcnt()
        {

            if (dgvAccounts.Rows.Count >= 1)
            {
                SelectedAccount = GetAccountInfo(Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells[0].Value));
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void dgvAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SelectAcnt();
                }
                else if (e.KeyCode == Keys.Up && dgvAccounts.SelectedRows[0].Index == 0)
                {
                    dgvAccounts.Focus();
                }
            }
        }

    }
}
