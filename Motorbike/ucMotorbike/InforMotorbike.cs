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
using DataTransferObject;
using BusinessLogicLayer;
using System.IO;
using Motorbike.ucHeThong;

namespace Motorbike.ucMotorbike
{
    public partial class InforMotorbike : UserControl
    {
        public InforMotorbike()
        {
            InitializeComponent();
        }
        byte[] image = null;
        List<MotorbikeDTO> lstNV;
        string path = "";
        protected override void OnLoad(EventArgs e)
        {
            lstNV = MotoBUS.LoadMOTORBIKE();
            LoadDgvNhanVien();
        }
        void LoadDgvNhanVien()
        {
            DGV_Motorbike.DataSource = typeof(List<MotorbikeDTO>);
            DGV_Motorbike.DataSource = lstNV;
            DGV_Motorbike.Columns["PRICE"].DefaultCellStyle.Format = "n";

            AutoCompleteStringCollection ascNV = new AutoCompleteStringCollection();
            if (lstNV.Count != 0)
            {
                foreach (var item in lstNV)
                {
                    ascNV.Add(item.MOTONAME);

                }
            }
            txtTuKhoa.AutoCompleteCustomSource = ascNV;

            AutoCompleteStringCollection ascProducer = new AutoCompleteStringCollection();
            if (lstNV.Count != 0)
            {
                foreach (var item in lstNV)
                {
                    ascProducer.Add(item.PRODUCER);

                }
            }
            txtCheckProducer.AutoCompleteCustomSource = ascProducer;
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        MotorbikeDTO CheckControl()
        {
            int err = 0;
            if (txtName.Text.Trim() == "")
            {
                err++;
                txtName.BackColor = Color.OrangeRed;
            }
            else
            {
                txtName.BackColor = Color.White;
            }
            if (txtProducer.Text.Trim() == "")
            {
                err++;
                txtProducer.BackColor = Color.OrangeRed;
            }
            else
            {
                txtProducer.BackColor = Color.White;
            }
            if (txtCapacity.Text.Trim() == "")
            {
                err++;
                txtCapacity.BackColor = Color.OrangeRed;
            }
            else
            {
                txtCapacity.BackColor = Color.White;
            }
            if (txtColor.Text.Trim() == "")
            {
                err++;
                txtColor.BackColor = Color.OrangeRed;
            }
            else
            {
                txtColor.BackColor = Color.White;
            }
            if (txtPrice.Text.Trim() == "")
            {
                err++;
                txtPrice.BackColor = Color.OrangeRed;
            }
            else
            {
                txtPrice.BackColor = Color.White;
            }
            if (image == null)
            {
                err++;
                MessageBox.Show("Select picture", "Warnings");
            }
            if (err != 0)
            {
                MessageBox.Show("Input again!", "Warnings");
                return null;
            }
            MotorbikeDTO nvDTO = new MotorbikeDTO();
            nvDTO.MOTONAME = txtName.Text;
            nvDTO.PRODUCER = txtProducer.Text;
            nvDTO.CAPACITY = int.Parse(txtCapacity.Text);
            nvDTO.COLOR = txtColor.Text;
            nvDTO.PICTURE = image;
            nvDTO.PRICE = double.Parse(txtPrice.Text);
            return nvDTO;
        }
        private void DGV_Motobike_Click(object sender, EventArgs e)
        {
            if (DGV_Motorbike.SelectedRows.Count != 0)
            {
                btnXoa.Enabled = true;
                DataGridViewRow dr = DGV_Motorbike.SelectedRows[0];
                lblMotoID.Text = dr.Cells["MOTOID"].Value.ToString();
                txtName.Text = dr.Cells["MOTONAME"].Value.ToString();
                txtProducer.Text = dr.Cells["PRODUCER"].Value.ToString();
                txtCapacity.Text = dr.Cells["CAPACITY"].Value.ToString();
                txtColor.Text = dr.Cells["COLOR"].Value.ToString();
                txtPrice.Text = dr.Cells["PRICE"].Value.ToString();
                pBMotorbike.SizeMode = PictureBoxSizeMode.Zoom;
                pBMotorbike.Image = ByteToImage((byte[])dr.Cells["PICTURE"].Value);
                image = (byte[])dr.Cells["PICTURE"].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MotorbikeDTO nvDTO = CheckControl();
            if (nvDTO != null)
            {
                nvDTO = MotoBUS.AddMOTORBIKE(nvDTO);
                if (nvDTO != null)
                {
                    lstNV.Add(nvDTO);
                    List<MotorbikeDTO> lstBaoHiem = MotoBUS.LoadMOTORBIKE();
                    DGV_Motorbike.DataSource = typeof(List<OrderDTO>);
                    if (lstBaoHiem != null)
                    {
                        DGV_Motorbike.DataSource = lstBaoHiem;
                        DGV_Motorbike.Columns["PRICE"].DefaultCellStyle.Format = "n";
                    }
                    else
                    {
                        DGV_Motorbike.DataSource = null;
                    }
                    MessageBox.Show("Add new motorbike success!", "Notification");
                }
                else
                {
                    MessageBox.Show("Add new motorbike fail!", "Notification");
                }
            }
        }

        private void pBMotorbike_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG |*.jpg| PNG |*png|All File |*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName.ToString();
                pBMotorbike.SizeMode = PictureBoxSizeMode.Zoom;
            }
            if (path != "")
            {
                FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader bnr = new BinaryReader(fstream);
                image = bnr.ReadBytes((int)fstream.Length);
                pBMotorbike.Image = ByteToImage(image);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            MotorbikeDTO nvDTO = CheckControl();
            if (nvDTO != null)
            {
                nvDTO.MOTOID = int.Parse(lblMotoID.Text);
                nvDTO.PICTURE = image;
            }
            MotorbikeDTO nvUpdateDTO = MotoBUS.UpdateMOTORBIKE(nvDTO);
            if (nvUpdateDTO != null)
            {
                MotorbikeDTO nvUpdate = lstNV.SingleOrDefault(n => n.MOTOID == nvUpdateDTO.MOTOID);
                nvUpdate.MOTOID = nvUpdateDTO.MOTOID;
                nvUpdate.MOTONAME = nvUpdateDTO.MOTONAME;
                nvUpdate.CAPACITY = nvUpdateDTO.CAPACITY;
                nvUpdate.PICTURE = nvUpdateDTO.PICTURE;
                nvUpdate.PRICE = nvUpdateDTO.PRICE;
                nvUpdate.COLOR = nvUpdateDTO.COLOR;
                nvUpdate.PRODUCER = nvUpdateDTO.PRODUCER;
                LoadDgvNhanVien();
            }
            else
            {
                MessageBox.Show("Update fail.", "Warnings");
                return;
            }
            MessageBox.Show("Update success.", "Warnings");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maNV = int.Parse(lblMotoID.Text);
            if (MotoBUS.DeleteMOTORBIKE(maNV) == true)
            {
                MotorbikeDTO nvDTO = lstNV.SingleOrDefault(n => n.MOTOID == maNV);
                lstNV.Remove(nvDTO);
                MessageBox.Show("Delete success.", "Notification");
                btnXoa.Enabled = false;
                return;
            }
            MessageBox.Show("Delete fail.", "Notification");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblMotoID.Text = "";
            txtName.Text = "";
            txtCapacity.Text = "";
            txtColor.Text = "";
            txtPrice.Text = "";
            txtProducer.Text = "";
            pBMotorbike.Image = null;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string tk = txtTuKhoa.Text;
            string tkProducer = txtCheckProducer.Text;
            //if (tk.Trim() != "")
            //{
                List<MotorbikeDTO> lstKQTK = lstNV.Where(n => (n.MOTONAME.ToLower()).Contains(tk.ToLower())).ToList();
                if (lstKQTK.Count == 0)
                {
                    int maNV;
                    bool kt = int.TryParse(tk, out maNV);
                    if (kt == true)
                    {
                        lstKQTK = lstNV.Where(n => n.MOTOID == maNV).ToList();
                    }
                }
                if (cbProducer.Checked == true)
                {
                    lstKQTK = lstKQTK.Where(n => (n.PRODUCER.ToLower()).Contains(tkProducer.ToLower())).ToList();
                }
                if(cbPrice.Checked==true)
                {
                    string money = cmbCheckPrice.SelectedItem.ToString();
                    if (money == "<=25.000.000")
                    {
                        lstKQTK = lstKQTK.Where(n => n.PRICE<=25000000).ToList();
                    }
                    else if(money==">25.000.000")
                    {
                        lstKQTK = lstKQTK.Where(n => n.PRICE > 25000000).ToList();
                    }
                }
                int soKQ = lstKQTK.Count();
                if (soKQ != 0)
                {
                    MessageBox.Show("Found " + soKQ + " motorbike: " + tk, "Notification");
                }
                else
                {
                    MessageBox.Show("Not found motorbike: " + tk, "Notification");
                    LoadDgvNhanVien();
                }
                DGV_Motorbike.DataSource = lstKQTK;
            //}
            //else
            //{
            //    MessageBox.Show("Input key need to find.", "Warnings");
            //    LoadDgvNhanVien();
            //}
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucManHinhChinh ucMHC = new ucManHinhChinh();
            ucMHC.Dock = DockStyle.Fill;
            Form1.FrmMain.MetroContainer.Controls.Add(ucMHC);
            Form1.FrmMain.MetroContainer.Controls["ucManHinhChinh"].BringToFront();
            foreach (InforMotorbike temp in Form1.FrmMain.MetroContainer.Controls.OfType<InforMotorbike>())
            {
                Form1.FrmMain.MetroContainer.Controls.Remove(temp);
            }
        }
    }
}
