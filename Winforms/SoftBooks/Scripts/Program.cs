using System;
using System.Windows.Forms;

namespace Database_Books
{
    static class Program
    {
        [STAThread]        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}