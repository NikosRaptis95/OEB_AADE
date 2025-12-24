using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.reportForms
{
    public partial class genView : templates.Forms.def
    {
        public genView()
        {
            InitializeComponent();
            getData();
        }

       
        private void getData()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                accountsClassLibrary.SynFl c = new accountsClassLibrary.SynFl();
                c.Fields.id = "%";

                // Δηλώνω κολόνες στο Grid            
                List<Object> cols = new List<Object>();
                DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                cols.Add(col0);
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                cols.Add(col1);
                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.DefaultCellStyle.Format = "# ### ##0.00";
                col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols.Add(col2);
                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.DefaultCellStyle.Format = "# ### ##0.00";
                col3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols.Add(col3);
                DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                col4.DefaultCellStyle.Format = "# ### ##0.00";
                col4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col4.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                cols.Add(col4);
                List<string> fields = new List<string>() { "DescDate", "DescKoKi", "Xreosi", "Pistosi", "Ypoloipo" };
                List<string> fname = new List<string>() { "Μήνας", "Τύπος Κίνησης", "Χρέωση", "Πίστωση", "Υπόλοιπο" };
                alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();
                // Μεταφορα ονόματος στις παραμέτρους
                fname = mc.customizationforGrid(fname, this.Name+"_"+ this.dataGridView1.Name);
                // Καλώ Κινήσεις  
                DataTable dt = c.ReadZoom(accountsClassLibrary.SynFl.TypeOfReadZoom.KinhseisAnaMhna, accountsClassLibrary.SynFl.TypeOfSynFl.All, "", false);
                mc.Bind(this.dataGridView1, dt, cols, fields, fname);

 
                // Δηλώνω κολόνες στο Grid            
                cols = new List<Object>();                
                DataGridViewTextBoxColumn col10 = new DataGridViewTextBoxColumn();
                cols.Add(col10);
               
                DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn();
                col11.DefaultCellStyle.Format = "# ### ##0.00";
                col11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols.Add(col11);
                DataGridViewTextBoxColumn col12 = new DataGridViewTextBoxColumn();
                col12.DefaultCellStyle.Format = "# ### ##0.00";
                col12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols.Add(col12);
                DataGridViewTextBoxColumn col13 = new DataGridViewTextBoxColumn();
                col13.DefaultCellStyle.Format = "# ### ##0.00";
                col13.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col13.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                cols.Add(col13);
                fields = new List<string>() { "DescKoKi", "Xreosi", "Pistosi", "Ypoloipo" };
                fname = new List<string>() {  "Τύπος Κίνησης", "Χρέωση", "Πίστωση", "Υπόλοιπο" };
                // Μεταφορα ονόματος στις παραμέτρους
                fname = mc.customizationforGrid(fname, this.Name + "_" + this.dataGridView2.Name);
                // Καλώ Κινήσεις            
                mc.Bind(this.dataGridView2, c.ReadZoom(accountsClassLibrary.SynFl.TypeOfReadZoom.KinhseisSum), cols, fields, fname);


                textBox_xreosi.Text = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["sumXreosi"]).ToString("#0.00");
                textBox_pistosi.Text = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["sumPistosi"]).ToString("#0.00");
                textBox_ypoloipo.Text = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["Ypoloipo"]).ToString("#0.00");

                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY("Χρέωση (" + textBox_xreosi.Text + ")", Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["sumXreosi"]));
                chart1.Series[0].Points.AddXY("Πίστωση (" + textBox_pistosi.Text + ")", Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["sumPistosi"]));
                chart1.Series[0].Points.AddXY("Υπόλοιπο (" + textBox_ypoloipo.Text + ")", Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["Ypoloipo"]));
            }
            catch { }

            Cursor.Current = Cursors.Default;
        }

     
    }
}
