using MetroFramework.Controls;
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
using Motorbike.ucHeThong;

namespace Motorbike
{
    public partial class Form1 : MetroForm
    {
        private static Form1 _frmMain;
        public MetroPanel MetroContainer
        {
            get
            {
                return this.mPanelChinh;
            }
            set
            {
                this.mPanelChinh = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        public static Form1 FrmMain
        {
            get
            {
                if(_frmMain==null)
                {
                    _frmMain = new Form1();
                }
                return _frmMain;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _frmMain = this;
            ucDangNhap ucDN = new ucDangNhap();
            ucDN.Dock = DockStyle.Fill;
            _frmMain.MetroContainer.Controls.Add(ucDN);
            _frmMain.MetroContainer.Controls["ucDangNhap"].BringToFront();
        }

        private void mPanelChinh_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
