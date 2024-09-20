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
    public class DAL_CTHDBan:DBConnect
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
            string sql = "Select count(*) from tblCTHoaDonBan where MaSach = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public string getTenSach(string ma)
        {
            con.Open();
            string sql = "Select TenSach from tblSach where MaSach = '" + ma.Trim() + "'";
            string ten;
            cmd = new SqlCommand(sql, con);
            ten = (string)cmd.ExecuteScalar();
            con.Close();
            return ten;
        }
        public DataTable getTableSach()
        {
            con.Open();
            da = new SqlDataAdapter("Select MaSach, TenSach, SoLuong, DonGia from tblSach", con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable getCTHDBan(string ma)
        {
            con.Open();
            da = new SqlDataAdapter("Select MaSach, SoLuong, DonGia, ThanhTien from tblCTHoaDonBan where MaHDBan = '" + ma.Trim() + "'", con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool addCTHDBan(CTHDBan s)
        {
            string sql = "Insert into tblCTHoaDonBan values('" + s.MaHDBan + "','" + s.MaSach + "','" + 1 + "','" + s.DonGia + "','" + s.ThanhTien + "')";
            thucthisql(sql);
            con.Open();
            cmd = new SqlCommand("proc_updCTHDBan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@MaHDB", s.MaHDBan);
            cmd.Parameters.AddWithValue("@MaSach", s.MaSach);
            cmd.Parameters.AddWithValue("@SoLuong", 1);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        public bool updCTHDBan(CTHDBan s)
        {
            con.Open();
            cmd = new SqlCommand("proc_updCTHDBan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@MaHDB", s.MaHDBan);
            cmd.Parameters.AddWithValue("@MaSach", s.MaSach);
            cmd.Parameters.AddWithValue("@SoLuong", s.SoLuong);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        public bool delCTHDBan(string mahd, string masach)
        {
            string sql = "Select SoLuong from tblCTHoaDonBan where MaHDBan='" + mahd + "' and MaSach='" + masach + "'";
            cmd = new SqlCommand(sql, con);
            int i = (int)cmd.ExecuteScalar();
            cmd = new SqlCommand("proc_delCTHDBan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@MaHDB", mahd);
            cmd.Parameters.AddWithValue("@MaSach", masach);
            cmd.Parameters.AddWithValue("@SoLuong", i);
            cmd.ExecuteNonQuery();
            sql = "Delete from tblCTHoaDonBan where MaHDBan='" + mahd + "' and MaSach='" + masach + "'";
            thucthisql(sql);
            return true;
        }
    }
}
