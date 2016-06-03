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
    public partial class frmWholeSaleUnit : Form
    {
        public int SelectedIndex = 0;
        public string SelectedValue = "1";
        public frmWholeSaleUnit()
        {
            InitializeComponent();
        }

        private void lstDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectedIndex = lstDiscount.SelectedIndex;
                GetVal();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                SelectedIndex = -1;
                SelectedValue = "1";
                this.Close();
            }
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            lstDiscount.Focus();
            lstDiscount.SelectedIndex = 0;
        }

        private void lstDiscount_DoubleClick(object sender, EventArgs e)
        {
            SelectedIndex = lstDiscount.SelectedIndex;
            GetVal();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void GetVal()
        {
            switch (SelectedIndex)
            {
                case 0: SelectedValue = "1"; break;
                case 1: SelectedValue = "10"; break;
                case 2: SelectedValue = "20"; break;
                case 3: SelectedValue = "6"; break;
                case 4: SelectedValue = "12"; break;
                case 5: SelectedValue = "24"; break;
            }
        }

        private void lstDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
