using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;

namespace Motorbike.ucNhanVien
{
    public partial class frmThongTinBaoHiem : MetroForm
    {
        public MetroTextBox txtSobaohiem
        {
            get
            {
                return txtEID;
            }
            set
            {
                txtEID = value;
            }
        }
        public string insuranceID
        {
            get
            {
                return txtInsuranceID.Text;
            }
            set
            {
                txtInsuranceID.Text = value;
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
        public DateTime ExpBuy
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
        public string Issuedby
        {
            get
            {
                return txtISSUEDBY.Text;
            }
            set
            {
                txtISSUEDBY.Text = value;
            }
        }
        public string Hospital
        {
            get
            {
                return txtHospital.Text;
            }
            set
            {
                txtHospital.Text = value;
            }
        }
        public string EID
        {
            get
            {
                return txtEID.Text;
            }
            set
            {
                txtEID.Text = value;
            }
        }

        public frmThongTinBaoHiem()
        {
            InitializeComponent();
        }
    }
}
