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
    public partial class frmELoadTrans : Form
    {
        clsLoadAccount m_LoadAccount = null;

        public frmELoadTrans(clsLoadAccount act)
        {
            InitializeComponent();
            m_LoadAccount = clsLoadAccount.GetLoadAccount(act.LoadId);
            m_LoadAccount.LstServiceFees = clsServiceFee.GetServiceFees(m_LoadAccount.LoadId);
        }

        private void frmELoadTrans_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            RefreshAccount();
            if (m_LoadAccount.Description.ToLower().Contains("globe"))
            {
                txtLoadAmount.Visible = true;
                cmbLoadAmt.Visible = false;
            }
            else
            {
                txtLoadAmount.Visible = false;
                cmbLoadAmt.Visible = true;
            }
        }

        private void LoadAmount()
        {
            //cmbLoadAmt.Items.Clear();
            if (m_LoadAccount.LstServiceFees.Count > 0)
            {
                cmbLoadAmt.DataSource = m_LoadAccount.LstServiceFees;
                cmbLoadAmt.DisplayMember = "Remarks";
                cmbLoadAmt.ValueMember = "ServiceFeeID";
            }
            cmbLoadAmt.SelectedIndex = -1;
            Clear();
        }

        private void cmbLoadAmt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_LoadAccount.LstServiceFees.Count > 0)
                {
                    clsServiceFee svc = m_LoadAccount.LstServiceFees.Find(x => x.ServiceFeeID == (int)cmbLoadAmt.SelectedValue);
                    if (svc != null)
                    {
                        txtAmtDue.Text = svc.EcashFee.ToString("n");
                        txtRebate.Text = svc.Rebate.ToString("n");
                        txtTransAmount.Text = svc.AmountTo.ToString("n");
                    }
                }
            }
            catch { }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                clsEloadTransaction eload = new clsEloadTransaction();
                eload.Load_Id = m_LoadAccount.LoadId;
                eload.Timestamp = DateTime.Now;
                eload.AmountDue = double.Parse(txtAmtDue.Text.Trim());
                eload.Rebate = double.Parse(txtRebate.Text.Trim());
                eload.Transaction_Amount = double.Parse(txtTransAmount.Text);
                eload.MobileNum = txtMobile.Text;
                eload.ELoadName = cmbLoadAmt.Text;
                eload.UserId = myPosWide.m_user.UserId;
                eload.Remarks = cmbLoadAmt.Text;
                frmInput input = new frmInput();
                double amountdue = eload.AmountDue;
                input.Title = "Payment";
                input.Value = amountdue.ToString("0.00");
                input.Caption = "Enter Tendered Amount";

                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (Convert.ToDouble(input.Value) >= amountdue)
                    {
                        eload.TenderedAmount = Convert.ToDouble(input.Value);
                        if (eload.Save())
                        {
                            Clear();
                            m_LoadAccount = clsLoadAccount.GetLoadAccount(m_LoadAccount.LoadId);
                            eload.PrintReceipt();
                            RefreshAccount();
                            
                        }
                        else
                        {
                            MessageBox.Show("Transaction not saved.", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Amount entered is less than the Amount Due", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void Clear()
        {
            txtMobile.Text = "";
            txtAmtDue.Text = "";
            txtRebate.Text = "";
            txtTransAmount.Text = "";
        }
        private void RefreshAccount()
        {
            ctrlLoadAccount1.Description = m_LoadAccount.Description;
            ctrlLoadAccount1.LoadType = m_LoadAccount.LoadType;
            ctrlLoadAccount1.LoadId = m_LoadAccount.LoadId;
            lblAvailableBal.Text = string.Format("Available Balance : {0:n}", m_LoadAccount.AvailableBalance);

            m_LoadAccount.LstServiceFees = clsServiceFee.GetServiceFees(m_LoadAccount.LoadId);            
            LoadAmount();
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
        private bool ValidateInput()
        {
            if (txtMobile.Text == "" || txtAmtDue.Text == ""){
                MessageBox.Show("Kindly fill-out required fields", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = false;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtLoadAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmtDue.Text = txtLoadAmount.Text;
                txtTransAmount.Text = string.Format("{0}", txtLoadAmount.Text);
                txtRebate.Text = string.Format("{0}", double.Parse(txtLoadAmount.Text) < 50 ? double.Parse(txtLoadAmount.Text) * 0.045 : double.Parse(txtLoadAmount.Text) * 0.046);
            }
            catch
            {
                txtAmtDue.Text = "0";
                txtTransAmount.Text = "0";
                txtRebate.Text = "0";
            }
        }

        private void txtLoadAmount_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = true;
            if (!(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                e.SuppressKeyPress = true;
            }
        } 
    }
}
