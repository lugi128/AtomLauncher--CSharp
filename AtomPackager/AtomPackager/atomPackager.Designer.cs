namespace AtomPackager
{
    partial class atomPackager
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
            this.formListScannedItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // formListScannedItems
            // 
            this.formListScannedItems.FormattingEnabled = true;
            this.formListScannedItems.Location = new System.Drawing.Point(16, 72);
            this.formListScannedItems.Name = "formListScannedItems";
            this.formListScannedItems.Size = new System.Drawing.Size(344, 420);
            this.formListScannedItems.TabIndex = 0;
            // 
            // atomPackager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 521);
            this.Controls.Add(this.formListScannedItems);
            this.Name = "atomPackager";
            this.Text = "atomPackager";
            this.Load += new System.EventHandler(this.atomPackager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox formListScannedItems;

    }
}