using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_TacGia
    {
        DAL_TacGia dal_tacgia = new DAL_TacGia();
        public int kiemtramatrung(string ma)
        {
            return dal_tacgia.kiemtramatrung(ma);
        }
        public DataTable getTacGia()
        {
            return dal_tacgia.getTacGia();
        }
        public bool addTacGia(TacGia s)
        {
            return dal_tacgia.addTacGia(s);
        }
        public bool updTacGia(TacGia s, string macu)
        {
            return dal_tacgia.updTacGia(s, macu);
        }
        public bool delTacGia(string ma)
        {
            return dal_tacgia.delTacGia(ma);
        }
    }
}
