using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
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

namespace VP_PBE.Admin
{
    public partial class FYPProjectApproval : Form
    {
        public FYPProjectApproval()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvApprovals.Rows[e.RowIndex];
                // Safely set the ComboBox text based on the selected row
                cmbStatus.Text = row.Cells["status"].Value?.ToString() ?? "Available";
                dgvApprovals.AllowUserToAddRows = false;
            }
        }



        private void LoadSubmissionData()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Select core columns for the approval process
                    string query = "SELECT project_id, title, status, supervisor_name FROM fyp_projects";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvApprovals.DataSource = dt; // Ensure your grid is named dgvApprovals
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading submissions: " + ex.Message); }
        }

        private void FYPProjectApproval_Load(object sender, EventArgs e)
        {
            LoadSubmissionData();
            // Fill the status dropdown with your possible options
            cmbStatus.Items.AddRange(new string[] { "Available", "Approved", "Assigned", "Rejected" });
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (dgvApprovals.CurrentRow == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a project and a new status.");
                return;
            }

            // Get the project_id from the hidden or visible column
            int projectId = Convert.ToInt32(dgvApprovals.CurrentRow.Cells["project_id"].Value);
            string newStatus = cmbStatus.SelectedItem.ToString();

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE fyp_projects SET status = @status WHERE project_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@id", projectId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Project status updated to " + newStatus);
                        LoadSubmissionData(); // Refresh the grid to show changes
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            AssignCredential res = new AssignCredential();
            res.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ResetUSerPassword res = new ResetUSerPassword();
            res.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            FYPProjectApproval res = new FYPProjectApproval();
            res.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            CategorizeResources res = new CategorizeResources();
            res.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

       

        private void button22_Click(object sender, EventArgs e)
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

        private void button31_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            AssignCredential res = new AssignCredential();
            res.Show();
            this.Hide();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ResetUSerPassword res = new ResetUSerPassword();
            res.Show();
            this.Hide();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            FYPProjectApproval res = new FYPProjectApproval();
            res.Show();
            this.Hide();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            CategorizeResources res = new CategorizeResources();
            res.Show();
            this.Hide();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

        
    }
}
