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
    public partial class frmSalesReportLite : Form
    {
        clsPurchasedItem m_ListPurchases = new clsPurchasedItem();
        List<clsUsers> lstUsers = new List<clsUsers>();
        double TotalIncome = 0.0;
        double NetProfit = 0.0;
        double TotalDiscounts = 0.0;
        double TotalAccountsReceivable = 0;
        double TotalPayment = 0;
        double TotalExpenses = 0.0;
        double InitialCash = 0.0;
        double DepositCash = 0.0;
        double expectedCOH = 0.0;
        double actualCOH = 0.0;
        public frmSalesReportLite()
        {
            InitializeComponent();
        }
        List<Receipt> m_lstReceipt = new List<Receipt>();

        private void SearchPurchases(DateTime startdate, DateTime enddate,string cashier)
        {
            dbConnect con = new dbConnect();
            
            TotalIncome = 0.0;
            NetProfit = 0.0;
            TotalAccountsReceivable = 0.0;
            m_lstReceipt.Clear();
            List<Receipt> tmpReceipt = con.GetReceiptInfo(startdate, enddate,cashier,false);
            if (cboMode.SelectedIndex == 0) m_lstReceipt = tmpReceipt;
            else
            {
                foreach (Receipt r in tmpReceipt)
                {
                    if (cboMode.SelectedIndex == 1 && r.CashTendered >= (r.DbAmountDue-r.WholeSaleDiscount-r.SeniorDiscount))
                    {
                        m_lstReceipt.Add(r);
                    }
                    else if (cboMode.SelectedIndex == 2 && r.CashTendered < (r.DbAmountDue - r.WholeSaleDiscount - r.SeniorDiscount))
                    {
                        m_lstReceipt.Add(r);
                    }
                }
            }
            List<double> lstSalesInfo = con.GetSalesInfo(startdate, enddate, cashier);
            if (lstSalesInfo != null & lstSalesInfo.Count == 4)
            {
                TotalIncome = lstSalesInfo[0];
                TotalAccountsReceivable = lstSalesInfo[1];
                NetProfit = lstSalesInfo[2];
                TotalDiscounts = lstSalesInfo[3];
            }
            TotalExpenses = con.GetTotalExpenses(startdate, enddate, cashier);
            TotalPayment = con.GetTotalPaymentsInfoFromDate(startdate, enddate, cashier);

            con.Close();
            dgvReceipt.Rows.Clear();

            foreach (Receipt r in m_lstReceipt)
            {
                AddItemToGridReceipt(r);
            }
            lblItems.Text = "Total Qty:" + m_lstReceipt.Count;

        }

        private void AddItemToGridReceipt(Receipt receipt)
        {
            int rowidx = dgvReceipt.Rows.Add();
            dgvReceipt.Rows[rowidx].Cells[0].Value = receipt.TransDate;
            dgvReceipt.Rows[rowidx].Cells[1].Value = receipt.ORNumber;
            dgvReceipt.Rows[rowidx].Cells[2].Value = receipt.DbAmountDue-receipt.WholeSaleDiscount-receipt.SeniorDiscount;
            //dgvReceipt.Rows[rowidx].Cells[3].Value = receipt.SeniorDiscount + receipt.ItemDiscount;
            //dgvReceipt.Rows[rowidx].Cells[4].Value = receipt.TotalDiscountedAmount;
            dgvReceipt.Rows[rowidx].Cells[3].Value = receipt.CashTendered;
            dgvReceipt.Rows[rowidx].Cells[4].Value = receipt.CashierName;
            dgvReceipt.Rows[rowidx].Cells[5].Value = receipt.AccountName;
        }

        private void dtPick_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickStart.Value >= dtPickEnd.Value) dtPickEnd.Value = dtPickStart.Value.AddDays(1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string cashier = cboCashier.SelectedItem.ToString();
            if(cashier=="All") cashier="";
            SearchPurchases(dtPickStart.Value, dtPickEnd.Value,cashier);
            SearchExpenses(dtPickStart.Value, dtPickEnd.Value, cashier);

            lblTotalSales.Text = string.Format("Total Sales: P {0:0.00}", TotalIncome);
            lblTotalDisc.Text = string.Format("Total Discounts: P {0:0.00}", TotalDiscounts);
            lblGrossSales.Text = string.Format("Gross Sales: P {0:0.00}", TotalIncome - TotalDiscounts);
            lblNetProfit.Text = string.Format("Gross Profit: P {0:0.00}", NetProfit);
            lblPayment.Text = string.Format("Payments: P {0:0.00}", TotalPayment);
            lblReceivable.Text = string.Format("Receivable: P {0:0.00}", TotalAccountsReceivable);
            InitialCash = clsInitCash.GetInitialCash(dtPickStart.Value, cashier);
            DepositCash = clsDepositCash.GetDepositCash(dtPickStart.Value, cashier);
            lblInitCash.Text = string.Format("Initial Cash: P {0:0.00}", InitialCash);
            lblDeposit.Text = string.Format("Cash Deposit: P {0:0.00}", DepositCash);

            TotalPayment = 0;
            TotalPayment = clsPaymentInfo.GetTotalPaymentsInfoFromDate(dtPickStart.Value, dtPickEnd.Value, cashier);
            InitialCash = clsInitCash.GetInitialCash(dtPickStart.Value, cashier);
            lblInitCash.Text = string.Format("Initial Cash: P {0:0.00}", InitialCash);
            expectedCOH = (TotalIncome - TotalDiscounts + InitialCash - DepositCash - TotalExpenses + TotalPayment);
            lblCOH.Text = string.Format("Expected COH: P {0:0.00}", expectedCOH);
            actualCOH = clsCheckOut.GetActualCOH(dtPickStart.Value, cashier);
            lblActualCOH.Text = string.Format("Actual COH: P {0:0.00}", actualCOH); 
            lblDiff.Text = string.Format("Amount Difference: P {0:0.00} [{1}]", actualCOH - expectedCOH, (actualCOH - expectedCOH > 0 ? "Over" : (actualCOH - expectedCOH == 0 ? "Match" : "Short")));

        }
        private void SearchExpenses(DateTime startdate, DateTime enddate, string cashier)
        {
            List<clsExpenses> lstExpenses = new List<clsExpenses>();

            lstExpenses = clsExpenses.GetExpenses(startdate, enddate, cashier);
            TotalExpenses = 0.0;

            foreach (clsExpenses r in lstExpenses)
            {
                TotalExpenses += r.Amount;
            }
            lblExp.Text = string.Format("Expenses: P {0:0.00}", TotalExpenses);

        }
        private void dtPickEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickEnd.Value <= dtPickStart.Value) dtPickStart.Value = dtPickEnd.Value.AddDays(-1);
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            cboCashier.Items.Add("All");
            lstUsers = clsUsers.GetUsers();
            foreach (clsUsers str in lstUsers)
            {
                cboCashier.Items.Add(str.UserName);
            }
            cboCashier.SelectedIndex = 0;
            cboMode.SelectedIndex = 0;
            dtPickEnd.Value = dtPickStart.Value.AddDays(1);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReceipt.Rows.Count == 0)
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
                string columns="";
                foreach(DataGridViewColumn col in dgvReceipt.Columns)
                {
                    columns += col.HeaderText + (col != dgvReceipt.Columns[dgvReceipt.Columns.Count - 1] ? "\t" : "");
                }
                List<string> lstValues = new List<string>();
                frmProgress progress = new frmProgress(dgvReceipt.Rows.Count);
                progress.Caption = "Loading Data";
                progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                progress.Show();
                int ctr2 = 0;

                foreach (DataGridViewRow row in dgvReceipt.Rows)
                {
                    string val="HEADER1";
                    for (int ctr = 0; ctr < dgvReceipt.Columns.Count; ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr != dgvReceipt.Columns.Count - 1 ? "\t" : "");
                    }
                    lstValues.Add(val);
                    Receipt r = new Receipt(Convert.ToInt32(row.Cells[1].Value));
                    if (r != null)
                    {
                        val = "BARCODE\tDESCRIPTION\tQTY\tAMOUNT\tTOTAL\tHEADER2";
                        lstValues.Add(val);

                        foreach (KeyValuePair<string,clsPurchasedItem> p in r.PurchasedItems)
                        {
                            val = string.Format("[{0}]\t{1}\t{2}\t{3}\t{4}\t", p.Value.BarCode, p.Value.Description, p.Value.Qty, p.Value.Amount - p.Value.Discount, p.Value.Qty * (p.Value.Amount - p.Value.Discount));
                            lstValues.Add(val);
                       }
                        //lstValues.Add("\t");
                    }
                    progress.Val = ++ctr2;

                }
                progress.Close();
                export.SaveToExcelWithSummary(savedlg.FileName, columns, lstValues, "Total Sales\tAccounts Receivable\tNet Profit", string.Format("{0}\t{1}\t{2}", TotalIncome-TotalDiscounts,TotalAccountsReceivable, NetProfit));
            }
        }
        private void UpdateReceiptItems()
        {
            if (dgvReceipt.SelectedRows.Count == 1)
            {
                Receipt r = new Receipt(Convert.ToInt32(dgvReceipt.SelectedRows[0].Cells[1].Value));
                AddItemToGrid(r);
            }
        }

        private void AddItemToGrid(Receipt receipt)
        {
            dgvPurchase.Rows.Clear();
            foreach (clsPurchasedItem fitem in receipt.PurchasedItems.Values)
            {
                int rowidx = dgvPurchase.Rows.Add();
                dgvPurchase.Rows[rowidx].Cells[0].Value = receipt.TransDate;
                dgvPurchase.Rows[rowidx].Cells[1].Value = receipt.ORNumber;
                dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.BarCode;
                dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.Description;
                dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.Qty;
                dgvPurchase.Rows[rowidx].Cells[5].Value = fitem.Amount;
                dgvPurchase.Rows[rowidx].Cells[6].Value = (fitem.Discount * fitem.Qty);
                dgvPurchase.Rows[rowidx].Cells[7].Value = fitem.Total - (fitem.Discount * fitem.Qty);
                dgvPurchase.Rows[rowidx].Cells[8].Value = fitem.UserName;
                dgvPurchase.Rows[rowidx].Cells[9].Value = fitem.Account;

            }
        }

        private void dgvReceipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateReceiptItems();
        }

        private void dgvReceipt_SelectionChanged(object sender, EventArgs e)
        {
            UpdateReceiptItems();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            //frmChkOutLight chkout = new frmChkOutLight();
            //chkout.ShowDialog();
            btnSearch.PerformClick();
            if (cboCashier.SelectedIndex == 0)
            {
                MessageBox.Show("Please select cashier.", "Checkout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            double totalamount = 0;
            if (MessageBox.Show("Would you like to perform Cash Count?", "Cash Count", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                CashCount cc = new CashCount();
                if (cc.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                else
                    totalamount = cc.TotalAmount;
            }
            frmInput payment = new frmInput();
            payment.Title = "Actual Cash on Hand";
            payment.Caption = "Amount";
            payment.IsNumericOnly = true;
            payment.Value = totalamount.ToString();
            if (payment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (payment.Value != "")
                {
                    clsCheckOut ckout = new clsCheckOut();
                    ckout.ActualAmount = double.Parse(payment.Value);
                    ckout.ExpectedAmount = expectedCOH;
                    ckout.Timestamp = dtPickStart.Value;
                    ckout.UserId = lstUsers[cboCashier.SelectedIndex-1].UserId;
                    ckout.UserName = lstUsers[cboCashier.SelectedIndex-1].UserName;
                    ckout.Save();
                    btnSearch.PerformClick();
                }
            }
        }

        private void frmSalesReportLite_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
