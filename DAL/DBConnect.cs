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
    public class DBConnect
    {
        protected SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3PJ7VU8K\SQLEXPRESS;Initial Catalog=QLCuaHangSach;Integrated Security=True");
        //SqlCommand cmd;
        //SqlDataReader dr;
        //SqlDataAdapter da;
        //DataSet ds;
        //DataTable dt;
    }
}
