using Library3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library4
{
    public partial class IssueBook : Form
    {
        private const string ConnectionString = "Data Source=SHAHD-HOSSAM3\\SQLEXPRESS;Initial Catalog=Library1;Integrated Security=True;";
        private StudentRepository studentRepository;
        private IssueBookRepository issueBookRepository;
        public IssueBook()
        {
            InitializeComponent();
            studentRepository = new StudentRepository();
            issueBookRepository = new IssueBookRepository();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                try
                {
                    // Assuming txtStudentID, txtIssueDate, and other controls for student details
                    int studentID = int.Parse(textBox5.Text);
                    DateTime issueDate = dateTimePicker1.Value;
                    string selectedBookTitle = comboBox1.Text;    
                    string studentName = textBox1.Text;
                    string studentPhone = textBox2.Text;
                    string studentAddress = textBox3.Text;
                    string studentEmail = textBox4.Text;

                    issueBookRepository.IssueBook(studentID, issueDate, selectedBookTitle, studentName, studentPhone, studentAddress, studentEmail);

                    MessageBox.Show("Book issued successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error issuing book: " + ex.Message);
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox5.Text, out int studentIDToSearch))
            {
                DataRow studentData = studentRepository.GetStudentDetailsById(studentIDToSearch);

                if (studentData != null)
                {
                    // Populate your textboxes with the retrieved data
                    textBox1.Text = studentData["Name"].ToString();
                    textBox3.Text = studentData["Address"].ToString();
                    textBox2.Text = studentData["Phone"].ToString();
                    textBox4.Text = studentData["Email"].ToString();
                }
                else
                {
                    MessageBox.Show($"No student found with ID {studentIDToSearch}.");
                    // Optionally, clear textboxes or handle as needed
                }
            }
            else
            {
                MessageBox.Show("Invalid student ID input. Please enter a valid integer.");
                // Optionally, clear textboxes or handle as needed
            }
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    // Assuming sp_getbooks returns a result set with a column named 'Title'
                    SqlCommand cmd = new SqlCommand("sp_getbooks", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable bookData = new DataTable();
                    adapter.Fill(bookData);

                    if (bookData.Rows.Count > 0)
                    {
                        // Assuming comboBox1 is the name of your ComboBox
                        comboBox1.DataSource = bookData;
                        comboBox1.DisplayMember = "Title"; // Assuming there is a "Title" column in the DataTable
                                                           // Optionally, set the default selected item
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No available books found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
