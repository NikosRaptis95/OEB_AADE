using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class frmKAEFl : templates.Forms.frmMaster
    {
        private string id;
        private string auditTransactionId;
        public frmKAEFl(string id_, string auditTransactionId_)
        {
            this.id = id_;
            this.auditTransactionId = auditTransactionId_;
            InitializeComponent();
            setFormsGlobals();
        }
        public frmKAEFl()
        {
            this.id = "";
            InitializeComponent();
            setFormsGlobals();
        }

        #region virtual functions, general functions & variables

        public override void LoadDefaults()
        {
            
        }

        KAEFl dataclass = new KAEFl();
        public override void LoadData()
        {
            AADEFl aade = new AADEFl();
            aade.Read(auditTransactionId);            

            if (id.ToUpper().Equals("NEW"))
            {                
                this.Text = "Νέα KAE ! - με αρ.Πρωτοκόλου:" + aade.Fields.auditProtocol; //΄Ορίζω τον τίτλο του παραθύρου
                this.megaText_id.megaTextBox.Text = new AADEFl().newCode();
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
            {
                string Res = dataclass.Read(id); // Διαβάζω τα δεδομένα
                this.Text = dataclass.Fields.auditRecord.auditProtocol.ToString();
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    this.Text = "Μεταβολή ΚΑΕ ! - με αρ. πρωτοκόλου:" + aade.Fields.auditProtocol; //΄Ορίζω τον τίτλο του παραθύρου
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
            if (id.Equals("new")){
                //dataclass.Fields.auditRecord.auditTransactionId = auditTransactionId; // ορίζω το AuditRecordid της εγγραφής
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
                ToolStripMenuItem ViewMenuItem20 = new ToolStripMenuItem("Υπολογισμός Συνόλου !");
                ViewMenuItem20.Click += (object sender, EventArgs e) =>
                {
                    AFMKIN afmkin = new AFMKIN();
                    double s = afmkin.ReadSUMΚΑΕ(id);
                    megaText_amount.megaTextBox.Text = s.ToString("N2");
                };
                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ενέργειες");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem20 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
            }
        }

        private void setFormsGlobals()
        {
            this.Name = "frmKAEfl";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            if (id.ToUpper().Equals("NEW"))
                this.Text = "Μεταβίβαση - Νέα KAE !"; //΄Ορίζω τον τίτλο του παραθύρου            
            else
                this.Text = "Μεταβολή KAE"; //΄Ορίζω τον τίτλο του παραθύρου
        }

        //S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        //class S
        //{
        //    private string lang = "gr";
        //    public S(string _lang) { lang = _lang; }

        //    public string G(int id)
        //    {
        //        switch (lang)
        //        {
        //            case "gr":
        //                switch (id)
        //                {
        //                    case 1: return "Πελάτης";
        //                    case 2: return "Πελάτες";
        //                    case 3: return "΄Πελατών";
        //                    case 4: return "Προμηθευτής";
        //                    case 5: return "Προμηθευτές";
        //                    case 6: return "Προμηθευτών";
        //                    default: return "Δεν βρέθηκε η συμβολοσειρά";
        //                }
        //            default:
        //                switch (id)
        //                {
        //                    case 1: return "Customer";
        //                    case 2: return "Customers";
        //                    case 3: return "Customers";
        //                    case 4: return "Supplier";
        //                    case 5: return "Suppliers";
        //                    case 6: return "Suppliers";
        //                    default: return "String not found";
        //                }
        //        }
        //    }

        //}
        #endregion



    }
}
