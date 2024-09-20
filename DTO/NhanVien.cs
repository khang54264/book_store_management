using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public NhanVien()
        {

        }
        public NhanVien(string ma, string ten, string sdt, string ns, string dc)
        {
            this.MaNhanVien = ma;
            this.TenNhanVien = ten;
            this.SoDienThoai = sdt;
            this.NgaySinh = ns;
            this.DiaChi = dc;
        }
    }
}
