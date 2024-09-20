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
    public class BUS_LoaiSach
    {
        DAL_LoaiSach dal_loaisach = new DAL_LoaiSach();
        public int kiemtramatrung(string ma)
        {
            return dal_loaisach.kiemtramatrung(ma);
        }
        public DataTable getLoaiSach()
        {
            return dal_loaisach.getLoaiSach();
        }
        public bool addLoaiSach(LoaiSach s)
        {
            return dal_loaisach.addLoaiSach(s);
        }
        public bool updLoaiSach(LoaiSach s, string macu)
        {
            return dal_loaisach.updLoaiSach(s, macu);
        }
        public bool delLoaiSach(string ma)
        {
            return dal_loaisach.delLoaiSach(ma);
        }
    }
}
