using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class.Load;
using System.IO;
using AlreySolutions.Class;

namespace AlreySolutions.LoadingStation
{
    public partial class frmSmartMoneyTrans : Form
    {
        clsLoadAccount m_LoadAccount = null;
        List<clsUnclaimedCash> m_UnclaimedCash = null;

        public frmSmartMoneyTrans(clsLoadAccount act)
        {
            InitializeComponent();
            m_LoadAccount = clsLoadAccount.GetLoadAccount(act.LoadId);
            txtSSAmount.KeyDown += new KeyEventHandler(txtWithDec_KeyDown);
            txtSSSvcFee.KeyDown += new KeyEventHandler(txtWithDec_KeyDown);
            txtCSAmount.KeyDown += new KeyEventHandler(txtWithDec_KeyDown);
            txtCSSvcFee.KeyDown += new KeyEventHandler(txtWithDec_KeyDown);
            txtSenderNum.KeyDown += new KeyEventHandler(txtWithOutDec_KeyDown);
            txtSSRecipientNum.KeyDown += new KeyEventHandler(txtWithOutDec_KeyDown);
            txtCSSmartMoney.KeyDown += new KeyEventHandler(txtWithOutDec_KeyDown);
            txtSSSmartMoney.KeyDown += new KeyEventHandler(txtWithOutDec_KeyDown);
        }

