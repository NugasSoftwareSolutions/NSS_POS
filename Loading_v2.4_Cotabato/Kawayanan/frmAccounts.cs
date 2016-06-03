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
    public partial class frmAccounts : Form
    {
        double TotalAccountsReceivable = 0;


        public frmAccounts()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Account Name must have a value.", "New Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsAccountInfo ac = new clsAccountInfo(Convert.ToInt32(lblAccountId.Text));
            if (ac != null && ac.AccountId>0)
            {
                ac.CreditLimit = Convert.ToDouble(txtLimit.Text);
            }
            else
            {
                ac.AccountId = Convert.ToInt32(lblAccountId.Text);
                ac.AccountName = txtName.Text.Trim();
                if (txtLimit.Text.Trim() != "")
                    ac.CreditLimit = Convert.ToDouble(txtLimit.Text);
                else
                    ac.CreditLimit = 0;
            }
            if (ac.Save())
            {
                ClearFields();
            }
            DisplayAccounts();
        }

        private void ClearFields()
        {
            lblAccountId.Text = "0";
            txtName.Text = "";
            txtLimit.Text = "0";
            txtName.Focus();

        }
        List<clsAccountInfo> accounts = new List<clsAccountInfo>();
        private void DisplayAccounts()
        {
            accounts = clsAccountInfo.GetAccounts("");
            if (accounts != null)
            {
                //dgvAccounts.Rows.Clear();
                //foreach (clsAccountInfo a in accounts)
                //{
                //    AddItemToGrid(a);
                //}
                dgvAccounts.DataSource = accounts;
                dgvAccounts.AutoGenerateColumns = true;
            }
        }

        private void AddItemToGrid(clsAccountInfo act)
        {
            int rowidx = dgvAccounts.Rows.Add();
            dgvAccounts.Rows[rowidx].Cells[0].Value = act.AccountId;
            dgvAccounts.Rows[rowidx].Cells[1].Value = act.AccountName;
            dgvAccounts.Rows[rowidx].Cells[2].Value = act.CreditLimit;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Are you sure you want to delete this account?", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (clsAccountInfo a in accounts)
                    {
                        if (a.AccountId.ToString() == dgvAccounts.SelectedRows[0].Cells[0].Value.ToString())
                        {
                            a.Delete();
                            DisplayAccounts();
                            return;
                        }
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                lblAccountId.Text = dgvAccounts.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvAccounts.SelectedRows[0].Cells[1].Value.ToString();
                txtLimit.Text = dgvAccounts.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            DisplayAccounts();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool IsNumericOnly = true;
        bool withDecimal = false;
        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsNumericOnly)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnOk.PerformClick();
                }
                else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                    || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                    || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                {

                }
                else
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void frmAccounts_Shown(object sender, EventArgs e)
        {
            DisplayAccounts();
        }

        private void txtLimit_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = false;
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnOk.PerformClick();
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {

            }
            else
            {
                e.SuppressKeyPress = true;
            }

        }

        private void frmAccounts_FormClosing( object sender, FormClosingEventArgs e )
        {
            e.Cancel = true;
            this.Hide();
        }


    }
}
