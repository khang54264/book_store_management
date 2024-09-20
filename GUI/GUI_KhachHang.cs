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
    public partial class GUI_KhachHang : Form
    {
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        int hang;
        public GUI_KhachHang()
        {
            InitializeComponent();
        }

        private void GUI_KhachHang_Load(object sender, EventArgs e)
        {
            dgvKH.DataSource = bus_kh.getKhachHang();
            dgvKH.Columns[0].HeaderText = "Mã KH";
            dgvKH.Columns[1].HeaderText = "Tên KH";
            dgvKH.Columns[2].HeaderText = "Số điện thoại";
            dgvKH.Columns[3].HeaderText = "Địa chỉ";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaKH.Text;
            string ten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;         
            KhachHang s = new KhachHang(ma, ten, sdt, diachi);
            if (bus_kh.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã KH bị trùng");
            }
            else
            {
                if (bus_kh.addKhachHang(s) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvKH.DataSource = bus_kh.getKhachHang();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaKH.Text;
            string ten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;       
            string macu = dgvKH[0, hang].Value.ToString();
            KhachHang s = new KhachHang(ma, ten, sdt, diachi);
            if (macu != ma)
            {
                if (bus_kh.kiemtramatrung(ma) == 1)
                {
                    MessageBox.Show("Mã khách hàng bị trùng");
                }
            }
            else
            {
                if (bus_kh.updKhachHang(s, macu) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvKH.DataSource = bus_kh.getKhachHang();
                }
            }
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;      
            txtMaKH.Text = dgvKH[0, hang].Value.ToString();
            txtTenKH.Text = dgvKH[1, hang].Value.ToString();
            txtSDT.Text = dgvKH[2, hang].Value.ToString();
            txtDiaChi.Text = dgvKH[3, hang].Value.ToString();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = bus_kh.getKhachHang().DefaultView;
            string ten = txtTimTenKH.Text;
            string sql = "TenKhachHang like '%" + ten + "%'";
            dv.RowFilter = sql;
            dgvKH.DataSource = dv;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvKH.DataSource = bus_kh.getKhachHang();
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtTimTenKH.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaKH.Text;
            if (bus_kh.delKhachHang(ma) == true)
            {
                MessageBox.Show("Xóa thành công");
                dgvKH.DataSource = bus_kh.getKhachHang();
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
