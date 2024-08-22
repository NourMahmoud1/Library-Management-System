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
    public static class MembersListBL
    {
        public static DataTable GetAllMembers()
        {
            string query = "SELECT * from Members;";
            SqlCommand cmd = new SqlCommand(query);
            return LibraryDL.Select(cmd);
        }

        public static int NewMember(string name, string email, string phone,  string joinDate)
        {
            string query = "insert into Members values(@name, @email, @phone, @joinDate);";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@joinDate", joinDate);
            return LibraryDL.DML(cmd);
        }
        public static int UpdateMember(int id, string name, string email, string phone)
        {
            string query = "update Members set Name = @name, Email = @email, PhoneNumber = @phone WHERE MemberID = @id;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            //cmd.Parameters.AddWithValue("@joinDate", joinDate);
            return LibraryDL.DML(cmd);
        }
        public static int DeleteMember(int id)
        {
            string query = "delete from Members where MemberID = @id;";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            return LibraryDL.DML(cmd);
        }
    }
}
