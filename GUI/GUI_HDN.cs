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
    public partial class GUI_HDN : Form
    {
        BUS_HDNhap bus_hdn = new BUS_HDNhap();
        BUS_CTHDNhap bus_cthdn = new BUS_CTHDNhap();
        BUS_NXB bus_nxb = new BUS_NXB();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        int hang;
        public string chosen_mahdn;
        public string chosen_tongtien;
        public GUI_HDN()
        {
            InitializeComponent();
        }

        private void GUI_HDN_Load(object sender, EventArgs e)
        {
            dgvHDNhap.DataSource = bus_hdn.getHDNhap();
            dgvHDNhap.Columns[0].HeaderText = "Mã hóa đơn";
            dgvHDNhap.Columns[1].HeaderText = "Mã nhân viên";
            dgvHDNhap.Columns[2].HeaderText = "Mã nhà xuất bản";
            dgvHDNhap.Columns[3].HeaderText = "Ngày nhập";
            dgvHDNhap.Columns[4].HeaderText = "Tổng tiền";
            cmbNXB.DataSource = bus_nxb.getNXB();
            cmbNXB.ValueMember = "MaNXB";
            cmbNXB.DisplayMember = "TenNXB";
            cmbNXB.SelectedIndex = 0;
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
            cmbNXB.Enabled = true;
            chkNgay.Enabled = true;
            btnLoc.Enabled = true;
            btnHuy.Enabled = true;
            btnTimKiem.Enabled = false;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = bus_hdn.getHDNhap().DefaultView;
            string mahdn = txtMaHD.Text;
            string sql = "MaHDNhap like '%" + mahdn + "%'";
            if (cmbNXB.SelectedIndex != 0)
            {
                string nxb = cmbNXB.SelectedValue.ToString();
                sql = sql + " and MaNXB = '" + nxb + "'";
            }
            if (cmbNV.SelectedIndex != 0)
            {
                string nv = cmbNV.SelectedValue.ToString();
                sql = sql + " and MaNhanVien = '" + nv + "'";
            }
            if (chkNgay.Checked)
            {
                string ngay = string.Format("{0}/{1}/{2}", dtpNgayNhap.Value.Year, dtpNgayNhap.Value.Month, dtpNgayNhap.Value.Day);
                sql = sql + " and NgayNhap like '%" + ngay + "'";
            }
            dv.RowFilter = sql;
            dgvHDNhap.DataSource = dv;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Trim()=="")
            {
                MessageBox.Show("Đề nghị chọn hóa đơn");
            }
            else
            {
                chosen_mahdn = txtMaHD.Text;
                chosen_tongtien = txtTongTien.Text;
                GUI_HoaDonNhap hdn = new GUI_HoaDonNhap();
                hdn.Mahdnhap=chosen_mahdn;
                hdn.TT = chosen_tongtien;
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            chosen_mahdn = "";
            chosen_tongtien = "0";
            this.Close();
        }

        private void dgvHDNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            try
            {
                string date = string.Format("{0}/{1}/{2}", dtpNgayNhap.Value.Year, dtpNgayNhap.Value.Month, dtpNgayNhap.Value.Day);
                txtMaHD.Text = dgvHDNhap[0, hang].Value.ToString();
                cmbNV.SelectedValue = dgvHDNhap[1, hang].Value.ToString();
                cmbNXB.SelectedValue = dgvHDNhap[2, hang].Value.ToString();
                dtpNgayNhap.Text = dgvHDNhap[3, hang].Value.ToString();
                txtTongTien.Text = dgvHDNhap[4, hang].Value.ToString();
                txtMaHD.Enabled = false;
                cmbNV.Enabled = false;
                cmbNXB.Enabled = false;
                dtpNgayNhap.Enabled = false;
                txtTongTien.Enabled = false;
                btnLoc.Enabled = false;
                btnChon.Enabled = true;
            }
            catch
            {
                txtMaHD.Enabled = false;
                cmbNV.Enabled = false;
                cmbNXB.Enabled = false;
                dtpNgayNhap.Enabled = false;
                txtTongTien.Enabled = false;
                btnChon.Enabled = false;
                return;
            }
        }

        private void chkNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgay.Checked)
            {
                dtpNgayNhap.Enabled = true;
            }
            else
            {
                dtpNgayNhap.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvHDNhap.DataSource = bus_hdn.getHDNhap();
            cmbNXB.SelectedIndex = 0;
            cmbNV.SelectedIndex = 0;
            btnHuy.Enabled = false;
            btnLoc.Enabled = false;
            btnTimKiem.Enabled = true;
            txtMaHD.Clear();
            txtTongTien.Clear();
            dtpNgayNhap.Refresh();
        }
    }
}
