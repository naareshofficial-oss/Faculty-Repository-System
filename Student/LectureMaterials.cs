using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; // Required for opening the file

namespace VP_PBE.Student
{
    public partial class LectureMaterials : Form
    {
        public LectureMaterials()
        {
            InitializeComponent();
        }

        private void LectureMaterials_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        if (string.IsNullOrEmpty(comboBox1.Text))
    {
        MessageBox.Show("Please select a Course Code.", "Selection Required");
        return;
    }

    try
    {
        using (var conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            // Using TRIM ensures hidden spaces in the dropdown don't break the search
            string sql = "SELECT subject_name AS 'Subject', description AS 'Details', file_path AS 'File Path' " +
                         "FROM lecture_materials WHERE TRIM(course_code) = @code";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@code", comboBox1.Text.Trim());

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Use your correct name: dgvMaterials
                        dgvMaterials.DataSource = dt;
                        dgvMaterials.Columns["File Path"].Visible = false; 
                    }
                    else
                    {
                        dgvMaterials.DataSource = null;
                        MessageBox.Show("No materials found for " + comboBox1.Text, "Not Found");
                    }
                }
            }
        }
    }
    catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the path from the selected row
                string filePath = dgvMaterials.Rows[e.RowIndex].Cells["File Path"].Value.ToString();

                if (System.IO.File.Exists(filePath) || System.IO.Directory.Exists(filePath))
                {
                    DialogResult result = MessageBox.Show("Open this file?", "Download", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                    }
                }
                else
                {
                    MessageBox.Show("File path not found: " + filePath, "Error");
                }
            }
        }
    }
}
