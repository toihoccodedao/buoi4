using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buoi4
{
    public partial class Form2 : Form
    {
        public event Action<Student> StudentUpdated;
        private BindingList<Student> students;
        private Student student;
        private int Luong;
        public Form2(BindingList<Student> students, Student student = null)
        {
            InitializeComponent();
            this.students = students;
            this.student = student;

            if (student != null)
            {
                boxMSSV.Text = student.Id.ToString();
                boxName.Text = student.Name;
                boxLuong.Text = student.Luong.ToString();
                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (int.TryParse(boxMSSV.Text, out int id) &&
            !string.IsNullOrWhiteSpace(boxName.Text) &&
            decimal.TryParse(boxLuong.Text, out decimal luong))
            {
                if (student == null)
                {
                    student = new Student { Id = id, Name = boxName.Text, Luong = luong };
                    students.Add(student);
                }
                else
                {
                    student.Id = id;
                    student.Name = boxName.Text;
                    student.Luong = luong;
                }

                StudentUpdated?.Invoke(student);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ.");
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            
                this.Close();
            
        }
    }
}
