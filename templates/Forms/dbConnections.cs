using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace templates.Forms
{
    public partial class dbConnections : def
    {
        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        public dbConnections()
        {
            InitializeComponent();
            setStrings();
            global.dbconnectionsRes = false;
        }

        private void dbConnections_Load(object sender, EventArgs e)
        {
            LoadConnectios();
        }
        private void LoadConnectios()
        {
            string[] filePaths = Directory.GetFiles(@"app_data\connectionstrings");
            this.listBox1.Items.Clear();
            this.listBox1.Items.Add("app_data\\connectionstring.txt");
            for (int i = 0; i < filePaths.Count(); i++)
            {
                this.listBox1.Items.Add(filePaths[i]);
            }
            //new tclass().executeCode(this, BO, EXE);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doTheconnection();
        }

        private void doTheconnection()
        {
            
        if (textBox_code.Text.IndexOf(@"app_data\connectionstrings\") > -1)
            {
                if (MessageBox.Show("Are you sure ?", "choose connection", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            try { File.Delete("app_data\\connectionstring.txt"); }
                            catch { }

                            File.Copy(this.textBox_code.Text, "app_data\\connectionstring.txt");
                        }
                        catch (IOException copyError)
                        {
                            MessageBox.Show(copyError.Message);
                        }
                        global.dbconnectionsRes = true;
                        this.Close();
                    }
                else
                    MessageBox.Show(@"Please select a file from 'app_data\connectionstrings\'", "Wrong selection !");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox_code.Text = "";
            this.textBox_description.Text = "";
            this.textBox_contype.Text = "";
            this.textBox_connectionstring.Text = "";

            this.textBox_code.Text = listBox1.SelectedItem.ToString();
            try
            {
                using (StreamReader sr = new StreamReader(this.textBox_code.Text))
                {
                    this.textBox_description.Text = sr.ReadLine();
                    this.textBox_contype.Text = sr.ReadLine();
                    this.textBox_connectionstring.Text = sr.ReadLine();        
                }
            }
            catch { }        
        }

        private void setStrings()
        {
            toolStripDropDownButton1.Text = _s.G(10);
            refreshToolStripMenuItem.Text = _s.G(4);
            newToolStripMenuItem.Text = _s.G(1);
            ενημέρωσηToolStripMenuItem.Text = _s.G(2);
            deleteToolStripMenuItem.Text = _s.G(3);
            label_code.Text = _s.G(5);
            label_description.Text = _s.G(6);
            label_contype.Text = _s.G(7);
            label_connectionstring.Text = _s.G(8);
            this.Text = _s.G(9);
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
                            case 1: return "Νέα εγγραφή";
                            case 2: return "Επεξεργασία";
                            case 3: return "Διαγραφή";
                            case 4: return "Επιλογή σύνδεσης";
                            case 5: return "Αρχείο";
                            case 6: return "Περιγραφή";
                            case 7: return "Τύπος σύνδεσης";
                            case 8: return "Συμβολοσειρά σύνδεσης";
                            case 9: return "Σύνδεση με την βάση δεδομένων !";
                            case 10: return "Επιλογές";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Insert";
                            case 2: return "Edit";
                            case 3: return "Delete";
                            case 4: return "Select connection";
                            case 5: return "File name";
                            case 6: return "Description";
                            case 7: return "Connection type";
                            case 8: return "Connection string";
                            case 9: return "Database connection !";
                            case 10: return "Options";
                            default: return "String not found";
                        }

                }
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbConnection f = new dbConnection("NEW");
            f.ShowDialog();
            LoadConnectios();
            ClearTexts();
        }

        private void ενημέρωσηToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox_code.Text.IndexOf(@"app_data\connectionstrings\") > -1)
            {
                dbConnection f = new dbConnection(textBox_code.Text);
                f.ShowDialog();
                LoadConnectios();
                ClearTexts();
            }
            else
                MessageBox.Show(@"Please select a file from 'app_data\connectionstrings\'", "Wrong selection !");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox_code.Text.IndexOf(@"app_data\connectionstrings\") > -1)
            {
                if (MessageBox.Show(textBox_code.Text,"Delete Connection !",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                if (MessageBox.Show("Are you sure ? " + textBox_code.Text, "Delete Connection !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    try { 
                        new BusinessObjects.Connections().Delete(textBox_code.Text); 
                        LoadConnectios();
                        ClearTexts();
                    }
                    catch { }
            }
            else
                MessageBox.Show(@"Please select a file from 'app_data\connectionstrings\'", "Wrong selection !");
        }

        private void ClearTexts()
        {
            textBox_code.Text = "";
            textBox_connectionstring.Text = "";
            textBox_contype.Text = "";
            textBox_description.Text = "";
            listBox1.ClearSelected();
        }
    }
}
