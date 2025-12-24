using accountsClassLibrary;
using Microsoft.ConsultingServices.HtmlEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class qsynt : templates.Forms.frmMaster
    {
        public qsynt(string codemtl)
        {
            InitializeComponent();
            MtlFl mtl = new MtlFl("%");
            mtl.Read(codemtl);
            this.Text = codemtl;
            megaText_Description.textBox1.Text = mtl.Fields.Description;
            megaText_Quantity.textBox1.Text = "1".Trim();
        }

        string id = "new";
        public qsynt(string id_, string codemtl, string descmtl, string quantity)
        {
            id= id_;
            InitializeComponent();
            MtlFl mtl = new MtlFl("%");
            mtl.Read(codemtl);
            this.Text = codemtl;
            megaText_Description.textBox1.Text = mtl.Fields.Description;
            megaText_Quantity.textBox1.Text = quantity.Trim();
        }

        public override void UpdateBtn()
        {          
            Program.global.InputBoxList.Add(this.Text);
            //Program.global.InputBox1List.Add(megaText_Quantity.megaTextBox.Text);
            Program.global.InputBoxText = this.Text;
            Program.global.InputBox1Text = megaText_Quantity.megaTextBox.Text;
            Program.global.InputBox2Text = id;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.global.InputBoxText = "";
            Program.global.InputBox1Text = "";
            Program.global.InputBox2Text = "";
            this.Close();
        }
    }
}
