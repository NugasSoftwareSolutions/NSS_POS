using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using AlreySolutions.Class;
using License;
using System.Runtime.InteropServices;
using AlreySolutions.LoadingStation;

namespace AlreySolutions
{
    public partial class myPosWide : Form
    {
        private Receipt m_receipt = new Receipt();
        private Receipt m_tempreceipt = new Receipt();
        private Int32 m_SavedTransOR  = 0;
        public static clsUsers m_user = null;
        private bool m_AllowEditing = true;
        private frmUtility m_UtilityWindow = null;
        private DateTime m_ActualDate,m_selectedDate;

        [DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
        public extern static void Win32GetSystemTime( ref SystemTime sysTime );

        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime( ref SystemTime sysTime );

        public myPosWide()
        {
            InitializeComponent();
            m_ActualDate = DateTime.Now;
            m_selectedDate = DateTime.Now;
            //try
            //{
            //    dbConnect.CompactAccessDB(Properties.Settings.Default.dbConnectionString + @";Jet OLEDB:Database Password=@Lr3yP0$dB;", Properties.Settings.Default.ServerPath + Properties.Settings.Default.Database);
            //}
            //catch
            //{
            //    MessageBox.Show("Repair Failed. There's an open database connection. Make sure all POS Systems are closed.", "Repair Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            bool funckey = true;
            if (e.Modifiers == Keys.None)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (txtBarcode.Text.Length == 12 && txtBarcode.Text.StartsWith("9999"))
                        {
                            RetrieveReceipt(Convert.ToInt64(txtBarcode.Text.Remove(0,4)).ToString());
                            txtBarcode.Text = "";
                        }else
                        {
                            AddProduct(txtBarcode.Text.Trim()); 
                        }
                        break;
                    case Keys.F1: Logout(); break;
                    case Keys.F2: NewCustomer(true); break;
                    case Keys.F3: AddProduct(SearchProduct()); break;
                    case Keys.Multiply:
                    case Keys.F4: ChangeQuantity(); break;
                    case Keys.F5: btnPrint_Click(null,null); break;
                    case Keys.F6: SelectDiscount(); break;
                    case Keys.Space:
                        if(txtBarcode.SelectionLength == txtBarcode.Text.Length)
                        {
                            AcceptPayment();
                        }else{
                            funckey = false;   
                        }
                        break;
                    case Keys.F7: RetrieveReceipt(); 
                        UpdateButtons(false);
                        break;
                    case Keys.F8:
                        PayAccount();
                        break;
                    case Keys.F9: VoidReceipt(); break;
                    case Keys.F10: ShowUtilities(); break;
                    case Keys.F11: ShowLoadingStation();
                        break;
                    case Keys.F12:
                        Properties.Settings.Default.Theme += 1;
                        if (Properties.Settings.Default.Theme > 4) Properties.Settings.Default.Theme = 0;
                        Properties.Settings.Default.Save();
                        clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
                        break;
                    case Keys.Down: SelectGridDown(); break;
                    case Keys.Up: SelectGridUp(); break;
                    default: funckey = false; break;
                }
                if (funckey)
                {
                    e.SuppressKeyPress = true;
                    txtBarcode.SelectAll();
                }
            }
            else if ((e.Modifiers == Keys.Alt) && (e.KeyCode == Keys.F4))
            {
                ExitApp();
                e.SuppressKeyPress = true;
            }
            else if ((e.Modifiers == Keys.Alt) && (e.KeyCode == Keys.F8))
            {
                CancelPayment();
                e.SuppressKeyPress = true;
            }
            else if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.S))
            {
                SaveTemp();
                e.SuppressKeyPress = true;
            }
            else if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.O))
            {
                OpenTemp();
                e.SuppressKeyPress = true;
            }
            else if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.P))
            {
                if (Properties.Settings.Default.PrintORBarcode == true)
                {
                    PrintBarcode();
                }
                e.SuppressKeyPress = true;
            }
            else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.D8)
            {
                ChangeQuantity();
                e.SuppressKeyPress = true;
                txtBarcode.SelectAll();
            }
        }

        private void PrintBarcode()
        {
            frmInput input = new frmInput();
            input.Title = "Print Barcode";
            input.Caption = "Scan Barcode";
            input.withDecimal = false;
            input.IsNumericOnly = false;
            if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string barcode = input.Value;
                input.Title = "Item Description";
                input.Caption = "Enter Description";
                input.Value = "";
                input.withDecimal = false;
                input.IsNumericOnly = false;
                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //input.Value = input.Value.PadLeft(12, '0');

                    m_receipt.InitializePrinter();
                    m_receipt.PrintHeader(new List<string>() { input.Value }, PrintFontAlignment.Center, PrintFontSize.BigReg);
                    m_receipt.PrintBarcode(barcode, 2);
                    m_receipt.FormFeed();
                    m_receipt.ExecPrint();
                    //m_receipt.OpenDrawer();
                }
            }
        }

        private void OpenTemp()
        {
            frmTempTrans tmp = new frmTempTrans(m_user);
            if (tmp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (tmp.SelectedTempOR != null)
                {
                    m_SavedTransOR = tmp.SelectedTempOR.ORNumber;
                    m_receipt = tmp.SelectedTempOR;
                    m_receipt.ORNumber = 0;
                    UpdatePurchases();
                }
            }
        }

        private void SaveTemp()
        {
            if (m_receipt != null && m_receipt.TotalDiscountedAmount > 0)
            {
                if (m_receipt.CashierName == "Customer")
                {
                    frmInput input = new frmInput();
                    input.Title = "Save Transaction";
                    input.Caption = "Customer Name/Reference";
                    input.Value = "";
                    input.withDecimal = false;
                    input.IsNumericOnly = false;
                    if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK && input.Value != "")
                    {
                        m_receipt.SaveTemp(input.Value, true);
                    }

                }
                else
                {
                    m_receipt.ORNumber = m_SavedTransOR;
                    m_receipt.SaveTemp(m_receipt.CashierName, true);
                }

                MessageBox.Show("Transaction successfully saved. Press Ctrl+O to retrieve.", "Save Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewCustomer();

            }
        }

        private void PayAccount()
        {
            frmSelectAccounts acct = new frmSelectAccounts(m_receipt.TotalDiscountedAmount - m_receipt.CashTendered,m_user);
            if (acct.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clsAccountInfo a = acct.SelectedAccount;

                frmInput payment = new frmInput();
                double amountpaid = a.AccountReceivable;
                double change = 0;
                payment.Title = "Cash Payment: " + a.AccountName;
                payment.Caption = "Amount";
                payment.IsNumericOnly = true;
                payment.Value = a.AccountReceivable.ToString();
                if (payment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (Convert.ToDouble(payment.Value) < a.AccountReceivable)
                    {
                        amountpaid = Convert.ToDouble(payment.Value);
                    }
                    else
                    {
                        amountpaid = a.AccountReceivable;
                        change = Convert.ToDouble(payment.Value) - a.AccountReceivable;
                    }
                    if (amountpaid >= 0)
                    {
                        clsPaymentInfo pay = new clsPaymentInfo();
                        pay.AccountId = a.AccountId;
                        pay.AmountPaid = amountpaid;
                        pay.Timestamp = DateTime.Now;
                        pay.UserId = m_user.UserId;
                        pay.UserName = m_user.UserName;
                        string reference = pay.Save();
                        string ret = "";
                        Receipt or = new Receipt();
                        or.InitializePrinter();
                        List<string> strmsg = new List<string>();
                        ret += or.PrintCompanyHeader();
                        strmsg.Add("");
                        strmsg.Add("PAYMENT");
                        ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold);
                        strmsg.Clear();

                        strmsg.Add(string.Format("Cashier: {0}", m_user.UserName.ToUpper()));
                        strmsg.Add(string.Format("Date: {0}", pay.Timestamp.ToString("yyyy-MM-dd HH:mm:ss")));
                        strmsg.Add(reference);
                        strmsg.Add(string.Format("Account Name: {0}", a.AccountName));
                        strmsg.Add(string.Format("Previous Balance: P {0:0.00}", a.AccountReceivable));
                        strmsg.Add(string.Format("Amount Paid: P {0:0.00}", amountpaid));
                        strmsg.Add(string.Format("Current Balance: P {0:0.00}", a.AccountReceivable - amountpaid));
                        ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                        or.FormFeed();
                        or.OpenDrawer();
                        or.ExecPrint(ret);
                        strmsg.Clear();
                        a.LoadTransInfo();

                        //a.PrincipalBalance = clsChargedTransaction.GetPrincipalAmount(a.AccountId);
                        //a.TotalInterest = clsChargedTransaction.GetTotalInterest(a.AccountId);
                        a.LastComputedInterest = DateTime.Today;
                        a.Save();

                        CloseDrawer drawer = new CloseDrawer();
                        drawer.Change = change;
                        drawer.ShowDialog();
                    }
                }
            }
        }


        private void Print( bool showdrawerdlg = true)
        {
            if (m_receipt.ORNumber > 0)
            {
                m_receipt.PrintNew(1);
                if ( (Properties.Settings.Default.PrintDuplicate==true && Properties.Settings.Default.EnablePrint) || m_receipt.CashTendered < m_receipt.TotalDiscountedAmount)
                {
                    if (MessageBox.Show("Print Duplicate Copy", "Print Receipt", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                        m_receipt.PrintNew(2);
                }
                if (m_receipt.CashTendered > 0 || showdrawerdlg)
                {
                    if (showdrawerdlg)
                    {
                        CloseDrawer drawer = new CloseDrawer();
                        drawer.Change = m_receipt.ChangeAmount;
                        if (drawer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            NewCustomer();
                        }
                    }
                }
                else
                {
                    NewCustomer();
                }
            }
            else
            {
                string ret = m_receipt.PrintNew(4);

                //if (m_receipt.PurchasedItems.Count > 0)
                //{
                //    AcceptPayment();
                //}
                //else
                //{
                //    RetrieveReceipt();
                //    if (m_receipt.CashTendered > 0) Print(showdrawerdlg);
                //    m_tempreceipt = new Receipt();
                //}
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
                    if (!AllowModify()) return;
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
                                if (nobarcode.Value != "" && nobarcode.Value.ToUpper().Contains("NEW ITEM")==false)
                                {
                                    item.Description = nobarcode.Value;
                                    if (MessageBox.Show("Item have Barcode?", "New Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
                                                break;
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

                                                                        nobarcode = new frmInput();
                                                                        nobarcode.Title = "Inventory";
                                                                        nobarcode.Caption = "Quantity Remaining";
                                                                        nobarcode.IsNumericOnly = true;
                                                                        nobarcode.withDecimal = true;
                                                                        nobarcode.Value = "0";
                                                                        if (nobarcode.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                                                        {
                                                                            if (nobarcode.Value != "" && Convert.ToDouble(nobarcode.Value) > 0)
                                                                            {
                                                                                item.TotalInventoryQty = Convert.ToDouble(nobarcode.Value);
                                                                                item.Save();

                                                                                clsInventory inventory = new clsInventory();
                                                                                inventory.BarCode = item.BarCode;
                                                                                inventory.Description = item.Description;
                                                                                inventory.Capital = item.Capital;
                                                                                inventory.DateAdded = dtNow.Value;
                                                                                inventory.Quantity = item.TotalInventoryQty;
                                                                                inventory.Remarks = "";
                                                                                inventory.Save();
                                                                            }
                                                                        }
                                                                        item.Save();
                                                                        purchased = new clsPurchasedItem(clsProductItem.SearchProduct(item.BarCode));

                                                                   }
                                                                }
                                                            }

                                                        }
                                                    }
                                                    else
                                                    {
                                                        item.Capital = item.Capital;
                                                        item.WSAmount = item.Amount;
                                                        item.Category = prod.Category;
                                                        item.CategoryId = prod.CategoryId;
                                                        item.CriticalLevel = 10;
                                                        item.Imagepath = "";
                                                        item.QtySold = 0;
                                                        item.TotalInventoryQty = 0;
                                                        item.WSMinimum = 0;
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
                            if (purchased.Category.ToUpper() == "E-LOAD")
                            {
                                frmInput frmInput = new frmInput();
                                frmInput.Title = "CELL NUMBER";
                                frmInput.Caption = "Enter Cell Number";
                                frmInput.Value = "";
                                frmInput.IsNumericOnly = false;
                                frmInput.withDecimal = false;
                                if (frmInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    purchased.Description += string.Format(":{0}", frmInput.Value);
                                    frmInput = new frmInput();
                                    frmInput.Title = "LOAD AMOUNT";
                                    frmInput.Caption = "Enter Amount";
                                    frmInput.Value = "";
                                    frmInput.IsNumericOnly = true;
                                    frmInput.withDecimal = false;
                                    if (frmInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        purchased.Qty = Convert.ToDouble(frmInput.Value);
                                        purchased.Amount = 1;
                                    }
                                }
                            }
                            m_receipt.PurchasedItems.Add(purchased.BarCode, purchased);
                        }
                        else
                            return;
                        //if (m_receipt.PurchasedItems[prod.BarCode].Qty > prod.AvailableQty)
                        //    MessageBox.Show("Quantity Purchased is more than the available quantity on stock", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    UpdatePurchases();
                    if(purchased != null && purchased.BarCode !="")
                        UpdateProductDisplay(m_receipt.PurchasedItems[purchased.BarCode]);
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
        private string SearchProduct(string barcode = "")
        {
            if (!AllowModify()) return "";
            ProductSearch search = new ProductSearch(barcode);
            if (search.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return search.Selected;
            }
            return "";
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
        private void UpdateProductDisplay(clsPurchasedItem prod)
        {
            if (prod.BarCode != "")
            {
                clsProductItem proditem = clsProductItem.SearchProduct(prod.BarCode);
                if (proditem != null)
                {
                    txtBarcode.Text = prod.BarCode;
                    lblProdDesc.Text = prod.Description;
                    lblAmount.Text = string.Format("P {0:0.00}", prod.Amount - prod.Discount);
                    lblQty.Text = prod.Qty.ToString();
                    lblUnit.Text = prod.Unit;
                    lblTotalPrice.Text = string.Format("P {0:0.00}", prod.Total - (prod.Discount * prod.Qty));
                    if (proditem.Imagepath == "") picProduct.ImageLocation = Properties.Settings.Default.Logos;
                    else picProduct.ImageLocation = string.Format("{0}", proditem.Imagepath);
                    SelectGrid(prod.BarCode);
                }
            }
            else
            {
                ClearFields();
            }
        }
        private void AddItemToGrid(clsPurchasedItem fitem)
        {
            int rowidx = dgvPurchase.Rows.Add();
            dgvPurchase.Rows[rowidx].Cells[0].Value = fitem.BarCode;
            dgvPurchase.Rows[rowidx].Cells[1].Value = fitem.Description;
            dgvPurchase.Rows[rowidx].Cells[2].Value = fitem.Qty;
            dgvPurchase.Rows[rowidx].Cells[3].Value = fitem.Unit;
            dgvPurchase.Rows[rowidx].Cells[4].Value = fitem.Amount - fitem.Discount;
            dgvPurchase.Rows[rowidx].Cells[5].Value = (fitem.Discount * fitem.Qty);
            dgvPurchase.Rows[rowidx].Cells[6].Value = fitem.Total - (fitem.Discount * fitem.Qty);
        }

        private void UpdatePurchases(bool isRetrieve=false)
        {
            dgvPurchase.Rows.Clear();
            foreach (KeyValuePair<string, clsPurchasedItem> purchases in m_receipt.PurchasedItems)
            {
                AddItemToGrid(purchases.Value);
            }
            txtOR.Text = string.Format("{0:000000000}", isRetrieve ? m_receipt.ORNumber : dbConnect.GetNextORNumber());
            txtTotal.Text = string.Format("P {0:0.00}", m_receipt.TotalAmountDue);
            txtItems.Text = m_receipt.TotalQty.ToString();
            txtDiscount.Text = string.Format("P {0:0.00}", m_receipt.ItemDiscount);
            txtDiscounted.Text = string.Format("P {0:0.00}", m_receipt.TotalDiscountedAmount);
            txtCashTendered.Text = string.Format("P {0:0.00}", m_receipt.CashTendered);
            txtDate.Text = m_receipt.TransDate.ToString();
            if (m_receipt.Accountid > 0)
            {
                txtAccount.Text = m_receipt.AccountName;
                txtChargeAmount.Text = string.Format("P {0:0.00}", m_receipt.ChargedAmount);
            }
            else
            {
                txtAccount.Text ="";
                txtChargeAmount.Text = string.Format("P {0:0.00}", 0);
            }
            txtChange.Text = string.Format("P {0:0.00}", m_receipt.ChangeAmount);
        }


        private void ClearFields()
        {
            txtBarcode.Text = "";
            lblProdDesc.Text = "";
            lblAmount.Text = "";
            lblTotalPrice.Text = "";
            lblQty.Text = "";
            lblUnit.Text = "";
            txtAccount.Text = "";
            txtChargeAmount.Text = "";
            picProduct.ImageLocation = Application.StartupPath + "\\" + Properties.Settings.Default.Logos;
        }


        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            txtBarcode.SelectAll();
        }

        private void iPOS_Shown(object sender, EventArgs e)
        {
            txtBarcode.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewCustomer(true);
        }

        private void NewCustomer(bool confirm = false)
        {
            bool ret = false;
            if (confirm && m_receipt.TotalDiscountedAmount > 0 && MessageBox.Show("Are you sure you want to cancel current transaction?", "New Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                ret = true;
            }
            if (ret || !confirm)
            {
                m_receipt = new Receipt();
                m_receipt.ORNumber = 0;// dbConnect.GetNextORNumber();
                m_receipt.CashierName = "Customer";
                ClearFields();
                UpdatePurchases();
                UpdateProductDisplay(new clsPurchasedItem());
                txtOR.Text = string.Format("{0:000000000}", dbConnect.GetNextORNumber());
                UpdateButtons(true);
            }
            m_tempreceipt = null;
            m_SavedTransOR = 0;
        }

        private void 
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            AcceptPayment()
        {
            if (!AllowModify()) return;
            if (m_receipt.PurchasedItems.Count > 0)
            {
                frmInput payment = new frmInput();
                clsChargedTransaction charge = null;
                clsAccountInfo selact = null;
                payment.Title = "Cash Payment";
                payment.Caption = "Amount";
                payment.IsNumericOnly = true;
                if (m_tempreceipt != null && m_tempreceipt.Accountid > 0)
                    payment.Value = m_tempreceipt.CashTendered.ToString();
                else
                    payment.Value = m_receipt.CashTendered >= Math.Round(m_receipt.TotalDiscountedAmount, 2) ? m_receipt.CashTendered.ToString() : m_receipt.TotalDiscountedAmount.ToString();
                
                if (payment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    bool confirmprint = m_receipt.CashTendered > 0 ? true : false;
                    bool updatepurchase = false;
                    if (m_tempreceipt != null && m_tempreceipt.ORNumber > 0) m_receipt.ORNumber = 0;
                    if (m_receipt.ORNumber == 0) m_receipt.TransDate = DateTime.Now;
                    m_receipt.CashTendered = Convert.ToDouble(payment.Value);
                    m_receipt.CashierName = m_user.UserName;
                    if (Properties.Settings.Default.RequireCustomerName || m_receipt.CashTendered < m_receipt.TotalDiscountedAmount)
                    {
                        if (Properties.Settings.Default.RequireCustomerName || m_receipt.Accountid>0 || MessageBox.Show("Cash tendered is less than the amount due. Would you like to charge balance to account?", "Charge Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            frmSelectAccounts acct = new frmSelectAccounts(m_receipt.TotalDiscountedAmount - m_receipt.CashTendered, m_user);
                            if ( m_receipt.Accountid>0 || acct.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                m_receipt.Save();
                                if (m_receipt.Accountid > 0) 
                                    selact = new clsAccountInfo(m_receipt.Accountid);
                                else 
                                    selact = acct.SelectedAccount;
                                if (selact != null)
                                {
                                    //Return Items to inventory
                                    if (m_tempreceipt != null)
                                    {

                                        foreach (clsPurchasedItem item in m_tempreceipt.PurchasedItems.Values)
                                        {
                                            clsProductItem prod = clsProductItem.SearchProduct(item.BarCode);
                                            if (prod != null)
                                            {
                                                updatepurchase = true;
                                                prod.QtySold -= item.Qty;
                                                prod.Save();
                                            }
                                        }


                                        if (selact != null && m_tempreceipt.ChargedAmount>0)
                                        {
                                            string ret = "";
                                            Receipt or = new Receipt();
                                            or.InitializePrinter();
                                            List<string> strmsg = new List<string>();
                                            or.PrintCompanyHeader();
                                            strmsg.Add("");
                                            strmsg.Add("VOID RECEIPT");
                                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold); strmsg.Clear();

                                            strmsg.Add(string.Format("Cashier: {0}", m_user.UserName.ToUpper()));
                                            strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                            strmsg.Add(string.Format("ORNum: {0}",m_tempreceipt.ORNumber));
                                            strmsg.Add("");
                                            strmsg.Add(string.Format("Account Name: {0}", selact.AccountName));
                                            strmsg.Add(string.Format("Previous Balance: P {0:0.00}", selact.AccountReceivable));
                                            strmsg.Add(string.Format("Amount Returned: P {0:0.00}", m_tempreceipt.ChargedAmount));
                                            strmsg.Add(string.Format("Current Balance: P {0:0.00}", selact.AccountReceivable - m_tempreceipt.ChargedAmount));
                                            ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                                            or.FormFeed();
                                            or.OpenDrawer();
                                            or.ExecPrint(ret);
                                            strmsg.Clear();

                                            selact.YTDTransaction -= m_tempreceipt.TotalDiscountedAmount;
                                            selact.PrincipalBalance -= m_tempreceipt.ChargedAmount;
                                            selact.Save();
                                        }
                                        m_tempreceipt.Delete();
                                    }
                                    m_tempreceipt = null;

                                    charge = new clsChargedTransaction();
                                    charge.AccountId = selact.AccountId;
                                    charge.AccountName = selact.AccountName;
                                    charge.ChargedAmount = m_receipt.CashTendered < m_receipt.TotalDiscountedAmount ? m_receipt.TotalDiscountedAmount - m_receipt.CashTendered : 0;
                                    charge.TransAmount = m_receipt.TotalDiscountedAmount;
                                    charge.ORNum = m_receipt.ORNumber;
                                    charge.User_Id = m_user.UserId;
                                    charge.PrevBalance = selact.AccountReceivable;
                                    charge.CurrBalance = charge.PrevBalance + charge.ChargedAmount;
                                    charge.TransBalance = charge.ChargedAmount;
                                    charge.InterestPayment = DateTime.Now;
                                    charge.Timestamp = DateTime.Now;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }

                        }
                        else
                        {
                            return;
                        }
                    }

                    if (m_SavedTransOR > 0)
                    {
                        Receipt tmp = new Receipt(m_SavedTransOR, true);
                        tmp.DeleteTempReceipt();
                    }
                    if (charge != null)
                    {
                        m_receipt.Accountid = charge.AccountId;
                        charge.ORNum = m_receipt.ORNumber;
                        charge.SaveChargeTransaction();
                        if (selact != null)
                        {
                            selact.YTDTransaction += m_receipt.TotalDiscountedAmount;
                            selact.PrincipalBalance += m_receipt.ChargedAmount;
                            selact.Save();
                        }
                    }
                    m_receipt.Save(updatepurchase);
                    UpdatePurchases(true);
                    if (!confirmprint || confirmprint && MessageBox.Show("Would you like to print receipt?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Print();
                    }
                    else
                    {
                        NewCustomer();
                    }
                }
            }
        }

        private bool RetrieveReceipt(string valOrNum="")
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Manager)) return false;
            if (valOrNum == "")
            {
                frmInput input = new frmInput();
                input.Title = "Retrieve Transaction";
                input.Caption = "Invoice Number";
                input.IsHiddenInput = false;
                input.IsNumericOnly = true;
                input.withDecimal = false;
                input.Value = valOrNum;
                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Receipt OR = new Receipt(Convert.ToInt32(input.Value));
                    if (OR.ORNumber != 0)
                    {
                        m_receipt = OR;
                        m_tempreceipt = new Receipt(Convert.ToInt32(input.Value));
                        m_SavedTransOR = 0;
                        UpdatePurchases(true);
                        if (OR.CashierName == m_user.UserName || m_user.LoginType < (int)UserAccess.Cashier)
                        {
                            UpdateButtons(true);
                        }
                        else
                        {
                            UpdateButtons(false);
                        }
                        //UpdateButtons(false);

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Invoice Number not found", "Retrieve OR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                Receipt OR = new Receipt(Convert.ToInt32(valOrNum));
                if (OR.ORNumber != 0)
                {
                    m_receipt = OR;
                    m_tempreceipt = new Receipt(Convert.ToInt32(valOrNum));
                    UpdatePurchases(true);
                    if (OR.TransDate < DateTime.Today || OR.CashierName != m_user.UserName)
                    {
                        UpdateButtons(false);
                    }
                    else
                    {
                        UpdateButtons(true);
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Invoice Number not found", "Retrieve OR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return false;
        }

        private bool CancelPayment()
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Manager)) return false;
            frmSelectAccounts acct = new frmSelectAccounts(m_receipt.TotalDiscountedAmount - m_receipt.CashTendered, m_user);
            if (acct.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clsAccountInfo a = acct.SelectedAccount;

                frmInput input = new frmInput();
                input.Title = "Retrieve Payment Info";
                input.Caption = "Payment Reference";
                input.IsHiddenInput = false;
                input.IsNumericOnly = true;
                input.withDecimal = false;
                input.Value = "";
                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                    clsPaymentInfo payment = clsPaymentInfo.GetPayment(Convert.ToInt32(input.Value));
                    if (payment != null)
                    {
                        clsChargedTransaction charges = clsChargedTransaction.GetChargedTransaction(payment.OrNum);

                        if (charges != null && payment.PaymentId != 0 && payment.AccountId == a.AccountId)
                        {
                            if (payment.Remarks.ToLower().Contains("interest"))
                            {
                                MessageBox.Show("Interest payment cancellation not allowed!", "Cancel Payment", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else if (MessageBox.Show(string.Format("Are you sure you want to cancel payment?\nRefno:{0}\nRemarks:{1}\nAmount:P {2:0.00}", payment.PaymentId, payment.Remarks, payment.AmountPaid), "Cancel Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (payment.Remarks.ToLower().Contains("principal"))
                                {
                                    a.PrincipalBalance += payment.AmountPaid;
                                    a.Save();
                                    charges.TransBalance += payment.AmountPaid;
                                    charges.SaveChargeTransaction();

                                    if (clsPaymentInfo.CancelPayment(payment.PaymentId))
                                    {
                                        MessageBox.Show("Payment successfully cancelled!", "Cancel Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cancel Payment did not succeed!", "Cancel Payment", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Payment Reference not found under this account", "Cancel Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            return false;
        }

        private void btnItemVoid_Click(object sender, EventArgs e)
        {
        }

        private void btnAcceptPayment_Click(object sender, EventArgs e)
        {
            AcceptPayment();
        }

        private void btnProdSearch_Click(object sender, EventArgs e)
        {
            AddProduct(SearchProduct());
        }


        private void UpdateButtons(bool allowediting)
        {
            m_AllowEditing = allowediting;
            //txtBarcode.Enabled = allowediting;
        }
        private void btnModTransaction_Click(object sender, EventArgs e)
        {
            if (!AllowModify()) return;
            RetrieveReceipt();
            UpdateButtons(false);
        }

        private void ItemVoid()
        {
            if (!AllowModify()) return;
            if (m_receipt.PurchasedItems.Count == 0) return;
            if (txtBarcode.Text.Trim() == "")
            {
                txtBarcode.Text = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
            }
            if (m_receipt.PurchasedItems.ContainsKey(txtBarcode.Text.Trim()))
                {
                m_receipt.PurchasedItems.Remove(txtBarcode.Text.Trim());
                    UpdatePurchases();
                    UpdateProductDisplay(new clsPurchasedItem());
                }

        }


        private void UseRetailPrice(clsProductItem item)
        {
            if (m_receipt.PurchasedItems.Count == 0) return;
            if (item.BarCode != "" && m_receipt.PurchasedItems.ContainsKey(item.BarCode))
            {
                m_receipt.PurchasedItems[item.BarCode].Amount = item.Amount;
                m_receipt.PurchasedItems[item.BarCode].Description = item.Description;
                m_receipt.PurchasedItems[item.BarCode].Discount = 0;
                m_receipt.PurchasedItems[item.BarCode].IsWholeSale = false;
                UpdatePurchases();
                UpdateProductDisplay(m_receipt.PurchasedItems[item.BarCode]);
            }
            else
            {
                MessageBox.Show("Select which item cancel discount", "Use Retail Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void UseWholeSalePrice(clsProductItem item)
        {
            if (m_receipt.PurchasedItems.Count == 0 || item==null) return;
            if (item.BarCode != "" && m_receipt.PurchasedItems.ContainsKey(item.BarCode))
            {
                m_receipt.PurchasedItems[item.BarCode].Amount = item.Amount;
                m_receipt.PurchasedItems[item.BarCode].Description = item.Description + "@WS";
                m_receipt.PurchasedItems[item.BarCode].Discount = item.Amount - item.WSAmount;
                m_receipt.PurchasedItems[item.BarCode].IsWholeSale = true;
                UpdatePurchases();
                UpdateProductDisplay(m_receipt.PurchasedItems[item.BarCode]);
            }
            else
            {
                MessageBox.Show("Select which item to apply wholesale price", "WholeSale", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void UpdateDisplayFromGridSelection(int rowidx = -1)
        {
            if (rowidx >= 0 && rowidx < dgvPurchase.Rows.Count && dgvPurchase.Rows[rowidx].Cells[0].Value != null)
            {
                txtBarcode.Text = dgvPurchase.Rows[rowidx].Cells[0].Value.ToString();
                lblProdDesc.Text = dgvPurchase.Rows[rowidx].Cells[1].Value.ToString();
                lblQty.Text = dgvPurchase.Rows[rowidx].Cells[2].Value.ToString();
                lblUnit.Text = dgvPurchase.Rows[rowidx].Cells[3].Value.ToString();
                lblAmount.Text = string.Format("P {0:0.00}", dgvPurchase.Rows[rowidx].Cells[4].Value);
                lblTotalPrice.Text = string.Format("P {0:0.00}", dgvPurchase.Rows[rowidx].Cells[6].Value);
                picProduct.ImageLocation = clsProductItem.SearchProduct(txtBarcode.Text).Imagepath;

                if (picProduct.ImageLocation == "") picProduct.ImageLocation = Properties.Settings.Default.Logos;


            }
            else if (dgvPurchase.SelectedRows.Count == 1 && dgvPurchase.SelectedRows[0].Cells[0].Value != null)
            {
                txtBarcode.Text = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
                lblProdDesc.Text = dgvPurchase.SelectedRows[0].Cells[1].Value.ToString();
                lblQty.Text = dgvPurchase.SelectedRows[0].Cells[2].Value.ToString();
                lblUnit.Text = dgvPurchase.SelectedRows[0].Cells[3].Value.ToString();
                lblAmount.Text = string.Format("P {0:0.00}", dgvPurchase.SelectedRows[0].Cells[4].Value);
                lblTotalPrice.Text = string.Format("P {0:0.00}", dgvPurchase.SelectedRows[0].Cells[6].Value);
                picProduct.ImageLocation = clsProductItem.SearchProduct(txtBarcode.Text).Imagepath;
                if (picProduct.ImageLocation == "") picProduct.ImageLocation = Properties.Settings.Default.Logos;
            }
            txtBarcode.SelectAll();
        }

        private void PercentDiscount(clsProductItem item)
        {
            if (m_receipt.PurchasedItems.Count == 0) return;
            if (item.BarCode != "" && m_receipt.PurchasedItems.ContainsKey(item.BarCode))
            {
                frmInput input = new frmInput();
                input.Title = "Discount";
                input.Caption = "Discount Percent";
                input.IsNumericOnly = true;
                input.Value = "5";
                if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //if (Double.Parse(input.Value) > Properties.Settings.Default.MaxPercentDiscount)
                    //{
                    //    if (!clsUtil.GetApproval(m_user, UserAccess.Manager)) return;
                    //}
                    //else if (Double.Parse(input.Value) > (Properties.Settings.Default.MaxPercentDiscount / 2.0))
                    //{
                    //    if (!clsUtil.GetApproval(m_user, UserAccess.Supervisor)) return;
                    //}
                    clsProductItem prod = clsProductItem.SearchProduct(item.BarCode);
                    if (item.Amount - (item.Amount * (Convert.ToDouble(input.Value) / 100.0)) < item.Capital)
                    {
                        int max = 100 - (int)(item.Capital / item.Amount * 100.0) - 1;
                        if (max > 0)
                        {
                            MessageBox.Show(string.Format("The discounted amount cannot be less than the capital. Maximum of {0}% discount may be given to this item.", max), "Percent Discount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PercentDiscount(item);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Can no longer apply discount to this item.", "Percent Discount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    m_receipt.PurchasedItems[item.BarCode].Amount = item.Amount;
                    m_receipt.PurchasedItems[item.BarCode].Description = item.Description + "@PD";
                    m_receipt.PurchasedItems[item.BarCode].Discount = item.Amount * (Convert.ToDouble(input.Value) / 100.0);
                    m_receipt.PurchasedItems[item.BarCode].IsWholeSale = true;
                    UpdatePurchases();
                    UpdateProductDisplay(m_receipt.PurchasedItems[item.BarCode]);
                }

            }
            else
            {
                MessageBox.Show("Select which item to override price", "Price Override", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PriceOverride(clsProductItem item, bool skipapproval=false)
        {
            try
            {
                if (m_receipt.PurchasedItems.Count == 0) return;
                if (!skipapproval && !clsUtil.GetApproval(m_user, UserAccess.Cashier)) return;
                if (item.BarCode != "" && m_receipt.PurchasedItems.ContainsKey(item.BarCode))
                {
                    frmInput input = new frmInput();
                    input.Title = "Override Product Price";
                    input.Caption = "Discounted Amount";
                    input.IsNumericOnly = true;
                    input.Value = (item.Amount * 0.95).ToString();
                    if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        //if ((100-Double.Parse(input.Value)/item.Amount*100) > Properties.Settings.Default.MaxPercentDiscount)
                        //{
                        //    if (!clsUtil.GetApproval(m_user, UserAccess.Manager)) return;
                        //}
                        //else if ((100 - Double.Parse(input.Value) / item.Amount * 100) > (Properties.Settings.Default.MaxPercentDiscount / 2.0))
                        //{
                        //    if (!clsUtil.GetApproval(m_user, UserAccess.Supervisor)) return;
                        //}

                        clsProductItem prod = clsProductItem.SearchProduct(item.BarCode);
                        if (prod != null)
                        {

                            if (Convert.ToDouble(input.Value) <= prod.Capital)
                            {
                                MessageBox.Show("The discounted amount cannot be less than the capital.", "Price Override", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PriceOverride(item, true);
                                return;
                            }

                            //else if (Convert.ToDouble(input.Value) > prod.Amount)
                            //{
                            //    MessageBox.Show("The discounted amount cannot be more than the retail amount.", "Price Override", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    PriceOverride(item, true);
                            //    return;
                            //}

                            if(m_receipt.PurchasedItems[item.BarCode].Category!="E-LOAD")
                                m_receipt.PurchasedItems[item.BarCode].Description = item.Description + "@PO";

                            double amount = Convert.ToDouble(input.Value);
                            m_receipt.PurchasedItems[item.BarCode].Amount = item.Amount;

                            //if (m_receipt.PurchasedItems[item.BarCode].Qty > 1)
                            //{
                            //    m_receipt.PurchasedItems[item.BarCode].Amount = Convert.ToDouble(input.Value) / m_receipt.PurchasedItems[item.BarCode].Qty;
                            //}

                            m_receipt.PurchasedItems[item.BarCode].Discount = Math.Round(item.Amount - amount, 2);
                            m_receipt.PurchasedItems[item.BarCode].IsWholeSale = true;
                            UpdatePurchases();
                            UpdateProductDisplay(m_receipt.PurchasedItems[item.BarCode]);

                        }
                        else
                        {
                            MessageBox.Show(string.Format("Product not found"), "Price Override", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Select which item to override price", "Price Override", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        private void TotalPaymentDiscount()
        {
            if (m_receipt.PurchasedItems.Count == 0) return;
            if (!clsUtil.GetApproval(m_user, UserAccess.Manager)) return;
            frmInput input = new frmInput();
            input.Title = "Additional Discount";
            input.Caption = "Discount Amount";
            input.IsNumericOnly = true;
            input.Value = "0";
            if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Convert.ToDouble(input.Value) > (m_receipt.TotalAmountDue-m_receipt.ItemDiscount) * 0.1)
                {
                    MessageBox.Show("Additional Discount cannot be more than the 10% of the Total Amount Due.", "Additional Discount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TotalPaymentDiscount();
                    return;
                }
                m_receipt.SeniorDiscount = Convert.ToDouble(input.Value);
                UpdatePurchases();
            }

        }
        //private void SeniorDiscount()
        //{
        //    if (m_receipt.PurchasedItems.Count == 0) return;
        //    if (m_receipt.TotalAmountDue > Properties.Settings.Default.SeniorMaxAmount && Properties.Settings.Default.SeniorMaxAmount!=0)
        //    {
        //        m_receipt.SeniorDiscount = Properties.Settings.Default.SeniorMaxAmount * (Properties.Settings.Default.SeniorDiscount / 100);
        //    }
        //    else
        //    {
        //        m_receipt.SeniorDiscount = m_receipt.TotalAmountDue * (Properties.Settings.Default.SeniorDiscount / 100);
        //    }
        //    UpdatePurchases();
        //}

        private void btnQuantity_Click(object sender, EventArgs e)
        {
            ChangeQuantity();
        }

        private void ChangeQuantity()
        {
            if ( !AllowModify()) return;
            if (m_receipt.PurchasedItems.Count == 0) return;
            if (txtBarcode.Text.Trim() == "")
            {
                txtBarcode.Text = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
            }
            if (txtBarcode.Text != "")
            {
                clsProductItem prod = clsProductItem.SearchProduct(txtBarcode.Text);
                if (prod !=null && prod.BarCode != "")
                {
                    if (m_receipt.PurchasedItems.ContainsKey(prod.BarCode))
                    {
                        frmInput input = new frmInput();
                        input.Title = "Quantity";
                        input.Caption = "Quantity";
                        input.Value = m_receipt.PurchasedItems[prod.BarCode].Qty.ToString();
                        input.IsNumericOnly = true;
                        if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            double qty = Convert.ToDouble(input.Value);
                            if (qty > 0)
                            {
                                //if (prod.StocksRemainingQty - Convert.ToDouble(input.Value) < 0)
                                //{
                                //    if (MessageBox.Show("Purchased items is more than the available quantity on stock.\r\nDo you want to continue?", "Out of Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                                //    {
                                //        return;
                                //    }
                                //}
                                //if (m_receipt.PurchasedItems[prod.BarCode].Unit == "pc" && (Convert.ToDouble(input.Value) % 1 != 0))
                                //    MessageBox.Show("Items with a Unit of Qty in pcs can't have a decimal value", "Change Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //else
                                m_receipt.PurchasedItems[prod.BarCode].Qty = Convert.ToDouble(input.Value);
                            }
                            else
                            {
                                m_receipt.PurchasedItems.Remove(prod.BarCode);
                            }
                            UpdatePurchases();
                            if (m_receipt.PurchasedItems.ContainsKey(prod.BarCode))
                                UpdateProductDisplay(m_receipt.PurchasedItems[prod.BarCode]);
                            else
                            {
                                if(m_receipt.PurchasedItems.Count>0)
                                    UpdateProductDisplay(m_receipt.PurchasedItems[dgvPurchase.Rows[0].Cells[0].Value.ToString()]);
                            }
                        }
                        else
                        {
                            UpdateProductDisplay(m_receipt.PurchasedItems[prod.BarCode]);
                        }
                    }


                }

            }
        }

        private void iPOS_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            if (!POSLicense.ValidateLicense(POSLicense.GetRegistryValue("LicenseKey")))
            {
                frmLicenseInfo license = new frmLicenseInfo();
                if (license.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!POSLicense.ValidateLicense(POSLicense.GetRegistryValue("LicenseKey")))
                    {
                        MessageBox.Show("Please contact Allan Rey Sagun @ Leopoldo Jalandoni Street\r\nPob. 5 Midsayap, Cotabato\r\nCellNo.: +639266620157", "License", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                        return;
                    }
                }
                else
                {
                    Application.Exit();
                    return;
                }
            }
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_user = login.m_User;
                ShowSplashScreen();
                mainGreetings.Text = "Hi! I'm " + m_user.UserName.ToUpper() + " at your service";
                UpdateButtons(false);
                BackupData();
                if (m_user.LoginType == (int)UserAccess.Manager || m_user.LoginType == (int)UserAccess.Cashier || m_user.LoginType == (int)UserAccess.Admin)
                {
                    NewCustomer();
                    CheckInitialCash();
                }
            }
            else
            {
                Application.Exit();
            }

        }

        public void CheckInitialCash(bool forceupdate = false)
        {
            double amount = clsInitCash.GetInitialCash(DateTime.Now, m_user.UserId);
            if (amount == 0 || forceupdate)
            {
                clsInitCash initcash = new clsInitCash();
                frmInput payment = new frmInput();
                payment.Title = "Add Cash Amount";
                payment.Caption = "Amount: " + amount.ToString();
                payment.IsNumericOnly = true;
                payment.Value = "0";
                if (payment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    initcash.PrevAmount = amount;
                    initcash.Addedamount = double.Parse(payment.Value);
                    initcash.Amount = amount + double.Parse(payment.Value);
                    if (initcash.Amount < 0)
                    {
                        MessageBox.Show("Please check value.");
                        return;
                    }
                    initcash.Timestamp = DateTime.Now;
                    initcash.UserId = m_user.UserId;
                    initcash.UserName = m_user.UserName;
                    initcash.Save();
                }
            }
        }


        public void CheckDepositCash( bool forceupdate = false )
        {
            double amount = clsDepositCash.GetCashDeposit(DateTime.Now, m_user.UserId);
            if (amount == 0 || forceupdate)
            {
                clsDepositCash depoCash = new clsDepositCash();
                frmInput payment = new frmInput();
                payment.Title = "Deposit Cash Amount";
                payment.Caption = "Amount: " + amount.ToString();
                payment.IsNumericOnly = true;
                payment.Value = "0";
                if (payment.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    depoCash.PrevAmount = amount;
                    depoCash.Addedamount = double.Parse(payment.Value);
                    depoCash.Amount = amount + double.Parse(payment.Value);
                    if (depoCash.Amount < 0)
                    {
                        MessageBox.Show("Please check value.");
                        return;
                    }
                    depoCash.Timestamp = DateTime.Now;
                    depoCash.UserId = m_user.UserId;
                    depoCash.UserName = m_user.UserName;
                    depoCash.Save();
                }
            }
        }


        private static void ShowSplashScreen()
        {
            SpashScreen screen = new SpashScreen();
            screen.ShowDialog();
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (m_receipt != null && m_receipt.TotalDiscountedAmount > 0)
            {
                Print(false);
            }
            else
            {
                Receipt or = new Receipt();
                or.OpenDrawer();
                or.ExecPrint();
                CloseDrawer c = new CloseDrawer();
                c.ShowDialog();
            }

        }

        private void btnUtility_Click(object sender, EventArgs e)
        {
            ShowUtilities();
        }

        private void Logout()
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                frmLogin login = new frmLogin();
                if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ShowSplashScreen();
                    this.Show();
                    m_user = login.m_User;
                    mainGreetings.Text = "Hi! I'm " + m_user.UserName.ToUpper()
                        + " at your service";
                    UpdateButtons(false);

                    NewCustomer();
                    CheckInitialCash();
                }
                else
                {
                    Application.Exit();
                }
            }
        }



        private void btnDiscount_Click(object sender, EventArgs e)
        {
            SelectDiscount();
        }

        private void SelectDiscount()
        {
            if (!AllowModify()) return;
            if (m_receipt.PurchasedItems.Count == 0) return;
            if (txtBarcode.Text.Trim() == "")
            {
                txtBarcode.Text = dgvPurchase.SelectedRows[0].Cells[0].Value.ToString();
            }
            clsProductItem prod = clsProductItem.SearchProduct(txtBarcode.Text);
            frmDiscount disc = new frmDiscount();
            if (disc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                switch (disc.SelectedIndex)
                {
                    case 0: UseWholeSalePrice(prod); break;
                    case 1: PriceOverride(prod); break;
                    case 2: PercentDiscount(prod); break;
                    case 3: UseRetailPrice(prod); break;
                }
            }
            txtBarcode.Text = prod.BarCode;
            txtBarcode.SelectAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private static void ExitApp()
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                
                Application.Exit();
            }
        }

        private void dgvPurchase_SelectionChanged(object sender, EventArgs e)
        {
            UpdateDisplayFromGridSelection();
        }


        private void dgvPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //UpdateDisplayFromGridSelection();
        }

        private void btnVoidReceipt_Click(object sender, EventArgs e)
        {
            if (!AllowModify()) return; 
            VoidReceipt();
        }

        private void VoidReceipt()
        {
            if (clsUtil.GetApproval(m_user, UserAccess.Manager))
            {
                if ((DateTime.Today - m_receipt.TransDate).TotalDays <= 7)
                {
                    if (m_receipt.CashTendered > 0 || RetrieveReceipt())
                    {
                        if (MessageBox.Show("Are you sure you want to void this sale?", "Void Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                        {
                            foreach (clsPurchasedItem item in m_receipt.PurchasedItems.Values)
                            {
                                clsProductItem prod = clsProductItem.SearchProduct(item.BarCode);
                                prod.QtySold -= item.Qty;
                                prod.Save();
                            }
                            if (m_receipt.Delete() == true)
                            {
                                clsAccountInfo act = new clsAccountInfo(m_receipt.Accountid);
                                if (act != null && m_receipt.ChargedAmount > 0)
                                {
                                    string ret = "";
                                    Receipt or = new Receipt();
                                    or.InitializePrinter();
                                    List<string> strmsg = new List<string>();
                                    or.PrintCompanyHeader();
                                    strmsg.Add("");
                                    strmsg.Add("VOID RECEIPT");
                                    ret += or.PrintAppend(strmsg, PrintFontAlignment.Center, PrintFontSize.UnderlineBold); strmsg.Clear();
                                    strmsg.Clear();

                                    strmsg.Add(string.Format("Cashier: {0}", m_user.UserName.ToUpper()));
                                    strmsg.Add(string.Format("Date: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                    strmsg.Add(string.Format("ORNum: {0}", m_receipt.ORNumber));
                                    strmsg.Add("");
                                    strmsg.Add(string.Format("Account Name: {0}", act.AccountName));
                                    strmsg.Add(string.Format("Previous Balance: P {0:0.00}", act.AccountReceivable));
                                    strmsg.Add(string.Format("Amount Returned: P {0:0.00}", m_receipt.ChargedAmount));
                                    strmsg.Add(string.Format("Current Balance: P {0:0.00}", act.AccountReceivable - m_receipt.ChargedAmount));
                                    ret += or.PrintAppend(strmsg, PrintFontAlignment.Left, PrintFontSize.Regular);
                                    or.FormFeed();
                                    or.OpenDrawer();
                                    or.ExecPrint(ret);
                                    strmsg.Clear();

                                    act.YTDTransaction -= m_receipt.TotalDiscountedAmount;
                                    act.PrincipalBalance -= m_receipt.ChargedAmount;
                                    act.Save();

                                }
                                MessageBox.Show("Sale was successfully cancelled.", "Void Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to cancel the Sale.", "Void Receipt", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            NewCustomer();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not allowed to void receipt. Transaction date more than a week.", "Void Receipt", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    NewCustomer();
                }
                m_tempreceipt = null;
            }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            PayAccount();
        }
        private void ShowUtilities()
        {
            //ManagersTask task = new ManagersTask(user,this);
            //task.ShowDialog();
            m_UtilityWindow = new frmUtility(m_user, this);
            m_UtilityWindow.Show();
            m_UtilityWindow.BringToFront();
        }

        private bool AllowModify()
        {
            return m_AllowEditing;
            //if (m_receipt.CashTendered > 0)
            //{
            //    MessageBox.Show("Not allowed to modify transaction", "Modify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            //else return true;
        }
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }
        bool isBackedup = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute == 0 && isBackedup == false)
            {
                BackupData();
            }
            else if(DateTime.Now.Minute > 0)
            {
                isBackedup = false;
            }
        }
        private void BackupData()
        {
            if(!Directory.Exists(Properties.Settings.Default.BackupPath))
            {
                try
                {
                    Directory.CreateDirectory(Properties.Settings.Default.BackupPath);
                    dbConnect.Backup();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Invalid backup path", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                dbConnect.Backup();
            }
        }

        private void dgvPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDisplayFromGridSelection();
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            
        }

        private void dtNow_ValueChanged( object sender, EventArgs e )
        {
            //// Set system date and time
            //SystemTime updatedTime = new SystemTime();
            //updatedTime.Year = (ushort)dtNow.Value.Year;
            //updatedTime.Month = (ushort)dtNow.Value.Month;
            //updatedTime.Day = (ushort)dtNow.Value.Day;
            //updatedTime.Hour = (ushort)DateTime.Now.Hour;
            //updatedTime.Minute = (ushort)DateTime.Now.Minute;
            //updatedTime.Second = (ushort)DateTime.Now.Second;
            //// Call the unmanaged function that sets the new date and time instantly
            //Win32SetSystemTime(ref updatedTime);
            if (dtNow.Value.Date != m_selectedDate.Date)
            {
                if (setDate(dtNow.Value.ToShortDateString()))
                {
                    m_selectedDate = dtNow.Value;
                }
                else
                {
                    dtNow.Value = m_selectedDate;
                }
            }
        }

        private bool setDate( string dateInYourSystemFormat )
        {
            if((m_ActualDate-Convert.ToDateTime(dateInYourSystemFormat)).TotalDays<0)
            {
                if (MessageBox.Show("Selected date should not be greater than the initial date. Do you want to continue?", "Set Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return false;
            }
            var proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.CreateNoWindow = true;
            proc.FileName = @"C:\Windows\System32\cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/C date " + dateInYourSystemFormat;
            try
            {
                System.Diagnostics.Process.Start(proc);
            }
            catch
            {
                MessageBox.Show("Error to change time of your system");
                return false;
            }
            return true;
        }

        private void btnNow_Click( object sender, EventArgs e )
        {
            if (m_ActualDate.Date != dtNow.Value.Date)
                dtNow.Value = m_ActualDate;
        }

        private void myPosWide_FormClosing( object sender, FormClosingEventArgs e )
        {
            if(m_ActualDate.Date!=dtNow.Value.Date)
                setDate(m_ActualDate.ToShortDateString());
        }

        private void myPosWide_Activated( object sender, EventArgs e )
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));

        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            SaveTemp();
        }

        private void btnOpen_Click( object sender, EventArgs e )
        {
            OpenTemp();
        }

        private void btnCancelPayment_Click( object sender, EventArgs e )
        {
            CancelPayment();
        }

        private void btnLogout_Click( object sender, EventArgs e )
        {
            if (!clsUtil.GetApproval(m_user, UserAccess.Supervisor)) return;
            frmChkOutLight c = new frmChkOutLight(m_user.UserId);
            c.ShowDialog();
        }

        private void main1_Paint( object sender, PaintEventArgs e )
        {

        }

        private void btnLoadingStation_Click(object sender, EventArgs e)
        {
            ShowLoadingStation();
        }

        private static void ShowLoadingStation()
        {
            frmLoadMenu loading = new frmLoadMenu(m_user);
            loading.Show();
        }

    }
}
