using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_Users
    {
        DAL_Users dal_users = new DAL_Users();
        public int kiemtramatrung(string ma)
        {
            return dal_users.kiemtramatrung(ma);
        }
        public int kiemtramk(string tdn, string mk)
        {
            return dal_users.kiemtramk(tdn, mk);
        }
        public DataTable getUsers()
        {
            return dal_users.getUsers();
        }
        public bool addUsers(Users s)
        {
            return dal_users.addUsers(s);
        }
        public bool updUsers(Users s)
        {
            return dal_users.updUsers(s);
        }
        public bool delUsers(string ma)
        {
            return dal_users.delUsers(ma);
        }
        public string chkLogin(Users s)
        {
            if (s.TenDangNhap == "")
                return "Required TenDangNhap";
            if (s.MatKhau == "")
                return "Required MatKhau";
            return dal_users.chkLogin(s);
        }
        public bool changePass(string tdn, string mkc, string mkm)
        {
            return dal_users.changePass(tdn, mkc, mkm);
        }
    }
}
