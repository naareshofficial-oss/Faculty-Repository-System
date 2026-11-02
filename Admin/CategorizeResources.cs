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
    public partial class CategorizeResources : Form
    {
        public CategorizeResources()
        {
            InitializeComponent();
        }

        private void LoadCategories()
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT category_id, category_name, category_type FROM resource_categories";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCategories.DataSource = dt; // Ensure your grid is named dgvCategories
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }



        private void CategorizeResources_Load(object sender, EventArgs e)
        {
            LoadCategories();
            // Populate the Type dropdown
            cmbCategoryType.Items.AddRange(new string[] { "Document", "Video", "Software", "Research Paper" });
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text) || cmbCategoryType.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO resource_categories (category_name, category_type) VALUES (@name, @type)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtCategoryName.Text);
                    cmd.Parameters.AddWithValue("@type", cmbCategoryType.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
            LoadCategories();
            MessageBox.Show("Category added!");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvCategories.CurrentRow.Cells["category_id"].Value);

            if (MessageBox.Show("Delete this category?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM resource_categories WHERE category_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadCategories();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txtCategoryName.Clear();
            cmbCategoryType.SelectedIndex = -1;
            txtCategoryName.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                txtCategoryName.Text = row.Cells["category_name"].Value?.ToString() ?? "";
                cmbCategoryType.Text = row.Cells["category_type"].Value?.ToString() ?? "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void button21_Click(object sender, EventArgs e)
        {
            FYPProjectApproval res = new FYPProjectApproval();
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

        private void button2_Click(object sender, EventArgs e)
        {
            ManageUsers res = new ManageUsers();
            res.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AssignCredential res = new AssignCredential();
            res.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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

      
    }
}
