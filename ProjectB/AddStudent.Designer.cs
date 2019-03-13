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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSemail = new System.Windows.Forms.TextBox();
            this.txtSFname = new System.Windows.Forms.TextBox();
            this.txtSStatus = new System.Windows.Forms.ComboBox();
            this.txtSLname = new System.Windows.Forms.TextBox();
            this.txtScontact = new System.Windows.Forms.TextBox();
            this.txtSRno = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegisterS = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtSemail, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSFname, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSStatus, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtSLname, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtScontact, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSRno, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(38, 126);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.9854F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.0146F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 387);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // txtSemail
            // 
            this.txtSemail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSemail.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSemail.ForeColor = System.Drawing.Color.Silver;
            this.txtSemail.Location = new System.Drawing.Point(3, 206);
            this.txtSemail.Name = "txtSemail";
            this.txtSemail.Size = new System.Drawing.Size(329, 43);
            this.txtSemail.TabIndex = 9;
            this.txtSemail.Text = "Email";
            this.txtSemail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSFname
            // 
            this.txtSFname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSFname.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSFname.ForeColor = System.Drawing.Color.Silver;
            this.txtSFname.Location = new System.Drawing.Point(3, 3);
            this.txtSFname.Name = "txtSFname";
            this.txtSFname.Size = new System.Drawing.Size(329, 43);
            this.txtSFname.TabIndex = 6;
            this.txtSFname.Text = "First Name";
            this.txtSFname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSFname.TextChanged += new System.EventHandler(this.txtSFname_TextChanged);
            // 
            // txtSStatus
            // 
            this.txtSStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSStatus.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSStatus.ForeColor = System.Drawing.Color.Silver;
            this.txtSStatus.FormattingEnabled = true;
            this.txtSStatus.Items.AddRange(new object[] {
            "Active",
            "InActive"});
            this.txtSStatus.Location = new System.Drawing.Point(3, 332);
            this.txtSStatus.Name = "txtSStatus";
            this.txtSStatus.Size = new System.Drawing.Size(329, 43);
            this.txtSStatus.TabIndex = 11;
            this.txtSStatus.Text = "           Status";
            // 
            // txtSLname
            // 
            this.txtSLname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSLname.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSLname.ForeColor = System.Drawing.Color.Silver;
            this.txtSLname.Location = new System.Drawing.Point(3, 62);
            this.txtSLname.Name = "txtSLname";
            this.txtSLname.Size = new System.Drawing.Size(329, 43);
            this.txtSLname.TabIndex = 7;
            this.txtSLname.Text = "Last Name";
            this.txtSLname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSLname.TextChanged += new System.EventHandler(this.txtSLname_TextChanged);
            // 
            // txtScontact
            // 
            this.txtScontact.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtScontact.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtScontact.ForeColor = System.Drawing.Color.Silver;
            this.txtScontact.Location = new System.Drawing.Point(3, 132);
            this.txtScontact.Name = "txtScontact";
            this.txtScontact.Size = new System.Drawing.Size(329, 43);
            this.txtScontact.TabIndex = 8;
            this.txtScontact.Text = "Contact";
            this.txtScontact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSRno
            // 
            this.txtSRno.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSRno.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.txtSRno.ForeColor = System.Drawing.Color.Silver;
            this.txtSRno.Location = new System.Drawing.Point(3, 271);
            this.txtSRno.Name = "txtSRno";
            this.txtSRno.Size = new System.Drawing.Size(329, 43);
            this.txtSRno.TabIndex = 10;
            this.txtSRno.Text = "Registration No";
            this.txtSRno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRegisterS);
            this.panel1.Location = new System.Drawing.Point(38, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 49);
            this.panel1.TabIndex = 3;
            // 
            // btnRegisterS
            // 
            this.btnRegisterS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.btnRegisterS.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.btnRegisterS.ForeColor = System.Drawing.Color.Transparent;
            this.btnRegisterS.Location = new System.Drawing.Point(0, 0);
            this.btnRegisterS.Name = "btnRegisterS";
            this.btnRegisterS.Size = new System.Drawing.Size(153, 48);
            this.btnRegisterS.TabIndex = 2;
            this.btnRegisterS.Text = "Save";
            this.btnRegisterS.UseVisualStyleBackColor = false;
            this.btnRegisterS.Click += new System.EventHandler(this.btnRegisterS_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(38, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 97);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 59);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage Student";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(283, 520);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(211, 49);
            this.panel3.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(152)))), ((int)(((byte)(220)))));
            this.button1.Font = new System.Drawing.Font("Verdana", 21.75F);
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(3, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "View List";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(526, 592);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Student";
            this.Load += new System.EventHandler(this.AddStudent_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtSRno;
        private System.Windows.Forms.TextBox txtSemail;
        private System.Windows.Forms.TextBox txtScontact;
        private System.Windows.Forms.TextBox txtSLname;
        private System.Windows.Forms.TextBox txtSFname;
        private System.Windows.Forms.ComboBox txtSStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegisterS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
    }
}

