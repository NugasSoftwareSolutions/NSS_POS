using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlreySolutions
{
    public partial class frmQty : Form
    {
        public int Quantity;

        public frmQty()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Quantity = Convert.ToInt32(txtAmount.Text);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid Quantity", "Product Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAmount.SelectAll();
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            txtAmount.Text = Quantity.ToString("0");
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnOk.PerformClick();
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {

            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
