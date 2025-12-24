using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness
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
            Application.Run(new iForms.frmMain());
            //Application.Run(new MForms.Form1());

        }
        public static class global
        {
            public static string username { get; set; }
            public static string InputBoxText { get; set; }
            public static List<string> InputBoxList { get; set; }
            public static string InputBox1Text { get; set; }
            public static List<string> InputBox1List { get; set; }
            public static string InputBox2Text { get; set; }
            public static List<string> InputBox2List { get; set; }

        }
    }    
}
