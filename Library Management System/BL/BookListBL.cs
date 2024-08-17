using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.DAL;
namespace Library_Management_System.BL
{
    public static class BookListBL
    {
        public static DataTable GetAll()
        {
            string query = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(query);
            return BooksListDL.Select(cmd);
        }
        public static int NewBook(string title,string  author, string ISBN, string publishYear, string Genre, int AvailableCopies)
        {
            string query = "insert into Books values(@title,@author,@ISBN,@publishYear,@Genre,@AvailableCopies)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@ISBN", ISBN);
            cmd.Parameters.AddWithValue("@publishYear", publishYear);
            cmd.Parameters.AddWithValue("@Genre", Genre);
            cmd.Parameters.AddWithValue("@AvailableCopies", AvailableCopies);
            return BooksListDL.DML(cmd);
        }
        //public static int UpdateBook(int id, string title, string author, string ISBN, string publishYear, string Genre, int AvailableCopies)
        //{

        //}
    }
}
