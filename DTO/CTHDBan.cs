using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHDBan
    {
        public string MaHDBan { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
        public CTHDBan()
        {

        }
        public CTHDBan(string mahd, string masach, int sl, float gia, float tt)
        {
            this.MaHDBan = mahd;
            this.MaSach = masach;
            this.SoLuong = sl;
            this.DonGia = gia;
            this.ThanhTien = tt;
        }
    }
}
