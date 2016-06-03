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
using AlreySolutions.Class.Load;

namespace AlreySolutions
{
    public partial class frmChkOutLight : Form
    {
        List<double> salesinfo = new List<double>();
        double TotalExpenses = 0.0;
        double totalSales =0.0;
        double initCash = 0.0;
        double depositCash = 0.0;
        double expectedCOH = 0.0;
        double TotalPayments = 0.0;
        double actualCOH = 0.0;
        double TotalLoadingStationCashIn = 0;
        double TotalLoadingStationCashOut = 0;
        public bool isCheckout = false;
        List<clsUsers> lstUsers = clsUsers.GetUsers();
        List<clsCheckOutItem> lstCheckOutItems = new List<clsCheckOutItem>();
        int m_userid = 0;
        public frmChkOutLight(int userid=0)
        {
            InitializeComponent();
            m_userid = userid;
        }

        private void SearchExpenses(DateTime startdate, DateTime enddate,string cashier)
        {
            List<clsExpenses> lstExpenses = new List<clsExpenses>();

            TotalExpenses = clsExpenses.GetTotalExpenses(startdate, enddate, cashier);
            lblTotalExpenses.Text = string.Format("Expenses: P {0:0.00}", TotalExpenses);
        }


        private void dtPick_ValueChanged(object sender, EventArgs e)
        {
            //if (dtPickStart.Value >= dtPickEnd.Value) dtPickEnd.Value = dtPickStart.Value.AddDays(1);
            dtPickEnd.Value = dtPickStart.Value.AddDays(1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            isCheckout = false;
            UpdateCheckout();
        }

        private void UpdateCheckout()
        {
            string cashier = "";
            if (cboCashier.SelectedIndex > -1)
            {
                dgvChkOut.Rows.Clear();
                clsUsers SelectedUser = lstUsers.Find(x => x.UserName == cboCashier.Text);
                int userid = SelectedUser != null ? SelectedUser.UserId : 0;
                TotalLoadingStationCashIn = clsReloadHistory.GetLoadingStationTotalCashIn(dtPickStart.Value, dtPickEnd.Value, userid);
                TotalLoadingStationCashOut = clsReloadHistory.GetLoadingStationTotalCashOut(dtPickStart.Value, dtPickEnd.Value, userid);

                cashier = cboCashier.SelectedItem.ToString();
                SearchExpenses(dtPickStart.Value, dtPickEnd.Value, cashier);
                salesinfo = GetTotalSales(dtPickStart.Value, dtPickEnd.Value, cashier);
                totalSales = salesinfo[0] - salesinfo[3];
                TotalPayments = clsPaymentInfo.GetTotalPaymentsInfoFromDate(dtPickStart.Value, dtPickEnd.Value, cashier);

                initCash = clsInitCash.GetInitialCash(dtPickStart.Value, cashier);
                depositCash = clsDepositCash.GetDepositCash(dtPickStart.Value, cashier);
                expectedCOH = totalSales + initCash - depositCash - TotalExpenses + TotalPayments;
                expectedCOH += TotalLoadingStationCashIn + TotalLoadingStationCashOut;

                //lblTotalCashinLoading.Text = string.Format("Loading Station Cash In: P {0:0.00}", TotalLoadingStationCashIn);
                //lblTotalCashoutLoading.Text = string.Format("Loading Station Cash Out: P {0:0.00}", TotalLoadingStationCashOut);

                //lblTotalSales.Text = string.Format("Total Sales: P {0:0.00}", totalSales);
                //lblInitCash.Text = string.Format("Initial Cash: P {0:0.00}", initCash);
                //lblDeposit.Text = string.Format("Deposit Cash: P {0:0.00}", depositCash);
                //lblReceivable.Text = string.Format("Total Charges: P {0:0.00}", salesinfo[1]);
                //lblTotalPayments.Text = string.Format("Total Payments: P {0:0.00}", TotalPayments);
                //lblExpectedCOH.Text = string.Format("Expected Cash on Hand: P {0:0.00}", expectedCOH);
                //actualCOH = clsCheckOut.GetActualCOH(dtPickStart.Value, cashier);
                //lblActualCash.Text = string.Format("Actual Cash on Hand: P {0:0.00}", actualCOH);
                //lblDiff.Text = string.Format("Amount Difference: P {0:0.00} [{1}]", actualCOH - expectedCOH, (actualCOH - expectedCOH > 0 ? "Over" : (actualCOH - expectedCOH == 0 ? "Match" : "Short")));

                int chkId = clsCheckOut.GetCheckOutID(dtPickStart.Value, cashier);
                if (chkId > 0)
                {
                    lstCheckOutItems = clsCheckOutItem.GetCheckOutItems(chkId);
                    if (lstCheckOutItems.Count > 0)
                    {
                        for (int i = 0; i < lstCheckOutItems.Count; i++)
                        {
                            clsCheckOutItem itemCheckout = lstCheckOutItems[i];
                            AddItemToGrid(itemCheckout);
                        }
                    }
                }
                else
                {
                    CreateCheckOutItems();
                    return;
                }
                if (isCheckout) CreateCheckOutItems();
            }
        }

        private void CreateCheckOutItems()
        {
            lstCheckOutItems = new List<clsCheckOutItem>();
            clsCheckOutItem item = new clsCheckOutItem()
            {
                Description = "Initial Cash",
                ExpectedAmount = initCash,
                ActualAmount = initCash
            };
            if (item.ActualAmount - item.ExpectedAmount != 0)
                item.Remarks = string.Format("{0} [{1:0.00}]", item.ActualAmount - item.ExpectedAmount > 0 ? "Over" : (item.ActualAmount - item.ExpectedAmount == 0 ? "Match" : "Short"), item.ActualAmount - item.ExpectedAmount);
            else item.Remarks = "Match";
            lstCheckOutItems.Add(item);
            AddItemToGrid(item);

            item = new clsCheckOutItem()
            {
                Description = "Expenses",
                ExpectedAmount = TotalExpenses,
                ActualAmount = TotalExpenses
            };
            if (item.ActualAmount - item.ExpectedAmount != 0)
                item.Remarks = string.Format("{0} [{1:0.00}]", item.ActualAmount - item.ExpectedAmount > 0 ? "Over" : (item.ActualAmount - item.ExpectedAmount == 0 ? "Match" : "Short"), item.ActualAmount - item.ExpectedAmount);
            else item.Remarks = "Match";
            lstCheckOutItems.Add(item);
            AddItemToGrid(item);

            item = new clsCheckOutItem()
            {
                Description = "Deposit Cash",
                ExpectedAmount = depositCash,
                ActualAmount = depositCash
            };
            if (item.ActualAmount - item.ExpectedAmount != 0)
                item.Remarks = string.Format("{0} [{1:0.00}]", item.ActualAmount - item.ExpectedAmount > 0 ? "Over" : (item.ActualAmount - item.ExpectedAmount == 0 ? "Match" : "Short"), item.ActualAmount - item.ExpectedAmount);
            else item.Remarks = "Match";
            lstCheckOutItems.Add(item);
            AddItemToGrid(item);

            item = new clsCheckOutItem()
            {
                Description = "Total Sales",
                ExpectedAmount = totalSales,
                ActualAmount = totalSales
            };
            if (item.ActualAmount - item.ExpectedAmount != 0)
                item.Remarks = string.Format("{0} [{1:0.00}]", item.ActualAmount - item.ExpectedAmount > 0 ? "Over" : (item.ActualAmount - item.ExpectedAmount == 0 ? "Match" : "Short"), item.ActualAmount - item.ExpectedAmount);
            else item.Remarks = "Match";
            lstCheckOutItems.Add(item);
            AddItemToGrid(item);

            item = new clsCheckOutItem()
            {
                Description = "Total Charges",
                ExpectedAmount = salesinfo[1],
                ActualAmount = salesinfo[1]
            };
            if (item.ActualAmount - item.ExpectedAmount != 0)
                item.Remarks = string.Format("{0} [{1:0.00}]", item.ActualAmount - item.ExpectedAmount > 0 ? "Over" : (item.ActualAmount - item.ExpectedAmount == 0 ? "Match" : "Short"), item.ActualAmount - item.ExpectedAmount);
            else item.Remarks = "Match";
            lstCheckOutItems.Add(item);
            AddItemToGrid(item);

            item = new clsCheckOutItem()
            {
                Description = "Loading Station Cash In",
                ExpectedAmount = TotalLoadingStationCashIn,
                ActualAmount = TotalLoadingStationCashIn
            };
            if (item.ActualAmount - item.ExpectedAmount != 0)
                item.Remarks = string.Format("{0} [{1:0.00}]", item.ActualAmount - item.ExpectedAmount > 0 ? "Over" : (item.ActualAmount - item.ExpectedAmount == 0 ? "Match" : "Short"), item.ActualAmount - item.ExpectedAmount);
            else item.Remarks = "Match";
            lstCheckOutItems.Add(item);
            AddItemToGrid(item);

            item = new clsCheckOutItem()
            {
                Description = "Loading Station Cash Out",
                ExpectedAmount = TotalLoadingStationCashOut,
                ActualAmount = TotalLoadingStationCashOut
            };
            if (item.ActualAmount - item.ExpectedAmount != 0)
                item.Remarks = string.Format("{0} [{1:0.00}]", item.ActualAmount - item.ExpectedAmount > 0 ? "Over" : (item.ActualAmount - item.ExpectedAmount == 0 ? "Match" : "Short"), item.ActualAmount - item.ExpectedAmount);
            else item.Remarks = "Match";
            lstCheckOutItems.Add(item);
            AddItemToGrid(item);
            
            
                List<clsLoadAccount> lstLoadAccount = clsLoadAccount.GetLoadAccounts();
                if (lstLoadAccount.Count > 0)
                {
                    foreach (clsLoadAccount account in lstLoadAccount)
                    {
                        item = new clsCheckOutItem()
                        {
                            Description = account.Description,
                            ExpectedAmount = account.AvailableBalance,
                            ActualAmount = 0
                        };
                        if (isCheckout)
                        {
                            double remainingBal = account.AvailableBalance;
                            frmInput input = new frmInput();
                            input.Title = "Actual Remaining Balance";
                            input.Value ="0";
                            input.Caption = account.Description;
                            if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                item.ActualAmount = double.Parse(input.Value);
                            }
                        }
                        if (item.ActualAmount - item.ExpectedAmount != 0)
                            item.Remarks = string.Format("{0} [{1:0.00}]", item.ActualAmount - item.ExpectedAmount > 0 ? "Over" : (item.ActualAmount - item.ExpectedAmount == 0 ? "Match" : "Short"), item.ActualAmount - item.ExpectedAmount);
                        else item.Remarks = "Match";
                        lstCheckOutItems.Add(item);
                        AddItemToGrid(item);
                    }
                }
            
            item = new clsCheckOutItem()
            {
                Description = "Cash on Hand",
                ExpectedAmount = expectedCOH,
                ActualAmount = actualCOH,
            };
            if (item.ActualAmount - item.ExpectedAmount != 0)
                item.Remarks = string.Format("{0} [{1:0.00}]", item.ActualAmount - item.ExpectedAmount > 0 ? "Over" : (item.ActualAmount - item.ExpectedAmount == 0 ? "Match" : "Short"), item.ActualAmount - item.ExpectedAmount);
            else item.Remarks = "Match";
            lstCheckOutItems.Add(item);
            AddItemToGrid(item);

        }
        private void AddItemToGrid(clsCheckOutItem item)
        {
            int rowidx = dgvChkOut.Rows.Add();
            dgvChkOut.Rows[rowidx].Cells[0].Value = item.Description;
            dgvChkOut.Rows[rowidx].Cells[1].Value = item.ExpectedAmount.ToString("n");
            dgvChkOut.Rows[rowidx].Cells[2].Value = item.ActualAmount.ToString("n");

            dgvChkOut.Rows[rowidx].Cells[3].Value = item.Remarks;
        }
        private void dtPickEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickEnd.Value <= dtPickStart.Value) dtPickStart.Value = dtPickEnd.Value.AddDays(-1);
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            int selidx = -1;
            foreach (clsUsers users in lstUsers)
            {
                cboCashier.Items.Add(users.UserName);
                if (users.UserId == m_userid) selidx = cboCashier.Items.Count - 1;
            }
            cboCashier.Enabled = true;
            dtPickEnd.Value = dtPickStart.Value.AddDays(1);

