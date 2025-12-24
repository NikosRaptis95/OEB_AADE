namespace DesktopBusiness.MForms
{
    partial class frmKinFl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKinFl));
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_id = new System.Windows.Forms.Label();
            this.label_IdSyn_Name = new System.Windows.Forms.Label();
            this.textBox_IdSyn_Name = new System.Windows.Forms.TextBox();
            this.label_Status = new System.Windows.Forms.Label();
            this.label_SalesPerson = new System.Windows.Forms.Label();
            this.textBox_Status = new System.Windows.Forms.ComboBox();
            this.textBox_RegistryDate = new System.Windows.Forms.DateTimePicker();
            this.label_RegistryDate = new System.Windows.Forms.Label();
            this.textBox_KoKiKin = new System.Windows.Forms.ComboBox();
            this.label_KoKiKin = new System.Windows.Forms.Label();
            this.label_IdSyn_Id = new System.Windows.Forms.Label();
            this.textBox_IdSyn_Id = new System.Windows.Forms.TextBox();
            this.button_idSyn = new System.Windows.Forms.Button();
            this.label_Summary = new System.Windows.Forms.Label();
            this.textBox_Summary = new System.Windows.Forms.TextBox();
            this.label_Memo = new System.Windows.Forms.Label();
            this.textBox_Memo = new System.Windows.Forms.TextBox();
            this.textBox_Cash = new System.Windows.Forms.CheckBox();
            this.label_timok = new System.Windows.Forms.Label();
            this.textBox_timokat = new System.Windows.Forms.TextBox();
            this.label_ypol = new System.Windows.Forms.Label();
            this.textBox_ypol = new System.Windows.Forms.TextBox();
            this.textBox_AitiKin = new System.Windows.Forms.ComboBox();
            this.label_AitiKin = new System.Windows.Forms.CheckBox();
            this.label_Seira = new System.Windows.Forms.CheckBox();
            this.textBox_Seira = new System.Windows.Forms.ComboBox();
            this.textBox_SalesPerson = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(338, 64);
            this.textBox_id.MaxLength = 60;
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(314, 20);
            this.textBox_id.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(664, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.toolStripMenuItem3,
            this.refreshToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(67, 20);
            this.toolStripDropDownButton1.Text = "Επιλογές";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.updateToolStripMenuItem.Text = "Αποθήκευση";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(192, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.refreshToolStripMenuItem.Text = "Ακύρωση - Ανανέωση";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(342, 47);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(122, 13);
            this.label_id.TabIndex = 12;
            this.label_id.Text = "αριθμός παραστατικού";
            // 
            // label_IdSyn_Name
            // 
            this.label_IdSyn_Name.AutoSize = true;
            this.label_IdSyn_Name.Location = new System.Drawing.Point(340, 90);
            this.label_IdSyn_Name.Name = "label_IdSyn_Name";
            this.label_IdSyn_Name.Size = new System.Drawing.Size(184, 13);
            this.label_IdSyn_Name.TabIndex = 33;
            this.label_IdSyn_Name.Text = "όνομα - επωνυμία συναλλασόμενου";
            // 
            // textBox_IdSyn_Name
            // 
            this.textBox_IdSyn_Name.Location = new System.Drawing.Point(338, 107);
            this.textBox_IdSyn_Name.MaxLength = 100;
            this.textBox_IdSyn_Name.Name = "textBox_IdSyn_Name";
            this.textBox_IdSyn_Name.ReadOnly = true;
            this.textBox_IdSyn_Name.Size = new System.Drawing.Size(314, 20);
            this.textBox_IdSyn_Name.TabIndex = 31;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(340, 226);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(35, 13);
            this.label_Status.TabIndex = 41;
            this.label_Status.Text = "status";
            // 
            // label_SalesPerson
            // 
            this.label_SalesPerson.AutoSize = true;
            this.label_SalesPerson.Location = new System.Drawing.Point(18, 226);
            this.label_SalesPerson.Name = "label_SalesPerson";
            this.label_SalesPerson.Size = new System.Drawing.Size(50, 13);
            this.label_SalesPerson.TabIndex = 40;
            this.label_SalesPerson.Text = "χρήστης";
            // 
            // textBox_Status
            // 
            this.textBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBox_Status.FormattingEnabled = true;
            this.textBox_Status.Location = new System.Drawing.Point(338, 243);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.Size = new System.Drawing.Size(314, 21);
            this.textBox_Status.TabIndex = 49;
            // 
            // textBox_RegistryDate
            // 
            this.textBox_RegistryDate.Location = new System.Drawing.Point(14, 22);
            this.textBox_RegistryDate.Name = "textBox_RegistryDate";
            this.textBox_RegistryDate.Size = new System.Drawing.Size(314, 20);
            this.textBox_RegistryDate.TabIndex = 50;
            // 
            // label_RegistryDate
            // 
            this.label_RegistryDate.AutoSize = true;
            this.label_RegistryDate.Location = new System.Drawing.Point(16, 6);
            this.label_RegistryDate.Name = "label_RegistryDate";
            this.label_RegistryDate.Size = new System.Drawing.Size(65, 13);
            this.label_RegistryDate.TabIndex = 51;
            this.label_RegistryDate.Text = "ημερομηνία";
            // 
            // textBox_KoKiKin
            // 
            this.textBox_KoKiKin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBox_KoKiKin.FormattingEnabled = true;
            this.textBox_KoKiKin.Location = new System.Drawing.Point(338, 21);
            this.textBox_KoKiKin.Name = "textBox_KoKiKin";
            this.textBox_KoKiKin.Size = new System.Drawing.Size(314, 21);
            this.textBox_KoKiKin.TabIndex = 53;
            this.textBox_KoKiKin.SelectedIndexChanged += new System.EventHandler(this.textBox_KoKiKin_SelectedIndexChanged);
            // 
            // label_KoKiKin
            // 
            this.label_KoKiKin.AutoSize = true;
            this.label_KoKiKin.Location = new System.Drawing.Point(340, 4);
            this.label_KoKiKin.Name = "label_KoKiKin";
            this.label_KoKiKin.Size = new System.Drawing.Size(79, 13);
            this.label_KoKiKin.TabIndex = 52;
            this.label_KoKiKin.Text = "τύπος κίνησης";
            // 
            // label_IdSyn_Id
            // 
            this.label_IdSyn_Id.AutoSize = true;
            this.label_IdSyn_Id.Location = new System.Drawing.Point(16, 90);
            this.label_IdSyn_Id.Name = "label_IdSyn_Id";
            this.label_IdSyn_Id.Size = new System.Drawing.Size(135, 13);
            this.label_IdSyn_Id.TabIndex = 55;
            this.label_IdSyn_Id.Text = "κωδικός συναλλασόμενου";
            // 
            // textBox_IdSyn_Id
            // 
            this.textBox_IdSyn_Id.Location = new System.Drawing.Point(14, 107);
            this.textBox_IdSyn_Id.MaxLength = 100;
            this.textBox_IdSyn_Id.Name = "textBox_IdSyn_Id";
            this.textBox_IdSyn_Id.Size = new System.Drawing.Size(280, 20);
            this.textBox_IdSyn_Id.TabIndex = 54;
            this.textBox_IdSyn_Id.TextChanged += new System.EventHandler(this.textBox_IdSyn_Id_TextChanged);
            // 
            // button_idSyn
            // 
            this.button_idSyn.Location = new System.Drawing.Point(295, 105);
            this.button_idSyn.Name = "button_idSyn";
            this.button_idSyn.Size = new System.Drawing.Size(32, 23);
            this.button_idSyn.TabIndex = 56;
            this.button_idSyn.Text = "...";
            this.button_idSyn.UseVisualStyleBackColor = true;
            this.button_idSyn.Click += new System.EventHandler(this.button_idSyn_Click);
            // 
            // label_Summary
            // 
            this.label_Summary.AutoSize = true;
            this.label_Summary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_Summary.Location = new System.Drawing.Point(494, 180);
            this.label_Summary.Name = "label_Summary";
            this.label_Summary.Size = new System.Drawing.Size(37, 13);
            this.label_Summary.TabIndex = 58;
            this.label_Summary.Text = "Ποσό";
            // 
            // textBox_Summary
            // 
            this.textBox_Summary.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_Summary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox_Summary.Location = new System.Drawing.Point(497, 196);
            this.textBox_Summary.MaxLength = 60;
            this.textBox_Summary.Name = "textBox_Summary";
            this.textBox_Summary.Size = new System.Drawing.Size(155, 20);
            this.textBox_Summary.TabIndex = 57;
            this.textBox_Summary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Memo
            // 
            this.label_Memo.AutoSize = true;
            this.label_Memo.Location = new System.Drawing.Point(16, 269);
            this.label_Memo.Name = "label_Memo";
            this.label_Memo.Size = new System.Drawing.Size(65, 13);
            this.label_Memo.TabIndex = 61;
            this.label_Memo.Text = "σημειώσεις";
            // 
            // textBox_Memo
            // 
            this.textBox_Memo.Location = new System.Drawing.Point(12, 286);
            this.textBox_Memo.Multiline = true;
            this.textBox_Memo.Name = "textBox_Memo";
            this.textBox_Memo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Memo.Size = new System.Drawing.Size(640, 100);
            this.textBox_Memo.TabIndex = 60;
            // 
            // textBox_Cash
            // 
            this.textBox_Cash.AutoSize = true;
            this.textBox_Cash.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.textBox_Cash.Checked = true;
            this.textBox_Cash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.textBox_Cash.Location = new System.Drawing.Point(17, 196);
            this.textBox_Cash.Name = "textBox_Cash";
            this.textBox_Cash.Size = new System.Drawing.Size(69, 17);
            this.textBox_Cash.TabIndex = 62;
            this.textBox_Cash.Text = "μετρητά";
            this.textBox_Cash.UseVisualStyleBackColor = true;
            // 
            // label_timok
            // 
            this.label_timok.AutoSize = true;
            this.label_timok.Location = new System.Drawing.Point(111, 180);
            this.label_timok.Name = "label_timok";
            this.label_timok.Size = new System.Drawing.Size(82, 13);
            this.label_timok.TabIndex = 64;
            this.label_timok.Text = "τιμοκατάλογος";
            // 
            // textBox_timokat
            // 
            this.textBox_timokat.Location = new System.Drawing.Point(105, 196);
            this.textBox_timokat.MaxLength = 100;
            this.textBox_timokat.Name = "textBox_timokat";
            this.textBox_timokat.ReadOnly = true;
            this.textBox_timokat.Size = new System.Drawing.Size(222, 20);
            this.textBox_timokat.TabIndex = 65;
            // 
            // label_ypol
            // 
            this.label_ypol.AutoSize = true;
            this.label_ypol.Location = new System.Drawing.Point(340, 180);
            this.label_ypol.Name = "label_ypol";
            this.label_ypol.Size = new System.Drawing.Size(51, 13);
            this.label_ypol.TabIndex = 67;
            this.label_ypol.Text = "υπόλοιπο";
            // 
            // textBox_ypol
            // 
            this.textBox_ypol.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_ypol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox_ypol.Location = new System.Drawing.Point(338, 196);
            this.textBox_ypol.MaxLength = 60;
            this.textBox_ypol.Name = "textBox_ypol";
            this.textBox_ypol.ReadOnly = true;
            this.textBox_ypol.Size = new System.Drawing.Size(153, 20);
            this.textBox_ypol.TabIndex = 68;
            this.textBox_ypol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_AitiKin
            // 
            this.textBox_AitiKin.FormattingEnabled = true;
            this.textBox_AitiKin.Location = new System.Drawing.Point(14, 151);
            this.textBox_AitiKin.Name = "textBox_AitiKin";
            this.textBox_AitiKin.Size = new System.Drawing.Size(638, 21);
            this.textBox_AitiKin.TabIndex = 69;
            // 
            // label_AitiKin
            // 
            this.label_AitiKin.AutoSize = true;
            this.label_AitiKin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_AitiKin.Checked = true;
            this.label_AitiKin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.label_AitiKin.Location = new System.Drawing.Point(19, 133);
            this.label_AitiKin.Name = "label_AitiKin";
            this.label_AitiKin.Size = new System.Drawing.Size(78, 17);
            this.label_AitiKin.TabIndex = 70;
            this.label_AitiKin.Text = "αιτιολογία";
            this.label_AitiKin.UseVisualStyleBackColor = true;
            this.label_AitiKin.CheckedChanged += new System.EventHandler(this.label_AitiKin_CheckedChanged);
            // 
            // label_Seira
            // 
            this.label_Seira.AutoSize = true;
            this.label_Seira.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_Seira.Checked = true;
            this.label_Seira.CheckState = System.Windows.Forms.CheckState.Checked;
            this.label_Seira.Location = new System.Drawing.Point(14, 48);
            this.label_Seira.Name = "label_Seira";
            this.label_Seira.Size = new System.Drawing.Size(55, 17);
            this.label_Seira.TabIndex = 71;
            this.label_Seira.Text = "σειρά";
            this.label_Seira.UseVisualStyleBackColor = true;
            this.label_Seira.CheckedChanged += new System.EventHandler(this.label_Seira_CheckedChanged);
            // 
            // textBox_Seira
            // 
            this.textBox_Seira.FormattingEnabled = true;
            this.textBox_Seira.Location = new System.Drawing.Point(12, 64);
            this.textBox_Seira.Name = "textBox_Seira";
            this.textBox_Seira.Size = new System.Drawing.Size(316, 21);
            this.textBox_Seira.TabIndex = 72;
            this.textBox_Seira.TextChanged += new System.EventHandler(this.textBox_Seira_TextChanged);
            // 
            // textBox_SalesPerson
            // 
            this.textBox_SalesPerson.Location = new System.Drawing.Point(17, 242);
            this.textBox_SalesPerson.MaxLength = 100;
            this.textBox_SalesPerson.Name = "textBox_SalesPerson";
            this.textBox_SalesPerson.ReadOnly = true;
            this.textBox_SalesPerson.Size = new System.Drawing.Size(311, 20);
            this.textBox_SalesPerson.TabIndex = 73;
            // 
            // frmKinFl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 417);
            this.Controls.Add(this.textBox_SalesPerson);
            this.Controls.Add(this.textBox_Seira);
            this.Controls.Add(this.label_Seira);
            this.Controls.Add(this.label_AitiKin);
            this.Controls.Add(this.textBox_AitiKin);
            this.Controls.Add(this.textBox_ypol);
            this.Controls.Add(this.label_ypol);
            this.Controls.Add(this.textBox_timokat);
            this.Controls.Add(this.label_timok);
            this.Controls.Add(this.textBox_Cash);
            this.Controls.Add(this.label_Memo);
            this.Controls.Add(this.textBox_Memo);
            this.Controls.Add(this.label_Summary);
            this.Controls.Add(this.textBox_Summary);
            this.Controls.Add(this.button_idSyn);
            this.Controls.Add(this.label_IdSyn_Id);
            this.Controls.Add(this.textBox_IdSyn_Id);
            this.Controls.Add(this.textBox_KoKiKin);
            this.Controls.Add(this.label_KoKiKin);
            this.Controls.Add(this.label_RegistryDate);
            this.Controls.Add(this.textBox_RegistryDate);
            this.Controls.Add(this.textBox_Status);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.label_SalesPerson);
            this.Controls.Add(this.label_IdSyn_Name);
            this.Controls.Add(this.textBox_IdSyn_Name);
            this.Controls.Add(this.label_id);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmKinFl";
            this.Text = "frmAccount";
            this.Load += new System.EventHandler(this.frmKinFl_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label_IdSyn_Name;
        private System.Windows.Forms.TextBox textBox_IdSyn_Name;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Label label_SalesPerson;
        private System.Windows.Forms.ComboBox textBox_Status;
        private System.Windows.Forms.DateTimePicker textBox_RegistryDate;
        private System.Windows.Forms.Label label_RegistryDate;
        private System.Windows.Forms.ComboBox textBox_KoKiKin;
        private System.Windows.Forms.Label label_KoKiKin;
        private System.Windows.Forms.Label label_IdSyn_Id;
        private System.Windows.Forms.TextBox textBox_IdSyn_Id;
        private System.Windows.Forms.Button button_idSyn;
        private System.Windows.Forms.Label label_Summary;
        private System.Windows.Forms.TextBox textBox_Summary;
        private System.Windows.Forms.Label label_Memo;
        private System.Windows.Forms.TextBox textBox_Memo;
        private System.Windows.Forms.CheckBox textBox_Cash;
        private System.Windows.Forms.Label label_timok;
        private System.Windows.Forms.TextBox textBox_timokat;
        private System.Windows.Forms.Label label_ypol;
        private System.Windows.Forms.TextBox textBox_ypol;
        private System.Windows.Forms.ComboBox textBox_AitiKin;
        private System.Windows.Forms.CheckBox label_AitiKin;
        private System.Windows.Forms.CheckBox label_Seira;
        private System.Windows.Forms.ComboBox textBox_Seira;
        private System.Windows.Forms.TextBox textBox_SalesPerson;
    }
}