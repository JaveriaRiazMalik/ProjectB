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
    public partial class AddAssessmentComponent : Form
    {

        private string selected_id_a; //assessment id
        private string selected_id_ac; //assessment component id
        public AddAssessmentComponent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// parametrized constructor
        /// </summary>
        /// <param name="id"></param>
        public AddAssessmentComponent(string id)
        {
            selected_id_a = id;
            InitializeComponent();
        }

        /// <summary>
        /// parametrized constructor
        /// </summary>
        /// <param name="ida"></param>
        /// <param name="idac"></param>
        public AddAssessmentComponent(string ida, string idac)
        {
            selected_id_a = ida;
            selected_id_ac = idac;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// showing Student
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
        /// showing Clo
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
        /// showing Rubric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ViewRubric r = new ViewRubric();
            this.Hide();
            r.Show();
        }

        /// <summary>
        /// showing levels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            ViewLevel v = new ViewLevel();
            this.Hide();
            v.Show();
        }

        /// <summary>
        /// showing showing assessments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
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
        private void button4_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //reading data from the AssessmentComponent table from database
                SqlDataReader data = DataConnection.get_instance().Getdata("SELECT * FROM AssessmentComponent");
                List<AssessmentComponent> rlist = new List<AssessmentComponent>();
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

                    rlist.Add(a);

                }
                AssessmentComponent ac = new AssessmentComponent();
                bool cond = true;
                if (txtname.Text == "" || comboRubric.Text == "" || txttotalmarks.Text=="" )
                {
                    //text boxes cannot contain empty spaces
                    MessageBox.Show("Enter all the entries in their respective boxes");
                    cond = false;
                }
                else
                {
                    if (cond == true && selected_id_ac == null)//for default constructor
                    {

                        ac.Name = txtname.Text;

                        //reading data from rubrics table
                        SqlDataReader dataR = DataConnection.get_instance().Getdata("SELECT * FROM Rubric");
                        while(dataR.Read())
                        {
                            if(comboRubric.Text == dataR.GetString(1))
                            {
                                ac.Rubricid = Convert.ToInt32(dataR.GetValue(0));
                            }
                        }

                        ac.Totalmarks = Convert.ToInt32(txttotalmarks.Text);
                        ac.Datecreated = DateTime.Now;
                        ac.Dateupdated = DateTime.Now;
                        ac.Assessmentid = Convert.ToInt32(selected_id_a);

                        // inserting the assessmen component in the database
                        string cmd = string.Format("INSERT AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", ac.Name,ac.Rubricid, ac.Totalmarks, ac.Datecreated, ac.Dateupdated, selected_id_a);
                        DataConnection.get_instance().Executequery(cmd);

                        MessageBox.Show("Assessment Component Added Successfully");

                        this.Hide();
                        ViewAssessmentCompnent vl = new ViewAssessmentCompnent(ac.Assessmentid.ToString());
                        vl.Show();



                    }
                    if (cond == true && selected_id_ac != null)//for parametrized constructor
                    {

                        ac.Name = txtname.Text;

                        SqlDataReader dataR = DataConnection.get_instance().Getdata("SELECT * FROM Rubric");
                        while (dataR.Read())
                        {
                            if (comboRubric.Text == dataR.GetString(1))
                            {
                                ac.Rubricid = Convert.ToInt32(dataR.GetValue(0));
                            }
                        }

                        ac.Totalmarks = Convert.ToInt32(txttotalmarks.Text);
                       
                        ac.Dateupdated = DateTime.Now;
                        ac.Assessmentid = Convert.ToInt32(selected_id_a);

                        // updating Assessment Components in the database
                        string cmd = string.Format("UPDATE AssessmentComponent SET Name='{0}',RubricId='{1}',TotalMarks='{2}',DateUpdated='{3}' WHERE AssessmentId='{4}'", ac.Name, ac.Rubricid, ac.Totalmarks, ac.Dateupdated,selected_id_a);
                        DataConnection.get_instance().Executequery(cmd);

                        MessageBox.Show("Assessment Component edited successfully");
                        this.Hide();
                        ViewAssessmentCompnent m = new ViewAssessmentCompnent(ac.Assessmentid.ToString());
                        m.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddAssessmentComponent_Load(object sender, EventArgs e)
        {
            //reading data from rubrics table
            SqlDataReader cmd = DataConnection.get_instance().Getdata("SELECT * FROM Rubric");
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Details", typeof(string));
            dt.Load(cmd);

            comboRubric.ValueMember = "Id";
            comboRubric.DisplayMember = "Details";
            comboRubric.DataSource = dt;

            comboRubric.Text = "";


            if (selected_id_ac != null) //displaying assessment component of a specific assessment
            {
                // reading data from the database from Rubric Levels
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM AssessmentComponent WHERE Id={0}", selected_id_ac));
                while (data.Read())
                {
                    SqlDataReader dataR = DataConnection.get_instance().Getdata("SELECT * FROM Rubric");
                    while (dataR.Read())
                    {
                        if (data.GetValue(2).ToString() == dataR.GetValue(0).ToString())
                        {
                            comboRubric.Text = dataR.GetValue(1).ToString();
                        }
                    }

                    
                    txtname.Text = data.GetString(1);
                    txttotalmarks.Text = data.GetValue(3).ToString() ;
                   


                }
            }


        }
    }
}
