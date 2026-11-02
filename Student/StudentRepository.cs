using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace VP_PBE.Student
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        // Method to refresh the grid with data
        private void RefreshGrid(string searchTerm = "")
        {
            try
            {
                // Join query to show the username of the person who uploaded the item
                string query = @"SELECT r.title AS 'Document Title', r.category AS 'Type', 
                                 u.username AS 'Uploaded By', r.file_path AS 'File Location'
                                 FROM repository_items r
                                 INNER JOIN users u ON r.uploader_id = u.user_id";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE r.title LIKE @search OR r.category LIKE @search";
                }

                using (var conn = DatabaseConnection.GetConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                    }

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind to the DataGridView in your designer
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        // Triggered by the Search Button (button1)
        private void button1_Click(object sender, EventArgs e)
        {
            RefreshGrid(txtSearch.Text.Trim());
        }

        // Triggered when the Form opens
        private void Form10_Load(object sender, EventArgs e)
        {
            RefreshGrid(); // Load all data automatically
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}