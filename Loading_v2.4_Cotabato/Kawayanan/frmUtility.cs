using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class;
using AlreySolutions.Reports;
using System.IO;

namespace AlreySolutions
{
    public partial class frmUtility : Form
    {
        private clsUsers m_user = null;
        private myPosWide m_POS = null;
        frmUserInfo m_winUserInfo = new frmUserInfo();
        frmSQLQuery m_winQuery = new frmSQLQuery();
        frmSetup m_winSetup =null;
        frmSalesReportLite m_winSalesReport = new frmSalesReportLite();
        frmProdSalesReport m_winProdSalesReport = new frmProdSalesReport();
        frmInventory m_winProdInventory = new frmInventory("");
        frmProductInfo m_winProdInfo = new frmProductInfo();
        AboutBox m_winAbout = new AboutBox();
        frmLicenseInfo m_winLicense = new frmLicenseInfo();
        frmCriticalInventory m_winCritical = new frmCriticalInventory();
        frmExpenseReport m_winExpenseReport = null;
        frmExpiryDate m_winExpiry = new frmExpiryDate();
        frmAccounts m_winAccounts = new frmAccounts();
        frmAccountsReceivable m_winAccountsReceivable = null;
        frmCategories m_winCategory = new frmCategories();
        frmReloadHistoryReport m_reloadHistory = new frmReloadHistoryReport();
        frmEcashTransReport m_ecashTransactions = new frmEcashTransReport();
        frmSCashTransReport m_smartcashtrans = new frmSCashTransReport();
        frmELoadTransReport m_eloadtrans = new frmELoadTransReport();
        frmLoadWalletTransactionsReport m_loadwallettrans = new frmLoadWalletTransactionsReport();

        public frmUtility(clsUsers _user, myPosWide poswide)
        {
            InitializeComponent();
            m_user = _user;
            m_POS = poswide;
            m_winUserInfo.MdiParent = this;
            m_winQuery.MdiParent = this;
            m_winSetup = new frmSetup(m_user);
            m_winSetup.MdiParent = this;
            m_winSalesReport.MdiParent = this;
            m_winProdSalesReport.MdiParent = this;
            m_winProdInventory = new frmInventory(m_user.UserName);
            m_winProdInventory.MdiParent = this;
            m_winProdInfo.MdiParent = this;
            m_winAbout.MdiParent = this;
            m_winLicense.MdiParent = this;
            m_winCritical.MdiParent = this;
            m_winExpiry.MdiParent = this;
            m_winAccounts.MdiParent = this;
            m_winExpenseReport = new frmExpenseReport(m_user);
            m_winExpenseReport.MdiParent = this;
            m_winAccountsReceivable = new frmAccountsReceivable(m_user);
            m_winAccountsReceivable.MdiParent = this;
            m_winCategory.MdiParent = this;
            m_reloadHistory.MdiParent = this;
            m_ecashTransactions.MdiParent = this;
            m_smartcashtrans.MdiParent = this;
            m_eloadtrans.MdiParent = this;
            m_loadwallettrans.MdiParent = this;

        }

