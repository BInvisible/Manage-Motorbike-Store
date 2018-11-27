using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Motorbike;
using Motorbike.ucHeThong;
using BusinessLogicLayer;
using DataAccessLayer;
using DataTransferObject;
using MetroFramework.Controls;

namespace Motorbike.ucHeThong
{
    public partial class ucDangNhap : UserControl
    {
        public ucDangNhap()
        {
            InitializeComponent();
        }
        LoginBUS objEM = new LoginBUS();
        List<LoginDTO> lstloginDTO=LoginBUS.LoadLogin();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            LoginDTO dnDTO = lstloginDTO.SingleOrDefault(n => n.Username == txtUserN.Text);
            if (objEM.Check(txtUserN.Text, txtPass.Text) == true && dnDTO.Authority == "employee")
            {
                if (MessageBox.Show("You login as a employee.", "Login Success!", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    ucManHinhChinh ucMHC = new ucManHinhChinh();
                    ucMHC.authority = dnDTO.Authority;
                    ucMHC.Dock = DockStyle.Fill;
                    Form1.FrmMain.MetroContainer.Controls.Add(ucMHC);
                    Form1.FrmMain.MetroContainer.Controls["ucManHinhChinh"].BringToFront();
                    foreach (ucDangNhap uc in Form1.FrmMain.MetroContainer.Controls.OfType<ucDangNhap>())
                    {
                        Form1.FrmMain.MetroContainer.Controls.Remove(uc);
                    }

                }
            }
            else if (objEM.Check(txtUserN.Text, txtPass.Text) == true && dnDTO.Authority == "admin")
            {
                if (MessageBox.Show("You login as a adminastrator.", "Login Success!", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    ucManHinhChinh ucMHC = new ucManHinhChinh();
                    ucMHC.Dock = DockStyle.Fill;
                    Form1.FrmMain.MetroContainer.Controls.Add(ucMHC);
                    Form1.FrmMain.MetroContainer.Controls["ucManHinhChinh"].BringToFront();
                    foreach (ucDangNhap uc in Form1.FrmMain.MetroContainer.Controls.OfType<ucDangNhap>())
                    {
                        Form1.FrmMain.MetroContainer.Controls.Remove(uc);
                    }
                }
            }
            else
            {
                MessageBox.Show("Login Failed!");
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}

