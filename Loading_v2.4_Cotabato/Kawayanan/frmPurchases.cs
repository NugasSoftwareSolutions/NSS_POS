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
    public partial class frmPurchases : Form
    {
        private Receipt m_receipt = new Receipt();
        private clsUsers m_user = null;

        public frmPurchases(clsUsers user)
        {
            InitializeComponent();
            m_user = user;
        }

        private void frmPurchases_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            string barcode = txtBarcode.Text;
            if (e.Modifiers == Keys.None)
            {
                switch(e.KeyCode)
                {
                    case Keys.Enter:
                        AddProduct(txtBarcode.Text.Trim());
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.Multiply:
                    case Keys.F4:
                        e.SuppressKeyPress = true;
                        ChangeQuantity();
                        txtBarcode.Text = barcode;
                        txtBarcode.SelectAll();
                        UpdateProductDisplay(barcode);
                        break;
                    case Keys.Down: SelectGridDown(); break;
                    case Keys.Up: SelectGridUp(); break;
                }

            }
        }

        private void SelectGridDown()
        {
            for (int ctr = 0; ctr < dgvPurchase.Rows.Count; ctr++)
            {
                if (dgvPurchase.Rows[ctr].Selected == true)
                {
                    if (dgvPurchase.Rows.Count > ctr + 1)
                        dgvPurchase.Rows[ctr + 1].Selected = true;
                    break;
                }
            }
        }
        private void SelectGridUp()
        {
            for (int ctr = 0; ctr < dgvPurchase.Rows.Count; ctr++)
            {
                if (dgvPurchase.Rows[ctr].Selected == true)
                {
                    if (ctr - 1 >= 0)
                        dgvPurchase.Rows[ctr - 1].Selected = true;
                    break;
                }
            }
        }
        private void ChangeQuantity()
        {
            if (m_receipt.PurchasedItems.Count == 0) return;
            if (txtBarcode.Text.Trim() == "")
            {
                txtBarcode.Text = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
            }
            if (txtBarcode.Text != "")
            {
                clsProductItem prod = clsProductItem.SearchProduct(txtBarcode.Text);
                if (prod != null && prod.BarCode != "")
                {
                    if (m_receipt.PurchasedItems.ContainsKey(prod.BarCode))
                    {
                        if (txtBarcode.Text.Trim() != "")
                        {
                            try
                            {
                                string barcode = txtBarcode.Text.Trim();
                                frmAddInventory addinventory = new frmAddInventory();
                                addinventory.Quantity = m_receipt.PurchasedItems[barcode].Qty;
                                addinventory.Capital = m_receipt.PurchasedItems[barcode].Capital;
                                addinventory.Retail = m_receipt.PurchasedItems[barcode].Amount;
                                

                                if (addinventory.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {

                                    if (addinventory.Capital <= 0 || addinventory.Retail<= 0)
                                    {
                                        MessageBox.Show("Capital/Quantity must be greater than 0", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    else
                                    {
                                        m_receipt.PurchasedItems[prod.BarCode].Qty = addinventory.Quantity;
                                        m_receipt.PurchasedItems[prod.BarCode].Capital = addinventory.Capital;
                                        m_receipt.PurchasedItems[prod.BarCode].Amount = addinventory.Retail;
                                        UpdatePurchases();
                                    }
                                }
                            }
                            catch
                            {

                            }

                        }
                        //frmInput input = new frmInput();
                        //input.Title = "Quantity";
                        //input.Caption = "Quantity";
                        //input.Value = m_receipt.PurchasedItems[prod.BarCode].Qty.ToString();
                        //input.IsNumericOnly = true;
                        //if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        //{
                        //    double qty = Convert.ToDouble(input.Value);
                        //    if (qty > 0)
                        //    {
                        //        m_receipt.PurchasedItems[prod.BarCode].Qty = Convert.ToDouble(input.Value);
                        //    }
                        //    else
                        //    {
                        //        m_receipt.PurchasedItems.Remove(prod.BarCode);
                        //    }
                        //    UpdatePurchases();
                        //}

                    }


                }

            }
        }

        private void AddProduct(string barcode)
        {
            if (barcode != "")
            {
                clsProductItem prod = clsProductItem.SearchProduct(barcode);
                clsPurchasedItem purchased = null;
                if (prod != null)
                {
                    if (m_receipt.PurchasedItems.ContainsKey(prod.BarCode))
                    {
                        m_receipt.PurchasedItems[prod.BarCode].UserID = m_user.UserId;
                        m_receipt.PurchasedItems[prod.BarCode].Qty += 1;
                        purchased = m_receipt.PurchasedItems[prod.BarCode];
                    }
                    else
                    {
                        purchased = new clsPurchasedItem(prod);
                        purchased.UserID = m_user.UserId;

                        if (purchased.Description.ToUpper().Contains("NEW ITEM"))
                        {
                            purchased.BarCode = "";
                            clsProductItem item = new clsProductItem();
                            frmInput nobarcode = new frmInput();
                            nobarcode.Title = "No Barcode";
                            nobarcode.Caption = "Product Description";
                            nobarcode.IsNumericOnly = false;
                            nobarcode.Value = purchased.Description;
                            if (nobarcode.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                if (nobarcode.Value != "")
                                {
                                    item.Description = nobarcode.Value;
                                    if (MessageBox.Show("Item have Barcode?", "New Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        nobarcode = new frmInput();
                                        nobarcode.Title = "No Barcode";
                                        nobarcode.Caption = "Scan Barcode";
                                        nobarcode.IsNumericOnly = false;
                                        nobarcode.withDecimal = false;
                                        nobarcode.Value = "";
                                        if (nobarcode.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                        {
                                            if (nobarcode.Value != "")
                                            {
                                                item.BarCode = nobarcode.Value;
                                                clsProductItem proditem = clsProductItem.SearchProduct(item.BarCode);
                                                if (proditem != null)
                                                {
                                                    MessageBox.Show("Product already exist!", "New Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Dictionary<int, string> lstCategories = dbConnect.GetCategories();
                                        int catId = 1;
                                        foreach (KeyValuePair<int, string> category in lstCategories)
                                        {
                                            if (category.Value == purchased.Category)
                                            {
                                                catId = category.Key;
                                            }
                                        }
                                        item.BarCode = dbConnect.GetNextSKU().ToString(catId.ToString().Trim() + "000000");
                                    }
                                    nobarcode = new frmInput();
                                    nobarcode.Title = "No Barcode";
                                    nobarcode.Caption = "Capital Amount";
                                    nobarcode.IsNumericOnly = true;
                                    nobarcode.withDecimal = true;
                                    nobarcode.Value = "0";
                                    if (nobarcode.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        if (nobarcode.Value != "")
                                        {
                                            item.Capital = Convert.ToDouble(nobarcode.Value);
                                            nobarcode = new frmInput();
                                            nobarcode.Title = "No Barcode";
                                            nobarcode.Caption = "Retail Amount";
                                            nobarcode.IsNumericOnly = true;
                                            nobarcode.withDecimal = true;
                                            nobarcode.Value = "0";
                                            if (nobarcode.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                            {
                                                if (nobarcode.Value != "")
                                                {
                                                    item.Amount = Convert.ToDouble(nobarcode.Value);
                                                    if (MessageBox.Show("Sold in Wholesale?", "New Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                                    {
                                                        nobarcode = new frmInput();
                                                        nobarcode.Title = "WholeSale";
                                                        nobarcode.Caption = "Quantity per Set(Box/Case/Rim)";
                                                        nobarcode.IsNumericOnly = true;
                                                        nobarcode.withDecimal = false;
                                                        nobarcode.Value = "";
                                                        if (nobarcode.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                        {
                                                            if (nobarcode.Value != "")
                                                            {
                                                                item.WSMinimum = Convert.ToInt32(nobarcode.Value);
                                                                nobarcode = new frmInput();
                                                                nobarcode.Title = "WholeSale";
                                                                nobarcode.Caption = "Amount per Set(Box/Case/Rim)";
                                                                nobarcode.IsNumericOnly = true;
                                                                nobarcode.withDecimal = true;
                                                                nobarcode.Value = "";
                                                                if (nobarcode.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                                {
                                                                    if (nobarcode.Value != "")
                                                                    {
                                                                        item.WSAmount = Convert.ToDouble(nobarcode.Value) / item.WSMinimum;
                                                                        item.Category = prod.Category;
                                                                        item.CategoryId = prod.CategoryId;
                                                                        item.CriticalLevel = 10;
                                                                        item.Imagepath = "";
                                                                        item.QtySold = 0;
                                                                        item.TotalInventoryQty = 0;
                                                                        item.Save();
                                                                        purchased = new clsPurchasedItem(clsProductItem.SearchProduct(item.BarCode));
                                                                    }
                                                                }
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        item.WSAmount = item.Amount;
                                                        item.Category = prod.Category;
                                                        item.CategoryId = prod.CategoryId;
                                                        item.CriticalLevel = 10;
                                                        item.Imagepath = "";
                                                        item.QtySold = 0;
                                                        item.TotalInventoryQty = 0;
                                                        item.WSMinimum = 1;
                                                        item.Save();
                                                        purchased = new clsPurchasedItem(clsProductItem.SearchProduct(item.BarCode));
                                                    }

                                                }
                                            }

                                        }
                                    }

                                }

                            }
                        } 
                        
                        if (purchased.BarCode != "")
                        {
                            m_receipt.PurchasedItems.Add(purchased.BarCode, purchased);
                        }
                        else
                            return;
                    }
                    UpdatePurchases();
                    if (purchased != null && purchased.BarCode != "")
                        UpdateProductDisplay(purchased.BarCode);
                }
                else
                {
                    //MessageBox.Show("Barcode/Product Code not found", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string result = SearchProduct(barcode);
                    txtBarcode.Text = result;
                    if (result != "")
                        AddProduct(result);
                }
            }
            txtBarcode.SelectAll();
        }

        private void UpdateProductDisplay(string prod)
        {
            if (prod != "")
            {
                clsProductItem proditem = clsProductItem.SearchProduct(prod);
                if (proditem != null)
                {
                    txtBarcode.Text = prod;
                    SelectGrid(prod);
                }
            }

        }
        private void SelectGrid(string barcode)
        {
            for (int ctr = 0; ctr < dgvPurchase.Rows.Count; ctr++)
            {
                if (dgvPurchase.Rows[ctr].Cells[0].Value.ToString() == barcode)
                {
                    dgvPurchase.Rows[ctr].Selected = true;
                    break;
                }
            }
        }

        private string SearchProduct(string barcode = "")
        {
            ProductSearch search = new ProductSearch(barcode);
            if (search.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return search.Selected;
            }
            return "";
        }
        private void UpdatePurchases(bool isRetrieve = false)
        {
            dgvPurchase.Rows.Clear();
            foreach (KeyValuePair<string, clsPurchasedItem> purchases in m_receipt.PurchasedItems)
            {
                AddItemToGrid(purchases.Value);
            }
            txtTotal.Text = string.Format("P {0:0.00}", m_receipt.TotalCapital);
        }

        private void AddItemToGrid(clsPurchasedItem fitem)
        {
            int rowidx = dgvPurchase.Rows.Add();
            dgvPurchase.Rows[rowidx].Cells[0].Value = fitem.BarCode;
            dgvPurchase.Rows[rowidx].Cells[1].Value = fitem.Description;
            dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.Qty;
            dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.Unit;
            dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.Capital;
            dgvPurchase.Rows[rowidx].Cells[5].Value = fitem.Capital * fitem.Qty;
        }

        private void dgvPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBarcode.Text = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
            txtBarcode.SelectAll();
        }

        private void dgvPurchase_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPurchase.SelectedRows.Count > 0 && dgvPurchase.SelectedRows[0].Cells[0].Value != null)
                txtBarcode.Text = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
            txtBarcode.SelectAll();
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            txtBarcode.SelectAll();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            frmInput input = new frmInput();
            input.withDecimal = true;
            input.IsNumericOnly = false;
            input.Value = "";
            input.Caption = "Enter Supplier/Reference Num";
            
            if (input.ShowDialog()== System.Windows.Forms.DialogResult.Cancel || input.Value=="")
            {
                return;
            }
            foreach (KeyValuePair<string,clsPurchasedItem> items in m_receipt.PurchasedItems)
            {
                clsPurchasedItem prod = items.Value;
                clsInventory itemIventory = new clsInventory();
                itemIventory.BarCode = prod.BarCode;
                itemIventory.Capital = prod.Capital;
                itemIventory.Quantity = prod.Qty;
                itemIventory.Remarks = input.Value;
                itemIventory.DateAdded = dtInventory.Value;
                itemIventory.Save();

                clsProductItem item  = clsProductItem.SearchProduct(prod.BarCode);
                if(item!=null)
                {
                    item.Capital = prod.Capital;
                    item.TotalInventoryQty += prod.Qty;
                    item.Amount = prod.Amount;
                    item.Save();
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

    }
}
