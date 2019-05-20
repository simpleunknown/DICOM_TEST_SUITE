namespace DICOMTest
{
    partial class Basic_Test
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
            this.echo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // echo
            // 
            this.echo.AccessibleName = "echo";
            this.echo.Location = new System.Drawing.Point(43, 27);
            this.echo.Name = "echo";
            this.echo.Size = new System.Drawing.Size(75, 23);
            this.echo.TabIndex = 0;
            this.echo.Text = "C-ECHO";
            this.echo.UseVisualStyleBackColor = true;
            this.echo.Click += new System.EventHandler(this.echo_click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "C-FIND";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.find_click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(43, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "C-MOVE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.move_click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(43, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "C-STORE";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.store_click);
            // 
            // Basic_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.echo);
            this.Name = "Basic_Test";
            this.Text = "Basic_Test";
            this.Load += new System.EventHandler(this.Basic_Test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button echo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}