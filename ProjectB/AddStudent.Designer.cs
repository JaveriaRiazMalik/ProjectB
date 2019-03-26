namespace ProjectB
{
    partial class AddStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSemail = new System.Windows.Forms.TextBox();
            this.txtSLname = new System.Windows.Forms.TextBox();
            this.txtScontact = new System.Windows.Forms.TextBox();
            this.txtSRno = new System.Windows.Forms.TextBox();
            this.txtSFname = new System.Windows.Forms.TextBox();
            this.txtSStatus = new System.Windows.Forms.ComboBox();
            this.btnRegisterS = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(108, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 59);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage Student";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(3, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(366, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Students";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.98174F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.21004F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.65601F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(657, 81);
            this.tableLayoutPanel2.TabIndex = 5;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.52061F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.47939F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(657, 384);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.txtSemail, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtSLname, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtScontact, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtSRno, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtSFname, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSStatus, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.btnRegisterS, 0, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.42441F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.14702F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(273, 378);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // txtSemail
            // 
            this.txtSemail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSemail.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSemail.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSemail.ForeColor = System.Drawing.Color.Silver;
            this.txtSemail.Location = new System.Drawing.Point(3, 163);
            this.txtSemail.Name = "txtSemail";
            this.txtSemail.Size = new System.Drawing.Size(267, 43);
            this.txtSemail.TabIndex = 9;
            this.txtSemail.Text = "Email";
            this.txtSemail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSLname
            // 
            this.txtSLname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSLname.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSLname.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSLname.ForeColor = System.Drawing.Color.Silver;
            this.txtSLname.Location = new System.Drawing.Point(3, 57);
            this.txtSLname.Name = "txtSLname";
            this.txtSLname.Size = new System.Drawing.Size(267, 43);
            this.txtSLname.TabIndex = 7;
            this.txtSLname.Text = "Last Name";
            this.txtSLname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtScontact
            // 
            this.txtScontact.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtScontact.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtScontact.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtScontact.ForeColor = System.Drawing.Color.Silver;
            this.txtScontact.Location = new System.Drawing.Point(3, 110);
            this.txtScontact.Name = "txtScontact";
            this.txtScontact.Size = new System.Drawing.Size(267, 43);
            this.txtScontact.TabIndex = 8;
            this.txtScontact.Text = "Contact";
            this.txtScontact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSRno
            // 
            this.txtSRno.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSRno.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSRno.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSRno.ForeColor = System.Drawing.Color.Silver;
            this.txtSRno.Location = new System.Drawing.Point(3, 216);
            this.txtSRno.Name = "txtSRno";
            this.txtSRno.Size = new System.Drawing.Size(267, 43);
            this.txtSRno.TabIndex = 10;
            this.txtSRno.Text = "Registration No";
            this.txtSRno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSFname
            // 
            this.txtSFname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSFname.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSFname.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSFname.ForeColor = System.Drawing.Color.Silver;
            this.txtSFname.Location = new System.Drawing.Point(3, 3);
            this.txtSFname.Name = "txtSFname";
            this.txtSFname.Size = new System.Drawing.Size(267, 43);
            this.txtSFname.TabIndex = 6;
            this.txtSFname.Text = "First Name";
            this.txtSFname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSStatus
            // 
            this.txtSStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSStatus.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSStatus.ForeColor = System.Drawing.Color.Silver;
            this.txtSStatus.FormattingEnabled = true;
            this.txtSStatus.Items.AddRange(new object[] {
            "Active",
            "InActive"});
            this.txtSStatus.Location = new System.Drawing.Point(3, 269);
            this.txtSStatus.Name = "txtSStatus";
            this.txtSStatus.Size = new System.Drawing.Size(267, 43);
            this.txtSStatus.TabIndex = 11;
            this.txtSStatus.Text = "           Status";
            // 
            // btnRegisterS
            // 
            this.btnRegisterS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.btnRegisterS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegisterS.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.btnRegisterS.ForeColor = System.Drawing.Color.Transparent;
            this.btnRegisterS.Location = new System.Drawing.Point(3, 322);
            this.btnRegisterS.Name = "btnRegisterS";
            this.btnRegisterS.Size = new System.Drawing.Size(267, 48);
            this.btnRegisterS.TabIndex = 2;
            this.btnRegisterS.Text = "Save";
            this.btnRegisterS.UseVisualStyleBackColor = false;
            this.btnRegisterS.Click += new System.EventHandler(this.btnRegisterS_Click_1);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button4, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.button3, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.button2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.button5, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.button6, 0, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(282, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.04318F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.52743F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(372, 378);
            this.tableLayoutPanel4.TabIndex = 3;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(3, 322);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(366, 48);
            this.button5.TabIndex = 6;
            this.button5.Text = "Main Screen";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(366, 42);
            this.label2.TabIndex = 4;
            this.label2.Text = "View";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(3, 216);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(366, 47);
            this.button4.TabIndex = 5;
            this.button4.Text = "Levels";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(3, 163);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(366, 47);
            this.button3.TabIndex = 4;
            this.button3.Text = "Rubrics";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(3, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(366, 47);
            this.button2.TabIndex = 3;
            this.button2.Text = "CLOs";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.button6.ForeColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(3, 269);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(366, 47);
            this.button6.TabIndex = 7;
            this.button6.Text = "Assessment";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // AddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(657, 465);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "AddStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Student";
            this.Load += new System.EventHandler(this.AddStudent_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtSemail;
        private System.Windows.Forms.TextBox txtSLname;
        private System.Windows.Forms.TextBox txtScontact;
        private System.Windows.Forms.TextBox txtSRno;
        private System.Windows.Forms.TextBox txtSFname;
        private System.Windows.Forms.ComboBox txtSStatus;
        private System.Windows.Forms.Button btnRegisterS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

