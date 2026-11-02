using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace VP_PBE.Services
{
    public class AuthenticationService
    {
        /// <summary>
        /// Hash password using SHA256 (compatible with .NET Framework 4.7.2)
        /// </summary>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return ByteArrayToString(hashedBytes);
            }
        }

        /// <summary>
        /// Convert byte array to hex string (for .NET Framework compatibility)
        /// </summary>
        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        /// <summary>
        /// Authenticate user by email and password
        /// </summary>
        public static (bool success, string role, int userId, string message) AuthenticateUser(string email, string password)
        {
            try
            {
                string hashedPassword = HashPassword(password);

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT user_id, role, status FROM Users WHERE email = @email AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("user_id");
                                string role = reader.GetString("role");
                                string status = reader.GetString("status");

                                if (status != "Active")
                                {
                                    return (false, "", 0, "Your account is " + status.ToLower() + ". Please contact administrator.");
                                }

                                // Log the login
                                LogUserLogin(userId);

                                return (true, role, userId, "Login successful");
                            }
                            else
                            {
                                return (false, "", 0, "Invalid email or password");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "", 0, "Database error: " + ex.Message);
            }
        }

        /// <summary>
        /// Log user login activity
        /// </summary>
        private static void LogUserLogin(int userId)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string logQuery = "INSERT INTO Logs (user_id, action, description, ip_address, timestamp) VALUES (@userId, 'LOGIN', 'User logged in successfully', @ipAddress, NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(logQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@ipAddress", GetClientIPAddress());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Get client IP address (using non-obsolete method)
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
    }
}