namespace VP_PBE.Student
{
    partial class StudentDashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProfilecomboBox = new System.Windows.Forms.ComboBox();
            this.Logout_button = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.RepositorycomboBox = new System.Windows.Forms.ComboBox();
            this.Dashboardbutton = new System.Windows.Forms.Button();
            this.FypcomboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 287);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 33);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Student Dashboard";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.ProfilecomboBox);
            this.panel2.Controls.Add(this.Logout_button);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.RepositorycomboBox);
            this.panel2.Controls.Add(this.Dashboardbutton);
            this.panel2.Controls.Add(this.FypcomboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 333);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // ProfilecomboBox
            // 
            this.ProfilecomboBox.BackColor = System.Drawing.Color.DarkGray;
            this.ProfilecomboBox.FormattingEnabled = true;
            this.ProfilecomboBox.Items.AddRange(new object[] {
            "Update Information ",
            "View Project Status",
            "Submission Deadlines  "});
            this.ProfilecomboBox.Location = new System.Drawing.Point(12, 158);
            this.ProfilecomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProfilecomboBox.Name = "ProfilecomboBox";
            this.ProfilecomboBox.Size = new System.Drawing.Size(104, 21);
            this.ProfilecomboBox.TabIndex = 14;
            this.ProfilecomboBox.Text = "         Profile";
            this.ProfilecomboBox.SelectedIndexChanged += new System.EventHandler(this.ProfilecomboBox_SelectedIndexChanged);
            // 
            // Logout_button
            // 
            this.Logout_button.BackColor = System.Drawing.Color.DarkGray;
            this.Logout_button.Location = new System.Drawing.Point(12, 200);
            this.Logout_button.Margin = new System.Windows.Forms.Padding(2);
            this.Logout_button.Name = "Logout_button";
            this.Logout_button.Size = new System.Drawing.Size(103, 25);
            this.Logout_button.TabIndex = 1;
            this.Logout_button.Text = "Logout ";
            this.Logout_button.UseVisualStyleBackColor = false;
            this.Logout_button.Click += new System.EventHandler(this.Logout_button_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VP_PBE.Properties.Resources.Unisel_new2;
            this.pictureBox2.Location = new System.Drawing.Point(19, 295);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(106, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // RepositorycomboBox
            // 
            this.RepositorycomboBox.BackColor = System.Drawing.Color.DarkGray;
            this.RepositorycomboBox.FormattingEnabled = true;
            this.RepositorycomboBox.Items.AddRange(new object[] {
            "Lecture Materials",
            "Past Year Questions ",
            "Academic Records "});
            this.RepositorycomboBox.Location = new System.Drawing.Point(12, 114);
            this.RepositorycomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.RepositorycomboBox.Name = "RepositorycomboBox";
            this.RepositorycomboBox.Size = new System.Drawing.Size(104, 21);
            this.RepositorycomboBox.TabIndex = 4;
            this.RepositorycomboBox.Text = "      Repository ";
            this.RepositorycomboBox.SelectedIndexChanged += new System.EventHandler(this.RepositorycomboBox_SelectedIndexChanged);
            // 
            // Dashboardbutton
            // 
            this.Dashboardbutton.BackColor = System.Drawing.Color.DarkGray;
            this.Dashboardbutton.Location = new System.Drawing.Point(9, 28);
            this.Dashboardbutton.Margin = new System.Windows.Forms.Padding(2);
            this.Dashboardbutton.Name = "Dashboardbutton";
            this.Dashboardbutton.Size = new System.Drawing.Size(106, 24);
            this.Dashboardbutton.TabIndex = 0;
            this.Dashboardbutton.Text = "Dashboard ";
            this.Dashboardbutton.UseVisualStyleBackColor = false;
            this.Dashboardbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // FypcomboBox
            // 
            this.FypcomboBox.BackColor = System.Drawing.Color.DarkGray;
            this.FypcomboBox.FormattingEnabled = true;
            this.FypcomboBox.Items.AddRange(new object[] {
            "Browse Titles          ",
            "Submit Proposal       ",
            "Upload Documents                               ",
            "Supervisor Assignment                            "});
            this.FypcomboBox.Location = new System.Drawing.Point(12, 72);
            this.FypcomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.FypcomboBox.Name = "FypcomboBox";
            this.FypcomboBox.Size = new System.Drawing.Size(104, 21);
            this.FypcomboBox.TabIndex = 3;
            this.FypcomboBox.Text = "            FYP";
            this.FypcomboBox.SelectedIndexChanged += new System.EventHandler(this.FypcomboBox_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VP_PBE.Properties.Resources.Unisel_image41;
            this.pictureBox1.Location = new System.Drawing.Point(152, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 332);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StudentDashboard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Dashboardbutton;
        private System.Windows.Forms.ComboBox FypcomboBox;
        private System.Windows.Forms.ComboBox RepositorycomboBox;
        private System.Windows.Forms.Button Logout_button;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox ProfilecomboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

