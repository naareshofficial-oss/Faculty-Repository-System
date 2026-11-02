namespace VP_PBE.Student
{
    partial class Approval
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProfilecomboBox = new System.Windows.Forms.ComboBox();
            this.Dasboard_button = new System.Windows.Forms.Button();
            this.Logout_button = new System.Windows.Forms.Button();
            this.FypcomboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.RepositorycomboBox = new System.Windows.Forms.ComboBox();
            this.SearchFypTitle_label = new System.Windows.Forms.Label();
            this.SearchFypTitle_textBox = new System.Windows.Forms.TextBox();
            this.SelectYear_label = new System.Windows.Forms.Label();
            this.SelectYearcomboBox = new System.Windows.Forms.ComboBox();
            this.Faculty_label = new System.Windows.Forms.Label();
            this.ChooseHere_comboBox = new System.Windows.Forms.ComboBox();
            this.Submit_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 38);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "SEARCH FYP TITLE ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.ProfilecomboBox);
            this.panel2.Controls.Add(this.Dasboard_button);
            this.panel2.Controls.Add(this.Logout_button);
            this.panel2.Controls.Add(this.FypcomboBox);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.RepositorycomboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 328);
            this.panel2.TabIndex = 1;
            // 
            // ProfilecomboBox
            // 
            this.ProfilecomboBox.BackColor = System.Drawing.Color.DarkGray;
            this.ProfilecomboBox.FormattingEnabled = true;
            this.ProfilecomboBox.Items.AddRange(new object[] {
            "Update Information ",
            "View Project Status",
            "Submission Deadlines  "});
            this.ProfilecomboBox.Location = new System.Drawing.Point(20, 145);
            this.ProfilecomboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProfilecomboBox.Name = "ProfilecomboBox";
            this.ProfilecomboBox.Size = new System.Drawing.Size(104, 21);
            this.ProfilecomboBox.TabIndex = 26;
            this.ProfilecomboBox.Text = "         Profile";
            // 
            // Dasboard_button
            // 
            this.Dasboard_button.BackColor = System.Drawing.Color.DarkGray;
            this.Dasboard_button.Location = new System.Drawing.Point(17, 14);
            this.Dasboard_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dasboard_button.Name = "Dasboard_button";
            this.Dasboard_button.Size = new System.Drawing.Size(106, 24);
            this.Dasboard_button.TabIndex = 21;
            this.Dasboard_button.Text = "Dashboard ";
            this.Dasboard_button.UseVisualStyleBackColor = false;
            this.Dasboard_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Logout_button
            // 
            this.Logout_button.BackColor = System.Drawing.Color.DarkGray;
            this.Logout_button.Location = new System.Drawing.Point(20, 186);
            this.Logout_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Logout_button.Name = "Logout_button";
            this.Logout_button.Size = new System.Drawing.Size(103, 25);
            this.Logout_button.TabIndex = 22;
            this.Logout_button.Text = "Logout ";
            this.Logout_button.UseVisualStyleBackColor = false;
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
            this.FypcomboBox.Location = new System.Drawing.Point(20, 58);
            this.FypcomboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FypcomboBox.Name = "FypcomboBox";
            this.FypcomboBox.Size = new System.Drawing.Size(104, 21);
            this.FypcomboBox.TabIndex = 23;
            this.FypcomboBox.Text = "            FYP";
            this.FypcomboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VP_PBE.Properties.Resources.Unisel_new2;
            this.pictureBox2.Location = new System.Drawing.Point(16, 273);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(106, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 25;
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
            this.RepositorycomboBox.Location = new System.Drawing.Point(20, 100);
            this.RepositorycomboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RepositorycomboBox.Name = "RepositorycomboBox";
            this.RepositorycomboBox.Size = new System.Drawing.Size(104, 21);
            this.RepositorycomboBox.TabIndex = 24;
            this.RepositorycomboBox.Text = "      Repository ";
            // 
            // SearchFypTitle_label
            // 
            this.SearchFypTitle_label.AutoSize = true;
            this.SearchFypTitle_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchFypTitle_label.Location = new System.Drawing.Point(200, 125);
            this.SearchFypTitle_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SearchFypTitle_label.Name = "SearchFypTitle_label";
            this.SearchFypTitle_label.Size = new System.Drawing.Size(111, 17);
            this.SearchFypTitle_label.TabIndex = 2;
            this.SearchFypTitle_label.Text = "Search Fyp Title";
            // 
            // SearchFypTitle_textBox
            // 
            this.SearchFypTitle_textBox.Location = new System.Drawing.Point(315, 125);
            this.SearchFypTitle_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchFypTitle_textBox.Name = "SearchFypTitle_textBox";
            this.SearchFypTitle_textBox.Size = new System.Drawing.Size(134, 20);
            this.SearchFypTitle_textBox.TabIndex = 3;
            this.SearchFypTitle_textBox.TextChanged += new System.EventHandler(this.SearchFypTitle_textBox_TextChanged);
            // 
            // SelectYear_label
            // 
            this.SelectYear_label.AutoSize = true;
            this.SelectYear_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectYear_label.Location = new System.Drawing.Point(200, 162);
            this.SelectYear_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SelectYear_label.Name = "SelectYear_label";
            this.SelectYear_label.Size = new System.Drawing.Size(81, 17);
            this.SelectYear_label.TabIndex = 4;
            this.SelectYear_label.Text = "Select Year";
            // 
            // SelectYearcomboBox
            // 
            this.SelectYearcomboBox.FormattingEnabled = true;
            this.SelectYearcomboBox.Items.AddRange(new object[] {
            "Year 1",
            "Year 2",
            "Year 3",
            "Year 4"});
            this.SelectYearcomboBox.Location = new System.Drawing.Point(315, 162);
            this.SelectYearcomboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SelectYearcomboBox.Name = "SelectYearcomboBox";
            this.SelectYearcomboBox.Size = new System.Drawing.Size(134, 21);
            this.SelectYearcomboBox.TabIndex = 5;
            this.SelectYearcomboBox.Text = " Year";
            // 
            // Faculty_label
            // 
            this.Faculty_label.AutoSize = true;
            this.Faculty_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Faculty_label.Location = new System.Drawing.Point(200, 199);
            this.Faculty_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Faculty_label.Name = "Faculty_label";
            this.Faculty_label.Size = new System.Drawing.Size(53, 17);
            this.Faculty_label.TabIndex = 6;
            this.Faculty_label.Text = "Faculty";
            // 
            // ChooseHere_comboBox
            // 
            this.ChooseHere_comboBox.FormattingEnabled = true;
            this.ChooseHere_comboBox.Items.AddRange(new object[] {
            "FCVAC",
            "FELS",
            "FBA",
            "FSK",
            "FESS"});
            this.ChooseHere_comboBox.Location = new System.Drawing.Point(315, 199);
            this.ChooseHere_comboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChooseHere_comboBox.Name = "ChooseHere_comboBox";
            this.ChooseHere_comboBox.Size = new System.Drawing.Size(134, 21);
            this.ChooseHere_comboBox.TabIndex = 7;
            this.ChooseHere_comboBox.Text = " Choose Here";
            // 
            // Submit_button
            // 
            this.Submit_button.Location = new System.Drawing.Point(304, 280);
            this.Submit_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Submit_button.Name = "Submit_button";
            this.Submit_button.Size = new System.Drawing.Size(73, 25);
            this.Submit_button.TabIndex = 8;
            this.Submit_button.Text = "Submit";
            this.Submit_button.UseVisualStyleBackColor = true;
            this.Submit_button.Click += new System.EventHandler(this.Submit_button_Click);
            // 
            // Approval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Submit_button);
            this.Controls.Add(this.ChooseHere_comboBox);
            this.Controls.Add(this.Faculty_label);
            this.Controls.Add(this.SelectYearcomboBox);
            this.Controls.Add(this.SelectYear_label);
            this.Controls.Add(this.SearchFypTitle_textBox);
            this.Controls.Add(this.SearchFypTitle_label);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Approval";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Approval_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ProfilecomboBox;
        private System.Windows.Forms.Button Dasboard_button;
        private System.Windows.Forms.Button Logout_button;
        private System.Windows.Forms.ComboBox FypcomboBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox RepositorycomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SearchFypTitle_label;
        private System.Windows.Forms.TextBox SearchFypTitle_textBox;
        private System.Windows.Forms.Label SelectYear_label;
        private System.Windows.Forms.ComboBox SelectYearcomboBox;
        private System.Windows.Forms.Label Faculty_label;
        private System.Windows.Forms.ComboBox ChooseHere_comboBox;
        private System.Windows.Forms.Button Submit_button;
    }
}