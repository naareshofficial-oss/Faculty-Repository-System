using System;
using System.Windows.Forms;
using VP_PBE.Services;
using VP_PBE.Student;

namespace VP_PBE.Lecture
{
    public partial class LecturerDashboard : Form
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }
        private void LecturerDashboard_Load(object sender, EventArgs e)
        {

        }

        // =========================
        // FYP MANAGEMENT
        // =========================
        private void btnFYP_Click(object sender, EventArgs e)
        {
            FYPManagementForm fyp = new FYPManagementForm();
            fyp.Show();
            this.Hide();
        }

        // =========================
        // SUPERVISION
        // =========================
        private void btnSupervision_Click(object sender, EventArgs e)
        {
            SupervisionForm sup = new SupervisionForm();
            sup.Show();
            this.Hide();
        }

        // =========================
        // GRADING
        // =========================
        private void btnGrading_Click(object sender, EventArgs e)
        {
            GradingForm grade = new GradingForm();
            grade.Show();
            this.Hide();
        }

        // =========================
        // RESOURCE MANAGEMENT
        // =========================
        private void btnResources_Click(object sender, EventArgs e)
        {
            ResourceManagementForm res = new ResourceManagementForm();
            res.Show();
            this.Hide();
        }

        // =========================
        // PAST QUESTIONS
        // =========================
        private void btnPastQuestions_Click(object sender, EventArgs e)
        {
            PastQuestionForm pq = new PastQuestionForm();
            pq.Show();
            this.Hide();
        }

        // =========================
        // QUESTION BANK
        // =========================
        private void btnQuestionBank_Click(object sender, EventArgs e)
        {
            QuestionBankForm qb = new QuestionBankForm();
            qb.Show();
            this.Hide();
        }

        // =========================
        // LOGOUT
        // =========================
        private void btnLogout_Click(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LecturerDashboard fyp = new LecturerDashboard();
            fyp.Show();
        }
    }
}