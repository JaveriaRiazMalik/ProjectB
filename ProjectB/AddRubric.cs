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
    public partial class AddRubric : Form
    {
        private string selected_id_clo;
        private string selected_id;
        public AddRubric()
        {
            InitializeComponent();
        }

        /// <summary>
        /// parametrized constructor of form taking clo id as parameter
        /// </summary>
        /// <param name="id"></param>
        public AddRubric(string id)
        {
            selected_id_clo = id;
            InitializeComponent();


        }
        /// <summary>
        /// parametrized constructor of form taking rubric id and clo id as parameter
        /// </summary>
        /// <param name="idr"></param>
        /// <param name="idc"></param>
        public AddRubric(string idr , string idc)
        {
            selected_id_clo = idc;
            selected_id = idr;
            InitializeComponent();


        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRubric_Load(object sender, EventArgs e)
        {
            if (selected_id != null)
            {
                // reading data from the database from Rubric
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Rubric"));
                while (data.Read())
                {
                    Rubric r = new Rubric();
                    r.Id = Convert.ToInt32(data.GetValue(0));
                    if (r.Id == Convert.ToInt32(selected_id))
                    {
                         txtdetails.Text = r.Details;
                       
                    }
                    }
            }
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

                //reading data from the Rubric table from database
                SqlDataReader data = DataConnection.get_instance().Getdata("SELECT * FROM Rubric");
                List<Rubric> rlist = new List<Rubric>();
                while (data.Read())
                {
                    Rubric ru = new Rubric();
                    ru.Id = Convert.ToInt32(data.GetValue(0));
                    ru.Details = data.GetString(1);
                    ru.Cloid = Convert.ToInt32(data.GetValue(2));

                    rlist.Add(ru);

                }
                Rubric rub = new Rubric();
                bool cond = true;
                if (txtdetails.Text == "")
                {
                    //text boxes cannot contain empty spaces
                    MessageBox.Show("Enter all the entries in their respective boxes");
                    cond = false;
                }
                else
                {
                    if (cond == true && selected_id == null)
                    {

                        rub.Details = txtdetails.Text;
                        rub.Cloid = Convert.ToInt32(selected_id_clo);

                        // inserting the rubrics in the database
                        string cmd = string.Format("INSERT Rubric(Details,Cloid) VALUES('{0}','{1}')", rub.Details, rub.Cloid);
                        DataConnection.get_instance().Executequery(cmd);

                        MessageBox.Show("Rubric Added Successfully");
                        this.Hide();
                        ViewRubric vc = new ViewRubric();
                        vc.Show();

                    }
                    if (cond == true && selected_id != null)
                    {

                        rub.Details = txtdetails.Text;
                        rub.Id = Convert.ToInt32(selected_id);


                        // updating Rubric in the database
                        string cmd = string.Format("UPDATE Rubric SET Details='{0}' WHERE Id='{1}'", rub.Details, rub.Id);
                        DataConnection.get_instance().Executequery(cmd);

                        MessageBox.Show("Rubric Edited Successfully!");
                        this.Hide();
                        ViewRubric vs = new ViewRubric();
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

        private void label1_Click(object sender, EventArgs e)
        {

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
    }
}
