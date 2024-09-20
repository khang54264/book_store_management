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
    public partial class GUI_NXB : Form
    {
        BUS_NXB bus_nxb = new BUS_NXB();
        int hang;
        public GUI_NXB()
        {
            InitializeComponent();
        }

        private void GUI_NXB_Load(object sender, EventArgs e)
        {
            dgvNXB.DataSource = bus_nxb.getNXB();
            dgvNXB.Columns[0].HeaderText = "Mã NXB";
            dgvNXB.Columns[1].HeaderText = "Tên NXB";
            dgvNXB.Columns[2].HeaderText = "Địa Chỉ";
            dgvNXB.Columns[3].HeaderText = "Số điện thoại";
            dgvNXB.Columns[4].HeaderText = "Email";
            dgvNXB.Columns[5].HeaderText = "Website";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text;
            string ten = txtTenNXB.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string website = txtWebsite.Text;
            NXB s = new NXB(ma, ten, diachi, sdt, email, website);
            if (bus_nxb.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã NXB bị trùng");
            }
            else
            {
                if (bus_nxb.addNXB(s) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvNXB.DataSource = bus_nxb.getNXB();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text;
            string ten = txtTenNXB.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string website = txtWebsite.Text;
            string macu = dgvNXB[0, hang].Value.ToString();
            NXB s = new NXB(ma, ten, diachi, sdt, email, website);
            if (macu != ma)
            {
                if (bus_nxb.kiemtramatrung(ma) == 1)
                {
                    MessageBox.Show("Mã NXB bị trùng");
                }
            }
            else
            {
                if (bus_nxb.updNXB(s, macu) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvNXB.DataSource = bus_nxb.getNXB();
                }
            }
        }

        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            txtMaNXB.Text = dgvNXB[0, hang].Value.ToString();
            txtTenNXB.Text = dgvNXB[1, hang].Value.ToString();
            txtDiaChi.Text = dgvNXB[2, hang].Value.ToString();
            txtSDT.Text = dgvNXB[3, hang].Value.ToString();
            txtEmail.Text = dgvNXB[4, hang].Value.ToString();
            txtWebsite.Text = dgvNXB[5, hang].Value.ToString();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = bus_nxb.getNXB().DefaultView;
            string ten = txtTimTenNXB.Text;
            string sql = "TenNXB like '%" + ten + "%'";
            dv.RowFilter = sql;
            dgvNXB.DataSource = dv;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvNXB.DataSource = bus_nxb.getNXB();
            txtMaNXB.Clear();
            txtTenNXB.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtWebsite.Clear();
            txtTimTenNXB.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaNXB.Text;
            if (bus_nxb.delNXB(ma) == true)
            {
                MessageBox.Show("Xóa thành công");
                dgvNXB.DataSource = bus_nxb.getNXB();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Trim().Length > 0 && !char.IsDigit(txtSDT.Text, txtSDT.Text.Length - 1))
            {
                MessageBox.Show("Nhập số!");
                txtSDT.Undo();
            }
        }
    }
}
