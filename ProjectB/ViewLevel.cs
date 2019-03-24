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
    public partial class ViewLevel : Form
    {
        private string idrub;
        public ViewLevel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parametrized constructor of form that takes level id as parameter
        /// </summary>
        /// <param name="id"></param>
        public ViewLevel(string id)
        {
            idrub = id;
            InitializeComponent();
        }

        /// <summary>
        /// Form load function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewLevel_Load(object sender, EventArgs e)
        {
            if (idrub == null)
            {
                //reads data from Rubric Level
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM RubricLevel"));
                List<RubricLevel> rlist = new List<RubricLevel>();
                while (data.Read())
                {
                    RubricLevel r = new RubricLevel();
                    r.Id = Convert.ToInt32(data.GetValue(0));
                    r.RubricId1 = Convert.ToInt32(data.GetValue(1));
                    r.Details = data.GetString(2);
                    r.Mlevel1 = Convert.ToInt32(data.GetValue(3));
                    rlist.Add(r);
                }
                BindingSource S = new BindingSource();
                S.DataSource = rlist;
                view.DataSource = S;
            }
            if (idrub != null)
            {
                //reads data from Rubric Level
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM RubricLevel"));
                List<RubricLevel> rlist = new List<RubricLevel>();
                while (data.Read())
                {
                    RubricLevel r = new RubricLevel();
                    r.Id = Convert.ToInt32(data.GetValue(0));
                    r.RubricId1 = Convert.ToInt32(data.GetValue(1));
                    r.Details = data.GetString(2);
                    r.Mlevel1 = Convert.ToInt32(data.GetValue(3));
                    if (r.RubricId1.ToString() == idrub)
                    { rlist.Add(r); }
                }
                BindingSource S = new BindingSource();
                S.DataSource = rlist;
                view.DataSource = S;
            }
        }

        /// <summary>
        ///showing main screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            Main frm = new Main();
            this.Hide();
            frm.Show();
        }

        /// <summary>
        /// data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit button
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selected = view.Rows[e.RowIndex];
                string idlevel = selected.Cells[2].Value.ToString();
                string idrubric = selected.Cells[3].Value.ToString();
                this.Hide();
                AddLevel fr = new AddLevel(idrubric, idlevel);
                fr.Show();
            }
            //delete button
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow selected = view.Rows[e.RowIndex];
                string id = selected.Cells[2].Value.ToString();
                MessageBox.Show("Are you sure you want to delete?");

                //deletes data from from Rubric Level
                string cmd = string.Format("DELETE FROM RubricLevel WHERE Id='{0}'", id);
               DataConnection.get_instance().Executequery(cmd);
               
                MessageBox.Show("Rubric Level Deleted");
                ViewLevel frm = new ViewLevel();
                this.Hide();
                frm.Show();
            }
           
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
        ///showing clo add form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            AddCLO s = new AddCLO();
            this.Hide();
            s.Show();
        }

       
    }
    
}
