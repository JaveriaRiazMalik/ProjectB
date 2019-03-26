﻿using System;
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
    public partial class ViewAssessment : Form
    {
        public ViewAssessment()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            AddStudent s = new AddStudent();
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCLO c = new AddCLO();
            this.Hide();
             c.Show();

        }

        private void btnRegisterS_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }

        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit button
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow selected = view.Rows[e.RowIndex];
                string id = selected.Cells[2].Value.ToString();
                this.Hide();
                AddAssesment fr = new AddAssesment(id);
                fr.Show();
            }
            //delete button
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow selected = view.Rows[e.RowIndex];
                string id = selected.Cells[2].Value.ToString();
                MessageBox.Show("Are you sure you want to delete?");

                //deletes data from from Rubric Level
                string cmd = string.Format("DELETE FROM Assessment WHERE Id='{0}'", id);
                DataConnection.get_instance().Executequery(cmd);

                MessageBox.Show("Assessment Deleted");
                ViewAssessment frm = new ViewAssessment();
                this.Hide();
                frm.Show();
            }
        }

        private void ViewAssessment_Load(object sender, EventArgs e)
        {
            SqlDataReader data = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Assessment"));
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
            BindingSource S = new BindingSource();
            S.DataSource = list;
            view.DataSource = S;

            view.Columns["Edit"].DisplayIndex = view.ColumnCount - 1;
            view.Columns["Delete"].DisplayIndex = view.ColumnCount - 1;
            view.Columns["AssessmentComponent"].DisplayIndex = view.ColumnCount - 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAssesment a = new AddAssesment();
            this.Hide();
            a.Show();
        }
    }
}