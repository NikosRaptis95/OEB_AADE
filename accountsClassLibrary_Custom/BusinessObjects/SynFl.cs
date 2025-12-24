using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accountsClassLibrary_Custom.BusinessObjects
{


    public class ItemSynFlModel : ItemSynFlModelGeotexniki
    { }

    public class SynFlCustom 
    {
        public void Read(ItemSynFlModel _Fields, DataRow dr)
        {
            switch(CustomAplication.GetApplication())
            {
                case CustomAplication.Customers.Geotexniki:
                    new SynFlCustomGeotexniki().Read(_Fields, dr);
                    break;
                default:
                    break;
            }           
        }

        public string ReadZoomSQL(string SQL)
        {
            switch (CustomAplication.GetApplication())
            {
                case CustomAplication.Customers.Geotexniki:
                    return new SynFlCustomGeotexniki().ReadZoomSQL(SQL);
                default:
                    return SQL;
            }
        }

        public DataTable ReadZoomData(DataTable dt)
        {
            switch (CustomAplication.GetApplication())
            {
                case CustomAplication.Customers.Geotexniki:
                    return new SynFlCustomGeotexniki().ReadZoomData(dt);
                default:
                    return dt;
            }
        }

        public string Update(ItemSynFlModel _Fields, string SQL)
        {
            switch (CustomAplication.GetApplication())
            {
                case CustomAplication.Customers.Geotexniki:
                    return new SynFlCustomGeotexniki().Update(_Fields, SQL);
                default:
                    return SQL;
            }


        }
    }


    #region Geotexniki
    public class ItemSynFlModelGeotexniki // Geotexniki
    {
       public ItemSynFlModelGeotexniki()
        {
            _Geotexniki_PassWords1 = "";
        }

        public ItemSynFlModelGeotexniki(string StringToFind)
        {
            _Geotexniki_PassWords1 = StringToFind;
        }

        private string _Geotexniki_PassWords1;
        public string Geotexniki_PassWords1
        {
            get { return _Geotexniki_PassWords1; }
            set { _Geotexniki_PassWords1 = value; }
        }
    }
    
  
    public class SynFlCustomGeotexniki // Geotexniki
    {
        public void Read(ItemSynFlModel _Fields, DataRow dr)
        {
            _Fields.Geotexniki_PassWords1 = dr["Geotexniki_PassWords1"].ToString();
        }
        public string ReadZoomSQL(string SQL)
        {
            string myvar = ", SynFl.Map, Geotexniki_PassWords1, '' as M1, '' as M2, '' As M3, '' as M4, '' as P1, '' as P2, '' As P3, '' as P4, ";
            SQL = SQL.Replace(", SynFl.Map, ", myvar).Replace("Order By SynFl.Map, SynFl.Name", "");
            return SQL;
        }
        public DataTable ReadZoomData(DataTable dt)
        {
            for(int i=0; i<dt.Rows.Count; i++)
            {
                try
                {
                    string tmp = dt.Rows[i]["Map"].ToString();
                    string field = "";

                    int start = 0;
                    int end = tmp.IndexOf(" ");
                    if (end < 0) end = tmp.Trim().Length;
                    field = tmp.Substring(start, end).Trim();
                    dt.Rows[i]["M1"] = field;


                    start = dt.Rows[i]["M1"].ToString().Length + 1;
                    end = tmp.Length - start;
                    if (end < 0) end = 0;
                    field = tmp.Substring(start, end).Trim();
                    dt.Rows[i]["M2"] = field;
                    try
                    {
                        field = dt.Rows[i]["M2"].ToString().Substring(0, dt.Rows[i]["M2"].ToString().IndexOf(" ")).Trim();
                        dt.Rows[i]["M2"] = field;
                    }
                    catch { }

                    start = dt.Rows[i]["M1"].ToString().Length + dt.Rows[i]["M2"].ToString().Length + 2;
                    end = tmp.Length - start;
                    if (end < 0) end = 0;
                    field = tmp.Substring(start, end).Trim();
                    dt.Rows[i]["M3"] = field;
                    try
                    {
                        field = dt.Rows[i]["M3"].ToString().Substring(0, dt.Rows[i]["M3"].ToString().IndexOf(" ")).Trim();
                        dt.Rows[i]["M3"] = field;
                    }
                    catch { }

                    start = dt.Rows[i]["M1"].ToString().Length + dt.Rows[i]["M2"].ToString().Length + dt.Rows[i]["M3"].ToString().Length + 3;
                    end = tmp.Length - start;
                    if (end < 0) end = 0;
                    field = tmp.Substring(start, end).Trim();
                    dt.Rows[i]["M4"] = field;
                }
                catch { }

                try
                {
                    string tmp = dt.Rows[i]["Geotexniki_PassWords1"].ToString();
                    string field = "";

                    int start = 0;
                    int end = tmp.IndexOf(" ");
                    if (end < 0) end = tmp.Trim().Length;
                    field = tmp.Substring(start, end).Trim();
                    dt.Rows[i]["P1"] = field;


                    start = dt.Rows[i]["P1"].ToString().Length + 1;
                    end = tmp.Length - start;
                    if (end < 0) end = 0;
                    field = tmp.Substring(start, end).Trim();
                    dt.Rows[i]["P2"] = field;
                    try
                    {
                        field = dt.Rows[i]["P2"].ToString().Substring(0, dt.Rows[i]["P2"].ToString().IndexOf(" ")).Trim();
                        dt.Rows[i]["P2"] = field;
                    }
                    catch { }

                    start = dt.Rows[i]["P1"].ToString().Length + dt.Rows[i]["P2"].ToString().Length + 2;
                    end = tmp.Length - start;
                    if (end < 0) end = 0;
                    field = tmp.Substring(start, end).Trim();
                    dt.Rows[i]["P3"] = field;
                    try
                    {
                        field = dt.Rows[i]["P3"].ToString().Substring(0, dt.Rows[i]["P3"].ToString().IndexOf(" ")).Trim();
                        dt.Rows[i]["P3"] = field;
                    }
                    catch { }

                    start = dt.Rows[i]["P1"].ToString().Length + dt.Rows[i]["P2"].ToString().Length + dt.Rows[i]["P3"].ToString().Length + 3;
                    end = tmp.Length - start;
                    if (end < 0) end = 0;
                    field = tmp.Substring(start, end).Trim();
                    dt.Rows[i]["P4"] = field;
                }
                catch { }

            }
            return dt;
        }


        public string Update(ItemSynFlModel _Fields, string SQL)
        {
            string myvar = ", Geotexniki_PassWords1 = '" + _Fields.Geotexniki_PassWords1.ToString() + "' ";
            SQL = SQL.Replace("Where", myvar + "Where");
            return SQL;
        }
    }
    #endregion



}
