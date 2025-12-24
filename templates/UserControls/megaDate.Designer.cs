namespace templates.UserControls
{
    partial class megaDate
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
            this.megaDateBox = new System.Windows.Forms.DateTimePicker();
            this.megaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // megaDateBox
            // 
            this.megaDateBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.megaDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.megaDateBox.Location = new System.Drawing.Point(5, 29);
            this.megaDateBox.Name = "megaDateBox";
            this.megaDateBox.Size = new System.Drawing.Size(167, 21);
            this.megaDateBox.TabIndex = 0;
            // 
            // megaLabel
            // 
            this.megaLabel.AutoSize = true;
            this.megaLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.megaLabel.Location = new System.Drawing.Point(5, 0);
            this.megaLabel.Name = "megaLabel";
            this.megaLabel.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.megaLabel.Size = new System.Drawing.Size(82, 26);
            this.megaLabel.TabIndex = 1;
            this.megaLabel.Text = this.megaLabel.Name;
            // 
            // megaDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.megaLabel);
            this.Controls.Add(this.megaDateBox);
            this.Name = "megaDate";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Size = new System.Drawing.Size(172, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label megaLabel;
        public System.Windows.Forms.DateTimePicker megaDateBox;
    }
}
