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
    public partial class GUI_TacGia : Form
    {
        BUS_TacGia bus_tacgia = new BUS_TacGia();
        int hang;
        public GUI_TacGia()
        {
            InitializeComponent();
        }

        private void GUI_TacGia_Load(object sender, EventArgs e)
        {
            dgvTacGia.DataSource = bus_tacgia.getTacGia();
            dgvTacGia.Columns[0].HeaderText = "Mã tác giả";
            dgvTacGia.Columns[1].HeaderText = "Tên tác giả";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaTG.Text;
            string ten = txtTenTG.Text;
            TacGia s = new TacGia(ma, ten);
            if (bus_tacgia.kiemtramatrung(ma) == 1)
            {
                MessageBox.Show("Mã tác giả bị trùng");
            }
            else
            {
                if (bus_tacgia.addTacGia(s) == true)
                {
                    MessageBox.Show("Thêm thành công");
                    dgvTacGia.DataSource = bus_tacgia.getTacGia();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaTG.Text;
            string ten = txtTenTG.Text;
            string macu = dgvTacGia[0, hang].Value.ToString();
            TacGia s = new TacGia(ma, ten);
            if (macu != ma)
            {
                if (bus_tacgia.kiemtramatrung(ma) == 1)
                {
                    MessageBox.Show("Mã tác giả bị trùng");
                }
            }
            else
            {
                if (bus_tacgia.updTacGia(s, macu) == true)
                {
                    MessageBox.Show("Sửa thành công");
                    dgvTacGia.DataSource = bus_tacgia.getTacGia();
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = bus_tacgia.getTacGia().DefaultView;
            string ten = txtTimTenTG.Text;
            string sql = "TenTacGia like '%" + ten + "%'";
            dv.RowFilter = sql;
            dgvTacGia.DataSource = dv;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvTacGia.DataSource = bus_tacgia.getTacGia();
            txtMaTG.Clear();
            txtTenTG.Clear();
            txtTimTenTG.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaTG.Text;
            if (bus_tacgia.delTacGia(ma) == true)
            {
                MessageBox.Show("Xóa thành công");
                dgvTacGia.DataSource = bus_tacgia.getTacGia();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = e.RowIndex;
            txtMaTG.Text = dgvTacGia[0, hang].Value.ToString();
            txtTenTG.Text = dgvTacGia[1, hang].Value.ToString();
        }
    }
}
