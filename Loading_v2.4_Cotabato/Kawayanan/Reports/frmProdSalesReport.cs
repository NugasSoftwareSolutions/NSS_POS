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
    public partial class  frmProdSalesReport : Form
    {
        clsPurchasedItem m_ListPurchases = new clsPurchasedItem();
        double TotalAmount = 0;
        public frmProdSalesReport()
        {
            InitializeComponent();
        }

        private void SearchPurchases(DateTime startdate, DateTime enddate,string cashier)
        {
            Dictionary<string, clsPurchasedItem> dicPurchases = new Dictionary<string, clsPurchasedItem>();
            dbConnect con = new dbConnect();

            dicPurchases = con.GetProductSales(startdate, enddate, cashier);
            con.Close();
            dgvPurchase.Rows.Clear();
            AddItemToGrid(dicPurchases);
        }

        Dictionary<int, string> categories = null;
        private void UpdateCategories()
        {
            categories = dbConnect.GetCategories();
            cboCategory.Items.Clear();
            cboCategory.Items.Add("ALL");
            if (categories != null)
            {
                foreach (KeyValuePair<int, string> kv in categories)
                {
                    cboCategory.Items.Add(kv.Value);
                }
            }
            cboCategory.SelectedItem = "ALL";
        }

        private void AddItemToGrid(Dictionary<string,clsPurchasedItem> dicPurchases)
        {
            TotalAmount = 0;
            foreach (KeyValuePair<string, clsPurchasedItem> fitem in dicPurchases)
            {
                if (cboCategory.SelectedItem.ToString() == fitem.Value.Category || cboCategory.SelectedIndex == 0)
                {
                    int rowidx = dgvPurchase.Rows.Add();

                    dgvPurchase.Rows[rowidx].Cells[0].Value = fitem.Value.BarCode;
                    dgvPurchase.Rows[rowidx].Cells[1].Value = fitem.Value.Description;
                    dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.Value.Qty;
                    dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.Value.Amount * fitem.Value.Qty;
                    dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.Value.Category;
                    TotalAmount += fitem.Value.Amount * fitem.Value.Qty;
                }
            }

            lblItems.Text = "Total Items: " + dicPurchases.Count.ToString();
            lblTotalAmount.Text = "Total Amount: P " + TotalAmount.ToString("0.00");
        }


        private void dtPick_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickStart.Value >= dtPickEnd.Value) dtPickEnd.Value = dtPickStart.Value.AddDays(1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string cashier = "";
            SearchPurchases(dtPickStart.Value, dtPickEnd.Value,cashier);
        }

        private void dtPickEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickEnd.Value <= dtPickStart.Value) dtPickStart.Value = dtPickEnd.Value.AddDays(-1);
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            //cboCashier.Items.Add("All");
            //List<string> lstUsers = clsUsers.GetUserList();
            //foreach (string str in lstUsers)
            //{
            //    cboCashier.Items.Add(str);
            //}
            //cboCashier.SelectedIndex = 0;
            dtPickEnd.Value = dtPickStart.Value.AddDays(1);
            UpdateCategories();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                string columns="";
                foreach(DataGridViewColumn col in dgvPurchase.Columns)
                {
                    columns += col.HeaderText + (col!=dgvPurchase.Columns[dgvPurchase.Columns.Count-1]?"\t":"");
                }
                List<string> lstValues = new List<string>();
                frmProgress progress = new frmProgress(dgvPurchase.Rows.Count);
                progress.Caption = "Loading Data";
                progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                progress.Show();
                int ctr2 = 0;
                foreach(DataGridViewRow row in dgvPurchase.Rows)
                {
                    string val="";
                    for(int ctr=0;ctr<dgvPurchase.Columns.Count;ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr!=dgvPurchase.Columns.Count-1?"\t":"");
                    }
                    lstValues.Add(val);
                    progress.Val = ++ctr2;
                }
                progress.Close();
                export.SaveToExcelWithSummary(savedlg.FileName, columns, lstValues, "Total Items", string.Format("{0}", dgvPurchase.Rows.Count));
            }
        }

        private void dgvSenior_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmProdSalesReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
