namespace templates.UserControls
{
    partial class megaTrackBar
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.megaLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.megaTextBox = new System.Windows.Forms.TextBox();
            this.mega_trackBar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mega_trackBar)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(312, 46);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // megaLabel
            // 
            this.megaLabel.AutoSize = true;
            this.megaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.megaLabel.Location = new System.Drawing.Point(3, 0);
            this.megaLabel.Name = "megaLabel";
            this.megaLabel.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.megaLabel.Size = new System.Drawing.Size(306, 20);
            this.megaLabel.TabIndex = 2;
            this.megaLabel.Text = this.megaLabel.Name;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.megaTextBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mega_trackBar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(312, 26);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // megaTextBox
            // 
            this.megaTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.megaTextBox.Location = new System.Drawing.Point(3, 3);
            this.megaTextBox.MaxLength = 4;
            this.megaTextBox.Name = "megaTextBox";
            this.megaTextBox.Size = new System.Drawing.Size(64, 20);
            this.megaTextBox.TabIndex = 5;
            this.megaTextBox.Text = "0";
            this.megaTextBox.TextChanged += new System.EventHandler(this.megaTextBox_TextChanged);
            this.megaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.megaTextBox_KeyPress);
            this.megaTextBox.Leave += new System.EventHandler(this.megaTextBox_Leave);
            // 
            // mega_trackBar
            // 
            this.mega_trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mega_trackBar.Location = new System.Drawing.Point(73, 3);
            this.mega_trackBar.Maximum = 9999;
            this.mega_trackBar.Name = "mega_trackBar";
            this.mega_trackBar.Size = new System.Drawing.Size(236, 20);
            this.mega_trackBar.TabIndex = 6;
            this.mega_trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mega_trackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // megaTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "megaTrackBar";
            this.Size = new System.Drawing.Size(312, 46);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mega_trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label megaLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TextBox megaTextBox;
        public System.Windows.Forms.TrackBar mega_trackBar;
    }
}
