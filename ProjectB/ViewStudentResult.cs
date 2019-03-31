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
    public partial class ViewStudentResult : Form
    {
        private string selected_id; //student id
        public ViewStudentResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// parametrised constructor of the form taking student id as a parameter
        /// </summary>
        /// <param name="id"></param>
        public ViewStudentResult(string id)
        {
            selected_id = id;
            InitializeComponent();
        }

        /// <summary>
        /// loading the assessments from assessments table in the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewStudentResult_Load(object sender, EventArgs e)
        {
            try
            {
                //reading data from Student table
                SqlDataReader dataS = DataConnection.get_instance().Getdata("SELECT * FROM Student");
                while (dataS.Read())
                {
                    if (dataS.GetInt32(0).ToString() == selected_id)
                    {
                        regno.Text = dataS.GetString(5);

                    }
                }

                //reading data from Assessment table
                SqlDataReader cmd = DataConnection.get_instance().Getdata("SELECT * FROM Assessment");
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Title", typeof(string));
                dt.Load(cmd);

                //binding data in combo box
                txtas.ValueMember = "Id";
                txtas.DisplayMember = "Title";
                txtas.DataSource = dt;

                txtas.Text = "Assessments";


                comboac.Hide();
                btnlevel.Hide();
                comborubric.Hide();
                btnresult.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        static int id; //assessment id
        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                comboac.Show();
               
                //reading data from Assessment table
                SqlDataReader dataA = DataConnection.get_instance().Getdata("SELECT * FROM Assessment");
                while (dataA.Read())
                {
                    if (txtas.Text == dataA.GetString(1).ToString())
                    {
                        id = Convert.ToInt32(dataA.GetValue(0)); //setting assessment id
                    }
                }

                //reading data from AssessmentComponent table
                SqlDataReader dataAC = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM AssessmentComponent WHERE AssessmentId='{0}'", id));
                //binding the data
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Load(dataAC);


                comboac.ValueMember = "Id";
                comboac.DisplayMember = "Name";
                comboac.DataSource = dt;

                comboac.Text = "Assessment Components";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnlevel_Click(object sender, EventArgs e)
        {
            

        }
       
        public static int ru_id; //for storing rubric id

        /// <summary>
        /// adding values in the Student Result table and showing result in data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StudentResult std = new StudentResult();
                std.Studentid = Convert.ToInt32(selected_id); //setting student id
                
                //reading data from Assessment Component table
                SqlDataReader dataAC = DataConnection.get_instance().Getdata("SELECT * FROM AssessmentComponent");
                while (dataAC.Read())
                {
                    if (comboac.Text == dataAC.GetString(1).ToString())
                    {
                        ru_id = Convert.ToInt32(dataAC.GetValue(2)); //setting rubric id
                        std.Assessmentcomponentid = Convert.ToInt32(dataAC.GetValue(0)); //setting assessment component id
                    }
                }

                //reading from Ruric Level table
                SqlDataReader dataRL = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM RubricLevel WHERE RubricId='{0}'",ru_id));
                while (dataRL.Read())
                {
                    if (comborubric.Text == dataRL.GetValue(3).ToString())
                    {
                        std.Rubricmeasurementid = Convert.ToInt32(dataRL.GetValue(0)); //setting rubric levell idb
                    }
                }

                std.Evaluationdate = DateTime.Now;

               // inserting values in Student Result table
                string cmd = string.Format("INSERT StudentResult(StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate) VALUES('{0}','{1}','{2}','{3}')", std.Studentid, std.Assessmentcomponentid, std.Rubricmeasurementid, std.Evaluationdate);
                DataConnection.get_instance().Executequery(cmd);

                //reading from Rubric and AssessmentComponent table
                SqlDataReader cmd1 = DataConnection.get_instance().Getdata(string.Format("SELECT Name AS Component, Details AS Rubric, TotalMarks, '" +comborubric.Text+ "' As StudentRubricLevel  FROM Rubric R JOIN AssessmentComponent AC ON R.Id = AC.RubricId WHERE  AC.Id='{0}'", std.Assessmentcomponentid));

                //showing result in data grid view
                BindingSource s = new BindingSource();
                s.DataSource = cmd1;
                dataGridView1.DataSource = s;
                dataGridView1.Columns["ObtainedMarks"].DisplayIndex = dataGridView1.ColumnCount - 1;
                MessageBox.Show("Result Added Successfully");

               int max;
               max = Convert.ToInt32(comborubric.Items.Count);

               foreach (DataGridViewRow dg in dataGridView1.Rows)
               {
                    //calculatin obtained marks
                    dg.Cells[0].Value = (float)(Convert.ToInt32(dg.Cells[4].Value) * Convert.ToInt32(dg.Cells[3].Value)) / max;
               }



          }
           catch (Exception ex)
          {
               MessageBox.Show(ex.Message);
           }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// showing all active student's list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click_1(object sender, EventArgs e)
        {
            Main a = new Main();
            this.Hide();
            a.Show();
        }

        private void txtas_Click(object sender, EventArgs e)
        {

        }

        private void txtas_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void comborubric_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void comboac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboac_DropDownClosed(object sender, EventArgs e)
        {
           

        }

        private void btncomp_Click(object sender, EventArgs e)
        {
            try
            {
                comboac.Show(); //showing assessment component combo box
                btnlevel.Show(); //showing level button

                //reading from Assessment table
                SqlDataReader dataA = DataConnection.get_instance().Getdata("SELECT * FROM Assessment");
                while (dataA.Read())
                {
                    if (txtas.Text == dataA.GetString(1).ToString())
                    {
                        id = Convert.ToInt32(dataA.GetValue(0)); //settin assessment id
                    }
                }

                //reading data from Assessment Component table
                SqlDataReader dataAC = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM AssessmentComponent WHERE AssessmentId='{0}'", id));

                //binding the assessment components
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Load(dataAC);


                comboac.ValueMember = "Id";
                comboac.DisplayMember = "Name";
                comboac.DataSource = dt;

                comboac.Text = "Assessment Components";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnlevel_Click_1(object sender, EventArgs e)
        {
            try

            {

                comborubric.Show(); //showing assessment level combo box
                btnresult.Show(); //showing result button

                //reading data from Assessment Component
                SqlDataReader dataAC = DataConnection.get_instance().Getdata("SELECT * FROM AssessmentComponent");
                while (dataAC.Read())
                {
                    if (comboac.Text == dataAC.GetString(1).ToString())
                    {
                        id = Convert.ToInt32(dataAC.GetValue(2)); //setting rubric id
                    }
                }

                //reading data from rubric levels table
                SqlDataReader dataRL = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM RubricLevel WHERE RubricId='{0}'", id));

                //binding measurement levels
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("MeasurementLevel", typeof(string));
                dt.Load(dataRL);


                comborubric.ValueMember = "Id";
                comborubric.DisplayMember = "MeasurementLevel";
                comborubric.DataSource = dt;

                comborubric.Text = "Rubric Levels";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
