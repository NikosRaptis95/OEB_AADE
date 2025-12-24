using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace templates.UserControls
{
    public partial class megaText : UserControl
    {
        [Description("text displayed in the Label"), Category("Data")]
        public override string Text
        {
            get { return megaLabel.Text; }
            set { megaLabel.Text = value; }
        }

        [Description("text displayed in the Label"), Category("Data")]
        public string Text_Label
        {
            get { return megaLabel.Text; }
            set { megaLabel.Text = value; }
        }

        [Description("text displayed in the textbox"), Category("Data")]
        public string Text_Textbox
        {
            get { return megaTextBox.Text; }
            set { megaTextBox.Text = value.Trim(); }
        }

        [Description("datafield in the textbox"), Category("Data")]
        public string datafield
        { get; set; }

        [Description("default text in the textbox"), Category("Data")]
        public string Text_Default
        { get; set; }

        [Description("multiline in the textbox"), Category("Data")]
        public Boolean Text_Multiline
        {
            get { return megaTextBox.Multiline; }
            set { megaTextBox.Multiline = value; }
        }

        [Description("Is Number"), Category("Data")]
        public Boolean Text_IsNumber
        { get; set; }

        [Description("scrollBars in the textbox"), Category("Data")]
        public ScrollBars Text_ScrollBars
        {
            get { return megaTextBox.ScrollBars; }
            set { megaTextBox.ScrollBars = value; }
        }

        [Description("Height in the textbox"), Category("Data")]
        public int Text_Height
        {
            get { return megaTextBox.Height; }
            set { megaTextBox.Height = value; }
        }

        [Description("MaxLength in the textbox"), Category("Data")]
        public int Text_MaxLength
        {
            get { return megaTextBox.MaxLength; }
            set { megaTextBox.MaxLength = value; }
        }

        //[Description("ClassMember in the Text"), Category("Data")]
        //public string ClassMember
        //{ get; set; }

        //[Description("ClassRelateField in the Text"), Category("Data")]
        //public string ClassRelateField
        //{ get; set; }

        public megaText()
        {
            InitializeComponent();
            setWidthColumns();
            //this.Dock = System.Windows.Forms.DockStyle.Top;
            //this.AutoSize = true;
            //Text_IsNumber = false;
            //ClassMember = "";
            //ClassRelateField = "";
        }

        private void megaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(Convert.ToInt32(e.KeyChar)==13 && Text_Multiline==false) { SendKeys.Send("{TAB}"); }          
        }

        private void megaTextBox_Leave(object sender, EventArgs e)
        {
            setFormat();
        }

        private void megaTextBox_Enter(object sender, EventArgs e)
        {
            setFormat();
        }

        private void setFormat()
        {
            if (Text_IsNumber)
            {
                try
                {
                    //megaTextBox.Text = Convert.ToDecimal(megaTextBox.Text).ToString("#0.00");
                    megaTextBox.Text = Convert.ToDecimal(megaTextBox.Text).ToString();
                }
                catch { megaTextBox.Text = "0"; }
            }
        }

        private void megaText_Resize(object sender, EventArgs e)
        {
            //if(Text_Multiline) { 
            //    int t = this.Height - (megaLabel.Height+ megaLabel.Top+4);
            //    if (t < 20) t = 20;
            //    megaTextBox.Height = t;
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(megaTextBox.Visible==false)
            {
                string tmp = "";
                try
                {
                    string tmpText = megaTextBox.Text;
                    if (textBox1.Visible && tmpText.Length > 0)
                    {
                        tmp = tmpText.Trim();
                        if(textBox2.Visible || textBox3.Visible || textBox4.Visible) if(tmp.IndexOf(" ") > 0) tmp = tmp.Substring(0, tmp.IndexOf(" ")).Trim();
                        textBox1.Text = tmp.Trim();
                    }
                    if (textBox2.Visible && tmpText.Replace(textBox1.Text, "").Trim().Length > 0)
                    {
                        tmp = tmpText.Trim();
                        if(textBox1.Visible) tmp = tmp.Substring(textBox1.Text.Length+1, tmp.Length - (textBox1.Text.Length+1)).Trim();
                        if(textBox3.Visible || textBox4.Visible) if(tmp.IndexOf(" ")>0) tmp= tmp.Substring(0, tmp.IndexOf(" ")).Trim();
                        textBox2.Text = tmp.Trim();
                    }
                    if (textBox3.Visible && tmpText.Replace(textBox1.Text, "").Replace(textBox2.Text, "").Trim().Length > 0)
                    {
                        tmp = tmpText.Trim();
                        if (textBox1.Visible) tmp = tmp.Substring(textBox1.Text.Length + 1, tmp.Length - (textBox1.Text.Length + 1)).Trim();
                        if (textBox2.Visible) tmp = tmp.Substring(textBox2.Text.Length + 1, tmp.Length - (textBox2.Text.Length + 1)).Trim();
                        if(textBox4.Visible)  if(tmp.IndexOf(" ") > 0) tmp = tmp.Substring(0, tmp.IndexOf(" ")).Trim();
                        textBox3.Text = tmp.Trim();
                    }
                    if (textBox4.Visible && tmpText.Replace(textBox1.Text, "").Replace(textBox2.Text, "").Replace(textBox3.Text, "").Trim().Length > 0)
                    {
                        tmp = tmpText.Trim();
                        if (textBox1.Visible) tmp = tmp.Replace(textBox1.Text, "");
                        if (textBox2.Visible) tmp = tmp.Replace(textBox2.Text, "");
                        if (textBox3.Visible) tmp = tmp.Replace(textBox3.Text, "");
                        if (tmp.IndexOf(" ") > 0) tmp = tmp.Substring(0, tmp.IndexOf(" "));
                        textBox4.Text = tmp.Trim();
                    }

                }
                catch(Exception ex) {
                    tmp = ex.Message;
                }
            }
            timer1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AddText();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AddText();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            AddText();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            AddText();
        }

        private void AddText()
        {
            string t1 = textBox1.Text.Replace(" ", "_").Trim(); if (t1.Length == 0 && textBox1.Visible) t1 = "-";
            string t2 = textBox2.Text.Replace(" ", "_").Trim(); if (t2.Length == 0 && textBox2.Visible) t2 = "-";
            string t3 = textBox3.Text.Replace(" ", "_").Trim(); if (t3.Length == 0 && textBox3.Visible) t3 = "-";
            string t4 = textBox4.Text.Replace(" ", "_").Trim(); if (t4.Length == 0 && textBox4.Visible) t4 = "-";
            megaTextBox.Text = t1 + " " + t2 + " " + t3 + " " + t4;
        }

        public void setWidthColumns()
        {
            
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int c = 0; c < tableLayoutPanel1.ColumnCount; c++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
            }

            int maxwidth = 100;
            int i = 0;
            if (textBox1.Visible == true) i++;
            if (textBox2.Visible == true) i++;
            if (textBox3.Visible == true) i++;
            if (textBox4.Visible == true) i++;

            if (textBox1.Visible == true)
                tableLayoutPanel1.ColumnStyles[0].Width = maxwidth / i;
            else
                tableLayoutPanel1.ColumnStyles[0].Width = 0;

            if (textBox2.Visible == true)
                tableLayoutPanel1.ColumnStyles[1].Width = maxwidth / i;
            else
                tableLayoutPanel1.ColumnStyles[1].Width = 0;

            if (textBox3.Visible == true)
                tableLayoutPanel1.ColumnStyles[2].Width = maxwidth / i;
            else
                tableLayoutPanel1.ColumnStyles[2].Width = 0;

            if (textBox4.Visible == true)
                tableLayoutPanel1.ColumnStyles[3].Width = maxwidth / i;
            else
                tableLayoutPanel1.ColumnStyles[3].Width = 0;
        }


    }
}
