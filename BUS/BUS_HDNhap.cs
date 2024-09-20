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
    public class BUS_HDNhap
    {
        DAL_HDNhap dal_hdnhap = new DAL_HDNhap();
        public int kiemtramatrung(string ma)
        {
            return dal_hdnhap.kiemtramatrung(ma);
        }
        public DataTable getHDNhap()
        {
            return dal_hdnhap.getHDNhap();
        }
        public HDNhap getOne(string ma)
        {
            return dal_hdnhap.getOne(ma);
        }
        public float getTongTien(string ma)
        {
            return dal_hdnhap.getTongTien(ma);
        }
        public bool addHDNhap(HDNhap s)
        {
            return dal_hdnhap.addHDNhap(s);
        }
        public bool updHDNhap(HDNhap s)
        {
            return dal_hdnhap.updHDNhap(s);
        }
        public bool delHDNhap(string ma)
        {
            return dal_hdnhap.delHDNhap(ma);
        }
        public DataTable printHDNhap(string ma)
        {
            return dal_hdnhap.printHDNhap(ma);
        }
    }
}
