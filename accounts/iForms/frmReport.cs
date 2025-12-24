using Microsoft.Reporting.WinForms;
using Syncfusion.Windows.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace DesktopBusiness.iForms
{
    public partial class frmReport : MetroForm
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private string Report;
        private DataTable Ds;
        private string Param;
        public frmReport(string report, DataTable ds, string param)
        {
            InitializeComponent();
            Report = report;
            Ds = ds;
            Param = param;
        }

        private void reportFrm_Load(object sender, EventArgs e)
        {               
            ReportDataSource rds1 = new ReportDataSource("mydt", Ds);
            string cReport = Report.Substring(0, Report.Length - 5)+"_Custom.rdlc";
            if(System.IO.File.Exists(cReport)) { Report = cReport;  }
            this.reportViewer1.LocalReport.ReportPath = Report;
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.LocalReport.Refresh();
         
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("param", Param);
            accountsClassLibrary.FilPin c = new accountsClassLibrary.FilPin();
            c.Read("xr001");
            parameters[1] = new ReportParameter("company", c.Fields.Name);
            //parameters[2] = new ReportParameter("imagecompany", c.Fields.Picture);
            this.reportViewer1.LocalReport.SetParameters(parameters); 
            
            this.reportViewer1.RefreshReport();
        }
    }
}
