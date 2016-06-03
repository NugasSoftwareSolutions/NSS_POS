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
    public partial class Main : Form
    {
        private Receipt mReceipt=null;
        private bool mAddItem = true;
        public string UserId = "";
        List<clsProductItem> lstFoodItems = null;

        public Main()
        {
            InitializeComponent();
            ClearFields();
        }
        private string GetSelectedCustomer()
        {
            if (cboName.SelectedIndex >= 0)
                return cboName.Items[cboName.SelectedIndex].ToString();
            else
                return "";
        }
        private void AcceptOrder()
        {
            if (mReceipt != null && mReceipt.PurchasedItems.Count>0)
            {
                if (mReceipt.TransDate.ToShortDateString() != DateTime.Now.ToShortDateString() && ValidateAdmin() == false)
                {
                    
                }
                else
                {
                    frmPayment pay = new frmPayment();
                    if (mReceipt.CashTendered == 0 || mReceipt.CashTendered < Convert.ToDouble(lblTotal.Text))
                        pay.PaymentAmount = Convert.ToDouble(lblTotal.Text);
                    else
                        pay.PaymentAmount = mReceipt.CashTendered;
                    if (pay.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        mReceipt.CashTendered = pay.PaymentAmount;
                        mReceipt.CustomerName = (GetSelectedCustomer() != "" ? GetSelectedCustomer() : mReceipt.CustomerName);
                        UpdateList();
                        mReceipt.Save();
                        lblOR.Text = mReceipt.ToString();
                        cboName.SelectedItem = mReceipt.CustomerName;
                        txtInput.SelectAll();

                        Profile _myProfile = new Profile();
                        _myProfile.ReadXML();
                        if (_myProfile.EnableAutoPrint == true)
                        {
                            Print();
                        }
                        else if (_myProfile.PrintReceipt)
                        {
                            if (MessageBox.Show("Would you like to print a receipt?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                            {
                                Print();
                            }
                        }
                    }
                }
            }
            else
            {
                txtInput.Text = "";
                MessageBox.Show("No Transaction to Process", "Accept Order",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            txtInput.SelectAll();
            txtInput.Focus();
        }

        private void CancelOrder()
        {
            if (mReceipt != null)
            {
                //tsStatus.Text = "Status: Order Canceled";
                mReceipt = null;
                ClearFields();
                txtInput.SelectAll();
            }
            else
            {
                txtInput.Text = "";
                MessageBox.Show("No Transaction to Process", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtInput.SelectAll();
            txtInput.Focus();
        }
        
        private void Setup(string barcode="")
        {
            if (ValidateAdmin() == true)
            {
                frmSetup setup = new frmSetup();
                setup.mBarcode = barcode;
                setup.ShowDialog();
                //UpdateFoodItems();
            }
        }

        private void Summary()
        {
            frmSummary summary = new frmSummary();
            summary.AccessLevel = (UserId.ToLower() == "alrey" ? 1 : 0);
            if (summary.ShowDialog() == System.Windows.Forms.DialogResult.OK && summary.m_SelectedReceipt!=null)
            {
                mReceipt = summary.m_SelectedReceipt;
                
                UpdateList();
            }
            txtInput.SelectAll();
            txtInput.Focus();

        }

        private void NewCustomer()
        {
            ClearFields();
            mReceipt = new Receipt();

            if (mReceipt.CustomerName == null)
            {
                mReceipt = null;
                return;
            }
            dbConnect connect = new dbConnect();
            Receipt OR = new Receipt();
            OR.ORNumber = connect.GetNextORNumber();
            if (OR.ORNumber > 0)
            {
                mReceipt.ORNumber = OR.ORNumber + 1;
                lblOR.Text = mReceipt.ToString();
                cboName.SelectedItem = mReceipt.CustomerName;
                mReceipt.ORNumber = 0;
            }
            else
            {
                mReceipt.ORNumber = 1;
                lblOR.Text = mReceipt.ToString();
                cboName.SelectedItem = mReceipt.CustomerName;
                mReceipt.ORNumber = 0;
            }
            radAdd.Checked = true;
            txtInput.SelectAll();
            txtInput.Focus();
            

        }
        private void ClearFields()
        {
            lblAmount.Text = "0.00";
            lblCash.Text = "0.00";
            lblChange.Text = "0.00";
            lblDescription.Text = "";
            lblQuantity.Text = "";
            lblTotal.Text = "0.00";
            lblOR.Text = "Official Receipt No.:";
            cboName.SelectedItem = "(Customer)";
            lblTable.Text = "Table:";
            dgv.Rows.Clear();
            mAddItem = true;
            AddRemoveItem();
            txtInput.SelectAll();
            txtInput.Focus();

        }

        private void RetrieveOrder()
        {

            if (ValidateAdmin()==true)
            {
                frmRetrieve retrieve = new frmRetrieve();
                if (retrieve.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (retrieve.myReceipt != null && retrieve.myReceipt.ORNumber > 0)
                    {
                        mReceipt = retrieve.myReceipt;
                        UpdateList();
                    }
                    else
                    {
                        MessageBox.Show("Reference Number not found.", "Retrieve Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            txtInput.SelectAll();
            txtInput.Focus();
        }

        private bool ValidateAdmin()
        {
            if (UserId.ToLower() == "alrey") return true;
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (login.UserId == "alrey")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("This requires an Admin credentials.", "Credentials", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            return false;
        }
        private void PrintOrder()
        {
            if (mReceipt != null)
            {
                //tsStatus.Text = "Status: Printing Feature Not Yet Available";
                txtInput.SelectAll();
            }
            else
            {
                //tsStatus.Text = "Status: Select New Customer First";
            }
            txtInput.SelectAll();
            txtInput.Focus();
        }
        private void UpdateList()
        {
            if (mReceipt != null)
            {
                //lstOrders.Items.Clear();
                dgv.Rows.Clear();
                foreach (KeyValuePair<string, clsPurchasedItem> fi in mReceipt.GetPurchasedItems())
                {
                    if (fi.Value.Qty > 0)
                    {
                        AddItemToGrid(fi.Value);
                        //lstOrders.Items.Add(fi.Value.Description + " : " + fi.Value.Qty + " x " + fi.Value.Amount.ToString("0.00") + " = " + (fi.Value.Qty * fi.Value.Amount).ToString("0.00"));
                    }
                }
                lblTotal.Text = mReceipt.TotalAmount.ToString("0.00");
                lblChange.Text = (mReceipt.ChangeAmount<0? string.Format("({0:0.00})",mReceipt.ChangeAmount*-1):mReceipt.ChangeAmount.ToString("0.00"));
                lblChange.ForeColor = (mReceipt.ChangeAmount < 0 ? Color.Red : Color.Black);
                lblCash.Text = mReceipt.CashTendered.ToString("0.00");
                lblOR.Text = mReceipt.ToString();
                cboName.SelectedItem = mReceipt.CustomerName;
                //lblTable.Text = "Table: " + mReceipt.TableNum;

                //lblCustInfo.Text = mReceipt.ToString();
            }
            txtInput.SelectAll();
            txtInput.Focus();
        }
        //private List<clsProductItem> FindItems()
        //{
        //    List<clsProductItem> fi = new List<clsProductItem>();
        //    dbConnect connect = new dbConnect();

        //    connect.ExecuteQuery("Select * from Food Order by ID",fi);

        //    connect.Close();
        //    return fi;
        //}
        //private clsProductItem FindItems(string barcode)
        //{
        //    clsProductItem fi = new clsProductItem();
        //    dbConnect connect = new dbConnect();
            
        //    connect.ExecuteQuery("Select * from Food where id ='" + barcode + "'", fi);

        //    connect.Close();
        //    return fi;
        //}
        //private clsProductItem AddProductToReceipt(string item)
        //{
        //    clsProductItem fi=null;
        //    dbConnect connect = new dbConnect();
        //    if (mReceipt != null)
        //    {
        //        fi = new clsProductItem();
        //        connect.ExecuteQuery("Select * from Food Where ID = '" + item + "'", fi);
        //        if (fi.BarCode != "")
        //        {
        //            Dictionary<string, clsProductItem> tmpFI = mReceipt.GetPurchasedItems();
        //            if(tmpFI.ContainsKey(item) == false)
        //            {
        //                fi.UserID = UserId;
        //                mReceipt.AddPurchasedItem(fi);
        //            }
        //            else
        //            {
        //                fi = tmpFI[item];
        //                fi.UserID = UserId;
        //            }
        //        }
        //        else
        //        {
        //            fi = null;
        //        }
        //    }

        //    connect.Close();
        //    return fi;
        //}

        private void AddRemoveItem()
        {
            txtInput.Focus();
            if (mAddItem)
            {
                //lstOrders.BackColor = Color.PaleGreen;
                dgv.ForeColor = Color.Black;
                this.BackColor = Color.Black;
            }
            else
            {
                //lstOrders.BackColor = Color.Red;
                dgv.ForeColor = Color.Red;
                this.BackColor = Color.Red;
            }
            txtInput.SelectAll();
            txtInput.Focus();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ValidateInput();
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.F1: RetrieveOrder();
                        frmInput input = new frmInput();
                        if (mReceipt != null)
                        {
                            input.Caption = "Customer:";
                            input.InputValue = mReceipt.CustomerName;
                            input.ShowDialog();
                            mReceipt.CustomerName = input.InputValue;
                            cboName.SelectedItem = input.InputValue;
                            mReceipt.Save();
                        }
                        break;
                    case Keys.F2: NewCustomer(); break;
                    case Keys.F3: AcceptOrder(); break;
                    case Keys.F4: ValidateOrder(true); break;
                    case Keys.F5: RetrieveOrder(); break;
                    case Keys.F6: mAddItem = true; AddRemoveItem(); break;
                    case Keys.F7: mAddItem = false; AddRemoveItem(); break;
                    case Keys.F8: Setup(); break;
                    case Keys.F9: Summary(); break;
                    case Keys.F10: Print(); break;
                    case Keys.F11: Settings(); break;
                }
            }
        }

        private void ValidateInput()
        {
            txtInput.Text = txtInput.Text.ToUpper();
            txtInput.SelectAll();
            switch (txtInput.Text.ToUpper())
            {
                case "ACCEPT ORDER": txtInput.Text = ""; AcceptOrder(); break;
                case "CANCEL ORDER": txtInput.Text = ""; CancelOrder(); break;
                case "NEW CUSTOMER": txtInput.Text = ""; NewCustomer(); break;
                case "RETRIEVE ORDER": txtInput.Text = ""; RetrieveOrder(); break;
                case "ADD ITEMS": txtInput.Text = ""; mAddItem = true; AddRemoveItem(); break;
                case "REMOVE ITEMS": txtInput.Text = ""; mAddItem = false; AddRemoveItem(); break;
                case "SETUP BARCODE": txtInput.Text = ""; Setup(); break;
                case "SUMMARY": txtInput.Text = ""; Summary(); break;
                case "PRINT": txtInput.Text = ""; Print(); break;
                case "EXIT": this.Close(); break;
                case "SETTINGS": Settings(); break;
                default:
                    ValidateOrder();
                    //else if (txtInput.Text.Substring(0, 2) == "OR" || txtInput.Text.Substring(0, 5) == "TABLE")
                    //{
                    //    frmRetrieve retrieve = new frmRetrieve();
                    //    retrieve.TableNum = txtInput.Text;
                    //    retrieve.RetrieveReceipt();
                    //    if (retrieve.myReceipt != null)
                    //    {
                    //        mReceipt = retrieve.myReceipt;
                    //        UpdateList();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Reference Number not found.", "Retrieve Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //}
                    //else
                    //{
                    //    //tsStatus.Text = "Status: Command Not Found";
                    //}
                    break;
            }
            txtInput.SelectAll();
            txtInput.Focus();
        }

        private void ValidateOrder(bool enterqty=false)
        {
            if (mReceipt == null) NewCustomer();
            if (mReceipt != null)// && (txtInput.Text.Substring(0, 4) == "RICE" || txtInput.Text.Substring(0, 4) == "SOFT" || txtInput.Text.Substring(0, 2) == "V0")
            {
                clsProductItem fi = AddProductToReceipt(txtInput.Text.ToUpper());
                if (fi != null)
                {
                    if (mAddItem)
                    {
                        if (enterqty)
                        {
                            frmQty fqty = new frmQty();
                            fqty.Quantity = fi.Qty;
                            if (fqty.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                fi.Qty = fqty.Quantity;
                            }
                        }
                        else
                        {
                            fi.Qty++;
                        }
                    }
                    else
                    {
                        if (fi.Qty > 0)
                        {
                            fi.Qty -= 1;
                        }
                    }
                    if (fi.Qty > 0)
                    {
                        lblDescription.Text = fi.Description;
                        lblAmount.Text = fi.Amount.ToString();
                        lblQuantity.Text = fi.Qty.ToString();
                    }
                    else
                    {
                        mReceipt.RemovePurchasedItem(fi);
                        lblDescription.Text = "";
                        lblAmount.Text = "0.00";
                        lblQuantity.Text = "";
                    }
                    // tsStatus.Text = "Status: Item Found!";
                }
                else
                {
                    // tsStatus.Text = "Status: Item Not Found!";
                    Setup(txtInput.Text.ToUpper());
                }

                UpdateList();
            }
        }


        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomer();
        }

        private void Main_Enter(object sender, EventArgs e)
        {
            txtInput.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptOrder();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ValidateOrder(true);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            RetrieveOrder();
        }

        private void radAdd_CheckedChanged(object sender, EventArgs e)
        {
            mAddItem = radAdd.Checked;
            AddRemoveItem();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            Setup();
        }

        private static void Settings()
        {
            frmCompanyProfile frm = new frmCompanyProfile();
            frm.ShowDialog();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            Summary();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void Print()
        {
            if (mReceipt != null)
            {
                if (mReceipt != null && mReceipt.ORNumber > 0 && mReceipt.TotalAmount > 0)
                {
                    mReceipt.Print();
                }
                else
                {
                    if (mReceipt.TotalAmount > 0)
                    {
                        DialogResult dlg = MessageBox.Show("Would you like to enter payment now?", "Payment", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dlg == DialogResult.Yes)
                        {
                            AcceptOrder();
                            mReceipt.Print();
                        }
                        else if (dlg == DialogResult.No)
                        {
                            mReceipt.Print();
                        }
                    }
                    else
                    {
                        MessageBox.Show("There's item purchased!", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            txtInput.SelectAll();
            txtInput.Focus();
           
        }

        private void lstOrders_KeyDown(object sender, KeyEventArgs e)
        {
            txtInput.SelectAll();
            txtInput.Focus();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings();
        }
        private void AddItemToGrid(clsPurchasedItem fitem)
        {
            int rowidx = dgv.Rows.Add();
            dgv.Rows[rowidx].Cells[0].Value = fitem.BarCode;
            dgv.Rows[rowidx].Cells[1].Value = fitem.Description;
            dgv.Rows[rowidx].Cells[2].Value = fitem.Amount;
            dgv.Rows[rowidx].Cells[3].Value = fitem.Qty;
            dgv.Rows[rowidx].Cells[4].Value = fitem.Amount * fitem.Qty;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UserId = login.UserId;
                this.Text = string.Format("Kawayanan Food Hauz - [Logged-on User: {0}] {1}", UserId, DateTime.Now.ToString());
                txtInput.Focus();
                UpdateFoodItems();
                //UpdatePending();
                //if(frmOrders.Visible==false) frmOrders.Show();
                //frmOrders.TopMost = true;
                btnInventory.Visible = true;
                Profile _myProfile = new Profile();
                _myProfile.ReadXML();
                cboName.Items.Clear();
                foreach (String emp in _myProfile.Employees)
                {
                    cboName.Items.Add(emp);
                }
                cboName.SelectedItem = "(Customer)";
             }
            else
            {
                this.Close();
            }

        }

        //private void UpdateFoodItems()
        //{
        //    lstItems.Items.Clear();

        //    lstFoodItems = new List<clsProductItem>();
        //    lstFoodItems = FindItems();
        //    foreach (clsProductItem fi in lstFoodItems)
        //    {
        //        Control[] ctrls = (Control[])this.Controls.Find("btn" + fi.BarCode, true);
        //        if (ctrls.Length == 0)
        //        {
        //            lstItems.Items.Add(fi.BarCode);
        //        }
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = string.Format("Kawayanan Food Hauz - [Logged-on User: {0}] {1}", UserId, DateTime.Now.ToString());
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgv.SelectedRows.Count == 1 && dgv.SelectedRows[0].Cells[0].Value != null)
            //{
            //    txtInput.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
            //    txtInput.SelectAll();
            //    txtInput.Focus();
            //}
            //else
            //{
            //    if(dgv.Rows.Count>0)
            //        dgv.Rows[0].Selected = true;
            //}
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count == 1 && dgv.SelectedRows[0].Cells[0].Value != null)
            {
                txtInput.Text = dgv.SelectedRows[0].Cells[0].Value.ToString();
                txtInput.SelectAll();
                txtInput.Focus();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (sender.GetType()==typeof(Button))
            {
                Button btnMenu = (Button)sender;
                string name = btnMenu.Name.Remove(0,3);
                txtInput.Text = name;
                ValidateInput();
            }
            txtInput.SelectAll();
            txtInput.Focus();
        }

        private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstItems.SelectedIndex > -1)
            {
                txtInput.Text = lstItems.SelectedItem.ToString();
                ValidateInput();
            }
        }

        private void lstItems_MouseClick(object sender, MouseEventArgs e)
        {
           //UpdateSelection();
        }

        //private void UpdateSelection()
        //{
        //    if (lstItems.SelectedIndex > -1)
        //    {
        //        clsProductItem fi = FindItems(lstItems.SelectedItem.ToString());
        //        if (fi != null)
        //        {
        //            Double amt = fi.Amount;
        //            txtInput.Text = fi.BarCode;
        //            lblDescription.Text = fi.Description;
        //            lblAmount.Text = String.Format("{0:0.00}", amt);
        //        }
        //    }
        //}

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelection();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            frmProdSetup inventory = new frmProdSetup();
            inventory.ShowDialog();
        }
        
        private void btnGoodDay_Click(object sender, EventArgs e)
        {
            //frmOrders.Greetings();
        }

        private void btnThankYou_Click(object sender, EventArgs e)
        {
            //frmOrders.ThankYou();
        }

        int adCtr = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            string[] strfile = System.IO.Directory.GetFiles("ads");

            int count = System.IO.Directory.GetFiles("ads").Length;

            if (adCtr > strfile.Length - 1) adCtr = 0;
            string fname = "ads\\" + System.IO.Path.GetFileName(strfile[adCtr]);
            picAd.Image = Image.FromFile(fname);
            adCtr++;
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboName.SelectedIndex>=0 && mReceipt!=null)
                mReceipt.CustomerName = cboName.SelectedItem.ToString();
            txtInput.Focus();
        }
    }
}
