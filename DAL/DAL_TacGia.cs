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
    public class DAL_TacGia:DBConnect
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
            string sql = "Select count(*) from tblTacGia where MaTacGia = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public DataTable getTacGia()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from tblTacGia", con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow itemrow = dt.NewRow();
            itemrow[1] = "";
            dt.Rows.InsertAt(itemrow, 0);
            con.Close();
            return dt;
        }
        public bool addTacGia(TacGia s)
        {
            string sql = "Insert into tblTacGia values('" + s.MaTacGia + "',N'" + s.TenTacGia + "')";
            thucthisql(sql);
            return true;
        }
        public bool updTacGia(TacGia s, string macu)
        {
            string sql = "Update tblTacGia set MaTacGia='" + s.MaTacGia + "',TenTacGia=N'" + s.TenTacGia + "' where MaTacGia='" + macu + "'";
            thucthisql(sql);
            return true;
        }
        public bool delTacGia(string ma)
        {
            string sql = "Delete from tblTacGia where MaTacGia='" + ma + "'";
            thucthisql(sql);
            return true;
        }
    }
}
