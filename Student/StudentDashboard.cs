using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VP_PBE.Services;

    namespace VP_PBE.Student
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FypcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FypcomboBox.SelectedIndex == -1) return;

            switch (FypcomboBox.SelectedIndex)
            {
                case 0: // Browse Titles
                    OpenForm(new Approval());
                    break;
                case 1: // Submit Proposal
                    OpenForm(new Form6());
                    break;
                case 2: // Upload Documents
                    OpenForm(new UploadProjectDocument());
                    break;
                case 3: // Supervisor Assignment
                    OpenForm(new Form7());
                    break;
            }

            FypcomboBox.SelectedIndex = -1; // Reset combo box
        }

        private void RepositorycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RepositorycomboBox.SelectedIndex == -1) return;

            switch (RepositorycomboBox.SelectedIndex)
            {
                case 0: // Lecture Materials
                    OpenForm(new LectureMaterials());
                    break;
                case 1: // Past Year Questions
                    OpenForm(new Form8());
                    break;
                case 2: // Academic Records
                    OpenForm(new Form10());
                    break;
            }

            RepositorycomboBox.SelectedIndex = -1; // Reset combo box
        }

        private void ProfilecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProfilecomboBox.SelectedIndex == -1) return;

            switch (ProfilecomboBox.SelectedIndex)
            {
                case 0: // Update Information
                    OpenForm(new Form11(SessionManager.CurrentUserEmail));
                    break;
                case 1: // View Project Status
                    OpenForm(new Form12());
                    break;
                case 2: // Submission Deadlines
                    OpenForm(new Form13());
                    break;
            }

            ProfilecomboBox.SelectedIndex = -1; // Reset combo box
        }

        private void Logout_button_Click(object sender, EventArgs e)
        {
            // Confirm logout
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear session
                SessionManager.ClearSession();

                // Open login form
                Form3 loginForm = new Form3();
                loginForm.Show();

                // Close dashboard
                this.Close();
            }
        }

        private void OpenForm(Form form)
        {
            form.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