        private void btnProcessSend_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                clsSmartCashTransaction sc = new clsSmartCashTransaction();
                sc.TransDate = DateTime.Now;
                sc.SenderName = txtSenderName.Text.Trim();
                sc.SenderContact = txtSenderNum.Text.Trim();
                sc.Load_Id = m_LoadAccount.LoadId;
                sc.Remarks = " ";
                sc.RecepientAccNum = " ";
                sc.UserId = myPosWide.m_user.UserId;
                if (tabCtrl.SelectedIndex == 0)
                {
                    sc.TransType = SCashTranstype.SEND;
                    sc.RecipientName = txtSSRecipientName.Text.Trim();
                    sc.RecipientContact = txtSSRecipientNum.Text.Trim();
                    sc.RecepientAccNum = txtSSSmartMoney.Text.Trim();

                    sc.RefNum = txtSSRefNum.Text;
                    sc.TransAmount = double.Parse(txtSSAmount.Text.Trim());
                    sc.SvcFeeAmount = double.Parse(txtSSSvcFee.Text.Trim());
                    sc.Rebate = double.Parse(txtSSCommission.Text.Trim());
                    sc.Remarks = clsSmartCashTransaction.GetTransType(sc.TransType);
                    frmInput input = new frmInput();
                    double amountdue = sc.TransAmount + sc.SvcFeeAmount;
                    input.Title = "Payment";
                    input.Value = amountdue.ToString("0.00");
                    input.Caption = "Enter Tendered Amount";
                    if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (Convert.ToDouble(input.Value) >= amountdue)
                        {
                            sc.TenderedAmount = Convert.ToDouble(input.Value);
                            if (sc.Save())
                            {
                                string ret = "";
                                Receipt or = new Receipt();
                                or.InitializePrinter();
                                List<string> strmsg = new List<string>();
                                ret += or.PrintCompanyHeader();
                                strmsg.Add("SMART MONEY");
                                strmsg.Add(sc.Remarks);
                                ret += or.PrintHeader(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold);
                                strmsg.Clear();

                                strmsg.Add(string.Format("Cashier: {0}", myPosWide.m_user.UserName.ToUpper()));
                                strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                strmsg.Add(string.Format("TransId: {0}", sc.SCashTransId));
                                strmsg.Add("");
                                strmsg.Add(string.Format("Sender: {0:0.00}", sc.SenderName));
                                strmsg.Add(string.Format("Contact Num: {0:0.00}", sc.SenderContact));
                                strmsg.Add(string.Format("Recipient: {0:0.00}", sc.RecipientName));
                                strmsg.Add(string.Format("Contact: {0:0.00}", sc.RecipientContact));
                                strmsg.Add(string.Format("Smart Money: {0:0.00}", sc.RecepientAccNum));
                                strmsg.Add(string.Format("RefNum: {0:0.00}", sc.RefNum));
                                strmsg.Add(string.Format("Trans Amount: P {0:0.00}", sc.TransAmount));
                                strmsg.Add(string.Format("Service Fee: P {0:0.00}", sc.SvcFeeAmount));
                                strmsg.Add(string.Format("Total Amount: P {0:0.00}", amountdue));
                                strmsg.Add(string.Format("Tendered Amount: P {0:0.00}", sc.TenderedAmount));
                                strmsg.Add(string.Format("Change Amount: P {0:0.00}", sc.TenderedAmount- amountdue));
                                strmsg.Add("");
                                strmsg.Add("");
                                ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                                or.FormFeed();
                                or.OpenDrawer();
                                or.ExecPrint(ret);
                                strmsg.Clear();
                                Clear();
                                m_LoadAccount = clsLoadAccount.GetLoadAccount(m_LoadAccount.LoadId);
                                RefreshAccount();
                            }
                            else
                            {
                                MessageBox.Show("Saving failed", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Amount entered is less than the Amount Due", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else if (tabCtrl.SelectedIndex == 1)
                {
                    sc.TransType = SCashTranstype.ENCASH;
                    if (optCash.Checked)
                        sc.PaymentMode = SCashPaymentMode.CASH;
                    else if (optSmartMoney.Checked)
                        sc.PaymentMode = SCashPaymentMode.SMARTMONEY;

                    sc.SenderAccnum = txtCSSmartMoney.Text;
                    sc.RefNum = txtCSRefNum.Text;
                    sc.TransAmount = double.Parse(txtCSAmount.Text.Trim());
                    sc.SvcFeeAmount = double.Parse(txtCSSvcFee.Text.Trim());
                    sc.Rebate = 0; // double.Parse(txtCSCommission.Text.Trim());
                    sc.TotalAmtTransfered = double.Parse(txtCSTotalAmtTrans.Text);


                    if (MessageBox.Show(string.Format("You are about to deduct {0:0.00} from your actual cash on hand.\n\nAre you sure this is correct?", sc.TransAmount - sc.SvcFeeAmount), "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (sc.Save())
                        {
                            if (clsUnclaimedCash.ClaimCash(sc.RefNum))
                            {
                                UpdateList();
                            }
                            string ret = "";
                            Receipt or = new Receipt();
                            or.InitializePrinter();
                            List<string> strmsg = new List<string>();
                            ret += or.PrintCompanyHeader();
                            strmsg.Add("SMART MONEY");
                            strmsg.Add(sc.Remarks);
                            ret += or.PrintHeader(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold);
                            strmsg.Clear();

                            strmsg.Add(string.Format("Cashier: {0}", myPosWide.m_user.UserName.ToUpper()));
                            strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            strmsg.Add(string.Format("TransId: {0}", sc.SCashTransId));
                            strmsg.Add("");
                            strmsg.Add(string.Format("Sender: {0:0.00}", sc.SenderName));
                            strmsg.Add(string.Format("Contact Num: {0:0.00}", sc.SenderContact));
                            strmsg.Add(string.Format("Smart Money: {0:0.00}", sc.RecepientAccNum));
                            strmsg.Add(string.Format("RefNum: {0:0.00}", sc.RefNum));
                            strmsg.Add(string.Format("Trans Amount: P {0:0.00}", sc.TransAmount));
                            strmsg.Add(string.Format("Service Fee: P {0:0.00}", sc.SvcFeeAmount));
                            strmsg.Add(string.Format("Payout Amount: P {0:0.00}", sc.TransAmount - sc.SvcFeeAmount));
                            strmsg.Add("");
                            strmsg.Add("");
                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                            or.FormFeed();
                            or.OpenDrawer();
                            or.ExecPrint(ret);
                            strmsg.Clear();
                            Clear();
                            RefreshAccount();
                        }
                    }

                }

                
            }
        }

        private bool ValidateInput()
        {
            if (txtSenderName.Text == "" || txtSenderNum.Text == "" ||
            (tabCtrl.SelectedIndex == 0 && (txtSSSmartMoney.Text == "" || txtSSRecipientName.Text == "" || txtSSSmartMoney.Text == "" || txtSSRefNum.Text == "" || txtSSAmount.Text == "" || txtSSSvcFee.Text == "")) ||
            (tabCtrl.SelectedIndex == 1 && (txtCSSmartMoney.Text == "" || txtCSRefNum.Text == "" || txtCSAmount.Text == "" || txtCSSvcFee.Text == "")))
            {
                MessageBox.Show("Kindly fill-out required fields", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        } 

        private void frmSPadalaTrans_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            RefreshAccount();
        }
        private void txtWithDec_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = true;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }
        private void txtWithOutDec_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = false;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }
        private void RefreshAccount()
        {
            m_LoadAccount = clsLoadAccount.GetLoadAccount(m_LoadAccount.LoadId);
            m_LoadAccount.LstServiceFees = clsServiceFee.GetServiceFees(m_LoadAccount.LoadId);
            ctrlLoadAccount.Description = m_LoadAccount.Description;
            ctrlLoadAccount.LoadType = m_LoadAccount.LoadType;
            ctrlLoadAccount.LoadId = m_LoadAccount.LoadId;
            lblAvailableBal.Text = string.Format("Available Bal: {0:n}\nCurrent Bal: {1:n}", m_LoadAccount.AvailableBalance, m_LoadAccount.CurrentBalance);
            //btn.Picture = 
            if (m_LoadAccount.ImgFile != null)
            {
                MemoryStream mem = new MemoryStream(m_LoadAccount.ImgFile);
                ctrlLoadAccount.Picture = Image.FromStream(mem);
                mem.Close();
            }
            else
            {
                ctrlLoadAccount.Picture = null;
            }
        }
        private void txtAmount1_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != "")
            {
                try
                {
                    clsServiceFee fee = m_LoadAccount.LstServiceFees.FirstOrDefault(x => double.Parse(txt.Text) <= x.AmountTo);
                    if (fee != null)
                    {
                        clsServiceFee inhousefee = ComputeGCashremitFee(double.Parse(txt.Text), true);

                        fee.Rebate = inhousefee.EcashFee - fee.EcashFee;
                        txtSSSvcFee.Text = inhousefee.EcashFee.ToString("n");
                        txtSSCommission.Text = fee.Rebate.ToString();
                    }
                    else txtSSSvcFee.Text = "";
                }
                catch { txtSSSvcFee.Text = ""; }
            }
            else txtSSSvcFee.Text = "";
        }
        private clsServiceFee ComputeGCashremitFee(double amt,bool isPadala = false)
        {
            clsServiceFee ret = new clsServiceFee();
            if (amt <= 1000)
            {
                ret.EcashFee = 30;
                ret.Rebate = 0;
            }
            else
            {                
                ret.EcashFee = amt * (isPadala ? 0.025 : 0.02);
                ret.Rebate = 0;
            }
            return ret;
        }

