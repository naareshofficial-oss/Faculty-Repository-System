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
using VP_PBE.Services;





namespace VP_PBE.Student
{
    public partial class Form11 : Form
    {
        private string _currentEmail; // store logged-in user by email

        public Form11(string email)
        {
            InitializeComponent();
            _currentEmail = email.Trim(); // remove spaces
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // Load user data from database using email
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT username, email FROM users WHERE email=@email", conn);
                cmd.Parameters.AddWithValue("@email", _currentEmail);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtUsername.Text = reader["username"].ToString(); // display username
                    txtEmail.Text = reader["email"].ToString();       // display email
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            string query = "UPDATE users SET email=@email, password=@password WHERE email=@currentEmail";

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@currentEmail", _currentEmail);
                cmd.Parameters.AddWithValue("@email", email);

                // Hash the password before saving
                string hashedPassword = AuthenticationService.HashPassword(password);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                int result = cmd.ExecuteNonQuery();

                MessageBox.Show(result > 0 ? "Profile updated successfully!" : "Update failed. Email not found!");
            }

            // Update session email if changed
            _currentEmail = email;
            SessionManager.CurrentUserEmail = email;
        }
    }
}
