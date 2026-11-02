using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using VP_PBE.Student;
using VP_PBE.Services;

namespace VP_PBE.Lecture
{
    public partial class ResourceManagementForm : Form
    {
        private string selectedFilePath = "";


        public ResourceManagementForm()
        {
            InitializeComponent();
        }

        private void LoadResources()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT resource_id, title, category, subject, file_path FROM learning_resources";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvResources.DataSource = dt; // Ensure your DataGridView is named dgvResources
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading list: " + ex.Message); }
        }

        // ================= LOAD =================
        private void ResourceManagementForm_Load(object sender, EventArgs e)
        {
            LoadResources(); // Show the list in DGV on startup

            // Populate dropdowns based on your UI design
            cmbCategory.Items.AddRange(new string[] { "Lecture Note", "Reading Material", "Video Link", "Lab Sheet" });
            cmbSubject.Items.AddRange(new string[] { "Database Systems", "Artificial Intelligence", "Software Engineering" });
        }

       

        // ================= BROWSE FILE =================
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    lblFileName.Text = System.IO.Path.GetFileName(ofd.FileName); // Updates "No File Chosen" label
                }
            }
        }
        // ================= UPLOAD =================
        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // 1. Save the long path in the hidden variable
                    selectedFilePath = ofd.FileName;

                    // 2. Show ONLY the file name on the UI label
                    lblFileName.Text = System.IO.Path.GetFileName(ofd.FileName);
                }
            }
        }

        // ================= UPDATE =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validation: Check if the hidden variable has a path
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Use 'selectedFilePath' to save the full address to MySQL
                    string sql = "INSERT INTO learning_resources (title, category, subject, file_path) " +
                                 "VALUES (@title, @cat, @sub, @path)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@cat", cmbCategory.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@sub", cmbSubject.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@path", selectedFilePath); // Full path goes here

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Resource saved with full path!");
                LoadResources(); // Refresh your DataGridView
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // ================= DELETE =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvResources.CurrentRow == null) return;
            int resId = Convert.ToInt32(dgvResources.CurrentRow.Cells["resource_id"].Value);

            if (MessageBox.Show("Delete this resource?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM learning_resources WHERE resource_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", resId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadResources();
                ClearFields();
            }
        }

        // ================= BACK =================
        private void btnBack_Click(object sender, EventArgs e)
        {
            LecturerDashboard dash = new LecturerDashboard();
            dash.Show();
            this.Close();
        }

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtTitle.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbSubject.SelectedIndex = -1;
            lblFileName.Text = "No File Chosen"; // Reset UI
            selectedFilePath = ""; // Reset hidden variable
        }
        private void dgvResources_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvResources.Rows[e.RowIndex];
                txtTitle.Text = row.Cells["title"].Value.ToString();
                cmbCategory.SelectedItem = row.Cells["category"].Value.ToString();
                cmbSubject.SelectedItem = row.Cells["subject"].Value.ToString();

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
    }
}