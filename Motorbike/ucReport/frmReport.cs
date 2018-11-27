using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using Motorbike.ucHeThong;

namespace Motorbike.ucReport
{
    public partial class frmReport : UserControl
    {
        MotoDB1 db = new MotoDB1();
        public frmReport()
        {
            InitializeComponent();
        }

        private void btnLisCustomer_Click(object sender, EventArgs e)
        {
            ReportCus rpt = new ReportCus();
            var data = from hd in db.CUSTOMERs
                       select new Model
                       {
                           CUSID = hd.CUSID,
                           FIRSTNAME = hd.FIRSTNAME,
                           LASTNAME = hd.LASTNAME,
                           IDCARD = hd.IDCARD,
                           PHONENUMBER = hd.PHONENUMBER,
                           ADDRESS = hd.ADDRESSS,
                       };
            rpt.SetDataSource(data);
            FormCrys.ReportSource = rpt;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ReportEm rpt = new ReportEm();
            var data = from em in db.EMPLOYEEs
                       join dg in db.DEGREEs on em.DEGREEID equals dg.DEGREEID
                       join dp in db.DEPARTMENTs on em.DEPARTMENTID equals dp.DEPARTMENTID
                       join ps in db.POSITIONs on em.POSITIONID equals ps.POSITIONID
                       select new Model
                       {
                            EID=em.EID,
                            FIRSTNAME=em.FIRSTNAME,
                            LASTNAME=em.LASTNAME,
                            DEPARTMENTNAME=dp.DEPARTMENTNAME,
                            DEGREENAME=dg.DEGREENAME,
                            POSITIONNAME=ps.POSITIONNAME,
                       };
            rpt.SetDataSource(data);
            FormCrys.ReportSource = rpt;
        }

        private void btnListMoto_Click(object sender, EventArgs e)
        {
            ReportMoto rpt = new ReportMoto();
            var data = from moto in db.MOTORBIKEs
                       select new Model
                       {
                           MOTOID=moto.MOTOID,
                           MOTONAME=moto.MOTONAME,
                           PRODUCER=moto.PRODUCER,
                           CAPACITY=moto.CAPACITY,
                           COLOR=moto.COLOR,
                           PRICE=moto.PRICE,
                       };
            rpt.SetDataSource(data);
            FormCrys.ReportSource = rpt;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucManHinhChinh ucMHC = new ucManHinhChinh();
            ucMHC.Dock = DockStyle.Fill;
            Form1.FrmMain.MetroContainer.Controls.Add(ucMHC);
            Form1.FrmMain.MetroContainer.Controls["ucManHinhChinh"].BringToFront();
            foreach (frmReport temp in Form1.FrmMain.MetroContainer.Controls.OfType<frmReport>())
            {
                Form1.FrmMain.MetroContainer.Controls.Remove(temp);
            }
        }
    }
}
