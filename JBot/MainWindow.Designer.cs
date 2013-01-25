namespace JBot
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.HealthLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ManaLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripSplitButton();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.HotkeyLabel = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.MinManaLabel = new System.Windows.Forms.Label();
            this.MaxHealLabel = new System.Windows.Forms.Label();
            this.MinHealLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocationDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blview)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HealthLabel,
            this.ManaLabel,
            this.toolStripDropDownButton1});
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
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownButtonWidth = 0;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(21, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ButtonClick += new System.EventHandler(this.toolStripDropDownButton1_ButtonClick);
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
            this.blview.Size = new System.Drawing.Size(540, 266);
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
            this.button3.Location = new System.Drawing.Point(0, 272);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(551, 321);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.blview);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(543, 295);
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
            this.tabPage2.Size = new System.Drawing.Size(543, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Walker";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button10);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(543, 295);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Extras";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(468, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "Client";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Location = new System.Drawing.Point(3, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Walker";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "^";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(88, 39);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(32, 23);
            this.button7.TabIndex = 13;
            this.button7.Text = ">";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(50, 58);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(32, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "v";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 39);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(32, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "<";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button9);
            this.tabPage4.Controls.Add(this.checkBox1);
            this.tabPage4.Controls.Add(this.HotkeyLabel);
            this.tabPage4.Controls.Add(this.button8);
            this.tabPage4.Controls.Add(this.comboBox1);
            this.tabPage4.Controls.Add(this.textBox4);
            this.tabPage4.Controls.Add(this.textBox3);
            this.tabPage4.Controls.Add(this.textBox2);
            this.tabPage4.Controls.Add(this.MinManaLabel);
            this.tabPage4.Controls.Add(this.MaxHealLabel);
            this.tabPage4.Controls.Add(this.MinHealLabel);
            this.tabPage4.Controls.Add(this.listBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(543, 295);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Healer";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(230, 136);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "Remove Rule";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 140);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Enabled";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // HotkeyLabel
            // 
            this.HotkeyLabel.AutoSize = true;
            this.HotkeyLabel.Location = new System.Drawing.Point(182, 83);
            this.HotkeyLabel.Name = "HotkeyLabel";
            this.HotkeyLabel.Size = new System.Drawing.Size(41, 13);
            this.HotkeyLabel.TabIndex = 10;
            this.HotkeyLabel.Text = "Hotkey";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(230, 107);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Add Rule";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBox1.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.comboBox1.Location = new System.Drawing.Point(230, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(230, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "40";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(230, 27);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "1000";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(230, 1);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "0";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // MinManaLabel
            // 
            this.MinManaLabel.AutoSize = true;
            this.MinManaLabel.Location = new System.Drawing.Point(182, 56);
            this.MinManaLabel.Name = "MinManaLabel";
            this.MinManaLabel.Size = new System.Drawing.Size(40, 13);
            this.MinManaLabel.TabIndex = 4;
            this.MinManaLabel.Text = "MinMP";
            // 
            // MaxHealLabel
            // 
            this.MaxHealLabel.AutoSize = true;
            this.MaxHealLabel.Location = new System.Drawing.Point(182, 30);
            this.MaxHealLabel.Name = "MaxHealLabel";
            this.MaxHealLabel.Size = new System.Drawing.Size(42, 13);
            this.MaxHealLabel.TabIndex = 2;
            this.MaxHealLabel.Text = "MaxHP";
            // 
            // MinHealLabel
            // 
            this.MinHealLabel.AutoSize = true;
            this.MinHealLabel.Location = new System.Drawing.Point(182, 4);
            this.MinHealLabel.Name = "MinHealLabel";
            this.MinHealLabel.Size = new System.Drawing.Size(39, 13);
            this.MinHealLabel.TabIndex = 1;
            this.MinHealLabel.Text = "MinHP";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(178, 134);
            this.listBox1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 343);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "JAPI";
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
            this.groupBox1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripSplitButton toolStripDropDownButton1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label MinManaLabel;
        private System.Windows.Forms.Label MaxHealLabel;
        private System.Windows.Forms.Label MinHealLabel;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label HotkeyLabel;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

