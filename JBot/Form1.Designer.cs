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
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocationDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blview)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 253);
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
            this.statusStrip1.Size = new System.Drawing.Size(551, 22);
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
            this.button2.Location = new System.Drawing.Point(0, 256);
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
            this.LocationDisplay.Location = new System.Drawing.Point(0, 0);
            this.LocationDisplay.Name = "LocationDisplay";
            this.LocationDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LocationDisplay.RowHeadersVisible = false;
            this.LocationDisplay.Size = new System.Drawing.Size(498, 250);
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
            this.blview.Location = new System.Drawing.Point(0, 0);
            this.blview.Name = "blview";
            this.blview.RowHeadersVisible = false;
            this.blview.ShowEditingIcon = false;
            this.blview.Size = new System.Drawing.Size(516, 251);
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
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(0, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(109, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Send";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Hello";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(109, 253);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "UpdateStats";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(527, 306);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.blview);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(519, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BattleList";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LocationDisplay);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(519, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Walker";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(519, 280);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Extras";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(190, 257);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "UpdateStatus";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 343);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocationDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blview)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

