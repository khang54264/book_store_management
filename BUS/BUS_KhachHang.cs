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
    public class BUS_KhachHang
    {
        DAL_KhachHang dal_khachhang = new DAL_KhachHang();
        public int kiemtramatrung(string ma)
        {
            return dal_khachhang.kiemtramatrung(ma);
        }
        public DataTable getKhachHang()
        {
            return dal_khachhang.getKhachHang();
        }
        public bool addKhachHang(KhachHang s)
        {
            return dal_khachhang.addKhachHang(s);
        }
        public bool updKhachHang(KhachHang s, string macu)
        {
            return dal_khachhang.updKhachHang(s, macu);
        }
        public bool delKhachHang(string ma)
        {
            return dal_khachhang.delKhachHang(ma);
        }
    }
}
