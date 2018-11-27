using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.IO;
using DataAccessLayer;
using DataTransferObject;
using Motorbike.ucHeThong;

namespace Motorbike.ucKhachHang
{
    public partial class ucHoSoKhachHang : UserControl
    {
        public ucHoSoKhachHang()
        {
            InitializeComponent();
        }
        List<CustomerDTO> lstCus;
        List<OrderDTO> lstorDTO;
        List<MotorbikeDTO> lstmotoDTO;
        OrderDTO or;
        MotorbikeDTO mDTO;
        CustomerDTO cusDTO;
        public DataGridView dataGV
        {
            get
            {
                return DGV_KhachHang;
            }
            set
            {
                DGV_KhachHang = value;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            lstCus = CustomerBUS.LoadCus();
            LoadDgvNhanVien();
        }
        void LoadDgvNhanVien()
        {
            DGV_KhachHang.DataSource = typeof(List<CustomerDTO>);
            DGV_KhachHang.DataSource = lstCus;

            //DGV_KhachHang.Columns["BILLID"].Visible = false;
            AutoCompleteStringCollection sourcename = new AutoCompleteStringCollection();
            if (lstCus.Count != 0)
            {
                foreach (var item in lstCus)
                {
                    sourcename.Add(item.FIRSTNAME + " " + item.LASTNAME);
                }
            }
            this.txtTuKhoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.txtTuKhoa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtTuKhoa.AutoCompleteCustomSource = sourcename;
            //AutoCompleteStringCollection ascNV = new AutoCompleteStringCollection();
            //if (lstCus.Count != 0)
            //{
            //    foreach (var item in lstCus)
            //    {
            //        ascNV.Add(item.FIRSTNAME + " " + item.LASTNAME);

            //    }
            //}
            //txtTuKhoa.AutoCompleteCustomSource = ascNV;
        }

        CustomerDTO CheckControl()
        {
            int err = 0;
            if (txtHoLot.Text.Trim() == "")
            {
                err++;
                txtHoLot.BackColor = Color.OrangeRed;
            }
            else
            {
                txtHoLot.BackColor = Color.White;
            }
            if (txtTen.Text.Trim() == "")
            {
                err++;
                txtTen.BackColor = Color.OrangeRed;
            }
            else
            {
                txtTen.BackColor = Color.White;
            }
            if (txtCMND.Text.Trim() == "")
            {
                err++;
                txtCMND.BackColor = Color.OrangeRed;
            }
            else
            {
                txtCMND.BackColor = Color.White;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                err++;
                txtDiaChi.BackColor = Color.OrangeRed;
            }
            else
            {
                txtDiaChi.BackColor = Color.White;
            }
            if (txtDienThoai.Text.Trim() == "")
            {
                err++;
                txtDienThoai.BackColor = Color.OrangeRed;
            }
            else
            {
                txtDienThoai.BackColor = Color.White;
            }
            if (err != 0)
            {
                MessageBox.Show("Input again!", "Warnings");
                return null;
            }
            CustomerDTO cusDTO = new CustomerDTO();
            cusDTO.FIRSTNAME = txtHoLot.Text;
            cusDTO.LASTNAME = txtTen.Text;
            cusDTO.IDCARD = txtCMND.Text;
            cusDTO.ADDRESSS = txtDiaChi.Text;
            cusDTO.PHONENUMBER = txtDienThoai.Text;
            return cusDTO;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            CustomerDTO cusDTO = CheckControl();
            if (cusDTO != null)
            {
                cusDTO = CustomerBUS.AddCus(cusDTO);
                if (cusDTO != null)
                {
                    lstCus.Add(cusDTO);
                    LoadDgvNhanVien();
                    MessageBox.Show("Add new customer success!", "Notification");
                }
                else
                {
                    MessageBox.Show("Add new customer fail!", "Notification");
                }
            }
        }

        private void DGV_KhachHang_Click(object sender, EventArgs e)
        {
            if (DGV_KhachHang.SelectedRows.Count != 0)
            {
                btnXoa.Enabled = true;
                DataGridViewRow dr = DGV_KhachHang.SelectedRows[0];
                mlblCID.Text = dr.Cells["CUSID"].Value.ToString();
                txtHoLot.Text = dr.Cells["FIRSTNAME"].Value.ToString();
                txtTen.Text = dr.Cells["LASTNAME"].Value.ToString();
                txtDiaChi.Text = dr.Cells["ADDRESSS"].Value.ToString();
                txtDienThoai.Text = dr.Cells["PHONENUMBER"].Value.ToString();
                txtCMND.Text = dr.Cells["IDCARD"].Value.ToString();

                //lstmotoDTO = MotoBUS.LoadMOTORBIKE();
                //mDTO = MotoBUS.Load(mDTO);
                int maNV = int.Parse(mlblCID.Text);
                List<OrderDTO> lstBaoHiem = OrderBUS.LoadBill(maNV);
                DGV_Order.DataSource = typeof(List<OrderDTO>);
                if (lstBaoHiem != null)
                {
                    DGV_Order.DataSource = lstBaoHiem;
                    DGV_Order.Columns["PRICE"].Visible = false;
                    DGV_Order.Columns["TOTALMONEY"].DefaultCellStyle.Format = "n";
                    btnUpdateOrder.Enabled = true;
                }
                else
                {
                    DGV_Order.DataSource = null;
                }
                btnAddOrder.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(mlblCID.Text);
            if (CustomerBUS.DeleteEm(maNV) == true)
            {
                CustomerDTO cusDTO = lstCus.SingleOrDefault(n => n.CUSID == maNV);
                lstCus.Remove(cusDTO);
                LoadDgvNhanVien();
                MessageBox.Show("Delete success.", "Notification");
                btnXoa.Enabled = false;
                return;
            }
            MessageBox.Show("Delete fail.", "Notification");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            CustomerDTO cusDTO = CheckControl();
            if (cusDTO != null)
            {
                cusDTO.CUSID = int.Parse(mlblCID.Text);
            }
            CustomerDTO cusUpdateDTO = CustomerBUS.UpdateEm(cusDTO);
            if (cusUpdateDTO != null)
            {
                CustomerDTO cusUpdate = lstCus.SingleOrDefault(n => n.CUSID == cusUpdateDTO.CUSID);
                cusUpdate.CUSID = cusUpdateDTO.CUSID;
                cusUpdate.FIRSTNAME = cusUpdateDTO.FIRSTNAME;
                cusUpdate.LASTNAME = cusUpdateDTO.LASTNAME;
                cusUpdate.IDCARD = cusUpdateDTO.IDCARD;
                cusUpdate.ADDRESSS = cusUpdateDTO.ADDRESSS;
                cusUpdate.PHONENUMBER = cusUpdateDTO.PHONENUMBER;
                LoadDgvNhanVien();
            }
            else
            {
                MessageBox.Show("Update fail.", "Warnings");
                return;
            }
            List<OrderDTO> lstOrder = (List<OrderDTO>)DGV_Order.DataSource;
            List<OrderDTO> lstOrderUpdate = OrderBUS.UpdateBill(cusDTO.CUSID, lstOrder);
            MessageBox.Show("Update success.", "Warnings");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tk = txtTuKhoa.Text;
            if (tk.Trim() != "")
            {
                List<CustomerDTO> lstKQTK = lstCus.Where(n => (n.FIRSTNAME.ToLower() + " " + n.LASTNAME.ToLower()).Contains(tk.ToLower())).ToList();
                if (lstKQTK.Count == 0)
                {
                    int maNV;
                    bool kt = int.TryParse(tk, out maNV);
                    if (kt == true)
                    {
                        lstKQTK = lstCus.Where(n => n.CUSID == maNV).ToList();
                    }
                }
                int soKQ = lstKQTK.Count();
                if (soKQ != 0)
                {
                    MessageBox.Show("Found " + soKQ + " customers: " + tk, "Notification");
                }
                else
                {
                    MessageBox.Show("Not found customers: " + tk, "Notification");
                    LoadDgvNhanVien();
                }
                DGV_KhachHang.DataSource = lstKQTK;
            }
            else
            {
                MessageBox.Show("Input key need to find.", "Warnings");
                LoadDgvNhanVien();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtHoLot.Text = "";
            txtTen.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        private void btnAddinsurance_Click(object sender, EventArgs e)
        {
            frmBill frmTTBH = new frmBill();
            frmTTBH.CUSID = mlblCID.Text;
            //frmTTBH.txtCustomerID.ReadOnly = true;
            frmTTBH.ShowDialog();
            if (frmTTBH.DialogResult == DialogResult.OK)
            {
                or = new OrderDTO();
                lstmotoDTO = MotoBUS.LoadMOTORBIKE();
                lstCus = CustomerBUS.LoadCus();
                
                or.CUSID = int.Parse(mlblCID.Text);

                lstorDTO = OrderBUS.LoadBill(or.CUSID);
                or.BID = int.Parse(frmTTBH.BID);
                or.DATEBUY = frmTTBH.DateBuy;
                or.MOTOID = int.Parse(frmTTBH.MOTOID);

                mDTO = lstmotoDTO.SingleOrDefault(n => n.MOTOID == or.MOTOID);
                cusDTO = lstCus.SingleOrDefault(n => n.CUSID == or.CUSID);
                //mDTO = MotoBUS.Load(mDTO);
                or.FIRSTNAME = cusDTO.FIRSTNAME;
                or.LASTNAME = cusDTO.LASTNAME;
                or.MOTONAME = mDTO.MOTONAME;
                or.QUANTITY = int.Parse(frmTTBH.Quantity);
                or.TOTALMONEY = or.QUANTITY*mDTO.PRICE;
                
                List<OrderDTO> lstOrder = (List<OrderDTO>)DGV_Order.DataSource;
                if (lstOrder == null)
                {
                    lstOrder = new List<OrderDTO>();
                }
                lstOrder.Add(or);
                DGV_Order.DataSource = typeof(List<OrderDTO>);
                DGV_Order.DataSource = lstOrder ;
                DGV_Order.Columns["TOTALMONEY"].DefaultCellStyle.Format = "n";
                DGV_Order.Columns["PRICE"].Visible = false;
                //DGV_Order.Columns["CUSTOMER"].Visible = false;
                //DGV_Order.Columns["MOTORBIKE"].Visible = false;
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (DGV_Order.SelectedRows.Count != 0)
            {
                frmBill frmTTBH = new frmBill();
                lstmotoDTO = MotoBUS.LoadMOTORBIKE();
                frmTTBH.CUSID = mlblCID.Text;
                frmTTBH.BID = or.BID.ToString();
                frmTTBH.DateBuy = or.DATEBUY.Value;
                frmTTBH.MOTOID = or.MOTOID.ToString();
                frmTTBH.Quantity = or.QUANTITY.ToString();
                frmTTBH.TotalMoney = or.TOTALMONEY.ToString();
                frmTTBH.txtCustomerID.ReadOnly = true;
                frmTTBH.ShowDialog();
                if (frmTTBH.DialogResult == DialogResult.OK)
                {
                    List<OrderDTO> lstOrder = (List<OrderDTO>)DGV_Order.DataSource;
                    OrderDTO bhUpdate= lstOrder.Single(n => n.BID == or.BID);

                    mDTO = lstmotoDTO.SingleOrDefault(n => n.MOTOID == or.MOTOID);
                    cusDTO = lstCus.SingleOrDefault(n => n.CUSID == or.CUSID);
                    //mDTO = MotoBUS.Load(mDTO);
                    bhUpdate.BID = int.Parse(frmTTBH.BID);
                    bhUpdate.DATEBUY = frmTTBH.DateBuy;
                    bhUpdate.MOTOID = int.Parse(frmTTBH.MOTOID);
                    bhUpdate.QUANTITY = int.Parse(frmTTBH.Quantity);
                    bhUpdate.TOTALMONEY = bhUpdate.QUANTITY * mDTO.PRICE;
                    bhUpdate.CUSID = int.Parse(frmTTBH.CUSID);

                    DGV_Order.DataSource = typeof(List<OrderDTO>);
                    DGV_Order.DataSource = lstOrder;
                    DGV_Order.Columns["TOTALMONEY"].DefaultCellStyle.Format = "n";
                    DGV_Order.Columns["PRICE"].Visible = false;
                    //DGV_Order.Columns["CUSTOMER"].Visible = false;
                    //DGV_Order.Columns["MOTORBIKE"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Select insurance need to update", "Warnings");
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (or == null)
            {
                MessageBox.Show("Select order need to delete", "Warnings");
                return;
            }
            if (DGV_Order.SelectedRows.Count != 0)
            {
                List<OrderDTO> lstBH = (List<OrderDTO>)DGV_Order.DataSource;
                OrderDTO bhDelete = lstBH.Single(n => n.BID == or.BID);

                lstBH.Remove(bhDelete);

                DGV_Order.DataSource = typeof(List<BILL>);
                DGV_Order.DataSource = lstBH;
                DGV_Order.Columns["TOTALMONEY"].DefaultCellStyle.Format = "n";
                DGV_Order.Columns["PRICE"].Visible = false;
                //DGV_Order.Columns["CUSTOMER"].Visible = false;
                //DGV_Order.Columns["MOTORBIKE"].Visible = false;
                btnDeleteOrder.Enabled = false;
                or = null;
            }
        }

        private void DGV_Order_Click(object sender, EventArgs e)
        {
            if (DGV_Order.SelectedRows.Count != 0)
            { 
                btnUpdateOrder.Enabled = true;
                btnDeleteOrder.Enabled = true;
                or = new OrderDTO();
                DataGridViewRow dr = DGV_Order.SelectedRows[0];
                or.BID = int.Parse(dr.Cells["BID"].Value.ToString());
                or.CUSID = int.Parse(dr.Cells["CUSID"].Value.ToString());
                or.FIRSTNAME = dr.Cells["FIRSTNAME"].Value.ToString();
                or.LASTNAME = dr.Cells["LASTNAME"].Value.ToString();
                or.DATEBUY = DateTime.Parse(dr.Cells["DATEBUY"].Value.ToString());
                or.MOTOID = int.Parse(dr.Cells["MOTOID"].Value.ToString());
                or.MOTONAME = dr.Cells["MOTONAME"].Value.ToString();
                or.QUANTITY = int.Parse(dr.Cells["QUANTITY"].Value.ToString());
                or.TOTALMONEY = double.Parse(dr.Cells["TOTALMONEY"].Value.ToString());

                DGV_Order.Columns["PRICE"].Visible = false;
                DGV_Order.Columns["TOTALMONEY"].DefaultCellStyle.Format = "n";
                //DGV_Order.Columns["CUSTOMER"].Visible = false;
                //DGV_Order.Columns["MOTORBIKE"].Visible = false;
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Show rptOrder = new Show();
            rptOrder.cusID = int.Parse(DGV_KhachHang.CurrentRow.Cells[0].Value.ToString());
            rptOrder.Show();
            //ShowCheckout show = new ShowCheckout();
            //int maNV = int.Parse(mlblCID.Text);
            //List<OrderDTO> lstBaoHiem = OrderBUS.LoadBill(maNV);
            //show.dgv.DataSource = typeof(List<OrderDTO>);
            //if (lstBaoHiem != null)
            //{
            //    show.dgv.DataSource = lstBaoHiem;
            //    double totall = 0;
            //    for (int i = 0; i < show.dgv.Rows.Count - 1; i++)
            //    {
            //        totall = totall + double.Parse(show.dgv.Rows[i].Cells["TOTALMONEY"].Value.ToString());
            //    }
            //    show.total = totall.ToString();
            //    show.dgv.Columns["PRICE"].Visible = false;
            //    show.dgv.Columns["TOTALMONEY"].DefaultCellStyle.Format = "n";
            //}
            //else
            //{
            //    show.dgv.DataSource = null;
            //}
            //show.ShowDialog();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ucManHinhChinh ucMHC = new ucManHinhChinh();
            ucMHC.Dock = DockStyle.Fill;
            Form1.FrmMain.MetroContainer.Controls.Add(ucMHC);
            Form1.FrmMain.MetroContainer.Controls["ucManHinhChinh"].BringToFront();
            foreach (ucHoSoKhachHang temp in Form1.FrmMain.MetroContainer.Controls.OfType<ucHoSoKhachHang>())
            {
                Form1.FrmMain.MetroContainer.Controls.Remove(temp);
            }
        }
    }
}
