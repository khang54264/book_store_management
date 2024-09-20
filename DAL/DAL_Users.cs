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
    public class DAL_Users:DBConnect
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        private string p;
        public string P { get => p; set => p = value; }

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
            string sql = "Select count(*) from tblUsers where TenDangNhap = '" + ma.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public int kiemtramk(string tdn, string mk)
        {
            con.Open();
            string sql = "Select count(*) from tblUsers where TenDangNhap = '"+ tdn.Trim() +"' and MatKhau = '" + mk.Trim() + "'";
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
        public string chkLogin(Users s)
        {
            string user = null;
            con.Open();
            cmd = new SqlCommand("proc_login",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Username", s.TenDangNhap);
            cmd.Parameters.AddWithValue("@Password", s.MatKhau);
            cmd.Parameters.AddWithValue("@Permission", s.Quyen);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(0);
                    P = reader.GetInt32(2).ToString();
                    con.Close();
                    return P;
                }
                reader.Close(); 
                con.Close();
            }
            else
            {
                con.Close();
                return "Tài khoản hoặc mật khẩu không chính xác"; 
            }
            con.Close();
            return user;
        }
        public DataTable getUsers()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from tblUsers", con);
            dt = new DataTable();
            da.Fill(dt);
            DataRow itemrow = dt.NewRow();
            itemrow[1] = "";
            dt.Rows.InsertAt(itemrow, 0);
            con.Close();
            return dt;
        }
        public bool addUsers(Users s)
        {
            string sql = "Insert into Users values('" + s.TenDangNhap + "','" + s.MatKhau + "', '" + s.Quyen + "', '" + s.MaNhanVien + "')";
            thucthisql(sql);
            return true;
        }
        public bool updUsers(Users s)
        {
            string sql = "Update tblUsers set MatKhau=N'" + s.MatKhau + "', Quyen='" + s.Quyen + "', MaNhanVien='" + s.MaNhanVien + "' where TenDangNhap='" + s.TenDangNhap + "'";
            thucthisql(sql);
            return true;
        }
        public bool delUsers(string ma)
        {
            string sql = "Delete from tblUsers where TenDangNhap='" + ma + "'";
            thucthisql(sql);
            return true;
        }
        public bool changePass(string tdn, string mkc, string mkm)
        {
            con.Open();
            cmd = new SqlCommand("Update tblUsers set MatKhau=@password where TenDangNhap=@username", con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@username", tdn);
            cmd.Parameters.AddWithValue("@password", mkm);
            cmd.ExecuteNonQuery();         
            con.Close();
            return true;  
        }
    }
}
