using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public KhachHang()
        {

        }
        public KhachHang(string ma, string ten, string sdt, string dc)
        {
            this.MaKhachHang = ma;
            this.TenKhachHang = ten;
            this.SoDienThoai = sdt;
            this.DiaChi = dc;
        }
    }
}
