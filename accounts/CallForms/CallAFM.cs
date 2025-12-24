using accountsClassLibrary;
using DesktopBusiness.iForms;
using DesktopBusiness.MForms;
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

namespace DesktopBusiness.CallForms
{
    public partial class CallAFM : templates.Forms.CallFrm
    {
        string level = "Basic";
        public CallAFM()
        {
            InitializeComponent();
            this.DataGrid.RowPrePaint += DataGrid_RowPrePaint;

            setFormsGlobals();
            level=File.ReadAllText(@"params\level.param");
            level= level.Trim();
        }
        public CallAFM(string _auditTransactionId)
        {
            InitializeComponent();
            auditTransactionId = _auditTransactionId;
            level = File.ReadAllText(@"params\level.param");
            level = level.Trim();
            setFormsGlobals();
        }
        public string auditTransactionId;

        public override List<string> GetData(string strFind)
        {

            // Δηλώνω κολόνες στο Grid            
            List<Object> cols = new List<Object>();
            for (int i = 0; i <= 5; i++) { cols.Add(new DataGridViewTextBoxColumn()); }
            List<string> fields = new List<string>() { "AA", "id", "Afm", "amount", "status", "Sxol"};
            List<string> fname = new List<string>() { "Visible=False", "κωδικός", "ΑΦΜ", "Ποσό", "Status", "Παρατηρήσεις" };
            alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();

            // Μεταφορα ονόματος στις παραμέτρους
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ ΚΑΕ του Πρωτοκόλου   
            new alphaFrameWork.AlphaFramework().Bind(this.DataGrid,
                                                   new AFMFl().ReadZoom(auditTransactionId),
                                                   cols, fields, fname);
            searchBox.Visible = false;
            CrearButton.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;

            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("id");
            return (s);
        }

        public override string Delete(List<string> id)
        {
            new accountsClassLibrary.AFMKIN().DeleteFromAFM(id[0]);
            return new accountsClassLibrary.AFMFl().Delete(id[0]);
        }

