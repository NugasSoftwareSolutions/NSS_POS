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
    public partial class frmSetup : Form
    {
        public string mBarcode="";
        private clsUsers m_User = null;
        List<clsProductItem> lstFood = new List<clsProductItem>();
        public frmSetup(clsUsers user)
        {
            m_User = user;
            InitializeComponent();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDesc.Focus();
                txtDesc.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        private void txtValidateValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                switch (((TextBox)sender).Name)
                {
                    case "txtCapital": txtAmount.Focus(); txtAmount.SelectAll(); break;
                    case "txtAmount": txtWSAmount.Text = txtAmount.Text; txtWSAmount.Focus(); txtWSAmount.SelectAll(); break;
                    //case "txtWSAmount": txtTotalQty.Focus(); txtTotalQty.SelectAll(); break;
                    case "txtWSAmount": txtCriticalLevel.Focus(); txtCriticalLevel.SelectAll(); break;
                    case "txtCriticalLevel": cboUnit.Focus(); break;
                }
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9 || e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {

            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
        private void ClearFields(bool excludebarcode=false)
        {
            if(!excludebarcode)
                txtBarcode.Text = "";
            

            txtAmount.Text = "0";
            txtDesc.Text = "";
            txtWSAmount.Text = "0";
            txtImagePath.Text = "";
            txtTotalQty.Text = "0";
            txtCapital.Text = "0";
            txtCriticalLevel.Text = "2";
            cboUnit.SelectedIndex = 0;
            dgvInventoryHistory.Rows.Clear();
            m_ListInventory.Clear();
            if(cboCategory.Items.Count>0)
                cboCategory.SelectedIndex = 0;
            labelItemsRemaining.Text = "0";
            //txtDesc.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetup_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            UpdateList();
            UpdateCategories();

            ClearFields();
            if (mBarcode != "")
            {
                txtBarcode.Text = mBarcode;
                txtDesc.Focus();
            }

            SelectItemFromGrid(mBarcode);
            openDlg.InitialDirectory = Application.StartupPath + "\\images";
        }
        Dictionary<int, string> categories = null;
        private void UpdateCategories()
        {
            categories = dbConnect.GetCategories();
            cboCategory.Items.Clear();
            if (categories != null)
            {
                foreach (KeyValuePair<int, string> kv in categories)
                {
                    cboCategory.Items.Add(kv.Value);
                }
            }
            cboCategory.SelectedItem = "GROCERY";
        }

        private void UpdateList(string searchstr="")
        {
            try
            {
                if (chkDontDisplay.Checked == true && searchstr=="") return;
                List<clsProductItem> lstProducts = clsProductItem.SearchProductItems(searchstr);

                dgvItemList.Rows.Clear();
                foreach (clsProductItem fi in lstProducts)
                {
                    AddItemToGrid(fi);
                }
                //dgvItemList.AutoGenerateColumns = true;
                //dgvItemList.DataSource = lstProducts;

            }
            catch { }
        }
        private void SelectItemFromGrid(string barcode)
        {
            for (int ctr = 0; ctr < dgvItemList.Rows.Count; ctr++)
            {
                if (dgvItemList.Rows[ctr].Cells[0].Value.ToString() == barcode)
                {
                    dgvItemList.ClearSelection();
                    dgvItemList.Rows[ctr].Selected = true;
                    txtBarcode.Text = barcode;
                    txtSearchString.Text = dgvItemList.Rows[ctr].Cells[1].Value.ToString();
                    UpdateItemDisplay(barcode);
                    break;
                }
            }
        }

        private void btnSaveProductItem_Click(object sender, EventArgs e)
        {
            SaveProductItem();
            //btnNew.PerformClick();
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            if (txtBarcode.Text != "")
            {
                string barcode = txtBarcode.Text.Trim();
                clsProductItem fi = clsProductItem.SearchProduct(barcode);
                if (fi != null && fi.BarCode != "")
                {
                    UpdateItemDisplay(fi.BarCode);
                }
                else
                {
                    ClearFields(true);
                    txtDesc.Focus();
                }
            }
        }

        private void UpdateItemDisplay(string barcode)
        {
            clsProductItem fi = clsProductItem.SearchProduct(barcode);
            if (fi != null)
            {
                updateInventoryList(barcode);
                txtBarcode.Text = fi.BarCode;
                txtDesc.Text = fi.Description;
                txtCapital.Text = fi.Capital.ToString("0.00");
                txtTotalQty.Text = fi.TotalInventoryQty.ToString();
                
                txtAmount.Text = fi.Amount.ToString("0.00");
                txtWSAmount.Text = fi.WSAmount.ToString("0.00");
                txtImagePath.Text = fi.Imagepath;
                txtCriticalLevel.Text = fi.CriticalLevel.ToString();
                labelItemsRemaining.Text ="Remaining Items: " +  (fi.TotalInventoryQty - fi.QtySold).ToString(fi.Unit=="pc"?"0":"0.0");
                picItem.ImageLocation = fi.Imagepath;
                cboUnit.Text = fi.Unit;
                cboCategory.SelectedItem = fi.Category;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    txtImagePath.Text = openDlg.FileName;
                }
                catch
                {
                }

                picItem.ImageLocation = txtImagePath.Text;
            }
        }

        private void AddItemToGrid(clsProductItem fitem)
        {
            int rowidx = dgvItemList.Rows.Add();
            dgvItemList.Rows[rowidx].Cells[0].Value = fitem.BarCode;
            dgvItemList.Rows[rowidx].Cells[1].Value = fitem.Description;
            dgvItemList.Rows[rowidx].Cells[2].Value = fitem.Capital;
            dgvItemList.Rows[rowidx].Cells[3].Value = fitem.Amount;
            dgvItemList.Rows[rowidx].Cells[4].Value = fitem.WSAmount;
            dgvItemList.Rows[rowidx].Cells[5].Value = fitem.TotalInventoryQty;
            dgvItemList.Rows[rowidx].Cells[6].Value = fitem.Unit;
            dgvItemList.Rows[rowidx].Cells[7].Value = fitem.StocksRemainingQty;
            dgvItemList.Rows[rowidx].Cells[8].Value = fitem.Imagepath;
            dgvItemList.Rows[rowidx].Cells[9].Value = fitem.CriticalLevel;
            dgvItemList.Rows[rowidx].Cells[10].Value = fitem.Category;
        }


        private void dgvPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowidx = e.RowIndex;
            if (rowidx>=0 && rowidx<dgvItemList.Rows.Count && dgvItemList.Rows[rowidx].Cells[0].Value != null)
            {
                txtBarcode.Text = dgvItemList.Rows[rowidx].Cells[0].Value.ToString();
                UpdateItemDisplay(txtBarcode.Text);
               // updateInventoryList(txtBarcode.Text);

               // txtDesc.Text = dgvPurchase.Rows[rowidx].Cells[1].Value.ToString();
               //// txtCapital.Text = dgvPurchase.Rows[rowidx].Cells[2].Value.ToString();
               // txtAmount.Text = dgvPurchase.Rows[rowidx].Cells[3].Value.ToString();
               // txtWSAmount.Text = dgvPurchase.Rows[rowidx].Cells[4].Value.ToString();
               // txtTotalQty.Text = dgvPurchase.Rows[rowidx].Cells[5].Value.ToString();
               // cboUnit.SelectedItem = dgvPurchase.Rows[rowidx].Cells[6].Value.ToString().Trim();
               // chkInStorage.Checked = (dgvPurchase.Rows[rowidx].Cells[7].Value.ToString().Trim()=="Yes"?true:false);
               // txtImagePath.Text = dgvPurchase.Rows[rowidx].Cells[8].Value.ToString();

               // picItem.ImageLocation = txtImagePath.Text;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvItemList.SelectedRows.Count == 1)
            {
                string barcode = dgvItemList.SelectedRows[0].Cells[0].Value.ToString();
                if (MessageBox.Show("Are you sure you want to delete item with barcode " + barcode, "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    if (clsProductItem.Delete(barcode))
                    {
                        UpdateList(barcode);
                        btnNew.PerformClick();
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateList(txtSearchString.Text);
            txtSearchString.SelectAll();
        }

        private void txtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
                txtSearchString.Text = "";
            }
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCapital.Focus();
                txtCapital.SelectAll();
            }
        }

        private void txtImagePath_Enter(object sender, EventArgs e)
        {
            //btnBrowse.PerformClick();
        }

        private void txtImagePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSaveProductItem_Click(null, null);
            }
        }

        private void dgvPurchase_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItemList.SelectedRows.Count > 0 && dgvItemList.SelectedRows[0].Cells[0].Value != null)
            {
                txtBarcode.Text = dgvItemList.SelectedRows[0].Cells[0].Value.ToString();
                UpdateItemDisplay(txtBarcode.Text);
            }
            
            //if (dgvPurchase.SelectedRows.Count > 0 && dgvPurchase.SelectedRows[0].Cells[0].Value!=null)
            //{

            //    txtBarcode.Text = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
            //    updateInventoryList(txtBarcode.Text);
            //    txtDesc.Text = dgvPurchase.SelectedRows[0].Cells[1].Value.ToString();
            //   // txtCapital.Text = dgvPurchase.SelectedRows[0].Cells[2].Value.ToString();
            //    txtAmount.Text = dgvPurchase.SelectedRows[0].Cells[3].Value.ToString();
            //    txtWSAmount.Text = dgvPurchase.SelectedRows[0].Cells[4].Value.ToString();
            //    txtTotalQty.Text = dgvPurchase.SelectedRows[0].Cells[5].Value.ToString();
            //    txtImagePath.Text = dgvPurchase.SelectedRows[0].Cells[8].Value.ToString();
            //    cboUnit.SelectedItem = dgvPurchase.Rows[0].Cells[6].Value.ToString().Trim();
            //    chkInStorage.Checked = (dgvPurchase.Rows[0].Cells[7].Value.ToString().Trim() == "Yes" ? true : false);
            //    picItem.ImageLocation = txtImagePath.Text;
            //}
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Trim() != "")
            {
                try
                {
                    string barcode = txtBarcode.Text.Trim();
                    clsProductItem prod = clsProductItem.SearchProduct(barcode);
                    if (prod == null)
                    {
                        MessageBox.Show("Save the item first.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    frmAddInventory addinventory = new frmAddInventory();
                    addinventory.Quantity = 0;
                    addinventory.Capital = prod.Capital;
                    addinventory.Retail = prod.Amount;
                    if (addinventory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        if (addinventory.Capital <= 0 || addinventory.Quantity <= 0 || addinventory.Retail <= 0)
                        {
                            MessageBox.Show("Capital/Quantity/Retail must be greater than 0", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        clsInventory itemIventory = new clsInventory();
                        itemIventory.BarCode = barcode;
                        itemIventory.Capital = addinventory.Capital;
                        itemIventory.Quantity = addinventory.Quantity;
                        itemIventory.ExpiryDate = dtInventory.Value;
                        itemIventory.DateAdded = dtInventory.Value;
                        itemIventory.Save();

                        prod.Capital = addinventory.Capital;
                        prod.TotalInventoryQty = clsInventory.GetTotalInventoryQty(prod.BarCode);
                        prod.Amount = addinventory.Retail;
                        prod.Save();

                        //SelectItemFromGrid(itemIventory.BarCode);
                        UpdateItemDisplay(barcode);
                        UpdateList(txtSearchString.Text);
                        //SaveProductItem(); // Update Quantity after saving inventory
                    }
                }
                catch
                {

                }

            }
        }

        private void txtImagePath_TextChanged(object sender, EventArgs e)
        {
            picItem.ImageLocation = txtImagePath.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtImagePath.Text = "";
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text != "")
                {
                    txtWSAmount.Text = (Convert.ToDouble(txtAmount.Text) * 0.9).ToString();
                }
            }
            catch { }
        }

        private void dgvPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowidx = e.RowIndex;
            if (rowidx >= 0 && rowidx < dgvItemList.Rows.Count && dgvItemList.Rows[rowidx].Cells[0].Value != null)
            {
                txtBarcode.Text = dgvItemList.Rows[rowidx].Cells[0].Value.ToString();
                UpdateItemDisplay(txtBarcode.Text);
            }
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtImagePath.Focus();
            txtImagePath.SelectAll();
        }

        private void SaveProductItem()
        {
            try
            {

                if (txtBarcode.Text.Trim() != "" && txtDesc.Text.Trim() != "")
                {
                    clsProductItem proditem = clsProductItem.SearchProduct(txtBarcode.Text);
                    if (proditem == null) proditem = new clsProductItem();
                    proditem.BarCode = txtBarcode.Text.Trim().ToUpper();
                    proditem.Description = txtDesc.Text.Trim();
                    proditem.Amount = double.Parse(txtAmount.Text.Trim());
                    proditem.WSAmount = double.Parse(txtWSAmount.Text.Trim());
                    proditem.WSMinimum = 0;
                    proditem.TotalInventoryQty = clsInventory.GetTotalInventoryQty(proditem.BarCode);
                    proditem.Capital = double.Parse(txtCapital.Text.Trim());
                    proditem.Imagepath = txtImagePath.Text.Trim();
                    proditem.QtySold = clsPurchasedItem.GetTotalQtySold(proditem.BarCode);
                    if (cboUnit.SelectedIndex == -1 && cboUnit.Text == "")
                        proditem.Unit = "pc";
                    else if (cboUnit.SelectedIndex == -1 && cboUnit.Text != "")
                        proditem.Unit = cboUnit.Text;
                    else
                        proditem.Unit = cboUnit.SelectedItem.ToString();
                    if (chkInStorage.Checked)
                        proditem.InStorage = 1;
                    else
                        proditem.InStorage = 0;
                    proditem.CriticalLevel = Int32.Parse(txtCriticalLevel.Text);
                    if (proditem.Capital > proditem.Amount || proditem.Capital > proditem.WSAmount)
                    {
                        MessageBox.Show("Retail/Wholesale Amount cannot be less than the capital", "Setup Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (proditem.WSAmount > proditem.Amount)
                    {
                        MessageBox.Show("Wholesale Amount cannot be greater than the retail amount.", "Setup Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (proditem.Capital <= 0 )
                    {
                        MessageBox.Show("Capital Amount cannot be zero.", "Setup Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (categories != null && categories.ContainsValue(cboCategory.SelectedItem.ToString()))
                    {
                        foreach (KeyValuePair<int, string> str in categories)
                        {
                            if (str.Value == cboCategory.SelectedItem.ToString())
                            {
                                proditem.CategoryId = str.Key;
                                break;
                            }
                        }
                    }
                    if (proditem.Save())
                    {
                        UpdateList(proditem.BarCode);
                        SelectItemFromGrid(proditem.BarCode);
                    }
                }
                else
                {
                    MessageBox.Show("Fill-out the form correctly.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBarcode.Focus();
                }
                //if (mBarcode != "") this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<clsInventory> m_ListInventory = new List<clsInventory>();

        private void updateInventoryList(string BarCode)
        {
            dgvInventoryHistory.Rows.Clear();
            m_ListInventory = clsInventory.lstInventory(BarCode);
            foreach (clsInventory inventory in m_ListInventory)
            {
                AddIventoryToGrid(inventory);
            }
              
            //txtTotalCapital.Text = String.Format("P {0:0.00}", arr[0]);
            //if (m_ListInventory.Count > 0)
            //{
            //    txtCapital.Text = String.Format("{0:0.00}", clsInventory.AverageCapital(m_ListInventory));
            //}
            //txtTotalQty.Text = String.Format("{0:0}", clsInventory.GetTotalInventoryQty(BarCode));
        }
        private void AddIventoryToGrid(clsInventory inventory)
        {
            int rowidx = dgvInventoryHistory.Rows.Add();
            dgvInventoryHistory.Rows[rowidx].Cells[0].Value = inventory.DateAdded;
            dgvInventoryHistory.Rows[rowidx].Cells[1].Value = inventory.Quantity;
            dgvInventoryHistory.Rows[rowidx].Cells[2].Value = inventory.Capital;
            dgvInventoryHistory.Rows[rowidx].Cells[3].Value = inventory.Quantity * inventory.Capital;
            dgvInventoryHistory.Rows[rowidx].Cells[4].Value = inventory.ExpiryDate.ToString("yyyy-MM-dd");
            dgvInventoryHistory.Rows[rowidx].Cells[5].Value = inventory.Remarks;
        }

        private void btnRemoveInventory_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Trim() != "")
            {
                string OrigQtValue = txtTotalQty.Text;
                frmInput input = new frmInput();
                input.Title = "Remove Inventory";
                input.Caption = "Quantity";
                input.IsNumericOnly = true;

                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    clsProductItem fi = clsProductItem.SearchProduct(txtBarcode.Text);

                    if (Convert.ToDouble(input.Value) <= 0)
                    {
                        MessageBox.Show("Quantity must be more than 0", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (fi!=null && fi.StocksRemainingQty - Convert.ToDouble(input.Value) >= 0)
                    {
                        frmInput inputReason = new frmInput();
                        inputReason.Title = "Remove Inventory";
                        inputReason.Caption = "Reason for Removing";
                        inputReason.Value = "Transfer Inventory";
                        if (inputReason.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            if (input.Value.Trim() == "")
                            {
                                MessageBox.Show("Must enter reason for removal of inventory", "Remove Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            clsInventory itemIventory = new clsInventory();
                            itemIventory.BarCode = txtBarcode.Text;
                            itemIventory.Capital = Convert.ToDouble(txtCapital.Text);
                            itemIventory.Quantity = -(Convert.ToDouble(input.Value));
                            itemIventory.Remarks = inputReason.Value;
                            itemIventory.ExpiryDate = dtInventory.Value;
                            itemIventory.DateAdded = dtInventory.Value;
                            itemIventory.Save();

                            fi.TotalInventoryQty = clsInventory.GetTotalInventoryQty(fi.BarCode);
                            fi.Save();
                            UpdateList(txtSearchString.Text);
                            UpdateItemDisplay(fi.BarCode);
                        }

                    }
                    else if (fi == null)
                    {
                        MessageBox.Show(string.Format("Product not found"), "Remove Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Removing quantity greater than available quantity not allowed"), "Remove Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            txtWSAmount.Text = txtAmount.Text;
        }

        private void frmSetup_Shown(object sender, EventArgs e)
        {
            
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnRetailCalc_Click(object sender, EventArgs e)
        {
            if (txtCapital.Text != "")
            {
                try
                {
                    txtAmount.Text = (Convert.ToDouble(txtCapital.Text) + 30).ToString("0.00");
                    txtWSAmount.Text = txtAmount.Text;
                }
                catch { }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtBarcode.Focus();
            dgvItemList.ClearSelection();
            //txtBarcode.Text = "A" + dbConnect.GetNextSKU();
        }

        

        private void btnRemoveDuplicate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Delete duplicate entries?", "Delete Duplicate Barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                List<clsProductItem> lstProducts = clsProductItem.SearchProductItems("");
                Dictionary<string, clsProductItem> dicProds = new Dictionary<string, clsProductItem>();

                foreach (clsProductItem c in lstProducts)
                {
                    if (dicProds.ContainsKey(c.BarCode))
                        clsProductItem.DeleteProductItem(c.ID);
                    else
                        dicProds.Add(c.BarCode, c);

                }
            }

        }

        private void frmSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            frmPurchases purchases = new frmPurchases(m_User);
            purchases.ShowDialog();
        }

        private void btnPrintBarcode_Click( object sender, EventArgs e )
        {
            if (txtBarcode.Text != "")
            {
                frmInput input = new frmInput();
                input.Title = "Print Barcode";
                input.Caption = "Enter Quantity to Print";
                input.withDecimal = false;
                input.IsNumericOnly = true;
                input.Value = "1";
                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int qty = Convert.ToInt32(input.Value);

                    Receipt m_receipt = new Receipt();
                    m_receipt.InitializePrinter();
                    if (qty > 0)
                    {
                        for(int ctr=0 ;ctr<qty;ctr++)
                        {
                            m_receipt.PrintHeader(new List<string>() { txtDesc.Text }, PrintFontAlignment.Center, PrintFontSize.BigReg);
                            m_receipt.PrintBarcode(txtBarcode.Text, 2);
                            m_receipt.FormFeed();
                        }
                    }
                    //m_receipt.FormFeed();
                    m_receipt.ExecPrint();

                }
            }
            
        }

        private void btnChangeBarcode_Click( object sender, EventArgs e )
        {
            if (txtBarcode.Text != "")
            {
                clsProductItem prod = clsProductItem.SearchProduct(txtBarcode.Text.Trim());
                if (prod != null)
                {
                    frmInput input = new frmInput();
                    input.Title = "Change Barcode";
                    input.Caption = "New Barcode";
                    input.withDecimal = false;
                    input.IsNumericOnly = false;
                    if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (txtBarcode.Text.Trim() != input.Text.Trim())
                        {
                            clsProductItem tmp = clsProductItem.SearchProduct(input.Value.Trim());
                            if (tmp != null)
                            {
                                MessageBox.Show("Change Barcode", "Barcode already exists!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                clsProductItem.ChangeBarcode(txtBarcode.Text.Trim(), input.Value.Trim());
                                txtBarcode.Text = input.Value.Trim();
                                txtSearchString.Text = input.Value.Trim();
                                btnSearch.PerformClick();
                            }
                        }
                    }
                }
            }

        }

        private void frmSetup_Activated( object sender, EventArgs e )
        {
            UpdateCategories();
        }
    }
}
    