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
    public partial class GUI_HoaDonNhap : Form
    {
        BUS_HDNhap bus_hdn = new BUS_HDNhap();
        BUS_CTHDNhap bus_cthdn = new BUS_CTHDNhap();
        BUS_Sach bus_sach = new BUS_Sach();
        BUS_NXB bus_nxb = new BUS_NXB();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        private string mahdnhap;
        private string tt;
        float TongTien;
        float slcu;
        int hang;

        public string Mahdnhap { get => mahdnhap; set => mahdnhap = value; }
        public string TT { get => tt; set => tt = value; }

        public GUI_HoaDonNhap()
        {
            InitializeComponent();
        }
        private void GUI_HoaDonNhap_Load(object sender, EventArgs e)
        {
            dgvSach.DataSource = bus_cthdn.getTableSach();
            dgvSach.Columns[0].HeaderText = "Mã sách";
            dgvSach.Columns[1].HeaderText = "Tên sách";
            dgvSach.Columns[2].HeaderText = "Số lượng";
            dgvSach.Columns[3].HeaderText = "Đơn giá";
            dgvSach.ClearSelection();
            dgvCTHDNhap.DataSource = bus_cthdn.getCTHDNhap("");
            dgvCTHDNhap.Columns[0].HeaderText = "Mã sách";
            dgvCTHDNhap.Columns[1].HeaderText = "Số lượng";
            dgvCTHDNhap.Columns[2].HeaderText = "Đơn giá";
            dgvCTHDNhap.Columns[3].HeaderText = "Thành tiền";
            dgvSach.ClearSelection();
            cmbNXB.DataSource = bus_nxb.getNXB();
            cmbNXB.ValueMember = "MaNXB";
            cmbNXB.DisplayMember = "TenNXB";
            cmbNXB.SelectedIndex = 0;
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
            else if (cmbNXB.SelectedIndex == 0)
            {
                err.SetError(cmbNXB, "Hãy chọn nhà xuất bản");
            }
            else if (cmbNV.SelectedIndex == 0)
            {
                err.SetError(cmbNV, "Hãy chọn nhân viên");
            }
            else
            {
                string mahd = txtMaHD.Text;
                string date = string.Format("{0}/{1}/{2}", dtpNgayNhap.Value.Year, dtpNgayNhap.Value.Month, dtpNgayNhap.Value.Day);
                string nxb = cmbNXB.SelectedValue.ToString().Trim();
                string nv = cmbNV.SelectedValue.ToString().Trim();
                float tt = 0;
                HDNhap hdnhap = new HDNhap(mahd, nv, nxb, date, tt);
                if (bus_hdn.kiemtramatrung(mahd) == 1)
                {
                    MessageBox.Show("Mã hóa đơn bị trùng");
                    txtMaHD.Focus();
                }
                else
                {
                    if (bus_hdn.addHDNhap(hdnhap) == true)
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvSach.DataSource = bus_cthdn.getTableSach();
                        dgvCTHDNhap.DataSource = bus_cthdn.getCTHDNhap(mahd);
                        btnTaoHD.Enabled = false;
                        txtMaHD.Enabled = false;
                        dtpNgayNhap.Enabled = true;
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
            dtpNgayNhap.Enabled = true;
            dtpNgayNhap.Refresh();
            cmbNXB.Enabled = true;
            cmbNXB.SelectedIndex = 0;
            cmbNV.Enabled = true;
            cmbNV.SelectedIndex = 0;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnTaoHD.Enabled = true;
            btnSuaHD.Enabled = false;
            btnInHD.Enabled = false;
            dgvSach.DataSource = bus_cthdn.getTableSach();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            GUI_HDN qlhdn = new GUI_HDN();
            qlhdn.ShowDialog();
            Mahdnhap = qlhdn.chosen_mahdn;
            TT = qlhdn.chosen_tongtien;
            if (Mahdnhap == "" || Mahdnhap == null)
            {
                return;
            }
            else
            {
                HDNhap hdn = new HDNhap();
                hdn = bus_hdn.getOne(Mahdnhap);
                hdn.TongTien = float.Parse(TT);
                try
                {
                    txtMaHD.Text = hdn.MaHDNhap.ToString();
                    cmbNV.SelectedValue = hdn.MaNhanVien.ToString();
                    cmbNXB.SelectedValue = hdn.MaNXB.ToString();
                    dtpNgayNhap.Text = hdn.NgayNhap.ToString();
                    txtTongTien.Text = hdn.TongTien.ToString();
                    txtMaHD.Enabled = false;
                    cmbNV.Enabled = true;
                    cmbNXB.Enabled = true;
                    dtpNgayNhap.Enabled = true;
                    txtTongTien.Enabled = false;
                    dgvCTHDNhap.DataSource = bus_cthdn.getCTHDNhap(txtMaHD.Text);
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

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text=="")
            {
                GUI_HDN qlhdn = new GUI_HDN();
                qlhdn.ShowDialog();
                Mahdnhap = qlhdn.chosen_mahdn;
                TT = qlhdn.chosen_tongtien;
                if (Mahdnhap == "" || Mahdnhap == null)
                {
                    return;
                }
                else
                {
                    HDNhap hdn = new HDNhap();
                    hdn = bus_hdn.getOne(Mahdnhap);
                    hdn.TongTien = float.Parse(TT);
                    txtMaHD.Text = hdn.MaHDNhap.ToString();
                    cmbNV.SelectedValue = hdn.MaNhanVien.ToString();
                    cmbNXB.SelectedValue = hdn.MaNXB.ToString();
                    dtpNgayNhap.Text = hdn.NgayNhap.ToString();
                    txtTongTien.Text = hdn.TongTien.ToString();
                    txtMaHD.Enabled = false;
                    cmbNV.Enabled = true;
                    cmbNXB.Enabled = true;
                    dtpNgayNhap.Enabled = true;
                    txtTongTien.Enabled = false;
                    dgvCTHDNhap.DataSource = bus_cthdn.getCTHDNhap(txtMaHD.Text);
                    btnThemHD.Enabled = false;
                    btnSuaHD.Enabled = false;
                    btnXoaHD.Enabled = true;
                    btnLuuHD.Enabled = false;
                    btnHuyHD.Enabled = true;
                    btnInHD.Enabled = true;
                }
                    
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string mahd = txtMaHD.Text;
                    if (bus_hdn.delHDNhap(mahd) == true)
                    {
                        txtMaHD.Clear();
                        cmbNV.SelectedIndex = 0;
                        cmbNXB.SelectedIndex = 0;
                        dtpNgayNhap.Refresh();
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
            dgvSach.DataSource = bus_cthdn.getTableSach();
            dgvSach.ClearSelection();
            dgvCTHDNhap.DataSource = bus_cthdn.getCTHDNhap("");
            dgvSach.ClearSelection();
            cmbNXB.SelectedIndex = 0;
            cmbNXB.Enabled = false;
            cmbNV.SelectedIndex = 0;
            cmbNV.Enabled = false;
            txtMaHD.Clear();
            txtMaHD.Enabled = false;
            dtpNgayNhap.Refresh();
            dtpNgayNhap.Enabled = false;
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
                string mahdn = txtMaHD.Text; 
                string masach = txtCTMaSach.Text;
                string tensach = txtCTTenSach.Text;
                int sl = int.Parse(txtCTSL.Text);
                float dongia = float.Parse(txtCTDonGia.Text);
                float tt = sl*dongia;
                CTHDNhap ct = new CTHDNhap(mahdn, masach, sl, dongia, tt);
                if (bus_cthdn.updCTHDNhap(ct) == true)
                {
                    TongTien = TongTien - slcu * dongia + tt;
                    txtTongTien.Text = TongTien.ToString();
                    dgvCTHDNhap.DataSource = bus_cthdn.getCTHDNhap(mahdn);
                    txtCTMaSach.Clear();
                    txtCTTenSach.Clear();
                    txtCTSL.Clear();
                    txtCTDonGia.Clear();
                    txtCTThanhTien.Clear();
                    dgvCTHDNhap.ClearSelection();
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
                string mahdn = txtMaHD.Text;
                string masach = txtCTMaSach.Text;
                float thanhtien = float.Parse(txtCTThanhTien.Text);
                if (bus_cthdn.delCTHDNhap(mahdn, masach) == true)
                {
                    TongTien = TongTien - thanhtien;
                    dgvCTHDNhap.DataSource = bus_cthdn.getCTHDNhap(mahdn);
                    txtCTMaSach.Clear();
                    txtCTTenSach.Clear();
                    txtCTSL.Clear();
                    txtCTDonGia.Clear();
                    txtCTThanhTien.Clear();
                    dgvCTHDNhap.ClearSelection();
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
                string mahdn = txtMaHD.Text;
                string masach = txtMaSach.Text;
                string tensach = txtTenSach.Text;
                float dongia = float.Parse(txtDonGia.Text);
                float thanhtien = 1 * dongia;
                CTHDNhap ct = new CTHDNhap(mahdn, masach, 1, dongia, thanhtien);
                if (bus_hdn.kiemtramatrung(masach) == 1)
                {
                    MessageBox.Show("Đã có sách trong hóa đơn");
                }
                else
                {
                    if (bus_cthdn.addCTHDNhap(ct) == true)
                    {
                        TongTien = TongTien + thanhtien;
                        txtTongTien.Text = TongTien.ToString();
                        dgvSach.DataSource = bus_cthdn.getTableSach();
                        dgvCTHDNhap.DataSource = bus_cthdn.getCTHDNhap(mahdn);
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
                GUI_HDN qlhdn = new GUI_HDN();
                qlhdn.ShowDialog();
                Mahdnhap = qlhdn.chosen_mahdn;
                TT = qlhdn.chosen_tongtien;
                GUI_InHD inHD = new GUI_InHD("HDN", Mahdnhap);
                inHD.Show();
            }
            else
            {
                GUI_InHD inHD = new GUI_InHD("HDN", txtMaHD.Text);
                inHD.Show();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void txtCTSoLuong_TextChanged(object sender, EventArgs e)
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
                        txtCTSL.Text= dgvCTHDNhap[1, hang].Value.ToString();
                        txtCTSL.Focus();
                    }  
                }      
                else
                    sl = 1;
                thanhtien = (sl * dongia);
                txtCTThanhTien.Text = thanhtien.ToString();
            }
            /*if (txtCTSL.Text.Trim().Length > 0 && int.Parse(txtCTSL.Text) > 100)
            {
                err.SetError(txtCTSL, "Số lượng quá nhiều");
                txtCTSL.Clear();
            }
            else
                err.Clear();*/
        }

        private void dgvCTHDNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            try
            {
                txtCTMaSach.Text = dgvCTHDNhap[0, hang].Value.ToString();
                txtCTTenSach.Text = bus_cthdn.getTenSach(txtCTMaSach.Text.Trim());
                txtCTSL.Text = dgvCTHDNhap[1, hang].Value.ToString();
                txtCTDonGia.Text = dgvCTHDNhap[2, hang].Value.ToString();
                txtCTThanhTien.Text = dgvCTHDNhap[3, hang].Value.ToString();
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

        private void btnNXB_Click(object sender, EventArgs e)
        {
            GUI_NXB nxb = new GUI_NXB();
            nxb.ShowDialog();
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text.Trim()))
            {
                return;
            }
            else
            {
                string mahdn = txtMaHD.Text;
                string manv = cmbNV.SelectedValue.ToString();
                string manxb = cmbNXB.SelectedValue.ToString();
                string date = string.Format("{0}/{1}/{2}", dtpNgayNhap.Value.Year, dtpNgayNhap.Value.Month, dtpNgayNhap.Value.Day);
                float tt = float.Parse(txtTongTien.Text);
                HDNhap hd = new HDNhap(mahdn, manv, manxb, date, tt);
                if (bus_hdn.updHDNhap(hd) == true)
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

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            if (btnSuaHD.Enabled == false)
            {
                btnLuuHD.Enabled = true;
            }
        }

        private void cmbNXB_SelectedValueChanged(object sender, EventArgs e)
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
