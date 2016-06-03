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
    public partial class frmInventory : Form
    {
        List<clsProductItem> m_ListProdItems = null;
        string m_username = "";
        public frmInventory(string username)
        {
            InitializeComponent();
            m_username = username;
        }

        private void SearchPurchases()
        {
            Dictionary<string,clsPurchasedItem> lstReceipt = new Dictionary<string,clsPurchasedItem>();
            dbConnect connect = new dbConnect();
            List<clsProductItem> lstProducts = new List<clsProductItem>();
            dgvPurchase.Rows.Clear();
            lstProducts = connect.SearchProductItemsAsOf("",dtDate.Value);
            m_ListProdItems = new List<clsProductItem>();
            foreach (clsProductItem fi in lstProducts)
            {
                AddItemToGrid(fi);
                m_ListProdItems.Add(fi);
            }
            connect.Close();

        }
        private void CalibrateProductItems()
        {
            Dictionary<string, clsPurchasedItem> lstReceipt = new Dictionary<string, clsPurchasedItem>();
            dbConnect connect = new dbConnect();
            List<clsProductItem> lstProducts = new List<clsProductItem>();
            dgvPurchase.Rows.Clear();
            lstProducts = connect.SearchProductItems("");
            m_ListProdItems = new List<clsProductItem>();
            foreach (clsProductItem fi in lstProducts)
            {
                bool saveitem = false;
                double totInventory = clsInventory.GetTotalInventoryQty(fi.BarCode);
                if (fi.TotalInventoryQty != totInventory)
                {
                    fi.TotalInventoryQty = totInventory;
                    saveitem = true;
                }
                double qtySold = clsPurchasedItem.GetTotalQtySold(fi.BarCode);
                if (fi.QtySold != qtySold)
                {
                    fi.QtySold = qtySold;
                    saveitem = true;
                }
                if (fi.StocksRemainingQty < 0 && Properties.Settings.Default.AddInvCalibrate)
                {
                    clsInventory itemIventory = new clsInventory();
                    itemIventory.BarCode = fi.BarCode;
                    itemIventory.Capital = fi.Capital;
                    itemIventory.Quantity = Math.Abs(fi.StocksRemainingQty);
                    //itemIventory.Remarks = "Calibrate Inventory";
                    itemIventory.Remarks = string.Format("(Calibrate){0}: TotInv={1} + {2}", m_username, fi.StocksRemainingQty, itemIventory.Quantity);

                    itemIventory.Save();
                    fi.TotalInventoryQty += itemIventory.Quantity;
                    saveitem = true;
                }
                if(saveitem) fi.Save();
                AddItemToGrid(fi);
                m_ListProdItems.Add(fi);
            }
            connect.Close();

        }
        private void AddItemToGrid(clsProductItem fitem)
        {

            int rowidx = dgvPurchase.Rows.Add();
            dgvPurchase.Rows[rowidx].Cells[0].Value = fitem.BarCode;
            dgvPurchase.Rows[rowidx].Cells[1].Value = fitem.Description;
            dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.Capital;
            dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.Amount;
            dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.WSAmount;
            dgvPurchase.Rows[rowidx].Cells[5].Value = fitem.Category;
            dgvPurchase.Rows[rowidx].Cells[6].Value = fitem.TotalInventoryQty;
            dgvPurchase.Rows[rowidx].Cells[7].Value = fitem.QtySold;
            dgvPurchase.Rows[rowidx].Cells[8].Value = fitem.TotalInventoryQty - fitem.QtySold;
            dgvPurchase.Rows[rowidx].Cells[9].Value = fitem.TotalInventoryQty - fitem.QtySold;
            dgvPurchase.Rows[rowidx].Cells[10].Value = string.Format("=J{0}-I{0}",rowidx+2);

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
            savedlg.FileName = "Inventory as of " + dtDate.Value.Date.ToString("yyyy-MM-dd");
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
                export.SaveToExcel(savedlg.FileName, columns, lstValues,dtDate.Value.Date.ToString("yyyy-MM-dd"));
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

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            UpdateInventory();
        }
        private bool UpdateInventory()
        {
            try
            {
                if(m_ListProdItems!=null)
                {
                    clsExportToExcel import = new clsExportToExcel();
                    OpenFileDialog opendlg = new OpenFileDialog();
                    opendlg.Filter = "Excel File (*.xls)|*.xls";
                    opendlg.InitialDirectory = Application.StartupPath;
                    if (opendlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        import.UpdateInventory(opendlg.FileName, m_ListProdItems,m_username);
                        SearchPurchases();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will update Total inventory Qty and Qty Sold, are you sure you want to continue?", "Calibrate Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                CalibrateProductItems();
                MessageBox.Show("Done calibrating");
            }
        }

        private void frmInventory_FormClosing( object sender, FormClosingEventArgs e )
        {
            e.Cancel = true;
            this.Hide();
        }

        private string GetReportDir( string ReportName )
        {
            string appFolderPath = System.AppDomain.CurrentDomain.BaseDirectory;
            //appFolderPath = appFolderPath);
            
            return appFolderPath + string.Format(@"Reports\{0}.rpt", ReportName);
        }

    }
}
