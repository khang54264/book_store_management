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
    public class DAL_NXB:DBConnect
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
            string sql = "Select count(*) from tblNhaXuatBan where MaNXB = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public DataTable getNXB()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from tblNhaXuatBan", con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow itemrow = dt.NewRow();
            itemrow[1] = "";
            dt.Rows.InsertAt(itemrow, 0);
            con.Close();
            return dt;
        }
        public bool addNXB(NXB s)
        {
            string sql = "Insert into tblNhaXuatBan values('" + s.MaNXB + "',N'" + s.TenNXB + "',N'" + s.DiaChi + "', '" + s.SoDienThoai + "', '" + s.Email + "', '" + s.Website + "')";
            thucthisql(sql);
            return true;
        }
        public bool updNXB(NXB s, string macu)
        {
            string sql = "Update tblNhaXuatBan set MaNXB='" + s.MaNXB + "',TenNXB=N'" + s.TenNXB + "',DiaChi=N'"+s.DiaChi+"',SoDienThoai='"+s.SoDienThoai+"',Email='"+s.Email+"',Website='"+s.Website+"' where MaNXB='" + macu + "'";
            thucthisql(sql);
            return true;
        }
        public bool delNXB(string ma)
        {
            string sql = "Delete from tblNhaXuatBan where MaNXB='" + ma + "'";
            thucthisql(sql);
            return true;
        }
    }
}
