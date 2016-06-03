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
    public partial class frmSalesReport : Form
    {
        clsPurchasedItem m_ListPurchases = new clsPurchasedItem();
        double TotalIncome = 0.0;
        double NetProfit = 0.0;
        double TotalQty = 0;
        double TotalAccountsReceivable = 0;
        double TotalPayment = 0;
        double TotalExpenses = 0.0;
        double InitialCash = 0.0;

        public frmSalesReport()
        {
            InitializeComponent();
        }

        private void SearchPurchases(DateTime startdate, DateTime enddate,string cashier)
        {
            List<Receipt> lstReceipt = new List<Receipt>();
            dbConnect con = new dbConnect();
            
            TotalIncome = 0.0;
            NetProfit = 0.0;
            TotalAccountsReceivable = 0.0;
            lstReceipt = con.GetReceiptInfo(startdate, enddate,cashier);
            con.Close();
            dgvPurchase.Rows.Clear();
            dgvSenior.Rows.Clear();
            dgvAccounts.Rows.Clear();
            dgvPayments.Rows.Clear();
            TotalQty = 0;
            foreach (Receipt r in lstReceipt)
            {
                AddItemToGridReceipt(r);
                AddAccountsReceivableItemToGrid(r);
                //AddItemToGrid(r);
                TotalIncome += (r.TotalDiscountedAmount > r.CashTendered ? r.CashTendered : r.TotalDiscountedAmount);
                NetProfit += (r.TotalDiscountedAmount - r.TotalCapital);
            }
            lblTotalSales.Text = string.Format("Total Sales: P {0:0.00}", TotalIncome);
            lblNetProfit.Text = string.Format("Net Profit: P {0:0.00}", NetProfit);
            lblReceivable.Text = string.Format("Receivable: P {0:0.00}", TotalAccountsReceivable);
            lblItems.Text = "Total Qty:" + TotalQty;

        }

        private void GetPayments(DateTime startdate, DateTime enddate, string cashier)
        {
            List<clsPaymentInfo> lstpayment = clsPaymentInfo.GetPaymentsInfoFromDate(startdate, enddate, cashier);
            foreach (clsPaymentInfo p in lstpayment)
            {
                AddPaymentsReceivedItemToGrid(p);
                TotalPayment += p.AmountPaid;
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
                dgvPurchase.Rows[rowidx].Cells[5].Value = fitem.Capital;
                dgvPurchase.Rows[rowidx].Cells[6].Value = fitem.Amount;
                dgvPurchase.Rows[rowidx].Cells[7].Value = (fitem.Discount * fitem.Qty);
                dgvPurchase.Rows[rowidx].Cells[8].Value = fitem.Total - (fitem.Discount * fitem.Qty);
                dgvPurchase.Rows[rowidx].Cells[9].Value = fitem.UserName;
                TotalQty += fitem.Qty;
            }
        }

        private void AddAccountsReceivableItemToGrid(Receipt receipt)
        {
           if(receipt.ChargeTrans!=null)
           {
               int rowidx = dgvAccounts.Rows.Add();
                dgvAccounts.Rows[rowidx].Cells[0].Value = receipt.TransDate;
                dgvAccounts.Rows[rowidx].Cells[1].Value = receipt.ORNumber;
                dgvAccounts.Rows[rowidx].Cells[2].Value = receipt.ChargeTrans.AccountName;
                dgvAccounts.Rows[rowidx].Cells[3].Value = receipt.ChargeTrans.ChargedAmount;
                TotalAccountsReceivable += receipt.ChargeTrans.ChargedAmount;
            }
        }

        private void AddPaymentsReceivedItemToGrid(clsPaymentInfo payment)
        {
                int rowidx = dgvPayments.Rows.Add();
                dgvPayments.Rows[rowidx].Cells[0].Value = payment.Timestamp;
                dgvPayments.Rows[rowidx].Cells[1].Value = payment.AccountName;
                dgvPayments.Rows[rowidx].Cells[2].Value = payment.AmountPaid;
                dgvPayments.Rows[rowidx].Cells[3].Value = payment.UserName;
            
        }
        private void AddItemToGridReceipt(Receipt receipt)
        {
            int rowidx = dgvSenior.Rows.Add();
            dgvSenior.Rows[rowidx].Cells[0].Value = receipt.TransDate;
            dgvSenior.Rows[rowidx].Cells[1].Value = receipt.ORNumber;
            dgvSenior.Rows[rowidx].Cells[2].Value = receipt.TotalAmountDue;
            dgvSenior.Rows[rowidx].Cells[3].Value = receipt.SeniorDiscount + receipt.ItemDiscount;
            dgvSenior.Rows[rowidx].Cells[4].Value = receipt.TotalDiscountedAmount;
            dgvSenior.Rows[rowidx].Cells[5].Value = receipt.CashTendered;
            dgvSenior.Rows[rowidx].Cells[6].Value = receipt.CashierName;
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
            TotalPayment = 0;
            GetPayments(dtPickStart.Value, dtPickEnd.Value, cashier);
            lblPayment.Text = string.Format("Payments: P {0:0.00}", TotalPayment);
            InitialCash = clsInitCash.GetInitialCash(dtPickStart.Value, cashier);
            lblInitCash.Text = string.Format("Initial Cash: P {0:0.00}", InitialCash);
            lblCOH.Text = string.Format("Cash On Hand: P {0:0.00}", (TotalIncome + InitialCash - TotalExpenses + TotalPayment)); 
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
            lblExp.Text = string.Format("Total Expenses: P {0:0.00}", TotalExpenses);

        }
        private void dtPickEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickEnd.Value <= dtPickStart.Value) dtPickStart.Value = dtPickEnd.Value.AddDays(-1);
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            cboCashier.Items.Add("All");
            List<string> lstUsers = clsUsers.GetUserList();
            foreach (string str in lstUsers)
            {
                cboCashier.Items.Add(str);
            }
            cboCashier.SelectedIndex = 0;
            dtPickEnd.Value = dtPickStart.Value.AddDays(1);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvPurchase.Rows.Count == 0)
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
                foreach(DataGridViewColumn col in dgvPurchase.Columns)
                {
                    columns += col.HeaderText + (col!=dgvPurchase.Columns[dgvPurchase.Columns.Count-1]?"\t":"");
                }
                List<string> lstValues = new List<string>();
                frmProgress progress = new frmProgress(dgvPurchase.Rows.Count);
                progress.Caption = "Loading Data";
                progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                progress.Show();
                int ctr2 = 0;
                foreach(DataGridViewRow row in dgvPurchase.Rows)
                {
                    string val="";
                    for(int ctr=0;ctr<dgvPurchase.Columns.Count;ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr!=dgvPurchase.Columns.Count-1?"\t":"");
                    }
                    lstValues.Add(val);
                    progress.Val = ++ctr2;
                }
                progress.Close();
                export.SaveToExcelWithSummary(savedlg.FileName, columns, lstValues, "Total Sales\tAccounts Receivable\tNet Profit", string.Format("{0}\t{1}\t{2}", TotalIncome,TotalAccountsReceivable, NetProfit));
            }
        }

        private void dgvSenior_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateReceiptItems();
        }

        private void UpdateReceiptItems()
        {
            if (dgvSenior.SelectedRows.Count == 1)
            {
                Receipt r = new Receipt(Convert.ToInt32(dgvSenior.SelectedRows[0].Cells[1].Value));
                AddItemToGrid(r);
            }
        }

        private void dgvSenior_SelectionChanged(object sender, EventArgs e)
        {
            UpdateReceiptItems();
        }
    }
}
