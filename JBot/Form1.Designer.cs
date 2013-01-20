namespace JBot
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.HealthLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ManaLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.LocationDisplay = new System.Windows.Forms.DataGridView();
            this.XPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blview = new System.Windows.Forms.DataGridView();
            this.NameDisplayBl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisibleDisplayBl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDisplayBl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XDisplayBl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YDisplayBl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZDisplayBl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeDisplayBl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocationDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blview)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Refresh HPMP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HealthLabel,
            this.ManaLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 321);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(635, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // HealthLabel
            // 
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(46, 17);
            this.HealthLabel.Text = "HP: 0/0";
            // 
            // ManaLabel
            // 
            this.ManaLabel.Name = "ManaLabel";
            this.ManaLabel.Size = new System.Drawing.Size(48, 17);
            this.ManaLabel.Text = "MP: 0/0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Location";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LocationDisplay
            // 
            this.LocationDisplay.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LocationDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LocationDisplay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.LocationDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LocationDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XPos,
            this.YPos,
            this.ZPos});
            this.LocationDisplay.Location = new System.Drawing.Point(0, 231);
            this.LocationDisplay.Name = "LocationDisplay";
            this.LocationDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LocationDisplay.RowHeadersVisible = false;
            this.LocationDisplay.Size = new System.Drawing.Size(191, 87);
            this.LocationDisplay.TabIndex = 5;
            // 
            // XPos
            // 
            this.XPos.HeaderText = "X";
            this.XPos.Name = "XPos";
            this.XPos.Width = 75;
            // 
            // YPos
            // 
            this.YPos.HeaderText = "Y";
            this.YPos.Name = "YPos";
            this.YPos.Width = 75;
            // 
            // ZPos
            // 
            this.ZPos.HeaderText = "Z";
            this.ZPos.Name = "ZPos";
            this.ZPos.Width = 30;
            // 
            // blview
            // 
            this.blview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blview.BackgroundColor = System.Drawing.SystemColors.Control;
            this.blview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameDisplayBl,
            this.VisibleDisplayBl,
            this.IDDisplayBl,
            this.XDisplayBl,
            this.YDisplayBl,
            this.ZDisplayBl,
            this.TypeDisplayBl});
            this.blview.Location = new System.Drawing.Point(12, 41);
            this.blview.Name = "blview";
            this.blview.RowHeadersVisible = false;
            this.blview.ShowEditingIcon = false;
            this.blview.Size = new System.Drawing.Size(611, 184);
            this.blview.TabIndex = 6;
            // 
            // NameDisplayBl
            // 
            this.NameDisplayBl.HeaderText = "Name";
            this.NameDisplayBl.Name = "NameDisplayBl";
            // 
            // VisibleDisplayBl
            // 
            this.VisibleDisplayBl.HeaderText = "Visible";
            this.VisibleDisplayBl.Name = "VisibleDisplayBl";
            this.VisibleDisplayBl.Width = 50;
            // 
            // IDDisplayBl
            // 
            this.IDDisplayBl.HeaderText = "ID";
            this.IDDisplayBl.Name = "IDDisplayBl";
            this.IDDisplayBl.Width = 60;
            // 
            // XDisplayBl
            // 
            this.XDisplayBl.HeaderText = "X";
            this.XDisplayBl.Name = "XDisplayBl";
            this.XDisplayBl.Width = 75;
            // 
            // YDisplayBl
            // 
            this.YDisplayBl.HeaderText = "Y";
            this.YDisplayBl.Name = "YDisplayBl";
            this.YDisplayBl.Width = 75;
            // 
            // ZDisplayBl
            // 
            this.ZDisplayBl.HeaderText = "Z";
            this.ZDisplayBl.Name = "ZDisplayBl";
            this.ZDisplayBl.Width = 50;
            // 
            // TypeDisplayBl
            // 
            this.TypeDisplayBl.HeaderText = "Type";
            this.TypeDisplayBl.Name = "TypeDisplayBl";
            this.TypeDisplayBl.Width = 50;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(548, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Battle List";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(548, 295);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Send";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(442, 297);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Hello";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 343);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.blview);
            this.Controls.Add(this.LocationDisplay);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocationDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel HealthLabel;
        private System.Windows.Forms.ToolStripStatusLabel ManaLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView LocationDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn XPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn YPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZPos;
        private System.Windows.Forms.DataGridView blview;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDisplayBl;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisibleDisplayBl;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDisplayBl;
        private System.Windows.Forms.DataGridViewTextBoxColumn XDisplayBl;
        private System.Windows.Forms.DataGridViewTextBoxColumn YDisplayBl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZDisplayBl;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeDisplayBl;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
    }
}

