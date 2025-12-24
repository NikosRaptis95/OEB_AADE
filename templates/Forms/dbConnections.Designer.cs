namespace templates.Forms
{
    partial class dbConnections
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbConnections));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label_description = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.label_code = new System.Windows.Forms.Label();
            this.textBox_code = new System.Windows.Forms.TextBox();
            this.textBox_contype = new System.Windows.Forms.TextBox();
            this.label_contype = new System.Windows.Forms.Label();
            this.label_connectionstring = new System.Windows.Forms.Label();
            this.textBox_connectionstring = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ενημέρωσηToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(337, 121);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(13, 185);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(61, 13);
            this.label_description.TabIndex = 1;
            this.label_description.Text = "περιγραφή";
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(12, 201);
            this.textBox_description.MaxLength = 20;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ReadOnly = true;
            this.textBox_description.Size = new System.Drawing.Size(334, 20);
            this.textBox_description.TabIndex = 2;
            // 
            // label_code
            // 
            this.label_code.AutoSize = true;
            this.label_code.Location = new System.Drawing.Point(13, 141);
            this.label_code.Name = "label_code";
            this.label_code.Size = new System.Drawing.Size(41, 13);
            this.label_code.TabIndex = 3;
            this.label_code.Text = "αρχείο";
            // 
            // textBox_code
            // 
            this.textBox_code.Location = new System.Drawing.Point(13, 157);
            this.textBox_code.MaxLength = 100;
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.ReadOnly = true;
            this.textBox_code.Size = new System.Drawing.Size(334, 20);
            this.textBox_code.TabIndex = 4;
            // 
            // textBox_contype
            // 
            this.textBox_contype.Location = new System.Drawing.Point(12, 245);
            this.textBox_contype.MaxLength = 10;
            this.textBox_contype.Name = "textBox_contype";
            this.textBox_contype.ReadOnly = true;
            this.textBox_contype.Size = new System.Drawing.Size(334, 20);
            this.textBox_contype.TabIndex = 5;
            // 
            // label_contype
            // 
            this.label_contype.AutoSize = true;
            this.label_contype.Location = new System.Drawing.Point(15, 229);
            this.label_contype.Name = "label_contype";
            this.label_contype.Size = new System.Drawing.Size(90, 13);
            this.label_contype.TabIndex = 6;
            this.label_contype.Text = "τύπος σύνδεσης";
            // 
            // label_connectionstring
            // 
            this.label_connectionstring.AutoSize = true;
            this.label_connectionstring.Location = new System.Drawing.Point(15, 277);
            this.label_connectionstring.Name = "label_connectionstring";
            this.label_connectionstring.Size = new System.Drawing.Size(88, 13);
            this.label_connectionstring.TabIndex = 8;
            this.label_connectionstring.Text = "connection string";
            // 
            // textBox_connectionstring
            // 
            this.textBox_connectionstring.Location = new System.Drawing.Point(12, 293);
            this.textBox_connectionstring.Name = "textBox_connectionstring";
            this.textBox_connectionstring.ReadOnly = true;
            this.textBox_connectionstring.Size = new System.Drawing.Size(334, 20);
            this.textBox_connectionstring.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 331);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(361, 21);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.ενημέρωσηToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem3,
            this.refreshToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(67, 19);
            this.toolStripDropDownButton1.Text = "Επιλογές";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.newToolStripMenuItem.Text = "Νέα εγγραφή";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // ενημέρωσηToolStripMenuItem
            // 
            this.ενημέρωσηToolStripMenuItem.Name = "ενημέρωσηToolStripMenuItem";
            this.ενημέρωσηToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.ενημέρωσηToolStripMenuItem.Text = "Επεξεργασία";
            this.ενημέρωσηToolStripMenuItem.Click += new System.EventHandler(this.ενημέρωσηToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(243, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.deleteToolStripMenuItem.Text = "Διαγραφή";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(243, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.refreshToolStripMenuItem.Text = "Επιλογή σύνδεσης με την βάση !";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // dbConnections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 352);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label_connectionstring);
            this.Controls.Add(this.textBox_connectionstring);
            this.Controls.Add(this.label_contype);
            this.Controls.Add(this.textBox_contype);
            this.Controls.Add(this.textBox_code);
            this.Controls.Add(this.label_code);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dbConnections";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Σύνδεση με την Βάση δεδομένων";
            this.Load += new System.EventHandler(this.dbConnections_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.Label label_code;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.TextBox textBox_contype;
        private System.Windows.Forms.Label label_contype;
        private System.Windows.Forms.Label label_connectionstring;
        private System.Windows.Forms.TextBox textBox_connectionstring;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ενημέρωσηToolStripMenuItem;
    }
}