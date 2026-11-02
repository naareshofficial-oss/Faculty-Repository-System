using System;
using System.Windows.Forms;
using VP_PBE.Student;

namespace VP_PBE
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Open register form and keep app running
            Form2 registerForm = new Form2();
            registerForm.Show();

            // Application stays running until all forms are closed
            Application.Run();
        }
    }
}