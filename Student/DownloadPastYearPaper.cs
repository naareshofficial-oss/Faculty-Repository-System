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


using MySql.Data.MySqlClient;

namespace VP_PBE.Student
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSubject = comboBox6.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedSubject))
            {
                LoadPastYearPapers(selectedSubject);
            }
        }

        private void LoadPastYearPapers(string subject = "")
        {
            try
            {
                string query = "SELECT subject, semester, year, faculty, program, file_path FROM past_questions";
                if (!string.IsNullOrEmpty(subject))
                {
                    query += " WHERE subject=@subject";
                }

                using (var conn = DatabaseConnection.GetConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(subject))
                        cmd.Parameters.AddWithValue("@subject", subject);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading papers: " + ex.Message);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            try
            {
                string query = "SELECT DISTINCT subject FROM past_questions ORDER BY subject";

                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    comboBox6.Items.Clear();
                    while (reader.Read())
                    {
                        comboBox6.Items.Add(reader["subject"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message);
            }
        }

        private void LoadPastYearPapers()
        {
            try
            {
                // SQL query to select relevant columns for the student
                string query = "SELECT subject, semester, year, faculty, program FROM past_questions";

                using (var conn = DatabaseConnection.GetConnection())
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Link this data to your DataGrid
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading papers: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadPastYearPapers();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a paper to download.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the full file path from the selected row
            string fullPath = dataGridView1.SelectedRows[0].Cells["file_path"].Value.ToString();

            // Make sure file exists
            if (!System.IO.File.Exists(fullPath))
            {
                MessageBox.Show("File not found: " + fullPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ask user where to save the file
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = System.IO.Path.GetFileName(fullPath);
                sfd.Filter = "PDF Files|*.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.Copy(fullPath, sfd.FileName, true);
                        MessageBox.Show("Download successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error downloading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
