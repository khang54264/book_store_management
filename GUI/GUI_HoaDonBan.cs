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
    public partial class GUI_HoaDonBan : Form
    {
        BUS_HDBan bus_hdb = new BUS_HDBan();
        BUS_CTHDBan bus_cthdb = new BUS_CTHDBan();
        BUS_Sach bus_sach = new BUS_Sach();
        BUS_KhachHang bus_kh = new BUS_KhachHang();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        private string mahdban;
        private string tt;
        float TongTien;
        float slcu;
        int hang;
        public string Mahdban { get => mahdban; set => mahdban = value; }
        public string TT { get => tt; set => tt = value; }

        public GUI_HoaDonBan()
        {
            InitializeComponent();
        }

        private void GUI_HoaDonBan_Load(object sender, EventArgs e)
        {
            dgvSach.DataSource = bus_cthdb.getTableSach();
            dgvSach.Columns[0].HeaderText = "Mã sách";
            dgvSach.Columns[1].HeaderText = "Tên sách";
            dgvSach.Columns[2].HeaderText = "Số lượng";
            dgvSach.Columns[3].HeaderText = "Đơn giá";
            dgvSach.ClearSelection();
            dgvCTHDBan.DataSource = bus_cthdb.getCTHDBan("");
            dgvCTHDBan.Columns[0].HeaderText = "Mã sách";
            dgvCTHDBan.Columns[1].HeaderText = "Số lượng";
            dgvCTHDBan.Columns[2].HeaderText = "Đơn giá";
            dgvCTHDBan.Columns[3].HeaderText = "Thành tiền";
            dgvSach.ClearSelection();
            cmbKH.DataSource = bus_kh.getKhachHang();
            cmbKH.ValueMember = "MaKhachHang";
            cmbKH.DisplayMember = "TenKhachHang";
            cmbKH.SelectedIndex = 0;
            cmbNV.DataSource = bus_nv.getNhanVien();
            cmbNV.ValueMember = "MaNhanVien";
            cmbNV.DisplayMember = "TenNhanVien";
            cmbNV.SelectedIndex = 0;
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text.Trim()))
            {
                err.SetError(txtMaHD, "Mã hóa đơn không được để trống");
                txtMaHD.Focus();
            }
            else if (cmbKH.SelectedIndex == 0)
            {
                err.SetError(cmbKH, "Hãy chọn khách hàng");
            }
            else if (cmbNV.SelectedIndex == 0)
            {
                err.SetError(cmbNV, "Hãy chọn nhân viên");
            }
            else
            {
                string mahd = txtMaHD.Text;
                string date = string.Format("{0}/{1}/{2}", dtpNgayBan.Value.Year, dtpNgayBan.Value.Month, dtpNgayBan.Value.Day);
                string kh = cmbKH.SelectedValue.ToString().Trim();
                string nv = cmbNV.SelectedValue.ToString().Trim();
                float tt = 0;
                HDBan hdban = new HDBan(mahd, nv, kh, date, tt);
                if (bus_hdb.kiemtramatrung(mahd) == 1)
                {
                    MessageBox.Show("Mã hóa đơn bị trùng");
                    txtMaHD.Focus();
                }
                else
                {
                    if (bus_hdb.addHDBan(hdban) == true)
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvSach.DataSource = bus_cthdb.getTableSach();
                        dgvCTHDBan.DataSource = bus_cthdb.getCTHDBan(mahd);
                        btnTaoHD.Enabled = false;
                        txtMaHD.Enabled = false;
                        dtpNgayBan.Enabled = true;
                        btnSuaHD.Enabled = false;
                        btnLuuHD.Enabled = false;
                        btnHuyHD.Enabled = false;
                        btnXoaHD.Enabled = true;
                    }
                }
            }
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            txtMaHD.Enabled = true;
            txtMaHD.Clear();
            dtpNgayBan.Enabled = true;
            dtpNgayBan.Refresh();
            cmbKH.Enabled = true;
            cmbKH.SelectedIndex = 0;
            cmbNV.Enabled = true;
            cmbNV.SelectedIndex = 0;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTaoHD.Enabled = true;
            btnSuaHD.Enabled = false;
            btnInHD.Enabled = false;
            dgvSach.DataSource = bus_cthdb.getTableSach();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            GUI_HDB qlhdb = new GUI_HDB();
            qlhdb.ShowDialog();
            Mahdban = qlhdb.chosen_mahdb;
            TT = qlhdb.chosen_tongtien;
            if (Mahdban == "" || Mahdban == null)
            {
                return;
            }
            else 
            {
                HDBan hdb = new HDBan();
                hdb = bus_hdb.getOne(Mahdban);
                hdb.TongTien = float.Parse(TT);
                txtMaHD.Text = hdb.MaHDBan.ToString();
                cmbNV.SelectedValue = hdb.MaNhanVien.ToString();
                cmbKH.SelectedValue = hdb.MaKhachHang.ToString();
                dtpNgayBan.Text = hdb.NgayBan.ToString();
                txtTongTien.Text = hdb.TongTien.ToString();
                txtMaHD.Enabled = false;
                cmbNV.Enabled = true;
                cmbKH.Enabled = true;
                dtpNgayBan.Enabled = true;
                txtTongTien.Enabled = false;
                dgvCTHDBan.DataSource = bus_cthdb.getCTHDBan(txtMaHD.Text);
                btnThemHD.Enabled = false;
                btnSuaHD.Enabled = false;
                btnXoaHD.Enabled = true;
                btnLuuHD.Enabled = false;
                btnHuyHD.Enabled = true;
                btnInHD.Enabled = true;
            }
            
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                GUI_HDB qlhdb = new GUI_HDB();
                qlhdb.ShowDialog();
                Mahdban = qlhdb.chosen_mahdb;
                TT = qlhdb.chosen_tongtien;
                if (Mahdban =="" || Mahdban == null)
                {
                    return; 
                } 
                else
                {
                    HDBan hdb = new HDBan();
                    hdb = bus_hdb.getOne(Mahdban);
                    hdb.TongTien = float.Parse(TT);
                    try
                    {
                        txtMaHD.Text = hdb.MaHDBan.ToString();
                        cmbNV.SelectedValue = hdb.MaNhanVien.ToString();
                        cmbKH.SelectedValue = hdb.MaKhachHang.ToString();
                        dtpNgayBan.Text = hdb.NgayBan.ToString();
                        txtTongTien.Text = hdb.TongTien.ToString();
                        txtMaHD.Enabled = false;
                        cmbNV.Enabled = true;
                        cmbKH.Enabled = true;
                        dtpNgayBan.Enabled = true;
                        txtTongTien.Enabled = false;
                        dgvCTHDBan.DataSource = bus_cthdb.getCTHDBan(txtMaHD.Text);
                        btnThemHD.Enabled = false;
                        btnSuaHD.Enabled = false;
                        btnXoaHD.Enabled = true;
                        btnLuuHD.Enabled = false;
                        btnHuyHD.Enabled = true;
                        btnInHD.Enabled = true;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string mahd = txtMaHD.Text;
                    if (bus_hdb.delHDBan(mahd) == true)
                    {
                        txtMaHD.Clear();
                        cmbNV.SelectedIndex = 0;
                        cmbKH.SelectedIndex = 0;
                        dtpNgayBan.Refresh();
                        btnThemHD.Enabled = true;
                        btnSuaHD.Enabled = true;
                        btnLuuHD.Enabled = false;
                        btnXoaHD.Enabled = false;
                        btnHuyHD.Enabled = true;
                    }
                }
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            dgvSach.DataSource = bus_cthdb.getTableSach();
            dgvSach.ClearSelection();
            dgvCTHDBan.DataSource = bus_cthdb.getCTHDBan("");
            dgvSach.ClearSelection();
            cmbKH.SelectedIndex = 0;
            cmbKH.Enabled = false;
            cmbNV.SelectedIndex = 0;
            cmbNV.Enabled = false;
            txtMaHD.Clear();
            txtMaHD.Enabled = false;
            dtpNgayBan.Refresh();
            dtpNgayBan.Enabled = false;
            txtTongTien.Clear();
            btnSuaHD.Enabled = true;
            btnXoa.Enabled = false;
            btnThemHD.Enabled = true;
            btnLuuHD.Enabled = false;
            btnXoaHD.Enabled = true;
        }

        private void linkSua_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GUI_Sach sach = new GUI_Sach();
            sach.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mahdb = txtMaHD.Text;
                string masach = txtCTMaSach.Text;
                string tensach = txtCTTenSach.Text;
                int sl = int.Parse(txtCTSL.Text);
                float dongia = float.Parse(txtCTDonGia.Text);
                float tt = sl * dongia;
                CTHDBan ct = new CTHDBan(mahdb, masach, sl, dongia, tt);
                if (bus_cthdb.updCTHDBan(ct) == true)
                {
                    TongTien = TongTien - slcu * dongia + tt;
                    txtTongTien.Text = TongTien.ToString();
                    dgvCTHDBan.DataSource = bus_cthdb.getCTHDBan(mahdb);
                    txtCTMaSach.Clear();
                    txtCTTenSach.Clear();
                    txtCTSL.Clear();
                    txtCTDonGia.Clear();
                    txtCTThanhTien.Clear();
                    dgvCTHDBan.ClearSelection();
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    txtCTSL.Enabled = false;
                    btnLuuHD.Enabled = true;
                    btnHuyHD.Enabled = false;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string mahdb = txtMaHD.Text;
                string masach = txtCTMaSach.Text;
                float thanhtien = float.Parse(txtCTThanhTien.Text);
                if (bus_cthdb.delCTHDBan(mahdb, masach) == true)
                {
                    TongTien = TongTien - thanhtien;
                    dgvCTHDBan.DataSource = bus_cthdb.getCTHDBan(mahdb);
                    txtCTMaSach.Clear();
                    txtCTTenSach.Clear();
                    txtCTSL.Clear();
                    txtCTDonGia.Clear();
                    txtCTThanhTien.Clear();
                    dgvCTHDBan.ClearSelection();
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    txtCTSL.Enabled = false;
                    btnLuuHD.Enabled = true;
                    btnHuyHD.Enabled = false;
                }
            }
        }

        private void linkThem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GUI_Sach sach = new GUI_Sach();
            sach.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSach.Text.Trim()))
            {
                return;
            }
            else
            {
                string mahdb = txtMaHD.Text;
                string masach = txtMaSach.Text;
                string tensach = txtTenSach.Text;
                float dongia = float.Parse(txtDonGia.Text);
                float thanhtien = 1 * dongia;
                CTHDBan ct = new CTHDBan(mahdb, masach, 1, dongia, thanhtien);
                if (bus_hdb.kiemtramatrung(masach) == 1)
                {
                    MessageBox.Show("Đã có sách trong hóa đơn");
                }
                else
                {
                    if (bus_cthdb.addCTHDBan(ct) == true)
                    {
                        TongTien = TongTien + thanhtien;
                        txtTongTien.Text = TongTien.ToString();
                        dgvSach.DataSource = bus_cthdb.getTableSach();
                        dgvCTHDBan.DataSource = bus_cthdb.getCTHDBan(mahdb);
                        txtMaSach.Clear();
                        txtTenSach.Clear();
                        txtSL.Clear();
                        txtDonGia.Clear();
                        dgvSach.ClearSelection();
                        btnThem.Enabled = false;
                        btnThemHD.Enabled = false;
                        btnLuuHD.Enabled = true;
                        btnHuyHD.Enabled = false;
                    }
                }
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Trim()=="")
            {
                GUI_HDB qlhdb = new GUI_HDB();
                qlhdb.ShowDialog();
                Mahdban = qlhdb.chosen_mahdb;
                TT = qlhdb.chosen_tongtien;
                GUI_InHD inHD = new GUI_InHD("HDB", Mahdban);
                inHD.Show();
            }
            else
            {
                GUI_InHD inHD = new GUI_InHD("HDB", txtMaHD.Text);
                inHD.Show();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void txtCTSL_TextChanged(object sender, EventArgs e)
        {
            float num;
            if (txtCTSL.Text.Trim().Length > 0 && !char.IsDigit(txtCTSL.Text, txtCTSL.Text.Length - 1))
            {
                err.SetError(txtCTSL, "Nhập số nguyên !");
                txtCTSL.Undo();
            }
            else if (float.TryParse(txtCTSL.Text, out num))
            {
                if (num <= 0)
                {
                    // Số nhập vào không hợp lệ, thông báo lỗi
                    MessageBox.Show("Vui lòng nhập số dương lớn hơn 0");
                    txtCTSL.Clear(); // Xóa textbox
                }
            }
            else
            {
                slcu = float.Parse(txtCTSL.Text);
                float sl = float.Parse(txtCTSL.Text);
                float dongia = float.Parse(txtCTDonGia.Text);
                float thanhtien;
                err.Clear();
                if (txtSL.Text.Length > 0)
                {
                    sl = int.Parse(txtSL.Text);
                    if (sl < 0)
                    {
                        MessageBox.Show(txtSL, "Không được nhập số âm");
                        txtCTSL.Text = dgvCTHDBan[1, hang].Value.ToString();
                        txtCTSL.Focus();
                    }
                }
                else
                    sl = 1;
                thanhtien = (sl * dongia);
                txtCTThanhTien.Text = thanhtien.ToString();
            }
        }

        private void dgvCTHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            try
            {
                txtCTMaSach.Text = dgvCTHDBan[0, hang].Value.ToString();
                txtCTTenSach.Text = bus_cthdb.getTenSach(txtCTMaSach.Text.Trim());
                txtCTSL.Text = dgvCTHDBan[1, hang].Value.ToString();
                txtCTDonGia.Text = dgvCTHDBan[2, hang].Value.ToString();
                txtCTThanhTien.Text = dgvCTHDBan[3, hang].Value.ToString();
                slcu = float.Parse(txtCTSL.Text);
                txtCTSL.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch
            {
                txtCTSL.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                return;
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            try
            {
                txtMaSach.Text = dgvSach[0, hang].Value.ToString();
                txtTenSach.Text = dgvSach[1, hang].Value.ToString();
                txtSL.Text = dgvSach[2, hang].Value.ToString();
                txtDonGia.Text = dgvSach[3, hang].Value.ToString();
                btnThem.Enabled = true;
            }
            catch
            {
                btnThem.Enabled = false;
                return;
            }
        }

        private void txtMaHD_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text.Trim()))
            {
                err.SetError(txtMaHD, "Mã hóa đơn không được để trống");
            }
            else
            {
                e.Cancel = false;
                err.SetError(txtMaHD, "");
            }
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            GUI_KhachHang kh = new GUI_KhachHang();
            kh.ShowDialog();
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text.Trim()))
            {
                return;
            }
            else
            {
                string mahdb = txtMaHD.Text;
                string manv = cmbNV.SelectedValue.ToString();
                string makh = cmbKH.SelectedValue.ToString();
                string date = string.Format("{0}/{1}/{2}", dtpNgayBan.Value.Year, dtpNgayBan.Value.Month, dtpNgayBan.Value.Day);
                float tt = float.Parse(txtTongTien.Text);
                HDBan hd = new HDBan(mahdb, manv, makh, date, tt);
                if (bus_hdb.updHDBan(hd) == true)
                {
                    MessageBox.Show("Lưu thành công");
                    btnSuaHD.Enabled = false;
                    btnThemHD.Enabled = true;
                    btnXoaHD.Enabled = true;
                    btnHuyHD.Enabled = true;
                    btnLuuHD.Enabled = false;
                }
            }
        }

        private void dtpNgayBan_ValueChanged(object sender, EventArgs e)
        {
            if (btnSuaHD.Enabled == false)
            {
                btnLuuHD.Enabled = true;
            }
        }

        private void cmbKH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (btnSuaHD.Enabled == false)
            {
                btnLuuHD.Enabled = true;
            }
        }

        private void cmbNV_SelectedValueChanged(object sender, EventArgs e)
        {
            if (btnSuaHD.Enabled == false)
            {
                btnLuuHD.Enabled = true;
            }
        }
    }
}
