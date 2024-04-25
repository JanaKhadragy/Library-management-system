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
    public partial class ViewStudent : Form
    {
        private StudentRepository studentRepository;
        public ViewStudent()
        {
            InitializeComponent();
            studentRepository = new StudentRepository();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dataGridView1.DataSource = studentRepository.GetStudents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchName = textBox1.Text; 
            List<Student> searchResults = studentRepository.SearchStudentsByName(searchName);

          
            dataGridView1.DataSource = searchResults;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
