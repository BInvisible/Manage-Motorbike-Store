using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Motorbike.ucHeThong;
using MetroFramework.Controls;
using System.Threading;

namespace Motorbike.ucNhanVien
{
    public partial class templateNhanVien : UserControl
    {
        public templateNhanVien()
        {
            InitializeComponent();
        }
        MetroProgressBar mProcessBar;
        MetroLabel mlblPerCent;
        string ucName = "";
        Thread thLoadProcessBar;
        Thread thLoadUC;
        private void btnBack_Click(object sender, EventArgs e)
        {
            ucManHinhChinh ucMHC = new ucManHinhChinh();
            ucMHC.Dock = DockStyle.Fill;
            Form1.FrmMain.MetroContainer.Controls.Add(ucMHC);
            Form1.FrmMain.MetroContainer.Controls["ucManHinhChinh"].BringToFront();
            foreach (templateNhanVien temp in Form1.FrmMain.MetroContainer.Controls.OfType<templateNhanVien>())
            {
                Form1.FrmMain.MetroContainer.Controls.Remove(temp);
            }
        }

        private void mPanelMenuItem_MouseHover(object sender, EventArgs e)
        {
            MetroPanel pnl = (MetroPanel)sender;
            pnl.CustomBackground = true;
            pnl.BackColor = Color.Black;
        }

        private void mPanelMenuItem_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel pnl = (MetroPanel)sender;
            pnl.CustomBackground = true;
            if (pnl.Tag.ToString() == "1")
            {
                pnl.BackColor = Color.Black;
            }
            else
            {
                pnl.BackColor = Color.FromArgb(45, 137, 239);
            }
        }

        private void metroLabelMenuItem_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlbl = (MetroLabel)sender;
            MetroPanel pnlParent = (MetroPanel)mlbl.Parent;
            pnlParent.CustomBackground = true;
            pnlParent.BackColor = Color.Black;
        }

        private void metroLabelMenuItem_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlbl = (MetroLabel)sender;
            MetroPanel pnlParent = (MetroPanel)mlbl.Parent;
            pnlParent.CustomBackground = true;
            if (pnlParent.Tag.ToString() == "1")
            {
                pnlParent.BackColor = Color.Black;
            }
            else
            {
                pnlParent.BackColor = Color.FromArgb(45, 137, 239);
            }
        }

        private void mPanelMenuItem_Click(object sender, EventArgs e)
        {
            MetroPanel mPanel = (MetroPanel)sender;
            MetroPanel mPanelParent = (MetroPanel)mPanel.Parent;
            foreach (MetroPanel pnlChild in mPanelParent.Controls.OfType<MetroPanel>())
            {
                pnlChild.Tag = 0;
                pnlChild.BackColor = Color.FromArgb(45, 137, 239);
            }
            
            mPanel.CustomBackground = true;
            mPanel.Tag = 1;
            mPanel.BackColor = Color.Black;
            ucName = mPanel.AccessibleName;
            UserContent();
        }

        private void metroLabelMenuItem_Click(object sender, EventArgs e)
        {
            MetroLabel metroLabel = (MetroLabel)sender;
            MetroPanel mPanel = (MetroPanel)metroLabel.Parent;
            MetroPanel mPanelParent = (MetroPanel)mPanel.Parent;
            foreach (MetroPanel pnlChild in mPanelParent.Controls.OfType<MetroPanel>())
            {
                pnlChild.Tag = 0;
                pnlChild.BackColor = Color.FromArgb(45, 137, 239);
            }

            mPanel.CustomBackground = true;
            mPanel.Tag = 1;
            mPanel.BackColor = Color.Black;
            ucName = mPanel.AccessibleName;
            UserContent();
        }

        public void LoadProcessBar()
        {
            for (int i = 0; i <= 10000; i++)
            {
                mProcessBar.Invoke(new MethodInvoker(delegate
                {
                    mProcessBar.Value = (i * 100) / 10000;
                }
                ));
                mlblPerCent.Invoke(new MethodInvoker(delegate
                {
                    mlblPerCent.Text = (i * 100) / 10000 + "%";
                }
                ));
                
            }
            thLoadUC.Resume();
        }
        public void LoadUC()
        {
            thLoadUC.Suspend();
            mPanelContent.Invoke(new MethodInvoker(delegate ()
            {
                
                switch (ucName)
                {
                    case "ucHoSoNhanVien":
                        {
                            ucHoSoNhanVien ucHSNV = new ucHoSoNhanVien();
                            ucHSNV.Dock = DockStyle.Fill;
                            mPanelContent.Controls.Add(ucHSNV);
                            mPanelContent.Controls["ucHoSoNhanVien"].BringToFront();
                            break;
                        }
                    case "ucManageEmployee":
                        {
                            ucCreateAccount ucME = new ucCreateAccount();
                            ucME.Dock = DockStyle.Fill;
                            mPanelContent.Controls.Add(ucME);
                            mPanelContent.Controls["ucCreateAccount"].BringToFront();
                            break;
                        }
                }
            }));
        }
        public void UserContent()
        {
            foreach(UserControl uc in mPanelContent.Controls.OfType<UserControl>())
            {
                mPanelContent.Controls.Remove(uc);
            }
            ucProcessBarcs ucPB = new ucProcessBarcs();
            ucPB.Dock = DockStyle.Fill;
            mPanelContent.Controls.Add(ucPB);
            mPanelContent.Controls["ucProcessBarcs"].BringToFront();
            mProcessBar= ucPB.mPB;
            mlblPerCent = ucPB.lblPC;
            //Thread Process Bar
            thLoadProcessBar = new Thread(new ThreadStart(LoadProcessBar));
            thLoadProcessBar.Start();
            //Thread load user control
            thLoadUC = new Thread(new ThreadStart(LoadUC));
            thLoadUC.Start();


        }   
        

    }
}

