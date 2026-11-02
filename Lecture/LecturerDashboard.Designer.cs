
namespace VP_PBE.Lecture
{
    partial class LecturerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LecturerDashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.btnFYP = new System.Windows.Forms.Button();
            this.btnResources = new System.Windows.Forms.Button();
            this.btnQuestionBank = new System.Windows.Forms.Button();
            this.btnSupervision = new System.Windows.Forms.Button();
            this.btnPastQuestions = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnGrading = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lecturer Dashboard ";
            // 
            // btnFYP
            // 
            this.btnFYP.Location = new System.Drawing.Point(65, 94);
            this.btnFYP.Name = "btnFYP";
            this.btnFYP.Size = new System.Drawing.Size(104, 25);
            this.btnFYP.TabIndex = 1;
            this.btnFYP.Text = "FYP Management";
            this.btnFYP.UseVisualStyleBackColor = true;
            this.btnFYP.Click += new System.EventHandler(this.btnFYP_Click);
            // 
            // btnResources
            // 
            this.btnResources.Location = new System.Drawing.Point(65, 207);
            this.btnResources.Name = "btnResources";
            this.btnResources.Size = new System.Drawing.Size(104, 26);
            this.btnResources.TabIndex = 2;
            this.btnResources.Text = "Resources";
            this.btnResources.UseVisualStyleBackColor = true;
            this.btnResources.Click += new System.EventHandler(this.btnResources_Click);
            // 
            // btnQuestionBank
            // 
            this.btnQuestionBank.Location = new System.Drawing.Point(65, 266);
            this.btnQuestionBank.Name = "btnQuestionBank";
            this.btnQuestionBank.Size = new System.Drawing.Size(104, 27);
            this.btnQuestionBank.TabIndex = 3;
            this.btnQuestionBank.Text = "Question Bank";
            this.btnQuestionBank.UseVisualStyleBackColor = true;
            this.btnQuestionBank.Click += new System.EventHandler(this.btnQuestionBank_Click);
            // 
            // btnSupervision
            // 
            this.btnSupervision.Location = new System.Drawing.Point(65, 151);
            this.btnSupervision.Name = "btnSupervision";
            this.btnSupervision.Size = new System.Drawing.Size(104, 27);
            this.btnSupervision.TabIndex = 4;
            this.btnSupervision.Text = "Supervision";
            this.btnSupervision.UseVisualStyleBackColor = true;
            this.btnSupervision.Click += new System.EventHandler(this.btnSupervision_Click);
            // 
            // btnPastQuestions
            // 
            this.btnPastQuestions.Location = new System.Drawing.Point(65, 328);
            this.btnPastQuestions.Name = "btnPastQuestions";
            this.btnPastQuestions.Size = new System.Drawing.Size(104, 26);
            this.btnPastQuestions.TabIndex = 5;
            this.btnPastQuestions.Text = "Past Questions";
            this.btnPastQuestions.UseVisualStyleBackColor = true;
            this.btnPastQuestions.Click += new System.EventHandler(this.btnPastQuestions_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(65, 454);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(104, 29);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnGrading
            // 
            this.btnGrading.Location = new System.Drawing.Point(65, 392);
            this.btnGrading.Name = "btnGrading";
            this.btnGrading.Size = new System.Drawing.Size(104, 27);
            this.btnGrading.TabIndex = 7;
            this.btnGrading.Text = "Grading";
            this.btnGrading.UseVisualStyleBackColor = true;
            this.btnGrading.Click += new System.EventHandler(this.btnGrading_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.btnFYP);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnGrading);
            this.panel1.Controls.Add(this.btnSupervision);
            this.panel1.Controls.Add(this.btnResources);
            this.panel1.Controls.Add(this.btnPastQuestions);
            this.panel1.Controls.Add(this.btnQuestionBank);
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 568);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 504);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Location = new System.Drawing.Point(65, 51);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(104, 23);
            this.btnDashboard.TabIndex = 9;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 70);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // LecturerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 638);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LecturerDashboard";
            this.Load += new System.EventHandler(this.LecturerDashboard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFYP;
        private System.Windows.Forms.Button btnResources;
        private System.Windows.Forms.Button btnQuestionBank;
        private System.Windows.Forms.Button btnSupervision;
        private System.Windows.Forms.Button btnPastQuestions;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnGrading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
    }
}

