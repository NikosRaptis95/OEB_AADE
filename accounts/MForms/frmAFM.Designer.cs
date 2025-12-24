namespace DesktopBusiness.MForms
{
    partial class frmAFM
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.megaText_DateTimeSend = new templates.UserControls.megaText();
            this.megaText_anstext = new templates.UserControls.megaText();
            this.megaText_status = new templates.UserControls.megaText();
            this.megaText_ansXML = new templates.UserControls.megaText();
            this.megaText_sendXML = new templates.UserControls.megaText();
            this.megaText_SynAFM = new templates.UserControls.megaText();
            this.megaText_amount = new templates.UserControls.megaText();
            this.megaText_AFM = new templates.UserControls.megaText();
            this.megaText_id = new templates.UserControls.megaText();
            this.megaText_Sxol = new templates.UserControls.megaText();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(1187, 558);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.tableLayoutPanel2);
            this.Page1.Size = new System.Drawing.Size(1179, 532);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.megaText_Sxol, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaText_DateTimeSend, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.megaText_anstext, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.megaText_status, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.megaText_ansXML, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.megaText_sendXML, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.megaText_SynAFM, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaText_amount, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.megaText_AFM, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaText_id, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1173, 526);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // megaText_DateTimeSend
            // 
            this.megaText_DateTimeSend.AutoSize = true;
            this.megaText_DateTimeSend.datafield = "DateTimeSend";
            this.megaText_DateTimeSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_DateTimeSend.Location = new System.Drawing.Point(4, 409);
            this.megaText_DateTimeSend.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_DateTimeSend.Name = "megaText_DateTimeSend";
            this.megaText_DateTimeSend.Size = new System.Drawing.Size(695, 39);
            this.megaText_DateTimeSend.TabIndex = 29;
            this.megaText_DateTimeSend.Text_Default = null;
            this.megaText_DateTimeSend.Text_Height = 21;
            this.megaText_DateTimeSend.Text_IsNumber = false;
            this.megaText_DateTimeSend.Text_Label = "Ημερομηνία και Ώρα αποστολής (yyyy-MM-dd HH:mm:ss)";
            this.megaText_DateTimeSend.Text_MaxLength = 50;
            this.megaText_DateTimeSend.Text_Multiline = false;
            this.megaText_DateTimeSend.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_DateTimeSend.Text_Textbox = "";
            // 
            // megaText_anstext
            // 
            this.megaText_anstext.AutoSize = true;
            this.megaText_anstext.datafield = "anstext";
            this.megaText_anstext.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_anstext.Location = new System.Drawing.Point(707, 409);
            this.megaText_anstext.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_anstext.Name = "megaText_anstext";
            this.megaText_anstext.Size = new System.Drawing.Size(462, 39);
            this.megaText_anstext.TabIndex = 28;
            this.megaText_anstext.Text_Default = null;
            this.megaText_anstext.Text_Height = 21;
            this.megaText_anstext.Text_IsNumber = false;
            this.megaText_anstext.Text_Label = "Απάντηση";
            this.megaText_anstext.Text_MaxLength = 50;
            this.megaText_anstext.Text_Multiline = false;
            this.megaText_anstext.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_anstext.Text_Textbox = "";
            // 
            // megaText_status
            // 
            this.megaText_status.AutoSize = true;
            this.megaText_status.datafield = "status";
            this.megaText_status.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_status.Location = new System.Drawing.Point(4, 469);
            this.megaText_status.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_status.Name = "megaText_status";
            this.megaText_status.Size = new System.Drawing.Size(695, 39);
            this.megaText_status.TabIndex = 27;
            this.megaText_status.Text_Default = null;
            this.megaText_status.Text_Height = 21;
            this.megaText_status.Text_IsNumber = false;
            this.megaText_status.Text_Label = "Status (0/1/2)";
            this.megaText_status.Text_MaxLength = 1;
            this.megaText_status.Text_Multiline = false;
            this.megaText_status.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_status.Text_Textbox = "";
            // 
            // megaText_ansXML
            // 
            this.megaText_ansXML.AutoSize = true;
            this.megaText_ansXML.datafield = "ansXML";
            this.megaText_ansXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_ansXML.Location = new System.Drawing.Point(707, 217);
            this.megaText_ansXML.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_ansXML.Name = "megaText_ansXML";
            this.megaText_ansXML.Size = new System.Drawing.Size(462, 184);
            this.megaText_ansXML.TabIndex = 26;
            this.megaText_ansXML.Text_Default = null;
            this.megaText_ansXML.Text_Height = 170;
            this.megaText_ansXML.Text_IsNumber = false;
            this.megaText_ansXML.Text_Label = "Απάντηση XML";
            this.megaText_ansXML.Text_MaxLength = 1024;
            this.megaText_ansXML.Text_Multiline = true;
            this.megaText_ansXML.Text_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.megaText_ansXML.Text_Textbox = "";
            // 
            // megaText_sendXML
            // 
            this.megaText_sendXML.AutoSize = true;
            this.megaText_sendXML.datafield = "sendXML";
            this.megaText_sendXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_sendXML.Location = new System.Drawing.Point(4, 217);
            this.megaText_sendXML.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_sendXML.Name = "megaText_sendXML";
            this.megaText_sendXML.Size = new System.Drawing.Size(695, 184);
            this.megaText_sendXML.TabIndex = 25;
            this.megaText_sendXML.Text_Default = null;
            this.megaText_sendXML.Text_Height = 170;
            this.megaText_sendXML.Text_IsNumber = false;
            this.megaText_sendXML.Text_Label = "Απεσταλμένο XML";
            this.megaText_sendXML.Text_MaxLength = 1024;
            this.megaText_sendXML.Text_Multiline = true;
            this.megaText_sendXML.Text_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.megaText_sendXML.Text_Textbox = "";
            this.megaText_sendXML.Load += new System.EventHandler(this.megaText_sendXML_Load);
            // 
            // megaText_SynAFM
            // 
            this.megaText_SynAFM.AutoSize = true;
            this.megaText_SynAFM.datafield = "SynAFM";
            this.megaText_SynAFM.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_SynAFM.Location = new System.Drawing.Point(4, 64);
            this.megaText_SynAFM.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_SynAFM.Name = "megaText_SynAFM";
            this.megaText_SynAFM.Size = new System.Drawing.Size(695, 145);
            this.megaText_SynAFM.TabIndex = 24;
            this.megaText_SynAFM.Text_Default = null;
            this.megaText_SynAFM.Text_Height = 150;
            this.megaText_SynAFM.Text_IsNumber = false;
            this.megaText_SynAFM.Text_Label = "Συνυπόχρεα ΑΦΜ (ΑΦΜ + shift + enter) ή Υπογραφοντες (ΑΦΜ ΟΝΟΜΑ ΕΠΩΝΥΜΟ <shift + e" +
    "nter>) + Μορφοποίηση";
            this.megaText_SynAFM.Text_MaxLength = 1024;
            this.megaText_SynAFM.Text_Multiline = true;
            this.megaText_SynAFM.Text_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.megaText_SynAFM.Text_Textbox = "";
            // 
            // megaText_amount
            // 
            this.megaText_amount.AutoSize = true;
            this.megaText_amount.datafield = "amount";
            this.megaText_amount.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_amount.Location = new System.Drawing.Point(707, 469);
            this.megaText_amount.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_amount.Name = "megaText_amount";
            this.megaText_amount.Size = new System.Drawing.Size(462, 39);
            this.megaText_amount.TabIndex = 23;
            this.megaText_amount.Text_Default = null;
            this.megaText_amount.Text_Height = 21;
            this.megaText_amount.Text_IsNumber = false;
            this.megaText_amount.Text_Label = "Σύνολο";
            this.megaText_amount.Text_MaxLength = 15;
            this.megaText_amount.Text_Multiline = false;
            this.megaText_amount.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_amount.Text_Textbox = "";
            // 
            // megaText_AFM
            // 
            this.megaText_AFM.AutoSize = true;
            this.megaText_AFM.datafield = "AFM";
            this.megaText_AFM.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_AFM.Location = new System.Drawing.Point(707, 4);
            this.megaText_AFM.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_AFM.Name = "megaText_AFM";
            this.megaText_AFM.Size = new System.Drawing.Size(462, 39);
            this.megaText_AFM.TabIndex = 22;
            this.megaText_AFM.Text_Default = null;
            this.megaText_AFM.Text_Height = 21;
            this.megaText_AFM.Text_IsNumber = false;
            this.megaText_AFM.Text_Label = "ΑΦΜ";
            this.megaText_AFM.Text_MaxLength = 50;
            this.megaText_AFM.Text_Multiline = false;
            this.megaText_AFM.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_AFM.Text_Textbox = "";
            // 
            // megaText_id
            // 
            this.megaText_id.AutoSize = true;
            this.megaText_id.datafield = "id";
            this.megaText_id.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_id.Location = new System.Drawing.Point(4, 4);
            this.megaText_id.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_id.Name = "megaText_id";
            this.megaText_id.Size = new System.Drawing.Size(695, 39);
            this.megaText_id.TabIndex = 0;
            this.megaText_id.Text_Default = null;
            this.megaText_id.Text_Height = 21;
            this.megaText_id.Text_IsNumber = false;
            this.megaText_id.Text_Label = "Κωδικός";
            this.megaText_id.Text_MaxLength = 50;
            this.megaText_id.Text_Multiline = false;
            this.megaText_id.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_id.Text_Textbox = "";
            // 
            // megaText_Sxol
            // 
            this.megaText_Sxol.AutoSize = true;
            this.megaText_Sxol.datafield = "Sxol";
            this.megaText_Sxol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_Sxol.Location = new System.Drawing.Point(707, 64);
            this.megaText_Sxol.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_Sxol.Name = "megaText_Sxol";
            this.megaText_Sxol.Size = new System.Drawing.Size(462, 145);
            this.megaText_Sxol.TabIndex = 30;
            this.megaText_Sxol.Text_Default = null;
            this.megaText_Sxol.Text_Height = 170;
            this.megaText_Sxol.Text_IsNumber = false;
            this.megaText_Sxol.Text_Label = "Παρατηρήσεις";
            this.megaText_Sxol.Text_MaxLength = 1024;
            this.megaText_Sxol.Text_Multiline = true;
            this.megaText_Sxol.Text_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.megaText_Sxol.Text_Textbox = "";
            // 
            // frmAFM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 579);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAFM";
            this.Text = "frmAFM";
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
        private templates.UserControls.megaText megaText_AFM;
        private templates.UserControls.megaText megaText_id;
        private templates.UserControls.megaText megaText_SynAFM;
        private templates.UserControls.megaText megaText_sendXML;
        private templates.UserControls.megaText megaText_ansXML;
        private templates.UserControls.megaText megaText_anstext;
        private templates.UserControls.megaText megaText_status;
        private templates.UserControls.megaText megaText_DateTimeSend;
        private templates.UserControls.megaText megaText_Sxol;
    }
}