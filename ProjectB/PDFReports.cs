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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ProjectB
{
    public partial class PDFReports : Form
    {
        public PDFReports()
        {
            InitializeComponent();
        }

        public void exportgridtopdf(DataGridView dg, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dg.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //Add header
            foreach(DataGridViewColumn column in dg.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            //Add datarow
            foreach(DataGridViewRow row in dg.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialogue = new SaveFileDialog();
            savefiledialogue.FileName = filename;
            savefiledialogue.DefaultExt = ".pdf";

            if(savefiledialogue.ShowDialog()==DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialogue.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PDFReports_Load(object sender, EventArgs e)
        {
            

            //reading data from Assessment table
            SqlDataReader dataAC = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Assessment"));

            //binding the assessments
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Load(dataAC);


            comboAc.ValueMember = "Id";
            comboAc.DisplayMember = "Title";
            comboAc.DataSource = dt;

            comboAc.Text = "Assessments";

            //reading data from CLO table
            SqlDataReader dataC = DataConnection.get_instance().Getdata(string.Format("SELECT * FROM Clo"));

            //binding the CLOs
            DataTable dC = new DataTable();
            dC.Columns.Add("Id", typeof(string));
            dC.Columns.Add("Name", typeof(string));
            dC.Load(dataC);


            comboClo.ValueMember = "Id";
            comboClo.DisplayMember = "Name";
            comboClo.DataSource = dC;

            comboClo.Text = "CLOs";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Main a = new Main();
            this.Hide();
            a.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                //reading data from Assessment table
                SqlDataReader dataS = DataConnection.get_instance().Getdata("SELECT * FROM Assessment");
                while (dataS.Read())
                {
                    if (dataS.GetString(1) == comboAc.Text)
                    {
                        id = Convert.ToInt32(dataS.GetValue(0));

                    }
                }

                SqlDataReader adapter = DataConnection.get_instance().Getdata(string.Format("SELECT Student.RegistrationNumber as RegNo, CONCAT(Student.FirstName,' ',Student.LastName) as Name, AssessmentComponent.Name as Component, AssessmentComponent.TotalMarks as TotalMarks, RubricLevel.MeasurementLevel as MeasurementLevel, ((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) As ObtainedMarks  FROM Student JOIN StudentResult ON Student.Id = StudentResult.StudentId JOIN AssessmentComponent ON StudentResult.AssessmentComponentId = AssessmentComponent.Id JOIN RubricLevel ON StudentResult.RubricMeasurementId = RubricLevel.Id WHERE AssessmentComponent.AssessmentId='{0}'", id));
                BindingSource S = new BindingSource();
                S.DataSource = adapter;
                dataGridView1.DataSource = S;


                exportgridtopdf(dataGridView1, comboAc.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboAc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        static int id;
        private void comboAc_DropDownClosed(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        static int idclo;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //reading data from CLO table
                SqlDataReader dataS = DataConnection.get_instance().Getdata("SELECT * FROM Clo");
                while (dataS.Read())
                {
                    if (dataS.GetString(1) == comboClo.Text)
                    {
                        idclo = Convert.ToInt32(dataS.GetValue(0));

                    }
                }

                SqlDataReader adapter = DataConnection.get_instance().Getdata(string.Format("SELECT Student.RegistrationNumber as RegNo, CONCAT(Student.FirstName,' ',Student.LastName) as Name, AssessmentComponent.Name as Component,Rubric.Details as RubricDetails, AssessmentComponent.TotalMarks as TotalMarks, RubricLevel.MeasurementLevel as MeasurementLevel, ((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) As ObtainedMarks  FROM Student JOIN StudentResult ON Student.Id = StudentResult.StudentId JOIN AssessmentComponent ON StudentResult.AssessmentComponentId = AssessmentComponent.Id JOIN RubricLevel ON StudentResult.RubricMeasurementId = RubricLevel.Id JOIN Rubric ON RubricLevel.RubricId = Rubric.Id WHERE Rubric.CloId='{0}'", idclo));
                BindingSource S = new BindingSource();
                S.DataSource = adapter;
                dataGridView1.DataSource = S;


                exportgridtopdf(dataGridView1, comboClo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
