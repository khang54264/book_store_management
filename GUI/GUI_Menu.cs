using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUI_Menu : Form
    {
        bool Hided;
        public string user, pass;
        private int per ;
        public int Per { get => per; set => per = value; }

        public GUI_Menu(string tk, string mk, int p) : this()
        {
            user = tk;
            pass = mk;
            Per = p;
        }
        public GUI_Menu()
        {
            InitializeComponent();
            Hided = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Hided)
            {
                pnSlide.Width = pnSlide.Width + 100;
                if(pnSlide.Width == 200)
                {
                    timer1.Stop();
                    Hided = false;
                    this.Refresh();
                }
            }
            else
            {
                pnSlide.Width = pnSlide.Width - 100;
                if(pnSlide.Width == 0 )
                {
                    timer1.Stop();
                    Hided = true;
                    this.Refresh();
                }
            }
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void GUI_Menu_Load(object sender, EventArgs e)
        {
            pnSlide.Width = 0;
            if (Per == 0)
            {
                btnNV.Enabled = true;
                btnQLUsers.Enabled = true;
                btnReport.Enabled = true;
            }
            if (Per == 1)
            {
                btnNV.Enabled = false;
                btnQLUsers.Enabled = false;
                btnReport.Enabled = false;
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            GUI_ChangePass cp = new GUI_ChangePass(user, pass);
            cp.ShowDialog();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            GUI_KhachHang kh = new GUI_KhachHang();
            this.Hide();
            kh.ShowDialog();
            this.Show();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            GUI_NhanVien nv = new GUI_NhanVien();
            this.Hide();
            nv.ShowDialog();
            this.Show();
        }

        private void btnHDNhap_Click(object sender, EventArgs e)
        {
            GUI_HoaDonNhap hdnhap = new GUI_HoaDonNhap();
            this.Hide();
            hdnhap.ShowDialog();
            this.Show();
        }

        private void btnHDBan_Click(object sender, EventArgs e)
        {
            GUI_HoaDonBan hdban = new GUI_HoaDonBan();
            this.Hide();
            hdban.ShowDialog();
            this.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            GUI_ThongKe tk = new GUI_ThongKe();
            this.Hide();
            tk.ShowDialog();
            this.Show();
        }

        private void btnQLUsers_Click(object sender, EventArgs e)
        {
            GUI_Users users = new GUI_Users();
            this.Hide();
            users.ShowDialog();
            this.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI_Sach sach = new GUI_Sach();
            this.Hide();
            sach.ShowDialog();
            this.Show();
        }
    }
}
