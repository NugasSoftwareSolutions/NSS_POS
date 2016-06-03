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
    public partial class frmAccountsReceivable : Form
    {
        clsPurchasedItem m_ListPurchases = new clsPurchasedItem();
        clsUsers m_user = null;
        List<clsChargedTransaction> m_Charges = new List<clsChargedTransaction>();
        List<clsPaymentInfo> m_Payments = new List<clsPaymentInfo>();
        Receipt m_Receipt = null;
        List<clsAccountInfo> m_Accounts = new List<clsAccountInfo>();
        public frmAccountsReceivable(clsUsers user)
        {
            InitializeComponent();
            m_user = user;
        }
        private void DisplayAccounts(string name)
        {
            double total = 0;
            m_Accounts = clsAccountInfo.GetAccounts(name);
            frmProgress progress = new frmProgress(m_Accounts.Count);
            progress.Caption = "Loading Accounts";
            progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            progress.Show(); 

            if (m_Accounts != null)
            {
                dgvAccounts.Rows.Clear();
                foreach (clsAccountInfo a in m_Accounts)
                {
                    AddItemToGrid(a);
                    total += a.AccountReceivable;
                    progress.Val += 1;
                    
                }
            }
            progress.Close();
            lblTotalReceivable.Text = string.Format("Accounts Receivable: P {0:0.00}", total);
            UpdateAccounts();
        }

        private void AddItemToGrid(clsAccountInfo act)
        {
            int rowidx = dgvAccounts.Rows.Add();
            dgvAccounts.Rows[rowidx].Cells[0].Value = act.AccountId;
            dgvAccounts.Rows[rowidx].Cells[1].Value = act.AccountName;
            dgvAccounts.Rows[rowidx].Cells[2].Value = act.YTDTransaction;
            dgvAccounts.Rows[rowidx].Cells[3].Value = act.PrincipalBalance;
            dgvAccounts.Rows[rowidx].Cells[4].Value = act.TotalInterest;
            dgvAccounts.Rows[rowidx].Cells[5].Value = act.AccountReceivable;
        }



        private void UpdateAccountsReceivable( int accountid )
        {
            m_Charges = clsChargedTransaction.GetChargedTransactions(accountid);
            dgvReceivable.Rows.Clear();
            if (m_Charges != null)
            {
                foreach (clsChargedTransaction ChargeTrans in m_Charges)
                {
                    if (ChargeTrans.ChargedAmount > 0)
                    {
                        int rowidx = dgvReceivable.Rows.Add();
                        dgvReceivable.Rows[rowidx].Cells[0].Value = ChargeTrans.Timestamp;
                        dgvReceivable.Rows[rowidx].Cells[1].Value = ChargeTrans.ORNum;
                        dgvReceivable.Rows[rowidx].Cells[2].Value = ChargeTrans.AccountName;
                        dgvReceivable.Rows[rowidx].Cells[3].Value = ChargeTrans.ChargedAmount;
                    }
                }
            }

        }

        private void AddPaymentsReceivedItemToGrid(int accountid)
        {
            m_Payments = clsPaymentInfo.GetPaymentsInfo(accountid);
            dgvPayments.Rows.Clear();
            foreach (clsPaymentInfo payment in m_Payments)
            {
                int rowidx = dgvPayments.Rows.Add();
                dgvPayments.Rows[rowidx].Cells[0].Value = payment.Timestamp;
                dgvPayments.Rows[rowidx].Cells[1].Value = payment.AccountName;
                dgvPayments.Rows[rowidx].Cells[2].Value = payment.AmountPaid;
                dgvPayments.Rows[rowidx].Cells[3].Value = payment.Remarks;
                dgvPayments.Rows[rowidx].Cells[4].Value = payment.UserName;
            }
        }

        private void AddPurchasedItemToGrid(int ornum)
        {
            m_Receipt = new Receipt(ornum);
            dgvPurchase.Rows.Clear();
            foreach (clsPurchasedItem fitem in m_Receipt.PurchasedItems.Values)
            {
                int rowidx = dgvPurchase.Rows.Add();
                dgvPurchase.Rows[rowidx].Cells[0].Value = m_Receipt.TransDate;
                dgvPurchase.Rows[rowidx].Cells[1].Value = m_Receipt.ORNumber;
                dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.BarCode;
                dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.Description;
                dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.Qty;
                dgvPurchase.Rows[rowidx].Cells[5].Value = fitem.Capital;
                dgvPurchase.Rows[rowidx].Cells[6].Value = fitem.Amount;
                dgvPurchase.Rows[rowidx].Cells[7].Value = (fitem.Discount * fitem.Qty);
                dgvPurchase.Rows[rowidx].Cells[8].Value = fitem.Total - (fitem.Discount * fitem.Qty);
                dgvPurchase.Rows[rowidx].Cells[9].Value = fitem.UserName;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to export.", "Export To Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsExportToExcel export = new clsExportToExcel();
            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.Filter = "Excel File (*.xls)|*.xls";
            savedlg.InitialDirectory = Application.StartupPath;
            if (savedlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string columns = "";
                foreach (DataGridViewColumn col in dgvAccounts.Columns)
                {
                    columns += col.HeaderText + (col != dgvAccounts.Columns[dgvAccounts.Columns.Count - 1] ? "\t" : "");
                }
                List<string> lstValues = new List<string>();
                foreach (DataGridViewRow row in dgvAccounts.Rows)
                {
                    string val = "";
                    for (int ctr = 0; ctr < dgvAccounts.Columns.Count; ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr != dgvAccounts.Columns.Count - 1 ? "\t" : "");
                    }
                    lstValues.Add(val);
                }
                export.SaveToExcel(savedlg.FileName, columns, lstValues);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                if (m_Accounts != null)
                {
                    foreach (clsAccountInfo a in m_Accounts)
                    {
                        if (a.AccountName == dgvAccounts.SelectedRows[0].Cells[1].Value.ToString())
                        {
                            frmInput payment = new frmInput();
                            double amountpaid =  a.AccountReceivable;
                            double change = 0;
                            payment.Title = "Cash Payment";
                            payment.Caption = "Amount";
                            payment.IsNumericOnly = true;
                            payment.Value = a.AccountReceivable.ToString();
                            if (payment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {

                                if (Convert.ToDouble(payment.Value) < a.AccountReceivable)
                                {
                                    amountpaid = Convert.ToDouble(payment.Value);
                                }
                                else
                                {
                                    amountpaid = a.AccountReceivable;
                                    change = Convert.ToDouble(payment.Value) - a.AccountReceivable;
                                }
                                if (amountpaid > 0)
                                {
                                    clsPaymentInfo pay = new clsPaymentInfo();
                                    pay.AccountId = a.AccountId;
                                    pay.AmountPaid = amountpaid;
                                    pay.Timestamp = DateTime.Now;
                                    pay.UserId = m_user.UserId;
                                    pay.UserName = m_user.UserName;
                                    string reference = pay.Save();
                                    string ret = "";
                                    Receipt or = new Receipt();
                                    or.InitializePrinter();
                                    List<string> strmsg = new List<string>();
                                    ret += or.PrintCompanyHeader();
                                    strmsg.Add("");
                                    strmsg.Add("PAYMENT");
                                    ret += or.PrintHeader(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold);
                                    strmsg.Clear();

                                    strmsg.Add(string.Format("Cashier: {0}", m_user.UserName.ToUpper()));
                                    strmsg.Add(string.Format("Date: {0}", pay.Timestamp.ToString("yyyy-MM-dd HH:mm:ss")));
                                    strmsg.Add(reference);
                                    strmsg.Add(string.Format("Account Name: {0}", a.AccountName));
                                    strmsg.Add(string.Format("Previous Balance: {0}", a.AccountReceivable));
                                    strmsg.Add(string.Format("Amount Paid: {0}", amountpaid));
                                    strmsg.Add(string.Format("Current Balance: {0}", a.AccountReceivable - amountpaid));

                                    a.LoadTransInfo();
                                    //a.PrincipalBalance = clsChargedTransaction.GetPrincipalAmount(a.AccountId);
                                   // a.TotalInterest = clsChargedTransaction.GetTotalInterest(a.AccountId);
                                    a.LastComputedInterest = DateTime.Today; 
                                    a.Save();

                                    ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                                    or.FormFeed();
                                    or.OpenDrawer();
                                    or.ExecPrint(ret);
                                    strmsg.Clear();

                                    CloseDrawer drawer = new CloseDrawer();
                                    drawer.Change = change;
                                    drawer.ShowDialog();
                                    DisplayAccounts(txtSearch.Text);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateAccounts();
        }

        private void UpdateAccounts()
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                int accountid = Convert.ToInt32(dgvAccounts.SelectedRows[0].Cells[0].Value);
                dgvPurchase.Rows.Clear();
                dgvReceivable.Rows.Clear();
                dgvPayments.Rows.Clear();
                UpdateAccountsReceivable(accountid);
                AddPaymentsReceivedItemToGrid(accountid);
                UpdateReceivables();
            }
        }

        private void dgvReceivable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateReceivables();
        }

        private void UpdateReceivables()
        {
            if (dgvReceivable.SelectedRows.Count == 1)
            {
                int ornum = Convert.ToInt32(dgvReceivable.SelectedRows[0].Cells[1].Value);
                AddPurchasedItemToGrid(ornum);
            }
        }

        private void dgvReceivable_SelectionChanged(object sender, EventArgs e)
        {
            UpdateReceivables();
        }

        private void dgvAccounts_SelectionChanged(object sender, EventArgs e)
        {
            UpdateAccounts();
        }

        private void frmAccountsReceivable_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

        }

        private void dgvReceivable_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {

        }

        private void btnGenStatement_Click( object sender, EventArgs e )
        {
            if (dgvAccounts.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to export.", "Export To Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsExportToExcel export = new clsExportToExcel();
            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.Filter = "Excel File (*.xls)|*.xls";
            savedlg.InitialDirectory = Application.StartupPath;
            Dictionary<DateTime, clsAccountStatement> tmpDicStatement = new Dictionary<DateTime, clsAccountStatement>();
            List<clsAccountStatement> lstStatement = new List< clsAccountStatement>();
            if (savedlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (clsChargedTransaction charge in m_Charges)
                {
                    clsAccountStatement ac = new clsAccountStatement();
                    ac.TransDate = charge.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");
                    ac.ORInfo = new Receipt(charge.ORNum);
                    ac.Description = string.Format("OR#{0:00000} Amount Due:{1:00} Amount Paid:{2:0.00}", charge.ORNum, ac.ORInfo.TotalDiscountedAmount, ac.ORInfo.PaidAmount);
                    ac.Debit = charge.ChargedAmount;
                    ac.Credit = 0;
                    ac.Balance = 0;
                    tmpDicStatement.Add(Convert.ToDateTime(ac.TransDate), ac);
                }
                foreach(clsPaymentInfo pay in m_Payments)
                {

                    clsAccountStatement ac = new clsAccountStatement();
                    bool add = true;
                    while (tmpDicStatement.ContainsKey(pay.Timestamp))
                    {
                        pay.Timestamp = pay.Timestamp.AddSeconds(1);
                    }
                    
                    ac.TransDate = pay.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");
                    ac.Description = string.Format("{0}", pay.Remarks);
                    ac.Debit = 0;
                    ac.Credit = pay.AmountPaid;
                    ac.Balance = 0;
                    ac.ORInfo = null;
                    
                    if(add)
                        tmpDicStatement.Add(Convert.ToDateTime(ac.TransDate),ac);
                }
                List<DateTime> lstKeys = tmpDicStatement.Keys.OrderBy(x => x).ToList();
                double balance = 0;
                foreach (DateTime dt in lstKeys)
                {
                    if (!tmpDicStatement[dt].Description.Contains("Interest"))
                        tmpDicStatement[dt].Balance = tmpDicStatement[dt].Credit - tmpDicStatement[dt].Debit + balance;
                    else
                        tmpDicStatement[dt].Balance = balance;
                    balance = tmpDicStatement[dt].Balance;
                    lstStatement.Add(tmpDicStatement[dt]);
                    if (tmpDicStatement[dt].ORInfo != null)
                    {
                        foreach (KeyValuePair<string, clsPurchasedItem> p in tmpDicStatement[dt].ORInfo.PurchasedItems)
                        {
                            clsAccountStatement ac = new clsAccountStatement();
                            ac.TransDate = "";
                            ac.Description = string.Format("{1} x {0} : {2}", p.Value.Description, p.Value.Qty, (p.Value.Amount * p.Value.Qty) - (p.Value.Discount * p.Value.Qty));
                            ac.Debit = 0;
                            ac.Credit = 0;
                            ac.ORInfo = null;
                            ac.Balance = balance;
                            lstStatement.Add(ac);
                        }
                    }
                }
                
                export.SaveStatementToExcel(savedlg.FileName, dgvAccounts.SelectedRows[0].Cells[1].Value.ToString(), Convert.ToDouble(dgvAccounts.SelectedRows[0].Cells[2].Value), Convert.ToDouble(dgvAccounts.SelectedRows[0].Cells[3].Value), Convert.ToDouble(dgvAccounts.SelectedRows[0].Cells[4].Value),lstStatement);
            }
        }

        private void frmAccountsReceivable_Activated( object sender, EventArgs e )
        {
        }

        private void frmAccountsReceivable_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            DisplayAccounts(txtSearch.Text);
        }

        private void btnCancelPayment_Click( object sender, EventArgs e )
        {
            CancelPayment();
        }

        private bool CancelPayment()
        {
            
            if (!clsUtil.GetApproval(m_user, UserAccess.Manager)) return false;
            frmSelectAccounts acct = new frmSelectAccounts(0, m_user);
            if (acct.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clsAccountInfo a = acct.SelectedAccount;

                frmInput input = new frmInput();
                input.Title = "Retrieve Payment Info";
                input.Caption = "Payment Reference";
                input.IsHiddenInput = false;
                input.IsNumericOnly = true;
                input.withDecimal = false;
                input.Value = "";
                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    clsPaymentInfo payment = clsPaymentInfo.GetPayment(Convert.ToInt32(input.Value));
                    if (payment != null)
                    {
                        clsChargedTransaction charges = clsChargedTransaction.GetChargedTransaction(payment.OrNum);

                        if (charges != null && payment.PaymentId != 0 && payment.AccountId == a.AccountId)
                        {
                            if (payment.Remarks.ToLower().Contains("interest"))
                            {
                                MessageBox.Show("Interest payment cancellation not allowed!", "Cancel Payment", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else if (MessageBox.Show(string.Format("Are you sure you want to cancel payment?\nRefno:{0}\nRemarks:{1}\nAmount:P {2:0.00}", payment.PaymentId, payment.Remarks, payment.AmountPaid), "Cancel Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (payment.Remarks.ToLower().Contains("principal"))
                                {
                                    a.PrincipalBalance += payment.AmountPaid;
                                    a.Save();
                                    charges.TransBalance += payment.AmountPaid;
                                    charges.SaveChargeTransaction();

                                    if (clsPaymentInfo.CancelPayment(payment.PaymentId))
                                    {
                                        MessageBox.Show("Payment successfully cancelled!", "Cancel Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cancel Payment did not succeed!", "Cancel Payment", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Payment Reference not found under this account", "Cancel Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            return false;
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            DisplayAccounts(txtSearch.Text);
        }

        private void btnSearch_Click( object sender, EventArgs e )
        {
            DisplayAccounts(txtSearch.Text);
        }

        private void btnRecompute_Click( object sender, EventArgs e )
        {
            double total = 0;
            List<clsAccountInfo> tmpAccounts = clsAccountInfo.GetAccounts(txtSearch.Text);
            frmProgress progress = new frmProgress(tmpAccounts.Count);
            progress.Caption = "Processing Accounts";
            progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            progress.Show();

            if (tmpAccounts != null)
            {
                dgvAccounts.Rows.Clear();
                foreach (clsAccountInfo a in m_Accounts)
                {
                    a.LoadTransInfo();
                    AddItemToGrid(a);
                    total += a.AccountReceivable;
                    progress.Val += 1;

                }
            }
            progress.Close();
            lblTotalReceivable.Text = string.Format("Accounts Receivable: P {0:0.00}", total);
            UpdateAccounts();
        }

        private void btnUpdateYTD_Click( object sender, EventArgs e )
        {
            double total = 0;
            List<clsAccountInfo> tmpAccounts = clsAccountInfo.GetAccounts(txtSearch.Text);
            frmProgress progress = new frmProgress(tmpAccounts.Count);
            progress.Caption = "Processing Accounts";
            progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            progress.Show();

            if (tmpAccounts != null)
            {
                dgvAccounts.Rows.Clear();
                foreach (clsAccountInfo a in m_Accounts)
                {
                    double ytd = a.YTDTransaction;
                    a.YTDTransaction = clsChargedTransaction.GetYTDTransactions(a.AccountId);
                    if(a.YTDTransaction!=ytd)
                        a.Save();
                    progress.Val += 1;

                }
            }
            progress.Close();
            lblTotalReceivable.Text = string.Format("Accounts Receivable: P {0:0.00}", total);
            DisplayAccounts(txtSearch.Text);
        }

        private void txtSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if (e.KeyValue == 13)
            {
                btnSearch.PerformClick();
            }
        }

    }
}
