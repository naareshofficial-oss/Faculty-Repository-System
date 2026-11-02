using MySql.Data.MySqlClient;
using System.Configuration;

namespace VP_PBE
{
    public class DatabaseConnection
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Database Connection Error: " + ex.Message,
                    "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}