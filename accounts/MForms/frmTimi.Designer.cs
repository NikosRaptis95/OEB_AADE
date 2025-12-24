namespace DesktopBusiness.MForms
{
    partial class frmTimi
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
            this.megaText_PEkpt = new templates.UserControls.megaText();
            this.megaText_Price = new templates.UserControls.megaText();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(391, 169);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.tableLayoutPanel1);
            this.Page1.Size = new System.Drawing.Size(383, 143);
            this.Page1.Text = "Δεδομένα Εγγραφής";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.megaText_PEkpt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.megaText_Price, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(377, 137);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // megaText_PEkpt
            // 
            this.megaText_PEkpt.datafield = "PEkpt";
            this.megaText_PEkpt.Location = new System.Drawing.Point(3, 3);
            this.megaText_PEkpt.Name = "megaText_PEkpt";
            this.megaText_PEkpt.Size = new System.Drawing.Size(371, 44);
            this.megaText_PEkpt.TabIndex = 2;
            this.megaText_PEkpt.Text_Default = null;
            this.megaText_PEkpt.Text_Height = 21;
            this.megaText_PEkpt.Text_IsNumber = true;
            this.megaText_PEkpt.Text_Label = "Έκπτωση";
            this.megaText_PEkpt.Text_MaxLength = 32767;
            this.megaText_PEkpt.Text_Multiline = false;
            this.megaText_PEkpt.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_PEkpt.Text_Textbox = "";
            // 
            // megaText_Price
            // 
            this.megaText_Price.datafield = "Price";
            this.megaText_Price.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_Price.Location = new System.Drawing.Point(3, 53);
            this.megaText_Price.Name = "megaText_Price";
            this.megaText_Price.Size = new System.Drawing.Size(371, 71);
            this.megaText_Price.TabIndex = 3;
            this.megaText_Price.Text_Default = null;
            this.megaText_Price.Text_Height = 21;
            this.megaText_Price.Text_IsNumber = true;
            this.megaText_Price.Text_Label = "Τιμή";
            this.megaText_Price.Text_MaxLength = 32767;
            this.megaText_Price.Text_Multiline = false;
            this.megaText_Price.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Price.Text_Textbox = "";
            // 
            // frmTimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 190);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmTimi";
            this.tabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private templates.UserControls.megaText megaText_Price;
        private templates.UserControls.megaText megaText_PEkpt;
    }
}