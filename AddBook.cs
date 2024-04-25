using Library3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library4
{
    public partial class AddBook : Form
    {
        private BookRepository bookRepository;
        public AddBook()
        {
            InitializeComponent();
            bookRepository = new BookRepository();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string author = textBox2.Text;
            string year = textBox3.Text;
            bookRepository.InsertBook(new Book
            {
                Title = title,
                Author = author,
                Year = year,
            });
            MessageBox.Show("Book added successfully!");
        }
    }
}
