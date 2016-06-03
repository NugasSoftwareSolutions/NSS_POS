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
    public partial class frmAddInventory : Form
    {
        public bool Cancelled = false;
        private double _Quantity = 0;
        public double Quantity
        {
            get {
                return _Quantity; 
            }
            set { _Quantity = value; }
        }

        private double _Capital = 0;
        public double Capital
        {
            get
            {
                return _Capital;
            }
            set { _Capital = value; }
        }
        private double _Retail;

        public double Retail
        {
            get { return _Retail; }
            set { _Retail = value; }
        }

        public frmAddInventory()
        {

            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" || txtCapital.Text =="" || txtRetail.Text =="" )
                MessageBox.Show("Complete all details", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    Quantity = Convert.ToDouble(txtQuantity.Text);
                    Capital = Convert.ToDouble(txtCapital.Text);
                    Retail = Convert.ToDouble(txtRetail.Text);
                    this.Close();
                }
                catch (Exception er) { MessageBox.Show(er.Message); }
            }
        }


        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnOk.PerformClick();
                }
                else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                    || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Delete
                    || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                {

                }
                else
                {
                    e.SuppressKeyPress = true;
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            this.Close();
        }

        private void frmAddInventory_Load( object sender, EventArgs e )
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            txtQuantity.Text = Quantity.ToString();
            txtQuantity.SelectAll();
            txtCapital.Text = Capital.ToString();
            txtRetail.Text = Retail.ToString();
        }

        private void subPan_Paint( object sender, PaintEventArgs e )
        {

        }
    }
}
