using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace templates.Forms
{
    public partial class Main : def
    {

        #region InitializeForm   
        S _s = new S(new alphaFrameWork.AlphaFramework().lang);

        public Main()
        {
            //MessageBox.Show("Ok");
            Cursor.Current = Cursors.WaitCursor;
            
            Form f = new templates.Forms.splash();           
            InitializeComponent();            
            this.Tag = "main";
            try {  getConnectionInformation();
            getCompany();
            new alphaFrameWork.datalayer().GetCheckDatabase();
            f.ShowDialog();  }
            catch { MessageBox.Show(_s.G(1), _s.G(2)); }
           _CustomizeMenu();
            Cursor.Current = Cursors.Default;            
        }
        private void Main_Load(object sender, EventArgs e)
        {           
            Form l = new templates.Forms.login(setUsers());
            l.ShowDialog();
            if (global.loginRes == false) { this.Close(); return; }
            else getUsers(global.User);

            string v = checkForUpdateFunction();
            checkForUpdate.Tag = v;
            if (checkForUpdate.Enabled == true) MessageBox.Show(_s.G(3) + v + _s.G(4) + v + "'", _s.G(2));   //{ updateNewVersion(v); }
            
            if (System.IO.File.Exists(@"customization\name.programmer")) { this.CaptionLabels[0].Text = "C#"; this.CaptionLabels[0].LabelMouseDown += Def_LabelMouseDown; }
            else { this.CaptionLabels[0].Text = "iLake"; }
            //new tclass().executeCode(this, BO, EXE);
        }

        private void Def_LabelMouseDown(object sender, LabelMouseDownEventArgs e)
        {
            if (MessageBox.Show(_s.G(5)+ this.Name + " - C# ;", _s.G(6), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                new CodeEditor(@"customization\Code\" + this.Name + ".cs").ShowDialog();
        }

        #endregion

        #region Buttons
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        { this.Close(); }                 

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        { foreach (Form childForm in MdiChildren)        
                                  childForm.Close(); }

        
        private void formClosing(object sender, FormClosingEventArgs e)
        {
            if(this.Tag.ToString() == "main" && global.loginRes) {
                if (MessageBox.Show(_s.G(7), _s.G(2), MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.Cancel)
                { e.Cancel = true; }
                else { try { System.IO.File.Delete(@"customization\name.programmer"); new alphaFrameWork.AlphaFramework().WebRetrieve(setLogin.Replace("Open","Close")); }  catch { } }
            }
        }
      
        private void έλεγχοςΝέαςΈκδοσηςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.checkForUpdate.Text = _s.G(8) + checkForUpdate.Tag.ToString();            
            updateNewVersion(checkForUpdate.Tag.ToString()); }

        private void bprrnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ilake.eu");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox childForm = new AboutBox();
            childForm.EXE = EXE;
            childForm.MdiParent = this;
            childForm.Show();            
        }

        #endregion

        #region GlobalVars
        private string setLogin = "";
        private void getCompany()
        { this.Text = Application.CompanyName + " - " + Application.ProductName; }       
        private void getConnectionInformation()
        {
            try
            {using (StreamReader sr = new StreamReader("app_data\\connectionstring.txt"))
                { this.Label_toolStripStatus.Text = sr.ReadLine(); } }
            catch { }
        }
        private string update_version;
        private string checkForUpdateFunction()
        {
            string MyUpdatePath = Application.StartupPath + @"\updates";
            try { if (Directory.Exists(MyUpdatePath)) Directory.Delete(MyUpdatePath, true); }
            catch { }

            alphaFrameWork.AlphaFramework c = new alphaFrameWork.AlphaFramework();
            bhtaFramework.bhtaFramework b = new bhtaFramework.bhtaFramework();
            List<string> r = getProgramDetails();
            setLogin =  b.LoginNetURL + "/login.net/setLogin.aspx?";
            try
            {
                setLogin = setLogin + "SN=" + r[0] + "&Program=" + Application.ProductName + "&FormName=" + r[1] + "&Type=" + r[2] + "&Version=" + Application.ProductVersion + "&Company=" + r[3] + "&UserName=" + global.User + "&ComputerName=" + r[4] + "&MachineId=" + r[5] + "&WindowsVersion=" + r[6] + "&ProgramPath=" + r[7].Replace(@"\", "'") + "&CheckDigit=";
                setLogin = setLogin + (global.User.Length + r[4].Length).ToString();
                //
            } catch { }
            //MessageBox.Show(c.WebRetrieve(setLogin));
            c.WebRetrieve(setLogin);


            string pathfile = "http://"+ b.SupportURL +"/bpr.net/" + Application.ProductName + "/version.txt";
            update_version = c.WebRetrieve(pathfile).Trim();
            Label_update.Text = "Αναβάθμιση : "+update_version;
            if (update_version.Equals(Application.ProductVersion) || update_version.Equals("xxxxxxx")) this.checkForUpdate.Enabled = false;
            else { this.checkForUpdate.Text = _s.G(8) + update_version; this.checkForUpdate.Enabled = true; }
            return update_version;
        }
        private void updateNewVersion(string v)
        {

            if (MessageBox.Show(_s.G(9) + Application.ProductVersion + _s.G(10) + v, _s.G(11), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Label_update.Visible = true;
                pb_update.Visible = true;
                Cursor.Current = Cursors.WaitCursor;
                if (new alphaFrameWork.AlphaFramework().UpdateSection(Application.StartupPath, update_version, Label_update, pb_update, Application.ProductVersion, this, Application.ProductName, Application.ExecutablePath))
                {
                    global.loginRes = false;
                    this.Close();
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(_s.G(12), _s.G(13));
                }
            }
            else { MessageBox.Show(_s.G(14), _s.G(13)); }
        }      
#endregion

#region VirtualFuncs
    public virtual void CustomizeMenu()
        { }
    public virtual List<user> setUsers()
        {
            List<user> users = new List<user>();
            users.Add(new user() { username = "Antonio", password = ""});
            users.Add(new user() { username = "Bruce", password = ""});
            users.Add(new user() { username = "Lara", password = ""});
            return users;
        }   
    public virtual void getUsers(string User)
        {
            
        }
    
    public virtual List<string> getProgramDetails()
        {
            List<string> r = new List<string>();
            r.Add("SN");
            r.Add("FormName");
            r.Add("Type");
            r.Add("Company");
            r.Add("ComputerName");
            r.Add("MachineId");
            r.Add("WindowsVersion");
            r.Add("ProgramPath");
            return r;
        }
#endregion

        private void _CustomizeMenu()
        {
            fileMenu.Text = _s.G(15);
            exitToolStripMenuItem.Text = _s.G(16);
            editMenu.Text = _s.G(17);
            viewMenu.Text = _s.G(18);
            toolBarToolStripMenuItem.Text = _s.G(19);
            statusBarToolStripMenuItem.Text = _s.G(20);
            toolsMenu.Text = _s.G(21);
            databaseConnectionToolStripMenuItem.Text = _s.G(22);
            checkForUpdate.Text = _s.G(23);
            exportDataToolStripMenuItem.Text = _s.G(24);
            importDataToolStripMenuItem.Text = _s.G(25);
            deleteDataToolStripMenuItemToolStripMenuItem.Text = _s.G(26);
            demoDataToolStripMenuItemToolStripMenuItem.Text = _s.G(27);
            windowsMenu.Text = _s.G(28);
            cascadeToolStripMenuItem.Text = _s.G(29);
            tileVerticalToolStripMenuItem.Text = _s.G(30);
            tileHorizontalToolStripMenuItem.Text = _s.G(31);
            arrangeIconsToolStripMenuItem.Text = _s.G(32);
            closeAllToolStripMenuItem.Text = _s.G(33);
            helpMenu.Text = _s.G(34); 
            contentsToolStripMenuItem.Text = _s.G(35);
            indexToolStripMenuItem.Text = _s.G(36);
            searchToolStripMenuItem.Text = _s.G(37);
            aboutToolStripMenuItem.Text = _s.G(38);
            CustomizeMenu();
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
                            case 1: return "Σφάλμα στην εκκίνησης της εφαρμογής !";
                            case 2: return "Προσοχή !!";
                            case 3: return "Υπάρχει νέα έκδοση διαθέσιμη !\n\nέκδοση ";
                            case 4: return "\n\nΜπορείτε να την εγκαταστήσετε απο το \nμενού 'Εργαλεία --> Εγκατάσταση έκδοσης ";
                            case 5: return "Θέλετε να επεξεργαστείτε την φόρμα ";
                            case 6: return "Για προγραμματιστές !";
                            case 7: return "Θέλετε να κλείσετε το πρόγραμμα ;";
                            case 8: return "Εγκατάσταση έκδοσης ";
                            case 9: return "Θέλετε να εγκαταστείσετε την νέα έκδοση του προγράμματος ;\n\nΠροσοχή !!! Η εφαρμογή πρέπει να τρέχει μονο μια φορά σε αυτον τον υπολογιστή και σε κανέναν άλλο !\n\nΥπάρχουσα έκδοση ";
                            case 10: return "\nΝέα έκδοση ";
                            case 11: return "Υπάρχει νέα έκδοση.";
                            case 12: return "Η διαδικασία εγκατάστασης διακόπηκε !";
                            case 13: return "Νέα έκδοση προγράμματος.";
                            case 14: return "Η διαδικασία εγκατάστασης ακυρώθηκε !";

                            case 15: return "Αρχείο";
                            case 16: return "Έξοδος";
                            case 17: return "Κινήσεις";
                            case 18: return "Παρουσιάσεις";
                            case 19: return "Ράβδος εργαλείων";
                            case 20: return "Ράβδος κατάστασης";
                            case 21: return "Εργαλεία";
                            case 22: return "Διαχείριση δεδομένων";
                            case 23: return "Αναβάθμιση εφαρμογής";

                            case 24: return "Εξαγωγή δεδομένων";
                            case 25: return "Εισαγωγή δεδομένων";
                            case 26: return "Διαγραφή δεδομένων";
                            case 27: return "Διαγραφή δεδομένων και δημιουργία δοκιμαστικών";

                            case 28: return "Παράθυρα";
                            case 29: return "Σε αλληλουχία";
                            case 30: return "Τακτοποίηση κάθετα";
                            case 31: return "Τακτοποίηση οριζόντια";
                            case 32: return "Τακτοποίηση εικονιδίων";
                            case 33: return "Κλείσιμο όλων";

                            case 34: return "Βοήθεια";
                            case 35: return "Περιεχόμενο";
                            case 36: return "Ευρετήριο";
                            case 37: return "Αναζήτηση";
                            case 38: return "Περι του προγράμματος";

                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Error starting application!";
                            case 2: return "Attention !!";
                            case 3: return "New version avaliable !\n\nversion ";
                            case 4: return "\n\nSetup new version from \nMenu 'Tools --> Setup new version ";
                            case 5: return "Edit form ";
                            case 6: return "For programmers !";
                            case 7: return "Close the program ?";
                            case 8: return "Setup new version ";
                            case 9: return "Setup new version ?\n\nAttention !!! Program must 'run' only one time in one computer !\n\nCurent version is ";
                            case 10: return "\nNew version ";
                            case 11: return "There is new version.";
                            case 12: return "Setup interupted !";
                            case 13: return "New version.";
                            case 14: return "Setup canceled !";

                            case 15: return "File";
                            case 16: return "Exit";
                            case 17: return "Edit";
                            case 18: return "Views";
                            case 19: return "Tool bar";
                            case 20: return "Status bar";
                            case 21: return "Tools";
                            case 22: return "Manage data";
                            case 23: return "Updates";

                            case 24: return "Export data";
                            case 25: return "Import data";
                            case 26: return "Delete data";
                            case 27: return "Delete data and create demo data";

                            case 28: return "Windows";
                            case 29: return "Cascade";
                            case 30: return "Tile Vertical";
                            case 31: return "Tile Horizonal";
                            case 32: return "Arange icons";
                            case 33: return "Close all";

                            case 34: return "Help";
                            case 35: return "View help";
                            case 36: return "Index";
                            case 37: return "Search";
                            case 38: return "About box";

                            default: return "String not found";
                        }

                }
            }

        }
    }
}
