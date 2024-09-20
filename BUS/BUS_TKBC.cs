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
    public class BUS_TKBC
    {
        DAL_TKBC dal_tkbc = new DAL_TKBC();
        public DataTable getDTThang(DateTime ngay)
        {
            return dal_tkbc.getDTThang(ngay);
        }
        public DataTable getDTNam(DateTime ngay)
        {
            return dal_tkbc.getDTNam(ngay);
        }
        public DataTable getSThang(DateTime ngay)
        {
            return dal_tkbc.getSThang(ngay);
        }
        public DataTable getSNam(DateTime ngay)
        {
            return dal_tkbc.getSNam(ngay);
        }
        public int TongDoanhThu()
        {
            return dal_tkbc.TongDoanhThu();
        }
    }
}
