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
    public partial class GUI_NhanVien : Form
    {
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        int hang;
        public GUI_NhanVien()
        {
            InitializeComponent();
        }

        private void GUI_NhanVien_Load(object sender, EventArgs e)
        {
            dgvNV.DataSource = bus_nv.getNhanVien();
            dgvNV.Columns[0].HeaderText = "Mã NV";
            dgvNV.Columns[1].HeaderText = "Tên NV";
            dgvNV.Columns[2].HeaderText = "Số điện thoại";
            dgvNV.Columns[3].HeaderText = "Ngày sinh";
            dgvNV.Columns[4].HeaderText = "Địa chỉ";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaNV.Text;
            string ten = txtTenNV.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string date = string.Format("{0}/{1}/{2}", dtpNgaySinh.Value.Year, dtpNgaySinh.Value.Month, dtpNgaySinh.Value.Day);
            NhanVien s = new NhanVien(ma, ten, sdt, date, diachi);
            if (bus_nv.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã NV bị trùng");
            }
            else
            {
                if (bus_nv.addNhanVien(s) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvNV.DataSource = bus_nv.getNhanVien();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaNV.Text;
            string ten = txtTenNV.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string date = string.Format("{0}/{1}/{2}", dtpNgaySinh.Value.Year, dtpNgaySinh.Value.Month, dtpNgaySinh.Value.Day);
            string macu = dgvNV[0, hang].Value.ToString();
            NhanVien s = new NhanVien(ma, ten, sdt, date, diachi);
            if (macu != ma)
            {
                if (bus_nv.kiemtramatrung(ma) == 1)
                {
                    MessageBox.Show("Mã nhân viên bị trùng");
                }
            }
            else
            {
                if (bus_nv.updNhanVien(s, macu) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvNV.DataSource = bus_nv.getNhanVien();
                }
            }
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            try
            {
                string date = string.Format("{0}/{1}/{2}", dtpNgaySinh.Value.Year, dtpNgaySinh.Value.Month, dtpNgaySinh.Value.Day);
                txtMaNV.Text = dgvNV[0, hang].Value.ToString();
                txtTenNV.Text = dgvNV[1, hang].Value.ToString();
                txtSDT.Text = dgvNV[2, hang].Value.ToString();
                dtpNgaySinh.Text = dgvNV[3, hang].Value.ToString();
                txtDiaChi.Text = dgvNV[4, hang].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = bus_nv.getNhanVien().DefaultView;
            string ten = txtTimTenNV.Text;
            string sql = "TenNhanVien like '%" + ten + "%'";
            dv.RowFilter = sql;
            dgvNV.DataSource = dv;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvNV.DataSource = bus_nv.getNhanVien();
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            dtpNgaySinh.Refresh();
            txtTimTenNV.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaNV.Text;
            if (bus_nv.delNhanVien(ma) == true)
            {
                MessageBox.Show("Xóa thành công");
                dgvNV.DataSource = bus_nv.getNhanVien();
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
