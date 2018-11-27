using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
namespace Motorbike.ucKhachHang
{
    public partial class frmBill : MetroForm
    {
        public MetroTextBox txtCustomerID
        {
            get
            {
                return txtCUSID;
            }
            set
            {
                txtCUSID = value;
            }
        }
        public string BID
        {
            get
            {
                return txtBID.Text;
            }
            set
            {
                txtBID.Text = value;
            }
        }
        public DateTime DateBuy
        {
            get
            {
                return dtpDateBuy.Value;
            }
            set
            {
                dtpDateBuy.Value = value;
            }
        }
        public string TotalMoney
        {
            get
            {
                return txtTotalMoney.Text;
            }
            set
            {
                txtTotalMoney.Text= value;
            }
        }
        public string Quantity
        {
            get
            {
                return txtQuantity.Text;
            }
            set
            {
                txtQuantity.Text = value;
            }
        }
        public string MOTOID
        {
            get
            {
                return txtMOTOID.Text;
            }
            set
            {
                txtMOTOID.Text = value;
            }
        }
        public string CUSID
        {
            get
            {
                return txtCUSID.Text;
            }
            set
            {
                txtCUSID.Text = value;
            }
        }
        public frmBill()
        {
            InitializeComponent();
        }
    }
}
