namespace JBot
{
    partial class ClientChooser
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
            this.sendUpWalkBtn = new System.Windows.Forms.Button();
            this.addLocationButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendUpWalkBtn
            // 
            this.sendUpWalkBtn.Location = new System.Drawing.Point(0, 239);
            this.sendUpWalkBtn.Name = "sendUpWalkBtn";
            this.sendUpWalkBtn.Size = new System.Drawing.Size(75, 23);
            this.sendUpWalkBtn.TabIndex = 0;
            this.sendUpWalkBtn.Text = "Update";
            this.sendUpWalkBtn.UseVisualStyleBackColor = true;
            this.sendUpWalkBtn.Click += new System.EventHandler(this.sendUpWalkBtn_Click);
            // 
            // addLocationButton
            // 
            this.addLocationButton.Location = new System.Drawing.Point(209, 239);
            this.addLocationButton.Name = "addLocationButton";
            this.addLocationButton.Size = new System.Drawing.Size(75, 23);
            this.addLocationButton.TabIndex = 1;
            this.addLocationButton.Text = "Select";
            this.addLocationButton.UseVisualStyleBackColor = true;
            this.addLocationButton.Click += new System.EventHandler(this.addLocationButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(284, 238);
            this.listBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.sendUpWalkBtn);
            this.panel1.Controls.Add(this.addLocationButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 262);
            this.panel1.TabIndex = 3;
            // 
            // ClientChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.Name = "ClientChooser";
            this.Text = "ClientChooser";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sendUpWalkBtn;
        private System.Windows.Forms.Button addLocationButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
    }
}