        public override templates.Forms.def CallForm(List<string> id)
        {
            AFMFl afm = new AFMFl();
            afm.Read(id[0]);

            if (afm.Fields.status == "1")
            {
                MessageBox.Show(
                    "Η εγγραφή έχει ήδη αποσταλεί και δεν μπορεί να τροποποιηθεί.",
                    "Μη επιτρεπτή ενέργεια",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return null;
            }

            return new DesktopBusiness.MForms.frmAFM(id[0], auditTransactionId);
        }

        private bool CanSendSelectedRows()
        {
            if (DataGrid.SelectedRows.Count == 0)
                return false;

            foreach (DataGridViewRow row in DataGrid.SelectedRows)
            {
                if (row.Cells["status"].Value?.ToString() == "1")
                    return false;
            }

            return true;
        }

        public override void CustomizeMenu()
        {


            // Παρουσιάσεις
            ToolStripMenuItem ViewMenuItem00 = new ToolStripMenuItem("Δημιουργία Συνόλων");
            ViewMenuItem00.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show(new alphaFrameWork.AlphaFramework().getStr(this.DataGrid), "Δημιουργία Συνόλων ?", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    AFMKIN afmkin = new AFMKIN();
                    AFMFl afm = new AFMFl();
                    for (int i = 0; i < DataGrid.SelectedRows.Count; i++) { 
                        double s = afmkin.ReadSUMAFM(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());                  
                        afm.UpdateAmount(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString(), s);
                    }
                    GetData(searchBox.Text);
                    MessageBox.Show("Η δημιουργία Συνόλων ολοκληρώθηκε !", "Δημιουργία Συνόλων !");
                }
                else
                {
                    MessageBox.Show("Η δημιουργία Συνόλων ακυρώθηκε !", "Δημιουργία Συνόλων !");
                }
                
            };


            ToolStripMenuItem ViewMenuItem01 = new ToolStripMenuItem("Δημιουργία XML & Αποστολή !");
            ViewMenuItem01.Click += async (object sender, EventArgs e) =>
            {
                if (!CanSendSelectedRows())
                {
                    MessageBox.Show(
                        "Υπάρχουν επιλεγμένες εγγραφές που έχουν ήδη αποσταλεί.",
                        "Μη επιτρεπτή ενέργεια",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (MessageBox.Show(
                    new alphaFrameWork.AlphaFramework().getStr(this.DataGrid),
                    "Δημιουργία XML & Αποστολή ?",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    MessageBox.Show("Η αποστολή ακυρώθηκε !", "Δημιουργία XML & Αποστολή !");
                    return;
                }

                for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
                {
                    string id = DataGrid.SelectedRows[i].Cells["id"].Value.ToString();
                    await Send_xml(PrepareXML.prepareXML(id), id);
                }

                MessageBox.Show("Η αποστολή ολοκληρώθηκε !", "Δημιουργία XML & Αποστολή !");
                GetData(searchBox.Text);
            };

            this.DataGrid.SelectionChanged += (s, e) =>
            {
                ViewMenuItem01.Enabled = CanSendSelectedRows();
            };


            ToolStripMenuItem ViewMenuItem02 = new ToolStripMenuItem("Import ΑΦΜ !");
            ViewMenuItem02.Click += async (object sender, EventArgs e) =>
            {
                string tmpfilename = @"exports\export_afm.csv";
                if(File.Exists(tmpfilename)==false)
                {
                    MessageBox.Show("Δεν υπάρχει το αρχείο: (" + tmpfilename + ")", "ΠΡΟΣΟΧΗ !!");
                    return;
                }
                if (MessageBox.Show(tmpfilename, "Import ΑΦΜ ?", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    DataTable dt = new bhtaFramework.bhtaFramework().CsvToDataTable(tmpfilename, true, ',');
                    try
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            AFMFl afm = new AFMFl();
                            afm.Fields.id = Guid.NewGuid().ToString();
                            afm.Fields.AFM = dt.Rows[i]["afm"].ToString();
                            afm.Fields.amount = Convert.ToDouble(dt.Rows[i]["poso"]);
                            afm.Fields.status = "0";
                            //afm.Fields.DateTimeSend = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ").ToString();
                            string res = afm.Insert(auditTransactionId);
                            if (res.Trim().Length > 0) { MessageBox.Show(res, "ΠΡΟΣΟΧΗ !"); }
                        }
                        GetData(searchBox.Text);
                        MessageBox.Show("Η διεργασία Import ΑΦΜ ολοκληρώθηκε !", "ΠΡΟΣΟΧΗ !!");
                    }
                    catch
                    {
                        MessageBox.Show("Σφάλμα στην διεργασία Import ΑΦΜ - απο το αρχείο: (" + tmpfilename + ")", "ΠΡΟΣΟΧΗ !!");
                    }
                }
                else
                {
                    MessageBox.Show("Η διεργασία ακυρώθηκε !", "Import ΑΦΜ !");
                }

            };

            ToolStripMenuItem ViewMenuItem03 = new ToolStripMenuItem("Import Ποσά στα ΑΦΜ !");
            ViewMenuItem03.Click += async (object sender, EventArgs e) =>
            {
                string tmpfilename = @"exports\export_kin.csv";
                if (File.Exists(tmpfilename) == false)
                {
                    MessageBox.Show("Δεν υπάρχει το αρχείο: (" + tmpfilename + ")", "ΠΡΟΣΟΧΗ !!");
                    return;
                }
                if (MessageBox.Show(tmpfilename, "Import ποσών στα ΑΦΜ ?", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    importPosa();
                }
                else
                {
                    MessageBox.Show("Η διεργασία ακυρώθηκε !", "Import Ποσά στα ΑΦΜ !");
                }

            };

            ToolStripMenuItem ViewMenuItem04 = new ToolStripMenuItem("Επιβεβαίωση Συνόλων");
            ViewMenuItem04.Click += async (object sender, EventArgs e) =>
            {
                if (MessageBox.Show(
                     new alphaFrameWork.AlphaFramework().getStr(this.DataGrid),
                     "Επιβεβαίωση Συνόλων?",
                     MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    MessageBox.Show("Η αποστολή ακυρώθηκε !", "Επιβεβαίωση Συνόλων");
                    return;
                }

                for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
                {
                    string id = DataGrid.SelectedRows[i].Cells["id"].Value.ToString();
                    //MessageBox.Show(PrepareXML.prepareXML('5'), id);
                    await Send_xml(PrepareXML.prepareXML(id), id);
                }

                MessageBox.Show("Η αποστολή ολοκληρώθηκε !", "Επιβεβαίωση Συνόλων");
                GetData(searchBox.Text);

            };

            ToolStripDropDownButton menuView0 = new ToolStripDropDownButton("Επεξεργασία");
            menuView0.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem00, ViewMenuItem01, ViewMenuItem02, ViewMenuItem03,ViewMenuItem04 });

            menu.Items.AddRange(new ToolStripItem[] { menuView0 });


            // Παράμετροι         
            {
                ToolStripMenuItem ViewMenuItem31 = new ToolStripMenuItem("AFMlist !");
                ViewMenuItem31.Click += (object sender, EventArgs e) =>
                {
                    AFMFl afm = new AFMFl();
                    afm.Read(DataGrid.SelectedRows[0].Cells["Id"].Value.ToString());

                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "AFMlist"+afm.Fields.auditRecord.Status.id+ ".param";
                    paramEditor.ShowDialog();
                };
                

                ToolStripDropDownButton menuView3 = new ToolStripDropDownButton("Παράμετροι");
                menuView3.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem31 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView3 });
            }

        }

