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
    public partial class AddCLO : Form
    {
        private string selected_id_clo;
       
        public AddCLO()
        {
            InitializeComponent();
        }
        /// <summary>
        ///parametrized form contructor taking clo id as a parameter
        /// </summary>
        /// <param name="idc"></param>
        public AddCLO(string idc) 
        {
            selected_id_clo = idc;
           

            InitializeComponent();
        }

        /// <summary>
        /// Saves all the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //reading the data from the table Clo from database
            SqlDataReader dataC = DataConnection.get_instance().Getdata("SELECT * FROM Clo");
            List<CLO> Clo = new List<CLO>();
            while (dataC.Read())
            {
                CLO c = new CLO();
                c.Id = Convert.ToInt32(dataC.GetValue(0));
                c.Name = dataC.GetString(1);
                c.DateCreated1 = dataC.GetDateTime(2);
                c.DateUpdated1 = dataC.GetDateTime(3);
                Clo.Add(c);

            }
            CLO clo = new CLO();
            bool cond = true;
            if (txtname.Text == "")
            {
                //text boxes cannot contain empty spaces
                MessageBox.Show("Enter all the entries in their respective boxes");
                cond = false;
            }
            else
            {
                if (cond == true && selected_id_clo == null)
                {
                    clo.Name = txtname.Text;
                    clo.DateCreated1 = DateTime.Now;
                    clo.DateUpdated1 = DateTime.Now;

                    //inserting the values in Clo in database
                    string cmd = string.Format("INSERT Clo(Name,DateCreated,DateUpdated) VALUES('{0}','{1}','{2}')", clo.Name, clo.DateCreated1,clo.DateUpdated1);
                    DataConnection.get_instance().Executequery(cmd);
                 
                    MessageBox.Show("Clo Added Successfully");
                    this.Hide();
                    ViewCLOS vc = new ViewCLOS();
                    vc.Show();

                }
                if (cond == true && selected_id_clo != null)
                {
                    clo.Name = txtname.Text;
                    clo.DateUpdated1 = DateTime.Now;

                    //updating the values in the Clo table in the database
                    string cmd = string.Format("UPDATE Clo SET Name='{0}',DateUpdated='{1}' WHERE Id='{2}'", clo.Name,clo.DateUpdated1 ,selected_id_clo);
                   DataConnection.get_instance().Executequery(cmd);
                   
                    MessageBox.Show("Clo Edited Successfully!");
                    this.Hide();
                    ViewCLOS vs = new ViewCLOS();
                    vs.Show();
                }
            }
        }

        /// <summary>
        /// Form load function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCLO_Load(object sender, EventArgs e)
        {
            //settind the already present values of the student in the database on form load
            if (selected_id_clo != null)
            {
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Clo"));
                while (data.Read())
                {
                    CLO cl = new CLO();
                    cl.Id = Convert.ToInt32(data.GetValue(0));
                    if (cl.Id == Convert.ToInt32(selected_id_clo))
                    {
                        txtname.Text = data.GetString(1);
                        
                    }
                }
            }
        }

        /// <summary>
        ///showing the student list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnview_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewStudent frm = new ViewStudent();
            frm.Show();
            
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///showing CLO list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ViewCLOS c = new ViewCLOS();
            this.Hide();
            c.Show();
            
        }

        /// <summary>
        ///showing rubric list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ViewRubric r = new ViewRubric();
            this.Hide();
            r.Show();
            
        }

        /// <summary>
        ///showing level list
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
