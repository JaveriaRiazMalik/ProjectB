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
    public partial class MarkAttendance : Form
    {
        public MarkAttendance()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewStudent s = new ViewStudent();
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewCLOS s = new ViewCLOS();
            this.Hide();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewRubric r = new ViewRubric();
            this.Hide();
            r.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewLevel l = new ViewLevel();
            this.Hide();
            l.Show();
        }

        private void txtsubmit_Click(object sender, EventArgs e)
        {
                   }

        private void viewclo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MarkAttendance_Load(object sender, EventArgs e)
        {
            SqlDataReader dataS = DataConnection.get_instance().Getdata("SELECT * FROM Student");
            List<Student> stdlist = new List<Student>();
            while (dataS.Read())
            {
                if (dataS.GetInt32(6) == 5)
                {
                    Student st = new Student();
                    st.Id = Convert.ToInt32(dataS.GetValue(0));
                    st.FirstName = dataS.GetString(1);
                    st.LastName = dataS.GetString(2);
                    st.Contact = dataS.GetString(3);
                    st.Email = dataS.GetString(4);
                    st.RegistrationNo = dataS.GetString(5);
                    st.Status = Convert.ToInt32(dataS.GetValue(6));
                    st.Statusid = dataS.GetValue(6).ToString();
                    stdlist.Add(st);
                }
            }
            BindingSource S = new BindingSource();
            S.DataSource = stdlist;
            viewattendance.DataSource = S;

            viewattendance.Columns.RemoveAt(4);
            viewattendance.Columns["Mark"].DisplayIndex = viewattendance.ColumnCount - 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = DateTime.Now.Date;
                string cmd = string.Format("INSERT ClassAttendance(AttendanceDate) VALUES('{0}')", d);
                DataConnection.get_instance().Executequery(cmd);

                for (int n = 0; n < viewattendance.RowCount - 1; n++)
                {

                    SqlDataReader std = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Student"));
                    while (std.Read())
                    {

                        string attstatus = viewattendance.Rows[n].Cells[0].Value.ToString();
                        string stdid = viewattendance.Rows[n].Cells[1].Value.ToString();

                        if (std[0].ToString() == stdid)
                        {
                            SqlDataReader clsdate = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM ClassAttendance"));
                            while (clsdate.Read())
                            {
                                SqlDataReader status = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Lookup"));
                                if (clsdate[1].ToString() == d.ToString())
                                {
                                    while (status.Read())
                                    {
                                        if (attstatus == status[1].ToString())
                                        {
                                            StudentAttendance stdatt = new StudentAttendance();
                                            stdatt.Attendanceid = Convert.ToInt32(clsdate[0]);
                                            stdatt.Attendancestatus = Convert.ToInt32(status[0]);
                                            stdatt.Studentid = Convert.ToInt32(std[0]);

                                            string cmd2 = string.Format("INSERT StudentAttendance(AttendanceId,StudentId,AttendanceStatus) VALUES('{0}','{1}','{2}')", stdatt.Attendanceid, stdatt.Studentid, stdatt.Attendancestatus);
                                            DataConnection.get_instance().Executequery(cmd2);
                                           
                                        }
                                    }
                                }
                            }

                        }

                    }
                }
                MessageBox.Show("Attendance Submitted");
                this.Hide();
                Main m = new Main();
                m.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewAssessment v = new ViewAssessment();
            this.Hide();
            v.Show();
        }
    }
}
