using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace templates
{
    class tclass
    {
        public void executeCode(Form This, string BO, string EXE)
        {   try
            {
                string fp = new alphaFrameWork.AlphaFramework().chkeckfolders("code") + This.Name + ".cs";
                if (System.IO.File.Exists(fp))
                {
                    string mycode = System.IO.File.ReadAllText(fp);
                    if (new alphaFrameWork.Code().CompileCode(mycode, This, BO.ToString(), EXE.ToString()) == false) new templates.Forms.CodeEditor(fp).ShowDialog();
                }
                else insertCode(fp, BO, EXE);
            }
            catch { }                
        }
        public void insertCode(string fp, string BO, string EXE)
        {
            try
            {
                string code =
                     "\n" +
                     "using System;" + Environment.NewLine +
                     "using System.Collections.Generic;" + Environment.NewLine +
                     "using System.Windows.Forms;" + Environment.NewLine +
                     "using templates;" + Environment.NewLine +
                     "using alphaFrameWork;" + Environment.NewLine +
                     "// using " + BO + ";" + Environment.NewLine +
                     "// using " + EXE + ";" + Environment.NewLine + Environment.NewLine +
                     "public class MegaSoftClass" + Environment.NewLine +
                     "  {" + Environment.NewLine + Environment.NewLine +
                     "     public void main(Form This)" + Environment.NewLine +
                     "     { }" + Environment.NewLine + Environment.NewLine +
                     "  }" + Environment.NewLine;

                if (System.IO.File.Exists(fp) == false)
                    System.IO.File.WriteAllText(fp, code, System.Text.Encoding.UTF8);
            }
            catch { }
        }

        public void editCode(string Name)
        {
            string fp = "customization\\code\\" + Name + ".cs";
            if (System.IO.File.Exists(fp))
            { new templates.Forms.CodeEditor(fp).ShowDialog(); }
                //Process.Start("notepad.exe", fp);
        }
    }
}
