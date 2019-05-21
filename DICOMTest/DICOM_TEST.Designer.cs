namespace DICOMTest
{
    partial class DICOM_TEST
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
            this.Basic_Test = new System.Windows.Forms.Button();
            this.Scan_Test = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SSL_button = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Basic_Test
            // 
            this.Basic_Test.AccessibleName = "Basic-Test";
            this.Basic_Test.BackColor = System.Drawing.SystemColors.Control;
            this.Basic_Test.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Basic_Test.Location = new System.Drawing.Point(95, 78);
            this.Basic_Test.Name = "Basic_Test";
            this.Basic_Test.Size = new System.Drawing.Size(75, 23);
            this.Basic_Test.TabIndex = 0;
            this.Basic_Test.Text = "Basic-Test";
            this.Basic_Test.UseVisualStyleBackColor = true;
            this.Basic_Test.Click += new System.EventHandler(this.button1_Click);
            // 
            // Scan_Test
            // 
            this.Scan_Test.Location = new System.Drawing.Point(12, 79);
            this.Scan_Test.Name = "Scan_Test";
            this.Scan_Test.Size = new System.Drawing.Size(77, 20);
            this.Scan_Test.TabIndex = 1;
            this.Scan_Test.Text = "Scan";
            this.Scan_Test.UseVisualStyleBackColor = true;
            this.Scan_Test.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Fuzz";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SSL_button
            // 
            this.SSL_button.Location = new System.Drawing.Point(188, 79);
            this.SSL_button.Name = "SSL_button";
            this.SSL_button.Size = new System.Drawing.Size(75, 23);
            this.SSL_button.TabIndex = 3;
            this.SSL_button.Text = "SSL-Check";
            this.SSL_button.UseVisualStyleBackColor = true;
            this.SSL_button.Click += new System.EventHandler(this.SSL_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(51, 185);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 37);
            this.button3.TabIndex = 4;
            this.button3.Text = "Auto scan";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Autoscanbutton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(188, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Config";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 270);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(301, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Progressstatus";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Not started";
            // 
            // DICOM_TEST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 322);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SSL_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Scan_Test);
            this.Controls.Add(this.Basic_Test);
            this.Name = "DICOM_TEST";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Basic_Test;
        private System.Windows.Forms.Button Scan_Test;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SSL_button;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public  System.Windows.Forms.Label label3;
    }
}

