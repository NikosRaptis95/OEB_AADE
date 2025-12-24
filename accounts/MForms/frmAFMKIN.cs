using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class frmAFMKIN : templates.Forms.frmMaster
    {
        private string id;
        private string AFMId;
        string level = "Basic";
        public frmAFMKIN()
        {
            InitializeComponent();
        }
       
        public frmAFMKIN(string id_,string AFMId_)
        {
            this.id = id_;
            this.AFMId = AFMId_;            
            InitializeComponent();
            level = File.ReadAllText(@"params\level.param");
            level = level.Trim();
            setFormsGlobals();
        }

        
        #region virtual functions, general functions & variables

        public override void LoadDefaults()
        {
            LoadCombos();
        }
        
        AFMKIN dataclass = new AFMKIN();

        public override void LoadData()
        {
            
            //AFMFl afm = new AFMFl();
            //afm.Read(AFMId);

            if (id.ToUpper().Equals("NEW"))
            {
                this.Text = "Νέο Χρηματικό Ποσό στο ΑΦΜ - @AFM - με αρ.Πρωτοκόλου:".Replace("@AFM", dataclass.Fields.AFMid.AFM.ToString()); //΄Ορίζω τον τίτλο του παραθύρου
                this.megaText_id.megaTextBox.Text = new AFMKIN().newCode();
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
            {
                string Res = dataclass.Read(id); // Διαβάζω τα δεδομένα
                this.Text = "Μεταβολή ΑΦΜ:"+dataclass.Fields.AFMid.AFM.ToString()+ "Αρ. Πρωτοκόλου:"+ dataclass.Fields.AFMid.auditRecord.auditProtocol.ToString();
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    //this.Text = "Μεταβολή ΑΦΜ Παραγωγού ! - με αρ. πρωτοκόλου:" + aade.Fields.auditProtocol; //΄Ορίζω τον τίτλο του παραθύρου
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
                res = dataclass.Insert(AFMId);
            } // νεα εγγραφή
            else res = dataclass.Update(AFMId);  // σώζω 
            if (res.Length == 0) this.Close(); // έξοδος
            else MessageBox.Show(res, "Σφάλμα !"); // παρουσίαση σφάλματος στο update
        }
        public override void CustomizeMenu()
        {

        }

        private void setFormsGlobals()
        {
            this.Name = "frmAFM";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            if (id.ToUpper().Equals("NEW"))
            {
                this.Text = "Νέο ΑΦΜ !"; //΄Ορίζω τον τίτλο του παραθύρου            
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
                this.Text = "Μεταβολή ΑΦΜ"; //΄Ορίζω τον τίτλο του παραθύρου

            if (level.ToUpper().Equals("BASIC"))
            {
                updateToolStripMenuItem.Enabled = false;
            }
        }

        private void LoadCombos()
        {
           
            LoadKAECombo(megaCombo_KAEid.megaComboBox);
            //LoadParPinCombo(textBox_Status, accountsClassLibrary.ParPin.TypeOfPar.Status);
            //loadAitiologia();
            //loadSeira();
        }
        private void LoadKAECombo(ComboBox MyCombo)
        {
            MyCombo.DisplayMember = "Name";
            MyCombo.ValueMember = "id";
            accountsClassLibrary.KAEFl mcp = new accountsClassLibrary.KAEFl();
            AFMFl afm = new AFMFl();
            afm.Read(AFMId);
            MyCombo.DataSource = mcp.ReadZoomCombo(afm.Fields.auditRecord.auditTransactionId);
        }

        #endregion


    }
}
