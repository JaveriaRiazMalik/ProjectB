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
    public partial class AddAssesment : Form
    {
        //statis assessment id
        private string selected_id;

        
        public AddAssesment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// parametrized constructor
        /// </summary>
        public AddAssesment(string id)
        {
            selected_id = id;
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// showing Student list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            ViewStudent v = new ViewStudent();
            this.Hide();
            v.Show();
        }

        /// <summary>
        /// showing Clo list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ViewCLOS v = new ViewCLOS();
            this.Hide();
            v.Show();
        }

        /// <summary>
        /// showing Rubric list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ViewRubric v = new ViewRubric();
            this.Hide();
            v.Show();
        }

        /// <summary>
        /// showing Level list
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
        /// Addind and editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
           {
                //reading data from assessment table
                SqlDataReader data = DataConnection.get_instance().Getdata("SELECT * FROM Assessment");
                List<Assessment> list = new List<Assessment>();
                while (data.Read())
                {
                    Assessment a = new Assessment();
                    a.Id = Convert.ToInt32(data.GetValue(0));
                    a.Title = data.GetString(1);
                    a.Datecreated = data.GetDateTime(2);
                    a.Totalmarks = Convert.ToInt32(data.GetValue(3));
                    a.Totalweightage = Convert.ToInt32(data.GetValue(4));
                    list.Add(a);
                }
                Assessment assess = new Assessment();
                bool cond = true;
                if (txttitle.Text == "" || txttotalmarks.Text == "" || txttotalweightage.Text == "")
                {
                    //text boxes cannot contain empty spaces
                    MessageBox.Show("Enter all the entries in their respective boxes");
                    cond = false;
                }
                else
                {
                    if (cond == true && selected_id == null) // It means Default Constructor is called and user wants to add the Assessment
                    {
                        assess.Title = txttitle.Text;
                        assess.Totalmarks = Convert.ToInt32(txttotalmarks.Text);
                        assess.Totalweightage = Convert.ToInt32(txttotalweightage.Text);
                        assess.Datecreated = DateTime.Now;

                        //inserting the values in Assessment in database
                        string cmd = string.Format("INSERT Assessment(Title,DateCreated,TotalMarks,TotalWeightage) VALUES('{0}','{1}','{2}','{3}')", assess.Title, assess.Datecreated, assess.Totalmarks, assess.Totalweightage);
                        DataConnection.get_instance().Executequery(cmd);

                        MessageBox.Show("Assessment Added Successfully");
                        this.Hide();
                        ViewAssessment vc = new ViewAssessment();
                        vc.Show();

                    }
                    if (cond == true && selected_id != null) // It means Parameterised Constructor is called and user wants to Edit 
                    {
                        assess.Title = txttitle.Text;
                        assess.Totalmarks = Convert.ToInt32(txttotalmarks.Text);
                        assess.Totalweightage = Convert.ToInt32(txttotalweightage.Text);
                        assess.Datecreated = DateTime.Now;

                        //updating the values in the Assessment table in the database
                        string cmd = string.Format("UPDATE Assessment SET Title='{0}', DateCreated='{1}', TotalMarks='{2}', TotalWeightage='{3}' WHERE Id='{4}'", assess.Title, assess.Datecreated, assess.Totalmarks, assess.Totalweightage,selected_id);
                        DataConnection.get_instance().Executequery(cmd);

                        MessageBox.Show("Assessment Edited Successfully!");
                        this.Hide();
                        ViewAssessment vs = new ViewAssessment();
                        vs.Show();
                    }
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        
        }

        private void AddAssesment_Load(object sender, EventArgs e)
        {
            if (selected_id != null)
            {
                //reading data from Assessment table
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Assessment"));
                while (data.Read())
                {
                    Assessment a = new Assessment();
                    a.Id = Convert.ToInt32(data.GetValue(0));
                    if (a.Id == Convert.ToInt32(selected_id))
                    {
                        txttitle.Text = data.GetString(1);
                        txttotalmarks.Text = data.GetValue(3).ToString();
                        txttotalweightage.Text = data.GetValue(4).ToString();

                    }
                }
            }
        }

        /// <summary>
        /// showing assessments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            ViewAssessment v = new ViewAssessment();
            this.Show();
            v.Hide();
        }
    }
}
