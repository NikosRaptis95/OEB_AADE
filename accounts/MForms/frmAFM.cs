using accountsClassLibrary;
using Syncfusion.Windows.Forms.Tools.XPMenus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DesktopBusiness.MForms
{
    public partial class frmAFM : templates.Forms.frmMaster
    {
        private string id;
        private string auditTransactionId;
        string level = "Basic";
        public frmAFM()
        {
            InitializeComponent();
        }
        public frmAFM(string id_, string auditTransactionId_)
        {
            this.id = id_;
            this.auditTransactionId = auditTransactionId_;
            InitializeComponent();
            level = File.ReadAllText(@"params\level.param");
            level = level.Trim();
            setFormsGlobals();
        }


        #region virtual functions, general functions & variables

        public override void LoadDefaults()
        {

        }

        AFMFl dataclass = new AFMFl();
        AADEFl aade = new AADEFl();
        public override void LoadData()
        {
            
            aade.Read(auditTransactionId);

            if (id.ToUpper().Equals("NEW"))
            {
                this.Text = "Νέο ΑΦΜ ! - με αρ.Πρωτοκόλου:" + aade.Fields.auditProtocol; //΄Ορίζω τον τίτλο του παραθύρου
                this.megaText_id.megaTextBox.Text = new AADEFl().newCode();
                this.megaText_status.megaTextBox.Text = "0"; // Νέα εγγραφή με status 0
                this.megaText_DateTimeSend.megaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
            {
                string Res = dataclass.Read(id); // Διαβάζω τα δεδομένα
                this.Text = dataclass.Fields.auditRecord.auditProtocol.ToString();
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    this.Text = "Μεταβολή ΑΦΜ ! - με αρ. πρωτοκόλου:" + aade.Fields.auditProtocol; //΄Ορίζω τον τίτλο του παραθύρου
                    base.LoadData(dataclass.Fields); // Μεταφέρω τα δεδομένα στα αντικείμενα της φόρμας
                    megaText_id.Enabled = false; /* primary key enable = false για το edit */
                }
            }
        }
        public override void UpdateBtn()
        {
            object objectdata = base.UpdateBtn(dataclass.Fields); // μεταφέρω τις τιμές των αντικειμένων σε ένα γενικό αντικείμενο 
            foreach (var property in objectdata.GetType().GetProperties())   // μεταφέρω τις τιμές απο το γενικό αντικείμενο στα πεδία της κλάσης
                dataclass.Fields.GetType().GetProperty(property.Name).SetValue(dataclass.Fields, property.GetValue(objectdata));
            string res = "";
            if (id.Equals("new"))
            {
                res = dataclass.Insert(auditTransactionId);
            } // νεα εγγραφή
            else res = dataclass.Update(auditTransactionId);  // σώζω 
            if (res.Length == 0) this.Close(); // έξοδος
            else MessageBox.Show(res, "Σφάλμα !"); // παρουσίαση σφάλματος στο update
        }
        public override void CustomizeMenu()
        {
            // Παρουσιάσεις           
            {
                ToolStripMenuItem ViewMenuItem20 = new ToolStripMenuItem("Χρηματικά Ποσά !");
                ViewMenuItem20.Click += (object sender, EventArgs e) =>
                {
                    CallForms.CallAFMΚΙΝ childForm = new CallForms.CallAFMΚΙΝ(id);
                    childForm.MdiParent = this.ParentForm;
                    childForm.Show();
                };

                ToolStripMenuItem ViewMenuItem21 = new ToolStripMenuItem("Δημιουργία Συνόλων !");
                ViewMenuItem21.Click += (object sender, EventArgs e) =>
                {
                    AFMKIN afmkin = new AFMKIN();
                    double s = afmkin.ReadSUMAFM(id);
                    megaText_amount.megaTextBox.Text = s.ToString("N2");
                };

                ToolStripMenuItem ViewMenuItem211 = new ToolStripMenuItem("Ξεκλείδωμα πεδίων !");
                ViewMenuItem211.Click += (object sender, EventArgs e) =>
                {
                    megaText_sendXML.megaTextBox.ReadOnly = false;  
                    megaText_ansXML.megaTextBox.ReadOnly = false;
                };

                ToolStripMenuItem ViewMenuItem22 = new ToolStripMenuItem("Δημιουργία XML & Αποστολή !");
                ViewMenuItem22.Click += async (object sender, EventArgs e) =>
                {
                    if (MessageBox.Show("Θέλετε να δημιουργηθεί το XML και να αποσταλεί στην ΑΑΔΕ;", "Επιβεβαίωση", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    else
                    {
                        Send_xml(PrepareXML.prepareXML(id), id);
                        LoadData(); // ξαναφορτώνω τα δεδομένα                        
                    }
                };
                ToolStripMenuItem ViewMenuItem23 = new ToolStripMenuItem("XML Editor !");
                ViewMenuItem23.Click += (object sender, EventArgs e) =>
                {
                    xmlEditor f = new xmlEditor();
                    f.id = this.id;
                    f.xmlText.Text = PrepareXML.prepareXML(megaText_id.megaTextBox.Text);
                    f.ShowDialog();
                };
                ToolStripMenuItem ViewMenuItem24 = new ToolStripMenuItem("Μορφοποίηση !");
                AFMFl afm = new AFMFl();
                afm.Read(id);
                ViewMenuItem24.Click += (object sender, EventArgs e) =>
                {
                    if (afm.Fields.auditRecord.Status.Name.Equals("retrieveKedeAmount")) { megaText_SynAFM.megaTextBox.Text = CleanAndWrapWithAfm(megaText_SynAFM.megaTextBox.Text); }
                    if (afm.Fields.auditRecord.Status.Name.Equals("retrieveNames")) { megaText_SynAFM.megaTextBox.Text = ProcessMultiLineYpogrString_PureSequence(megaText_SynAFM.megaTextBox.Text); }
                    //UpdateBtn();
                    MessageBox.Show("Έγινε Μορφοποίηση  !", afm.Fields.auditRecord.Status.Name);
                };

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ενέργειες");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem20, ViewMenuItem21, ViewMenuItem211, ViewMenuItem23, ViewMenuItem22, ViewMenuItem24 });

                menuView2.DropDownItems.Insert(2, new ToolStripSeparator());
                menuView2.DropDownItems.Insert(4, new ToolStripSeparator());
                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });

                afm = new AFMFl();
                afm.Read(id);
                if (afm.Fields.auditRecord.Status.Name.Equals("retrieveNames"))
                {
                    ViewMenuItem20.Enabled = false;
                    ViewMenuItem21.Enabled = false;
                    //ViewMenuItem211.Enabled = false;
                    //ViewMenuItem22.Enabled = false;
                    megaText_amount.Visible = false;

                }
                
                if (id.ToUpper().Equals("NEW"))
                {
                    ViewMenuItem20.Enabled = false;
                    ViewMenuItem21.Enabled = false;
                    //ViewMenuItem211.Enabled = false;
                    ViewMenuItem23.Enabled = false;
                    ViewMenuItem22.Enabled = false;
                    ViewMenuItem24.Enabled = false;
                }

            }
        }

        private void setFormsGlobals()
        {
            this.Name = "frmAFM";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            if (id.ToUpper().Equals("NEW"))
                this.Text = "Νέο ΑΦΜ !"; //΄Ορίζω τον τίτλο του παραθύρου            
            else
                this.Text = "Μεταβολή ΑΦΜ"; //΄Ορίζω τον τίτλο του παραθύρου

            megaText_anstext.megaTextBox.ReadOnly = true;
            megaText_anstext.megaTextBox.WordWrap = false;
            megaText_anstext.megaTextBox.ScrollBars = ScrollBars.Both;

            megaText_ansXML.megaTextBox.ReadOnly = true;
            megaText_ansXML.megaTextBox.WordWrap = false;
            megaText_ansXML.megaTextBox.ScrollBars = ScrollBars.Both;

            megaText_sendXML.megaTextBox.ReadOnly = true;
            megaText_sendXML.megaTextBox.WordWrap = false;
            megaText_sendXML.megaTextBox.ScrollBars = ScrollBars.Both;

            if (level.ToUpper().Equals("BASIC"))
            {
                AADEFl aade = new AADEFl();
                aade.Read(auditTransactionId);
                if (aade.Fields.Status.Name.Equals("retrieveNames"))
                {
                    megaText_AFM.Visible = false;
                    megaText_amount.Visible = false;

                }
                //if (id.ToUpper().Equals("NEW") && aade.Fields.Status.Name.Equals("retrieveNames")) 
                //{  } 
                //else updateToolStripMenuItem.Enabled = false;
            }
            
        }

        private async void Send_xml(string xmlfile, string id_)
        {

            SendXML xmlSender = new SendXML();
            try
            {
                //string result = await xmlSender.SendXML(xmlfile, id_);
                bool ok = false;
                string result = await xmlSender.SendXML(xmlfile, id);
                if (result.IndexOf("><errorRecord/><") > -1)
                {
                    ok = true;
                }
                List<List<string>> xmlres = new List<List<string>>();


                xmlres = new bhtaFramework.bhtaFramework().XmlToList(result);
                AFMFl afm = new AFMFl();
                afm.Read(id_);
                xmlres.Add(new List<string> { "service", afm.Fields.auditRecord.Status.Name });

                afm.Fields.sendXML = xmlfile;
                afm.Fields.ansXML = result;
                List<string> TMP = new bhtaFramework.bhtaFramework().ExtractSubsets(result, "<faultstring>", "</faultstring>");
                List<string> TMP2 = new bhtaFramework.bhtaFramework().ExtractSubsets(result, "<errorDescr>", "</errorDescr>");
                string errordesc = "";
                if (TMP.Count > 0) errordesc = "Error: " + TMP[0];
                if (TMP2.Count > 0 && TMP.Count == 0) errordesc = "Error: " + TMP2[0];

                afm.Fields.anstext = errordesc.Replace("<", "");
                afm.Fields.id = id_;
                afm.Fields.DateTimeSend = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ").ToString();
                string displaystring = "";
                for (int i = 0; i < xmlres.Count; i++)
                {
                    displaystring += xmlres[i][0] + "=" + xmlres[i][1] + "\r\n";
                    if (xmlres[i].Count > 1 && xmlres[i][0].IndexOf("errorRecord") > -1)
                    {
                        afm.Fields.status = xmlres[i][1].Length.ToString();
                    }
                }
                //if (afm.Fields.status.Equals("0"))
                //    afm.Fields.status = "1";
                //else
                //    afm.Fields.status = "2";
                if (ok)
                    afm.Fields.status = "1";
                else
                    afm.Fields.status = "2";
                afm.UpdateAns();
                string title = "";

                if (afm.Fields.status.Equals("2"))
                    title = "SOAP Response - Υπήρξε σφάλμα !";
                else
                    title = "SOAP Response - Η αποστολη έγινε !";

                MessageBox.Show(displaystring, title);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion              

        public string CleanAndWrapWithAfm(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return string.Empty;
            }

            // 1. Remove anything that looks like an XML tag (e.g., <tag>, </tag>, <tag attribute="value"/>)
            // Regex: <.*?> matches a '<', followed by any characters, followed by a '>' (non-greedily).
            string cleanedContent = Regex.Replace(inputString, "<.*?>", string.Empty);

            // 2. Process the cleaned content line by line
            // Use StringSplitOptions.RemoveEmptyEntries to ignore completely blank lines
            string[] lines = cleanedContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder result = new StringBuilder();

            foreach (string line in lines)
            {
                // Trim to remove leading/trailing whitespace (e.g., spaces or tabs) from the line itself
                string trimmedLine = line.Trim();

                // Only process lines that are not empty after trimming
                if (!string.IsNullOrEmpty(trimmedLine))
                {
                    // 3. Wrap the cleaned content of the line with <afm> tags
                    result.AppendLine($"<afm>{trimmedLine}</afm>");
                }
            }

            // Return the final string, removing any trailing newline from the last append
            return result.ToString().TrimEnd('\r', '\n');
        }

        public string ProcessMultiLineYpogrString_PureSequence(string multiLineInput)
        {
            if (string.IsNullOrEmpty(multiLineInput))
            {
                return string.Empty;
            }

            // Διαχωρίζουμε το αρχικό string σε γραμμές
            string[] lines = multiLineInput
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToArray();

            StringBuilder finalOutput = new StringBuilder();

            foreach (string line in lines)
            {
                // Διαχωρίζουμε τη γραμμή με βάση το κενό διάστημα.
                string[] fields = line.Split(null as char[], StringSplitOptions.RemoveEmptyEntries);

                // Ελέγχουμε αν έχουμε τουλάχιστον 3 πεδία
                if (fields.Length >= 3)
                {
                    // Καθαρίζουμε τα πεδία
                    string afm = CleanInput(fields[0]);
                    string onoma = CleanInput(fields[1]);
                    string eponymo = CleanInput(fields[2]);

                    // Προσθέτουμε το μπλοκ <YPOGR> στο StringBuilder
                    finalOutput.AppendLine(CreateYpogrXml(afm, onoma, eponymo));
                }
            }
            return finalOutput.ToString().Trim();
        }

        private readonly Regex XmlTagRegex = new Regex("<.*?>", RegexOptions.Compiled);
        private string CleanInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return XmlTagRegex.Replace(input, string.Empty).Trim();
        }
        private string CreateYpogrXml(string afm, string onoma, string eponymo)
        {
            string nl = Environment.NewLine;
            // Δεν προσθέτουμε tabs, για να έχουμε πιο "καθαρή" εμφάνιση
            return
    $@"<YPOGR>
<afmYpogr>{afm}</afmYpogr>
<onomaYpogr>{onoma}</onomaYpogr>
<eponymoYpogr>{eponymo}</eponymoYpogr>
</YPOGR>";
            // {nl}
        }

        private void megaText_sendXML_Load(object sender, EventArgs e)
        {
           
        }
    }
}


