using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using templates.BusinessObjects;

namespace templates
{
    public partial class dbConnection : templates.Forms.frmMaster
    {
        public dbConnection()
        {
            InitializeComponent();
            setFormsGlobals();
            FileName = "";
        }

        private string FileName;

        public dbConnection(string FileName_)
        {
            InitializeComponent();
            FileName = FileName_;
            setFormsGlobals();
        }

        #region virtual functions, general functions & variables

        List<string> servers = new bhtaFramework.bhtaFramework().CloudSqlServers();
        public override void LoadDefaults()
        {
            // Όρίζω τιμές στα αντικείμενα της φόρμας κατα το form load
            comboBox_server.Items.Clear();
            comboBox_server.Items.Add(Environment.MachineName);
            comboBox_server.Items.Add("localhost");

            for (int i = 0; i < servers.Count; i++)
                comboBox_server.Items.Add(servers[i]);

            comboBox_Provider.Items.Clear();
            comboBox_Provider.Items.Add("Microsoft.ACE.OLEDB.12.0");
            comboBox_Provider.Items.Add("Microsoft.Jet.OLEDB.4.0");

           
            comboBox_DataSource.Items.Clear();
            try { 
            string[] fileEntries = Directory.GetFiles("app_data", "*.mdb");
            foreach (string fileName in fileEntries)
                comboBox_DataSource.Items.Add(fileName); }
            catch { }

            comboBox_InitialCatalog.Items.Clear();           

        }

        private void loadDatabases()
        {
            string old = comboBox_InitialCatalog.Text;
            comboBox_InitialCatalog.Items.Clear();
            List<string> databases = new databases().GetDatabaseList(comboBox_server.Text, textBox_uid.Text, textBox_pwd.Text);
            for (int i = 0; i < databases.Count; i++)
                comboBox_InitialCatalog.Items.Add(databases[i]);
            comboBox_InitialCatalog.Text=old;
        }

        

