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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewStudent viewStudent = new ViewStudent();
            viewStudent.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewBooks viewBooks = new ViewBooks();
            viewBooks.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IssueBook issueBook = new IssueBook();
            issueBook.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewIssue book = new ViewIssue();
            book.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ReturnBook returnBook = new ReturnBook();
            returnBook.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            View_Return view_Return = new View_Return();
            view_Return.ShowDialog();   
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
