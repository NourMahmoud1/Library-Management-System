using Library_Management_System.BL;
using System.Data;
using System.Net;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
        }


        private void ClearBook_txt()
        {
            txt_BookID.Clear();
            txt_Book_Author.Clear();
            txt_Book_ISBN.Clear();
            txt_Book_Title.Clear();
            txt_Book_Available_Copies.Clear();
            //txt_Book_Published_Year.Clear();
            txt_Book_Genre.Clear();
            txt_Book_Title.Focus();
        }
        private void ClearMember_txt()
        {
            txt_MemberID.Clear();
            txt_MemberName.Clear();
            txt_MemberEmail.Clear();
            txt_MemberPhoeNumber.Clear();
            txt_MemberName.Focus();
        }
        private int ValidationTextBoxBook()
        {
            //validate if the text box is empty
            if (string.IsNullOrWhiteSpace(txt_Book_Title.Text) || string.IsNullOrEmpty(txt_Book_Author.Text) || string.IsNullOrEmpty(txt_Book_Genre.Text) || string.IsNullOrEmpty(txt_Book_ISBN.Text) || string.IsNullOrEmpty(txt_Book_Published_Year.Text) || string.IsNullOrEmpty(txt_Book_Available_Copies.Text))
            {
                // Display an error message
                MessageBox.Show("Please fill All the required field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;


            }
            return 1;
        }
        private int ValidationTextBoxMember()
        {
            //validate if the text box is empty
            if (string.IsNullOrWhiteSpace(txt_MemberName.Text) || string.IsNullOrEmpty(txt_MemberEmail.Text) || string.IsNullOrEmpty(txt_MemberPhoeNumber.Text))
            {
                // Display an error message
                MessageBox.Show("Please fill All the required field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;

            }
            return 1;
        }
        private void btn_NewBook_Click_1(object sender, EventArgs e)
        {
            if (ValidationTextBoxBook() != -1)

            {
                try
                {
                    if (BookListBL.NewBook(txt_Book_Title.Text, txt_Book_Author.Text, txt_Book_ISBN.Text,Convert.ToDateTime( txt_Book_Published_Year.Text), txt_Book_Genre.Text, Convert.ToInt32(txt_Book_Available_Copies.Text)) > 0)
                    {
                        DataTable dt = BookListBL.GetAllBooks();
                        MessageBox.Show("Book Added Successfully");
                        dataGridViewBooks.DataSource = dt;
                        ClearBook_txt();

                        displayComboboxMember();
                        displayComboboxBook();

                    }
                    else
                    {
                        MessageBox.Show("Failed to Add Book");
                    }
                }
                catch (Exception ex)//txt_Book_Published_Year
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Library_Load(object sender, EventArgs e)
        {
            DataTable dtBook = BookListBL.GetAllBooks();
            dataGridViewBooks.DataSource = dtBook;
            DataTable dtMembers = MembersListBL.GetAllMembers();
            dataGridViewMembers.DataSource = dtMembers;

            DataTable dtBorrower = BorrowerBL.GetBorrowerData();
            dataGridViewBorrowerBooks.DataSource = dtBorrower;
            //insert data of the member has borrow a book to the table 
            // in the return page
            DataTable dtReturnBorrower = ReturnBookBL.GetBorrowerDataForReturn();

            dataGridViewHasBorrowerBooks.DataSource = dtReturnBorrower;

            displayComboboxMember();
            displayComboboxBook();
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ValidationTextBoxBook() != -1)
            {
                try
                {
                    if (BookListBL.UpdateBook(Convert.ToInt32(txt_BookID.Text), txt_Book_Title.Text, txt_Book_Author.Text, Convert.ToInt32(txt_Book_ISBN.Text), Convert.ToDateTime(txt_Book_Published_Year.Text), txt_Book_Genre.Text, Convert.ToInt32(txt_Book_Available_Copies.Text)) > 0)
                    {
                        DataTable dt = BookListBL.GetAllBooks();
                        MessageBox.Show("Book Updated Successfully");
                        dataGridViewBooks.DataSource = dt;
                        ClearBook_txt();

                        displayComboboxMember();
                        displayComboboxBook();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Update Book");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewBooks_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //    txt_BookID.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    txt_Book_Title.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    txt_Book_Author.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    txt_Book_ISBN.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    txt_Book_Published_Year.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    txt_Book_Genre.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    txt_Book_Available_Copies.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[6].Value.ToString();
            //
        }

        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_BookID.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_Book_Title.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Book_Author.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Book_ISBN.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Book_Published_Year.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_Book_Genre.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_Book_Available_Copies.Text = dataGridViewBooks.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (ValidationTextBoxBook() != -1)

            {

                try
                {
                    if (BookListBL.DeleteBook(Convert.ToInt32(txt_BookID.Text)) > 0)
                    {
                        DataTable dt = BookListBL.GetAllBooks();
                        MessageBox.Show("Book Deleted Successfully");
                        dataGridViewBooks.DataSource = dt;
                        ClearBook_txt();

                        displayComboboxMember();
                        displayComboboxBook();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete Book");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }

        private void btn_NewMember_Click(object sender, EventArgs e)
        {
            if (ValidationTextBoxMember() != -1)
            {
                try
                {
                    if (MembersListBL.NewMember(txt_MemberName.Text, txt_MemberEmail.Text, txt_MemberPhoeNumber.Text, DateTime.Now.ToString()) > 0)
                    {
                        DataTable dt = MembersListBL.GetAllMembers();
                        MessageBox.Show("Member Added Successfully");
                        dataGridViewMembers.DataSource = dt;
                        ClearMember_txt();

                        displayComboboxMember();
                        displayComboboxBook();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Add Member");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: "+ ex.Message);
                }
            }
        }

        private void btn_UpdateMember_Click(object sender, EventArgs e)
        {
            if (ValidationTextBoxMember() != -1)
            {
                try
                {
                    if (MembersListBL.UpdateMember(Convert.ToInt32(txt_MemberID.Text), txt_MemberName.Text, txt_MemberEmail.Text, txt_MemberPhoeNumber.Text) > 0)
                    {
                        DataTable dt = MembersListBL.GetAllMembers();
                        MessageBox.Show("Member Updated Successfully");
                        dataGridViewMembers.DataSource = dt;
                        ClearMember_txt();

                        displayComboboxMember();
                        displayComboboxBook();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Update Member");
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridViewMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MemberID.Text = dataGridViewMembers.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_MemberName.Text = dataGridViewMembers.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_MemberEmail.Text = dataGridViewMembers.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_MemberPhoeNumber.Text = dataGridViewMembers.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_MemberJoinDate.Text = dataGridViewMembers.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btn_DeleteMember_Click(object sender, EventArgs e)
        {
            if (ValidationTextBoxMember() != -1)
            {
                try
                {
                    if (MembersListBL.DeleteMember(Convert.ToInt32(txt_MemberID.Text)) > 0)
                    {

                        DataTable dt = MembersListBL.GetAllMembers();
                        MessageBox.Show("Member Deleted Successfully");
                        dataGridViewMembers.DataSource = dt;
                        ClearMember_txt();

                        displayComboboxMember();
                        displayComboboxBook();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete Member");
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        // display the member inside the combobox 
        public void displayComboboxMember()
        {
            // make the comb_Borrower Empty
            comb_Borrower.Items.Clear();
            DataTable memberData = BorrowerBL.GetMemberIdAndName();

            foreach (DataRow row in memberData.Rows)
            {
                string memberId = row["MemberID"].ToString();
                string memberName = row["Name"].ToString();


                comb_Borrower.Items.Add($"{memberId} - {memberName}");
            }
        }
        public void displayComboboxBook()
        {
            comb_Book.Items.Clear();

            DataTable bookData = BorrowerBL.GetBookIDAndTitle();

            foreach (DataRow row in bookData.Rows)
            {
                string bookId = row["BookID"].ToString();
                string bookTitle = row["Title"].ToString();

                comb_Book.Items.Add($"{bookId} - {bookTitle}");
            }
        }

        private void comb_Borrower_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void comb_Borrower_SelectedIndexChanged(object sender, EventArgs e)
        {
            int memberIndex = GetSelectedBorrowerID();
            if (memberIndex != -1)
            {
                DataTable memberData = BorrowerBL.GetSpaceficMember(memberIndex);
                dataGridViewSelectedBorrower.DataSource = memberData;
            }
        }
        private int GetSelectedBorrowerID()
        {
            if (comb_Borrower.SelectedItem != null)
            {
                string selectedItem = comb_Borrower.SelectedItem.ToString();

                string[] parts = selectedItem!.Split('-');
                int memberId = int.Parse(parts[0].Trim());

                return memberId;
            }
            return -1;
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comb_Book_SelectedIndexChanged(object sender, EventArgs e)
        {
            int bookIndex = GetSelectedBookID();
            if (bookIndex != -1)
            {
                DataTable bookData = BorrowerBL.GetSpaceficBook(bookIndex);
                dataGridViewSelectedBook.DataSource = bookData;
            }
        }
        private int GetSelectedBookID()
        {
            if (comb_Book.SelectedItem != null)
            {
                string selectedItem = comb_Book.SelectedItem.ToString();

                string[] parts = selectedItem.Split('-');
                int bookId = int.Parse(parts[0].Trim());

                return bookId;
            }
            return -1;
        }

        private void btn_BorrowConfirm_Click(object sender, EventArgs e)
        {
            int bookId = GetSelectedBookID();
            if (bookId != -1)
            {
                int memberId = GetSelectedBorrowerID();
                if (memberId != -1)
                {
                    DataTable numberOfAvailableCopiesDT = BorrowerBL.GetAvailableCopies(bookId);
                    //MessageBox.Show($"{numberOfAvailableCopiesDT.Rows[0][0].ToString()}");
                    int numberOfAvailableCopies = Convert.ToInt32(numberOfAvailableCopiesDT.Rows[0][0].ToString());
                    if (numberOfAvailableCopies > 0)
                    {
                        //
                        BorrowerBL.NewBorrower(bookId, memberId, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.AddDays(14).ToString("yyyy-MM-dd"));
                        numberOfAvailableCopies--;
                        BorrowerBL.UpdateAvailableCopies(bookId, numberOfAvailableCopies);


                        //change the data in Borrower table 
                        DataTable dtBorrower = BorrowerBL.GetBorrowerData();
                        dataGridViewBorrowerBooks.DataSource = dtBorrower;
                        //insert data of the member has borrow a book to the table 
                        // in the return page
                        DataTable dtReturnBorrower = ReturnBookBL.GetBorrowerDataForReturn();
                        dataGridViewHasBorrowerBooks.DataSource = dtReturnBorrower;
                        // change the number of available copies in the book page 
                        DataTable dtBook = BookListBL.GetAllBooks();
                        dataGridViewBooks.DataSource = dtBook;
                        MessageBox.Show("user Borrow the book Successfully");

                    }
                    else
                    {
                        MessageBox.Show("Sorry, There Are NO Available Copies Now.\nChoose Another Book");
                    }
                    //MessageBox.Show($"{numberOfAvailableCopies}");
                    //BorrowerBL.BorrowBook(bookId, memberId);
                }
                else
                {
                    MessageBox.Show("Please select a member");
                }
            }
            else
            {
                MessageBox.Show("Please select a book");
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private void tabPage3_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void dataGridViewHasBorrowerBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txt_MemberID.Text = dataGridViewMembers.Rows[e.RowIndex].Cells[0].Value.ToString();

            txt_BorrowerID.Text = dataGridViewHasBorrowerBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
            txt_MemberIDBorrower.Text = dataGridViewHasBorrowerBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_MemberNameBorrower.Text = dataGridViewHasBorrowerBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_BookIDBorrower.Text = dataGridViewHasBorrowerBooks.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_BookTitleBorrower.Text = dataGridViewHasBorrowerBooks.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_BorrowDateBorrower.Text = dataGridViewHasBorrowerBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_ReturnDateBorrower.Text = dataGridViewHasBorrowerBooks.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btn_returnBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_BorrowerID.Text != null)
                {
                    int borrowid = Convert.ToInt32(txt_BorrowerID.Text);
                    ReturnBookBL.UpdateReturnDate(borrowid, DateTime.Now.ToString());
                    // get the number of Copies
                    int bookId = Convert.ToInt32(txt_BookIDBorrower.Text);
                    DataTable numberOfAvailableCopiesDT = BorrowerBL.GetAvailableCopies(bookId);
                    int numberOfAvailableCopies = Convert.ToInt32(numberOfAvailableCopiesDT.Rows[0][0].ToString());
                    numberOfAvailableCopies++;
                    BorrowerBL.UpdateAvailableCopies(bookId, numberOfAvailableCopies);


                    DataTable dtBorrower = BorrowerBL.GetBorrowerData();
                    dataGridViewBorrowerBooks.DataSource = dtBorrower;
                    //insert data of the member has borrow a book to the table 
                    // in the return page
                    DataTable dtReturnBorrower = ReturnBookBL.GetBorrowerDataForReturn();

                    dataGridViewHasBorrowerBooks.DataSource = dtReturnBorrower;
                    // change the number of available copies in the book page 
                    DataTable dtBook = BookListBL.GetAllBooks();
                    dataGridViewBooks.DataSource = dtBook;
                    MessageBox.Show("Book Returned Successfully");
                }
                else
                {
                    MessageBox.Show("Please, Select One First");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_Book_Title_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void txt_Book_Author_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ErrorProvider error = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(txt_Book_Author.Text))
            {
                // Set error if the field is empty
                error.SetError(txt_Book_Author, "This field is required.");
                e.Cancel = true; // Prevent losing focus
            }
            else
            {
                // Clear the error if the field is filled
                error.SetError(txt_Book_Author, string.Empty);
            }
        }

        private void txt_searchBook_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = BookListBL.SearchBook(txt_searchBook.Text);

            if (dt.Rows.Count > 0)
            {
                dataGridViewBooks.DataSource = dt;
                //MessageBox.Show("Done");
            }
            else
            {
                //MessageBox.Show("No Books Found");
            }
            if (string.IsNullOrWhiteSpace(txt_searchBook.Text) || txt_searchBook.Text == ""){
                DataTable dtBook = BookListBL.GetAllBooks();
                dataGridViewBooks.DataSource = dtBook;
                MessageBox.Show("No Books Found");
            }
            

        }
    }
}
