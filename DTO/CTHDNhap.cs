using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHDNhap
    {
        public string MaHDNhap { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
        public CTHDNhap()
        {

        }
        public CTHDNhap(string macthd, string masach, int sl, float gia, float tt)
        {
            this.MaHDNhap = macthd;
            this.MaSach = masach;
            this.SoLuong = sl;
            this.DonGia = gia;
            this.ThanhTien = tt;
        }
    }
}
