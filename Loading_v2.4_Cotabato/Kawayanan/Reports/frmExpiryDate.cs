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
    public partial class frmExpiryDate : Form
    {
        clsPurchasedItem m_ListPurchases = new clsPurchasedItem();

        public frmExpiryDate()
        {
            InitializeComponent();
        }

        private void SearchExpiredItems(int OffsetDays)
        {
            dgvInventoryHistory.Rows.Clear();
            List<clsInventory> m_ListInventory = clsInventory.lstInventory("").OrderBy(x => x.ExpiryDate).ToList();
            foreach (clsInventory inventory in m_ListInventory)
            {
                if (Math.Abs((inventory.ExpiryDate.Date - DateTime.Today).TotalDays) <= OffsetDays && inventory.Quantity > 0)
                {
                    switch (cboFilter.SelectedIndex)
                    {
                        case 0:
                            if ((inventory.ExpiryDate.Date - DateTime.Today).TotalDays <= 0)
                            {
                                AddIventoryToGrid(inventory); 
                            }
                            break;
                        case 1:
                            if ((inventory.ExpiryDate.Date - DateTime.Today).TotalDays > 0)
                            {
                                AddIventoryToGrid(inventory); 
                            }
                            break;
                        case 2: AddIventoryToGrid(inventory); break;
                    }
                }
            }
        }
        private void AddIventoryToGrid(clsInventory inventory)
        {
            int rowidx = dgvInventoryHistory.Rows.Add();
            dgvInventoryHistory.Rows[rowidx].Cells[0].Value = inventory.BarCode;
            dgvInventoryHistory.Rows[rowidx].Cells[1].Value = inventory.Description;
            dgvInventoryHistory.Rows[rowidx].Cells[2].Value = inventory.DateAdded;
            dgvInventoryHistory.Rows[rowidx].Cells[3].Value = inventory.Quantity;
            dgvInventoryHistory.Rows[rowidx].Cells[4].Value = inventory.ExpiryDate.ToString("yyyy-MM-dd");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvInventoryHistory.Rows.Count == 0)
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
                foreach (DataGridViewColumn col in dgvInventoryHistory.Columns)
                {
                    columns += col.HeaderText + (col != dgvInventoryHistory.Columns[dgvInventoryHistory.Columns.Count - 1] ? "\t" : "");
                }
                List<string> lstValues = new List<string>();
                foreach (DataGridViewRow row in dgvInventoryHistory.Rows)
                {
                    string val = "";
                    for (int ctr = 0; ctr < dgvInventoryHistory.Columns.Count; ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr != dgvInventoryHistory.Columns.Count - 1 ? "\t" : "");
                    }
                    lstValues.Add(val);
                }
                export.SaveToExcel(savedlg.FileName, columns, lstValues);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int days = 30;
            try
            {
                days = Convert.ToInt16(cboDays.SelectedItem);
            }
            catch
            {

            }
            SearchExpiredItems(days);
        }


        private void frmInventory_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            cboDays.Items.Clear();
            for (int ctr = 1; ctr <= 31; ctr++)
            {
                cboDays.Items.Add(ctr);
            }
            cboDays.SelectedItem = 30;
            cboFilter.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExpiryDate_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
