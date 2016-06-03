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
    public partial class frmRetrieve : Form
    {
        public Receipt myReceipt;
        public string TableNum
        {
            get { return txtTableNum.Text; }
            set { txtTableNum.Text = value.ToUpper(); }
        }
        public frmRetrieve()
        {
            InitializeComponent();
            myReceipt = null;
        }
        public void RetrieveReceipt()
        {
            dbConnect connect = new dbConnect();
            try
            {
                myReceipt = connect.RetrieveReceiptInfo(Int32.Parse(txtTableNum.Text.Trim())); 
            }
            catch { }
            finally
            {
                connect.Close();
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                txtTableNum.Text = txtTableNum.Text.ToUpper();
                RetrieveReceipt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnOk.PerformClick();
            }
        }

        private void radTable_CheckedChanged(object sender, EventArgs e)
        {
            txtTableNum.Focus();
            txtTableNum.SelectAll();
        }
    }
}
