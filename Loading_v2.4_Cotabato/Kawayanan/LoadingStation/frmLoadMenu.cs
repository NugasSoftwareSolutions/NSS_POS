using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class.Load;
using AlreySolutions.Class;
using System.IO;
using System.Runtime.InteropServices;

namespace AlreySolutions.LoadingStation
{
    public partial class frmLoadMenu : Form
    {
        private List<clsLoadAccount> _mLoadAccounts=null;
        private List<ctrlLoadAccount> _mCtrls = new List<ctrlLoadAccount>();
        private clsUsers _mUser = null;
        public frmLoadMenu(clsUsers user)
        {
            InitializeComponent();
            _mLoadAccounts = new List<clsLoadAccount>();
            _mUser = user;
        }

        
        private void frmLoadMenu_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
           _mLoadAccounts = clsLoadAccount.GetLoadAccounts();
            DisplayAccounts();
        }

        private void DisplayAccounts()
        {
            if (_mLoadAccounts != null)
            {
                clsLoadAccount newact = new clsLoadAccount();
                newact.LoadType = LoadAccountType.New;
                newact.Description = "Add/Edit Account";
                newact.LoadId = -1;

                FileStream fs;
                BinaryReader br;
                fs = new FileStream(Application.StartupPath + "\\images\\addLoadAccount.png", FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                newact.ImgFile = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                _mLoadAccounts.Add(newact);
                int margin = 10;
                int left = 5, top = margin, ctr = 1;
                foreach(clsLoadAccount a in _mLoadAccounts)
                {
                    ctrlLoadAccount btn = CreateButton(a);
                    btn.Left = left;
                    btn.Top = top;
                    btn.Width = Properties.Settings.Default.LoadBtnSize;
                    btn.Height = Properties.Settings.Default.LoadBtnSize;
                    pnlLoadAccount.Controls.Add(btn);
                    if (ctr >= Properties.Settings.Default.MaxLoadBtnCnt)
                    {
                        left =5;
                        top += Properties.Settings.Default.LoadBtnSize + margin;
                        ctr = 0;
                    }
                    else
                    {
                        left += Properties.Settings.Default.LoadBtnSize + margin;
                    }
                    ctr++;
                }
                pnlLoadAccount.Width = ((Properties.Settings.Default.LoadBtnSize + margin) * Properties.Settings.Default.MaxLoadBtnCnt) + margin;
                if (pnlLoadAccount.VerticalScroll.Visible)
                {
                    pnlLoadAccount.Width += 20;
                    
                }            

                //this.Height = ((Properties.Settings.Default.LoadBtnSize + margin) * (_mLoadAccounts.Count / Properties.Settings.Default.MaxLoadBtnCnt+ 1)) + margin;// top + (int)(Properties.Settings.Default.LoadBtnSize * 1.25);
                //this.Top = 0;
                //this.Left = 0;
                //this.Left = (SystemInformation.VirtualScreen.Width - this.Width) / 2;
                //this.Top = (SystemInformation.VirtualScreen.Height - this.Height) / 2;
                
            }
        }

        private ctrlLoadAccount CreateButton(clsLoadAccount a)
        {
            ctrlLoadAccount btn = new ctrlLoadAccount();
            btn.Name = "btn" + a.MobileNum;
            btn.Description = a.Description;
            btn.LoadType = a.LoadType;
            btn.LoadId = a.LoadId;
            //btn.Picture = 
            if (a.ImgFile != null)
            {
                MemoryStream mem = new MemoryStream(a.ImgFile);
                btn.Picture = Image.FromStream(mem);
                mem.Close();
            }
            else
            {
                btn.Picture = null;
            }
            
            btn.OnClick += new ctrlLoadAccount.OnClickHandler(LoadAccount_Click);
            return btn;
        }

        private void LoadAccount_Click(int LoadId)
        {
            clsLoadAccount a = _mLoadAccounts.Find(x => x.LoadId == LoadId);
            if (a != null)
            {
                //this.Close();
                if (a.LoadType == LoadAccountType.GCash)
                {
                    frmGlobeGCashTrans ec = new frmGlobeGCashTrans(a);
                    LoadMenuForm(ec);
                    //ec.Left = 0;
                    //ec.Top = 0;
                    //ec.ShowDialog();
                }else if (a.LoadType == LoadAccountType.SCash)
                {
                    frmSmartMoneyTrans ec = new frmSmartMoneyTrans(a);
                    LoadMenuForm(ec);
                    //ec.Left = 0;
                    //ec.Top = 0;
                    //ec.ShowDialog();
                }
                else if (a.LoadType == LoadAccountType.ELoad)
                {
                    frmELoadTrans el = new frmELoadTrans(a);
                    LoadMenuForm(el);
                    //el.Left = 0;
                    //el.Top = 0;
                    //el.ShowDialog();
                }
                else if (a.LoadType == LoadAccountType.New)
                {
                    frmLoadAccounts act = new frmLoadAccounts(_mUser);
                    act.ShowDialog();
                    //LoadMenuForm(act);
                    pnlLoadAccount.Controls.Clear();
                    _mLoadAccounts = clsLoadAccount.GetLoadAccounts();
                    DisplayAccounts();
                }
                else
                {
                    frmLoadWalletTrans lw = new frmLoadWalletTrans(a);
                    LoadMenuForm(lw);
                    //lw.Left = 0; ;
                    //lw.Top = 0; ;

                    //lw.ShowDialog();
                }
            }
        }

        private void frmLoadMenu_Resize(object sender, EventArgs e)
        {

        }

        private void frmLoadMenu_ResizeEnd(object sender, EventArgs e)
        {
            this.Controls.Clear();
            DisplayAccounts();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public static void LoadMenuForm( Form frm)
        {            
            Form Openfrm = Application.OpenForms[frm.Name];
            if (Openfrm != null)//meaning form is already open,just bring it to Front
            {
                Openfrm.BringToFront();
            }
            else
            {
                frm.MdiParent = frmLoadMenu.ActiveForm;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                //frm.Dock = DockStyle.Fill;
                frm.Show();
                frm.BringToFront();
            }
        }

        private void pnlLoadAccount_Resize(object sender, EventArgs e)
        {
        }
    }
}
