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
    public class DAL_HDNhap:DBConnect
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
            string sql = "Select count(*) from tblHoaDonNhap where MaHDNhap = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public DataTable getHDNhap()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from tblHoaDonNhap", con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow itemrow = dt.NewRow();
            itemrow[1] = "";
            dt.Rows.InsertAt(itemrow, 0);
            con.Close();
            return dt;
        }
        public HDNhap getOne(string ma)
        {
            con.Open();
            HDNhap hoadon = new HDNhap();
            cmd = new SqlCommand("proc_getHDNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@mahd", ma);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hoadon.MaHDNhap = ma;
                    hoadon.MaNhanVien = reader.GetString(1);
                    hoadon.MaNXB = reader.GetString(2);
                    DateTime date = reader.GetDateTime(3);
                    string ngay = string.Format("{0}/{1}/{2}", date.Year, date.Month, date.Day);
                    hoadon.NgayNhap = ngay;
                    reader.Close();
                    con.Close();
                    return hoadon;
                }
                reader.Close();
                con.Close();
            }
            else
            {
                con.Close();
                return hoadon;
            }
            con.Close();
            return hoadon;
        }
        public float getTongTien(string ma)
        {
            con.Open();
            float tt;
            string sql = "Select TongTien from tblHoaDonNhap where MaHDNhap = '" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, con);
            tt = (float)cmd.ExecuteScalar();
            con.Close();
            return tt;
        }
        public bool addHDNhap(HDNhap s)
        {
            string sql = "Insert into tblHoaDonNhap values('" + s.MaHDNhap + "','" + s.MaNhanVien + "','" + s.MaNXB + "','" + s.NgayNhap + "','" + s.TongTien + "')";
            thucthisql(sql);
            return true;
        }
        public bool updHDNhap(HDNhap s)
        {
            string sql = "Update tblHoaDonNhap set MaNhanVien=N'" + s.MaNhanVien + "',MaNXB=N'" + s.MaNXB + "',NgayNhap=N'" + s.NgayNhap + "',TongTien=N'" + s.TongTien + "' where MaHDNhap='" + s.MaHDNhap + "'";
            thucthisql(sql);
            return true;
        }
        public bool delHDNhap(string ma)
        {
            string sql = "Delete from tblHoaDonNhap where MaHDNhap='" + ma + "'";
            thucthisql(sql);
            sql = "Delete from tblCTHoaDonNhap where MaHDNhap='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable printHDNhap(string ma)
        {
            con.Open();
            cmd = new SqlCommand("proc_inHDNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@mahd", ma);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
