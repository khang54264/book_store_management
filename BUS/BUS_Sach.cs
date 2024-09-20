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
    public class BUS_Sach
    {
        DAL_Sach dal_sach = new DAL_Sach();
        public int kiemtramatrung(string ma)
        {
            return dal_sach.kiemtramatrung(ma);
        }
        public DataTable getSach()
        {
            return dal_sach.getSach();
        }
        public bool addSach(Sach s)
        {
            return dal_sach.addSach(s);
        }
        public bool updSach(Sach s, string macu)
        {
            return dal_sach.updSach(s, macu);
        }
        public bool delSach(string ma)
        {
            return dal_sach.delSach(ma);
        }
    }
}
