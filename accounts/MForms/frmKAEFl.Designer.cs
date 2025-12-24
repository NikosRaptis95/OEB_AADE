namespace DesktopBusiness.MForms
{
    partial class frmKAEFl
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
            this.megaText_id = new templates.UserControls.megaText();
            this.megaText_Kae = new templates.UserControls.megaText();
            this.megaText_amount = new templates.UserControls.megaText();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(800, 140);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.tableLayoutPanel2);
            this.Page1.Size = new System.Drawing.Size(792, 114);
            // 
            // megaText_id
            // 
            this.megaText_id.AutoSize = true;
            this.megaText_id.datafield = "id";
            this.megaText_id.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_id.Location = new System.Drawing.Point(4, 4);
            this.megaText_id.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_id.Name = "megaText_id";
            this.megaText_id.Size = new System.Drawing.Size(385, 39);
            this.megaText_id.TabIndex = 0;
            this.megaText_id.Text_Default = null;
            this.megaText_id.Text_Height = 21;
            this.megaText_id.Text_IsNumber = false;
            this.megaText_id.Text_Label = "Κωδικός";
            this.megaText_id.Text_MaxLength = 10;
            this.megaText_id.Text_Multiline = false;
            this.megaText_id.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_id.Text_Textbox = "";
            // 
            // megaText_Kae
            // 
            this.megaText_Kae.AutoSize = true;
            this.megaText_Kae.datafield = "Kae";
            this.megaText_Kae.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_Kae.Location = new System.Drawing.Point(4, 58);
            this.megaText_Kae.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_Kae.Name = "megaText_Kae";
            this.megaText_Kae.Size = new System.Drawing.Size(385, 39);
            this.megaText_Kae.TabIndex = 22;
            this.megaText_Kae.Text_Default = null;
            this.megaText_Kae.Text_Height = 21;
            this.megaText_Kae.Text_IsNumber = false;
            this.megaText_Kae.Text_Label = "ΚΑΕ";
            this.megaText_Kae.Text_MaxLength = 50;
            this.megaText_Kae.Text_Multiline = false;
            this.megaText_Kae.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Kae.Text_Textbox = "";
            // 
            // megaText_amount
            // 
            this.megaText_amount.AutoSize = true;
            this.megaText_amount.datafield = "amount";
            this.megaText_amount.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_amount.Location = new System.Drawing.Point(397, 58);
            this.megaText_amount.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_amount.Name = "megaText_amount";
            this.megaText_amount.Size = new System.Drawing.Size(385, 39);
            this.megaText_amount.TabIndex = 23;
            this.megaText_amount.Text_Default = null;
            this.megaText_amount.Text_Height = 21;
            this.megaText_amount.Text_IsNumber = false;
            this.megaText_amount.Text_Label = "Σύνολο";
            this.megaText_amount.Text_MaxLength = 20;
            this.megaText_amount.Text_Multiline = false;
            this.megaText_amount.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_amount.Text_Textbox = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.megaText_amount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaText_Kae, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaText_id, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(786, 108);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // frmKAEFl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 161);
            this.Name = "frmKAEFl";
            this.Text = "frmKAEFl";
            this.tabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private templates.UserControls.megaText megaText_amount;
        private templates.UserControls.megaText megaText_Kae;
        private templates.UserControls.megaText megaText_id;
    }
}