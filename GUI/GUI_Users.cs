using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace GUI
{
    public partial class GUI_Users : Form
    {
        BUS_Users bus_users = new BUS_Users();
        int hang;
        public GUI_Users()
        {
            InitializeComponent();
        }

        private void GUI_Users_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = bus_users.getUsers();
            dgvUsers.Columns[0].HeaderText = "Username";
            dgvUsers.Columns[1].HeaderText = "Password";
            dgvUsers.Columns[2].HeaderText = "Quyền";
            dgvUsers.Columns[3].HeaderText = "Mã nhân viên";
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            GUI_NhanVien nv = new GUI_NhanVien();
            this.Hide();
            nv.ShowDialog();
            this.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            int quyen;
            if (cmbPer.SelectedValue.ToString() == "Quản lý")
                quyen = 0;
            else
                quyen = 1;
            string manv = txtMaNV.Text;
            Users s = new Users(user, pass, quyen, manv);
            if (bus_users.kiemtramatrung(user) == 1)
            {
                MessageBox.Show("Username bị trùng");
            }
            else
            {
                if (bus_users.addUsers(s) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvUsers.DataSource = bus_users.getUsers();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            int quyen;
            if (cmbPer.SelectedValue.ToString() == "Quản lý")
                quyen = 0;
            else
                quyen = 1;
            string manv = txtMaNV.Text;
            Users s = new Users(user, pass, quyen, manv);
            if (bus_users.updUsers(s) == true)
            {
                MessageBox.Show("Sửa thành công");
                dgvUsers.DataSource = bus_users.getUsers();
                btnSua.Enabled = false;
                txtUser.Clear();
                txtPass.Clear();
                cmbPer.SelectedIndex = -1;
                txtMaNV.Clear();
                txtTimMaNV.Clear();
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = bus_users.getUsers().DefaultView;
            string ten = txtTimMaNV.Text;
            string sql = "MaNhanVien like '%" + ten + "%'";
            dv.RowFilter = sql;
            dgvUsers.DataSource = dv;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            txtUser.Clear();
            txtPass.Clear();
            txtMaNV.Clear();
            cmbPer.SelectedIndex = -1;
            txtTimMaNV.Clear();
            dgvUsers.DataSource = bus_users.getUsers();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            if (bus_users.delUsers(user) == true)
            {
                MessageBox.Show("Xóa thành công");
                dgvUsers.DataSource = bus_users.getUsers();
                btnXoa.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            try
            {
                txtUser.Text = dgvUsers[0, hang].Value.ToString();
                txtPass.Text = dgvUsers[1, hang].Value.ToString();
                string per = dgvUsers[2, hang].Value.ToString();
                if (per == "0")
                    cmbPer.SelectedIndex = 0;
                if (per == "1")
                txtMaNV.Text = dgvUsers[3, hang].Value.ToString();
                btnSua.Enabled = true;
                txtUser.Enabled = false;
                btnXoa.Enabled = true;
            }
            catch
            {

                return;
            }
        }
    }
}
