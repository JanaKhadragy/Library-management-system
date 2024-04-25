using Library4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library4
{
    public class StudentRepository
    {
        private const string ConnectionString = "Data Source=SHAHD-HOSSAM3\\SQLEXPRESS;Initial Catalog=Library1;Integrated Security=True;";
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT ID, Name, Address, Phone, Email FROM Students", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };

                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }
        public void InsertStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertStudent", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Address", student.Address);
                    command.Parameters.AddWithValue("@Phone", student.Phone);
                    command.Parameters.AddWithValue("@Email", student.Email);


                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Student> SearchStudentsByName(string searchName)
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection("Data Source=SHAHD-HOSSAM3\\SQLEXPRESS;Initial Catalog=Library1;Integrated Security=True;"))
            {
                connection.Open();

                string query = "SELECT ID, Name, Address, Phone, Email FROM Students WHERE Name LIKE @SearchName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchName", $"%{searchName}%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student()
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };

                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }
        public DataRow GetStudentDetailsById(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetStudentDetailsById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentID", ID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Check if data is returned
                        if (dataTable.Rows.Count > 0)
                        {
                            return dataTable.Rows[0];
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}