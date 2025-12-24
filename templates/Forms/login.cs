using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;

namespace templates.Forms
{
    public partial class login : def
    {
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "MegaSoftDefaultUser";
        const string keyName = userRoot + "\\" + subkey;

        private List<user> users;

        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        public login(List<user> users_)
        {
            InitializeComponent();
            _CustomizeMenu();
            this.CaptionLabels[0].LabelMouseDown += Def_LabelMouseDown;
            Act = false;
            global.loginRes = false;
            users = users_;            
        }

        private void loginFrm_Load(object sender, EventArgs e)
        {
            this.Text = Application.CompanyName + " - " + Application.ProductName;
            getConnectionInformation();
            LoadFilPinCombo();
            //new tclass().executeCode(this, BO, EXE);
        }

        private void LoadFilPinCombo()
        {         
            textBox_User.DisplayMember = "username";
            textBox_User.ValueMember = "password";            
            textBox_User.DataSource = users;
            string un = (string)Registry.GetValue(keyName, Application.ProductName, "");
            try {for (int i = 0; i < textBox_User.Items.Count; i++)
                     if (users[i].username.Equals(un)) { textBox_User.SelectedIndex = i; break; }                                    
            }
            catch { }            
        }
 
        private void getConnectionInformation()
        {
            try
            {
                using (StreamReader sr = new StreamReader("app_data\\connectionstring.txt"))
                {
                    try
                    { File.Delete(@"app_data\Application.txt"); }
                    catch { }
                    
                    this.Label1.Text = sr.ReadLine();
                    sr.ReadLine();
                    string cs = sr.ReadLine();
                    int idx  = cs.IndexOf(new bhtaFramework.bhtaFramework().SupportURL.Replace("http://", "").Replace("https://", ""));
                    if(idx > -1)
                    {
                        string application = "";
                        try
                        {
                            application = cs.Substring(idx + 32, cs.Length - idx - 32);
                            application = application.Substring(0, application.IndexOf(";"));
                        }
                        catch 
                        { }
                        this.Label1.Text = "Application=" + application;
                        try { File.WriteAllText(@"app_data\Application.txt", application); }
                        catch { }
                    }
                }
            }
            catch { }
        }
       
        private void button2_Click(object sender, EventArgs e)
        { this.Close(); }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (users.Count < 1)
                { global.loginRes = true;
                  MessageBox.Show(_s.G(12), _s.G(2));
                }
                else
                {
                    global.User = users[textBox_User.SelectedIndex].username.ToString();
                    global.loginRes = true;
                    try { Registry.SetValue(keyName, Application.ProductName, global.User); }
                    catch { }
                }
            }
            catch { }

            this.Close();                      
        }

        private void connections_Click(object sender, EventArgs e)
        {
            Form MyForm = new templates.Forms.dbConnections();
            MyForm.ShowDialog();
            if (global.dbconnectionsRes) {
                MessageBox.Show(_s.G(1), _s.G(2));
                this.Close(); }            
        }

        private Boolean Act = false;
        private void γιαΠρογραμματιστέςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (γιαΠρογραμματιστέςToolStripMenuItem.Checked) {
                    γιαΠρογραμματιστέςToolStripMenuItem.Checked = false;
                    this.CaptionLabels[0].Text = "iLake"; System.IO.File.Delete(@"customization\name.programmer");
                    Act = false;
                }
                else
                {
                    γιαΠρογραμματιστέςToolStripMenuItem.Checked = true; this.CaptionLabels[0].Text = "C#";
                    using (FileStream fs = File.Create(@"customization\name.programmer"))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(System.Guid.NewGuid().ToString());
                        fs.Write(info, 0, info.Length);
                    }
                    Act = true;
                }
            }
            catch { }
        }     

        private void Def_LabelMouseDown(object sender, LabelMouseDownEventArgs e)
        {
            if(Act)
                if (MessageBox.Show(_s.G(3) + this.Name + " - C# ;", _s.G(4), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    new CodeEditor(@"customization\Code\" + this.Name + ".cs").ShowDialog();
        }

        private void _CustomizeMenu()
        {
            toolStripDropDownButton5.Text = _s.G(6);
            connections.Text = _s.G(5);
            γιαΠρογραμματιστέςToolStripMenuItem.Text = _s.G(4);
            button1.Text = _s.G(8);
            button2.Text = _s.G(7);
            label_User.Text = _s.G(9);
            label2.Text = _s.G(10);
            this.Text = _s.G(11);        }
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
                            case 1: return "Ή εφαρμογή θα κλείσει, κάντε επανεκκίνηση !";
                            case 2: return "Προσοχή !!";
                            case 3: return "Θέλετε να επεξεργαστείτε την φόρμα ";
                            case 4: return "Για προγραμματιστές !";
                            case 5: return "Συνδέσεις";
                            case 6: return "Ρυθμίσεις";
                            case 7: return "Έξοδος";
                            case 8: return "Είσοδος";
                            case 9: return "Χρήστης";
                            case 10: return "Κωδικός";
                            case 11: return "Είσοδος στην εφαρμογή";
                            case 12: return "Δεν υπάρχει ενεργός χρήστης στην εφαρμογή !\nΠρέπει να ανοίξετε έναν !";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Program will close, please restart !";
                            case 2: return "Attention !!";
                            case 3: return "Do you want to edit the form ";
                            case 4: return "For programmers !";
                            case 5: return "Connections";
                            case 6: return "Options";
                            case 7: return "Exit";
                            case 8: return "Login";
                            case 9: return "User";
                            case 10: return "Password";
                            case 11: return "Login";
                            case 12: return "There is no user !\nYou have to add one !";
                            default: return "String not found";
                        }

                }
            }

        }
    }
}
