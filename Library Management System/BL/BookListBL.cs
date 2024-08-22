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
        public static DataTable GetAllBooks()
        {
            string query = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(query);
            return LibraryDL.Select(cmd);
        }
        public static int NewBook(string title, string author, string ISBN, DateTime publishYear, string Genre, int AvailableCopies)
        {
            string query = "insert into Books values(@title,@author,@ISBN,@publishYear,@Genre,@AvailableCopies)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@ISBN", ISBN);
            cmd.Parameters.AddWithValue("@publishYear", publishYear);
            cmd.Parameters.AddWithValue("@Genre", Genre);
            cmd.Parameters.AddWithValue("@AvailableCopies", AvailableCopies);
            return LibraryDL.DML(cmd);
        }
        public static int UpdateBook(int id, string title, string author, int ISBN, DateTime publishYear, string Genre, int AvailableCopies)
        {
            string query = "update Books set Title=@title,Author=@author,ISBN=@ISBN,PublishedYear=@publishYear,Genre=@Genre,AvailableCopies=@AvailableCopies where BookID=@id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@ISBN", ISBN);
            cmd.Parameters.AddWithValue("@publishYear", publishYear);
            cmd.Parameters.AddWithValue("@Genre", Genre);
            cmd.Parameters.AddWithValue("@AvailableCopies", AvailableCopies);
            return LibraryDL.DML(cmd);
        }

        public static int DeleteBook(int id)
        {
            string query = "delete from Books where BookID=@id";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            return LibraryDL.DML(cmd);
        }
        public static DataTable SearchBook(string value)
        {

            //string query = "select * from Books where Title = @title and Author = @author and Genre = @genre";
            // query to to search for books by title, author, or genre

            //string query = "SELECT * FROM Books WHERE Title LIKE @title OR Author LIKE @author OR Genre LIKE @genre";
            string query = "SELECT * FRoM Books Where Title Like '%" + value + "%' Or Author Like '%" + value + "%' Or Genre Like '%" + value + "%'";
            SqlCommand cmd = new SqlCommand(query);

            //SqlCommand cmd = new SqlCommand(query);
            //cmd.Parameters.AddWithValue("@title", value);
            //cmd.Parameters.AddWithValue("@author", value);
            //cmd.Parameters.AddWithValue("@genre", value);

            return LibraryDL.Select(cmd);
        }
    }
}
