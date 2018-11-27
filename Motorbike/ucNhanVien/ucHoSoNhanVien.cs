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

namespace Motorbike.ucNhanVien
{
    public partial class ucHoSoNhanVien : UserControl
    {
        public ucHoSoNhanVien()
        {
            InitializeComponent();
        }
        byte[] image = null;
        List<EmployeeDTO> lstNV;
        INSURANCE bh;
        string path = "";
        protected override void OnLoad(EventArgs e)
        {
            lstNV= EmployeeBUS.LoadEmployee();
            //DGV_NhanVien.DataSource = lstNV;
            LoadDgvNhanVien();  
            //DGV_NhanVien.Columns["DEGREEID"].Visible = false;
            //DGV_NhanVien.Columns["DEPARTMENTID"].Visible = false;
            //DGV_NhanVien.Columns["POSITIONID"].Visible = false;

            cmbBangCap.DataSource = DegreeBUS.LoadDegree();
            cmbBangCap.DisplayMember = "DEGREENAME";
            cmbBangCap.ValueMember = "DEGREEID";
            
            
            cmbBoPhan.DataSource = DepartmentBUS.LoadDepartment();
            cmbBoPhan.DisplayMember = "DEPARTMENTNAME";
            cmbBoPhan.ValueMember = "DEPARTMENTID";

            mCmbBoPhan.DataSource = DepartmentBUS.LoadDepartment();
            mCmbBoPhan.DisplayMember = "DEPARTMENTNAME";
            mCmbBoPhan.ValueMember = "DEPARTMENTID";

            cmbChucVu.DataSource = PositionBUS.LoadPosition();
            cmbChucVu.DisplayMember = "POSITIONNAME";
            cmbChucVu.ValueMember = "POSITIONID";
          
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG |*.jpg| PNG |*png|All File |*.*";

            if(dialog.ShowDialog()==DialogResult.OK)
            {
                path = dialog.FileName.ToString();
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
            if(path!="")
            {
                FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader bnr = new BinaryReader(fstream);
                image = bnr.ReadBytes((int)fstream.Length);
                pictureBox2.Image = ByteToImage(image); 
            }
        }
        public static Bitmap ByteToImage(byte[]blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        EmployeeDTO CheckControl()
        {
            int err = 0;
            if(txtHoLot.Text.Trim()=="")
            {
                err++;
                txtHoLot.BackColor = Color.OrangeRed;
            }
            else
            {
                txtHoLot.BackColor = Color.White;
            }
            if(txtTen.Text.Trim()=="")
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
            if (image==null)
            {
                err++;
                MessageBox.Show("Select picture", "Warnings");
            }
            if(err!=0)
            {
                MessageBox.Show("Input again!", "Warnings");
                return null;
            }
            EmployeeDTO nvDTO = new EmployeeDTO();
            nvDTO.FIRSTNAME = txtHoLot.Text;
            nvDTO.LASTNAME = txtTen.Text;
            nvDTO.IDCARD = txtCMND.Text;
            if(rdbMale.Checked)
            {
                nvDTO.GENDER = "Male";
            }
            else
            {
                nvDTO.GENDER = "Female";
            }
            nvDTO.DOB = dateTimePicker1.Value;
            nvDTO.PICTURE = image;
            nvDTO.ADDDRESSS = txtDiaChi.Text;
            nvDTO.PHONENUMBER = txtDienThoai.Text;
            nvDTO.DEGREEID = int.Parse(cmbBangCap.SelectedValue.ToString());
            nvDTO.DEPARTMENTID = int.Parse(cmbBoPhan.SelectedValue.ToString());
            nvDTO.POSITIONID = int.Parse(cmbChucVu.SelectedValue.ToString());
            nvDTO.DEGREENAME = cmbBangCap.Text;
            nvDTO.DEPARTMENTNAME = cmbBoPhan.Text;
            nvDTO.POSITIONNAME = cmbChucVu.Text;
            return nvDTO;
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            EmployeeDTO nvDTO = CheckControl();
            if(nvDTO!=null)
            {
                nvDTO = EmployeeBUS.AddEm(nvDTO);
                if (nvDTO != null)
                {
                    lstNV.Add(nvDTO);
                    LoadDgvNhanVien();
                    MessageBox.Show("Add new employee success!", "Notification");
                }
                else
                {
                    MessageBox.Show("Add new employee fail!", "Notification");
                }
            }
        }
        void LoadDgvNhanVien()
        {
            DGV_NhanVien.DataSource = typeof(List<EmployeeDTO>);
            DGV_NhanVien.DataSource = lstNV;
            DGV_NhanVien.Columns["DEGREEID"].Visible = false;
            DGV_NhanVien.Columns["DEPARTMENTID"].Visible = false;
            DGV_NhanVien.Columns["POSITIONID"].Visible = false;

            AutoCompleteStringCollection ascNV = new AutoCompleteStringCollection();
            if (lstNV.Count != 0)
            {
                foreach (var item in lstNV)
                {
                    ascNV.Add(item.FIRSTNAME + " " + item.LASTNAME);

                }
            }
            txtTuKhoa.AutoCompleteCustomSource = ascNV;
        }
        

        private void DGV_NhanVien_Click(object sender, EventArgs e)
        {
            if (DGV_NhanVien.SelectedRows.Count != 0)
            {
                btnXoa.Enabled = true;
                DataGridViewRow dr = DGV_NhanVien.SelectedRows[0];
                mlblEID.Text = dr.Cells["EID"].Value.ToString();
                txtHoLot.Text = dr.Cells["FIRSTNAME"].Value.ToString();
                txtTen.Text = dr.Cells["LASTNAME"].Value.ToString();
                txtDiaChi.Text = dr.Cells["ADDDRESSS"].Value.ToString();
                txtDienThoai.Text = dr.Cells["PHONENUMBER"].Value.ToString();
                txtCMND.Text = dr.Cells["IDCARD"].Value.ToString();
                int maNV = int.Parse(mlblEID.Text);
                if (dr.Cells["GENDER"].Value.ToString() == "Male")
                {
                    rdbMale.Checked = true;
                }
                else
                {
                    rdbFemale.Checked = true;
                }
                dateTimePicker1.Value = (DateTime)dr.Cells["DOB"].Value;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = ByteToImage((byte[])dr.Cells["PICTURE"].Value);
                image=(byte[])dr.Cells["PICTURE"].Value;
                cmbBangCap.SelectedText = dr.Cells["DEGREENAME"].Value.ToString();
                cmbBoPhan.SelectedText = dr.Cells["POSITIONNAME"].Value.ToString();
                cmbBoPhan.SelectedText = dr.Cells["DEPARTMENTNAME"].Value.ToString();
                List<INSURANCE> lstBaoHiem = InsuranceBUS.LoadBaoHiem(maNV);
                DGV_BaoHiem.DataSource = typeof(List<INSURANCE>);
                if (lstBaoHiem != null)
                {
                    DGV_BaoHiem.DataSource = lstBaoHiem;
                    DGV_BaoHiem.Columns["EMPLOYEEs"].Visible = false;
                    //DGV_BaoHiem.Columns["EID"].Visible = false;
                    btnUpdateInsurance.Enabled = true;
                }
                else
                {
                    DGV_BaoHiem.DataSource = null;
                }
                btnAddinsurance.Enabled = true;

            }
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            EmployeeDTO nvDTO = CheckControl();
            if(nvDTO!=null)
            {
                nvDTO.EID = int.Parse(mlblEID.Text);
                nvDTO.PICTURE = image;
            }
            EmployeeDTO nvUpdateDTO = EmployeeBUS.UpdateEm(nvDTO);
            if(nvUpdateDTO!=null)
            {
                EmployeeDTO nvUpdate = lstNV.SingleOrDefault(n => n.EID == nvUpdateDTO.EID);
                nvUpdate.EID = nvUpdateDTO.EID;
                nvUpdate.FIRSTNAME = nvUpdateDTO.FIRSTNAME;
                nvUpdate.LASTNAME = nvUpdateDTO.LASTNAME;
                nvUpdate.IDCARD = nvUpdateDTO.IDCARD;
                nvUpdate.GENDER = nvUpdateDTO.GENDER;
                nvUpdate.DOB = nvUpdateDTO.DOB;
                nvUpdate.ADDDRESSS = nvUpdateDTO.ADDDRESSS;
                nvUpdate.PHONENUMBER = nvUpdateDTO.PHONENUMBER;
                nvUpdate.PICTURE = nvUpdateDTO.PICTURE;
                nvUpdate.DEGREEID = nvUpdateDTO.DEGREEID;
                nvUpdate.DEGREEID = nvUpdateDTO.DEGREEID;
                nvUpdate.DEPARTMENTID = nvUpdateDTO.DEPARTMENTID;
                nvUpdate.DEPARTMENTNAME = nvUpdateDTO.DEPARTMENTNAME;
                nvUpdate.POSITIONID = nvUpdateDTO.POSITIONID;
                nvUpdate.POSITIONNAME = nvUpdateDTO.POSITIONNAME;
                LoadDgvNhanVien();
            }
            else
            {
                MessageBox.Show("Update fail.", "Warnings");
                return;
            }
            List<INSURANCE> lstBH = (List<INSURANCE>)DGV_BaoHiem.DataSource;
            List<INSURANCE> lstBHUpdate = InsuranceBUS.UpdateBaoHiem(nvDTO.EID, lstBH);
            //if (lstBHUpdate == null)
            //{
            //    List<INSURANCE> lstLoadBH = InsuranceBUS.LoadBaoHiem(nvDTO.EID);
            //    DGV_BaoHiem.DataSource = typeof(List<INSURANCE>);
            //    DGV_BaoHiem.DataSource = lstLoadBH;
            //    DGV_BaoHiem.Columns["EMPLOYEEs"].Visible = false;
            //    MessageBox.Show("Employee doesn't update or INSURANCEID is duplicate", "Warnings");
            //    return;
            //}
            MessageBox.Show("Update success.", "Warnings");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mlblEID.Text = "";
            txtHoLot.Text = "";
            txtTen.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            cmbBangCap.Text = "";
            cmbBoPhan.Text = "";
            cmbChucVu.Text = "";
            pictureBox2.Image = null;
        }

        private void DGV_BaoHiem_Click(object sender, EventArgs e)
        {
            if(DGV_BaoHiem.SelectedRows.Count!=0)
            {
                btnUpdateInsurance.Enabled = true;
                btnDeleteInsurance.Enabled = true;
                bh = new INSURANCE();
                DataGridViewRow dr = DGV_BaoHiem.SelectedRows[0];
                bh.INSURANCEID = int.Parse(dr.Cells["INSURANCEID"].Value.ToString());
                bh.DATEBUY = DateTime.Parse(dr.Cells["DATEBUY"].Value.ToString());
                bh.EXPDATE= DateTime.Parse(dr.Cells["EXPDATE"].Value.ToString());
                bh.ISSUEDBY = dr.Cells["ISSUEDBY"].Value.ToString();
                bh.HOSPITAL = dr.Cells["HOSPITAL"].Value.ToString();
                bh.EID = int.Parse(dr.Cells["EID"].Value.ToString());
            }
        }

        private void btnAddinsurance_Click(object sender, EventArgs e)
        {
            frmThongTinBaoHiem frmTTBH = new frmThongTinBaoHiem();
            frmTTBH.EID = mlblEID.Text;
            frmTTBH.ShowDialog();
            if(frmTTBH.DialogResult==DialogResult.OK)
            {
                bh = new INSURANCE();
                bh.EID = int.Parse(mlblEID.Text);
                //bh.INSURANCEID = int.Parse(frmTTBH.insuranceID);
                bh.DATEBUY = frmTTBH.DateBuy;
                bh.EXPDATE = frmTTBH.ExpBuy;
                bh.HOSPITAL = frmTTBH.Hospital;
                bh.ISSUEDBY = frmTTBH.Issuedby;
                List<INSURANCE> lstBH = (List<INSURANCE>)DGV_BaoHiem.DataSource;
                if(lstBH==null)
                {
                    lstBH = new List<INSURANCE>();
                }
                lstBH.Add(bh);
                DGV_BaoHiem.DataSource = typeof(List<INSURANCE>);
                DGV_BaoHiem.DataSource = lstBH;
                DGV_BaoHiem.Columns["EMPLOYEEs"].Visible = false; 
            }
        }

        private void btnUpdateInsurance_Click(object sender, EventArgs e)
        {
            if (DGV_BaoHiem.SelectedRows.Count != 0)
            {
                frmThongTinBaoHiem frmTTBH = new frmThongTinBaoHiem();
                frmTTBH.EID = mlblEID.Text;
                frmTTBH.insuranceID = bh.INSURANCEID.ToString();
                frmTTBH.DateBuy = bh.DATEBUY.Value;
                frmTTBH.Issuedby = bh.ISSUEDBY;
                frmTTBH.ExpBuy = bh.EXPDATE.Value;
                frmTTBH.Hospital = bh.HOSPITAL;
                frmTTBH.txtSobaohiem.ReadOnly = true;
                frmTTBH.ShowDialog();
                if(frmTTBH.DialogResult==DialogResult.OK)
                {
                    List<INSURANCE> lstBH = (List<INSURANCE>)DGV_BaoHiem.DataSource;
                    INSURANCE bhUpdate=lstBH.Single(n => n.INSURANCEID == bh.INSURANCEID);

                    bhUpdate.INSURANCEID = int.Parse(frmTTBH.insuranceID);
                    bhUpdate.DATEBUY = frmTTBH.DateBuy;
                    bhUpdate.EXPDATE = frmTTBH.ExpBuy;
                    bhUpdate.HOSPITAL = frmTTBH.Hospital;
                    bhUpdate.ISSUEDBY = frmTTBH.Issuedby;
                    bhUpdate.EID = int.Parse(frmTTBH.EID);

                    DGV_BaoHiem.DataSource = typeof(List<INSURANCE>);
                    DGV_BaoHiem.DataSource = lstBH;
                    DGV_BaoHiem.Columns["EMPLOYEEs"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Select insurance need to update", "Warnings");
            }
        }

        private void btnDeleteInsurance_Click(object sender, EventArgs e)
        {
            if(bh==null)
            {
                MessageBox.Show("Select insurance need to delete", "Warnings");
                return;
            }
            if (DGV_BaoHiem.SelectedRows.Count!=0)
            {
                List<INSURANCE> lstBH = (List<INSURANCE>)DGV_BaoHiem.DataSource;
                INSURANCE bhDelete = lstBH.Single(n => n.INSURANCEID == bh.INSURANCEID);

                lstBH.Remove(bhDelete); 

                DGV_BaoHiem.DataSource = typeof(List<INSURANCE>);
                DGV_BaoHiem.DataSource = lstBH;
                DGV_BaoHiem.Columns["EMPLOYEEs"].Visible = false;
                btnDeleteInsurance.Enabled = false;
                bh = null;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(mlblEID.Text);
            if(EmployeeBUS.DeleteEm(maNV)==true)
            {
                EmployeeDTO nvDTO = lstNV.SingleOrDefault(n => n.EID == maNV);
                lstNV.Remove(nvDTO);
                //DGV_NhanVien.DataSource = typeof(List<EmployeeDTO>);
                //DGV_NhanVien.DataSource = lstNV;
                //DGV_NhanVien.Columns["DEGREEID"].Visible = false;
                //DGV_NhanVien.Columns["DEPARTMENTID"].Visible = false;
                //DGV_NhanVien.Columns["POSITIONID"].Visible = false;
                LoadDgvNhanVien();
                MessageBox.Show("Delete success.", "Notification");
                btnXoa.Enabled = false;
                return;
            }
            MessageBox.Show("Delete fail.", "Notification");
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tk = txtTuKhoa.Text;
            if(tk.Trim()!="")
            {
                List<EmployeeDTO> lstKQTK = lstNV.Where(n => (n.FIRSTNAME.ToLower() + " " + n.LASTNAME.ToLower()).Contains(tk.ToLower())).ToList();
                if(lstKQTK.Count==0)
                {
                    int maNV;
                    bool kt = int.TryParse(tk, out maNV);
                    if(kt==true)
                    {
                        lstKQTK = lstNV.Where(n => n.EID == maNV).ToList();
                    }
                }
                if(mCkbBoPhan.Checked==true)
                {
                    int maBP=int.Parse(mCmbBoPhan.SelectedValue.ToString());
                    lstKQTK = lstKQTK.Where(n => n.DEPARTMENTID ==maBP).ToList();
                }
                int soKQ = lstKQTK.Count();
                if (soKQ != 0)
                {
                    MessageBox.Show("Found " + soKQ + " employees: " + tk, "Notification");
                }
                else
                {
                    MessageBox.Show("Not found employees: " + tk, "Notification");
                    LoadDgvNhanVien();
                }
                DGV_NhanVien.DataSource = lstKQTK;
            }
            else
            {
                MessageBox.Show("Input key need to find.", "Warnings");
                LoadDgvNhanVien();
            }
        }
    }
}
