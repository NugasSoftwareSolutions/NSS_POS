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
    public partial class CloseDrawer : Form
    {
        public double Change
        {
            set { this.lblChange.Text = string.Format("Change Amount: P {0:0.00}", value); }
        }
        public CloseDrawer()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void CloseDrawer_Load(object sender, EventArgs e)
        {
            Class.clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
        }
    }
}