        private void txtAmount2_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != "")
            {
                try
                {
                    //clsServiceFee fee = m_LoadAccount.LstServiceFees.FirstOrDefault(x => double.Parse(txt.Text) <= x.AmountTo);
                    //if (fee != null)
                    //{
                        clsServiceFee inhousefee = ComputeGCashremitFee(double.Parse(txt.Text), false);

                        //fee.Rebate = inhousefee.EcashFee - fee.EcashFee;

                        txtCSSvcFee.Text = inhousefee.EcashFee.ToString("n");
                        txtCSCommission.Text = "0";
                        txtCSTotalAmtTrans.Text = txt.Text;
                        double p = double.Parse(txtCSAmount.Text) - double.Parse(txtCSSvcFee.Text);
                        txtCSTotalPayment.Text = string.Format("{0:0.00}", p);

                        //if (optCash.Checked)
                        //{
                        //    txtTotalCashPayment.Text = string.Format("{0:n}", double.Parse(txt.Text) - fee.EcashFee);
                        //}
                        //else
                        //{
                        //    txtTotalCashPayment.Text = string.Format("{0:n}", double.Parse(txt.Text));
                        //}
                    //}
                    //else txtCSSvcFee.Text = "";
                }
                catch { txtCSSvcFee.Text = ""; }
            }
            else txtCSSvcFee.Text = "";
        }

        private void btnClearSend_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {

            txtSenderName.Text = "";
            txtSenderNum.Text = "";
            txtSSSmartMoney.Text = "";
            txtSSRecipientName.Text = "";
            txtSSSmartMoney.Text = "";
            txtSSRecipientNum.Text = "";
            txtSSRefNum.Text = "";
            txtSSAmount.Text = "0";
            txtSSSvcFee.Text = "0";
            txtCSSmartMoney.Text = "";
            txtCSRefNum.Text = "";
            txtCSAmount.Text = "0";
            txtCSSvcFee.Text = "0";

            txtSSCommission.Text = "0";
            txtCSCommission.Text = "0";
            txtCSTotalAmtTrans.Text = "";
            txtCSTotalPayment.Text = "";

            txtSenderName.Focus();

            txtUCSmartMoney.Text = "";
            txtUCRefNum.Text = "";
            txtUCAmount.Text = "0";
        }

        private void optSmartMoney_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void optCash_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnSaveUnclaimedCash_Click(object sender, EventArgs e)
        {
            if (txtUCSmartMoney.Text.Trim().Length != 16 )
            {
                MessageBox.Show("Invalid SmartMoney format", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUCSmartMoney.Focus();
                txtUCSmartMoney.SelectAll();
            }
            else if(string.IsNullOrEmpty(txtUCAmount.Text) || Convert.ToInt32(txtUCAmount.Text) <= 0 )
            {
                MessageBox.Show("Invalid Amount", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUCAmount.Focus();
                txtUCAmount.SelectAll();
                
            }
            else if(string.IsNullOrEmpty(txtUCRefNum.Text))
            {
                MessageBox.Show("Reference Num is required", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUCRefNum.Focus();
            }
            else
            {
                clsUnclaimedCash uc = new clsUnclaimedCash();
                uc.Amount = Convert.ToInt32(txtUCAmount.Text);
                uc.LoadAccountId = m_LoadAccount.LoadId;
                uc.RefNum = txtUCRefNum.Text.Trim();
                uc.SmartMoney = txtUCSmartMoney.Text.Trim();
                uc.UserId = myPosWide.m_user.UserId;
                uc.Timestamp = DateTime.Now;
                if (uc.Save())
                {
                    MessageBox.Show("Unclaimed cash added successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateList();
                    RefreshAccount();
                    Clear();
                }
            }
        }
        private void UpdateList()
        {
            m_UnclaimedCash = clsUnclaimedCash.GetUnclaimedCash(m_LoadAccount.LoadId);
            dgvUnclaimedCash.Rows.Clear();
            cboRefNum.Items.Clear();
            foreach (clsUnclaimedCash uc in m_UnclaimedCash)
            {
                AddItemToGrid(uc);
                cboRefNum.Items.Add(uc.RefNum);
                if (txtCSRefNum.Text == uc.RefNum) cboRefNum.SelectedItem = uc.RefNum;
            }
            RefreshAccount();
        }

        private void AddItemToGrid(clsUnclaimedCash uc)
        {
            int rowidx = dgvUnclaimedCash.Rows.Add();

            dgvUnclaimedCash.Rows[rowidx].Cells[0].Value = uc.SmartMoney;
            dgvUnclaimedCash.Rows[rowidx].Cells[1].Value = uc.RefNum;
            dgvUnclaimedCash.Rows[rowidx].Cells[2].Value = uc.Amount;
            dgvUnclaimedCash.Rows[rowidx].Cells[3].Value = uc.Timestamp;
        }

        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInfo.Text = tabCtrl.SelectedIndex == 0 ? "Sender's Information" : "Benificiary's Information";
            if (tabCtrl.SelectedIndex == 1 || tabCtrl.SelectedIndex == 2)
            {
                UpdateList();
            }
        }

        private void txtRecAccountNum_Enter(object sender, EventArgs e)
        {
            txtSSSmartMoney.SelectAll();
        }

        private void txtUCSmartMoney_Enter(object sender, EventArgs e)
        {
            txtUCSmartMoney.SelectAll();
        }

        private void cboRefNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRefNum.SelectedIndex > -1)
            {
                foreach (clsUnclaimedCash uc in m_UnclaimedCash)
                {
                    if (uc.RefNum == cboRefNum.SelectedItem.ToString().Trim())
                    {
                        txtCSSmartMoney.Text = uc.SmartMoney;
                        txtCSRefNum.Text = uc.RefNum;
                        txtCSAmount.Text = uc.Amount.ToString("n");
                    }
                }
            }
        }

        private void btnRecompute_Click(object sender, EventArgs e)
        {
            frmInput frm = new frmInput();
            frm.Title = "Recompute Service Fee";
            frm.Caption = "Enter Service Fee %:";
            frm.Value = "2";
            frm.IsNumericOnly = true;
            frm.withDecimal = true;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Convert.ToDouble(frm.Value) > 5) MessageBox.Show("Invalid Service Fee Percentage. Must be less than 5");
                else
                {
                    txtCSSvcFee.Text = (Convert.ToDouble(txtCSAmount.Text) * (Convert.ToDouble(frm.Value)/100)).ToString("0.00");
                }
            }
        }
    }
}
