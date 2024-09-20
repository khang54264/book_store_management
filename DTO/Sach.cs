using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaLoaiSach { get; set; }
        public string MaTacGia { get; set; }
        public string MaNXB { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public Sach()
        {

        }
        public Sach(string ma, string ten, string loai, string tacgia, string nxb, int sl, float gia)
        {
            this.MaSach = ma;
            this.TenSach = ten;
            this.MaLoaiSach = loai;
            this.MaTacGia = tacgia;
            this.MaNXB = nxb;
            this.SoLuong = sl;
            this.DonGia = gia;
        }
    }
}
