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
    public partial class AssignCredential : Form
    {
        public AssignCredential()
        {
            InitializeComponent();
        }

        private void FillUserDropdown()
        {
            try
            {
                // SQL to get all usernames from your table
                string query = "SELECT username FROM users";

                using (var conn = DatabaseConnection.GetConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    // Clear the existing items first
                    comboBox1.Items.Clear();

                    while (dr.Read())
                    {
                        // Add each username found in the DB to the dropdown
                        comboBox1.Items.Add(dr["username"].ToString());
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling dropdown: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT username, password, email, role FROM users WHERE username = @oldName";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@oldName", comboBox1.SelectedItem.ToString());
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUsername.Text = reader["username"].ToString();
                                txtPassword.Text = reader["password"].ToString();
                                // Note: Ensure you have an Email textbox in your design
                                cmbRole.SelectedItem = reader["role"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading user details: " + ex.Message); }
        }



        private void AssignCredential_Load(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Fetch usernames to fill the selection dropdown
                    string query = "SELECT username FROM users";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox1.Items.Clear();
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["username"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        } 

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Use UPDATE to change existing data in the 'users' table
                    string sql = "UPDATE users SET username=@newName, password=@pass, email=@email, role=@role " +
                                 "WHERE username=@oldName";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@newName", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                        //cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@oldName", comboBox1.SelectedItem.ToString());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Credentials updated successfully!");
                            // Refresh the dropdown in case the username was changed
                            AssignCredential_Load(null, null);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void AssignCredential_Load_1(object sender, EventArgs e)
        {
            FillUserDropdown();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AssignCredential res = new AssignCredential();
            res.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ResetUSerPassword res = new ResetUSerPassword();
            res.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FYPProjectApproval res = new FYPProjectApproval();
            res.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CategorizeResources res = new CategorizeResources();
            res.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

     

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void button16_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

       
    }
}
