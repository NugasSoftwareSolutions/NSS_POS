using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class;

namespace AlreySolutions.Reports
{
    public partial class frmPurchaseSummary : Form
    {
        List<clsInventory> m_ListProdItems = null;

        public frmPurchaseSummary()
        {
            InitializeComponent();
            dtPickStart.Value = DateTime.Now;
            dtPickEnd.Value = DateTime.Now.AddDays(1);
        }

        private void SearchPurchases()
        {
            m_ListProdItems = new List<clsInventory>();
            dgvPurchase.Rows.Clear();
            List<clsInventory> lstInventory = clsInventory.GetPurchases(dtPickStart.Value, dtPickEnd.Value, txtRemarks.Text);
            double total = 0;
            foreach (clsInventory fi in lstInventory)
            {
                total += fi.Capital * fi.Quantity;
                AddItemToGrid(fi);
                m_ListProdItems.Add(fi);
            }
            lblTotalAmount.Text = string.Format("Total: P {0:0.00}", Math.Round( total,2));
        }
        private void AddItemToGrid(clsInventory fitem)
        {

            int rowidx = dgvPurchase.Rows.Add();
            dgvPurchase.Rows[rowidx].Cells[0].Value = fitem.DateAdded;
            dgvPurchase.Rows[rowidx].Cells[1].Value = fitem.BarCode;
            dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.Description;
            dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.Capital;
            dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.Quantity;
            dgvPurchase.Rows[rowidx].Cells[5].Value = Math.Round(fitem.Quantity * fitem.Capital,2);
            dgvPurchase.Rows[rowidx].Cells[6].Value = fitem.Remarks;

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

        private void frmInventory_FormClosing( object sender, FormClosingEventArgs e )
        {

        }


    }
}
