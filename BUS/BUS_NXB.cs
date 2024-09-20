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
    public class BUS_NXB
    {
        DAL_NXB dal_nxb = new DAL_NXB();
        public int kiemtramatrung(string ma)
        {
            return dal_nxb.kiemtramatrung(ma);
        }
        public DataTable getNXB()
        {
            return dal_nxb.getNXB();
        }
        public bool addNXB(NXB s)
        {
            return dal_nxb.addNXB(s);
        }
        public bool updNXB(NXB s, string macu)
        {
            return dal_nxb.updNXB(s, macu);
        }
        public bool delNXB(string ma)
        {
            return dal_nxb.delNXB(ma);
        }
    }
}
