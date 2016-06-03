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
    public partial class frmLoadWalletTrans : Form
    {
        clsLoadAccount m_LoadAccount = null;

        public frmLoadWalletTrans(clsLoadAccount act)
        {
            InitializeComponent();
            m_LoadAccount = clsLoadAccount.GetLoadAccount(act.LoadId);
        }

        private void frmLoadWalletTrans_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            RefreshAccount();
            Clear();
        }

        private void txtMobileNum_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = false;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = true;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtAmtDue_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = true;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtDisCount_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = true;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtDisCount_TextChanged(object sender, EventArgs e)
        {
            ComputeDiscountedAmount();
        }
        private void ComputeDiscountedAmount()
        {
            try
            {
                if (txtLoadAmount.Text != "")
                {
                    double loadAmt = double.Parse(txtLoadAmount.Text);
                    double disc = loadAmt * (double.Parse(txtDisCount.Text) / 100);
                    txtAmtDue.Text = string.Format("{0:n}", loadAmt - disc);
                }
            }
            catch { }
        }
        private bool ValidateInput()
        {
            if (txtMobileNum.Text == "" || txtAmtDue.Text == "")
            {
                MessageBox.Show("Kindly fill-out required fields", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void RefreshAccount()
        {
            ctrlLoadAccount1.Description = m_LoadAccount.Description;
            ctrlLoadAccount1.LoadType = m_LoadAccount.LoadType;
            ctrlLoadAccount1.LoadId = m_LoadAccount.LoadId;
            lblAvailableBal.Text = string.Format("Available Balance : {0:n}", m_LoadAccount.AvailableBalance);

            m_LoadAccount.LstServiceFees = clsServiceFee.GetServiceFees(m_LoadAccount.LoadId);
            if (m_LoadAccount.ImgFile != null)
            {
                MemoryStream mem = new MemoryStream(m_LoadAccount.ImgFile);
                ctrlLoadAccount1.Picture = Image.FromStream(mem);
                mem.Close();
            }
            else
            {
                ctrlLoadAccount1.Picture = null;
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                clsSubDAccount subd = clsSubDAccount.GetSubDAccount(txtMobileNum.Text);
                
                clsLoadWalletTransaction wallet = new clsLoadWalletTransaction();
                wallet.Load_Id = m_LoadAccount.LoadId;
                wallet.UserId = myPosWide.m_user.UserId;
                wallet.SubDId = subd != null ? subd.Id_subdAccounts : 0;
                wallet.Timestamp = DateTime.Now;
                wallet.LoadAmount = double.Parse(txtLoadAmount.Text);
                wallet.MobileNum = txtMobileNum.Text;
                wallet.DiscountPercentage = double.Parse(txtDisCount.Text);
                wallet.AmtDue = double.Parse(txtAmtDue.Text);
                
                frmInput input = new frmInput();
                double amountdue = wallet.AmtDue;
                input.Title = "Payment";
                input.Value = amountdue.ToString("0.00");
                input.Caption = "Enter Tendered Amount";

                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (Convert.ToDouble(input.Value) >= amountdue)
                    {
                        wallet.TenderedAmount = Convert.ToDouble(input.Value);
                        if (wallet.Save())
                        {
                            Clear();
                            m_LoadAccount = clsLoadAccount.GetLoadAccount(m_LoadAccount.LoadId);
                            wallet.PrintReceipt();
                            RefreshAccount();
                        }
                        else
                        {
                            MessageBox.Show("Transaction not saved.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Amount entered is less than the Amount Due. Charge to Sub-D Account?", "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                        {
                            wallet.TenderedAmount = Convert.ToDouble(input.Value);
                            if (wallet.Save())
                            {
                                Clear();
                                m_LoadAccount = clsLoadAccount.GetLoadAccount(m_LoadAccount.LoadId);
                                wallet.PrintReceipt();
                                RefreshAccount();
                            }
                            else
                            {
                                MessageBox.Show("Transaction not saved.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }
        private void Clear()
        {
            
            txtDisCount.Text = Properties.Settings.Default.LoadWalletDiscount.ToString();
            txtLoadAmount.Text = "";
            txtAmtDue.Text = "";
            txtMobileNum.Text = "";
            txtCustomer.Text = "";
            lblBalance.Text = "Account Balance: 0.00";
            txtCustomer.Focus();

        }
        private void txtLoadAmount_TextChanged(object sender, EventArgs e)
        {
            ComputeDiscountedAmount();
        }

        private void btnRetailer_Click(object sender, EventArgs e)
        {
            this.Close();
            frmELoadTrans frmEload = new frmELoadTrans(m_LoadAccount);
            frmLoadMenu.LoadMenuForm(frmEload);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSelectCustomer sel = new frmSelectCustomer(m_LoadAccount, txtCustomer.Text.Trim());
            if (sel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clsSubDAccount subd = sel.SelectedAccount;
                if (subd != null)
                {
                    txtCustomer.Text = subd.Name;
                    txtMobileNum.Text = subd.MobileNum;
                    txtDisCount.Text = subd.Discount.ToString();
                    lblBalance.Text = "Account Balance: " + subd.Balance.ToString("n");
                    txtLoadAmount.Focus();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
