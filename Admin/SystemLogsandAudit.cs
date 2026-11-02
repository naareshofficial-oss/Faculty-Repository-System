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
    public partial class SystemLogsandAudit : Form
    {
        public SystemLogsandAudit()
        {
            InitializeComponent();
        }

       

        private void SystemLogs_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       

        private void SystemLogsandAudit_Load(object sender, EventArgs e)
        {
            LoadLogs(); // This triggers the data pull when the window opens
        }
        private void LoadLogs()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // 1. Ensure 'created_date' is the REAL name in your DB. 
                    // If it fails, try 'created_at' or check your table columns.
                    string query = "SELECT created_date AS 'Date', username AS 'User', role AS 'Role', status AS 'Status' FROM users";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 2. Clear old manual columns (like 'Action') so they don't stay blank
                    dgvSystemLogs.Columns.Clear();

                    // 3. Bind the new data
                    dgvSystemLogs.DataSource = dt;

                    // 4. Formatting
                    if (dgvSystemLogs.Columns.Contains("Date"))
                    {
                        dgvSystemLogs.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        dgvSystemLogs.Columns["Date"].Width = 150;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading system logs: " + ex.Message);
            }
        }

     

        private void button21_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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

        private void button15_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

     

        private void button22_Click(object sender, EventArgs e)
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

     
        private void button31_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            AssignCredential res = new AssignCredential();
            res.Show();
            this.Hide();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ResetUSerPassword res = new ResetUSerPassword();
            res.Show();
            this.Hide();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            FYPProjectApproval res = new FYPProjectApproval();
            res.Show();
            this.Hide();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            CategorizeResources res = new CategorizeResources();
            res.Show();
            this.Hide();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            SystemLogsandAudit res = new SystemLogsandAudit();
            res.Show();
            this.Hide();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ExportData res = new ExportData();
            res.Show();
            this.Hide();
        }

       
    }
}
