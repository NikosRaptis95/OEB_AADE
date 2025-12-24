using accountsClassLibrary;
using Microsoft.ConsultingServices.HtmlEditor;
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
    public partial class frmTimi : templates.Forms.frmMaster
    {
        public string product;
        public string timokatalogos;
        public string productDescription;
        public string timokatalogosDescription;
        public frmTimi(string product_, string timokatalogos_, string productDescription_, string TimoDescription_)
        {
            product = product_;
            timokatalogos = timokatalogos_;
            productDescription = productDescription_;
            timokatalogosDescription = TimoDescription_;
            InitializeComponent();
            setFormsGlobals();
            this.Text = TimoDescription_ + " " + productDescription_;
        }

        private void setFormsGlobals()
        {
            this.Name = "frmTimi";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            if (product.ToUpper().Equals("NEW"))
            {
                this.Text = "Τιμή - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου
                tabControl1.TabPages[0].Text = "Δεδομενα";
            }
            else
            {
                this.Text = productDescription;
                tabControl1.TabPages[0].Text = timokatalogosDescription; //΄Ορίζω τον τίτλο του παραθύρου
            }


        }
        Times dataclass = new Times(" ");
        public override void LoadData()
        {
            if (product.ToUpper().Equals("NEW")) { this.refreshToolStripMenuItem.Enabled = false; }            
            else
            {
                string Res = dataclass.Read(product, timokatalogos); // Διαβάζω τα δεδομένα
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    base.LoadData(dataclass.Fields); // Μεταφαίρω τα δεδομένα στα αντικείμενα της φόρμας
                }
            }
        }

        public override void UpdateBtn()
        {
            object objectdata = base.UpdateBtn(dataclass.Fields); // μεταφέρω τις τιμές των αντικειμένων σε ένα γενικό αντικείμενο 
            foreach (var property in objectdata.GetType().GetProperties())   // μεταφέρω τις τιμές απο το γενικό αντικείμενο στα πεδία της κλάσης
                dataclass.Fields.GetType().GetProperty(property.Name).SetValue(dataclass.Fields, property.GetValue(objectdata));
            dataclass.Fields.Product = product;
            dataclass.Fields.PriceList.id = timokatalogos;

            
            string res = "";
            if (product.Equals("new")) res = dataclass.Insert(); // νεα εγγραφή
            else res = dataclass.Update();  // σώζω 
            if (res.Length == 0) this.Close(); // έξοδος
            else MessageBox.Show(res, "Σφάλμα !"); // παρουσίαση σφάλματος στο update
        }
    }
}
