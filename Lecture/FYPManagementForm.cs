using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO; 
using System.Windows.Forms;
using VP_PBE.Services;
using VP_PBE.Student;

namespace VP_PBE.Lecture
{
    public partial class FYPManagementForm : Form
    {
        private string selectedFilePath = "";

        public FYPManagementForm()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void FYPManagementForm_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }



        private void LoadDataIntoGrid()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // REMOVE any mention of supervisor from this string
                    string query = "SELECT project_id, title, description, status FROM fyp_projects";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvFYP.DataSource = dt;

                    // Hide the ID column so users only see Title, Description, and Status
                    if (dgvFYP.Columns.Contains("project_id"))
                    {
                        dgvFYP.Columns["project_id"].Visible = false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading grid: " + ex.Message); }
        }



       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Only insert the fields present on your new form
                    string sql = "INSERT INTO fyp_projects (title, description, status) VALUES (@title, @desc, 'Available')";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDataIntoGrid();
                MessageBox.Show("Project Added Successfully!"); // Clean message
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // ================= UPDATE =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvFYP.CurrentRow == null) return;
            int projectId = Convert.ToInt32(dgvFYP.CurrentRow.Cells["project_id"].Value);

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // REMOVED supervisor_name and file_path from the update to match your new UI
                    string sql = "UPDATE fyp_projects SET title=@title, description=@desc WHERE project_id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@id", projectId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadDataIntoGrid();
                MessageBox.Show("Project Updated Successfully!");
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
        }

        // ================= DELETE =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFYP.CurrentRow == null) return;

            int projectId = Convert.ToInt32(dgvFYP.CurrentRow.Cells["project_id"].Value);

            // Ask for permission before deleting
            DialogResult result = MessageBox.Show("Are you sure you want to delete this project?",
                                                 "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM fyp_projects WHERE project_id=@id";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", projectId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadDataIntoGrid();
                    ClearFields();
                    MessageBox.Show("Project deleted.");
                }
                catch (Exception ex) { MessageBox.Show("Delete Error: " + ex.Message); }
            }
        }

        // ================= BROWSE FILE =================
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files|*.pdf|Word Docs|*.docx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Store full path hiddenly, show filename on label
                    selectedFilePath = ofd.FileName;
                    txtFilePath.Text = Path.GetFileName(ofd.FileName);
                }
            }
        }

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            txtDescription.Clear();
            txtFilePath.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

      

        private void dgvFYP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFYP.Rows[e.RowIndex];
                // Only update the controls that still exist
                txtTitle.Text = row.Cells["title"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["description"].Value?.ToString() ?? "";

                // Removed supervisor logic to prevent crashes
            }
        }


        private void dgvFYP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFYP.Rows[e.RowIndex];

                // Only fill the boxes that exist on your form now
                txtTitle.Text = row.Cells["title"].Value?.ToString() ?? "";
                txtDescription.Text = row.Cells["description"].Value?.ToString() ?? "";

                // Removed all file_path and supervisor logic to stop the CS0103 errors
            }
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LecturerDashboard fyp = new LecturerDashboard();
            fyp.Show();
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

        private void btnFYP_Click(object sender, EventArgs e)
        {

        }
    }
}