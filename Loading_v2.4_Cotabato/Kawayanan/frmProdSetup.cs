using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kawayanan.Class;

namespace Kawayanan
{
    public partial class frmProdSetup : Form
    {
        List<clsPurchasedItem> lstInventoryItems = new List<clsPurchasedItem>();
        
        public frmProdSetup()
        {
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

        private void ClearFields()
        {
            txtQty.Text = "";
            txtAmount.Text = "";
            txtDesc.Text = "";
            txtDesc.Focus();
            txtCode.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetup_Load(object sender, EventArgs e)
        {
            ClearFields();
            //UpdateList();
        }
        bool noinventory = false;

        //private void UpdateList()
        //{
        //    try
        //    {
        //        dbConnect connect = new dbConnect();
        //        lstInventoryItems.Clear();
        //        noinventory = false;
        //        connect.ExecuteQuery(string.Format("Select * from InventoryHistory where [Date] = #{0}# Order by Inventory_ID",Convert.ToDateTime(dtPick.Text)), lstInventoryItems);
        //        if (lstInventoryItems.Count == 0)
        //        {
        //            noinventory = true;
        //            connect.ExecuteQuery(string.Format("Select * from Inventory Order by Inventory_ID"), lstInventoryItems);
        //            SaveHistory();
        //            UpdateList();
        //            return;
        //        }
        //        lstProduct.Items.Clear();

        //        foreach (clsTransactionItem fi in lstInventoryItems)
        //        {
        //            if (noinventory) fi.Quantity = 0;
        //            lstProduct.Items.Add(string.Format("{0} : {1}",fi.Description ,fi.Quantity));
        //        }
        //        connect.Close();
        //    }
        //    catch { }            
        //}

        //private void SaveHistory()
        //{
        //    try
        //    {
        //        dbConnect connect = new dbConnect();
        //        //lstInventoryItems.Clear();
        //        //connect.ExecuteQuery("Select * from Inventory Order by Inventory_ID", lstInventoryItems);
        //        //lstProduct.Items.Clear();
        //        foreach (clsPurchasedItem fi in lstInventoryItems)
        //        {
        //            //lstProduct.Items.Add(string.Format("{0} : {1}", fi.Description, fi.Quantity));
        //            fi.Qty = 0;
        //            fi.TransDate = Convert.ToDateTime(dtPick.Text);
        //            fi.SaveHistory();
        //        }
        //        connect.Close();
        //    }
        //    catch { }
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDesc.Text.Trim() != "" && Convert.ToInt32(txtAmount.Text)>0)
                {
                    clsTransactionItem item = new clsTransactionItem();
                    if (lstProduct.SelectedIndex > -1) item.ORNumber = lstInventoryItems[lstProduct.SelectedIndex].ORNumber;
                    item.Description = txtDesc.Text;
                    item.Amount = Convert.ToInt32(txtAmount.Text);
                    item.Quantity = Convert.ToInt32(txtQty.Text);
                    item.BarCode = txtCode.Text;
                    item.TransDate = Convert.ToDateTime(dtPick.Text);
                    item.SaveHistory();
                    //UpdateList();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Fill-out the form correctly.", "Save",MessageBoxButtons.OK ,MessageBoxIcon.Information);
                    txtDesc.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstProduct_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstProduct.SelectedIndex > -1)
            {
                txtCode.Text = lstInventoryItems[lstProduct.SelectedIndex].BarCode;
                txtDesc.Text = lstInventoryItems[lstProduct.SelectedIndex].Description;
                txtAmount.Text = lstInventoryItems[lstProduct.SelectedIndex].Amount.ToString();
                txtQty.Text = lstInventoryItems[lstProduct.SelectedIndex].Quantity.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstProduct.SelectedIndex > -1)
            {
                clsTransactionItem proditem = new clsTransactionItem();
                proditem.Delete(lstInventoryItems[lstProduct.SelectedIndex].ORNumber);
                //UpdateList();
                ClearFields();
                if(lstProduct.Items.Count>0)
                lstProduct.SelectedIndex = 0;
            }
        }

        private void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProduct.SelectedIndex > -1)
            {
                txtCode.Text = lstInventoryItems[lstProduct.SelectedIndex].BarCode;
                txtDesc.Text = lstInventoryItems[lstProduct.SelectedIndex].Description;
                txtAmount.Text = lstInventoryItems[lstProduct.SelectedIndex].Amount.ToString();
                txtQty.Text = lstInventoryItems[lstProduct.SelectedIndex].Quantity.ToString();
                txtQty.SelectAll();
                txtQty.Focus();
            }
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            SaveHistory();
        }

        private void dtPick_ValueChanged(object sender, EventArgs e)
        {
            //UpdateList();
        }
    }
}
    