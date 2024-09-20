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
    public class BUS_HDBan
    {
        DAL_HDBan dal_hdban = new DAL_HDBan();
        public int kiemtramatrung(string ma)
        {
            return dal_hdban.kiemtramatrung(ma);
        }
        public DataTable getHDBan()
        {
            return dal_hdban.getHDBan();
        }
        public HDBan getOne(string ma)
        {
            return dal_hdban.getOne(ma);
        }
        public float getTongTien(string ma)
        {
            return dal_hdban.getTongTien(ma);
        }
        public bool addHDBan(HDBan s)
        {
            return dal_hdban.addHDBan(s);
        }
        public bool updHDBan(HDBan s)
        {
            return dal_hdban.updHDBan(s);
        }
        public bool delHDBan(string ma)
        {
            return dal_hdban.delHDBan(ma);
        }
        public DataTable printHDBan(string ma)
        {
            return dal_hdban.printHDBan(ma);
        }
    }
}
