using Library_Management_System.BL;
using System.Data;

namespace Library_Management_System
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
        }


        private void Clear()
        {
            txt_BookID.Clear();
            txt_Book_Author.Clear();
            txt_Book_ISBN.Clear();
            txt_Book_Title.Clear();
            txt_Book_Available_Copies.Clear();
            txt_Book_Published_Year.Clear();
            txt_Book_Genre.Clear();
            txt_BookID.Focus();
        }

        private void btn_NewBook_Click_1(object sender, EventArgs e)
        {
            if (BookListBL.NewBook(txt_Book_Title.Text, txt_Book_Author.Text, txt_Book_ISBN.Text, txt_Book_Published_Year.Text, txt_Book_Genre.Text, Convert.ToInt32(txt_Book_Available_Copies.Text)) > 0)
            {
                DataTable dt = BookListBL.GetAll();
                MessageBox.Show("Book Added Successfully");
                dataGridViewBooks.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Add Book");
            }
            
        }

        private void Library_Load(object sender, EventArgs e)
        {
            DataTable dt = BookListBL.GetAll();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("I Didn't Find Your Data", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                dataGridViewBooks.DataSource = dt;
            }
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
