using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlreySolutions.Class
{
    public partial class frmProgress : Form
    {
        private int val;
        private string caption;

        public string Caption
        {
            get { return caption; }
            set {
                lblCaption.Text = value;
                caption = value; }
        }

        public int Val
        {
            get { return val; }
            set {
                try { 
                    pbar.Value = value;
                    if(pbar.Value % 10 == 0)
                        this.Update();
                }
                catch{}
            val = value; }
        }
        private int maxval;

        public frmProgress(int max)
        {
            InitializeComponent();
            maxval = max;
            pbar.Maximum = max;
        }

        private void frmProgress_Load( object sender, EventArgs e )
        {
            Class.clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
        }
    }
}
