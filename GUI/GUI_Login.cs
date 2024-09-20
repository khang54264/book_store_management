using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class GUI_Login : Form
    {
        BUS_Users bus_users = new BUS_Users();
        public GUI_Login()
        {
            InitializeComponent();
        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked)
                txtPass.PasswordChar = (char)0;
            else
                txtPass.PasswordChar = '*';
        }

        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                /*e.Cancel = true;*/
                errLogin.SetError(txtUser, "Bạn cần nhập vào Username!");
                /*txtUser.Focus();*/
            }
            else
            {
                e.Cancel = false;
                errLogin.SetError(txtUser, "");
            }
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                /*e.Cancel = true;*/
                errLogin.SetError(txtPass, "Bạn cần nhập vào Password!");
                /*txtPass.Focus();*/
            }
            else
            {
                e.Cancel = false;
                errLogin.SetError(txtPass, "");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            Users s = new Users(); 
            s.TenDangNhap = username;
            s.MatKhau = password;
            string login = bus_users.chkLogin(s);
            switch (login)
            {
                case "Required TenDangNhap":
                    MessageBox.Show("Tên đăng nhập không được để trống");
                    return;
                case "Required MatKhau":
                    MessageBox.Show("Mật khẩu không được để trống");
                    return;
                case "Tài khoản hoặc mật khẩu không chính xác":
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                    return;
                case "0":
                    {
                        MessageBox.Show("Chào mừng quản lý đăng nhập");
                        GUI_Menu menu = new GUI_Menu(username, password, 0);
                        txtUser.Clear();
                        txtPass.Clear();
                        this.Hide();
                        menu.ShowDialog();
                        this.Show();
                        return;
                    }                 
                case "1":
                    {
                        MessageBox.Show("Chào mừng nhân viên đăng nhập");
                        GUI_Menu menu = new GUI_Menu(username, password, 1);
                        txtUser.Clear();
                        txtPass.Clear();
                        this.Hide();
                        menu.ShowDialog();
                        this.Show();
                        return;
                    }             
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }
    }
}
