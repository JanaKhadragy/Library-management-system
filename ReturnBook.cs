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
    public partial class ReturnBook : Form
    {
        private IssueBookRepository issueBookRepository;
        public ReturnBook()
        {
            InitializeComponent();
            issueBookRepository = new IssueBookRepository();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string issueId = textBox4.Text;
            string returnDate = dateTimePicker1.Value.ToString();

            // Instantiate the repository class
            IssueBookRepository issueBookRepository = new IssueBookRepository();

            // Call the method from the repository
            issueBookRepository.ReturnBook(issueId, returnDate);

            MessageBox.Show("Book returned");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ReturnBook_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = issueBookRepository.GetIssuedBooks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            DataTable filteredData = issueBookRepository.GetIssuedBooksByStudentName(name);
            dataGridView1.DataSource = filteredData;
        }
    }
}
