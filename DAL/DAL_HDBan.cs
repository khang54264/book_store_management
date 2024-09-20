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
    public class DAL_HDBan:DBConnect
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
            string sql = "Select count(*) from tblHoaDonBan where MaHDBan = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public DataTable getHDBan()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from tblHoaDonBan", con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow itemrow = dt.NewRow();
            itemrow[1] = "";
            dt.Rows.InsertAt(itemrow, 0);
            con.Close();
            return dt;
        }
        public HDBan getOne(string ma)
        {
            con.Open();
            HDBan hoadon = new HDBan();
            cmd = new SqlCommand("proc_getHDBan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@mahd", ma);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    hoadon.MaHDBan = ma;
                    hoadon.MaNhanVien = reader.GetString(1);
                    hoadon.MaKhachHang = reader.GetString(2);
                    DateTime date = reader.GetDateTime(3);
                    string ngay = string.Format("{0}/{1}/{2}", date.Year, date.Month, date.Day);
                    hoadon.NgayBan = ngay;
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
            string sql = "Select TongTien from tblHoaDonBan where MaHDBan = '" + ma.Trim() + "'";
            cmd = new SqlCommand(sql, con);
            tt = (float)cmd.ExecuteScalar();
            con.Close();
            return tt;
        }
        public bool addHDBan(HDBan s)
        {
            string sql = "Insert into tblHoaDonBan values('" + s.MaHDBan + "','" + s.MaNhanVien + "','" + s.MaKhachHang + "','" + s.NgayBan + "','" + s.TongTien + "')";
            thucthisql(sql);
            return true;
        }
        public bool updHDBan(HDBan s)
        {
            string sql = "Update tblHoaDonBan set MaNhanVien=N'" + s.MaNhanVien + "',MaKhachHang=N'" + s.MaKhachHang + "',NgayBan=N'" + s.NgayBan + "',TongTien=N'" + s.TongTien + "' where MaHDBan='" + s.MaHDBan + "'";
            thucthisql(sql);
            return true;
        }
        public bool delHDBan(string ma)
        {
            string sql = "Delete from tblHoaDonBan where MaHDBan='" + ma + "'";
            thucthisql(sql);
            sql = "Delete from tblCTHoaDonBan where MaHDBan='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable printHDBan(string ma)
        {
            con.Open();
            cmd = new SqlCommand("proc_inHDBan", con);
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
