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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load( object sender, EventArgs e )
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            LoadSettings();
        }

        private void LoadSettings()
        {
            txtCompanyName.Text = Properties.Settings.Default.Company;
            txtAdd1.Text = Properties.Settings.Default.Address1;
            txtAdd2.Text = Properties.Settings.Default.Address2;
            txtContact.Text = Properties.Settings.Default.ContactNum;
            txtTIN.Text = Properties.Settings.Default.TIN;
            chkPrintTin.Checked = Properties.Settings.Default.PrintTIN;
            txtMsg1.Text = Properties.Settings.Default.Message1;
            txtMsg2.Text = Properties.Settings.Default.Message2;
            txtMsg3.Text = Properties.Settings.Default.Message3;
            chkPrintMsg.Checked = Properties.Settings.Default.PrintMessage;
            txtVatPerCent.Text = Properties.Settings.Default.VatPercentage.ToString();
            chkPrintVat.Checked = Properties.Settings.Default.PrintVat;
            chkPrintDup.Checked = Properties.Settings.Default.PrintDuplicate;
            txtMaxDisc.Text = Properties.Settings.Default.MaxPercentDiscount.ToString();
            txtInterest.Text = Properties.Settings.Default.InterestRate.ToString();
            chkPrintBarcode.Checked = Properties.Settings.Default.PrintORBarcode;
            chkRequireCust.Checked = Properties.Settings.Default.RequireCustomerName;
            txtConString.Text = Properties.Settings.Default.dbConnectionString1;
            txtBackup.Text = Properties.Settings.Default.BackupPath;
            chkPreview.Checked = Properties.Settings.Default.ShowReceipt;
            chkConfirmPrint.Checked = Properties.Settings.Default.ConfirmPrint;
            chkPrintReceipt.Checked = Properties.Settings.Default.EnablePrint;
            
        }

        private void SaveSettings()
        {
            try
            {
                Properties.Settings.Default.Company = txtCompanyName.Text;
                Properties.Settings.Default.Address1 = txtAdd1.Text;
                Properties.Settings.Default.Address2 = txtAdd2.Text;
                Properties.Settings.Default.ContactNum = txtContact.Text;
                Properties.Settings.Default.TIN = txtTIN.Text;
                Properties.Settings.Default.PrintTIN = chkPrintTin.Checked;
                Properties.Settings.Default.Message1 = txtMsg1.Text;
                Properties.Settings.Default.Message2 = txtMsg2.Text;
                Properties.Settings.Default.Message3 = txtMsg3.Text;
                Properties.Settings.Default.PrintMessage = chkPrintMsg.Checked;
                Properties.Settings.Default.VatPercentage = Convert.ToInt16(txtVatPerCent.Text);
                Properties.Settings.Default.PrintVat = chkPrintVat.Checked;
                Properties.Settings.Default.MaxPercentDiscount = Convert.ToInt16(txtMaxDisc.Text);
                Properties.Settings.Default.InterestRate = Convert.ToDouble(txtInterest.Text);
                Properties.Settings.Default.PrintORBarcode = chkPrintBarcode.Checked;
                Properties.Settings.Default.RequireCustomerName = chkRequireCust.Checked;
                Properties.Settings.Default.PrintDuplicate = chkPrintDup.Checked;
                Properties.Settings.Default.dbConnectionString1 = txtConString.Text;
                Properties.Settings.Default.ShowReceipt = chkPreview.Checked;
                Properties.Settings.Default.EnablePrint = chkPrintReceipt.Checked;
                Properties.Settings.Default.ConfirmPrint = chkConfirmPrint.Checked;
                if (System.IO.Directory.Exists(txtBackup.Text))
                {
                    Properties.Settings.Default.BackupPath = txtBackup.Text;
                }
                Properties.Settings.Default.Save();
                MessageBox.Show("Settings successfully saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            SaveSettings();
        }

        private void btnBrowse_Click( object sender, EventArgs e )
        {
            if (txtBackup.Text != "") folderBrowserDialog1.SelectedPath = txtBackup.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackup.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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
