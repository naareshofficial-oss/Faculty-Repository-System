using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient; // Fixes CS0246
namespace VP_PBE.Student
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }


        private void LoadDeadlines()
        {
            try
            {
                // Corrected SQL using actual column names
                string query = "SELECT deadline_name AS 'Task', deadline_date AS 'Due Date', description AS 'Details' FROM submission_deadlines";

                using (var conn = DatabaseConnection.GetConnection())
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Display in the DataGridView on your form
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FillDeadlineComboBox()
        {
            try
            {
                // Fetch only the unique deadline names
                string query = "SELECT deadline_name FROM submission_deadlines";

                using (var conn = DatabaseConnection.GetConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("All Deadlines"); // Option to show everything

                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr["deadline_name"].ToString());
                    }
                    conn.Close();
                }
                comboBox1.SelectedIndex = 0; // Default to first item
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling dropdown: " + ex.Message);
            }
        }




        private void LoadDeadlines(string filter = "")
        {
            try
            {
                // Base query
                string query = "SELECT deadline_name AS 'Task', deadline_date AS 'Due Date', description AS 'Details' FROM submission_deadlines";

                // Add filtering logic
                if (!string.IsNullOrEmpty(filter) && filter != "All Deadlines")
                {
                    query += " WHERE deadline_name = @filter";
                }

                using (var conn = DatabaseConnection.GetConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (!string.IsNullOrEmpty(filter) && filter != "All Deadlines")
                    {
                        cmd.Parameters.AddWithValue("@filter", filter);
                    }

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void Form13_Load(object sender, EventArgs e)
        {
            FillDeadlineComboBox(); // Fill the list
            LoadDeadlines();        // Show all data initially
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDeadline = comboBox1.SelectedItem.ToString();
            LoadDeadlines(selectedDeadline); // Update grid based on choice
        }
    }
}
