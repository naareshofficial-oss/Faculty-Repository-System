using MySql.Data.MySqlClient;
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
using VP_PBE.Student;



namespace VP_PBE.Lecture
{
    public partial class PastQuestionForm : Form
    {
        public PastQuestionForm()
        {
            InitializeComponent();
        }


        private void LoadPastQuestions()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT question_id, subject, semester, year, file_path FROM past_questions";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPastQuestions.DataSource = dt; // Ensure DGV name matches your designer
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading grid: " + ex.Message); }
        }


        private void Form6_Load(object sender, EventArgs e)
        {
            LoadPastQuestions(); // Display all data in DataGridView on start
                                 // Populate static semester options if not done in designer
            cmbSemester.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8" });
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files (*.pdf)|*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    lblFileName.Text = ofd.FileName; // Updates the "No File Chosen" label
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYear.Text) || cmbSubject.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields and select a file.");
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO past_questions (subject, semester, year, file_path) " +
                                 "VALUES (@subject, @sem, @year, @path)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@subject", cmbSubject.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@sem", cmbSemester.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@year", txtYear.Text);
                        cmd.Parameters.AddWithValue("@path", lblFileName.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Past Year Question Uploaded!");
                        LoadPastQuestions(); // Refresh Grid
                        ClearFields();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Upload Error: " + ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPastQuestions.CurrentRow == null) return;

            int qId = Convert.ToInt32(dgvPastQuestions.CurrentRow.Cells["question_id"].Value);

            if (MessageBox.Show("Delete this record?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM past_questions WHERE question_id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", qId);
                            cmd.ExecuteNonQuery();
                            LoadPastQuestions();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Delete Error: " + ex.Message); }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cmbSubject.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtYear.Clear();
            lblFileName.Text = "No File Chosen"; // Resets the UI
        }

        private void dgvPastQuestions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LecturerDashboard fyp = new LecturerDashboard();
            fyp.Show();
        }

        private void btnFYP_Click(object sender, EventArgs e)
        {
            FYPManagementForm fyp = new FYPManagementForm();
            fyp.Show();
            this.Hide();
        }

        private void btnSupervision_Click(object sender, EventArgs e)
        {
            SupervisionForm sup = new SupervisionForm();
            sup.Show();
            this.Hide();
        }

        private void btnResources_Click(object sender, EventArgs e)
        {
            ResourceManagementForm res = new ResourceManagementForm();
            res.Show();
            this.Hide();
        }

        private void btnQuestionBank_Click(object sender, EventArgs e)
        {
            QuestionBankForm qb = new QuestionBankForm();
            qb.Show();
            this.Hide();
        }

        private void btnPastQuestions_Click(object sender, EventArgs e)
        {
            PastQuestionForm pq = new PastQuestionForm();
            pq.Show();
            this.Hide();
        }

        private void btnGrading_Click(object sender, EventArgs e)
        {
            GradingForm grade = new GradingForm();
            grade.Show();
            this.Hide();
        }

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
    }
}
