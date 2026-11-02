using System;
using MySql.Data.MySqlClient;
using System.Text;
using System.Security.Cryptography;

namespace VP_PBE.Services
{
    public class RegistrationService
    {
        /// <summary>
        /// Register a new user
        /// </summary>
        public static (bool success, string message) RegisterUser(string username, string email, string password, string confirmPassword, string role)
        {
            // Validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return (false, "All fields are required.");
            }

            if (password != confirmPassword)
            {
                return (false, "Passwords do not match.");
            }

            if (password.Length < 6)
            {
                return (false, "Password must be at least 6 characters long.");
            }

            if (!IsValidEmail(email))
            {
                return (false, "Please enter a valid email address.");
            }

            // Check if email already exists
            if (EmailExists(email))
            {
                return (false, "Email address is already registered. Please use a different email.");
            }

            // Check if username already exists
            if (UsernameExists(username))
            {
                return (false, "Username is already taken. Please choose a different username.");
            }

            try
            {
                string hashedPassword = AuthenticationService.HashPassword(password);

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "INSERT INTO Users (role, username, password, email, status) VALUES (@role, @username, @password, @email, 'Active')";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@email", email);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            // Get the newly created user ID
                            int userId = (int)cmd.LastInsertedId;

                            // Create profile based on role
                            CreateUserProfile(userId, role);

                            // Log registration
                            LogRegistration(userId, email);

                            return (true, "Registration successful! You can now login.");
                        }
                        else
                        {
                            return (false, "Registration failed. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Database error: " + ex.Message);
            }
        }

        /// <summary>
        /// Check if email already exists
        /// </summary>
        private static bool EmailExists(string email)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE email = @email";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if username already exists
        /// </summary>
        private static bool UsernameExists(string username)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE username = @username";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Create user profile based on role
        /// </summary>
        private static void CreateUserProfile(int userId, string role)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    if (role.ToLower() == "student")
                    {
                        string query = "INSERT INTO Students (user_id, program, semester, cgpa) VALUES (@userId, 'Not Set', 1, 0.0)";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (role.ToLower() == "teacher")
                    {
                        string query = "INSERT INTO Teachers (user_id, department, specialization) VALUES (@userId, 'Not Set', 'Not Set')";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Log registration activity
        /// </summary>
        private static void LogRegistration(int userId, string email)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string logQuery = "INSERT INTO Logs (user_id, action, description, ip_address, timestamp) VALUES (@userId, 'REGISTRATION', 'New user registered: ' + @email, @ipAddress, NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(logQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@ipAddress", GetClientIPAddress());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Get client IP address
        /// </summary>
        private static string GetClientIPAddress()
        {
            try
            {
                string hostName = System.Net.Dns.GetHostName();
                System.Net.IPHostEntry ipHostInfo = System.Net.Dns.GetHostEntry(hostName);
                System.Net.IPAddress ipAddress = ipHostInfo.AddressList[0];
                return ipAddress.ToString();
            }
            catch
            {
                return "Unknown";
            }
        }

        /// <summary>
        /// Validate email format
        /// </summary>
        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}