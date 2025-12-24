using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace templates.BusinessObjects
{
    public class databases
    {
        public String TestODBCConnection(string conString)
        {
            try
            {
                using (OdbcConnection con = new OdbcConnection(conString))
                {
                    con.Open();
                    con.Close();
                }
                return "Connection succeeded";
            }
            catch { return "Connection failed"; }
        }

        public String TestOLEDBConnection(string conString)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(conString))
                {
                    con.Open();
                    con.Close();
                }
                return "Connection succeeded";
            }
            catch { return "Connection failed"; }
        }

        public String TestSQLCLIENTConnection(string conString)
        {
            try {
                bhtaFramework.bhtaFramework b = new bhtaFramework.bhtaFramework();
                conString = conString.Replace("@clouduid", b.clouduid).Replace("@cloudpwd", b.cloudpwd);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    con.Close();
                }
                return "Connection succeeded"; 
            }
            catch { return "Connection failed"; }
        }
        public List<string> GetDatabaseList(string server, string uid, string pwd)
        {
            List<string> list = new List<string>();

            try
            {
                // Open connection to the database
                string conString = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + "; database=master";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();

                    // Set up a command with the given query and associate
                    // this with the current connection.
                    using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(dr[0].ToString());
                            }
                        }
                    }
                    con.Close();
                }
            }
            catch { }
            return list;

        }
    }
    public class ItemConnectionsModel
    {
        public ItemConnectionsModel()
        {
            _FileName = "";
            _Description = "";
            _ConnectionType = "";

            _SQLCLIEND = new SQLCLIENDItem();
            _OLEDB = new OLEDBItem();
            _ODBC = new ODBCItem();


        }
        

        private string _FileName;
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _ConnectionType;
        public string ConnectionType
        {
            get { return _ConnectionType; }
            set { _ConnectionType = value; }
        }

        private SQLCLIENDItem _SQLCLIEND;
        public SQLCLIENDItem SQLCLIEND
        {
            get { return _SQLCLIEND; }
            set { _SQLCLIEND = value; }
        }

        private OLEDBItem _OLEDB;
        public OLEDBItem OLEDB
        {
            get { return _OLEDB; }
            set { _OLEDB = value; }
        }

        private ODBCItem _ODBC;
        public ODBCItem ODBC
        {
            get { return _ODBC; }
            set { _ODBC = value; }
        }

        public class SQLCLIENDItem
        {
            public SQLCLIENDItem()
            {
                _server = "";
                _InitialCatalog = "";
                _uid = "";
                _pwd = "";
            }

            private string _server;
            public string server
            {
                get { return _server; }
                set { _server = value; }
            }

            private string _InitialCatalog;
            public string InitialCatalog
            {
                get { return _InitialCatalog; }
                set { _InitialCatalog = value; }
            }

            private string _uid;
            public string uid
            {
                get { return _uid; }
                set { _uid = value; }
            }

            private string _pwd;
            public string pwd
            {
                get { return _pwd; }
                set { _pwd = value; }
            }

        }

       public class OLEDBItem
        {
            public OLEDBItem()
            {
                _Provider = "";
                _DataSource = "";
            }

            private string _Provider;
            public string Provider
            {
                get { return _Provider; }
                set { _Provider = value; }
            }

            private string _DataSource;
            public string DataSource
            {
                get { return _DataSource; }
                set { _DataSource = value; }
            }

        }

       public class ODBCItem
        {
            public ODBCItem()
            {
                _ConnectionString = "";
            }

            private string _ConnectionString;
            public string ConnectionString
            {
                get { return _ConnectionString; }
                set { _ConnectionString = value; }
            }

        }




    }

    public class Connections
    {
        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        public Connections()
        {
            _Fields = new ItemConnectionsModel();
        }

       
        private ItemConnectionsModel _Fields;
        public ItemConnectionsModel Fields
        {
            get { return _Fields; }
            set { _Fields = value; }
        }

        public string Insert()
        {
            alphaFrameWork.AlphaFramework myc = new alphaFrameWork.AlphaFramework();
            string myMethod = "Connections_Insert";
            if (myc.customizationControl(myMethod) == false) return _s.G(1) + myMethod + " !!";

            //  Write your rules here **********************
            if (_Fields.FileName.Length < 1) _Fields.FileName = System.Guid.NewGuid().ToString();

            Connections_e e = new Connections_e();
            e.Fields = _Fields;
            if (e.Insert()) return "";
            else return _s.G(2);
        }

        public string Update()
        {
            alphaFrameWork.AlphaFramework myc = new alphaFrameWork.AlphaFramework();
            string myMethod = "Connections_Update";
            if (myc.customizationControl(myMethod) == false) return _s.G(3) + myMethod + " !!";

            //  Write your rules here **********************


            Connections_e e = new Connections_e();
            e.Fields = _Fields;
            if (e.Update()) return "";
            else return _s.G(4);
        }


        public string Delete(string filename)
        {
            alphaFrameWork.AlphaFramework myc = new alphaFrameWork.AlphaFramework();
            string myMethod = "Connections_Delete";
            if (myc.customizationControl(myMethod) == false) return _s.G(3) + myMethod + " !!";

            //  Write your rules here **********************


            Connections_e e = new Connections_e();
            e.Fields = _Fields;
            if (e.Delete(filename)) return "";
            else return _s.G(6);
        }


        public string Read(string filenameToFind)
        {
            alphaFrameWork.AlphaFramework myc = new alphaFrameWork.AlphaFramework();
            string myMethod = "Connections_Read";
            if (myc.customizationControl(myMethod) == false) return _s.G(3) + myMethod + " !!";

            //  Write your rules here **********************

            Connections_e e = new Connections_e();
            if (e.Read(filenameToFind) > 0) { _Fields = e.Fields; return ""; }
            else return _s.G(5);
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
                            case 1: return "Άπορρίφθηκε απο το customization -> control -> ";
                            case 2: return "Δεν μπορώ να βρώ την εγγραφή\n\nΗ εγγραφή μπορει να μην υπάρχει !";
                            case 3: return "Άπορρίφθηκε απο το customization -> control -> ";
                            case 4: return "Δεν ενημέρωσα την εγγραφή !\n\nη εγγραφή δεν υπάρχει!";
                            case 5: return "Δεν βρήκα την εγγραφή! \n\nη εγγραφή δεν υπάρχει !";
                            case 6: return "Δεν μπόρεσα να σβήσω την εγγραφή\n\nη εγγραφή δεν υπάρχει !";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Not allowed from customization -> control -> ";
                            case 2: return "Unable to enter the record\n\nThis entry may exist !";
                            case 3: return "Rejected by customization -> control -> ";
                            case 4: return "Unable to update registration\n\nThis record does not exist or is not deleted!";
                            case 5: return "Unable to read registration! \n\nThis record does not exist or is deleted!";
                            case 6: return "Unable to erase registration\n\nThis record does not exist or is deleted!";
                            default: return "String not found";
                        }

                }
            }

        }
    }

    class Connections_e
    {
        alphaFrameWork.datalayer _DataLayer = new alphaFrameWork.datalayer();
        public Connections_e()
        {
            _Fields = new ItemConnectionsModel();
        }

        
        private ItemConnectionsModel _Fields;
        public ItemConnectionsModel Fields
        {
            get { return _Fields; }
            set { _Fields = value; }
        }

        public Boolean Insert()
        {
            if (File.Exists(_Fields.FileName))
            {
                return false;
            }
            else
            {
                Update();   
                return true;
            }
        }

        public Boolean Update()
        {
            if (File.Exists(_Fields.FileName))
                        Delete(_Fields.FileName);

            try
            {
                File.WriteAllText(_Fields.FileName, getFromFields());
                return true;
            }
            catch { return false; }
        }

        private string getFromFields()
        {
            string str = _Fields.Description + Environment.NewLine + _Fields.ConnectionType + Environment.NewLine;
            switch (_Fields.ConnectionType.ToUpper())
            {
                case "SQLCLIENT":
                    str += ("server=" + _Fields.SQLCLIEND.server + ";");
                    str += ("Initial Catalog=" + _Fields.SQLCLIEND.InitialCatalog + ";");
                    str += ("uid=" + _Fields.SQLCLIEND.uid + ";");
                    str += ("pwd=" + _Fields.SQLCLIEND.pwd + ";");
                    break;
                case "OLEDB":
                    str += ("Provider=" + _Fields.OLEDB.Provider + ";");
                    str += ("Data Source=" + _Fields.OLEDB.DataSource + ";");
                    break;
                case "ODBC":
                    str += _Fields.ODBC.ConnectionString;
                    break;
                default:
                    break;
            }
            return str;
        }

        public Boolean Delete(string filename)
        {
            try
            {
                File.Delete(filename);
                return true;
            }
            catch { return false; }
        }

       
        public int Read(string filenameToFind)
        {
            if (File.Exists(filenameToFind))
            {
                
                _Fields.FileName = filenameToFind;
                string cs = "";
                using (StreamReader sr = new StreamReader(filenameToFind))
                {
                    _Fields.Description = sr.ReadLine();
                    _Fields.ConnectionType = sr.ReadLine();
                    cs = sr.ReadLine();

                    
                    bhtaFramework.bhtaFramework b = new bhtaFramework.bhtaFramework();
                    
                    switch(_Fields.ConnectionType.ToUpper())
                    {
                        case "SQLCLIENT":
                            _Fields.SQLCLIEND.server = b.getDataFromString(cs, "server=", ";");
                            _Fields.SQLCLIEND.InitialCatalog = b.getDataFromString(cs, "Initial Catalog=", ";");
                            _Fields.SQLCLIEND.pwd = b.getDataFromString(cs, "pwd=", ";");
                            _Fields.SQLCLIEND.uid = b.getDataFromString(cs, "uid=", ";");
                            break;
                        case "OLEDB":
                            _Fields.OLEDB.Provider = b.getDataFromString(cs, "Provider=", ";");
                            _Fields.OLEDB.DataSource = b.getDataFromString(cs, "Data Source=", ";");
                            break;
                        case "ODBC":
                            _Fields.ODBC.ConnectionString = cs;
                            break;
                        default:
                            break;
                    }
                    
                }
                
                
               
                return 1;
            }
            else
                return 0;
        }


    }



}
