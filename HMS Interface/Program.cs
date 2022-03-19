using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Interface
{
    class Global {
        public static string person = "";
        public static string username = "";
        public static int ID;
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 l = new Form1();
            l.Show();
            Application.Run();
        }
    }
}
