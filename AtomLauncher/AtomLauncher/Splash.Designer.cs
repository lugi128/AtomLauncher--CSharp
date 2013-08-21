namespace AtomLauncher
{
    partial class Splash
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
            this.splashLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // splashLabel
            // 
            this.splashLabel.AutoSize = true;
            this.splashLabel.ForeColor = System.Drawing.Color.White;
            this.splashLabel.Location = new System.Drawing.Point(48, 16);
            this.splashLabel.Name = "splashLabel";
            this.splashLabel.Size = new System.Drawing.Size(55, 13);
            this.splashLabel.TabIndex = 0;
            this.splashLabel.Text = "Welcome!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loading... Please wait...";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(153, 65);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splashLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atom Launcher";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label splashLabel;
        private System.Windows.Forms.Label label1;

    }
}