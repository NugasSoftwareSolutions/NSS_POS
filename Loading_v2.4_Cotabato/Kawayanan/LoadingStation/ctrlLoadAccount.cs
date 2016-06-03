using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class.Load;

namespace AlreySolutions.LoadingStation
{
    public partial class ctrlLoadAccount : UserControl
    {
        public delegate void OnClickHandler(int LoadId); 
        public OnClickHandler OnClick;
        public ctrlLoadAccount()
        {
            InitializeComponent();
        }
        private Image _Picture;
        public Image Picture
        {
            get { return _Picture; }
            set {
                _Picture = value;
                imgPic.Image = value;
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { 
                _description = value;
                lblDescription.Text = _description;
            }
        }

        private LoadAccountType _LoadType;

        public LoadAccountType LoadType
        {
            get { return _LoadType; }
            set { 
                _LoadType = value;
                switch (_LoadType)
                {
                    case LoadAccountType.GCash: this.BackColor = Color.RoyalBlue; break;
                    case LoadAccountType.SCash: this.BackColor = Color.Green; break;
                    case LoadAccountType.LoadWallet: this.BackColor = Color.OrangeRed; break;
                    case LoadAccountType.ELoad: this.BackColor = Color.DeepSkyBlue; break;

                }
                
            }
        }

        private int _loadId;

        public int LoadId
        {
            get { return _loadId; }
            set { _loadId = value; }
        }


        private void ctrlLoadAccount_Load(object sender, EventArgs e)
        {
        }

        private void imgPic_Click(object sender, EventArgs e)
        {
            if(OnClick!=null)
            {
                OnClick(_loadId);
            }
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
            if(OnClick!=null)
            {
                OnClick(_loadId);
            }
        }


    }
}
