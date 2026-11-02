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
using System.Xml.Linq;
using VP_PBE.Services;

namespace VP_PBE.Student
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Validate that Matric Id (Student ID) is entered
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a Student ID.", "Input Required");
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // SQL JOIN to get faculty, teacher name, and assignment title
                    string sql = @"SELECT s.faculty, t.teacher_name, sa.assignment_title 
                           FROM supervisor_assignment sa
                           JOIN teachers t ON sa.teacher_id = t.teacher_id
                           JOIN students s ON sa.student_id = s.student_id
                           WHERE s.student_id = @sid";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", textBox2.Text);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 2. Format the message string
                                string faculty = reader["faculty"].ToString();
                                string teacher = reader["teacher_name"].ToString();
                                string title = reader["assignment_title"].ToString();

                                string result = $"FACULTY: {faculty}\n" +
                                                $"SUPERVISOR: {teacher}\n" +
                                                $"PROJECT: {title}";

                                // 3. Show the results in a MessageBox
                                MessageBox.Show(result, "Assignment Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // 4. Close the form after the user clicks OK
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No assignment found for this Student ID.", "Not Found");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Reset all TextBoxes
            textBox2.Clear();

            // Reset ComboBox to 'Choose' or first index
            if (comboBox4.Items.Count > 0)
                comboBox4.SelectedIndex = 0;

            // Focus back on the first input
            textBox2.Focus();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
