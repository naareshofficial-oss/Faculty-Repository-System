namespace VP_PBE.Student
{
    partial class UploadProjectDocument
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
            this.Dashboard_button = new System.Windows.Forms.Button();
            this.Logout_button = new System.Windows.Forms.Button();
            this.FypcomboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.RepositorycomboBox = new System.Windows.Forms.ComboBox();
            this.DocumentName_label = new System.Windows.Forms.Label();
            this.DocumnetName_textBox = new System.Windows.Forms.TextBox();
            this.DocumentDescription_label = new System.Windows.Forms.Label();
            this.DocumentDescription_textBox = new System.Windows.Forms.TextBox();
            this.Upload_label = new System.Windows.Forms.Label();
            this.ChooseFile_button = new System.Windows.Forms.Button();
            this.Upload_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblFileName = new System.Windows.Forms.Label();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 32);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "UPLOAD PROJECT DOCUMENT";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.ProfilecomboBox);
            this.panel2.Controls.Add(this.Dashboard_button);
            this.panel2.Controls.Add(this.Logout_button);
            this.panel2.Controls.Add(this.FypcomboBox);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.RepositorycomboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(160, 334);
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
            this.ProfilecomboBox.Location = new System.Drawing.Point(21, 150);
            this.ProfilecomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProfilecomboBox.Name = "ProfilecomboBox";
            this.ProfilecomboBox.Size = new System.Drawing.Size(104, 21);
            this.ProfilecomboBox.TabIndex = 20;
            this.ProfilecomboBox.Text = "         Profile";
            // 
            // Dashboard_button
            // 
            this.Dashboard_button.BackColor = System.Drawing.Color.DarkGray;
            this.Dashboard_button.Location = new System.Drawing.Point(18, 19);
            this.Dashboard_button.Margin = new System.Windows.Forms.Padding(2);
            this.Dashboard_button.Name = "Dashboard_button";
            this.Dashboard_button.Size = new System.Drawing.Size(106, 24);
            this.Dashboard_button.TabIndex = 15;
            this.Dashboard_button.Text = "Dashboard ";
            this.Dashboard_button.UseVisualStyleBackColor = false;
            this.Dashboard_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Logout_button
            // 
            this.Logout_button.BackColor = System.Drawing.Color.DarkGray;
            this.Logout_button.Location = new System.Drawing.Point(21, 191);
            this.Logout_button.Margin = new System.Windows.Forms.Padding(2);
            this.Logout_button.Name = "Logout_button";
            this.Logout_button.Size = new System.Drawing.Size(103, 25);
            this.Logout_button.TabIndex = 16;
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
            this.FypcomboBox.Location = new System.Drawing.Point(21, 63);
            this.FypcomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.FypcomboBox.Name = "FypcomboBox";
            this.FypcomboBox.Size = new System.Drawing.Size(104, 21);
            this.FypcomboBox.TabIndex = 17;
            this.FypcomboBox.Text = "            FYP";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VP_PBE.Properties.Resources.Unisel_new2;
            this.pictureBox2.Location = new System.Drawing.Point(21, 280);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(106, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
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
            this.RepositorycomboBox.Location = new System.Drawing.Point(21, 105);
            this.RepositorycomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.RepositorycomboBox.Name = "RepositorycomboBox";
            this.RepositorycomboBox.Size = new System.Drawing.Size(104, 21);
            this.RepositorycomboBox.TabIndex = 18;
            this.RepositorycomboBox.Text = "      Repository ";
            // 
            // DocumentName_label
            // 
            this.DocumentName_label.AutoSize = true;
            this.DocumentName_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentName_label.Location = new System.Drawing.Point(204, 117);
            this.DocumentName_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DocumentName_label.Name = "DocumentName_label";
            this.DocumentName_label.Size = new System.Drawing.Size(113, 17);
            this.DocumentName_label.TabIndex = 2;
            this.DocumentName_label.Text = "Document Name";
            // 
            // DocumnetName_textBox
            // 
            this.DocumnetName_textBox.Location = new System.Drawing.Point(352, 115);
            this.DocumnetName_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.DocumnetName_textBox.Name = "DocumnetName_textBox";
            this.DocumnetName_textBox.Size = new System.Drawing.Size(152, 20);
            this.DocumnetName_textBox.TabIndex = 3;
            this.DocumnetName_textBox.TextChanged += new System.EventHandler(this.DocumnetName_textBox_TextChanged);
            // 
            // DocumentDescription_label
            // 
            this.DocumentDescription_label.AutoSize = true;
            this.DocumentDescription_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentDescription_label.Location = new System.Drawing.Point(204, 166);
            this.DocumentDescription_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DocumentDescription_label.Name = "DocumentDescription_label";
            this.DocumentDescription_label.Size = new System.Drawing.Size(147, 17);
            this.DocumentDescription_label.TabIndex = 4;
            this.DocumentDescription_label.Text = "Document Description";
            // 
            // DocumentDescription_textBox
            // 
            this.DocumentDescription_textBox.Location = new System.Drawing.Point(352, 166);
            this.DocumentDescription_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.DocumentDescription_textBox.Name = "DocumentDescription_textBox";
            this.DocumentDescription_textBox.Size = new System.Drawing.Size(152, 20);
            this.DocumentDescription_textBox.TabIndex = 5;
            this.DocumentDescription_textBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Upload_label
            // 
            this.Upload_label.AutoSize = true;
            this.Upload_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Upload_label.Location = new System.Drawing.Point(204, 218);
            this.Upload_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Upload_label.Name = "Upload_label";
            this.Upload_label.Size = new System.Drawing.Size(79, 17);
            this.Upload_label.TabIndex = 6;
            this.Upload_label.Text = "Upload File";
            // 
            // ChooseFile_button
            // 
            this.ChooseFile_button.Location = new System.Drawing.Point(386, 218);
            this.ChooseFile_button.Margin = new System.Windows.Forms.Padding(2);
            this.ChooseFile_button.Name = "ChooseFile_button";
            this.ChooseFile_button.Size = new System.Drawing.Size(83, 19);
            this.ChooseFile_button.TabIndex = 7;
            this.ChooseFile_button.Text = "CHOOSE FILE";
            this.ChooseFile_button.UseVisualStyleBackColor = true;
            this.ChooseFile_button.Click += new System.EventHandler(this.ChooseFile_button_Click);
            // 
            // Upload_button
            // 
            this.Upload_button.Location = new System.Drawing.Point(336, 304);
            this.Upload_button.Margin = new System.Windows.Forms.Padding(2);
            this.Upload_button.Name = "Upload_button";
            this.Upload_button.Size = new System.Drawing.Size(68, 24);
            this.Upload_button.TabIndex = 8;
            this.Upload_button.Text = "Upload ";
            this.Upload_button.UseVisualStyleBackColor = true;
            this.Upload_button.Click += new System.EventHandler(this.Upload_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(383, 255);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(79, 13);
            this.lblFileName.TabIndex = 9;
            this.lblFileName.Text = "No Chosen File";
            // 
            // UploadProjectDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.Upload_button);
            this.Controls.Add(this.ChooseFile_button);
            this.Controls.Add(this.Upload_label);
            this.Controls.Add(this.DocumentDescription_textBox);
            this.Controls.Add(this.DocumentDescription_label);
            this.Controls.Add(this.DocumnetName_textBox);
            this.Controls.Add(this.DocumentName_label);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UploadProjectDocument";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.UploadProjectDocument_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProfilecomboBox;
        private System.Windows.Forms.Button Dashboard_button;
        private System.Windows.Forms.Button Logout_button;
        private System.Windows.Forms.ComboBox FypcomboBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox RepositorycomboBox;
        private System.Windows.Forms.Label DocumentName_label;
        private System.Windows.Forms.TextBox DocumnetName_textBox;
        private System.Windows.Forms.Label DocumentDescription_label;
        private System.Windows.Forms.TextBox DocumentDescription_textBox;
        private System.Windows.Forms.Label Upload_label;
        private System.Windows.Forms.Button ChooseFile_button;
        private System.Windows.Forms.Button Upload_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblFileName;
    }
}