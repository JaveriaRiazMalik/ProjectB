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
    public partial class ViewAttendance : Form
    {
        public ViewAttendance()
        {
            InitializeComponent();
        }

        /// <summary>
        /// showing Student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewStudent s = new ViewStudent();
            s.Show();
        }

        /// <summary>
        /// showing Clo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCLOS c = new ViewCLOS();
            c.Show();
        }

        /// <summary>
        /// showing Rubric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewRubric r = new ViewRubric();
            r.Show();
        }

        /// <summary>
        /// showing level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewLevel rl = new ViewLevel();
            rl.Show();

        }

        /// <summary>
        /// showing Main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.Show();
        }

        /// <summary>
        /// adding attendance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                bool flag = false;

                //reading data from ClassAttendance
                SqlDataReader Attendance = DataConnection.get_instance().Getdata("SELECT * FROM ClassAttendance");
                while (Attendance.Read())
                {
                    if (dateTimePicker1.Value.Date.ToString() == Attendance[1].ToString())
                    {
                        id = Convert.ToInt32(Attendance[0]);

                        //applying JOIN on StudentAttendace and Student
                        SqlDataReader Attendancetoday = DataConnection.get_instance().Getdata(string.Format("SELECT FirstName,LastName,RegistrationNumber,AttendanceStatus,AttendanceId FROM StudentAttendance S JOIN Student D ON S.StudentId = D.Id WHERE S.AttendanceId='{0}'",id));


                        BindingSource s = new BindingSource();
                        s.DataSource =Attendancetoday ;
                        dataGridView1.DataSource = s;
                       

                        
                        foreach(DataGridViewRow dg in dataGridView1.Rows )
                        {
                            if(dg.Cells[4].FormattedValue.ToString() == "1")
                            {
                                dg.Cells[0].Value = "Present";
                            }
                            else if (dg.Cells[4].FormattedValue.ToString() == "2")
                            {
                                dg.Cells[0].Value = "Absent";
                            }
                            else if (dg.Cells[4].FormattedValue.ToString() == "3")
                            {
                                dg.Cells[0].Value = "Leave";
                            }
                            else
                            {
                                dg.Cells[0].Value = "Late";
                            }
                        }
                        dataGridView1.Columns.RemoveAt(5);
                        dataGridView1.Columns.RemoveAt(4);
                        

                    }
                    else
                    {
                        flag = true;

                    }

                }
                if(flag)
                {
                    MessageBox.Show("No attendance has been marked on this day");
                }

            }

                 
           catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// showing Assessment Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            AddAssesment a = new AddAssesment();
            this.Hide();
            a.Show();
        }

        private void ViewAttendance_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
