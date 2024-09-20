using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NXB
    {
        public string MaNXB { get; set; }
        public string TenNXB { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public NXB()
        {

        }
        public NXB(string ma, string ten, string dc, string sdt, string mail, string web)
        {
            this.MaNXB = ma;
            this.TenNXB = ten;
            this.DiaChi = dc;
            this.SoDienThoai = sdt;
            this.Email = mail;
            this.Website = web;
        }
    }
}
