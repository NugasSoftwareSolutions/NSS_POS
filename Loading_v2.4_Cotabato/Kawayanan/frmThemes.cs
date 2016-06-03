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
    public partial class frmThemes : Form
    {
        public frmThemes()
        {
            InitializeComponent();
        }

        private void btnBBC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBBC.Text = colorDialog1.Color.ToArgb().ToString();
                txtBBC.BackColor = Color.FromArgb(Convert.ToInt32(txtBBC.Text));
            }
        }

        private void btnBFC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBFC.Text = colorDialog1.Color.ToArgb().ToString();
                txtBFC.BackColor = Color.FromArgb(Convert.ToInt32(txtBFC.Text));
            }
        }

        private void btnFBC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFBC.Text = colorDialog1.Color.ToArgb().ToString();
                txtFBC.BackColor = Color.FromArgb(Convert.ToInt32(txtFBC.Text));
            }
        }

        private void btnFFC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFFC.Text = colorDialog1.Color.ToArgb().ToString();
                txtFFC.BackColor = Color.FromArgb(Convert.ToInt32(txtFFC.Text));
            }
        }

        private void btnPBC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPBC.Text = colorDialog1.Color.ToArgb().ToString();
                txtPBC.BackColor = Color.FromArgb(Convert.ToInt32(txtPBC.Text));
            }
        }

        private void btnPFC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPFC.Text = colorDialog1.Color.ToArgb().ToString();
                txtPFC.BackColor = Color.FromArgb(Convert.ToInt32(txtPFC.Text));
            }
        }

        private void btnSPBC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSPBC.Text = colorDialog1.Color.ToArgb().ToString();
                txtSPBC.BackColor = Color.FromArgb(Convert.ToInt32(txtSPBC.Text));
            }
        }

        private void btnSPFC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSPFC.Text = colorDialog1.Color.ToArgb().ToString();
                txtSPFC.BackColor = Color.FromArgb(Convert.ToInt32(txtSPFC.Text));
            }
        }

        private void btnTBC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtTBC.Text = colorDialog1.Color.ToArgb().ToString();
                txtTBC.BackColor = Color.FromArgb(Convert.ToInt32(txtTBC.Text));
            }
        }

        private void btnTFC_Click( object sender, EventArgs e )
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtTFC.Text = colorDialog1.Color.ToArgb().ToString();
                txtTFC.BackColor = Color.FromArgb(Convert.ToInt32(txtTFC.Text));
            }
        }

        private void btnApplyTheme_Click( object sender, EventArgs e )
        {
            clsThemes.ThemeSettings settings = new clsThemes.ThemeSettings();
            settings.btnColor = Color.FromArgb(Convert.ToInt32(txtBBC.Text));
            settings.btnFont = Color.FromArgb(Convert.ToInt32(txtBFC.Text));
            settings.MainFormColor = Color.FromArgb(Convert.ToInt32(txtFBC.Text));
            settings.MainFontColor = Color.FromArgb(Convert.ToInt32(txtFFC.Text));
            settings.PanColor = Color.FromArgb(Convert.ToInt32(txtPBC.Text));
            settings.PanFontColor = Color.FromArgb(Convert.ToInt32(txtPFC.Text));
            settings.SubPanColor = Color.FromArgb(Convert.ToInt32(txtSPBC.Text));
            settings.SubPanFontColor = Color.FromArgb(Convert.ToInt32(txtSPFC.Text));
            settings.TextBackColor = Color.FromArgb(Convert.ToInt32(txtTBC.Text));
            settings.TextFontColor = Color.FromArgb(Convert.ToInt32(txtTFC.Text));
            clsThemes.ThemeSettings.ApplyThemeSettings(cboTheme.SelectedIndex, settings);
            clsThemes.ApplyTheme(this, settings);
        }

        private void cboTheme_SelectedIndexChanged( object sender, EventArgs e )
        {
            clsThemes.ThemeSettings settings = new clsThemes.ThemeSettings(cboTheme.SelectedIndex);
            txtBBC.BackColor = settings.btnColor;
            txtBFC.BackColor = settings.btnFont;
            txtFBC.BackColor = settings.MainFormColor;
            txtFFC.BackColor = settings.MainFontColor;
            txtPBC.BackColor = settings.PanColor;
            txtPFC.BackColor = settings.PanFontColor;
            txtSPBC.BackColor = settings.SubPanColor;
            txtSPFC.BackColor = settings.SubPanFontColor;
            txtTBC.BackColor = settings.TextBackColor;
            txtTFC.BackColor = settings.TextFontColor;

            txtBBC.Text = settings.btnColor.ToArgb().ToString();
            txtBFC.Text = settings.btnFont.ToArgb().ToString();
            txtFBC.Text = settings.MainFormColor.ToArgb().ToString();
            txtFFC.Text = settings.MainFontColor.ToArgb().ToString();
            txtPBC.Text = settings.PanColor.ToArgb().ToString();
            txtPFC.Text = settings.PanFontColor.ToArgb().ToString();
            txtSPBC.Text = settings.SubPanColor.ToArgb().ToString();
            txtSPFC.Text = settings.SubPanFontColor.ToArgb().ToString();
            txtTBC.Text = settings.TextBackColor.ToArgb().ToString();
            txtTFC.Text = settings.TextFontColor.ToArgb().ToString();
            btnApplyTheme.PerformClick();
        }

        private void frmThemes_Load( object sender, EventArgs e )
        {
            cboTheme.SelectedIndex = Properties.Settings.Default.Theme;
        }
    }
}
