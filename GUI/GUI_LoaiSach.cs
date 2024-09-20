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
    public partial class GUI_LoaiSach : Form
    {
        BUS_LoaiSach bus_loaisach = new BUS_LoaiSach();
        int hang;
        public GUI_LoaiSach()
        {
            InitializeComponent();
        }

        private void GUI_LoaiSach_Load(object sender, EventArgs e)
        {
            dgvLSach.DataSource = bus_loaisach.getLoaiSach();
            dgvLSach.Columns[0].HeaderText = "Mã loại sách";
            dgvLSach.Columns[1].HeaderText = "Tên loại sách";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaLSach.Text;
            string ten = txtTenLSach.Text;
            LoaiSach s = new LoaiSach(ma, ten);
            if (bus_loaisach.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã loại sách bị trùng");
            }
            else
            {
                if (bus_loaisach.addLoaiSach(s) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvLSach.DataSource = bus_loaisach.getLoaiSach();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaLSach.Text;
            string ten = txtTenLSach.Text;
            string macu = dgvLSach[0, hang].Value.ToString();
            LoaiSach s = new LoaiSach(ma, ten);
            if (macu != ma)
            {
                if (bus_loaisach.kiemtramatrung(ma) == 1)
                {
                    MessageBox.Show("Mã loại sách bị trùng");
                }
            }
            else
            {
                if (bus_loaisach.updLoaiSach(s, macu) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvLSach.DataSource = bus_loaisach.getLoaiSach();
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = bus_loaisach.getLoaiSach().DefaultView;
            string ten = txtTimTenLSach.Text;
            string sql = "TenLoaiSach like '%" + ten + "%'";
            dv.RowFilter = sql;
            dgvLSach.DataSource = dv;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvLSach.DataSource = bus_loaisach.getLoaiSach();
            txtMaLSach.Clear();
            txtTenLSach.Clear();
            txtTimTenLSach.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaLSach.Text;
            if (bus_loaisach.delLoaiSach(ma) == true)
            {
                MessageBox.Show("Xóa thành công");
                dgvLSach.DataSource = bus_loaisach.getLoaiSach();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            txtMaLSach.Text = dgvLSach[0, hang].Value.ToString();
            txtTenLSach.Text = dgvLSach[1, hang].Value.ToString();
        }
    }
}
