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
using VP_PBE.Student;
using VP_PBE.Services;
namespace VP_PBE.Admin
{
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
            LoadUserData(); // Load users into grid on startup
        }


        private void LoadUserData()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Select all relevant columns from your users table
                    string query = "SELECT user_id, username, role, email, status FROM users";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt; // Ensure your DataGridView is named dgvUsers
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading users: " + ex.Message); }
        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please enter a Name and Email.");
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Insert into your 'users' table using parameters to prevent SQL injection
                    string sql = "INSERT INTO users (username, role, email, password, status) " +
                                 "VALUES (@name, @role, @email, @pass, 'Active')";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem?.ToString() ?? "Student");
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User added successfully!");
                        LoadUserData(); // Refresh grid
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error adding user: " + ex.Message); }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            // Get the user_id from the selected row
            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["user_id"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        string sql = "DELETE FROM users WHERE user_id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadUserData(); // Refresh grid
                    MessageBox.Show("User deleted.");
                }
                catch (Exception ex) { MessageBox.Show("Error deleting: " + ex.Message); }
            }
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                txtName.Text = row.Cells["username"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
                cmbRole.SelectedItem = row.Cells["role"].Value?.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            FYPProjectApproval res = new FYPProjectApproval();
            res.Show();
            this.Hide();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            AssignCredential res = new AssignCredential();
            res.Show();
            this.Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ResetUSerPassword res = new ResetUSerPassword();
            res.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            CategorizeResources res = new CategorizeResources();
            res.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

     

        private void button25_Click(object sender, EventArgs e)
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

        private void button34_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            AssignCredential res = new AssignCredential();
            res.Show();
            this.Hide();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            ResetUSerPassword res = new ResetUSerPassword();
            res.Show();
            this.Hide();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            FYPProjectApproval res = new FYPProjectApproval();
            res.Show();
            this.Hide();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            CategorizeResources res = new CategorizeResources();
            res.Show();
            this.Hide();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

       
    }
}
