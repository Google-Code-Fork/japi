namespace AS2
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
            this.sy = new System.Windows.Forms.TextBox();
            this.sx = new System.Windows.Forms.TextBox();
            this.fx = new System.Windows.Forms.TextBox();
            this.fy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.wallsList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.wally = new System.Windows.Forms.TextBox();
            this.wallx = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pathList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // sy
            // 
            this.sy.Location = new System.Drawing.Point(12, 365);
            this.sy.Name = "sy";
            this.sy.Size = new System.Drawing.Size(31, 20);
            this.sy.TabIndex = 0;
            this.sy.Text = "4";
            // 
            // sx
            // 
            this.sx.Location = new System.Drawing.Point(12, 339);
            this.sx.Name = "sx";
            this.sx.Size = new System.Drawing.Size(31, 20);
            this.sx.TabIndex = 1;
            this.sx.Text = "1";
            // 
            // fx
            // 
            this.fx.Location = new System.Drawing.Point(50, 339);
            this.fx.Name = "fx";
            this.fx.Size = new System.Drawing.Size(31, 20);
            this.fx.TabIndex = 2;
            this.fx.Text = "7";
            // 
            // fy
            // 
            this.fy.Location = new System.Drawing.Point(50, 365);
            this.fy.Name = "fy";
            this.fy.Size = new System.Drawing.Size(31, 20);
            this.fy.TabIndex = 3;
            this.fy.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Finish";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // wallsList
            // 
            this.wallsList.FormattingEnabled = true;
            this.wallsList.Location = new System.Drawing.Point(441, 29);
            this.wallsList.Name = "wallsList";
            this.wallsList.Size = new System.Drawing.Size(161, 303);
            this.wallsList.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Walls";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(515, 363);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // wally
            // 
            this.wally.Location = new System.Drawing.Point(478, 365);
            this.wally.Name = "wally";
            this.wally.Size = new System.Drawing.Size(31, 20);
            this.wally.TabIndex = 10;
            this.wally.Text = "4";
            // 
            // wallx
            // 
            this.wallx.Location = new System.Drawing.Point(441, 365);
            this.wallx.Name = "wallx";
            this.wallx.Size = new System.Drawing.Size(31, 20);
            this.wallx.TabIndex = 9;
            this.wallx.Text = "4";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(441, 337);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(139, 320);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(296, 65);
            this.button4.TabIndex = 13;
            this.button4.Text = "Find Path!";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pathList
            // 
            this.pathList.FormattingEnabled = true;
            this.pathList.Location = new System.Drawing.Point(274, 11);
            this.pathList.Name = "pathList";
            this.pathList.Size = new System.Drawing.Size(161, 303);
            this.pathList.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 397);
            this.Controls.Add(this.pathList);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.wally);
            this.Controls.Add(this.wallx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wallsList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fy);
            this.Controls.Add(this.fx);
            this.Controls.Add(this.sx);
            this.Controls.Add(this.sy);
            this.Name = "Form1";
            this.Text = "AS2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sy;
        private System.Windows.Forms.TextBox sx;
        private System.Windows.Forms.TextBox fx;
        private System.Windows.Forms.TextBox fy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox wallsList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox wally;
        private System.Windows.Forms.TextBox wallx;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox pathList;
    }
}

