using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HDNhap
    {
        public string MaHDNhap { get; set; }
        public string MaNhanVien { get; set; }
        public string MaNXB { get; set; }
        public string NgayNhap { get; set; }
        public float TongTien { get; set; }
        public HDNhap()
        {

        }
        public HDNhap(string mahd, string manv, string manxb, string ngay, float tien)
        {
            this.MaHDNhap = mahd;
            this.MaNhanVien = manv;
            this.MaNXB = manxb;
            this.NgayNhap = ngay;
            this.TongTien = tien;
        }
    }
}
