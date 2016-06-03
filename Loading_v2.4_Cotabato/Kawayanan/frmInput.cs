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
    public partial class frmInput : Form
    {
        private string _Value = "";
        public string Value
        {
            get {
                if (IsNumericOnly && _Value == "") return "0";
                return _Value; 
            }
            set { _Value = value; }
        }
        public bool IsNumericOnly=false;
        public bool withDecimal = true;
        public bool IsHiddenInput
        {
            get { return txtInput.UseSystemPasswordChar; }
            set { txtInput.UseSystemPasswordChar = value; }
        }
        public string Caption
        {
            get { return lblCaption.Text; }
            set { lblCaption.Text = value; }
        }

        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public frmInput()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtInput.Text == "")
                MessageBox.Show(string.Format("{0} must have a value.", Caption), Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else    
            {
                try
                {
                    Value = txtInput.Text;
                     this.Close();
                }
                catch (Exception er) { MessageBox.Show(er.Message); }
            }
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            txtInput.Text = Value;
            txtInput.SelectAll();
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsNumericOnly)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    btnOk.PerformClick();
                }
                else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                    || (withDecimal && e.KeyCode == Keys.OemPeriod) || (withDecimal && e.KeyCode == Keys.Decimal ) || e.KeyCode == Keys.Delete
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
}
