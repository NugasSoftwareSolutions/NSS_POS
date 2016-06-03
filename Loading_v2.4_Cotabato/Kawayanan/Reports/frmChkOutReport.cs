using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class;
using System.Drawing.Printing;

namespace AlreySolutions
{
    public partial class frmCheckOutReport : Form
    {
        double TotalExpenses = 0.0;
        double totalSales =0.0;
        double initCash = 0.0;
        double expectedCOH = 0.0;
        double TotalPayments = 0.0;
        double actualCOH = 0.0;

        List<clsUsers> lstUsers = clsUsers.GetUsers();

        public frmCheckOutReport()
        {
            InitializeComponent();
        }

        private void SearchExpenses(DateTime startdate, DateTime enddate,string cashier)
        {
            List<clsExpenses> lstExpenses = new List<clsExpenses>();
           
            TotalExpenses = 0.0;
            lstExpenses = clsExpenses.GetExpenses(startdate, enddate,cashier);

            dgvExpenses.Rows.Clear();
            AddItemToGrid(lstExpenses);
            foreach (clsExpenses r in lstExpenses)
            {
                TotalExpenses += r.Amount;
            }
            lblTotalExpenses.Text = string.Format("Expenses: P {0:0.00}", TotalExpenses);

        }

        private void AddItemToGrid(List<clsExpenses> exp)
        {
            foreach (clsExpenses fitem in exp)
            {
                int rowidx = dgvExpenses.Rows.Add();
                dgvExpenses.Rows[rowidx].Cells[0].Value = fitem.Timestamp;
                dgvExpenses.Rows[rowidx].Cells[1].Value = fitem.Description;
                dgvExpenses.Rows[rowidx].Cells[2].Value = fitem.Amount;
                dgvExpenses.Rows[rowidx].Cells[3].Value = fitem.UserName;
            }
        }


        private void dtPick_ValueChanged(object sender, EventArgs e)
        {
            //if (dtPickStart.Value >= dtPickEnd.Value) dtPickEnd.Value = dtPickStart.Value.AddDays(1);
            dtPickEnd.Value = dtPickStart.Value.AddDays(1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateCheckout();
        }

        private void UpdateCheckout()
        {
            string cashier = "";
            if (cboCashier.SelectedIndex > -1)
            {
                cashier = cboCashier.SelectedItem.ToString();
                SearchExpenses(dtPickStart.Value, dtPickEnd.Value, cashier);
                List<double> salesinfo = GetTotalSales(dtPickStart.Value, dtPickEnd.Value, cashier);
                totalSales = salesinfo[0];
                TotalPayments = 0;
                List<clsPaymentInfo> lstpayment = clsPaymentInfo.GetPaymentsInfoFromDate(dtPickStart.Value, dtPickEnd.Value, cashier);
                foreach (clsPaymentInfo p in lstpayment)
                {
                    TotalPayments += p.AmountPaid;
                }
                initCash = clsInitCash.GetInitialCash(dtPickStart.Value, cashier);
                expectedCOH = totalSales + initCash - TotalExpenses + TotalPayments;

                lblTotalSales.Text = string.Format("Total Sales: P {0:0.00}", totalSales);
                lblInitCash.Text = string.Format("Initial Cash: P {0:0.00}", initCash);
                lblReceivable.Text = string.Format("Total Charges: P {0:0.00}", salesinfo[1]);
                lblTotalPayments.Text = string.Format("Total Payments: P {0:0.00}", TotalPayments);
                lblExpectedCOH.Text = string.Format("Expected Cash on Hand: P {0:0.00}", expectedCOH);
                actualCOH = clsCheckOut.GetActualCOH(dtPickStart.Value, cashier);
                lblActualCash.Text = string.Format("Actual Cash on Hand: P {0:0.00}", actualCOH);
                lblDiff.Text = string.Format("Amount Difference: P {0:0.00} [{1}]", actualCOH - expectedCOH,(actualCOH - expectedCOH>0?"Over":(actualCOH - expectedCOH==0?"Match":"Short")));
            }
        }

        private void dtPickEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickEnd.Value <= dtPickStart.Value) dtPickStart.Value = dtPickEnd.Value.AddDays(-1);
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));

            foreach (clsUsers users in lstUsers)
            {
                cboCashier.Items.Add(users.UserName);
            }
            cboCashier.SelectedIndex = 0;
            dtPickEnd.Value = dtPickStart.Value.AddDays(1);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<double> GetTotalSales(DateTime startdate, DateTime enddate, string cashier)
        {
            List<Receipt> lstReceipt = new List<Receipt>();
            dbConnect con = new dbConnect();
            List<double> totalSales = new List<double>();
            double TotalIncome = 0.0;
            double TotalReceivable = 0.0;

            lstReceipt = con.GetReceiptInfo(startdate, enddate, cashier);
            con.Close();
            foreach (Receipt r in lstReceipt)
            {
                TotalIncome += (r.TotalDiscountedAmount > r.CashTendered ? r.CashTendered : r.TotalDiscountedAmount);
                if (r.ChargeTrans != null)
                {
                    TotalReceivable += r.ChargeTrans.ChargedAmount;
                }
            }
            totalSales.Add(TotalIncome);
            totalSales.Add(TotalReceivable);
            return totalSales;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
            frmInput payment = new frmInput();
            payment.Title = "Actual Cash on Hand";
            payment.Caption = "Amount";
            payment.IsNumericOnly = true;
            payment.Value = actualCOH.ToString();
            if (payment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (payment.Value != "")
                {
                    clsCheckOut ckout = new clsCheckOut();
                    ckout.ActualAmount = double.Parse(payment.Value);
                    ckout.ExpectedAmount = expectedCOH;
                    ckout.Timestamp = dtPickStart.Value;
                    ckout.UserId = lstUsers[cboCashier.SelectedIndex].UserId;
                    ckout.UserName = lstUsers[cboCashier.SelectedIndex].UserName;
                    ckout.Save();
                    UpdateCheckout();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            UpdateCheckout();
        }

    }
}
