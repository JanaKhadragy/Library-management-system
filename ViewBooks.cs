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

namespace Library4
{
    public partial class ViewBooks : Form
    {
        private BookRepository bookRepository;
        public ViewBooks()
        {
            InitializeComponent();
            bookRepository = new BookRepository();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTitle = textBox1.Text; 
            List<Book> searchResults = bookRepository.SearchBooksByTitle(searchTitle);
            dataGridView1.DataSource = searchResults;
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }
        private void LoadBooks()
        {
            dataGridView1.DataSource = bookRepository.GetBooks();
        }
    }
}
