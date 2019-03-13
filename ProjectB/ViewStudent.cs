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
            DataConnection.get_instance().connectionstring = "Data Source=HAIER-PC\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True";
           
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var con = DataConnection.get_instance().Getconnection();
            con.Open();
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selected = viewstudents.Rows[e.RowIndex];
                string id = selected.Cells[2].Value.ToString();
                AddStudent frm = new AddStudent(id);
                this.Hide();
                frm.Show();
            }
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow selected = viewstudents.Rows[e.RowIndex];
                string id = selected.Cells[2].Value.ToString();
                MessageBox.Show("Are you sure you want to delete?");
                string cmd = string.Format("DELETE FROM Student WHERE Id='{0}'", id);
                int rows = DataConnection.get_instance().Executequery(cmd);
                MessageBox.Show(String.Format("{0} rows affected", rows));
                ViewStudent frm = new ViewStudent();
                this.Hide();
                frm.Show();
            }
            con.Close();

        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            var con = DataConnection.get_instance().Getconnection();
            con.Open();
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
            
                students.Add(std);
            }
            BindingSource S = new BindingSource();
            S.DataSource = students;
            viewstudents.DataSource = S;
            con.Close();

        }

        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            this.Hide();
            frm.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
