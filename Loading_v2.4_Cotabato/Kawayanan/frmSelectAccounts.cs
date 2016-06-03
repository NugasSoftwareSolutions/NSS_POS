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
    public partial class frmSelectAccounts : Form
    {
        private double AmountToCHarge = 0;
        clsUsers user = null;
        public frmSelectAccounts(double amountToCharge, clsUsers _user)
        {
            InitializeComponent();
            AmountToCHarge = amountToCharge;
            user = _user;
        }
        public clsAccountInfo SelectedAccount = null;
        List<clsAccountInfo> accounts = new List<clsAccountInfo>();
        private void DisplayAccounts()
        {
            if (txtName.Text.Trim() == "") return;
            accounts = clsAccountInfo.GetAccounts(txtName.Text.Trim());
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
                foreach (clsAccountInfo a in accounts)
                {
                    AddItemToGrid(a);
                }
            }
                
            }
        }

        private void AddItemToGrid(clsAccountInfo act)
        {
            int rowidx = dgvAccounts.Rows.Add();
            dgvAccounts.Rows[rowidx].Cells[0].Value = act.AccountId;
            dgvAccounts.Rows[rowidx].Cells[1].Value = act.AccountName;
            dgvAccounts.Rows[rowidx].Cells[2].Value = act.CreditLimit;
            dgvAccounts.Rows[rowidx].Cells[3].Value = act.PrincipalBalance;
            dgvAccounts.Rows[rowidx].Cells[4].Value = act.TotalInterest;
            dgvAccounts.Rows[rowidx].Cells[5].Value = act.AccountReceivable;
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
        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                SelectAcnt();
            }
        }

        private bool GetApproval(UserAccess accesslevel = UserAccess.Cashier)
        {
            if (user.LoginType <= (int)accesslevel)
            {
                return true;
            }
            else
            {
                if (accesslevel == UserAccess.Admin)
                    MessageBox.Show("This action requires approval from Administrator.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (accesslevel == UserAccess.Manager)
                    MessageBox.Show("This action requires approval from Manager.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (accesslevel == UserAccess.Supervisor)
                    MessageBox.Show("This action requires approval from Manager/Supervisor.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                frmApproval login = new frmApproval((int)accesslevel);
                if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    clsUsers iuser = login.m_User;
                    if (iuser.LoginType <= (int)accesslevel) return true;
            }
        }

            return false;
        }
        private enum UserAccess
        {
            Admin = 1,
            Manager = 2,
            Supervisor = 3,
            Cashier = 4
        }
        private clsAccountInfo GetAccountInfo(int accountid)
        {
            foreach (clsAccountInfo a in accounts)
            {
                if (a.AccountId == accountid) return a;
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
                if (AmountToCHarge>0 && (SelectedAccount.AccountReceivable + AmountToCHarge > SelectedAccount.CreditLimit && SelectedAccount.CreditLimit > 0))
                {
                    if (MessageBox.Show("Credit has exceeded the limit. Would you like to continue?", "Credit Limit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (GetApproval(UserAccess.Manager) == false) return;
                    }
                    else
                    {
                        return;
                    }
                }

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

        private void btnNonMember_Click( object sender, EventArgs e )
        {
            txtName.Text = "(Non-Member)";
            DisplayAccounts();
        }

        private void txtName_TextChanged( object sender, EventArgs e )
        {

        }

        private void subPan_Paint( object sender, PaintEventArgs e )
        {

        }

        private void lblCaption_Click( object sender, EventArgs e )
        {

        }

    }
}
