using System;
using System.Data.SqlClient;
namespace Library4
{
    public class Book
    {
        public int Book_ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }

        public Book()
        {
        }

        public Book(int id, string title, string author, string year)
        {
            Book_ID = id;
            Title = title;
            Author = author;
            Year = year;
        }
    }
}