using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Users
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int Quyen { get; set; }
        public string MaNhanVien { get; set; }
        public Users()
        {

        }
        public Users(string user, string pass, int per, string ma)
        {
            this.TenDangNhap = user;
            this.MatKhau = pass;
            this.Quyen = per;
            this.MaNhanVien = ma;
        }
    }
}
