namespace templates.UserControls
{
    partial class megaFind
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
            this.megaLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.megaDisplay = new System.Windows.Forms.Label();
            this.megaTextBox = new System.Windows.Forms.TextBox();
            this.megaButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // megaLabel
            // 
            this.megaLabel.AutoSize = true;
            this.megaLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.megaLabel.Location = new System.Drawing.Point(3, 0);
            this.megaLabel.Name = "megaLabel";
            this.megaLabel.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.megaLabel.Size = new System.Drawing.Size(1060, 18);
            this.megaLabel.TabIndex = 2;
            this.megaLabel.Text = this.megaLabel.Name;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.megaLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1066, 46);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.megaDisplay, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1066, 26);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // megaDisplay
            // 
            this.megaDisplay.AutoSize = true;
            this.megaDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.megaDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.megaDisplay.Location = new System.Drawing.Point(137, 0);
            this.megaDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.megaDisplay.Name = "megaDisplay";
            this.megaDisplay.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.megaDisplay.Size = new System.Drawing.Size(0, 26);
            this.megaDisplay.TabIndex = 7;
            // 
            // megaTextBox
            // 
            this.megaTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.megaTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.megaTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.megaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.megaTextBox.Location = new System.Drawing.Point(40, 3);
            this.megaTextBox.Name = "megaTextBox";
            this.megaTextBox.Size = new System.Drawing.Size(94, 21);
            this.megaTextBox.TabIndex = 5;
            this.megaTextBox.TextChanged += new System.EventHandler(this.megaTextBox_TextChanged);
            this.megaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.megaTextBox_KeyPress);
            // 
            // megaButton
            // 
            this.megaButton.BackColor = System.Drawing.SystemColors.Info;
            this.megaButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.megaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.megaButton.Location = new System.Drawing.Point(3, 3);
            this.megaButton.Name = "megaButton";
            this.megaButton.Size = new System.Drawing.Size(31, 20);
            this.megaButton.TabIndex = 6;
            this.megaButton.Text = "...";
            this.megaButton.UseVisualStyleBackColor = false;
            this.megaButton.Click += new System.EventHandler(this.megaButton_Click);
            // 
            // megaFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "megaFind";
            this.Size = new System.Drawing.Size(1066, 46);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label megaLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label megaDisplay;
        public System.Windows.Forms.TextBox megaTextBox;
        private System.Windows.Forms.Button megaButton;
    }
}
