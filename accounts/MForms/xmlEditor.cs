using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;


namespace DesktopBusiness.MForms
{
    public partial class xmlEditor : Form
    {
        public string id;

        public xmlEditor()
        {
            InitializeComponent();
            xmlText.Font = new Font("Consolas", 10);

        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName("c:\\tmpxml")); }
            catch { }
            try { System.IO.File.WriteAllText("c:\\tmpxml\\oeb.xml", xmlText.Text);
                  MessageBox.Show("Καταχωρήθηκε το c:\\tmpxml\\oeb.xml"); }
            catch (Exception ex)
            { MessageBox.Show("Σφάλμα στην καταχώρηση του αρχείου: " + ex.Message); }
            
        }

        private void SendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Send_xml();
        }
        private async void Send_Json()
        {
            // 1. Ορισμός Δεδομένων
            //string url = "https://test.gsis.gr/esbpilot/retrieveKedeAmount"; // Το σωστό URL για δοκιμή REST
            string url = "https://test.gsis.gr/esb/retrieveKedeAmount\r\n"; // Το σωστό URL για δοκιμή REST
            string user = "WW1833736U367";
            string pass = "0256dx"; pass = "MDI1NmR4";

            // Το πλήρες JSON payload της υπηρεσίας retrieveKedeAmount
            string jsonString = "{ \"auditRecord\": {...}, \"retrieveKedeAmountRequest\": {...} }";

            // Δημιουργία client (ή χρήση του client που είχατε ορίσει)
            var client = new RestApiClient();

            try
            {
                // 2. Εκτέλεση της ασύγχρονης συνάρτησης (Await: Περιμένει χωρίς να μπλοκάρει το UI)
                string result = await client.SendRestRequestAsync(url, jsonString, user, pass);

                // 3. Εμφάνιση Αποτελέσματος
                MessageBox.Show($"Επιτυχής Απάντηση: {result}", "API Call Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                // 4. Χειρισμός Σφάλματος (π.χ., 404 Not Found, Σφάλμα δικτύου, κλπ.)
                MessageBox.Show($"Σφάλμα κλήσης API: {ex.Message}", "API Call Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Send_xml()
        {            

            SendXML xmlSender = new SendXML();
            try
            {                
                string result = await xmlSender.SendXML(xmlText.Text, id);
                List<List<string>> xmlres = new List<List<string>>();
                
                
                xmlres = new bhtaFramework.bhtaFramework().XmlToList(result);
                AFMFl afm = new AFMFl();
                afm.Read(id);
                xmlres.Add(new List<string> {"service", afm.Fields.auditRecord.Status.Name });

                afm.Fields.sendXML=xmlText.Text;
                afm.Fields.ansXML=result;
                List<string> TMP = new bhtaFramework.bhtaFramework().ExtractSubsets(result, "<faultstring>", "</faultstring>");
                List<string> TMP2 = new bhtaFramework.bhtaFramework().ExtractSubsets(result, "<errorDescr>", "</errorDescr>");
                string errordesc = "";
                if (TMP.Count > 0) errordesc = "Error: " + TMP[0];
                if (TMP2.Count > 0 && TMP.Count==0) errordesc = "Error: " + TMP2[0];

                afm.Fields.anstext = errordesc.Replace("<", "");
                afm.Fields.id = id;
                afm.Fields.DateTimeSend = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToString();
                string displaystring = "";
                for(int i=0;i< xmlres.Count;i++)
                {
                    displaystring += xmlres[i][0] + "=" + xmlres[i][1] + "\r\n";
                    if (xmlres[i].Count > 1 && xmlres[i][0].IndexOf("errorRecord") > -1)
                    {
                        afm.Fields.status = xmlres[i][1].Length.ToString();
                    }
                }
                if (afm.Fields.status.Equals("0"))
                    afm.Fields.status = "1";
                else
                    afm.Fields.status = "2";
                afm.UpdateAns();
                string title="";

                if (afm.Fields.status.Equals("2"))
                    title="SOAP Response - Υπήρξε σφάλμα !";
                else
                    title= "SOAP Response - Η αποστολη έγινε !";

                MessageBox.Show(displaystring, title);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
         


        private void xmlEditor_Load(object sender, EventArgs e)
        {
        }
    }
}
