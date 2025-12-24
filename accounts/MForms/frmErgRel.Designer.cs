namespace DesktopBusiness.MForms
{
    partial class frmErgRel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.megaText_Seira = new templates.UserControls.megaText();
            this.megaCombo_KoKi = new templates.UserControls.megaCombo();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(612, 136);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.tableLayoutPanel1);
            this.Page1.Size = new System.Drawing.Size(604, 110);
            this.Page1.Text = "Στοιχεία Εγγραφής";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.megaText_Seira, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.megaCombo_KoKi, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 104);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // megaText_Seira
            // 
            this.megaText_Seira.datafield = "Seira";
            this.megaText_Seira.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_Seira.Location = new System.Drawing.Point(3, 58);
            this.megaText_Seira.Name = "megaText_Seira";
            this.megaText_Seira.Size = new System.Drawing.Size(592, 46);
            this.megaText_Seira.TabIndex = 0;
            this.megaText_Seira.Text_Default = null;
            this.megaText_Seira.Text_Height = 21;
            this.megaText_Seira.Text_IsNumber = false;
            this.megaText_Seira.Text_Label = "Σειρά";
            this.megaText_Seira.Text_MaxLength = 2;
            this.megaText_Seira.Text_Multiline = false;
            this.megaText_Seira.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Seira.Text_Textbox = "";
            // 
            // megaCombo_KoKi
            // 
            this.megaCombo_KoKi.AutoSize = true;
            this.megaCombo_KoKi.datafield = "KoKi";
            this.megaCombo_KoKi.DataSource = null;
            this.megaCombo_KoKi.DisplayMember = "Name";
            this.megaCombo_KoKi.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_KoKi.Location = new System.Drawing.Point(3, 3);
            this.megaCombo_KoKi.Name = "megaCombo_KoKi";
            this.megaCombo_KoKi.Size = new System.Drawing.Size(592, 41);
            this.megaCombo_KoKi.TabIndex = 1;
            this.megaCombo_KoKi.Text_Label = "Κωδικός Κίνησης";
            this.megaCombo_KoKi.Text_Textbox = "";
            this.megaCombo_KoKi.ValueMember = "";
            // 
            // frmErgRel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(612, 157);
            this.Name = "frmErgRel";
            this.tabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private templates.UserControls.megaText megaText_Seira;
        private templates.UserControls.megaCombo megaCombo_KoKi;
    }
}
