using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motorbike.ucKhachHang
{
    public partial class ShowCheckout : MetroForm
    {
        public ShowCheckout()
        {
            InitializeComponent();
        }
        public DataGridView dgv
        {
            get
            {
                return DGV_Show;
            }
            set
            {
                DGV_Show = value;
            }
        }
        public string total
        {
            get
            {
                return txtTOTAL.Text;
            }
            set
            {
                txtTOTAL.Text = value;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Show rptOrder = new Show();
            rptOrder.cusID = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            rptOrder.Show();
        }
    }
}
