using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VP_PBE.Student;
using VP_PBE.Services;
namespace VP_PBE.Admin
{
    public partial class ExportData : Form
    {
        public ExportData()
        {
            InitializeComponent();
        }

        private string GetSelectedDataType()
        {
            if (rbUsers.Checked) return "Users";
            if (rbProjects.Checked) return "FYP Projects";
            if (rbResources.Checked) return "Resources";
            if (rbLogs.Checked) return "System Logs";
            return "";
        }

        private DataTable FetchExportData(string type)
        {
            string query = "";
            switch (type)
            {
                case "Users":
                    query = "SELECT username, email, role, status FROM users";
                    break;
                case "FYP Projects":
                    query = "SELECT title, description, status FROM fyp_projects";
                    break;
                case "Resources":
                    query = "SELECT category_name, category_type FROM resource_categories";
                    break;
                case "System Logs":
                    query = "SELECT created_date, username, status FROM users";
                    break;
            }

            using (var conn = DatabaseConnection.GetConnection())
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // PDF Button Click
        private void button14_Click(object sender, EventArgs e)
        {
            string dataType = GetSelectedDataType();
            if (string.IsNullOrEmpty(dataType)) return;

            DataTable dt = FetchExportData(dataType);
            SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF Files|*.pdf", FileName = dataType + "_Report" };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // RENAMED TO AVOID DUPLICATE ERRORS
                GeneratePDFReport(dt, sfd.FileName);
                MessageBox.Show(dataType + " exported to PDF successfully!");
            }
        }

        // Excel/CSV Button Click
        private void button13_Click(object sender, EventArgs e)
        {
            string dataType = GetSelectedDataType();
            if (string.IsNullOrEmpty(dataType)) return;

            DataTable dt = FetchExportData(dataType);
            SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files|*.csv", FileName = dataType + "_Data" };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                GenerateCSVReport(dt, sfd.FileName);
                MessageBox.Show(dataType + " exported to CSV/Excel successfully!");
            }
        }

        // NO DUPLICATES ALLOWED BELOW
        private void GeneratePDFReport(DataTable dt, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, fs);
                document.Open();

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                foreach (DataColumn column in dt.Columns)
                    table.AddCell(new Phrase(column.ColumnName));

                foreach (DataRow row in dt.Rows)
                {
                    foreach (var cell in row.ItemArray)
                        table.AddCell(new Phrase(cell.ToString()));
                }

                document.Add(table);
                document.Close();
            }
        }

        private void GenerateCSVReport(DataTable dt, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                    string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        private void ExportData_Load(object sender, EventArgs e)
        {
            rbUsers.Checked = true;
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