using System;
using System.Windows.Forms;
using VP_PBE.Services;
using VP_PBE.Admin;
using VP_PBE.Lecture;

namespace VP_PBE.Student
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize UI controls only
                if (Role_comboBox != null)
                {
                    Role_comboBox.Enabled = false;
                    Role_comboBox.Text = "Auto-detected";
                }

                if (Email_textBox != null)
                {
                    Email_textBox.Focus();
                }

                // Test database connection silently in background
                System.Threading.Thread dbTest = new System.Threading.Thread(() =>
                {
                    try
                    {
                        DatabaseConnection.TestConnection();
                    }
                    catch { }
                });
                dbTest.Start();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Form3_Load Error: " + ex.Message);
            }
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            string email = Email_textBox.Text.Trim();
            string password = Password_textBox.Text;

            // Validation
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Email_textBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Password_textBox.Focus();
                return;
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Email_textBox.Focus();
                return;
            }

            // Authenticate user
            (bool success, string role, int userId, string message) result = AuthenticationService.AuthenticateUser(email, password);

            if (result.success)
            {
                // Set session
                SessionManager.SetSession(result.userId, result.role, email);

                // Display detected role
                try
                {
                    Role_comboBox.Text = result.role;
                }
                catch { }

                // Redirect based on role
                RedirectUserByRole(result.role);

                SessionManager.CurrentUserEmail = Email_textBox.Text; // store the logged-in email

                // Close login form AFTER opening dashboard
                this.Close();
            }
            else
            {
                MessageBox.Show(result.message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password_textBox.Clear();
                Password_textBox.Focus();
            }
        }

        private void RedirectUserByRole(string role)
        {
            try
            {
                Form nextForm = null;

                switch (role.ToLower())
                {
                    case "student":
                        nextForm = new StudentDashboard();
                        break;
                    case "teacher":
                        nextForm = new LecturerDashboard();
                        break;
                    case "admin":
                        nextForm = new AdminDashboard();
                        break;
                    default:
                        MessageBox.Show("Unknown role: " + role + ". Please contact administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                if (nextForm != null)
                {
                 
                    nextForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening dashboard:\n\n" + ex.GetType().Name + ": " + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace,
                    "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
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

        private void Email_textBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Password_textBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Role_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}