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
    public partial class ParamEditor : Form
    {
        public ParamEditor()
        {
            InitializeComponent();
            paramTextBox.Font = new Font("Consolas", 10);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
                {
                if (filename != "")
                {
                    System.IO.File.WriteAllText(filename, paramTextBox.Text);
                    MessageBox.Show("Καταχωρήθηκε το " + filename);
                }
                else
                {
                    MessageBox.Show("Δεν υπαρχει όνομα αρχείου.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Σφάλμα στην καταχώρηση αρχείου: " + ex.Message);
            }

            
        }

        public string filename = "";
        
        private void ParamEditor_Load(object sender, EventArgs e)
        {
            if(filename != "")
            {
                filename = @"params\"+ filename;
                this.Text = "Παράμετροι - " + filename;
                try
                {
                    paramTextBox.Text = System.IO.File.ReadAllText(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Σφάλμα στην ανάγνωση αρχείου: " + ex.Message);
                }
            }            
        }

        private void ParamEditor_Resize(object sender, EventArgs e)
        {
           
        }

        private void ParamEditor_ResizeBegin(object sender, EventArgs e)
        {
           
        }
    }
}
