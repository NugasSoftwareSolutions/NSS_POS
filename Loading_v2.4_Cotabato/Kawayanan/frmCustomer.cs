using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;

namespace Kawayanan
{
    public partial class frmCustomer : Form
    {
        public string TableNum;
        public frmCustomer()
        {
            InitializeComponent();
            TableNum = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void txtTableNum_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtTableNum.SelectAll();
                e.SuppressKeyPress = true;
                if (txtTableNum.Text.Trim() != "")
                {
                    TableNum = txtTableNum.Text;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No Table Number Selected");
                    txtTableNum.Text = "Take-Out";
                }
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            txtTableNum.Text = "Take-Out";
            txtTableNum.Focus();
            txtTableNum.SelectAll();
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TableNum = txtTableNum.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TableNum = txtTableNum.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void txtTableNum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
