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
    public class DAL_NhanVien:DBConnect
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
            string sql = "Select count(*) from tblNhanVien where MaNhanVien = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public DataTable getNhanVien()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from tblNhanVien", con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow itemrow = dt.NewRow();
            itemrow[1] = "";
            dt.Rows.InsertAt(itemrow, 0);
            con.Close();
            return dt;
        }
        public bool addNhanVien(NhanVien s)
        {
            string sql = "Insert into tblNhanVien values('" + s.MaNhanVien + "',N'" + s.TenNhanVien + "','" + s.SoDienThoai + "','" + s.NgaySinh + "',N'" + s.DiaChi + "')";
            thucthisql(sql);
            return true;
        }
        public bool updNhanVien(NhanVien s, string macu)
        {
            string sql = "Update tblNhanVien set MaNhanVien='" + s.MaNhanVien + "',TenNhanVien=N'" + s.TenNhanVien + "',SoDienThoai='"+s.SoDienThoai+"',NgaySinh='"+s.NgaySinh+"',DiaChi=N'"+s.DiaChi+"' where MaNhanVien='" + macu + "'";
            thucthisql(sql);
            return true;
        }
        public bool delNhanVien(string ma)
        {
            string sql = "Delete from tblNhanVien where MaNhanVien='" + ma + "'";
            thucthisql(sql);
            return true;
        }
    }
}
