namespace Atom_Packager
{
    partial class Home
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
            this.homeLabelStatus = new System.Windows.Forms.Label();
            this.homeTextLocation = new System.Windows.Forms.TextBox();
            this.homeButtonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // homeLabelStatus
            // 
            this.homeLabelStatus.AutoSize = true;
            this.homeLabelStatus.Location = new System.Drawing.Point(16, 16);
            this.homeLabelStatus.Name = "homeLabelStatus";
            this.homeLabelStatus.Size = new System.Drawing.Size(56, 13);
            this.homeLabelStatus.TabIndex = 0;
            this.homeLabelStatus.Text = "Working...";
            // 
            // homeTextLocation
            // 
            this.homeTextLocation.Location = new System.Drawing.Point(16, 40);
            this.homeTextLocation.Name = "homeTextLocation";
            this.homeTextLocation.Size = new System.Drawing.Size(208, 20);
            this.homeTextLocation.TabIndex = 1;
            // 
            // homeButtonStart
            // 
            this.homeButtonStart.Location = new System.Drawing.Point(232, 40);
            this.homeButtonStart.Name = "homeButtonStart";
            this.homeButtonStart.Size = new System.Drawing.Size(75, 23);
            this.homeButtonStart.TabIndex = 2;
            this.homeButtonStart.Text = "Start";
            this.homeButtonStart.UseVisualStyleBackColor = true;
            this.homeButtonStart.Click += new System.EventHandler(this.homeButtonStart_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 73);
            this.Controls.Add(this.homeButtonStart);
            this.Controls.Add(this.homeTextLocation);
            this.Controls.Add(this.homeLabelStatus);
            this.Name = "Home";
            this.Text = "Atom Packager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label homeLabelStatus;
        private System.Windows.Forms.TextBox homeTextLocation;
        private System.Windows.Forms.Button homeButtonStart;
    }
}

