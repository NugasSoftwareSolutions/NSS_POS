using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using License;
using AlreySolutions.Class;
namespace AlreySolutions
{
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtCompany.Text == "")
            {
                MessageBox.Show("Must enter a Company Name", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCompany.Focus();
                return;
            }
            if (POSLicense.ValidateLicense(txtLicenseCode.Text))
            {
                POSLicense.SetRegistryLicense(txtLicenseCode.Text);
                POSLicense.SetCompany(txtCompany.Text);
                MessageBox.Show("Product has been successfully registered.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid License Code", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseCode.Focus();
                txtLicenseCode.SelectAll();
            }
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            txtCompany.Text = POSLicense.GetRegistryValue("Company-POS System");
            txtRegCode.Text = POSLicense.GetRegistrationCode();
            txtLicenseCode.Text = POSLicense.GetRegistryValue("LicenseKey-POS System");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseInfo_FormClosing( object sender, FormClosingEventArgs e )
        {

        }

        private void subPan_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
