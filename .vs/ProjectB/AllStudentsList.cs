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
    public partial class AllStudentsList : Form
    {
        public AllStudentsList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Showing student list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            ViewStudent s = new ViewStudent();
            this.Hide();
            s.Show();
        }

        /// <summary>
        /// showing CLO list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ViewCLOS c = new ViewCLOS();
            this.Hide();
            c.Show();
        }

        /// <summary>
        /// showing Assessment list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ViewAssessment v = new ViewAssessment();
            this.Hide();
            v.Show();
        }

        /// <summary>
        /// showing main screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();

        }

        /// <summary>
        /// showing student list in grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //view result of a particulat student
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selected = view.Rows[e.RowIndex];
                string id = selected.Cells[1].Value.ToString();
                ViewStudentResult v = new ViewStudentResult(id);
                this.Hide();
                v.Show();
            }
        }

        /// <summary>
        /// Adding and editing values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllStudentsList_Load(object sender, EventArgs e)
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
            view.DataSource = S;

            view.Columns.RemoveAt(4);
            view.Columns["GenerateResult"].DisplayIndex = view.ColumnCount - 1;
        }
    }
}
