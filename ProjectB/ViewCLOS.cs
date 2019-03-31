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
    public partial class ViewCLOS : Form
    {
        public ViewCLOS()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewCLOS_Load(object sender, EventArgs e)
        {
            //reading data from the Student table
            SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Clo"));
            List<CLO> clos = new List<CLO>();
            while (data.Read())
            {
                CLO c = new CLO();
                c.Id = Convert.ToInt32(data.GetValue(0));
                c.Name = data.GetString(1);
                c.DateCreated1 = data.GetDateTime(2);
                c.DateUpdated1 = data.GetDateTime(3);

                clos.Add(c);
            }
            BindingSource S = new BindingSource();
            S.DataSource = clos;
            viewclo.DataSource = S;

            viewclo.Columns["Edit"].DisplayIndex = viewclo.ColumnCount - 1;
            viewclo.Columns["Delete"].DisplayIndex = viewclo.ColumnCount - 1;
            viewclo.Columns["AddRubric"].DisplayIndex = viewclo.ColumnCount - 1;
            viewclo.Columns["ViewRelatedRubrics"].DisplayIndex = viewclo.ColumnCount - 1;
        }

        /// <summary>
        /// Data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewstudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit button
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selected = viewclo.Rows[e.RowIndex];
                string id = selected.Cells[4].Value.ToString();
                AddCLO frm = new AddCLO(id);
                this.Hide();
                frm.Show();
            }
            //delete button
            if (e.ColumnIndex == 1)
            {
               
                DataGridViewRow selected = viewclo.Rows[e.RowIndex];
                int id = Convert.ToInt32(selected.Cells[4].Value);
                MessageBox.Show("Are you sure you want to delete?");
                int ru;
                int ac;
                //reading data from Rubric table
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Rubric WHERE CloId={0}",id));
                if (data != null)
                {
                    while (data.Read())
                    {
                        
                        ru = Convert.ToInt32(data.GetValue(0));

                        SqlDataReader dataAs = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM AssessmentComponent WHERE RubricId={0}", ru));
                        if (dataAs != null)
                        {
                            while (dataAs.Read())
                            {
                                ac = Convert.ToInt32(dataAs.GetValue(0));
                                SqlDataReader dataSR = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM StudentResult WHERE AssessmentComponentId={0}", ac));
                                if (dataSR != null)
                                {
                                    while (dataSR.Read())
                                    {
                                        
                                        //deleting data from Student Result
                                        string cmd3 = string.Format("DELETE FROM StudentResult WHERE AssessmentComponentId='{0}'", ac);
                                        DataConnection.get_instance().Executequery(cmd3);

                                    }

                                }
                                //deleting data from Assessment Component
                                string cmd2 = string.Format("DELETE FROM AssessmentComponent WHERE RubricId='{0}'", ru);
                                DataConnection.get_instance().Executequery(cmd2);
                               


                            }

                        }
                        //reading data from Rubric Levels table
                        SqlDataReader dataR = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM RubricLevel WHERE RubricId={0}",ru));
                            if (dataR != null)
                            {
                                while (dataR.Read())
                                {
                                   
                                    //deleting data from Rubric Level
                                        string cmd2 = string.Format("DELETE FROM RubricLevel WHERE RubricId='{0}'", ru);
                                       DataConnection.get_instance().Executequery(cmd2);
                                       

                                    
                                }
                            }

                            //deleting data from Rubric
                            string cmd1 = string.Format("DELETE FROM Rubric WHERE Id='{0}'", ru);
                            DataConnection.get_instance().Executequery(cmd1);
                           
                        
                    }
                }

                //deleting data from Clo
                string cmd = string.Format("DELETE FROM Clo WHERE Id='{0}'",id);
                DataConnection.get_instance().Executequery(cmd);
                MessageBox.Show("Related Student Results Deleted");
                MessageBox.Show("Related Assessments Deleted");
                MessageBox.Show("Clo, Rubrics and  Rubric Levels Deleted");
                


                ViewCLOS frm = new ViewCLOS();
                this.Hide();
                frm.Show();
            }
            //add Rubric
            if (e.ColumnIndex == 2)
            {

                DataGridViewRow selected = viewclo.Rows[e.RowIndex];
                string id = selected.Cells[4].Value.ToString();
                AddRubric frm = new AddRubric(id);
                this.Hide();
                frm.Show();
            }
            //View related Clo Rubrics
            if (e.ColumnIndex == 3)
            {

                DataGridViewRow selected = viewclo.Rows[e.RowIndex];
                string id = selected.Cells[4].Value.ToString();
                ViewRubric frm = new ViewRubric(id);
                this.Hide();
                frm.Show();
            }
        }

        /// <summary>
        ///showing main screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main m = new Main();
            m.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        ///showing student add form
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
        ///showing Clo add form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            AddCLO s = new AddCLO();
            this.Hide();
            s.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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
