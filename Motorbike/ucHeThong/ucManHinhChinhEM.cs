using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Motorbike.ucNhanVien;
using MetroFramework;
using MetroFramework.Controls;
using Motorbike.ucKhachHang;
using Motorbike.ucMotorbike;

namespace Motorbike.ucHeThong
{
    public partial class ucManHinhChinhEM : UserControl
    {
        int changePointX = 0;
        int dvDichChuyen = 50;
        string ucName = "";
        public ucManHinhChinhEM()
        {
            InitializeComponent();
        }


        private void btn_Click(object sender, EventArgs e)
        {
            MetroTile metroTile = (MetroTile)sender;
            ucName = metroTile.Tag.ToString();
            timerManHinhChinh.Start();
        }

        private void timerManHinhChinh_Tick(object sender, EventArgs e)
        {
            if (changePointX >= mPanelContainer.Size.Width)
            {
                timerManHinhChinh.Stop();

                switch (ucName)
                {
                    case "ucCustomer":
                        {
                            ucHoSoKhachHang ucKH = new ucHoSoKhachHang();
                            ucKH.Dock = DockStyle.Fill;

                            Form1.FrmMain.MetroContainer.Controls.Add(ucKH);
                            Form1.FrmMain.MetroContainer.Controls["ucHoSoKhachHang"].BringToFront();
                            foreach (ucManHinhChinh uc in Form1.FrmMain.MetroContainer.Controls.OfType<ucManHinhChinh>())
                            {
                                Form1.FrmMain.MetroContainer.Controls.Remove(uc);
                            }
                            break;
                        }
                    case "ucManageMotorbike":
                        {
                            InforMotorbike ucKH = new InforMotorbike();
                            ucKH.Dock = DockStyle.Fill;

                            Form1.FrmMain.MetroContainer.Controls.Add(ucKH);
                            Form1.FrmMain.MetroContainer.Controls["InforMotorbike"].BringToFront();
                            foreach (ucManHinhChinh uc in Form1.FrmMain.MetroContainer.Controls.OfType<ucManHinhChinh>())
                            {
                                Form1.FrmMain.MetroContainer.Controls.Remove(uc);
                            }
                            break;
                        }
                }

            }
            else
            {
                changePointX += dvDichChuyen;
                mPanelContainer.Location = new Point(changePointX, 0);
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            ucDangNhap ucDangNhap = new ucDangNhap();
            ucDangNhap.Dock = DockStyle.Fill;
            Form1.FrmMain.MetroContainer.Controls.Add(ucDangNhap);
            Form1.FrmMain.MetroContainer.Controls["ucDangNhap"].BringToFront();
            foreach (ucManHinhChinhEM temp in Form1.FrmMain.MetroContainer.Controls.OfType<ucManHinhChinhEM>())
            {
                Form1.FrmMain.MetroContainer.Controls.Remove(temp);
            }
        }
    }
}
