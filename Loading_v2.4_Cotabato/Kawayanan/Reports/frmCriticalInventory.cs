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
    public partial class frmCriticalInventory : Form
    {
        clsPurchasedItem m_ListPurchases = new clsPurchasedItem();

        public frmCriticalInventory()
        {
            InitializeComponent();
        }

        private void SearchPurchases()
        {
            Dictionary<string,clsPurchasedItem> lstReceipt = new Dictionary<string,clsPurchasedItem>();
            dbConnect con = new dbConnect();

            dbConnect connect = new dbConnect();
            List<clsProductItem> lstProducts = new List<clsProductItem>();
            dgvPurchase.Rows.Clear();
            lstProducts = connect.SearchProductItems("");
            foreach (clsProductItem fi in lstProducts)
            {
                if (fi.StocksRemainingQty <= fi.CriticalLevel)
                {
                    AddItemToGrid(fi);
                }
            }
            connect.Close();

        }

        private void AddItemToGrid(clsProductItem fitem)
        {

            int rowidx = dgvPurchase.Rows.Add();
            dgvPurchase.Rows[rowidx].Cells[0].Value = fitem.BarCode;
            dgvPurchase.Rows[rowidx].Cells[1].Value = fitem.Description;
            dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.TotalInventoryQty;
             dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.CriticalLevel;
           dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.TotalInventoryQty - fitem.QtySold;

            //else
            //{
            //    dbConnect con = new dbConnect();
            //    Int32 ret  = con.GetSoldItems(fitem.BarCode);
            //    con.Close();
            //    dgvPurchase.Rows[rowidx].Cells[2].Value = ret;
            //    if (ret > 0)
            //    {
            //        fitem.QtySold = ret;
            //        fitem.Save();
            //    }
            //}
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPurchases();
        }


        private void frmInventory_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCriticalInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
