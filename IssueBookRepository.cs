using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Library3;
using System.Windows.Forms;

namespace Library4
{
    public class IssueBookRepository
    {
        private const string ConnectionString = "Data Source=SHAHD-HOSSAM3\\SQLEXPRESS;Initial Catalog=Library1;Integrated Security=True;";
        public void IssueBook(int studentID, DateTime issueDate, string bookTitle, string studentName, string studentPhone, string studentAddress, string studentEmail)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertIssuedBook", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@IssueDate", issueDate);
                    command.Parameters.AddWithValue("@BookTitle", bookTitle);
                    command.Parameters.AddWithValue("@StudentName", studentName);
                    command.Parameters.AddWithValue("@StudentPhone", studentPhone);
                    command.Parameters.AddWithValue("@StudentAddress", studentAddress);
                    command.Parameters.AddWithValue("@StudentEmail", studentEmail);

                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetIssuedBooks()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                // Assuming you have a stored procedure named 'get_issued_books_with_null_return_date'
                using (SqlCommand command = new SqlCommand("get_issued_books_with_null_return_date", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        return dataTable;
                    }
                }
            }
        }
        public void ReturnBook(string issueId, string returnDate)
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("update_issue_book", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = issueId;
                        cmd.Parameters.Add("@returndate", SqlDbType.NVarChar).Value = returnDate;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        public DataTable GetIssuedBooksByStudentName(string studentName)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Use a parameterized query to avoid SQL injection
                string query = "SELECT * FROM IssuedBooks WHERE StudentName LIKE @StudentName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentName", "%" + studentName + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        public DataTable GetIssuedBooksWithReturnDate()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                // Assuming you have a stored procedure named 'get_issued_books_with_return_date'
                using (SqlCommand command = new SqlCommand("get_issued_books_with_return_date", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        return dataTable;
                    }
                }
            }
        }
        public DataTable SearchIssuedBooksWithoutReturnDate(string studentName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("search_issued_books_by_partial_student_name_without_return_date", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PartialStudentName", studentName);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in SearchIssuedBooksWithoutReturnDate: " + ex.Message);
                return null; // or handle the error as needed
            }
        }
        public DataTable SearchIssuedBooksWithReturnDate(string studentName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("search_issued_books_by_partial_student_name_with_return_date", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PartialStudentName", studentName);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in SearchIssuedBooksWithReturnDate: " + ex.Message);
                return null; // or handle the error as needed
            }
        }
    }
}

