using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopBusiness.reportForms
{
    public partial class ksynRepFrm : templates.Forms.def
    {
        private List<String> MySynFl;
        private List<String> MyDescSynFl;

        public ksynRepFrm(List<String> mysynfl, List<String> mydescsynfl)
        {
            InitializeComponent();
            loadCombos();
            MySynFl = mysynfl;
            MyDescSynFl = mydescsynfl;
            getData();
        }

        private void loadCombos()
        {
            accountsClassLibrary.KinFl mcp = new accountsClassLibrary.KinFl();

            DataTable dt0 = mcp.ReadZoomAitiKin("%");
            DataRow dr0;
            dr0 = dt0.NewRow();
            dt0.Rows.InsertAt(dr0, 0);
            textBox_AitiKin0.DataSource = null;
            textBox_AitiKin0.Items.Clear();
            textBox_AitiKin0.DisplayMember = "AitiKin";
            textBox_AitiKin0.DataSource = dt0;

            DataTable dt1 = mcp.ReadZoomAitiKin("%");
            DataRow dr1;
            dr1 = dt1.NewRow();
            dt1.Rows.InsertAt(dr1, 0);
            textBox_AitiKin1.DataSource = null;
            textBox_AitiKin1.Items.Clear();
            textBox_AitiKin1.DisplayMember = "AitiKin";
            textBox_AitiKin1.DataSource = dt1;
        }

        private void getData()
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < MySynFl.Count; i++)
            {
                dataGridView1.Rows.Add(new DataGridViewRow());
                dataGridView1.Rows[i].Cells[0].Value = MySynFl[i];
                dataGridView1.Rows[i].Cells[1].Value = MyDescSynFl[i];
                dataGridView1.Rows[i].Cells[2].Value = 0;
            }            
            Cursor.Current = Cursors.Default;
            recalc();
        }

        private void recalc()
        {
            Cursor.Current = Cursors.WaitCursor;
            accountsClassLibrary.SynFl ms = new accountsClassLibrary.SynFl();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ms.Fields.id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                ms.ReadYpoloipo(this.textBox_AitiKin0.Text);
                dataGridView1.Rows[i].Cells[2].Value = ms.Fields.Ypoloipo;
            }
            Cursor.Current = Cursors.Default;
        }

        private void getDetail()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                accountsClassLibrary.SynFl cs = new accountsClassLibrary.SynFl();
                cs.Fields.id = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
                //dataGridView2.AutoGenerateColumns = false;
                DataTable dt = cs.ReadZoom(accountsClassLibrary.SynFl.TypeOfReadZoom.KinhseisAnaMhna, accountsClassLibrary.SynFl.TypeOfSynFl.Customers, this.textBox_AitiKin1.Text);
                //dataGridView2.DataSource = dt;

                // Δηλώνω κολόνες στο Grid            
                List<Object> cols = new List<Object>();
                DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                cols.Add(col0);
                DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                col1.DefaultCellStyle.Format = "# ### ##0.00";
                col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols.Add(col1);
                DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                col2.DefaultCellStyle.Format = "# ### ##0.00";
                col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols.Add(col2);
                DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                col3.DefaultCellStyle.Format = "# ### ##0.00";
                col3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col3.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
                cols.Add(col3);
                List<string> fields = new List<string>() { "DescDate", "Xreosi", "Pistosi", "Ypoloipo" };
                List<string> fname = new List<string>() { "Μήνας", "Χρέωση", "Πίστωση", "Υπόλοιπο" };
                alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();
                // Μεταφορα ονόματος στις παραμέτρους
                fname = mc.customizationforGrid(fname, this.Name + "_" + this.dataGridView2.Name);
                // Καλώ Κινήσεις  
                mc.Bind(this.dataGridView2, dt, cols, fields, fname);


                chart1.Series["Χρέωση"].Points.Clear();
                chart1.Series["Πίστωση"].Points.Clear();
                chart1.Series["Υπόλοιπο"].Points.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    chart1.Series["Χρέωση"].Points.AddXY(dt.Rows[i]["DescDate"].ToString(), dt.Rows[i]["Xreosi"]);
                    chart1.Series["Πίστωση"].Points.AddXY(dt.Rows[i]["DescDate"].ToString(), dt.Rows[i]["Pistosi"]);
                    chart1.Series["Υπόλοιπο"].Points.AddXY(dt.Rows[i]["DescDate"].ToString(), dt.Rows[i]["Ypoloipo"]);
                }
            }
            catch
            { dataGridView2.DataSource = null; }
            Cursor.Current = Cursors.Default;
        }

        private void συναλλασόμενοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MForms.frmSynFl childForm = new MForms.frmSynFl(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString(),accountsClassLibrary.SynFl.TypeOfSynFl.All);
            childForm.MdiParent = this.ParentForm;
            childForm.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new CallForms.CallKinKartFrm(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());            
            childForm.MdiParent = this.ParentForm;
            childForm.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_AitiKin0.SelectedIndex = 0;
            textBox_AitiKin1.SelectedIndex = 0;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            getDetail();
        }

        private void textBox_AitiKin1_TextChanged(object sender, EventArgs e)
        {
            getDetail();
        }

        private void textBox_AitiKin0_TextChanged(object sender, EventArgs e)
        {
            recalc();
        }

    }
}
