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
    public class DAL_KhachHang:DBConnect
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
            string sql = "Select count(*) from tblKhachHang where MaKhachHang = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public DataTable getKhachHang()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from tblKhachHang", con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow itemrow = dt.NewRow();
            itemrow[1] = "";
            dt.Rows.InsertAt(itemrow, 0);
            con.Close();
            return dt;
        }
        public bool addKhachHang(KhachHang s)
        {
            string sql = "Insert into tblKhachHang values('" + s.MaKhachHang + "',N'" + s.TenKhachHang + "','" + s.SoDienThoai + "',N'" + s.DiaChi + "')";
            thucthisql(sql);
            return true;
        }
        public bool updKhachHang(KhachHang s, string macu)
        {
            string sql = "Update tblKhachHang set MaKhachHang='" + s.MaKhachHang + "',TenKhachHang=N'" + s.TenKhachHang + "',SoDienThoai='" + s.SoDienThoai + "',DiaChi=N'" + s.DiaChi + "' where MaKhachHang='" + macu + "'";
            thucthisql(sql);
            return true;
        }
        public bool delKhachHang(string ma)
        {
            string sql = "Delete from tblKhachHang where MaKhachHang='" + ma + "'";
            thucthisql(sql);
            return true;
        }
    }
}
