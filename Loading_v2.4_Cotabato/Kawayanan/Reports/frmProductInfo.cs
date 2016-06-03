using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class;
using System.IO;

namespace AlreySolutions
{
    public partial class frmProductInfo : Form
    {
        public string mBarcode="";
        List<clsProductItem> lstFood = new List<clsProductItem>();
        public frmProductInfo()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetup_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            UpdateList();
        }

        private void UpdateList(string searchstr = "")
        {
            try
            {
                dbConnect connect = new dbConnect();
                List<clsProductItem> lstProducts = new List<clsProductItem>();
                //dgvPurchase.Rows.Clear();
                lstProducts = connect.SearchProductItems(searchstr);
                //foreach (clsProductItem fi in lstProducts)
                //{
                //    AddItemToGrid(fi);
                //}
                connect.Close();
                dgvPurchase.DataSource = lstProducts;
                dgvPurchase.AutoGenerateColumns = true;
            }
            catch { }
        }

        private void AddItemToGrid(clsProductItem fitem)
        {
            int rowidx = dgvPurchase.Rows.Add();
            dgvPurchase.Rows[rowidx].Cells[0].Value = fitem.BarCode;
            dgvPurchase.Rows[rowidx].Cells[1].Value = fitem.Description;
            dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.Capital;
            dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.Amount;
            dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.WSAmount;
            dgvPurchase.Rows[rowidx].Cells[5].Value = fitem.TotalInventoryQty-fitem.QtySold;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateList(txtSearchString.Text);
            txtSearchString.Text = "";
        }

        private void txtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvPurchase.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to export.", "Export To Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsExportToExcel export = new clsExportToExcel();
            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.Filter = "Excel File (*.xls)|*.xls";
            savedlg.InitialDirectory = Application.StartupPath;
            if (savedlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string columns = "";
                foreach (DataGridViewColumn col in dgvPurchase.Columns)
                {
                    columns += col.HeaderText + (col != dgvPurchase.Columns[dgvPurchase.Columns.Count - 1] ? "\t" : "");
                }
                List<string> lstValues = new List<string>();
                foreach (DataGridViewRow row in dgvPurchase.Rows)
                {
                    string val = "";
                    for (int ctr = 0; ctr < dgvPurchase.Columns.Count; ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr != dgvPurchase.Columns.Count - 1 ? "\t" : "");
                    }
                    lstValues.Add(val);
                }
                export.SaveToExcel(savedlg.FileName, columns, lstValues);
            }
        }

        private void frmStockInventory_Shown(object sender, EventArgs e)
        {
            txtSearchString.Focus();
        }

        private void frmProductInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
    