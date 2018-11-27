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
using Motorbike.ucKhachHang;
using Motorbike.ucMotorbike;
using Motorbike.ucReport;
using MetroFramework;
using MetroFramework.Controls;

namespace Motorbike.ucHeThong
{
    public partial class ucManHinhChinh : UserControl
    {
        int changePointX = 0;
        int dvDichChuyen = 50;
        string ucName = "";
        public string authority = "";
        public ucManHinhChinh()
        {
            InitializeComponent();
        }

        private void ucManHinhChinh_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            MetroTile metroTile = (MetroTile)sender;
            if (metroTile == btnEmployee)
            {
                if (authority == "employee")
                {
                    MessageBox.Show("You can't use this function", "Warnings");
                    return;
                }
            }
            ucName = metroTile.Tag.ToString();
            timerManHinhChinh.Start();

        }

        private void timerManHinhChinh_Tick(object sender, EventArgs e)
        {
            if (changePointX >= mPanelContainer.Size.Width)
            {
                timerManHinhChinh.Stop();

                switch(ucName)
                {
                    case "NhanVien":
                        {
                            templateNhanVien ucNV = new templateNhanVien();
                            ucNV.Dock = DockStyle.Fill;

                            Form1.FrmMain.MetroContainer.Controls.Add(ucNV);
                            Form1.FrmMain.MetroContainer.Controls["templateNhanVien"].BringToFront();
                            foreach (ucManHinhChinh uc in Form1.FrmMain.MetroContainer.Controls.OfType<ucManHinhChinh>())
                            {
                                Form1.FrmMain.MetroContainer.Controls.Remove(uc);
                            }
                            break;
                        }
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
                    case "ucSaR":
                        {
                            frmReport fr = new frmReport();
                            fr.Dock = DockStyle.Fill;

                            Form1.FrmMain.MetroContainer.Controls.Add(fr);
                            Form1.FrmMain.MetroContainer.Controls["frmReport"].BringToFront();
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

        private void mPanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mPanelChinh_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnBack_Click_1(object sender, EventArgs e)
        {
            ucDangNhap ucDangNhap = new ucDangNhap();
            ucDangNhap.Dock = DockStyle.Fill;
            Form1.FrmMain.MetroContainer.Controls.Add(ucDangNhap);
            Form1.FrmMain.MetroContainer.Controls["ucDangNhap"].BringToFront();
            foreach (ucManHinhChinh temp in Form1.FrmMain.MetroContainer.Controls.OfType<ucManHinhChinh>())
            {
                Form1.FrmMain.MetroContainer.Controls.Remove(temp);
            }
        }
    }
}
