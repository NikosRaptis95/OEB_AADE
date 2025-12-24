
using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;


namespace templates.Forms

{
    public partial class def : Syncfusion.Windows.Forms.MetroForm
    {
        public string EXE;
        public string BO;
        public def Caller;

        private Syncfusion.Windows.Forms.CaptionLabel l = new Syncfusion.Windows.Forms.CaptionLabel();
        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        public def()
        {
            InitializeComponent();
            Caller = null;
                     
            l.Location = new Point(10, 4);
            l.Font = new Font(l.Font, FontStyle.Italic); 
            if (System.IO.File.Exists(@"customization\name.programmer")) l.Text = "C# ";
            else l.Text = "iLake";           
            this.CaptionLabels.Add(l);
            
            if (System.IO.File.Exists(@"customization\name.programmer")) this.CaptionLabels[0].LabelMouseDown += Def_LabelMouseDown;
                           
        }

        private void def_Load(object sender, EventArgs e)
        {
           
            if (System.IO.File.Exists(@"customization\name.programmer")==false && Caller != null)
            {
                //l.Text = "<- (Ευρετήριο)";
                //this.CaptionLabels[0].LabelMouseDown += Def_LabelMouseDown_Back;
            }
        }

        private void Def_LabelMouseDown(object sender, LabelMouseDownEventArgs e)
        {
            if (MessageBox.Show(_s.G(1) + this.Name + " - C# ;", _s.G(2), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                    new CodeEditor(@"customization\Code\" + this.Name + ".cs").ShowDialog();
        }

        private void def_Shown(object sender, EventArgs e)
        {
            new tclass().executeCode(this, BO, EXE);
        }

        //public static string GetRootNamespace()
        //{
        //    StackTrace stackTrace = new StackTrace();
        //    StackFrame[] stackFrames = stackTrace.GetFrames();
        //    string ns = null;
        //    foreach (var frame in stackFrames)
        //    {
        //        string _ns = frame.GetMethod().DeclaringType.Namespace;
        //        int indexPeriod = _ns.IndexOf('.');
        //        string rootNs = _ns;
        //        if (indexPeriod > 0)
        //            rootNs = _ns.Substring(0, indexPeriod);

        //        if (rootNs == "System")
        //            break;
        //        ns = _ns;
        //    }

        //    return ns;
        //}

              
        private void Def_LabelMouseDown_Back(object sender, LabelMouseDownEventArgs e)
        {
            if (MessageBox.Show(_s.G(3), Caller.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                if (this.ParentForm == null)
                        {  //Caller.ShowDialog(); 
                }
                else
                {
                    //Caller.MdiParent = this.ParentForm;
                    //Caller.Show();
                }
            }
         
        }

       

        class S
        {
            private string lang = "gr";
            public S(string _lang) { lang = _lang; }

            public string G(int id)
            {
                switch (lang)
                {
                    case "gr":
                        switch (id)
                        {
                            case 1: return "Θέλετε να επεξεργαστείτε την φόρμα ";
                            case 2: return "Για προγραμματιστές !";
                            case 3: return "Θέλετε να καλέσετε το ευρετήριο ;";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Edit form ";
                            case 2: return "For programmers !";
                            case 3: return "Call list ?";
                            default: return "String not found";
                        }

                }
            }

        }

        private void def_FormClosing(object sender, FormClosingEventArgs e)
        {
            new bhtaFramework.bhtaFramework().ScreenCapture(this.Handle, this.Name);
        }
    }
}
