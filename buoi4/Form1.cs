using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace buoi4
{
    public partial class Form1 : Form
    {
        private BindingList<Student> students;

        public Form1()
        {
            InitializeComponent();
            students = new BindingList<Student>();
        }
        private void OnStudentUpdated(Student updatedStudent)
        {
            MessageBox.Show($"Student updated: {updatedStudent.Name}");
        }
        private void OpenForm2(Student student = null)
        {
            Form2 form2 = new Form2(students, student);
            form2.StudentUpdated += OnStudentUpdated; 
            form2.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            students = new BindingList<Student>
            {
                new Student() { Id = 1, Name = "Teo", Luong = 100000000 },
                new Student() { Id = 2, Name = "Ba", Luong = 200000000 },
                new Student() { Id = 3, Name = "Thang", Luong = 200000000}
            };
            dataStudent.DataSource = students;
        }

        private void dataStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(students);

            if (form2.ShowDialog() == DialogResult.OK)
            {
                dataStudent.Refresh(); 
            }

        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if (dataStudent.CurrentRow != null)
            {
                Student selectedStudent = dataStudent.CurrentRow.DataBoundItem as Student;
                Form2 form2 = new Form2(students, selectedStudent);
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    dataStudent.Refresh(); 
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataStudent.CurrentRow != null)
            {
                Student selectedStudent = dataStudent.CurrentRow.DataBoundItem as Student;
                students.Remove(selectedStudent);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}