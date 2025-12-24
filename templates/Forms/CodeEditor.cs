using System;
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
    public partial class CodeEditor : frmMaster
    {
        
        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        public CodeEditor(string FileName)
        {
            InitializeComponent();
            this.Page1.Text = FileName;
        }

        #region virtual functions, general functions & variables

        public override void LoadDefaults()
        { }

        public override void LoadData()
        { try { this.editControl1.LoadFile(this.Page1.Text, Encoding.UTF8); } catch (Exception ex) { MessageBox.Show(ex.Message, _s.G(3)); } }
        public override void UpdateBtn()
        {
            try {
                string tmp = this.editControl1.Text;
                this.editControl1.Close();

                string tmpNew = "";
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmpNew += tmp.Substring(i, 1);
                    if (tmp.Substring(i, 1).Equals(((char)10).ToString())) tmpNew += ((char)13).ToString(); 
                }

                System.IO.File.WriteAllText(Page1.Text, tmpNew, Encoding.UTF8);
                MessageBox.Show(_s.G(1), _s.G(2));
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, _s.G(3)); } }

        public override void CustomizeMenu()
        {
            ToolStripMenuItem ViewMenuItem20 = new ToolStripMenuItem(_s.G(4));
            ViewMenuItem20.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show(_s.G(5), _s.G(2),
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    try
                    {
                        this.editControl1.Close();
                        System.IO.File.Delete(Page1.Text);
                        Page1.Text = "";
                        MessageBox.Show(_s.G(6), _s.G(2));
                    }
                    catch { MessageBox.Show(_s.G(7), _s.G(2)); }
                    this.Close();
                }
            };

            ToolStripMenuItem ViewMenuItem21 = new ToolStripMenuItem(_s.G(8));
            ViewMenuItem21.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show(_s.G(9), _s.G(8),
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this.editControl1.Close();
                        System.Diagnostics.Process.Start("notepad.exe", this.Page1.Text);
                        Page1.Text = "";
                    }
                    catch { MessageBox.Show(_s.G(7), _s.G(2)); }
                }
            };

            ToolStripMenuItem ViewMenuItem22 = new ToolStripMenuItem(_s.G(10));
            ViewMenuItem22.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show(_s.G(11), _s.G(2),
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    try
                    {
                        this.editControl1.Close();
                        System.IO.File.WriteAllText(Page1.Text, System.IO.File.ReadAllText(Page1.Text, Encoding.UTF8), Encoding.UTF8);
                        LoadData();
                        MessageBox.Show(_s.G(12), _s.G(2));
                    }
                    catch { MessageBox.Show(_s.G(7), _s.G(2)); }
                }
            };

            ToolStripDropDownButton menuView2 = new ToolStripDropDownButton(_s.G(13));
            menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem20, ViewMenuItem21, ViewMenuItem22 });

            // Add to main menu
            menu.Items.AddRange(new ToolStripItem[] { menuView2 });
           

        }

        //private void setFormsGlobals()
        //{
        //    this.Name = "CodeEditor";
        //    this.BO = "AutomationClassLibrary.dll";
        //    this.EXE = Application.ExecutablePath;
        //}

        #endregion

        private void CodeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.editControl1.Close();
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
                            case 1: return "Η αποθήκευση έγινε !!!";
                            case 2: return "Προσοχή !!";
                            case 3: return "Σφάλμα";
                            case 4: return "Διαγραφή του αρχείου";
                            case 5: return "Θα διαγράψετε το αρχείο !! Θέλετε να συνεχίσετε ;";
                            case 6: return "H διαγραφή έγινε !!!";
                            case 7: return "Κάτι πήγε στραβά !!!";
                            case 8: return "Άνοιγμα του αρχείου με το NotePad";
                            case 9: return "Θέλετε να ανοίξετε το αρχείο με το notepad\nΟ editor θα κλείσει το αρχείο !!\nΘέλετε να συνεχίσετε; ";
                            case 10: return "Μετασχηματισμός σε UTF8";
                            case 11: return "Θα μετασχηματίσετε το αρχείο σε UTF-8 (με δυνατότητα για Ελληνικούς χαρακτήρες) !! Θέλετε να συνεχίσετε ;";
                            case 12: return "Ο μετασχηματισμός σε UTF-8 έγινε !!!";
                            case 13: return "Ενέργειες";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Update done !!!";
                            case 2: return "Attention !!";
                            case 3: return "Error";
                            case 4: return "Delete file";
                            case 5: return "Delete file !! Continue ?";
                            case 6: return "Delete done !!!";
                            case 7: return "Error !!!";
                            case 8: return "Open file with NotePad";
                            case 9: return "Open file with notepad\nEditor will close the file !!\nContinue ? ";
                            case 10: return "Convert to UTF8";
                            case 11: return "Convert to UTF-8 !! Continue ?";
                            case 12: return "Convert to UTF-8 done !!!";
                            case 13: return "Edit";
                            default: return "String not found";
                        }

                }
            }

        }
    }
}
