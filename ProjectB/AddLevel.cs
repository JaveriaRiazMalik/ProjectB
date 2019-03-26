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
    public partial class AddLevel : Form
    {
        private string idr;
        private string idl;
        public AddLevel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// parametrized constructor of form taking rubric id as parameter
        /// </summary>
        /// <param name="id"></param>
        public AddLevel(string id)
        {
            idr = id;
            InitializeComponent();
        }

        /// <summary>
        /// parametrized constructor of form taking rubric id and rubric level id as parameter
        /// </summary>
        /// <param name="idru"></param>
        /// <param name="idle"></param>
        public AddLevel(string idru,string idle) 
        {
            idr = idru;
            idl = idle;
            InitializeComponent();
        }

        /// <summary>
        /// Saves the changes being made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //reading data from the Rubric Level table from database
                SqlDataReader data = DataConnection.get_instance().Getdata("SELECT * FROM RubricLevel");
                List<RubricLevel> rlist = new List<RubricLevel>();
                while (data.Read())
                {
                    RubricLevel rl = new RubricLevel();
                    rl.RubricId1 = Convert.ToInt32(idr);
                    rl.Details = txtdetails.Text;
                    rl.Mlevel1 = Convert.ToInt32(txtm.Text);

                    rlist.Add(rl);

                }
                RubricLevel rub = new RubricLevel();
                bool cond = true;
                if (txtdetails.Text == "" || txtm.Text == "")
                {
                    //text boxes cannot contain empty spaces
                    MessageBox.Show("Enter all the entries in their respective boxes");
                    cond = false;
                }
                else
                {
                    if (cond == true && idl == null)
                    {

                        rub.Details = txtdetails.Text;
                        rub.Mlevel1 = Convert.ToInt32(txtm.Text);
                        rub.RubricId1 = Convert.ToInt32(idr);

                        // inserting the rubric levels in the database
                        string cmd = string.Format("INSERT RubricLevel(RubricId,Details,MeasurementLevel) VALUES('{0}','{1}',{2})", rub.RubricId1, rub.Details, rub.Mlevel1);
                        DataConnection.get_instance().Executequery(cmd);

                        MessageBox.Show("Rubric Levels Added Successfully");

                        this.Hide();
                        ViewLevel vl = new ViewLevel();
                        vl.Show();



                    }
                    if (cond == true && idl != null)
                    {

                        rub.Details = txtdetails.Text;
                        rub.Id = Convert.ToInt32(idl);
                        rub.Mlevel1 = Convert.ToInt32(txtm.Text);
                        rub.RubricId1 = Convert.ToInt32(idr);


                        // updating Rubric Levels in the database
                        string cmd = string.Format("UPDATE RubricLevel SET Details='{0}', MeasurementLevel='{1}' WHERE Id='{2}'", rub.Details, rub.Mlevel1, rub.Id);
                        DataConnection.get_instance().Executequery(cmd);

                        MessageBox.Show("Rubric Level Edited Successfully!");
                        this.Hide();
                        ViewLevel vs = new ViewLevel();
                        vs.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLevel_Load(object sender, EventArgs e)
        {
            if (idl != null)
            {
                // reading data from the database from Rubric Levels
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM RubricLevel WHERE Id={0}",idl));
                while (data.Read())
                {
                        txtdetails.Text = data.GetString(2);
                        txtm.Text = data.GetValue(3).ToString();

                    
                }
            }
        }

        /// <summary>
        ///showing student list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewStudent frm = new ViewStudent();
            frm.Show();
            
        }

        /// <summary>
        ///showing CLOs List
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
        ///showing Rubrics list
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
        ///showing Rubric Levels list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            ViewLevel l = new ViewLevel();
            this.Hide();
            l.Show();
            
        }

        /// <summary>
        ///showing main screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdetail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
        
        /// <summary>
        /// showing assessments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            ViewAssessment s = new ViewAssessment();
            this.Hide();
            s.Show();

        }
    }
}
