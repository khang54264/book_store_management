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
    public class BUS_CTHDNhap
    {
        DAL_CTHDNhap dal_cthdnhap = new DAL_CTHDNhap();
        public int kiemtramatrung(string ma)
        {
            return dal_cthdnhap.kiemtramatrung(ma);
        }
        public string getTenSach(string ma)
        {
            return dal_cthdnhap.getTenSach(ma);
        }
        public DataTable getTableSach()
        {
            return dal_cthdnhap.getTableSach();
        }
        public DataTable getCTHDNhap(string ma)
        {
            return dal_cthdnhap.getCTHDNhap(ma);
        }
        public bool addCTHDNhap(CTHDNhap s)
        {
            return dal_cthdnhap.addCTHDNhap(s);
        }
        public bool updCTHDNhap(CTHDNhap s)
        {
            return dal_cthdnhap.updCTHDNhap(s);
        }
        public bool delCTHDNhap(string mahd, string masach)
        {
            return dal_cthdnhap.delCTHDNhap(mahd, masach);
        }
    }
}
