using Library_Management_System.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public static class ReturnBookBL
    {
        //Update the ReturnDate in the BorrowedBooks table 
        public static int UpdateReturnDate(int borroweID, string date)
        {
            string query = "update BorrowedBooks set ReturnDate = @returnDate,ReturnState = 1 where BorrowID = @id;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@returnDate", date);
            cmd.Parameters.AddWithValue("@id", borroweID);
            return LibraryDL.DML(cmd);
        }
        public static DataTable GetBorrowerDataForReturn()
        {
            string query = "SELECT BorrowedBooks.BorrowID, Members.MemberID, Members.Name, Books.BookID, Books.Title, BorrowedBooks.BorrowDate, BorrowedBooks.ReturnDate FROM Books INNER JOIN BorrowedBooks ON Books.BookID = BorrowedBooks.BookID INNER JOIN Members ON BorrowedBooks.MemberID = Members.MemberID where not BorrowedBooks.ReturnState  = 1";
            SqlCommand cmd = new SqlCommand(query);
            return LibraryDL.Select(cmd);
        }
    }
}
