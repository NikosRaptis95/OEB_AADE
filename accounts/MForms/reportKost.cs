using accountsClassLibrary;
using alphaFrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DesktopBusiness.MForms
{
    public partial class reportKost : Form
    {
        public string Timo;
        public string TimoDesc;
        public string Code;
        public string Description;

        public reportKost(string Timo_, string TimoDesc_, string Code_, string Description_)
        {
            Timo = Timo_;
            TimoDesc = TimoDesc_;
            Code = Code_; 
            Description = Description_;
            
            InitializeComponent();
        }

        class rec
        {
            public string Product { get; set; }
            public double Quantity { get; set; }
            public double Price { get; set; }
            public double Summary { get; set; }
        }
           


        private void reportKost_Load(object sender, EventArgs e)
        {
            Title.Text = Description + " / " + TimoDesc;
            accountsClassLibrary.Times t = new accountsClassLibrary.Times();
            DataTable dtTimo = new DataTable();
            t.Fields.Product = Code;
            dtTimo = t.ReadZoom();
            accountsClassLibrary.Times timos = new Times();
            accountsClassLibrary.MtlFl m = new MtlFl();
            accountsClassLibrary.Syntages s = new accountsClassLibrary.Syntages();
            DataTable dtSyntagi = new DataTable();
            dtSyntagi = s.ReadZoom(Code);
            List<rec> list = new List<rec>();

            rec rec_ = new rec();
            double summary = 0;
            for (int i = 0; i < dtSyntagi.Rows.Count; i++)
            {
                m.Read(dtSyntagi.Rows[i]["product"].ToString());
                timos.Read(dtSyntagi.Rows[i]["product"].ToString(), Timo);     
                rec_ = new rec();
                rec_.Product=m.Fields.Description;
                rec_.Price=timos.Fields.Price;
                rec_.Quantity = Convert.ToDouble(dtSyntagi.Rows[i]["Quantity"]);
                rec_.Summary=rec_.Price* rec_.Quantity;
                summary += rec_.Summary;
                list.Add(rec_);
            }

            var source = new BindingSource();
            source.DataSource = list;
            dataGridView1.DataSource = source;
            dataGridView1.Refresh();
            Label_Summary.Text = summary.ToString("### ###.##");


        }
    }
}
