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
    public partial class GUI_ChangePass : Form
    {
        BUS_Users bus_users = new BUS_Users();
        public string user, pass;
        public GUI_ChangePass(string tk, string mk) : this()
        {
            user = tk;
            pass = mk;
        }
        public GUI_ChangePass()
        {
            InitializeComponent();
        }
        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked)
                txtCurPass.PasswordChar = (char)0;
            else
                txtCurPass.PasswordChar = '*';
            if (chkPass.Checked)
                txtNewPass.PasswordChar = (char)0;
            else
                txtNewPass.PasswordChar = '*';
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string tdn = txtUser.Text;
            string mkc = txtCurPass.Text;
            string mkm = txtNewPass.Text;
            if (bus_users.kiemtramk(tdn, mkc) == 0)
            {
                MessageBox.Show("Mật khẩu sai vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                bus_users.changePass(tdn, mkc, mkm);
                MessageBox.Show("Đổi mật khẩu thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void GUI_Users_Load(object sender, EventArgs e)
        {
            txtUser.Text = this.user;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
