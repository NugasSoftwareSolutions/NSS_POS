using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AlreySolutions.Class;
using AlreySolutions.Class.Load;

namespace AlreySolutions.LoadingStation
{
    public partial class frmLoadAccounts : Form
    {
        clsUsers m_user = null;
        List<clsLoadAccount> m_ListAccounts = null;
        public frmLoadAccounts(clsUsers user)
        {
            InitializeComponent();
            m_user = user;
        }

        byte[] ImageData = null;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs;
                BinaryReader br;
                fs = new FileStream(fileDlg.FileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);

                MemoryStream mem = new MemoryStream(ImageData);
                picImage.Image = Image.FromStream(mem);

                br.Close();
                fs.Close();
                mem.Close();
                
            }
        }

        private void frmLoadAccounts_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings( Properties.Settings.Default.Theme));
            ReloadAccounts();
            ClearFields();

        }

        private void ReloadAccounts()
        {
            m_ListAccounts = clsLoadAccount.GetLoadAccounts();
            dgvLoadAccounts.Rows.Clear();
            foreach (clsLoadAccount act in m_ListAccounts)
            {
                AddItemToGrid(act);
            }
        }
        private void AddItemToGrid(clsLoadAccount act)
        {
            int rowidx = dgvLoadAccounts.Rows.Add();

            dgvLoadAccounts.Rows[rowidx].Cells[0].Value = act.LoadId;
            dgvLoadAccounts.Rows[rowidx].Cells[1].Value = act.AccountNum;
            dgvLoadAccounts.Rows[rowidx].Cells[2].Value = act.MobileNum;
            dgvLoadAccounts.Rows[rowidx].Cells[3].Value = act.Description;
            dgvLoadAccounts.Rows[rowidx].Cells[4].Value = act.CurrentBalance.ToString("0.00");
            dgvLoadAccounts.Rows[rowidx].Cells[5].Value = act.AvailableBalance.ToString("0.00");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Supervisor)) return;
            if (ValidateFields())
            {
                clsLoadAccount m_loadaccount = GetSelAccount();
                if (m_loadaccount == null)
                {
                    m_loadaccount = new clsLoadAccount();
                    m_loadaccount.LoadId = 0;
                }
                m_loadaccount.AccountNum = txtAccountNum.Text.Trim();
                m_loadaccount.AvailableBalance = Convert.ToDouble(txtAvailBal.Text);
                m_loadaccount.CurrentBalance = Convert.ToDouble(txtCurBal.Text);
                m_loadaccount.Description = txtDesc.Text.Trim();
                m_loadaccount.ImgFile = ImageData;
                m_loadaccount.LoadType = clsLoadAccount.GetLoadType(cboLoadType.Text);
                m_loadaccount.MobileNum = txtMobile.Text.Trim();
                if (!m_loadaccount.Save())
                {
                    MessageBox.Show("Load Account Not Saved!", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ClearFields();
                    ReloadAccounts();
                    btnNew.PerformClick();
                }
            }
            else
            {
                MessageBox.Show("Please fillout necessary field(s).", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateFields()
        {
            if (cboLoadType.SelectedIndex == -1 || string.IsNullOrEmpty(txtAccountNum.Text) || string.IsNullOrEmpty(txtDesc.Text)
                || string.IsNullOrEmpty(txtMobile.Text) || string.IsNullOrEmpty(txtAvailBal.Text) || string.IsNullOrEmpty(txtCurBal.Text))
                return false;
            else return true;
        }

        private void ClearFields()
        {
            cboLoadType.SelectedIndex = 0;
            txtAccountNum.Text = "";
            txtMobile.Text = "";
            txtDesc.Text = "";
            txtCurBal.Text = "0";
            txtAvailBal.Text = "0";
            ImageData = null;
            picImage.Image = null;
            dgvLoadAccounts.ClearSelection();
        }
        private void UpdateFields(clsLoadAccount act)
        {
            if (act != null)
            {
                cboLoadType.SelectedIndex = (int)act.LoadType;
                txtAccountNum.Text = act.AccountNum;
                txtMobile.Text = act.MobileNum;
                txtDesc.Text = act.Description;
                txtCurBal.Text = act.CurrentBalance.ToString("0.00");
                txtAvailBal.Text = act.AvailableBalance.ToString("0.00");
                ImageData = act.ImgFile;
                if (ImageData != null)
                {
                    MemoryStream mem = new MemoryStream(ImageData);
                    picImage.Image = Image.FromStream(mem);
                    mem.Close();
                }
                else
                {
                    picImage.Image = null;
                }
            }

        }

        private clsLoadAccount GetSelAccount()
        {
            if (dgvLoadAccounts.SelectedRows.Count > 0)
            {
                int loadid = Convert.ToInt32(dgvLoadAccounts.SelectedRows[0].Cells[0].Value);
                if (loadid > 0)
                {
                    foreach (clsLoadAccount act in m_ListAccounts)
                    {
                        if (act.LoadId == loadid)
                        {
                            return act;
                        }
                    }
                }
            }
            return null;
        }
        private void dgvLoadAccounts_SelectionChanged(object sender, EventArgs e)
        {
            
            UpdateFields(GetSelAccount());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Manager)) return;
            clsLoadAccount selact = GetSelAccount();
            if (selact != null)
            {
                frmReloadAccount reload = new frmReloadAccount(selact, m_user);
                if (reload.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ReloadAccounts();
                }
            }
            else
            {
                MessageBox.Show("No Account Selected", "Reload", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSvcFee_Click(object sender, EventArgs e)
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Supervisor)) return; 
            clsLoadAccount acc = GetSelAccount();
            if (acc != null)
            {
                frmServiceFee svc = new frmServiceFee(acc);
                svc.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Manager)) return;
            clsLoadAccount acc = GetSelAccount();
            if (acc != null)
            {
                if (MessageBox.Show(string.Format("Are you sure you want to delete {0} with mobile number {1}?",acc.Description, acc.MobileNum), "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    bool ret = acc.Delete();
                    if (ret) MessageBox.Show("It has been successfully Deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Failed to Delete the account.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    ClearFields();
                    ReloadAccounts();
                    
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Supervisor)) return;
            clsLoadAccount acc = GetSelAccount();
            if (acc != null)
            {
                if (acc.LoadType == LoadAccountType.GCash)
                {
                    if (MessageBox.Show(string.Format("Are you sure you want to reset Load Account to {0:0.00}?", Properties.Settings.Default.GCashResetAmount), "Reset Load", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        
                        clsReloadHistory reload = new clsReloadHistory();
                        reload.Amount = Convert.ToDouble(acc.CurrentBalance-Properties.Settings.Default.GCashResetAmount);
                        reload.Load_Id = acc.LoadId;
                        reload.RefNum = string.Format("RESETACCNT{0:yyyyMMddHHssmm}", DateTime.Now);
                        reload.Timestamp = DateTime.Now;
                        reload.UserId = m_user.UserId;
                        reload.Remarks = "Reset GCASH Account";
                        reload.TransactionAmount = 0;
                        reload.RemainingBalance = Properties.Settings.Default.GCashResetAmount;
                        if (reload.Save())
                        {
                            acc.CurrentBalance = reload.RemainingBalance;
                            acc.AvailableBalance = reload.RemainingBalance;

                            if (acc.Save())
                            {
                                reload.PrintReceipt(acc);
                                ReloadAccounts();
                            }
                            else
                            {
                                MessageBox.Show("Account Balance was not reset!", "Reset Balance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                    }
                }
                else
                {
                    MessageBox.Show("This is only applicable to GCash Account", "Reset Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnFundTransfer_Click(object sender, EventArgs e)
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Supervisor)) return;
            clsLoadAccount acc = GetSelAccount();
            if (acc != null)
            {
                frmInput input = new frmInput();
                input.withDecimal = true;
                input.IsNumericOnly = true;
                input.Value = "";
                input.Title = "Fund Transfer";
                input.Caption = "Enter amount to transfer";
                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    clsReloadHistory reload = new clsReloadHistory();
                    reload.Amount = Convert.ToDouble(input.Value);
                    reload.Load_Id = acc.LoadId;
                    reload.RefNum = string.Format("FUNDTRANS{0:yyyyMMddHHssmm}",DateTime.Now);
                    reload.Timestamp = DateTime.Now;
                    reload.UserId = m_user.UserId;
                    reload.Remarks = "Fund Transfer";
                    reload.TransactionAmount = 0;
                    reload.RemainingBalance = acc.CurrentBalance - Convert.ToDouble(input.Value);
                    if (reload.Save())
                    {
                        acc.CurrentBalance = reload.RemainingBalance;
                        acc.AvailableBalance = reload.RemainingBalance;
                        if (acc.Save())
                        {
                            reload.PrintReceipt(acc);
                            ReloadAccounts();
                        }
                        else
                        {
                            MessageBox.Show("Fund Transfer Failed!", "Fund Transfer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSubD_Click(object sender, EventArgs e)
        {
            clsLoadAccount ac = GetSelAccount();
            if (ac != null)
            {
                frmSubDAccounts subd = new frmSubDAccounts(ac);
                subd.ShowDialog();
            }
        }
    }
}
