using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace templates
{
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
        }
    }
    public static class global
    {
        public static List<string> r = new List<string>();
        public static Boolean loginRes;        
        public static Boolean dbconnectionsRes;
        public static string User;
        
    }
    public class user
    {
        public string username { get; set; }
        public string password { get; set; }     
    }


}
