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
using VP_PBE.Student;
using VP_PBE.Services;

namespace VP_PBE.Lecture
{
    public partial class QuestionBankForm : Form
    {
        public QuestionBankForm()
        {
            InitializeComponent();
        }

        private void QuestionBankForm_Load(object sender, EventArgs e)
        {
            LoadQuestions(); // Refresh DGV on startup
                             // Populate the Subject ComboBox
            cmbSubject.Items.AddRange(new string[] { "Database Systems", "Artificial Intelligence", "Software Engineering" });
        }
        private void LoadQuestions()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT q_id, subject, question, answer FROM question_bank";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvQuestions.DataSource = dt; // Ensure your DGV name is dgvQuestions
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvQuestions.Rows[e.RowIndex];
                cmbSubject.SelectedItem = row.Cells["subject"].Value.ToString();
                txtQuestion.Text = row.Cells["question"].Value.ToString();
                txtAnswer.Text = row.Cells["answer"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO question_bank (subject, question, answer) VALUES (@sub, @q, @a)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sub", cmbSubject.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@q", txtQuestion.Text);
                        cmd.Parameters.AddWithValue("@a", txtAnswer.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Question added!");
                LoadQuestions();
                ClearFields();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvQuestions.CurrentRow == null) return;
            int qId = Convert.ToInt32(dgvQuestions.CurrentRow.Cells["q_id"].Value);

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE question_bank SET subject=@sub, question=@q, answer=@a WHERE q_id=@id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sub", cmbSubject.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@q", txtQuestion.Text);
                        cmd.Parameters.AddWithValue("@a", txtAnswer.Text);
                        cmd.Parameters.AddWithValue("@id", qId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadQuestions();
                MessageBox.Show("Question updated!");
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cmbSubject.SelectedIndex = -1;
            txtQuestion.Clear();
            txtAnswer.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Check if a row is actually selected
            if (dgvQuestions.CurrentRow == null)
            {
                MessageBox.Show("Please select a question from the list to delete.");
                return;
            }

            // 2. Get the unique ID from the hidden or visible q_id column
            int questionId = Convert.ToInt32(dgvQuestions.CurrentRow.Cells["q_id"].Value);
            string subjectName = dgvQuestions.CurrentRow.Cells["subject"].Value.ToString();

            // 3. Ask for confirmation
            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete the question for {subjectName}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        // 4. Execute the DELETE command
                        string sql = "DELETE FROM question_bank WHERE q_id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", questionId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Question deleted successfully.");

                    // 5. Refresh the DataGridView and clear the input fields
                    LoadQuestions();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting record: " + ex.Message);
                }
            }
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