        Connections dataclass = new Connections();
        public override void LoadData()
        {
            if (FileName.ToUpper().Equals("NEW"))
            {
                megaText_FileName.megaTextBox.Text = @"app_data\connectionstrings\"+System.Guid.NewGuid().ToString()+".txt";
                tabControl_ConnectionType.SelectedIndex = 0;
            }
            else
            {
                string Res = dataclass.Read(FileName); // Διαβάζω τα δεδομένα
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    //this.Text = dataclass.ReadTitle(MyType) + " - " + dataclass.Fields.Name; //΄Ορίζω τον τίτλο του παραθύρου
                    base.LoadData(dataclass.Fields); // Μεταφαίρω τα δεδομένα στα αντικείμενα της φόρμας
                    megaText_FileName.Enabled = false; /* primary key enable = false για το edit */

                    switch(dataclass.Fields.ConnectionType.ToUpper())
                    {
                        case "SQLCLIENT":         
                            tabControl_ConnectionType.SelectedIndex = 0;
                            comboBox_server.Text = dataclass.Fields.SQLCLIEND.server;
                            comboBox_InitialCatalog.Text = dataclass.Fields.SQLCLIEND.InitialCatalog;
                            textBox_uid.Text = dataclass.Fields.SQLCLIEND.uid;
                            textBox_pwd.Text = dataclass.Fields.SQLCLIEND.pwd;                          
                            break;
                        case "OLEDB":
                            tabControl_ConnectionType.SelectedIndex = 1;
                            comboBox_Provider.Text = dataclass.Fields.OLEDB.Provider;
                            comboBox_DataSource.Text = dataclass.Fields.OLEDB.DataSource;
                            break;
                        case "ODBC":
                            tabControl_ConnectionType.SelectedIndex = 2;
                            textBox_ConnectionString.Text = dataclass.Fields.ODBC.ConnectionString;
                            break;
                    }

                }
            }
        }
        public override void UpdateBtn()
        {
            string start = megaText_FileName.megaTextBox.Text.ToUpper().Substring(0, 27);
            string ext = megaText_FileName.megaTextBox.Text.ToUpper().Substring(megaText_FileName.megaTextBox.Text.Length - 4).ToUpper();

            if (start == @"app_data\connectionstrings\".ToUpper() && ext == ".TXT")
            {
                object objectdata = base.UpdateBtn(dataclass.Fields); // μεταφέρω τις τιμές των αντικειμένων σε ένα γενικό αντικείμενο 
                foreach (var property in objectdata.GetType().GetProperties())   // μεταφέρω τις τιμές απο το γενικό αντικείμενο στα πεδία της κλάσης
                    dataclass.Fields.GetType().GetProperty(property.Name).SetValue(dataclass.Fields, property.GetValue(objectdata));

                switch (tabControl_ConnectionType.SelectedIndex)
                {
                    case 0:
                        dataclass.Fields.ConnectionType= "SQLCLIENT";
                        dataclass.Fields.SQLCLIEND.InitialCatalog = comboBox_InitialCatalog.Text;
                        dataclass.Fields.SQLCLIEND.server = comboBox_server.Text;
                        dataclass.Fields.SQLCLIEND.uid = textBox_uid.Text;
                        dataclass.Fields.SQLCLIEND.pwd = textBox_pwd.Text;
                        break;
                    case 1:
                        dataclass.Fields.ConnectionType = "OLEDB";
                        dataclass.Fields.OLEDB.Provider = comboBox_Provider.Text;
                        dataclass.Fields.OLEDB.DataSource = comboBox_DataSource.Text;
                        break;
                    case 2:
                        dataclass.Fields.ConnectionType = "ODBC";
                        dataclass.Fields.ODBC.ConnectionString = textBox_ConnectionString.Text;
                        break;
                }

                string res = "";
                if (FileName.Equals("new")) res = dataclass.Insert(); // νεα εγγραφή
                else res = dataclass.Update();  // σώζω 
                if (res.Length == 0) this.Close(); // έξοδος
                else MessageBox.Show(res, "Error !"); // παρουσίαση σφάλματος στο update
            }
            else
                MessageBox.Show("Error in File Name !", "Error");
        }
        public override void CustomizeMenu()
        {


        }
        
        private void setFormsGlobals()
        {
            this.BO = "templates.dll";
            this.EXE = Application.ExecutablePath;
            if (FileName.ToUpper().Equals("NEW"))
                this.Text = "Connections - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου     
            linkLabel1.Text = "get Application from " + new bhtaFramework.bhtaFramework().DashboardURL;
        }

        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
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
                           
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            
                            default: return "String not found";
                        }
                }
            }

        }

        #endregion

        private void comboBox_server_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(servers.Any(comboBox_server.Text.Contains))
            {
                label_pwd.Visible = false;
                label_uid.Visible = false;
                textBox_uid.Text = "@clouduid";
                textBox_pwd.Text = "@cloudpwd";
                textBox_uid.Visible = false;
                textBox_pwd.Visible = false;
                label_InitialCatalog.Text = "Application";
                linkLabel1.Visible = true;
            }
            else
            {
                label_pwd.Visible = true;
                label_uid.Visible = true;
                textBox_pwd.Text = "";
                textBox_uid.Text = "sa";
                textBox_uid.Visible = true;
                textBox_pwd.Visible = true;
                label_InitialCatalog.Text = "Intitial Catalog";
                linkLabel1.Visible = false;
            }
        }

        private void button_loaddatabases_Click(object sender, EventArgs e)
        {
            loadDatabases();
        }

        private void button_testconnection_Click(object sender, EventArgs e)
        {
            testSQLCLIENTconnection(getSQLCLIENTConnectionString());
        }
        private string getSQLCLIENTConnectionString()
        {
            return "server=" + comboBox_server.Text + ";Initial Catalog=" + comboBox_InitialCatalog.Text + ";uid=" + textBox_uid.Text + ";pwd=" + textBox_pwd.Text + ";";
        }
        private void testSQLCLIENTconnection(string cs)
        {
            MessageBox.Show((new BusinessObjects.databases().TestSQLCLIENTConnection(cs)).ToString(), "Test connection");
        }

        private string getOLEDBConnectionString()
        {
            return "Provider=" + comboBox_Provider.Text + ";Data Source=" + comboBox_DataSource.Text + ";";
        }

        private void testOLEDBconnection(string cs)
        {
            MessageBox.Show((new BusinessObjects.databases().TestOLEDBConnection(cs)).ToString(), "Test connection");
        }
        private void button_OLEDB_TestConnection_Click(object sender, EventArgs e)
        {
            testOLEDBconnection(getOLEDBConnectionString());
        }

        private void button_ODBC_TestConnection_Click(object sender, EventArgs e)
        {
            MessageBox.Show((new BusinessObjects.databases().TestODBCConnection(textBox_ConnectionString.Text)).ToString(), "Test connection");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new bhtaFramework.bhtaFramework().DashboardURL + "/login.aspx");
        }
    }
}
