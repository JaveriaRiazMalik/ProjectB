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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            DataConnection.get_instance().connectionstring = "Data Source=DESKTOP-RB72FPN\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
           
            try
            {
                var con = DataConnection.get_instance().Getconnection();
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Shows student list form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewStudent ad = new ViewStudent();
            ad.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Shows clo list form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btmMAttendance_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCLOS c = new ViewCLOS();
            c.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Shows rubric list form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMLabs_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewRubric r = new ViewRubric();
            r.Show();
        }

        /// <summary>
        /// shows attendance page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM ClassAttendance"));
            while (data.Read())
            {
                if (data[1].ToString() == DateTime.Now.Date.ToString())
                {
                    MessageBox.Show(" Attendence has already been taken today!");
                    flag = true;
                }

            }
            if (flag == false)
            {

                MarkAttendance m = new MarkAttendance();
                this.Hide();
                m.Show();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewAttendance v = new ViewAttendance();
            this.Hide();
            v.Show();
        }
    }
}
