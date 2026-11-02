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
using VP_PBE.Student;

using VP_PBE.Services;
namespace VP_PBE.Admin
{
    public partial class ResetUSerPassword : Form
    {
        public ResetUSerPassword()
        {
            InitializeComponent();
        }

        private void ResetUSerPassword_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Get all usernames from the users table
                    string query = "SELECT username FROM users";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmbSelectUser.Items.Clear();
                            while (reader.Read())
                            {
                                cmbSelectUser.Items.Add(reader["username"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading users: " + ex.Message); }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // 1. Validation: Ensure a user is selected
            if (cmbSelectUser.SelectedItem == null)
            {
                MessageBox.Show("Please select a user.");
                return;
            }

            // 2. Validation: Ensure passwords match
            if (string.IsNullOrEmpty(txtNewPassword.Text) || txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match or are empty!");
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Update the password column for the chosen username
                    string sql = "UPDATE users SET password = @pass WHERE username = @user";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pass", txtNewPassword.Text);
                        cmd.Parameters.AddWithValue("@user", cmbSelectUser.SelectedItem.ToString());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password reset successfully for " + cmbSelectUser.SelectedItem.ToString());

                            // Clear fields after success
                            txtNewPassword.Clear();
                            txtConfirmPassword.Clear();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // 1. Reset the ComboBox selection to nothing
            cmbSelectUser.SelectedIndex = -1;

            // 2. Empty the password textboxes
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();

            // 3. Optional: Place the cursor back in the dropdown for a fresh start
            cmbSelectUser.Focus();
        }

private void ClearFormFields()
        {
            cmbSelectUser.SelectedIndex = -1;
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        // Then call it in your Clear button...
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            AssignCredential res = new AssignCredential();
            res.Show();
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ResetUSerPassword res = new ResetUSerPassword();
            res.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            FYPProjectApproval res = new FYPProjectApproval();
            res.Show();
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            CategorizeResources res = new CategorizeResources();
            res.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

      

        private void button24_Click(object sender, EventArgs e)
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

        private void button33_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            AssignCredential res = new AssignCredential();
            res.Show();
            this.Hide();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            ResetUSerPassword res = new ResetUSerPassword();
            res.Show();
            this.Hide();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            FYPProjectApproval res = new FYPProjectApproval();
            res.Show();
            this.Hide();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            CategorizeResources res = new CategorizeResources();
            res.Show();
            this.Hide();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

       
    }
}
