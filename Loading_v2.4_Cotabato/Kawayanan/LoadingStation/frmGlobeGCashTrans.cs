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
    public partial class frmGlobeGCashTrans : Form
    {
        clsLoadAccount m_LoadAccount = null;

        public frmGlobeGCashTrans(clsLoadAccount act)
        {
            InitializeComponent();
            m_LoadAccount = clsLoadAccount.GetLoadAccount(act.LoadId);
        }

        private void frmECashTrans_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            RefreshAccount();
        }

        private void RefreshAccount()
        {
            m_LoadAccount.LstServiceFees = clsServiceFee.GetServiceFees(m_LoadAccount.LoadId);
            ctrlLoadAccount.Description = m_LoadAccount.Description;
            ctrlLoadAccount.LoadType = m_LoadAccount.LoadType;
            ctrlLoadAccount.LoadId = m_LoadAccount.LoadId;
            lblAvailableBal.Text = string.Format("Available Balance : {0:n}", m_LoadAccount.AvailableBalance);
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

        
        private void Clear()
        {
            txtSenderName.Text="Allan Rey Sagun";
            txtSenderNum.Text = "09175587982";
            txtRecipientName.Text = "Alisha Reigh Sagun";
            txtRecipientNum.Text = "09778368054";
            txtGCashMobNum.Text = "";
            txtRefNum1.Text = "";
            txtAmount1.Text = "";
            txtSvcFee1.Text = "";
            txtCountry.Text = "";
            txtRefNum2.Text = "";
            txtAmount2.Text = "";
            txtSvcFee2.Text = "";
            txtSenderMobile.Text = "";
            txtReceiverMobile.Text = "";
            txtAmount3.Text = "";
            txtSvcFee3.Text = "";
            optCashIn.Checked = true;
            optRecInt.Checked = true;
            optSendP2P.Checked = true;

            txtRebate1.Text = "";
            txtRebate2.Text = "";
            txtRebate3.Text = "";
        }


        private bool ValidateInput()
        {
            if (txtSenderName.Text == "" || txtRecipientName.Text == "" ||
            (tabCtrl.SelectedIndex == 0 && (txtGCashMobNum.Text == "" || txtRefNum1.Text == "" || txtAmount1.Text == "" || txtSvcFee1.Text == "")) ||
            (tabCtrl.SelectedIndex == 1 && (txtCountry.Text == "" ||  txtRefNum2.Text == "" || txtAmount2.Text == "" || txtSvcFee2.Text == ""))  ||
            (tabCtrl.SelectedIndex == 2 && (txtSenderMobile.Text == "" || txtReceiverMobile.Text == "" || txtAmount3.Text == "" || txtSvcFee3.Text == "")))
            {
                return false;
            }
            return true;
        }
        private void btnProcessGCash_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                double amountdue = 0;
                
                clsGCashTransaction gc = new clsGCashTransaction();
                gc.SenderName = txtSenderName.Text;
                gc.SenderContact = txtSenderNum.Text;
                gc.RecipientName = txtRecipientName.Text;
                gc.RecipientContact = txtRecipientNum.Text;
                gc.GCashNumber = txtGCashMobNum.Text;
                gc.TransDate = DateTime.Now;
                gc.Country = "";

                if (tabCtrl.SelectedIndex == 0)
                {
                    if (optCashIn.Checked)
                        gc.TransactionType = GCashTransType.CashIn;
                    else if (optCashOut.Checked)
                        gc.TransactionType = GCashTransType.CashOut;
                    else if (optSendOthers.Checked)
                        gc.TransactionType = GCashTransType.SendToOthers;

                    gc.RefNum = txtRefNum1.Text;
                    gc.TransAmount = Convert.ToDouble(txtAmount1.Text);
                    gc.SvcFeeAmount = Convert.ToDouble(txtSvcFee1.Text);
                    gc.Rebate = Convert.ToDouble(txtRebate1.Text);
                }
                else if (tabCtrl.SelectedIndex == 1)
                {
                    if (optRecInt.Checked)
                    {
                        gc.TransactionType = GCashTransType.IntCashPickUp;
                        gc.Country = txtCountry.Text;
                    }
                    else if (optRecDom.Checked)
                        gc.TransactionType = GCashTransType.DomCashPickup;

                    gc.RefNum = txtRefNum2.Text;
                    gc.TransAmount = Convert.ToDouble(txtAmount2.Text);
                    gc.SvcFeeAmount = Convert.ToDouble(txtSvcFee2.Text);
                    gc.Rebate = Convert.ToDouble(txtRebate2.Text);
                }
                else if (tabCtrl.SelectedIndex == 2)
                {
                    if (optSendP2P.Checked)
                    {
                        gc.TransactionType = GCashTransType.RemitSend;                        
                        gc.TransAmount = Convert.ToDouble(txtAmount3.Text);
                        gc.SvcFeeAmount = Convert.ToDouble(txtSvcFee3.Text);
                        gc.Rebate = Convert.ToDouble(txtRebate3.Text);
                    }
                    else if (optCancelP2P.Checked)
                    {
                        gc.TransactionType = GCashTransType.RemitCancel;
                        gc.TransAmount = Convert.ToDouble(txtAmount3.Text);
                        gc.SvcFeeAmount = Convert.ToDouble(txtSvcFee3.Text);
                        gc.Rebate = Convert.ToDouble(txtRebate3.Text);
                    }
                    gc.RefNum = "";
                   
                }
                amountdue = gc.TransAmount + gc.SvcFeeAmount;                
                gc.UserId = myPosWide.m_user.UserId;
                gc.UserName = myPosWide.m_user.UserName;
                gc.Remarks = clsGCashTransaction.GetTransType(gc.TransactionType);
                gc.Load_Id = m_LoadAccount.LoadId;

                if (tabCtrl.SelectedIndex == 2 && optCancelP2P.Checked )
                {
                    amountdue = gc.SvcFeeAmount;
                    if (MessageBox.Show(string.Format("Amount: {0:0.00}\nService Fee: {1:0.00}\nPayout Amount: {2:0.00}\n\nAre you sure this is correct?", gc.TransAmount, gc.SvcFeeAmount, gc.TransAmount - gc.SvcFeeAmount), "Cancel Remittance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (gc.Save())
                        {
                            MessageBox.Show("Transaction completed", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            string ret = "";
                            Receipt or = new Receipt();
                            or.InitializePrinter();
                            List<string> strmsg = new List<string>();
                            ret += or.PrintCompanyHeader();
                            strmsg.Add("G-CASH");
                            strmsg.Add(gc.Remarks);
                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold);
                            strmsg.Clear();

                            strmsg.Add(string.Format("Cashier: {0}", myPosWide.m_user.UserName.ToUpper()));
                            strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            strmsg.Add(string.Format("TransId: {0}", gc.GCashtTransId));
                            strmsg.Add("");
                            strmsg.Add(string.Format("{0}", gc.Remarks));
                            strmsg.Add(string.Format("Sender: {0:0.00}", gc.SenderName));
                            strmsg.Add(string.Format("Recipient: {0:0.00}", gc.RecipientName));
                            strmsg.Add(string.Format("RefNum: {0:0.00}", gc.RefNum));
                            strmsg.Add(string.Format("Trans Amount: P {0:0.00}", gc.TransAmount));
                            strmsg.Add(string.Format("Service Fee: P {0:0.00}", gc.SvcFeeAmount));
                            strmsg.Add(string.Format("Payout Amount: P {0:0.00}", gc.TransAmount - gc.SvcFeeAmount));
                            strmsg.Add("");
                            strmsg.Add("");
                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                            or.FormFeed();
                            or.OpenDrawer();
                            or.ExecPrint(ret);
                            strmsg.Clear();

                            m_LoadAccount = clsLoadAccount.GetLoadAccount(m_LoadAccount.LoadId);
                            RefreshAccount();
                        }
                    }
                }
                else if (tabCtrl.SelectedIndex == 0 && optCashOut.Checked)
                {
                    amountdue = gc.SvcFeeAmount;
                    if (MessageBox.Show(string.Format("Amount: {0:0.00}\nService Fee: {1:0.00}\nPayout Amount: {2:0.00}\n\nAre you sure this is correct?", gc.TransAmount, gc.SvcFeeAmount, gc.TransAmount - gc.SvcFeeAmount), "Cash Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (gc.Save())
                        {
                            Clear();
                            string ret = "";
                            Receipt or = new Receipt();
                            or.InitializePrinter();
                            List<string> strmsg = new List<string>();
                            ret += or.PrintCompanyHeader();
                            strmsg.Add("G-CASH");
                            strmsg.Add(gc.Remarks);
                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold); strmsg.Clear();

                            strmsg.Add(string.Format("Cashier: {0}", myPosWide.m_user.UserName.ToUpper()));
                            strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            strmsg.Add(string.Format("TransId: {0}", gc.GCashtTransId));
                            strmsg.Add("");
                            strmsg.Add(string.Format("{0}", gc.Remarks));
                            strmsg.Add(string.Format("Sender: {0:0.00}", gc.SenderName));
                            strmsg.Add(string.Format("Recipient: {0:0.00}", gc.RecipientName));
                            strmsg.Add(string.Format("RefNum: {0:0.00}", gc.RefNum));
                            strmsg.Add(string.Format("Trans Amount: P {0:0.00}", gc.TransAmount));
                            strmsg.Add(string.Format("Service Fee: P {0:0.00}", gc.SvcFeeAmount));
                            strmsg.Add(string.Format("Payout Amount: P {0:0.00}", gc.TransAmount - gc.SvcFeeAmount));
                            strmsg.Add("");
                            strmsg.Add("");
                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                            or.FormFeed();
                            or.OpenDrawer();
                            or.ExecPrint(ret);
                            strmsg.Clear();

                            m_LoadAccount = clsLoadAccount.GetLoadAccount(m_LoadAccount.LoadId);
                            RefreshAccount();
                        }
                    }
                }
                else if (tabCtrl.SelectedIndex == 1)
                {
                    if (MessageBox.Show(string.Format("You are about to deduct {0:0.00} from your actual cash on hand. \n\nAre you sure this is correct?", gc.TransAmount), "Receive Remittance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (gc.Save())
                        {
                            Clear();
                            string ret = "";
                            Receipt or = new Receipt();
                            or.InitializePrinter();
                            List<string> strmsg = new List<string>();
                            ret += or.PrintCompanyHeader();
                            strmsg.Add("G-CASH");
                            strmsg.Add(gc.Remarks);
                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold); strmsg.Clear();

                            strmsg.Add(string.Format("Cashier: {0}", myPosWide.m_user.UserName.ToUpper()));
                            strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            strmsg.Add(string.Format("TransId: {0}", gc.GCashtTransId));
                            strmsg.Add("");
                            strmsg.Add(string.Format("Sender: {0:0.00}", gc.SenderName));
                            strmsg.Add(string.Format("Recipient: {0:0.00}", gc.RecipientName));
                            strmsg.Add(string.Format("RefNum: {0:0.00}", gc.RefNum));
                            strmsg.Add(string.Format("Trans Amount: P {0:0.00}", gc.TransAmount));
                            strmsg.Add(string.Format("Service Fee: P {0:0.00}", gc.SvcFeeAmount));
                            strmsg.Add(string.Format("Payout Amount: P {0:0.00}", gc.TransAmount - gc.SvcFeeAmount));
                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                            or.FormFeed();
                            or.OpenDrawer();
                            or.ExecPrint(ret);
                            strmsg.Clear();

                            m_LoadAccount = clsLoadAccount.GetLoadAccount(m_LoadAccount.LoadId);
                            RefreshAccount();
                        }
                    }
                }
                else
                {
                    frmInput input = new frmInput();
                    input.Title = "Payment";
                    input.Value = amountdue.ToString("0.00");
                    input.Caption = "Enter Tendered Amount";
                    if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (Convert.ToDouble(input.Value) >= amountdue)
                        {
                            gc.TenderedAmount = Convert.ToDouble(input.Value);
                            gc.Save();
                            MessageBox.Show("Transaction completed", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            string ret = "";
                            Receipt or = new Receipt();
                            or.InitializePrinter();
                            List<string> strmsg = new List<string>();
                            ret += or.PrintCompanyHeader();
                            strmsg.Add("");
                            strmsg.Add("G-CASH");
                            strmsg.Add(gc.Remarks);
                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold); strmsg.Clear();
                            strmsg.Clear();

                            strmsg.Add(string.Format("Cashier: {0}", myPosWide.m_user.UserName.ToUpper()));
                            strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                            strmsg.Add(string.Format("TransId: {0}", gc.GCashtTransId));
                            strmsg.Add("");
                            strmsg.Add(string.Format("Sender: {0:0.00}", gc.SenderName));
                            strmsg.Add(string.Format("Recepient: {0:0.00}", gc.RecipientName));
                            strmsg.Add(string.Format("Recepient Number: {0:0.00}", gc.RecipientContact));

                            strmsg.Add(string.Format("Trans Amount: P {0:0.00}", gc.TransAmount));
                            strmsg.Add(string.Format("Service Fee: P {0:0.00}", gc.SvcFeeAmount));
                            strmsg.Add(string.Format("Tendered Amount: P {0:0.00}", gc.TenderedAmount));
                            strmsg.Add(string.Format("Change: P {0:0.00}", gc.TenderedAmount - (gc.TransAmount + gc.SvcFeeAmount)));
                            strmsg.Add("");
                            strmsg.Add("");
                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                            or.FormFeed();
                            or.OpenDrawer();
                            or.ExecPrint(ret);
                            strmsg.Clear();


                            m_LoadAccount = clsLoadAccount.GetLoadAccount(m_LoadAccount.LoadId);
                            RefreshAccount();
                        }
                        else
                        {
                            MessageBox.Show("Amount entered is less than the Amount Due", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kindly fill-out required fields", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearSend_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtAmount2_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = true;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtGCashMobNum_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = false;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }


        private void txtAmount1_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != "")
            {
                if (double.Parse(txt.Text) > 40000)
                {
                    MessageBox.Show("Maximum transaction amount is 40,000.");
                    txt.Text = "40000";
                }
                else ComputeServiceFee(txt.Text);
            }
            else
            {
                txtSvcFee1.Text = "0";
                txtRebate1.Text = "0";
            }
        }

        private void ComputeServiceFee(string txt)
        {
            try
            {
                clsServiceFee fee = m_LoadAccount.LstServiceFees.FirstOrDefault(x => double.Parse(txt) <= x.AmountTo);
                if (fee != null)
                {
                    if ( optCashOut.Checked || optSendOthers.Checked )
                    {
                        txtSvcFee1.Text = fee.EcashFee.ToString("n");
                        txtRebate1.Text = ComputeRebate(double.Parse(txt)).ToString();
                    }

                    else
                    {
                        txtSvcFee1.Text = "0";
                        txtRebate1.Text = "0";
                    }
                }
                else
                {
                    txtSvcFee1.Text = "0";
                    txtRebate1.Text = "0";
                }

            }
            catch { txtSvcFee1.Text = "0"; txtRebate1.Text = "0"; }
        }
        private double ComputeRebate(double amount)
        {
            return Math.Ceiling(amount / 100);
        }
        private void txtAmount2_TextChanged(object sender, EventArgs e)
        {
            //TextBox txt = (TextBox)sender;
            //if (txt.Text != "")
            //{
            //    try
            //    {
            //        clsServiceFee fee = m_LoadAccount.LstServiceFees.FirstOrDefault(x => double.Parse(txt.Text) <= x.AmountTo);
            //        if (fee != null)
            //        {
                        txtSvcFee2.Text = "0";
                        txtRebate2.Text = "0";
            //        }
            //        else txtSvcFee2.Text = "";
            //    }
            //    catch { txtSvcFee2.Text = ""; }
            //}
            //else txtSvcFee2.Text = "";
        }

        private void txtAmount3_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != "")
            {
                try
                {
                    if (double.Parse(txt.Text) > 40000)
                    {
                        MessageBox.Show("Maximum transaction amount is 40,000.");
                        txt.Text = "40000";
                    }
                    else
                    {
                        clsServiceFee fee = ComputeGCashremitFee(double.Parse(txt.Text));
                        if (fee != null)
                        {
                            txtSvcFee3.Text = fee.EcashFee.ToString("n");
                            txtRebate3.Text = fee.Rebate.ToString();
                        }
                        else
                        {
                            txtSvcFee3.Text = "0";
                            txtRebate3.Text = "0";

                        }
                    }
                }
                catch
                {
                    txtSvcFee3.Text = "0";
                    txtRebate3.Text = "0";
                }
            }
            else
            {
                txtSvcFee3.Text = "0";
                txtRebate3.Text = "0";
            }
        }
        private clsServiceFee ComputeGCashremitFee(double amt) 
        {
            clsServiceFee ret = new clsServiceFee();
            if (optCancelP2P.Checked)
            {
                ret.EcashFee = 0;
                ret.Rebate = 0;
            }
            else
            {
                if (amt <= 200)
                {
                    ret.EcashFee = 10;
                    ret.Rebate = 2.5;
                }
                else if (amt <= 1000)
                {
                    ret.EcashFee = 50;
                    ret.Rebate = 12.5;
                }
                else if (amt <= 2000)
                {
                    ret.EcashFee = 100;
                    ret.Rebate = 25;
                }
                else if (amt <= 5000)
                {
                    ret.EcashFee = 150;
                    ret.Rebate = 37.5;
                }
                else if (amt <= 40000)
                {
                    ret.EcashFee = 200;
                    ret.Rebate = 50;
                }
            }
            return ret;
        }
        private void txtRebate1_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = true;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtRebate2_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = true;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtRebate3_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = true;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void optCashIn_CheckedChanged(object sender, EventArgs e)
        {
            ComputeServiceFee(txtAmount1.Text);
        }

        private void optCashOut_CheckedChanged(object sender, EventArgs e)
        {
            ComputeServiceFee(txtAmount1.Text);
        }

        private void optSendOthers_CheckedChanged(object sender, EventArgs e)
        {
            ComputeServiceFee(txtAmount1.Text);
        }

        private void optCancelP2P_CheckedChanged(object sender, EventArgs e)
        {
            clsServiceFee fee = ComputeGCashremitFee(double.Parse(txtAmount3.Text));
            if (fee != null)
            {
                txtSvcFee3.Text = fee.EcashFee.ToString("n");
                txtRebate3.Text = fee.Rebate.ToString();
            }
            else
            {
                txtSvcFee3.Text = "0";
                txtRebate3.Text = "0";

            }
        }

        private void txtRecipientNum_TextChanged(object sender, EventArgs e)
        {
            txtGCashMobNum.Text = txtRecipientNum.Text;
        }

    }
}
