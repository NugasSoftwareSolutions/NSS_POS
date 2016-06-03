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
    public partial class frmDiscount : Form
    {
        public int SelectedIndex = 0;
        public string SelectedValue = "";
        public frmDiscount()
        {
            InitializeComponent();
        }

        private void lstDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectedIndex = lstDiscount.SelectedIndex;
                SelectedValue = lstDiscount.SelectedItem.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                SelectedIndex = -1;
                SelectedValue = "";
                this.Close();
            }
        }

        private void frmDiscount_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            lstDiscount.Focus();
            lstDiscount.SelectedIndex = 0;
        }

        private void lstDiscount_DoubleClick(object sender, EventArgs e)
        {
            SelectedIndex = lstDiscount.SelectedIndex;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void lstDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
