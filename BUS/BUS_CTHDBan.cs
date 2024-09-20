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
    public class BUS_CTHDBan
    {
        DAL_CTHDBan dal_cthdban = new DAL_CTHDBan();
        public int kiemtramatrung(string ma)
        {
            return dal_cthdban.kiemtramatrung(ma);
        }
        public string getTenSach(string ma)
        {
            return dal_cthdban.getTenSach(ma);
        }
        public DataTable getTableSach()
        {
            return dal_cthdban.getTableSach();
        }
        public DataTable getCTHDBan(string ma)
        {
            return dal_cthdban.getCTHDBan(ma);
        }
        public bool addCTHDBan(CTHDBan s)
        {
            return dal_cthdban.addCTHDBan(s);
        }
        public bool updCTHDBan(CTHDBan s)
        {
            return dal_cthdban.updCTHDBan(s);
        }
        public bool delCTHDBan(string mahd, string masach)
        {
            return dal_cthdban.delCTHDBan(mahd, masach);
        }
    }
}
