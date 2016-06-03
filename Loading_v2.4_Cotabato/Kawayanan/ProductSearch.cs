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
    public partial class ProductSearch : Form
    {
        public string Selected = "";
        public clsProductItem SelectedProduct = new clsProductItem();
        public bool close = false;
        public ProductSearch(string barcode="")
        {
            InitializeComponent();
            if (barcode != "")
            {
                UpdateList(barcode);
                txtSearchString.Text = barcode;
                if (barcode != "" && dgvPurchase.Rows.Count == 1)
                {
                    Selected = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
                    close = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Selected = "";
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void dgvPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvPurchase.SelectedRows.Count == 1)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Selected = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else if (e.KeyCode == Keys.Up && dgvPurchase.SelectedRows[0].Index == 0)
                {
                    txtSearchString.Focus();
                }
            }
        }

        private void dgvPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPurchase.SelectedRows.Count == 1)
            {
                Selected = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        private void UpdateList(string searchstr = "")
        {
            try
            {
                dbConnect connect = new dbConnect();
                List<clsProductItem> lstProducts = new List<clsProductItem>();
                dgvPurchase.Rows.Clear();
                lstProducts = connect.SearchProductItems(searchstr);
                foreach (clsProductItem fi in lstProducts)
                {
                    AddItemToGrid(fi);
                }
                connect.Close();
            }
            catch { }
        }
        private void AddItemToGrid(clsProductItem fitem)
        {
            int rowidx = dgvPurchase.Rows.Add();
            dgvPurchase.Rows[rowidx].Cells[0].Value = fitem.BarCode;
            dgvPurchase.Rows[rowidx].Cells[1].Value = fitem.Description;
            dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.Amount;
            dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.WSAmount;
            dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.StocksRemainingQty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateList(txtSearchString.Text.Trim());
            if (dgvPurchase.Rows.Count == 1)
            {
                Selected = dgvPurchase.Rows[0].Cells[0].Value.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void txtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgvPurchase.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
                if (dgvPurchase.Rows.Count == 1)
                {
                    Selected = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void ProductSearch_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            if (close)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void mainPan_Paint( object sender, PaintEventArgs e )
        {

        }

        private void ProductSearch_Activated( object sender, EventArgs e )
        {
            if (dgvPurchase.Rows.Count > 0) dgvPurchase.Focus();
        }
    }
}
