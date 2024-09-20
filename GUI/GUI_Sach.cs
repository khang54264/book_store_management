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
    public partial class GUI_Sach : Form
    {
        BUS_Sach bus_sach = new BUS_Sach();
        BUS_LoaiSach bus_loaisach = new BUS_LoaiSach();
        BUS_TacGia bus_tacgia = new BUS_TacGia();
        BUS_NXB bus_nxb = new BUS_NXB();
        int hang;
        public GUI_Sach()
        {
            InitializeComponent();
        }

        private void GUI_Sach_Load(object sender, EventArgs e)
        {
            dgvSach.DataSource = bus_sach.getSach();
            dgvSach.Columns[0].HeaderText = "Mã sách";
            dgvSach.Columns[1].HeaderText = "Tên sách";
            dgvSach.Columns[2].HeaderText = "Mã loại sách";
            dgvSach.Columns[3].HeaderText = "Mã tác giả";
            dgvSach.Columns[4].HeaderText = "Mã nhà xuất bản";
            dgvSach.Columns[5].HeaderText = "Số lượng";
            dgvSach.Columns[6].HeaderText = "Đơn giá";
            cmbLoaiSach.DataSource = bus_loaisach.getLoaiSach();
            cmbLoaiSach.ValueMember = "MaLoaiSach";
            cmbLoaiSach.DisplayMember = "TenLoaiSach";
            cmbLoaiSach.SelectedIndex = 0;
            cmbTacGia.DataSource = bus_tacgia.getTacGia();
            cmbTacGia.ValueMember = "MaTacGia";
            cmbTacGia.DisplayMember = "TenTacGia";
            cmbTacGia.SelectedIndex = 0;
            cmbNXB.DataSource = bus_nxb.getNXB();
            cmbNXB.ValueMember = "MaNXB";
            cmbNXB.DisplayMember = "TenNXB";
            cmbNXB.SelectedIndex = 0;
            cmbTimLoaiSach.DataSource = bus_loaisach.getLoaiSach();
            cmbTimLoaiSach.ValueMember = "MaLoaiSach";
            cmbTimLoaiSach.DisplayMember = "TenLoaiSach";
            cmbTimLoaiSach.SelectedIndex = 0;
            cmbTimTacGia.DataSource = bus_tacgia.getTacGia();
            cmbTimTacGia.ValueMember = "MaTacGia";
            cmbTimTacGia.DisplayMember = "TenTacGia";
            cmbTimTacGia.SelectedIndex = 0;
            cmbTimNXB.DataSource = bus_nxb.getNXB();
            cmbTimNXB.ValueMember = "MaNXB";
            cmbTimNXB.DisplayMember = "TenNXB";
            cmbTimNXB.SelectedIndex = 0;
            /*
            if (txtDonGia.Text.Length >= 4)
            {
            // Chuyển đổi giá trị nhập vào thành double
            double sl = double.Parse(txtDonGia.Text);

            // Hiển thị giá trị với dấu phẩy
            txtDonGia.Text = sl.ToString("N0");
            }
            */
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text;
            string ten = txtTenSach.Text;
            string loai = cmbLoaiSach.SelectedValue.ToString();
            string tg = cmbTacGia.SelectedValue.ToString();
            string nxb = cmbNXB.SelectedValue.ToString();
            int sl = int.Parse(txtSoLuong.Text);
            float gia = float.Parse(txtDonGia.Text);
            Sach s = new Sach(ma, ten, loai, tg, nxb, sl, gia);
            if (bus_sach.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã sách bị trùng");
            }
            else
            {
                if (bus_sach.addSach(s) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvSach.DataSource = bus_sach.getSach();
                }
            }          
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            try
            {
                txtMaSach.Text = dgvSach[0, hang].Value.ToString();
                txtTenSach.Text = dgvSach[1, hang].Value.ToString();
                cmbLoaiSach.SelectedValue = dgvSach[2, hang].Value.ToString();
                cmbTacGia.SelectedValue = dgvSach[3, hang].Value.ToString();
                cmbNXB.SelectedValue = dgvSach[4, hang].Value.ToString();
                txtSoLuong.Text = dgvSach[5, hang].Value.ToString();
                txtDonGia.Text = dgvSach[6, hang].Value.ToString();
            }
            catch
            {
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text;
            string ten = txtTenSach.Text;
            string loai = cmbLoaiSach.SelectedValue.ToString();
            string tg = cmbTacGia.SelectedValue.ToString();
            string nxb = cmbNXB.SelectedValue.ToString();
            int sl = int.Parse(txtSoLuong.Text);
            float gia = float.Parse(txtDonGia.Text);
            string macu = dgvSach[0, hang].Value.ToString();
            Sach s = new Sach(ma, ten, loai, tg, nxb, sl, gia);
            if (macu!=ma)
            {
                if (bus_sach.kiemtramatrung(ma) == 1)
                {
                    MessageBox.Show("Mã sách bị trùng");
                }
            }
            else
            {
                if (bus_sach.updSach(s, macu) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvSach.DataSource = bus_sach.getSach();
                }
            }         
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaSach.Text;
            if (bus_sach.delSach(ma) == true)
            {
                MessageBox.Show("Xóa thành công");
                dgvSach.DataSource = bus_sach.getSach();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvSach.DataSource = bus_sach.getSach();
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtSoLuong.Clear();
            txtDonGia.Clear();
            txtTimTenSach.Clear();
            cmbLoaiSach.SelectedIndex = 0;
            cmbTacGia.SelectedIndex = 0;
            cmbNXB.SelectedIndex = 0;
            cmbTimLoaiSach.SelectedIndex = 0;
            cmbTimTacGia.SelectedIndex = 0;
            cmbTimNXB.SelectedIndex = 0;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = bus_sach.getSach().DefaultView;            
            string ten = txtTimTenSach.Text;
            string sql = "TenSach like '%" + ten + "%'";
            if (cmbTimLoaiSach.SelectedIndex != 0)
            {
                string ls = cmbTimLoaiSach.SelectedValue.ToString();
                sql = sql + " and MaLoaiSach = '" + ls + "'";
            }
            if (cmbTimTacGia.SelectedIndex != 0)
            {
                string tg = cmbTimTacGia.SelectedValue.ToString();
                sql = sql + " and MaTacGia = '" + tg + "'";
            }
            if (cmbTimNXB.SelectedIndex != 0)
            {
                string nxb = cmbTimNXB.SelectedValue.ToString();
                sql = sql + " and MaNXB = '" + nxb + "'";
            }
            dv.RowFilter = sql;
            dgvSach.DataSource = dv;
        }

        private void btnFLoaiSach_Click(object sender, EventArgs e)
        {
            GUI_LoaiSach loaisach = new GUI_LoaiSach();
            loaisach.ShowDialog();
            cmbLoaiSach.DataSource = bus_loaisach.getLoaiSach();
            cmbTimLoaiSach.DataSource = bus_loaisach.getLoaiSach();
        }

        private void btnFTacGia_Click(object sender, EventArgs e)
        {
            GUI_TacGia tacgia = new GUI_TacGia();
            tacgia.ShowDialog();
            cmbTacGia.DataSource = bus_tacgia.getTacGia();
            cmbTimTacGia.DataSource = bus_tacgia.getTacGia();
        }

        private void btnFNXB_Click(object sender, EventArgs e)
        {
            GUI_NXB nxb = new GUI_NXB();
            nxb.ShowDialog();
            cmbNXB.DataSource = bus_nxb.getNXB();
            cmbTimNXB.DataSource = bus_nxb.getNXB();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            float num;
            if (txtSoLuong.Text.Trim().Length > 0 && !char.IsDigit(txtSoLuong.Text, txtSoLuong.Text.Length - 1))
            {
                MessageBox.Show("Nhập số!");
                txtSoLuong.Undo();
            }
            else if (float.TryParse(txtSoLuong.Text, out num))
            {
                if (num <= 0)
                {
                    // Số nhập vào không hợp lệ, thông báo lỗi
                    MessageBox.Show("Vui lòng nhập số dương lớn hơn 0");
                    txtSoLuong.Clear(); // Xóa textbox
                }
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            float num;
            if (txtDonGia.Text.Trim().Length > 0 && !char.IsDigit(txtDonGia.Text, txtDonGia.Text.Length - 1))
            {
                MessageBox.Show("Nhập số!");
                txtDonGia.Undo();
            }
            else if (float.TryParse(txtDonGia.Text, out num))
            {
                if (num <= 0)
                {
                    // Số nhập vào không hợp lệ, thông báo lỗi
                    MessageBox.Show("Vui lòng nhập số dương lớn hơn 0");
                    txtDonGia.Clear(); // Xóa textbox
                }
            }

        }
    }
}
