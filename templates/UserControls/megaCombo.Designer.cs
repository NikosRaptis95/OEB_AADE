namespace templates.UserControls
{
    partial class megaCombo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.megaComboBox = new System.Windows.Forms.ComboBox();
            this.megaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // megaComboBox
            // 
            this.megaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.megaComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.megaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.megaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.megaComboBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.megaComboBox.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third"});
            this.megaComboBox.Location = new System.Drawing.Point(0, 24);
            this.megaComboBox.Name = "megaComboBox";
            this.megaComboBox.Size = new System.Drawing.Size(172, 23);
            this.megaComboBox.TabIndex = 0;
            this.megaComboBox.SelectedIndexChanged += new System.EventHandler(this.megaComboBox_SelectedIndexChanged);
            this.megaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.megaComboBox_KeyPress);
            // 
            // megaLabel
            // 
            this.megaLabel.AutoSize = true;
            this.megaLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.megaLabel.Location = new System.Drawing.Point(0, 0);
            this.megaLabel.Name = "megaLabel";
            this.megaLabel.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.megaLabel.Size = new System.Drawing.Size(82, 18);
            this.megaLabel.TabIndex = 1;
            this.megaLabel.Text = this.megaLabel.Name;
            // 
            // megaCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.megaLabel);
            this.Controls.Add(this.megaComboBox);
            this.Name = "megaCombo";
            this.Size = new System.Drawing.Size(172, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label megaLabel;
        public System.Windows.Forms.ComboBox megaComboBox;
    }
}
