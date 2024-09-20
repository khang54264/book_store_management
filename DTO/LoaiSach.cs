using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSach
    {
        public string MaLoaiSach { get; set; }
        public string TenLoaiSach { get; set; }
        public LoaiSach()
        {

        }
        public LoaiSach(string ma, string ten)
        {
            this.MaLoaiSach = ma;
            this.TenLoaiSach = ten;
        }
    }
}
