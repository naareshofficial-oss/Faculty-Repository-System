using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // This fixes the CS0246 errors
using VP_PBE.Services;

namespace VP_PBE.Student
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Required field validation for Proposal Submission
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please provide a project title and select a file before submitting.",
                                "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try {
        using (var conn = DatabaseConnection.GetConnection())
        {
            conn.Open();
            string sql = "INSERT INTO Submissions (student_fwp_id, document_name, file_path, status) " +
                         "VALUES (@fwpId, @title, @path, 'Submitted')";
            
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            // We assume you fetch the student_fwp_id based on the logged-in StudentId
            cmd.Parameters.AddWithValue("@fwpId", 1); // Replace with dynamic ID
            cmd.Parameters.AddWithValue("@title", textBox1.Text);
            cmd.Parameters.AddWithValue("@path", openFileDialog1.FileName);

            cmd.ExecuteNonQuery();
            MessageBox.Show("FYP Proposal has been submitted successfully!", "Database Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }




        private string selectedFilePath = "";


       




        private void CHOOSEFILE_Click(object sender, EventArgs e)
        {
            // Configure the file dialog for specific project formats
            openFileDialog1.Filter = "Word Documents (*.docx)|*.docx|PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            openFileDialog1.Title = "Select Your FYP Proposal";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 2. Store the full path for the database
                selectedFilePath = openFileDialog1.FileName;

                // 3. Show only the file name in your new label
                lblFileName.Text = System.IO.Path.GetFileName(selectedFilePath);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            switch (comboBox1.SelectedIndex)
            {
                case 0: // Browse Titles
                    OpenForm(new Approval());
                    break;
                case 1: // Submit Proposal
                    OpenForm(new Form6());
                    break;
                case 2: // Upload Documents
                    OpenForm(new UploadProjectDocument());
                    break;
                case 3: // Supervisor Assignment
                    OpenForm(new Form7());
                    break;
            }

            comboBox1.SelectedIndex = -1; // Reset combo box
        }

        private void OpenForm(Form form)
        {
            form.ShowDialog();
        }
    }
}
