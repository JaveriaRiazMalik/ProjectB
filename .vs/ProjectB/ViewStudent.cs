using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectB
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
           
           
        }

        /// <summary>
        /// data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           //edit button
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selected = viewstudents.Rows[e.RowIndex];
                string id = selected.Cells[2].Value.ToString();
                AddStudent frm = new AddStudent(id);
                this.Hide();
                frm.Show();
            }
            //delete button
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow selected = viewstudents.Rows[e.RowIndex];
                string id = selected.Cells[2].Value.ToString();
                MessageBox.Show("Are you sure you want to delete?");

                //deletes Student from Student Attendance
                string cmd1 = string.Format("DELETE FROM StudentAttendance WHERE StudentId='{0}'", id);
                DataConnection.get_instance().Executequery(cmd1);

                //deletes Student from Student Result
                string cmd2 = string.Format("DELETE FROM StudentResult WHERE StudentId='{0}'", id);
                DataConnection.get_instance().Executequery(cmd2);

                //deletes Student data from Student
                string cmd = string.Format("DELETE FROM Student WHERE Id='{0}'", id);
               DataConnection.get_instance().Executequery(cmd);

               


                ViewStudent frm = new ViewStudent();
                this.Hide();
                frm.Show();
            }
            
           

        }
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewStudent_Load(object sender, EventArgs e)
        {
            //reads data from Student
            SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Student"));
            List<Student> students = new List<Student>();
            while (data.Read())
            {
                Student std = new Student();
                std.Id = Convert.ToInt32(data.GetValue(0));
                std.FirstName = data.GetString(1);
                std.LastName = data.GetString(2);
                std.Contact = data.GetString(3);
                std.Email = data.GetString(4);
                std.RegistrationNo = data.GetString(5);
                std.Status = Convert.ToInt32(data.GetValue(6));
                if(std.Status == 5)
                {
                    std.Statusid = "Active";
                }
                else
                {
                    std.Statusid = "InActive";
                }
                

                students.Add(std);
            }
            BindingSource S = new BindingSource();
            S.DataSource = students;
            viewstudents.DataSource = S;

            viewstudents.Columns["Edit"].DisplayIndex = viewstudents.ColumnCount - 1;
            viewstudents.Columns["Delete"].DisplayIndex = viewstudents.ColumnCount - 1;
           

            viewstudents.Columns.RemoveAt(5);


        }

        /// <summary>
        /// showing main screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            this.Hide();
            frm.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// showing add student form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            AddStudent s = new AddStudent();
            this.Hide();
            s.Show();
        }

        /// <summary>
        /// showing add clo form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            AddCLO s = new AddCLO();
            this.Hide();
            s.Show();

        }

        /// <summary>
        /// showing assessments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            AddAssesment a = new AddAssesment();
            this.Hide();
            a.Show();
        }
    }
}
