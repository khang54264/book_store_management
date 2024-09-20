using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_Sach:DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        void thucthisql(string sql)
        {
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int kiemtramatrung(string ma)
        {
            con.Open();
            string sql = "Select count(*) from tblSach where MaSach = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public DataTable getSach()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from tblSach", con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getSachHD()
        {
            con.Open();
            da = new SqlDataAdapter("Select MaSach, TenSach, SoLuong, DonGia from tblSach", con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool addSach(Sach s)
        {
            //string ngay = string.Format("{0}/{1}/{2}",s.date.year,s.date.month,s.date.day);
            string sql = "Insert into tblSach values('"+s.MaSach+"',N'"+s.TenSach+"','"+s.MaLoaiSach+"','"+s.MaTacGia+"','"+s.MaNXB+"','"+s.SoLuong+"','"+s.DonGia+"')";
            thucthisql(sql);
            return true;
        }
        public bool updSach(Sach s, string macu)
        {
            string sql = "Update tblSach set MaSach='" + s.MaSach + "',TenSach=N'" + s.TenSach + "',MaLoaiSach='" + s.MaLoaiSach + "',MaTacGia='" + s.MaTacGia + "',MaNXB='" + s.MaNXB + "',SoLuong='" + s.SoLuong + "',DonGia='" + s.DonGia + "' where MaSach='"+macu+"'";
            thucthisql(sql);
            return true;
        }
        public bool delSach(string ma)
        {
            string sql = "Delete from tblSach where MaSach='" + ma + "'";
            thucthisql(sql);
            return true;
        }
    }
}
