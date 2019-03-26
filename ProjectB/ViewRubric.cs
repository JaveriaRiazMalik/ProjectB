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
   
    public partial class ViewRubric : Form
    {
        private string idclo;
        public ViewRubric()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Parametrized constructor of form that takes rubric id as parameter
        /// </summary>
        /// <param name="id"></param>
        public ViewRubric(string id)
        {
            idclo = id;
            InitializeComponent();
        }

        /// <summary>
        /// Form load function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewRubric_Load(object sender, EventArgs e)
        {
            if (idclo == null)
            {
                //reads data from Rubric 
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Rubric"));
                List<Rubric> rlist = new List<Rubric>();
                while (data.Read())
                {
                    Rubric r = new Rubric();
                    r.Id = Convert.ToInt32(data.GetValue(0));
                    r.Details = data.GetString(1);
                    r.Cloid = Convert.ToInt32(data.GetValue(2));
                    rlist.Add(r);
                }
                BindingSource S = new BindingSource();
                S.DataSource = rlist;
                View.DataSource = S;

                View.Columns["Edit"].DisplayIndex = View.ColumnCount - 1;
                View.Columns["Delete"].DisplayIndex = View.ColumnCount - 1;
                View.Columns["AddLevel"].DisplayIndex = View.ColumnCount - 1;
                View.Columns["ViewRelatedLevels"].DisplayIndex = View.ColumnCount - 1;

            }
            if(idclo!=null)
            {
                //reads data from Rubric 
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Rubric"));
                List<Rubric> rlist = new List<Rubric>();
                while (data.Read())
                {
                    Rubric r = new Rubric();
                    r.Id = Convert.ToInt32(data.GetValue(0));
                    r.Details = data.GetString(1);
                    r.Cloid = Convert.ToInt32(data.GetValue(2));
                    if (r.Cloid.ToString() == idclo)
                    { rlist.Add(r); }
                }
                BindingSource S = new BindingSource();
                S.DataSource = rlist;
                View.DataSource = S;

                View.Columns["Edit"].DisplayIndex = View.ColumnCount - 1;
                View.Columns["Delete"].DisplayIndex = View.ColumnCount - 1;
                View.Columns["AddLevel"].DisplayIndex = View.ColumnCount - 1;
                View.Columns["ViewRelatedLevels"].DisplayIndex = View.ColumnCount - 1;
            }
        }

        /// <summary>
        /// Showing main screen
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
        private void View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit button
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selected = View.Rows[e.RowIndex];
                string idr = selected.Cells[4].Value.ToString();
                string idc = selected.Cells[5].Value.ToString();
                AddRubric frm = new AddRubric(idr, idc);
                this.Hide();
                frm.Show();
            }
            //delete button
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow selected = View.Rows[e.RowIndex];
                string id = selected.Cells[4].Value.ToString();
                MessageBox.Show("Are you sure you want to delete?");

                //read from Rubric Level
                SqlDataReader dataR = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM RubricLevel WHERE Rubricid={0}",id));
                if (dataR != null)
                {
                    while (dataR.Read())
                    {
                        int r;
                        r = Convert.ToInt32(dataR.GetValue(1));
                        if (r.ToString() == id.ToString())
                        {
                            //delete from Rubric Level
                            string cmd2 = string.Format("DELETE FROM RubricLevel WHERE RubricId='{0}'", r);
                           DataConnection.get_instance().Executequery(cmd2);
                          
                            MessageBox.Show("Related Rubric Level(s) Deleted");

                        }
                    }
                }
                //delete from Rubric 
                string cmd = string.Format("DELETE FROM Rubric WHERE Id='{0}'", id);
                 DataConnection.get_instance().Executequery(cmd);
              
                MessageBox.Show("Rubric Deleted");

               
                ViewRubric frm = new ViewRubric();
                this.Hide();
                frm.Show();
            }
            //add levels button
            if (e.ColumnIndex == 2)
            {

                DataGridViewRow selected = View.Rows[e.RowIndex];
                string id = selected.Cells[4].Value.ToString();
                AddLevel frm = new AddLevel(id);
                this.Hide();
                frm.Show();
            }
            //view related levels button
            if (e.ColumnIndex == 3)
            {

                DataGridViewRow selected = View.Rows[e.RowIndex];
                string id = selected.Cells[4].Value.ToString();
                ViewLevel frm = new ViewLevel(id);
                this.Hide();
                frm.Show();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// showing student add form
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
        /// showing clo add form
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
