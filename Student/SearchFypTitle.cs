using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // This fixes the CS0246 errors

namespace VP_PBE.Student
{
    public partial class Approval : Form
    {
        public Approval()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Submit_button_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Search by title and status
                    string sql = "SELECT title, description, status FROM FYP_Projects WHERE title LIKE @search";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + SearchFypTitle_textBox.Text + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Link this to a DataGridView or display the first result in textboxes
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show($"Found {dt.Rows.Count} matching projects!", "Search Results");
                        // Example: dgvResults.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No projects found matching your criteria.");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void SearchFypTitle_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Approval_Load(object sender, EventArgs e)
        {

        }
    }
}
