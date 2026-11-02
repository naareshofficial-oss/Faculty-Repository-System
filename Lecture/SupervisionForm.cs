using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using VP_PBE.Student;
using VP_PBE.Services;

namespace VP_PBE.Lecture
{
    public partial class SupervisionForm : Form
    {
       
        public SupervisionForm()
        {
            InitializeComponent();
        }

        // ================= LOAD FORM =================
        private void SupervisionForm_Load(object sender, EventArgs e)
        {
            LoadSupervisionData(); // Loads the list as soon as the form opens
         
        }



        //private void FillStudentComboBox()
        //{
        //    try
        //    {
        //        using (var conn = DatabaseConnection.GetConnection())
        //        {
        //            conn.Open();
        //            // We only want to see users who are actually students
        //            string query = "SELECT username FROM users WHERE role = 'Student'";
        //            MySqlCommand cmd = new MySqlCommand(query, conn);

        //            using (MySqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                cmbStudentName.Items.Clear(); // Clear old items
        //                while (dr.Read())
        //                {
        //                    cmbStudentName.Items.Add(dr["username"].ToString());
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error loading students: " + ex.Message);
        //    }
        //}




        // Change dgvStudents_CellContentClick to dgvSupervision_CellClick
        private void dgvSupervision_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on a valid row (not the header)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupervision.Rows[e.RowIndex];

                // Fill the textboxes with data from the selected row
                txtProgressNotes.Text = row.Cells["progress_notes"].Value?.ToString();
                txtFeedback.Text = row.Cells["feedback"].Value?.ToString();

                // Optional: If you have a textbox or label for the student name:
                // txtStudentName.Text = row.Cells["student_name"].Value?.ToString();
            }
        }

        private void LoadSupervisionData()
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();

                // Insert any new students automatically
                string autoInsert = @"INSERT INTO student_supervision (student_name)
                              SELECT username
                              FROM users
                              WHERE role='Student'
                              AND username NOT IN
                              (SELECT student_name FROM student_supervision)";

                MySqlCommand cmdInsert = new MySqlCommand(autoInsert, conn);
                cmdInsert.ExecuteNonQuery();

                // Load supervision data
                string query = @"SELECT student_name, progress_notes, feedback, last_updated 
                         FROM student_supervision";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSupervision.DataSource = dt;
            }
        }





        // ================= SAVE FEEDBACK =================
        private void btnSaveFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO student_supervision (student_name, feedback) VALUES (@name, @feed)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // You might want to add a Student ComboBox to your UI to get the name
                        cmd.Parameters.AddWithValue("@name", "Selected Student");
                        cmd.Parameters.AddWithValue("@feed", txtFeedback.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadSupervisionData();
                MessageBox.Show("Feedback saved!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ================= UPDATE PROGRESS =================
        private void btnUpdateProgress_Click(object sender, EventArgs e)
        {
            if (dgvSupervision.CurrentRow == null)
            {
                MessageBox.Show("Please select a student first!");
                return;
            }

            // Save the selected student
            string studentName = dgvSupervision.CurrentRow.Cells["student_name"].Value.ToString();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"UPDATE student_supervision 
                           SET progress_notes=@notes,
                               feedback=@feedback,
                               last_updated=NOW()
                           WHERE student_name=@name";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@notes", txtProgress.Text);
                    cmd.Parameters.AddWithValue("@feedback", txtFeedback.Text);
                    cmd.Parameters.AddWithValue("@name", studentName);

                    cmd.ExecuteNonQuery();
                }

                // Reload grid
                LoadSupervisionData();

                // 🔹 Re-select the same student row
                foreach (DataGridViewRow row in dgvSupervision.Rows)
                {
                    if (row.Cells["student_name"].Value.ToString() == studentName)
                    {
                        row.Selected = true;
                        dgvSupervision.CurrentCell = row.Cells[0];
                        break;
                    }
                }

                MessageBox.Show("Updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }









        // ================= BACK =================
        private void btnBack_Click(object sender, EventArgs e)
        {
            LecturerDashboard dash = new LecturerDashboard();
            dash.Show();
            this.Close();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupervision.Rows[e.RowIndex];

                txtProgress.Text = row.Cells["progress_notes"].Value?.ToString();
                txtFeedback.Text = row.Cells["feedback"].Value?.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvSupervision.CurrentRow == null)
            {
                MessageBox.Show("Please select a student first!");
                return;
            }

            string studentName = dgvSupervision.CurrentRow.Cells["student_name"].Value.ToString();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO student_supervision
                           (student_name, progress_notes, feedback)
                           VALUES (@name, @notes, @feedback)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@name", studentName);
                    cmd.Parameters.AddWithValue("@notes", txtProgressNotes.Text);
                    cmd.Parameters.AddWithValue("@feedback", txtFeedback.Text);

                    cmd.ExecuteNonQuery();
                }

                LoadSupervisionData();

                MessageBox.Show("Student supervision saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            // 1. Check if a row is actually selected in the grid
            if (dgvSupervision.CurrentRow == null)
            {
                MessageBox.Show("Please select a student from the list first!");
                return;
            }

            // 2. Get the ID from the selected row so we know which student to update
            int id = Convert.ToInt32(dgvSupervision.CurrentRow.Cells["supervision_id"].Value);

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // 3. Use the Text property of your TextBoxes
                    // We update both Progress and Feedback based on the ID
                    string sql = "UPDATE student_supervision SET progress_notes = @notes, feedback = @feed, last_updated = NOW() WHERE supervision_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Ensure these names match your actual TextBox names (txtProgressNotes and txtFeedback)
                        cmd.Parameters.AddWithValue("@notes", txtProgressNotes.Text);
                        cmd.Parameters.AddWithValue("@feed", txtFeedback.Text);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }

                // 4. Refresh the grid and clear the boxes
                LoadSupervisionData();
                MessageBox.Show("Progress and Feedback updated successfully! ✅");

                // Optional: Clear textboxes after update
                // txtProgressNotes.Clear();
                // txtFeedback.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvSupervision.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete!");
                return;
            }

            string studentName = dgvSupervision.CurrentRow.Cells["student_name"].Value.ToString();

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string sql = "DELETE FROM student_supervision WHERE student_name=@name";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", studentName);

                    cmd.ExecuteNonQuery();
                }

                LoadSupervisionData();

                txtProgress.Clear();
                txtFeedback.Clear();

                MessageBox.Show("Record deleted successfully!");
            }
        }


        private void SupervisionForm_Click(object sender, EventArgs e)
        {

        }

        private void txtProgress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFeedback_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}