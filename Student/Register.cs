using System;
using System.Windows.Forms;
using VP_PBE.Services;

namespace VP_PBE.Student
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Populate role dropdown
            RolecomboBox.Items.Clear();
            RolecomboBox.Items.Add("Student");
            RolecomboBox.Items.Add("Teacher");
            RolecomboBox.Items.Add("Admin"); // Add this line!
            RolecomboBox.SelectedIndex = 0;

            // Focus on username field
            Username_textBox.Focus();
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            string username = Username_textBox.Text.Trim();
            string email = Email_textBox.Text.Trim();
            string password = Password_textBox.Text;
            string role = RolecomboBox.SelectedItem?.ToString() ?? "Student";

            // Validation
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Username_textBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Email_textBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Password_textBox.Focus();
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Password_textBox.Focus();
                return;
            }

            // Register user
            (bool success, string message) result = RegistrationService.RegisterUser(username, email, password, password, role);

            if (result.success)
            {
                // Show success message
                MessageBox.Show(result.message + "\n\nYou will now be redirected to the login page.",
                    "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    // Open login form as independent window (not modal)
                    Form3 loginForm = new Form3();
                    loginForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening login form: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(result.message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password_textBox.Clear();
                Password_textBox.Focus();
            }
        }




        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void Username_label_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Open login form directly (skip registration)
                Form3 loginForm = new Form3();
                loginForm.ShowDialog(this);

                // Close registration form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening login form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RolecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}