        private void Query()
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Admin))
            {
                m_winQuery = new frmSQLQuery();
                m_winQuery.ShowDialog();
            }
        }

        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            SetupUserAccount();
        }

        private void ActivateChild(Form selform)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (selform.GetType() == frm.GetType())
                {
                    selform.Show();
                    selform.BringToFront();
                    return;
                }
            }
        }
        private void SetupUserAccount()
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                ActivateChild(m_winUserInfo);
                //if (m_winUserInfo.Visible==false)
                //    m_winUserInfo.Show();
                //else
                //    m_winUserInfo.Activate();
            }
        }

        private void btnSetupProd_Click(object sender, EventArgs e)
        {
            SetupProduct();
        }

        private void SetupProduct()
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Manager)) return;
            ActivateChild(m_winSetup);
        }
        private void btnSalesInventory_Click(object sender, EventArgs e)
        {
            SalesInventory();
        }

        private void SalesInventory()
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                ActivateChild(m_winSalesReport);
            }
        }
        private void ProdSalesInventory()
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                ActivateChild(m_winProdSalesReport);

            }
        }

        private void btnProdInventory_Click(object sender, EventArgs e)
        {
            ProductInventory();
        }
        private void ProductInventory()
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                ActivateChild(m_winProdInventory);
            }
        }
        private void StocksInquiry()
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                ActivateChild(m_winProdInfo);
            }
        }

        //private bool GetApproval(int accesslevel = 4)
        //{
        //    if (m_user.LoginType <= accesslevel)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        if (accesslevel == 1)
        //            MessageBox.Show("This action requires approval from Administrator.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        else if (accesslevel == 2)
        //            MessageBox.Show("This action requires approval from Manager.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        else if (accesslevel == 3)
        //            MessageBox.Show("This action requires approval from Manager/Supervisor.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        //        frmApproval login = new frmApproval(accesslevel);
        //        if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            clsUsers iuser = login.m_User;
        //            if (iuser.LoginType <= accesslevel) return true;
        //        }
        //    }

        //    return false;
        //}


        private void btnAbout_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }

        private void ShowAbout()
        {
            ActivateChild(m_winAbout);
        }

        private void btnProdLicense_Click(object sender, EventArgs e)
        {
            ShowProdLicense();
        }

        private void ShowProdLicense()
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                ActivateChild(m_winLicense);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            BackupData();
        }

        private void BackupData()
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                string directory = Path.GetDirectoryName(Application.ExecutablePath);
                directory = directory.Substring(0, directory.LastIndexOf("\\"));
                string backup = directory + "\\iPOSBackup";
                string filename = string.Format("{0}\\backup_{1:yyyMMdd_HHmm}.mdb", backup, DateTime.Now);
                if (!Directory.Exists(backup))
                {
                    Directory.CreateDirectory(backup);
                }
                dbConnect con = new dbConnect();
                string dbName = con.GetDatabaseName();
                con.Close();
                try
                {
                    File.Copy(dbName, filename, true);
                    MessageBox.Show(string.Format("Backup was saved successfully to {0}", filename), "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnStocksInquiry_Click(object sender, EventArgs e)
        {
            StocksInquiry();
        }

        private void btnUpdateInitExp_Click(object sender, EventArgs e)
        {
        }

        private void btnAddExpenses_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Cashier))
            {
                clsExpenses exp = new clsExpenses();
                exp.UserId = m_user.UserId;
                exp.UserName = m_user.UserName;
                exp.Amount = 0;
                exp.Description = "";
                exp.Timestamp = DateTime.Now;


                frmInput InputExpense = new frmInput();
                InputExpense.Title = "Expense Description";
                InputExpense.Caption = "Description";
                InputExpense.IsNumericOnly = false;
                InputExpense.Value = "";
                if (InputExpense.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (InputExpense.Value != "")
                    {
                        exp.Description = InputExpense.Value;

                        InputExpense.Title = "Expense Amount";
                        InputExpense.Caption = "Amount";
                        InputExpense.IsNumericOnly = true;
                        InputExpense.Value = "0";
                        if (InputExpense.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            if (InputExpense.Value != "")
                            {
                                exp.Amount = Convert.ToDouble(InputExpense.Value);
                                exp.Save();
                            }
                        }
                    }
                }
            }
        }

        private void btnShowExpenses_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                ActivateChild(m_winExpenseReport);

            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                frmChkOutLight chkout = new frmChkOutLight();
                chkout.ShowDialog();
            }
        }

        private void btnCritical_Click(object sender, EventArgs e)
        {
            ActivateChild( m_winCritical);
        }

        private void btnExpiration_Click(object sender, EventArgs e)
        {
            ActivateChild(m_winExpiry);

        }

        private void btnProdSalesReport_Click(object sender, EventArgs e)
        {
            ProdSalesInventory();
        }
        private static void ShowSplashScreen()
        {
            SpashScreen screen = new SpashScreen();
            screen.ShowDialog();
        }

        //private bool GetApproval(UserAccess accesslevel = UserAccess.Cashier)
        //{
        //    if (m_user.LoginType <= (int)accesslevel)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        if (accesslevel == UserAccess.Admin)
        //            MessageBox.Show("This action requires approval from Administrator.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        else if (accesslevel == UserAccess.Manager)
        //            MessageBox.Show("This action requires approval from Manager.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        else if (accesslevel == UserAccess.Supervisor)
        //            MessageBox.Show("This action requires approval from Manager/Supervisor.", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        //        frmApproval login = new frmApproval((int)accesslevel);
        //        if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            clsUsers iuser = login.m_User;
        //            if (iuser.LoginType <= (int)accesslevel) return true;
        //        }
        //    }

        //    return false;
        //}
        private void frmUtility_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            if (m_user == null || m_POS == null)
            {
                frmLogin login = new frmLogin();
                if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    m_user = login.m_User;
                    m_winSetup = new frmSetup(m_user);
                    if (clsUtil.GetApproval(m_user, UserAccess.Manager))
                    {
                        ShowSplashScreen();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void btnCustAccount_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                ActivateChild(m_winAccounts);

            }
        }

        private void btnAccountsRec_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                ActivateChild(m_winAccountsReceivable);
            }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                ActivateChild(m_winCategory);

            }
        }

        private void searchProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StocksInquiry();
        }

        private void setupProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupProduct();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCategories.PerformClick();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUserAccount.PerformClick();
        }

        private void productPurchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnProdSalesReport.PerformClick();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSalesInventory.PerformClick();
        }

        private void expirationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExpiration.PerformClick();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnProdInventory.PerformClick();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnShowExpenses_Click(null, null);
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCustAccount.PerformClick();
        }

        private void receivablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAccountsRec.PerformClick();
        }

        private void cashOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddExpenses.PerformClick();
        }

        private void cashinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCashIn.PerformClick();
        }

        private void checkoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckOut_Click(null, null);
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBackup_Click(null, null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAbout_Click(null, null);
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnProdLicense_Click(null, null);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCashIn_Click( object sender, EventArgs e )
        {
            //Receipt or = new Receipt();
            //or.InitializePrinter();
            //for (int ctr = 200; ctr < 300; ctr++)
            //{
            //    or.PrintTest(new List<string> { "Test Print:" + ctr.ToString() },1, ctr);
            //}
            //or.ExecPrint();
            //return;
            if (m_POS != null)
                m_POS.CheckInitialCash(true);
            else
                MessageBox.Show("Please update initial cash at the Cashier's computer", "Initial Cash", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void depositCashToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (m_POS != null)
                m_POS.CheckDepositCash(true);
            else
                MessageBox.Show("Please update deposit cash at the Cashier's computer", "Deposit Cash", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void frmUtility_FormClosing( object sender, FormClosingEventArgs e )
        {
        }

        private void productPurchasesToolStripMenuItem1_Click( object sender, EventArgs e )
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                frmPurchaseSummary p = new frmPurchaseSummary();
                p.MdiParent = this;
                p.Show();
            }
        }

        private void paymentSummaryToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                frmPaymentSummary p = new frmPaymentSummary();
                p.MdiParent = this;
                p.Show();
            }
        }

        private void themesToolStripMenuItem_Click( object sender, EventArgs e )
        {
            frmThemes fthemes = new frmThemes();
            fthemes.ShowDialog();
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
        }

        private void settingsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                frmSettings fset = new frmSettings();
                fset.MdiParent = this;
                fset.Show();
            }
        }

        private void reloadHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                ActivateChild(m_reloadHistory);
            }
        }

        private void eCashTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                ActivateChild(m_ecashTransactions);
            }
        }

        private void smartPadalaTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                ActivateChild(m_smartcashtrans);
            }
        }

        private void eloadTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                ActivateChild(m_eloadtrans);
            }
        }

        private void loadwalletTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Supervisor))
            {
                ActivateChild(m_loadwallettrans);
            }
        }
    }
}
