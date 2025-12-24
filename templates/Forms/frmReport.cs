using Microsoft.Reporting.WinForms;
using System;
using System.Data;

using System.Windows.Forms;

namespace templates.Forms
{
    public partial class frmReport : def
    {

        public frmReport()
        {
            InitializeComponent();
        }

        private string Report;
        private DataTable Ds;
        private string Param0;
        private string Param1;


        public frmReport(string report, DataTable ds, string param0, string param1)
        {
            InitializeComponent();
            Report = report;
            Ds = ds;
            Param0 = param0;
            Param1 = param1;
        }

        private void reportFrm_Load(object sender, EventArgs e)
        {
            ReportDataSource rds1 = new ReportDataSource("mydt", Ds);
            string cReport = Report.Substring(0, Report.Length - 5) + "_Custom.rdlc";
            if (System.IO.File.Exists(cReport)) { Report = cReport; }
            this.reportViewer1.LocalReport.ReportPath = Report;
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.LocalReport.Refresh();

            try
            {
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("param", Param0);
                parameters[1] = new ReportParameter("company", Param1);
                //parameters[2] = new ReportParameter("imagecompany", c.Fields.Picture);
                this.reportViewer1.LocalReport.SetParameters(parameters);
            }
            catch { }
            this.reportViewer1.RefreshReport();
            //new tclass().executeCode(this, BO, EXE);
        }
    }
}
