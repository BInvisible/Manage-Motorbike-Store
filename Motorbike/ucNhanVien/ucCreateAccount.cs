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

namespace Motorbike.ucNhanVien
{
    public partial class ucCreateAccount : UserControl
    {
        List<LoginDTO> lstDTO;
        public ucCreateAccount()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            lstDTO = LoginBUS.LoadLogin();
            LoadDgvAccount();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            LoginDTO nvDTO = CheckControl();

            if (nvDTO != null)
            {
                nvDTO = LoginBUS.AddLogin(nvDTO);
                if (nvDTO != null)
                {
                    lstDTO.Add(nvDTO);
                    //LoadDgvNhanVien();
                    MessageBox.Show("Add new account success!", "Notification");
                }
                else
                {
                    MessageBox.Show("Add new account fail!", "Notification");
                }
            }
        }

        private LoginDTO CheckControl()
        {
            int err = 0;
            if (txtUsername.Text.Trim() == "")
            {
                err++;
                txtUsername.BackColor = Color.OrangeRed;
            }
            else
            {
                txtUsername.BackColor = Color.White;
            }
            if (txtPass.Text.Trim() == "")
            {
                err++;
                txtPass.BackColor = Color.OrangeRed;
            }
            else
            {
                txtPass.BackColor = Color.White;
            }
            if (txtReEnter.Text.Trim() == "")
            {
                err++;
                txtReEnter.BackColor = Color.OrangeRed;
            }
            else
            {
                txtReEnter.BackColor = Color.White;
            }
            if (txtReEnter.Text.Trim() != txtPass.Text.Trim())
            {
                err++;
                txtReEnter.BackColor = Color.OrangeRed;
                txtPass.BackColor = Color.OrangeRed;
                MessageBox.Show("Password doesn't match", "Warnings");
            }
            if (cmbAuthority.Text.Trim() == "")
            {
                err++;
                cmbAuthority.BackColor = Color.OrangeRed;
            }
            else
            {
                cmbAuthority.BackColor = Color.White;
            }
            if (err != 0)
            {
                MessageBox.Show("Input again!", "Warnings");
                return null;
            }
            LoginDTO logDTO = new LoginDTO();
            logDTO.Username = txtUsername.Text;
            logDTO.Password = txtPass.Text;
            logDTO.Authority = cmbAuthority.Text;
            return logDTO;
        }
        void LoadDgvAccount()
        {
            DGV_account.DataSource = typeof(List<LoginDTO>);
            DGV_account.DataSource = lstDTO;

            AutoCompleteStringCollection ascNV = new AutoCompleteStringCollection();
            if (lstDTO.Count != 0)
            {
                foreach (var item in lstDTO)
                {
                    ascNV.Add(item.Username);

                }
            }
            txtTuKhoa.AutoCompleteCustomSource = ascNV;
        }

        private void DGV_account_Click(object sender, EventArgs e)
        {
            if (DGV_account.SelectedRows.Count != 0)
            {
                btnXoa.Enabled = true;
                DataGridViewRow dr = DGV_account.SelectedRows[0];
                txtUsername.Text = dr.Cells["Username"].Value.ToString();
                txtPass.Text = dr.Cells["Password"].Value.ToString();
                txtReEnter.Text= dr.Cells["Password"].Value.ToString();
                cmbAuthority.Text = dr.Cells["Authority"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoginDTO logDTO = CheckControl();
            if (logDTO != null)
            {
                logDTO.Username =txtUsername.Text ;
            }
            LoginDTO logUpdateDTO = LoginBUS.UpdateLogin(logDTO);
            if (logUpdateDTO != null)
            {
                LoginDTO logUpdate = lstDTO.SingleOrDefault(n => n.Username == logUpdateDTO.Username);
                logUpdate.Username = logUpdateDTO.Username;
                logUpdate.Password = logUpdateDTO.Password;
                logUpdate.Authority = logUpdateDTO.Authority;
                LoadDgvAccount();
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
            string username = txtUsername.Text;
            if (LoginBUS.DeleteAccount(username) == true)
            {
                LoginDTO logDTO = lstDTO.SingleOrDefault(n => n.Username == username);
                lstDTO.Remove(logDTO);
                LoadDgvAccount();
                MessageBox.Show("Delete success.", "Notification");
                btnXoa.Enabled = false;
                return;
            }
            MessageBox.Show("Delete fail.", "Notification");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPass.Text = "";
            txtReEnter.Text = "";
            cmbAuthority.Text = "";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string tk = txtTuKhoa.Text;
            //if (tk.Trim() != "")
            //{
            List<LoginDTO> lstKQTK = lstDTO.Where(n => (n.Username.ToLower()).Contains(tk.ToLower())).ToList();
            if (lstKQTK.Count == 0)
            {
                lstKQTK = lstDTO.Where(n => n.Username == tk).ToList();
            }
            if (mcbCheckAuthority.Checked == true)
            {
                string authority = cmbCheckAuthority.SelectedItem.ToString();
                if (authority == "employee")
                {
                    lstKQTK = lstKQTK.Where(n => n.Authority =="employee").ToList();
                }
                else if (authority == "admin")
                {
                    lstKQTK = lstKQTK.Where(n => n.Authority =="admin").ToList();
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
                LoadDgvAccount();
            }
            DGV_account.DataSource = lstKQTK;
        }
    }
}

