namespace DICOMTest
{
    partial class DICOM_Test_Tool
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
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Basic_Test
            // 
            this.Basic_Test.AccessibleName = "Basic-Test";
            this.Basic_Test.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Basic_Test.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Basic_Test.Location = new System.Drawing.Point(95, 78);
            this.Basic_Test.Name = "Basic_Test";
            this.Basic_Test.Size = new System.Drawing.Size(75, 23);
            this.Basic_Test.TabIndex = 0;
            this.Basic_Test.Text = "Basic-Test";
            this.Basic_Test.UseVisualStyleBackColor = false;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "SSL-Check";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // DICOM_Test_Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Scan_Test);
            this.Controls.Add(this.Basic_Test);
            this.Name = "DICOM_Test_Tool";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Basic_Test;
        private System.Windows.Forms.Button Scan_Test;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

