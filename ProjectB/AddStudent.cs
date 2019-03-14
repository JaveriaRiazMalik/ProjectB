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

        private void btnRegisterS_Click_1(object sender, EventArgs e)
        {

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
                stdlist.Add(st);
            }
            Student std = new Student();
            bool cond = true;
            if (txtSFname.Text == "" || txtSLname.Text == "" || txtScontact.Text == "" || txtSemail.Text == "" || txtSRno.Text == "" || txtSStatus.Text == "")
            {
                MessageBox.Show("Enter all the entries in their respective boxes");
                cond = false;
            }
            else
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
                }
                try
                {
                    std.LastName = txtSLname.Text;
                }
                catch (Exception)
                {
                    cond = false;
                    MessageBox.Show("Invalid Syntax! Name should be in alphabets");
                }
                try
                {
                    std.Email = txtSemail.Text;
                }
                catch (Exception)
                {
                    cond = false;
                    MessageBox.Show("Invalid Syntax! Email cannot contian spaces");
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
                    }
                }

                string cmd = string.Format("INSERT Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", std.FirstName, std.LastName, std.Contact, std.Email, std.RegistrationNo, std.Status);
                int rows = DataConnection.get_instance().Executequery(cmd);
                MessageBox.Show(String.Format("{0} rows affected", rows));
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

                SqlDataReader status = DataConnection.get_instance().Getdata("SELECT * FROM Lookup");

                while (status.Read())
                {
                    if (status[1].ToString() == txtSStatus.Text)
                    {
                        std.Status = Convert.ToInt32(status[0]);
                    }
                }

                string cmd = string.Format("UPDATE Student SET FirstName='{0}',LastName='{1}',Contact='{2}',Email='{3}',RegistrationNumber='{4}',Status='{5}' WHERE Id='{6}'", std.FirstName, std.LastName, std.Contact.ToString(), std.Email, std.RegistrationNo, std.Status,selected_id);
                int rows = DataConnection.get_instance().Executequery(cmd);
                MessageBox.Show(String.Format("{0} rows affected", rows));
                MessageBox.Show("Student Edited Successfully!");
                this.Hide();
                ViewStudent vs = new ViewStudent();
                vs.Show();
               

            }
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
           
            if (selected_id != null)
            {
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
        private void button1_Click(object sender, EventArgs e)
        {
            ViewStudent frm = new ViewStudent();
            this.Hide();
            frm.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewCLOS c = new ViewCLOS();
            this.Hide();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewRubric r = new ViewRubric();
            this.Hide();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewLevel l = new ViewLevel();
            this.Hide();
            l.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }
    }
}
