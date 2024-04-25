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
    
    public partial class View_Return : Form
    {
        private IssueBookRepository issueBookRepository;
        public View_Return()
        {
            InitializeComponent();
            issueBookRepository = new IssueBookRepository();
        }

        private void View_Return_Load(object sender, EventArgs e)
        {
            try
            {
                // Instantiate the repository class
                IssueBookRepository issueBookRepository = new IssueBookRepository();

                // Call the method from the repository
                DataTable issuedBooks = issueBookRepository.GetIssuedBooksWithReturnDate();

                // Display the DataTable in your DataGridView or any other control
                dataGridView1.DataSource = issuedBooks;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentName = textBox1.Text;
            DataTable issuedBooks = issueBookRepository.SearchIssuedBooksWithReturnDate(studentName);
            dataGridView1.DataSource = issuedBooks;
        }
    }
}
