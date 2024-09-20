using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TacGia
    {
        public string MaTacGia { get; set; }
        public string TenTacGia { get; set; }
        public TacGia()
        {

        }
        public TacGia(string ma, string ten)
        {
            this.MaTacGia = ma;
            this.TenTacGia = ten;
        }
    }
}
