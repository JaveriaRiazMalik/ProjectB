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
    public partial class AddStudent : Form
    {
        private string selected_id;
        public AddStudent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// parametrized constructor of form taking student id as parameter
        /// </summary>
        /// <param name="passed_id"></param>
        public AddStudent(string passed_id)
        {
            selected_id = passed_id;
            InitializeComponent();
        }

       
        private void txtSLname_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisterS_Click(object sender, EventArgs e)
        {
          
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSFname_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSLname_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Saves changes being made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegisterS_Click_1(object sender, EventArgs e)
        {
            try { 
            //reading data from the Student table from database
            SqlDataReader dataS = DataConnection.get_instance().Getdata("SELECT * FROM Student");
            List<Student> stdlist = new List<Student>();
            while (dataS.Read())
            {
                Student st = new Student();
                st.Id = Convert.ToInt32(dataS.GetValue(0));
                st.FirstName = dataS.GetString(1);
                st.LastName = dataS.GetString(2);
                st.Contact = dataS.GetString(3);
                st.Email = dataS.GetString(4);
                st.RegistrationNo = dataS.GetString(5);
                st.Status = Convert.ToInt32(dataS.GetValue(6));
                st.Statusid = dataS.GetValue(6).ToString();
                stdlist.Add(st);
            }
            Student std = new Student();
            bool cond = true;
            if (txtSFname.Text == "" || txtSLname.Text == "" || txtScontact.Text == "" || txtSemail.Text == "" || txtSRno.Text == "" || txtSStatus.Text == "")
            {
                MessageBox.Show("Enter all the entries in their respective boxes");
                //text boxes cannot contain empty spaces
                cond = false;
            }
            else
            {
                if (selected_id == null)
                {

                    foreach (Student s in stdlist)
                    {

                        if (s.RegistrationNo == txtSRno.Text)
                        {
                            //checks whether the entries are unique or not
                            MessageBox.Show("Student cannot have same Registration Number");
                            cond = false;
                        }

                    }
                    foreach (Student s in stdlist)
                    {
                        if (s.Id.ToString() == selected_id)
                        {
                            std = s;
                        }
                    }
                    try
                    {
                        std.FirstName = txtSFname.Text;
                    }
                    catch (Exception)
                    {
                        cond = false;
                        MessageBox.Show("Invalid Syntax! Name should be in alphabets");
                        //name should only contain alphabets
                    }
                    try
                    {
                        std.LastName = txtSLname.Text;
                    }
                    catch (Exception)
                    {
                        cond = false;
                        MessageBox.Show("Invalid Syntax! Name should be in alphabets");
                        //name should only contain alphabets
                    }
                    try
                    {
                        std.Email = txtSemail.Text;
                    }
                    catch (Exception)
                    {
                        cond = false;
                        MessageBox.Show("Invalid Syntax! Email cannot contian spaces");
                        //spaces must not be present in email
                    }
                }

            }

            if (cond == true && selected_id == null) // It means Default Constructor is called and user wants to add the employee
            {
                std.FirstName = txtSFname.Text;
                std.LastName = txtSLname.Text;
                std.Contact = txtScontact.Text;
                std.Email = txtSemail.Text;
                std.RegistrationNo = txtSRno.Text;

                SqlDataReader status = DataConnection.get_instance().Getdata("SELECT * FROM Lookup");

                while (status.Read())
                {
                    if (status[1].ToString() == txtSStatus.Text)
                    {
                        std.Status = Convert.ToInt32(status[0]);
                        std.Statusid = status[1].ToString();
                    }
                }
                // inserting the Students in the database
                string cmd = string.Format("INSERT Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", std.FirstName, std.LastName, std.Contact, std.Email, std.RegistrationNo, std.Status);
               DataConnection.get_instance().Executequery(cmd);
               
                MessageBox.Show("Student Added Successfully");
                this.Hide();
                ViewStudent vs = new ViewStudent();
                vs.Show();

            }
                if (cond == true && selected_id != null) // It means Parameterised Constructor is called and user wants to Edit 
                {

                    std.FirstName = txtSFname.Text;
                    std.LastName = txtSLname.Text;
                    std.Contact = txtScontact.Text;
                    std.Email = txtSemail.Text;
                    std.RegistrationNo = txtSRno.Text;

                    //reading data from the table Lookup
                    SqlDataReader status = DataConnection.get_instance().Getdata("SELECT * FROM Lookup");

                    while (status.Read())
                    {
                        if (status[1].ToString() == txtSStatus.Text)
                        {
                            std.Status = Convert.ToInt32(status[0]);
                            std.Statusid = status[1].ToString();
                        }
                    }
                    //updating data from the Student table
                    string cmd = string.Format("UPDATE Student SET FirstName='{0}',LastName='{1}',Contact='{2}',Email='{3}',RegistrationNumber='{4}',Status='{5}' WHERE Id='{6}'", std.FirstName, std.LastName, std.Contact.ToString(), std.Email, std.RegistrationNo, std.Status, selected_id);
                    DataConnection.get_instance().Executequery(cmd);

                    MessageBox.Show("Student Edited Successfully!");
                    this.Hide();
                    ViewStudent vs = new ViewStudent();
                    vs.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStudent_Load(object sender, EventArgs e)
        {
           
            if (selected_id != null)
            {
                //readin data from Student table
                SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Student"));
                while (data.Read())
                {
                    Student std = new Student();
                    std.Id = Convert.ToInt32(data.GetValue(0));
                    if (std.Id == Convert.ToInt32(selected_id))
                    {
                        txtSFname.Text = data.GetString(1);
                        txtSLname.Text= data.GetString(2);
                        txtScontact.Text= data.GetString(3);
                        txtSemail.Text= data.GetString(4);
                        txtSRno.Text= data.GetString(5);
                        if (data.GetValue(6).ToString() == "5")
                        {
                            txtSStatus.Text = "Active";
                        }
                        else
                        {
                            txtSStatus.Text = "InActive";
                        }
                    }
                }
            }
           
        }

        /// <summary>
        ///showing student list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ViewStudent frm = new ViewStudent();
            this.Hide();
            frm.Show();
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
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
        ///showing Rubric list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            ViewRubric r = new ViewRubric();
            this.Hide();
            r.Show();
            
        }

        /// <summary>
        ///showing Rubric Level list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
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
        private void button5_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
            
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
