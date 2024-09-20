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
    public partial class GUI_HDB : Form
    {
        BUS_HDBan bus_hdb = new BUS_HDBan();
        BUS_CTHDBan bus_cthdb = new BUS_CTHDBan();
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        int hang;
        public string chosen_mahdb;
        public string chosen_tongtien;
        public GUI_HDB()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            chosen_mahdb = "";
            chosen_tongtien = "0";
            this.Close();
        }

        private void GUI_HDB_Load(object sender, EventArgs e)
        {
            dgvHDBan.DataSource = bus_hdb.getHDBan();
            dgvHDBan.Columns[0].HeaderText = "Mã hóa đơn";
            dgvHDBan.Columns[1].HeaderText = "Mã nhân viên";
            dgvHDBan.Columns[2].HeaderText = "Mã khách hàng";
            dgvHDBan.Columns[3].HeaderText = "Ngày bán";
            dgvHDBan.Columns[4].HeaderText = "Tổng tiền";
            cmbKH.DataSource = bus_kh.getKhachHang();
            cmbKH.ValueMember = "MaKhachHang";
            cmbKH.DisplayMember = "TenKhachHang";
            cmbKH.SelectedIndex = 0;
            cmbNV.DataSource = bus_nv.getNhanVien();
            cmbNV.ValueMember = "MaNhanVien";
            cmbNV.DisplayMember = "TenNhanVien";
            cmbNV.SelectedIndex = 0;
            btnHuy.Enabled = false;
            btnLoc.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtMaHD.Enabled = true;
            cmbNV.Enabled = true;
            cmbKH.Enabled = true;
            chkNgay.Enabled = true;
            btnLoc.Enabled = true;
            btnHuy.Enabled = true;
            btnTimKiem.Enabled = false;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = bus_hdb.getHDBan().DefaultView;
            string mahdb = txtMaHD.Text;
            string sql = "MaHDBan like '%" + mahdb + "%'";
            if (cmbKH.SelectedIndex != 0)
            {
                string kh = cmbKH.SelectedValue.ToString();
                sql = sql + " and MaKhachHang = '" + kh + "'";
            }
            if (cmbNV.SelectedIndex != 0)
            {
                string nv = cmbNV.SelectedValue.ToString();
                sql = sql + " and MaNhanVien = '" + nv + "'";
            }
            if (chkNgay.Checked)
            {
                string ngay = string.Format("{0}/{1}/{2}", dtpNgayBan.Value.Year, dtpNgayBan.Value.Month, dtpNgayBan.Value.Day);
                sql = sql + " and NgayBan like '%" + ngay + "'";
            }
            dv.RowFilter = sql;
            dgvHDBan.DataSource = dv;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Trim() == "")
            {
                MessageBox.Show("Đề nghị chọn hóa đơn");
            }
            else
            {
                chosen_mahdb = txtMaHD.Text;
                chosen_tongtien = txtTongTien.Text;
                GUI_HoaDonBan hdb = new GUI_HoaDonBan();
                hdb.Mahdban = chosen_mahdb;
                hdb.TT = chosen_tongtien;
                this.Close();
            }
        }

        private void dgvHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            try
            {
                string date = string.Format("{0}/{1}/{2}", dtpNgayBan.Value.Year, dtpNgayBan.Value.Month, dtpNgayBan.Value.Day);
                txtMaHD.Text = dgvHDBan[0, hang].Value.ToString();
                cmbNV.SelectedValue = dgvHDBan[1, hang].Value.ToString();
                cmbKH.SelectedValue = dgvHDBan[2, hang].Value.ToString();
                dtpNgayBan.Text = dgvHDBan[3, hang].Value.ToString();
                txtTongTien.Text = dgvHDBan[4, hang].Value.ToString();
                txtMaHD.Enabled = false;
                cmbNV.Enabled = false;
                cmbKH.Enabled = false;
                dtpNgayBan.Enabled = false;
                txtTongTien.Enabled = false;
                btnLoc.Enabled = false;
                btnChon.Enabled = true;
            }
            catch
            {
                txtMaHD.Enabled = false;
                cmbNV.Enabled = false;
                cmbKH.Enabled = false;
                dtpNgayBan.Enabled = false;
                txtTongTien.Enabled = false;
                btnChon.Enabled = false;
                return;
            }
        }

        private void chkNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgay.Checked)
            {
                dtpNgayBan.Enabled = true;
            }
            else
            {
                dtpNgayBan.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvHDBan.DataSource = bus_hdb.getHDBan();
            cmbKH.SelectedIndex = 0;
            cmbNV.SelectedIndex = 0;
            btnHuy.Enabled = false;
            btnLoc.Enabled = false;
            btnTimKiem.Enabled = true;
            txtMaHD.Clear();
            txtTongTien.Clear();
            dtpNgayBan.Refresh();
        }
    }
}
