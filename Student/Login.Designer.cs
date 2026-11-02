namespace VP_PBE.Student
{
    partial class Form3
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Email_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.Email_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.Login_Button = new System.Windows.Forms.Button();
            this.Role_label = new System.Windows.Forms.Label();
            this.Role_comboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 366);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VP_PBE.Properties.Resources.picture;
            this.pictureBox1.Location = new System.Drawing.Point(0, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(305, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOGIN";
            // 
            // Email_label
            // 
            this.Email_label.AutoSize = true;
            this.Email_label.Location = new System.Drawing.Point(210, 142);
            this.Email_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Email_label.Name = "Email_label";
            this.Email_label.Size = new System.Drawing.Size(32, 13);
            this.Email_label.TabIndex = 2;
            this.Email_label.Text = "Email";
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(210, 190);
            this.Password_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(53, 13);
            this.Password_label.TabIndex = 3;
            this.Password_label.Text = "Password";
            // 
            // Email_textBox
            // 
            this.Email_textBox.Location = new System.Drawing.Point(287, 142);
            this.Email_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.Email_textBox.Name = "Email_textBox";
            this.Email_textBox.Size = new System.Drawing.Size(128, 20);
            this.Email_textBox.TabIndex = 4;
            this.Email_textBox.TextChanged += new System.EventHandler(this.Email_textBox_TextChanged);
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(287, 185);
            this.Password_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.Size = new System.Drawing.Size(128, 20);
            this.Password_textBox.TabIndex = 5;
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(310, 309);
            this.Login_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(75, 26);
            this.Login_Button.TabIndex = 6;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // Role_label
            // 
            this.Role_label.AutoSize = true;
            this.Role_label.Location = new System.Drawing.Point(210, 232);
            this.Role_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Role_label.Name = "Role_label";
            this.Role_label.Size = new System.Drawing.Size(29, 13);
            this.Role_label.TabIndex = 7;
            this.Role_label.Text = "Role";
            // 
            // Role_comboBox
            // 
            this.Role_comboBox.FormattingEnabled = true;
            this.Role_comboBox.Items.AddRange(new object[] {
            "Student ",
            "Lecturer",
            "Admin"});
            this.Role_comboBox.Location = new System.Drawing.Point(287, 230);
            this.Role_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.Role_comboBox.Name = "Role_comboBox";
            this.Role_comboBox.Size = new System.Drawing.Size(128, 21);
            this.Role_comboBox.TabIndex = 8;
            this.Role_comboBox.SelectedIndexChanged += new System.EventHandler(this.Role_comboBox_SelectedIndexChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Role_comboBox);
            this.Controls.Add(this.Role_label);
            this.Controls.Add(this.Login_Button);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Email_textBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Email_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Email_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox Email_textBox;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.Label Role_label;
        private System.Windows.Forms.ComboBox Role_comboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}