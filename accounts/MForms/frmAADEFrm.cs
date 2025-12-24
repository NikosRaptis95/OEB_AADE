using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class frmAADEFrm : templates.Forms.frmMaster
    {
        private string id;
        public frmAADEFrm(string id_)
        {
            InitializeComponent();
            id = id_;
            setFormsGlobals(); 
        
        }

        #region virtual functions, general functions & variables

        public override void LoadDefaults()
        {
            // Όρίζω τιμές στα αντικείμενα της φόρμας κατα το form load
            ParPin par = new ParPin();
            megaCombo_Status.DataSource = par.ReadZoom(ParPin.TypeOfPar.AADEServices);
        }

        AADEFl dataclass = new AADEFl();
        public override void LoadData()
        {
            if (id.ToUpper().Equals("NEW"))
            {
                this.Text = "Νέα Εγγραφή - Μεταβίβασης Είσπραξεων !"; //΄Ορίζω τον τίτλο του παραθύρου 
                this.megaText_id.megaTextBox.Text = new AADEFl().newCode();
                megaText_auditUserIp.megaTextBox.Text = new bhtaFramework.bhtaFramework().GetLocalIPAddress();
                megaDate_auditTransactionDate.megaDateBox.Value = DateTime.Now;
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
            {
                string Res = dataclass.Read(id); // Διαβάζω τα δεδομένα
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    this.Text = "Μεταβολή Προβολή - Μεταβίβασης Εισπράξεων !"; //΄Ορίζω τον τίτλο του παραθύρου
                    base.LoadData(dataclass.Fields); // Μεταφαίρω τα δεδομένα στα αντικείμενα της φόρμας
                    megaText_id.Enabled = false; /* primary key enable = false για το edit */
                }
            }
            displayRetriveNamesLabels();

        }
        public override void UpdateBtn()
        {
            object objectdata = base.UpdateBtn(dataclass.Fields); // μεταφέρω τις τιμές των αντικειμένων σε ένα γενικό αντικείμενο 
            foreach (var property in objectdata.GetType().GetProperties())   // μεταφέρω τις τιμές απο το γενικό αντικείμενο στα πεδία της κλάσης
                dataclass.Fields.GetType().GetProperty(property.Name).SetValue(dataclass.Fields, property.GetValue(objectdata));
            string res = "";
            if (id.Equals("new")) res = dataclass.Insert(); // νεα εγγραφή
            else res = dataclass.Update();  // σώζω 
            if (res.Length == 0) this.Close(); // έξοδος
            else MessageBox.Show(res, "Σφάλμα !"); // παρουσίαση σφάλματος στο update
        }
        public override void CustomizeMenu()
        {
             string serviceindex = megaCombo_Status.megaComboBox.SelectedIndex.ToString();
            // Παρουσιάσεις           
            {
                ToolStripMenuItem ViewMenuItem20 = new ToolStripMenuItem("ΚΑΕ !");
                ViewMenuItem20.Click += (object sender, EventArgs e) =>
                {
                    CallForms.CallKAE childForm = new CallForms.CallKAE(id);
                    childForm.MdiParent = this.ParentForm;
                    childForm.Show();
                };

                ToolStripMenuItem ViewMenuItem21 = new ToolStripMenuItem("ΑΦΜ συναλλασσόμενων !");
                ViewMenuItem21.Click += (object sender, EventArgs e) =>
                {
                    CallForms.CallAFM childForm = new CallForms.CallAFM(id);
                    childForm.MdiParent = this.ParentForm;
                    childForm.Show();
                };

                ToolStripMenuItem ViewMenuItem22 = new ToolStripMenuItem("Υπολογισμός Συνόλου !");
                ViewMenuItem22.Click += (object sender, EventArgs e) =>
                {
                    AFMFl afmfl = new AFMFl();
                    double s = afmfl.ReadSUM(id);
                    megaText_synolo.megaTextBox.Text = s.ToString("N2");
                };

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ενέργειες");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem20, ViewMenuItem21, ViewMenuItem22 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
            }

            // Ρυθμίσεις         
            {
                ToolStripMenuItem ViewMenuItem23 = new ToolStripMenuItem("AmountRequest !");
                ViewMenuItem23.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "retrieveKedeAmountRequest.param".Replace(".", megaCombo_Status.megaComboBox.SelectedIndex.ToString() + ".");
                    paramEditor.ShowDialog();
                };

                ToolStripMenuItem ViewMenuItem24 = new ToolStripMenuItem("AmountInputRecord !");
                ViewMenuItem24.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "retrieveKedeAmountInputRecord.param".Replace(".", megaCombo_Status.megaComboBox.SelectedIndex.ToString()+".");
                    paramEditor.ShowDialog();
                };

                ToolStripMenuItem ViewMenuItem25 = new ToolStripMenuItem("auditRecord !");
                ViewMenuItem25.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "auditRecord.param".Replace(".", megaCombo_Status.megaComboBox.SelectedIndex.ToString() + ".");
                    paramEditor.ShowDialog();
                };
                ToolStripMenuItem ViewMenuItem26 = new ToolStripMenuItem("SynFPA !");
                ViewMenuItem26.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "SynFPA.param".Replace(".", megaCombo_Status.megaComboBox.SelectedIndex.ToString() + ".");
                    paramEditor.ShowDialog();
                };


                ToolStripDropDownButton menuView3 = new ToolStripDropDownButton("Παράμετροι");

                menuView3.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem23, ViewMenuItem24, ViewMenuItem25, ViewMenuItem26 });
                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView3 });
            }

            // Documents_PDF           
            {
                ToolStripMenuItem ViewMenuItem29 = new ToolStripMenuItem("manual_EDA_v4 !");
                ViewMenuItem29.Click += (object sender, EventArgs e) =>
                {
                    LoadPDF("manual_EDA_v4");
                };
                ToolStripMenuItem ViewMenuItem30 = new ToolStripMenuItem("client_specs_v1.5_0 !");
                ViewMenuItem30.Click += (object sender, EventArgs e) =>
                {
                    LoadPDF("KED_client_specs_v1.5_0");
                };

                ToolStripMenuItem ViewMenuItem31 = new ToolStripMenuItem("Progress_Service_K_v_1.01 !");
                ViewMenuItem31.Click += (object sender, EventArgs e) =>
                {
                    LoadPDF("Kede_Progress_Service_K_v_1.01");
                };

                ToolStripMenuItem ViewMenuItem32 = new ToolStripMenuItem("Progress_Service_K_v_1.02 !");
                ViewMenuItem32.Click += (object sender, EventArgs e) =>
                {
                    LoadPDF("Kede_Progress_Service_K_v_1.02");
                };

                ToolStripMenuItem ViewMenuItem33 = new ToolStripMenuItem("Delete_Amount_Service_K_v_0.99 !");
                ViewMenuItem33.Click += (object sender, EventArgs e) =>
                {
                    LoadPDF("Kede_Delete_Amount_Service_K_v_0.99");
                };

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Αρχεία Προδιαγραφών");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem29, ViewMenuItem30, ViewMenuItem31, ViewMenuItem32, ViewMenuItem33 });
                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
            }

        }

       private void setFormsGlobals()
        {
            this.Name = "frmAADEFrm";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            if (id.ToUpper().Equals("NEW"))
                this.Text = "Μεταβίβαση - Νέα είσπραξη !"; //΄Ορίζω τον τίτλο του παραθύρου            
            else
                this.Text = "Μεταβίβαση"; //΄Ορίζω τον τίτλο του παραθύρου
        }

        private void LoadPDF(string pdfFilePath)
        {
            try
            {
                pdfFilePath = @"Documents\"+pdfFilePath+".pdf";
                Process.Start(new ProcessStartInfo(pdfFilePath)
                {
                    UseShellExecute = true 
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Σφάλμα κατά το άνοιγμα του PDF: {ex.Message}");
            }
        }



        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayRetriveNamesLabels();
        }

        private void displayRetriveNamesLabels()
        {
            
                megaText_afmYpogr.megaLabel.Text = "ΑΦΜ Υπογράφοντος";
                megaText_nameYpogr.Visible = true;
                megaText_lastDayRule.megaLabel.Text = "Κανόνας 1.τελευταίας εργάσιμης / 2.τακτής ημερομηνίας (1 ή 2)";
                megaText_insFrequency.megaLabel.Text = "Περιοδικότητα δόσεων (π.χ. 1 = κάθε μήνα, 2 = κάθε δίμηνο)";
                megaText_apofNoEtos.megaLabel.Text = "Αριθμός απόφασης – Έτος";
                megaText_ypiresiaDescr.megaLabel.Text = "Περιγραφή Υπηρεσίας";
                megaText_inSctCod.megaLabel.Text = "Τύπος πηγής (98)";
                megaText_inMctCod.megaLabel.Text = "Είδος Χρηματικού Καταλόγου (1)";
                megaText_txtCod.megaLabel.Text = "Είδος Φόρου";
            

            if (megaCombo_Status.megaComboBox.SelectedIndex.ToString().Equals("5"))
            {
                megaText_afmYpogr.megaLabel.Text = "Πλήθος Υπογραφόντων";
                megaText_nameYpogr.Visible = false;               
            }
            
            if (megaCombo_Status.megaComboBox.SelectedIndex.ToString().Equals("3") || megaCombo_Status.megaComboBox.SelectedIndex.ToString().Equals("4"))
            {
                megaText_lastDayRule.megaLabel.Text = "ΑΦΕΚ Διαγραφής 1.με επιστροφής 2.χωρίς επιστροφή";
                megaText_insFrequency.megaLabel.Text = "Τυπος Απόφασης (1. Απ.Δικαστηρίου ή 4.Λοιπά)";
                megaText_apofNoEtos.megaLabel.Text = "Έτος απόφασης";
                megaText_ypiresiaDescr.megaLabel.Text = "Αριθμός απόφασης";                
                megaText_inSctCod.megaLabel.Text = "Αρ.Γραμμής Χρηματικού καταλόγου";
                megaText_inMctCod.megaLabel.Text = "Αρ.Χρηματικού καταλόγου(ΧΚ)";
                megaText_txtCod.megaLabel.Text = "Αρ.Τριπλότυπου βεβαίωσης(ΑΤΒ)";
            }

        }

        private void megaCombo_Status_Load(object sender, EventArgs e)
        {

        }

        private void megaText_apofNoEtos_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox1.Text = "Εκπληκτικο";
        }
    }
}
