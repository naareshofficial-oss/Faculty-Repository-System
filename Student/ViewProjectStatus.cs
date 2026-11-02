using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using VP_PBE.Services; // Ensure this matches your connection service namespace

namespace VP_PBE.Student
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            LoadProjectStatus();
        }

        private void LoadProjectStatus()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // This query pulls the exact columns we saw in your Workbench screenshot
                    string query = "SELECT assignment_title AS 'Project Title', status AS 'Status', assignment_date AS 'Date Assigned' FROM supervisor_assignment";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind the data to your grid
                    dataGridView1.DataSource = dt;

                    // Optional: Make the columns fit the text nicely
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading project status: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // Leave empty unless you want to trigger an action when clicking a cell
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}