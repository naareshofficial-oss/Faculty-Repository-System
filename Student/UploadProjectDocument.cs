using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VP_PBE.Student
{
    public partial class UploadProjectDocument : Form
    {
        public UploadProjectDocument()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void UploadProjectDocument_Load(object sender, EventArgs e)
        {

        }
        private string selectedFilePath = "";


        private void Upload_button_Click(object sender, EventArgs e)
        {

            // 1. Validation Logic
            if (string.IsNullOrWhiteSpace(DocumnetName_textBox.Text) ||
                string.IsNullOrWhiteSpace(DocumentDescription_textBox.Text) ||
                string.IsNullOrEmpty(selectedFilePath)) // This now works because ChooseFile set it
            {
                MessageBox.Show("All fields are required! Please enter a name, description, and choose a file.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Database Logic (No more ShowDialog here!)
            string filePath = selectedFilePath;
            string fileName = DocumnetName_textBox.Text;
            string desc = DocumentDescription_textBox.Text;

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "INSERT INTO Repository_Items (title, category, file_path, file_type, uploader_id, description) " +
                                 "VALUES (@title, 'Project Documents', @path, @type, @uid, @desc)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@title", fileName);
                    cmd.Parameters.AddWithValue("@path", filePath);
                    cmd.Parameters.AddWithValue("@type", System.IO.Path.GetExtension(filePath));
                    cmd.Parameters.AddWithValue("@uid", SessionManager.CurrentUserId);
                    cmd.Parameters.AddWithValue("@desc", desc);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Document saved to database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields for next upload
                    DocumnetName_textBox.Clear();
                    DocumentDescription_textBox.Clear();
                    lblFileName.Text = "";
                    selectedFilePath = "";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void ChooseFile_button_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Word Documents (*.docx)|*.docx|PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // SAVE the path to the global variable
                selectedFilePath = openFileDialog1.FileName;
                // Show the name to the user so they know it worked
                lblFileName.Text = System.IO.Path.GetFileName(selectedFilePath);
            }
        }

        public static class SessionManager
        {
            // Default to 4 (Student) based on your SQL sample inserts
            public static int CurrentUserId = 4;
        }

        private void DocumnetName_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
