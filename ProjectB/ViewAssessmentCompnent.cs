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
    public partial class ViewAssessmentCompnent : Form
    {
        string selected;
        public ViewAssessmentCompnent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// parametrized constructor
        /// </summary>
        /// <param name="id"></param>
        public ViewAssessmentCompnent(string id)
        {
            selected = id;
            InitializeComponent();
        }

        /// <summary>
        /// showing Student
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
        /// showing Clo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            AddCLO c = new AddCLO();
            this.Hide();
            c.Show();
        }

        /// <summary>
        /// showing Assessment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            AddAssesment a = new AddAssesment();
            this.Hide();
            a.Show();
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
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewAssessmentCompnent_Load(object sender, EventArgs e)
        {
            if (selected != null)
            {
                //reading data from AssessmentComponent
                SqlDataReader data = DataConnection.get_instance().Getdata("SELECT * FROM AssessmentComponent");
                List<AssessmentComponent> list = new List<AssessmentComponent>();
                while (data.Read())
                {
                    AssessmentComponent a = new AssessmentComponent();
                    a.Id = Convert.ToInt32(data.GetValue(0));
                    a.Rubricid = Convert.ToInt32(data.GetValue(2));
                    a.Assessmentid = Convert.ToInt32(data.GetValue(6));
                    a.Totalmarks = Convert.ToInt32(data.GetValue(3));

                    a.Name = data.GetString(1);
                    a.Datecreated = data.GetDateTime(4);
                    a.Dateupdated = data.GetDateTime(5);

                    list.Add(a);

                }
                BindingSource S = new BindingSource();
                S.DataSource = list;
                view.DataSource = S;

                view.Columns["Edit"].DisplayIndex = view.ColumnCount - 1;
                view.Columns["Delete"].DisplayIndex = view.ColumnCount - 1;
            }
            
        }

        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit button
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selected = view.Rows[e.RowIndex];
                string ida = selected.Cells[4].Value.ToString(); //assessment id
                string idac = selected.Cells[2].Value.ToString(); //assessment component id
                this.Hide();
                AddAssessmentComponent fr = new AddAssessmentComponent(ida,idac);
                fr.Show();
            }
            //delete button
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow selected = view.Rows[e.RowIndex];
                string id = selected.Cells[2].Value.ToString(); //assessment component id
                MessageBox.Show("Are you sure you want to delete?");

                //deletes data from from Assessment Component
                string cmd = string.Format("DELETE FROM AssessmentComponent WHERE Id='{0}'", id);
                DataConnection.get_instance().Executequery(cmd);

                MessageBox.Show("Assessment Component Deleted");
                ViewAssessmentCompnent frm = new ViewAssessmentCompnent(id);
                this.Hide();
                frm.Show();
            }
        }
    }
}