        private void importPosa()
        {
            string tmpfilename = @"exports\export_kin.csv";
            DataTable dt = new bhtaFramework.bhtaFramework().CsvToDataTable(tmpfilename, true, ',');
            try
            {
                AFMKIN afmkin = new AFMKIN();
                for (int i = 0; i < dt.Rows.Count; i++)
                {                    
                    afmkin.Fields.id = Guid.NewGuid().ToString();
                    AFMFl afm = new AFMFl();
                    bool resafm = afm.ReadByAFM(dt.Rows[i]["afm"].ToString(), auditTransactionId);
                    afmkin.Fields.AFMid.id = afm.Fields.id;
                    afmkin.Fields.dueDate = Convert.ToDateTime(dt.Rows[i]["duedate"]);
                    KAEFl kae = new KAEFl();
                    bool reskae = kae.ReadFromKae(dt.Rows[i]["kae"].ToString(), auditTransactionId);
                    afmkin.Fields.KAEid.id = kae.Fields.id;
                    afmkin.Fields.ammount = Convert.ToDouble(dt.Rows[i]["poso"]);
                    
                    if (resafm == false)
                    {
                        MessageBox.Show("Δεν υπάρχει το ΑΦΜ: (" + dt.Rows[i]["afm"].ToString() + ")", "ΠΡΟΣΟΧΗ !!");
                        continue;
                    }
                    if (reskae == false)
                    {
                        MessageBox.Show("Δεν υπάρχει η ΚΑΕ: (" + dt.Rows[i]["kae"].ToString() + ")", "ΠΡΟΣΟΧΗ !!");
                        continue;
                    }
                    string res = afmkin.Insert(afmkin.Fields.AFMid.id);
                    if (res.Trim().Length > 0) { MessageBox.Show(res, "ΠΡΟΣΟΧΗ !"); }
                }
                GetData(searchBox.Text);
                MessageBox.Show("Η διεργασία Import Ποσών στα ΑΦΜ ολοκληρώθηκε !", "ΠΡΟΣΟΧΗ !!");
            }
            catch
            {
                MessageBox.Show("Σφάλμα στην διεργασία Import Ποσών στα ΑΦΜ - απο το αρχείο: (" + tmpfilename + ")", "ΠΡΟΣΟΧΗ !!");
            }
        }

        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            
        }

        private void setFormsGlobals()
        {
            this.Name = "CallAFM";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            AADEFl aade = new AADEFl();
            aade.Read(auditTransactionId);
            this.Text = "ΑΦΜ στην Απόφαση με Αρ.Πρωτοκόλου:" + aade.Fields.auditProtocol;
            //if(level.ToUpper().Equals("BASIC"))
            //    {
            //    newMenuItem.Enabled = false;
            //}
        }

        private async Task Send_xml(string xmlfile,  string id)
        {           
            SendXML xmlSender = new SendXML();
            try
            {
                bool ok = false;
                string result = await xmlSender.SendXML(xmlfile, id);
                if(result.IndexOf("><errorRecord/><") >-1)
                {
                    ok= true;
                }
                List<List<string>> xmlres = new List<List<string>>();


                xmlres = new bhtaFramework.bhtaFramework().XmlToList(result);
                AFMFl afm = new AFMFl();
                afm.Read(id);
                xmlres.Add(new List<string> { "service", afm.Fields.auditRecord.Status.Name });

                afm.Fields.sendXML = xmlfile;
                afm.Fields.ansXML = result;
                List<string> TMP = new bhtaFramework.bhtaFramework().ExtractSubsets(result, "<faultstring>", "</faultstring>");
                List<string> TMP2 = new bhtaFramework.bhtaFramework().ExtractSubsets(result, "<errorDescr>", "</errorDescr>");
                string errordesc = "";
                if (TMP.Count > 0) errordesc = "Error: " + TMP[0];
                if (TMP2.Count > 0 && TMP.Count == 0) errordesc = "Error: " + TMP2[0];

                afm.Fields.anstext = errordesc.Replace("<", "");
                afm.Fields.id = id;
                afm.Fields.DateTimeSend = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString();
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

                if (afm.Fields.status.Equals("2")) MessageBox.Show(displaystring, "SOAP Response - Υπήρξε σφάλμα !");
                else MessageBox.Show(displaystring, "SOAP Response - Η αποστολή έγινε με επιτυχία !");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }            
        }
        private void DataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = DataGrid.Rows[e.RowIndex];

            if (row.Cells["status"].Value != null &&
                row.Cells["status"].Value.ToString() == "1")
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
                row.DefaultCellStyle.ForeColor = Color.DarkGray;
                row.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                row.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                row.ReadOnly = true; // no editing
            }
        }



    }
}