            if (selidx >= 0){
                cboCashier.SelectedIndex = selidx;
                cboCashier.Enabled = false;
                btnCheckOut.Enabled = false;
                btnSearch.Enabled = false;
                dtPickStart.Enabled = false;
                isCheckout = true;                
                CheckOut();
            }
            else
                cboCashier.SelectedIndex = -1;

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

            totalSales.AddRange(con.GetSalesInfo(startdate, enddate, cashier));

            con.Close();
            
            return totalSales;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            isCheckout = true;
            CheckOut();
        }

        public void CheckOut()
        {    
            double totalamount = 0;
            Receipt or = new Receipt();
            or.InitializePrinter();
            or.OpenDrawer();


            frmInput payment = new frmInput();
            payment.Title = "Actual Cash on Hand";
            payment.Caption = "Amount";
            payment.IsNumericOnly = true;
            payment.Value = "0";
            if (payment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (payment.Value != "" && Convert.ToDouble(payment.Value)>0)
                {
                    CashCount cc = new CashCount();
                    if (cc.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        return;
                    else
                        totalamount = cc.TotalAmount;
                    if (Convert.ToDouble(payment.Value) != totalamount)
                    {
                        MessageBox.Show("Cash count doesn't match with your total Amount", "Cash Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //btnSearch.PerformClick();
                    UpdateCheckout();

                    clsCheckOut ckout = new clsCheckOut();
                    ckout.ActualAmount = double.Parse(payment.Value);
                    ckout.ExpectedAmount = expectedCOH;
                    ckout.Timestamp = dtPickStart.Value;
                    ckout.UserId = lstUsers[cboCashier.SelectedIndex].UserId;
                    ckout.UserName = lstUsers[cboCashier.SelectedIndex].UserName;
                    lstCheckOutItems[lstCheckOutItems.Count - 1].ActualAmount = ckout.ActualAmount;
                    ckout.LstItems = this.lstCheckOutItems;

                    ckout.Save();
                    isCheckout = false;
                    UpdateCheckout();
                    btnPrint.PerformClick();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            UpdateCheckout();
            Print();
        }

        public void Print()
        {
            string ret = "";
            Receipt or = new Receipt();
            or.InitializePrinter();
            List<string> strmsg = new List<string>();
            ret += or.PrintCompanyHeader();
            strmsg.Add("");
            strmsg.Add("Checkout Receipt");
            ret += or.PrintHeader(strmsg, PrintFontAlignment.Center , PrintFontSize.UnderlineBold);
            strmsg.Clear();
            strmsg.Add("Cashier:" + lstUsers[cboCashier.SelectedIndex].UserName);
            strmsg.Add("Date:" + this.dtPickStart.Value.ToString());
            strmsg.Add("");

            for (int ctr = 0; ctr < dgvChkOut.Rows.Count; ctr++)
            {
                strmsg.Add(string.Format("{0}: \nActual: P {1:0.00}\nRemarks: {2}", dgvChkOut.Rows[ctr].Cells[0].Value, dgvChkOut.Rows[ctr].Cells[2].Value, dgvChkOut.Rows[ctr].Cells[3].Value));
            }
            //strmsg.Add(lblInitCash.Text);
            //strmsg.Add(lblTotalExpenses.Text);
            //strmsg.Add(lblTotalSales.Text);
            //strmsg.Add(lblTotalPayments.Text);
            //strmsg.Add(lblExpectedCOH.Text);
            //strmsg.Add(lblActualCash.Text);
            //strmsg.Add(lblDiff.Text);
            //strmsg.Add("");
            strmsg.Add("");
            strmsg.Add("");
            strmsg.Add("_________________________");
            strmsg.Add(lstUsers[cboCashier.SelectedIndex].UserName);
            strmsg.Add("");
            strmsg.Add("");
            strmsg.Add("");
            strmsg.Add("_________________________");
            strmsg.Add("Owner/Manager");
            ret += or.PrintAppend(strmsg, PrintFontAlignment.Left , PrintFontSize.Regular);
            or.FormFeed();
            or.ExecPrint(ret);
        }

    }
}
