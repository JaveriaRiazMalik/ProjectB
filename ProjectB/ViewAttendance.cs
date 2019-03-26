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
            int id;
            SqlDataReader Attendence = DataConnection.get_instance().Getdata("SELECT * FROM ClassAttendance");
            while (Attendence.Read())
            {
                if (dateTimePicker1.Value.Date.ToString() == Attendence[1].ToString())
                {
                    id = Convert.ToInt32(Attendence[0]);
                    
                    SqlDataReader Attendancetoday = DataConnection.get_instance().Getdata(string.Format("SELECT FirstName,LastName,RegistrationNumber,AttendanceStatus,AttendanceId FROM StudentAttendance, Student WHERE AttendanceId='{0}'",id));
                    BindingSource s = new BindingSource();
                    s.DataSource = Attendancetoday;
                    dataGridView1.DataSource = s;

                }
            }
        }
    }
}
