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

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewStudent s = new ViewStudent();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCLOS c = new ViewCLOS();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewRubric r = new ViewRubric();
            r.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewLevel rl = new ViewLevel();
            rl.Show();

        }

        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.Show();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int ids;
                List<ViewAttendanceList> list = new List<ViewAttendanceList>();
                SqlDataReader Attendance = DataConnection.get_instance().Getdata("SELECT * FROM ClassAttendance");
                while (Attendance.Read())
                {
                    if (dateTimePicker1.Value.Date.ToString() == Attendance[1].ToString())
                    {
                        id = Convert.ToInt32(Attendance[0]);

                        SqlDataReader Attendancetoday = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM StudentAttendance WHERE AttendanceId = '{0}'", id));
                        while (Attendancetoday.Read())
                        {
                            ids = Convert.ToInt32(Attendancetoday[1]);

                            SqlDataReader student = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Student WHERE Id = '{0}'", ids));
                            while (student.Read())
                            {

                               if (ids.ToString() == student[0].ToString())
                               {
                                    ViewAttendanceList v = new ViewAttendanceList();
                                    v.Firstname = student.GetString(1);
                                    v.Lastname = student.GetString(2);
                                    v.Regno = student.GetString(5);
                                    v.Attendanceid = Convert.ToInt32(Attendancetoday.GetValue(0));
                                    v.Attendancestatus = Convert.ToInt32(Attendancetoday.GetValue(2));
                                    v.Studentid = Convert.ToInt32(Attendancetoday.GetValue(1));
                                    if (v.Attendancestatus == 1)
                                    {
                                        v.Status = "Present";
                                    }
                                    else if (v.Attendancestatus == 2)
                                    {
                                        v.Status = "Absent";
                                    }
                                    else if (v.Attendancestatus == 3)
                                    {
                                        v.Status = "Leave";
                                    }
                                    else
                                    {
                                        v.Status = "Late";
                                    }
                                    list.Add(v);

                               }

                            }

                        }

                    }
                }
                BindingSource s = new BindingSource();
                s.DataSource = list;
                dataGridView1.DataSource = s;
                dataGridView1.Columns.RemoveAt(6);
            }
           catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddAssesment a = new AddAssesment();
            this.Hide();
            a.Show();
        }
    }
}
