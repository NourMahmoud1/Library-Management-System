using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library_Management_System.DAL
{
    public class BooksListDL
    {
        static string ConnectionString = "Data Source=.;Initial Catalog=Library_DB;Integrated Security=True;TrustServerCertificate=True";
        static SqlConnection con = new SqlConnection(ConnectionString);
        public static DataTable Select(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            cmd.Connection = con;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);


            return dt;
        }
        public static int DML(SqlCommand cmd)
        {
            cmd.Connection = con;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
