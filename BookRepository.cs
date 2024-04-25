using Library4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library3
{
    public class BookRepository
    {
        private const string ConnectionString = "Data Source=SHAHD-HOSSAM3\\SQLEXPRESS;Initial Catalog=Library1;Integrated Security=True;";

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT book_id, Title, Author, Year FROM Books", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book()
                            {
                                Book_ID = reader.GetInt32(reader.GetOrdinal("book_id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Author = reader.GetString(reader.GetOrdinal("Author")),
                                Year = reader.GetString(reader.GetOrdinal("Year"))
                            };

                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }
        public List<Book> SearchBooksByTitle(string searchTitle)
        {
            List<Book> books = new List<Book>();

            using (SqlConnection connection = new SqlConnection("Data Source=SHAHD-HOSSAM3\\SQLEXPRESS;Initial Catalog=Library1;Integrated Security=True;"))
            {
                connection.Open();

                string query = "SELECT book_id, Title, Author, Year FROM Books WHERE Title LIKE @SearchTitle";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchTitle", $"%{searchTitle}%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book()
                            {
                                Book_ID = reader.GetInt32(reader.GetOrdinal("book_id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Author = reader.GetString(reader.GetOrdinal("Author")),
                                Year = reader.GetString(reader.GetOrdinal("Year")),
                            };

                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }
        public void IssueBook(string bookTitle, int studentID, DateTime issueDate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("IssueBook", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookTitle", bookTitle);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@IssueDate", issueDate);
                    command.Parameters.Add("@ReturnDate", SqlDbType.NVarChar).Value = "";

                    command.ExecuteNonQuery();
                }
            }
        }


        public List<string> GetBookNames()
        {
            List<string> bookNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT Title FROM Books", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader.GetString(reader.GetOrdinal("Title"));
                            bookNames.Add(title);
                        }
                    }
                }
            }

            return bookNames;
        }
        public void InsertBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertBook", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Year", book.Year);

                    command.ExecuteNonQuery();
                    Console.WriteLine("Book inserted");
                }
            }
        }
    }
}
