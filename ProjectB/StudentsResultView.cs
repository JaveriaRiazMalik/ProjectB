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
    public partial class StudentsResultView : Form
    {
        public StudentsResultView()
        {
            InitializeComponent();
        }

        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            AddStudent s = new AddStudent();
            this.Hide();
            s.Show();
           
        }

        private void StudentsResultView_Load(object sender, EventArgs e)
        {
            //reading data from Student
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
            dataGridView1.DataSource = S;

            dataGridView1.Columns.RemoveAt(4);
            dataGridView1.Columns["GenerateResult"].DisplayIndex = dataGridView1.ColumnCount - 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //view result of a particulat student
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selected = dataGridView1.Rows[e.RowIndex];
                string id = selected.Cells[1].Value.ToString();
                ViewStudentResult v = new ViewStudentResult(id);
                this.Hide();
                v.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PDFReports p = new PDFReports();
            this.Hide();
            p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCLO c = new AddCLO();
            this.Hide();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAssesment a = new AddAssesment();
            this.Hide();
            a.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }
    }
}
