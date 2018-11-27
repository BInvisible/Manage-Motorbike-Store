using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace Motorbike.ucKhachHang
{
    public partial class Show : Form
    {
        public Show()
        {
            InitializeComponent();
        }
        public int cusID { get; set; }
        MotoDB1 db = new MotoDB1();

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            rptOrder rpt = new rptOrder();
            var data = from hd in db.BILLs
                       join kh in db.CUSTOMERs on hd.CUSID equals kh.CUSID
                       join hh in db.MOTORBIKEs on hd.MOTOID equals hh.MOTOID
                       where hd.CUSID == cusID
                       select new Model
                       {
                           BID = hd.BID,
                           CUSID = kh.CUSID,
                           FIRSTNAME = kh.FIRSTNAME,
                           LASTNAME = kh.LASTNAME,
                           DATEBUY = hd.DATEBUY,
                           MOTOID = hh.MOTOID,
                           MOTONAME = hh.MOTONAME,
                           QUANTITY = hd.QUANTITY,
                           PRICE = hh.PRICE,
                           TOTALMONEY = hd.TOTALMONEY,
                       };
            rpt.SetDataSource(data);
            ReportViewer.ReportSource = rpt;
            ReportViewer.Show();
        }

    }
}
