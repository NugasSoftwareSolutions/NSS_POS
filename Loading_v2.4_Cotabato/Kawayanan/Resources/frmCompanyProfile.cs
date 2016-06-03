using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using AlreySolutions.Class;

namespace AlreySolutions
{
    public partial class frmCompanyProfile : Form
    {
        private Profile myProfile = new Profile();

        public frmCompanyProfile()
        {
            InitializeComponent();
        }

        private void frmCompanyProfile_Load(object sender, EventArgs e)
        {
            myProfile.ReadXML();
            txtAddress.Text = myProfile.Address;
            txtCompanyName.Text = myProfile.Company;
            txtContactNo.Text = myProfile.ContactNum;
            txtTIN.Text = myProfile.TIN;
            chkPreview.Checked = myProfile.EnablePreview;
            chkAutoPrint.Checked = myProfile.EnableAutoPrint;
            chkPrint.Checked = myProfile.PrintReceipt;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            myProfile.Address = txtAddress.Text;
            myProfile.Company = txtCompanyName.Text;
            myProfile.ContactNum = txtContactNo.Text;
            myProfile.TIN = txtTIN.Text;
            myProfile.EnablePreview = chkPreview.Checked;
            myProfile.EnableAutoPrint = chkAutoPrint.Checked;
            myProfile.PrintReceipt = chkPrint.Checked;
            myProfile.SaveXML();
        }
    }
}
