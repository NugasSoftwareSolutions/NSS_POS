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
    public partial class CashCount : Form
    {
        public double TotalAmount = 0;
        public CashCount()
        {
            InitializeComponent();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = ((TextBox)sender);
            string sname = txt.Name.Replace("txt", "");
            double val = 0;
            double denom = 0;
            if (sname != "25c")
                denom = Convert.ToInt32(sname);
            else
                denom = 0.25;
            try
            {
                val = Convert.ToDouble(txt.Text) * denom;
            }
            catch { }

            switch ((int)denom)
            {
                case 1000: lbl1000.Text = val.ToString("0.00"); break;
                case 500: lbl500.Text = val.ToString("0.00"); break;
                case 200: lbl200.Text = val.ToString("0.00"); break;
                case 100: lbl100.Text = val.ToString("0.00"); break;
                case 50: lbl50.Text = val.ToString("0.00"); break;
                case 20: lbl20.Text = val.ToString("0.00"); break;
                case 10: lbl10.Text = val.ToString("0.00"); break;
                case 5: lbl5.Text = val.ToString("0.00"); break;
                case 1: lbl1.Text = val.ToString("0.00"); break;
                default: lbl25c.Text = val.ToString("0.00"); break;
            }

            TotalAmount = Convert.ToDouble(lbl1000.Text) + Convert.ToDouble(lbl500.Text) + Convert.ToDouble(lbl200.Text) + Convert.ToDouble(lbl100.Text) + Convert.ToDouble(lbl50.Text) + Convert.ToDouble(lbl20.Text) + Convert.ToDouble(lbl10.Text) + Convert.ToDouble(lbl5.Text) + Convert.ToDouble(lbl1.Text) + Convert.ToDouble(lbl25c.Text);
            lblTotalAmount.Text = TotalAmount.ToString("0.00");
        }
        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            bool withDecimal = false;
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {

            }
            else
            {
                e.SuppressKeyPress = true;
            }

        }

        private void CashCount_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            this.DialogResult = System.Windows.Forms.DialogResult.None;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

    }
}
