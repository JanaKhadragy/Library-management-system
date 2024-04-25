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
    public partial class AddStudent : Form
    {
        private StudentRepository studentRepository;
        public AddStudent()
        {
            InitializeComponent();
            studentRepository = new StudentRepository();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox4.Text;
            string phone = textBox2.Text;
            string address = textBox3.Text;
            studentRepository.InsertStudent(new Student
            {
                Name = name,
                Address = address,
                Phone = phone,
                Email = email,

            });
            MessageBox.Show("Student added successfully!");
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
