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
    public class DAL_LoaiSach:DBConnect
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
            string sql = "Select count(*) from tblLoaiSach where MaLoaiSach = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public DataTable getLoaiSach()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from tblLoaiSach", con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow itemrow = dt.NewRow();
            itemrow[1] = "";
            dt.Rows.InsertAt(itemrow, 0);
            con.Close();
            return dt;
        }
        public bool addLoaiSach(LoaiSach s)
        {
            string sql = "Insert into tblLoaiSach values('" + s.MaLoaiSach + "',N'" + s.TenLoaiSach + "')";
            thucthisql(sql);
            return true;
        }
        public bool updLoaiSach(LoaiSach s, string macu)
        {
            string sql = "Update tblLoaiSach set MaLoaiSach='" + s.MaLoaiSach + "',TenLoaiSach=N'" + s.TenLoaiSach + "' where MaLoaiSach='" + macu + "'";
            thucthisql(sql);
            return true;
        }
        public bool delLoaiSach(string ma)
        {
            string sql = "Delete from tblLoaiSach where MaLoaiSach='" + ma + "'";
            thucthisql(sql);
            return true;
        }
    }
}
