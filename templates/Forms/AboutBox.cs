using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace templates.Forms
{
    public partial class AboutBox : def
    {
        
        public AboutBox()
        {
            InitializeComponent();           
        }
        private void AboutBox_Load(object sender, EventArgs e)
        {
            try {
                
                var VI = FileVersionInfo.GetVersionInfo(EXE);
                this.Text = String.Format("About {0}", VI.ProductName);
                this.labelProductName.Text = VI.ProductName;
                this.labelVersion.Text = String.Format("Version {0}", VI.ProductVersion);
                this.labelCopyright.Text = VI.LegalCopyright + " " +DateTime.Now.Year.ToString();
                this.labelCompanyName.Text = VI.CompanyName;
                this.textBoxDescription.Text = VI.Comments;

                if (System.IO.File.Exists("SN.txt")) 
                try { this.labelSN.Text="SN: "+System.IO.File.ReadAllText("SN.txt"); }
                catch { this.labelSN.Text = "SN: 1234567890"; }

                this.label_MachineId.Text = "Computer Name : " + Environment.MachineName + " IP:" + new bhtaFramework.bhtaFramework().GetLocalIPAddress();

                alphaFrameWork.AlphaFramework a = new alphaFrameWork.AlphaFramework();
                this.labelMachineName.Text = "Machine Id : "+ a.GetProcessorId();

                this.textBoxDescription.Text += (Environment.NewLine + Environment.NewLine + "Windows version: " + a.GetWindowsInfo());
                this.textBoxDescription.Text += (Environment.NewLine + Environment.NewLine + "Program Path:" + Application.ExecutablePath);
            }
            catch { }
            //new tclass().executeCode(this, BO, EXE);
        }

        
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
      
    }
}
