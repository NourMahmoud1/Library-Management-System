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
    public static class BorrowerBL
    {
        public static DataTable GetMemberIdAndName() // to insert into combo box of the Members
        {
            string query = "select MemberID, Name from Members;";
            SqlCommand cmd = new SqlCommand(query);
            return LibraryDL.Select(cmd);
        }
        public static DataTable GetBookIDAndTitle() // to insert into combo box of the Books
        {
            string query = "select BookID, Title from Books;";
            SqlCommand cmd = new SqlCommand(query);
            return LibraryDL.Select(cmd);
        } 
        public static DataTable GetSpaceficMember(int id)
        {
            string query = "select * from Members where MemberID = @id;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            return LibraryDL.Select(cmd);
        }
        public static DataTable GetSpaceficBook(int id)
        {
            string query = "select * from Books where BookID = @id;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            return LibraryDL.Select(cmd);
        }
        //get the number of Available Copies
        public static DataTable GetAvailableCopies(int id)
        {
            string query = "select AvailableCopies from Books where BookID = @id;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            return LibraryDL.Select(cmd);
        }

        public static int NewBorrower(int memberID, int bookID, string borrowDate, string returnDate)
        {
            string query = "insert into BorrowedBooks values(@memberID, @bookID, @borrowDate, @returnDate,0);";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@memberID", memberID);
            cmd.Parameters.AddWithValue("@bookID", bookID);
            cmd.Parameters.AddWithValue("@borrowDate", borrowDate);
            cmd.Parameters.AddWithValue("@returnDate", returnDate);
            return LibraryDL.DML(cmd);
        }
        //UpdateAvailableCopies
        public static int UpdateAvailableCopies(int id, int availableCopies)
        {
            string query = "update Books set AvailableCopies = @availableCopies where BookID = @id;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@availableCopies", availableCopies);
            return LibraryDL.DML(cmd);
        }
        //get the borrow data
        public static DataTable GetBorrowerData()
        {
            string query = "SELECT BorrowedBooks.BorrowID, BorrowedBooks.BorrowDate, BorrowedBooks.ReturnDate,BorrowedBooks.ReturnState, Members.Name, Books.Title, Books.ISBN FROM Books INNER JOIN BorrowedBooks ON Books.BookID = BorrowedBooks.BookID INNER JOIN Members ON BorrowedBooks.MemberID = Members.MemberID;";
            SqlCommand cmd = new SqlCommand(query);
            return LibraryDL.Select(cmd);
        }
    }
}
