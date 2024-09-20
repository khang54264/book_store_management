using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HDBan
    {
        public string MaHDBan { get; set; }
        public string MaNhanVien { get; set; }
        public string MaKhachHang { get; set; }
        public string NgayBan { get; set; }
        public float TongTien { get; set; }
        public HDBan()
        {

        }
        public HDBan(string mahdb, string manv, string makh, string ngay, float tien)
        {
            this.MaHDBan = mahdb;
            this.MaNhanVien = manv;
            this.MaKhachHang = makh;
            this.NgayBan = ngay;
            this.TongTien = tien;
        }
    }
}
