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
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_nhanvien = new DAL_NhanVien();
        public int kiemtramatrung(string ma)
        {
            return dal_nhanvien.kiemtramatrung(ma);
        }
        public DataTable getNhanVien()
        {
            return dal_nhanvien.getNhanVien();
        }
        public bool addNhanVien(NhanVien s)
        {
            return dal_nhanvien.addNhanVien(s);
        }
        public bool updNhanVien(NhanVien s, string macu)
        {
            return dal_nhanvien.updNhanVien(s, macu);
        }
        public bool delNhanVien(string ma)
        {
            return dal_nhanvien.delNhanVien(ma);
        }
    }
}
