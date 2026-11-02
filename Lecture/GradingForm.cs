using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using VP_PBE.Student;
using VP_PBE.Services;

namespace VP_PBE.Lecture
{
    public partial class GradingForm : Form
    {
       

        public GradingForm()
        {
            InitializeComponent();
        }


        private void LoadGrades()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                // Use student_grading because it contains the project_title and marks
                string query = "SELECT student_name, project_title, marks, grade FROM student_grading";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSubmissions.DataSource = dt;
            }
        }

        // ================= LOAD =================
        private void GradingForm_Load(object sender, EventArgs e)
        {
            // 1. Clear existing items to prevent duplicates
            cmbStudent.Items.Clear();
            cmbProject.Items.Clear();
            cmbGrade.Items.Clear();

            // 2. Add static grades to the Grade ComboBox
            cmbGrade.Items.AddRange(new string[] { "A", "A-", "B+", "B", "B-", "C+", "C", "D", "F" });

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // 3. Fetch Students from 'users' table
                    string studentQuery = "SELECT username FROM users WHERE role = 'Student'";
                    using (MySqlCommand cmd = new MySqlCommand(studentQuery, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbStudent.Items.Add(reader["username"].ToString());
                            }
                        }
                    }

                    // 4. Fetch Projects from 'fyp_projects' table
                    string projectQuery = "SELECT title FROM fyp_projects";
                    using (MySqlCommand cmd = new MySqlCommand(projectQuery, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbProject.Items.Add(reader["title"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

       

       
        // ================= SAVE =================
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation: Ensure no fields are empty
            if (cmbStudent.SelectedItem == null || cmbProject.SelectedItem == null || string.IsNullOrEmpty(txtMarks.Text))
            {
                MessageBox.Show("Please fill in all grading fields.");
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO student_grading (student_name, project_title, marks, grade) " +
                                 "VALUES (@name, @project, @marks, @grade)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", cmbStudent.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@project", cmbProject.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@marks", txtMarks.Text);
                        cmd.Parameters.AddWithValue("@grade", cmbGrade.SelectedItem?.ToString() ?? "N/A");

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Grade saved successfully for " + cmbStudent.SelectedItem.ToString());

                        LoadGrades();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
        }

        // ================= UPDATE =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Update based on student name and project title
                    string sql = "UPDATE student_grading SET marks=@marks, grade=@grade " +
                                 "WHERE student_name=@name AND project_title=@project";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@marks", txtMarks.Text);
                        cmd.Parameters.AddWithValue("@grade", cmbGrade.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@name", cmbStudent.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@project", cmbProject.SelectedItem.ToString());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0) MessageBox.Show("Student grade updated!");
                        else MessageBox.Show("No record found to update.");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // ================= BACK =================
        private void btnBack_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvSubmissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSubmissions.Rows[e.RowIndex];

                // Safely handle potential nulls to prevent crashes
                cmbStudent.Text = row.Cells["student_name"].Value?.ToString() ?? "";
                cmbProject.Text = row.Cells["project_title"].Value?.ToString() ?? "";
                txtMarks.Text = row.Cells["marks"].Value?.ToString() ?? "";
                cmbGrade.Text = row.Cells["grade"].Value?.ToString() ?? "";
            }
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

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