using DesktopBusiness.MForms;
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

namespace DesktopBusiness.CallForms
{
    public partial class CAll_AADEFrm : templates.Forms.CallFrm
    {
        public CAll_AADEFrm()
        {
            InitializeComponent();
            this.Name = "CAll_AADEFrm";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            this.Text = "Μεταβίβαση Εισπράξεων";
        }

        public override List<string> GetData(string strFind)
        {

            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            for (int i = 0; i < 3; i++) { cols.Add(new DataGridViewTextBoxColumn()); }

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            col0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cols.Add(col0);

            for (int i = 0; i < 3; i++) { cols.Add(new DataGridViewTextBoxColumn()); }

            for (int i = 0; i <= 12; i++) { cols.Add(new DataGridViewTextBoxColumn()); }

            List<string> fields = new List<string>() { "AA", "id", "auditProtocol", "auditTransactionDate", "auditUnit", "auditUserId", "auditUserIp", "inMctCod", "inSctCod", "txtCode", "insFrequency", "lastDayRule", "fiscalYear", "synolo", "comments", "ypiresiaDescr", "apofNoEtos", "afmYpogr", "nameYpogr", "doy" };
            List<string> fname = new List<string>() { "Visible=False", "κωδικός", "Πρωτόκολλο", "Ημερομνία Ώρα", "Φορέας", "User", "IP", "Είδος Χρηματικού Καταλόγου", "Τύπος Πηγής", "Είδος φόρου", "Περιοδικότητα δόσεων", "Κανόνας τελευταίας εργάσιμης", "Οικονομικό έτος", "Ποσό", "Σημειώσεις", "Περιγραφή υπηρεσίας", "Αρ.Aπόφασης–Έτος", "ΑΦΜ Υπογράφοντος", "Ονομα Υπογράφοντος", "ΔΟΥ" };

            // Τίτλος στο παράθυρο, Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind                        
            new alphaFrameWork.AlphaFramework().Bind(DataGrid,
                      new accountsClassLibrary.AADEFl(strFind).ReadZoom(this.Name),
                      cols, fields, fname);

            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("id");
            return (s);
        }

        public override string Delete(List<string> id) { return (new accountsClassLibrary.AADEFl().Delete(id[0])); }

        public override templates.Forms.def CallForm(List<string> id) { return (new DesktopBusiness.MForms.frmAADEFrm(id[0])); }

        public override void CustomizeMenu()
        {

            // Ρυθμίσεις         
            {
                ToolStripMenuItem ViewMenuItem26 = new ToolStripMenuItem("username !");
                ViewMenuItem26.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "username.param";
                    paramEditor.ShowDialog();
                };
                ToolStripMenuItem ViewMenuItem27 = new ToolStripMenuItem("password !");
                ViewMenuItem27.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "password.param";
                    paramEditor.ShowDialog();
                };
                ToolStripMenuItem ViewMenuItem261 = new ToolStripMenuItem("username (Delete) !");
                ViewMenuItem261.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "usernameD.param";
                    paramEditor.ShowDialog();
                };
                ToolStripMenuItem ViewMenuItem271 = new ToolStripMenuItem("password (Delete) !");
                ViewMenuItem271.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "passwordD.param";
                    paramEditor.ShowDialog();
                };
                ToolStripMenuItem ViewMenuItem28 = new ToolStripMenuItem("typeapp !");
                ViewMenuItem28.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "typeapp.param";
                    paramEditor.ShowDialog();
                };
                

                ToolStripDropDownButton menuView3 = new ToolStripDropDownButton("Παράμετροι");
                menuView3.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem26, ViewMenuItem27, ViewMenuItem261, ViewMenuItem271, ViewMenuItem28 });
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
                menu.Items.AddRange(new ToolStripDropDownButton[] {  menuView2 });
            }
                                   
        }
        private void LoadPDF(string pdfFilePath)
        {
            try
            {
                pdfFilePath = @"Documents\" + pdfFilePath + ".pdf";
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
        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            //searchBox.DisplayMember = "Name";
            //searchBox.ValueMember = "id";
            //searchBox.DataSource = new accountsClassLibrary.FilPin("%").ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.CategoryMtl);
        }


    }
}
