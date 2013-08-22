namespace AtomLauncher
{
    partial class minecraftSettings
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
            this.mcComboStartRam = new System.Windows.Forms.ComboBox();
            this.mcComboMaxRam = new System.Windows.Forms.ComboBox();
            this.mcCheckCMD = new System.Windows.Forms.CheckBox();
            this.mcCheckOnline = new System.Windows.Forms.CheckBox();
            this.mcRadio64bitJava = new System.Windows.Forms.RadioButton();
            this.mcRadio32bitJava = new System.Windows.Forms.RadioButton();
            this.mcCheckAutoJava = new System.Windows.Forms.CheckBox();
            this.mcTextFolder = new System.Windows.Forms.TextBox();
            this.mcFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mcLabelFolder = new System.Windows.Forms.Label();
            this.mcLabelStartRam = new System.Windows.Forms.Label();
            this.mcLabelMaxRam = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.mcButtonOK = new System.Windows.Forms.Button();
            this.mcButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mcComboStartRam
            // 
            this.mcComboStartRam.FormattingEnabled = true;
            this.mcComboStartRam.Location = new System.Drawing.Point(8, 88);
            this.mcComboStartRam.Name = "mcComboStartRam";
            this.mcComboStartRam.Size = new System.Drawing.Size(112, 21);
            this.mcComboStartRam.TabIndex = 0;
            // 
            // mcComboMaxRam
            // 
            this.mcComboMaxRam.FormattingEnabled = true;
            this.mcComboMaxRam.Location = new System.Drawing.Point(136, 88);
            this.mcComboMaxRam.Name = "mcComboMaxRam";
            this.mcComboMaxRam.Size = new System.Drawing.Size(112, 21);
            this.mcComboMaxRam.TabIndex = 1;
            // 
            // mcCheckCMD
            // 
            this.mcCheckCMD.AutoSize = true;
            this.mcCheckCMD.Location = new System.Drawing.Point(8, 120);
            this.mcCheckCMD.Name = "mcCheckCMD";
            this.mcCheckCMD.Size = new System.Drawing.Size(129, 17);
            this.mcCheckCMD.TabIndex = 2;
            this.mcCheckCMD.Text = "Display CMD Window";
            this.mcCheckCMD.UseVisualStyleBackColor = true;
            // 
            // mcCheckOnline
            // 
            this.mcCheckOnline.AutoSize = true;
            this.mcCheckOnline.Location = new System.Drawing.Point(8, 144);
            this.mcCheckOnline.Name = "mcCheckOnline";
            this.mcCheckOnline.Size = new System.Drawing.Size(86, 17);
            this.mcCheckOnline.TabIndex = 3;
            this.mcCheckOnline.Text = "Online Mode";
            this.mcCheckOnline.UseVisualStyleBackColor = true;
            // 
            // mcRadio64bitJava
            // 
            this.mcRadio64bitJava.AutoSize = true;
            this.mcRadio64bitJava.Location = new System.Drawing.Point(16, 184);
            this.mcRadio64bitJava.Name = "mcRadio64bitJava";
            this.mcRadio64bitJava.Size = new System.Drawing.Size(104, 17);
            this.mcRadio64bitJava.TabIndex = 4;
            this.mcRadio64bitJava.Text = "Force 64bit Java";
            this.mcRadio64bitJava.UseVisualStyleBackColor = true;
            // 
            // mcRadio32bitJava
            // 
            this.mcRadio32bitJava.AutoSize = true;
            this.mcRadio32bitJava.Checked = true;
            this.mcRadio32bitJava.Location = new System.Drawing.Point(16, 200);
            this.mcRadio32bitJava.Name = "mcRadio32bitJava";
            this.mcRadio32bitJava.Size = new System.Drawing.Size(104, 17);
            this.mcRadio32bitJava.TabIndex = 5;
            this.mcRadio32bitJava.TabStop = true;
            this.mcRadio32bitJava.Text = "Force 32bit Java";
            this.mcRadio32bitJava.UseVisualStyleBackColor = true;
            // 
            // mcCheckAutoJava
            // 
            this.mcCheckAutoJava.AutoSize = true;
            this.mcCheckAutoJava.Location = new System.Drawing.Point(8, 168);
            this.mcCheckAutoJava.Name = "mcCheckAutoJava";
            this.mcCheckAutoJava.Size = new System.Drawing.Size(107, 17);
            this.mcCheckAutoJava.TabIndex = 6;
            this.mcCheckAutoJava.Text = "Auto Select Java";
            this.mcCheckAutoJava.UseVisualStyleBackColor = true;
            this.mcCheckAutoJava.CheckedChanged += new System.EventHandler(this.mcCheckAutoJava_CheckedChanged);
            // 
            // mcTextFolder
            // 
            this.mcTextFolder.Location = new System.Drawing.Point(8, 40);
            this.mcTextFolder.Name = "mcTextFolder";
            this.mcTextFolder.Size = new System.Drawing.Size(240, 20);
            this.mcTextFolder.TabIndex = 7;
            // 
            // mcLabelFolder
            // 
            this.mcLabelFolder.AutoSize = true;
            this.mcLabelFolder.Location = new System.Drawing.Point(8, 24);
            this.mcLabelFolder.Name = "mcLabelFolder";
            this.mcLabelFolder.Size = new System.Drawing.Size(127, 13);
            this.mcLabelFolder.TabIndex = 8;
            this.mcLabelFolder.Text = "Minecraft Folder Location";
            // 
            // mcLabelStartRam
            // 
            this.mcLabelStartRam.AutoSize = true;
            this.mcLabelStartRam.Location = new System.Drawing.Point(8, 72);
            this.mcLabelStartRam.Name = "mcLabelStartRam";
            this.mcLabelStartRam.Size = new System.Drawing.Size(68, 13);
            this.mcLabelStartRam.TabIndex = 9;
            this.mcLabelStartRam.Text = "Starting Ram";
            // 
            // mcLabelMaxRam
            // 
            this.mcLabelMaxRam.AutoSize = true;
            this.mcLabelMaxRam.Location = new System.Drawing.Point(144, 72);
            this.mcLabelMaxRam.Name = "mcLabelMaxRam";
            this.mcLabelMaxRam.Size = new System.Drawing.Size(52, 13);
            this.mcLabelMaxRam.TabIndex = 9;
            this.mcLabelMaxRam.Text = "Max Ram";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mcButtonOK
            // 
            this.mcButtonOK.Location = new System.Drawing.Point(168, 184);
            this.mcButtonOK.Name = "mcButtonOK";
            this.mcButtonOK.Size = new System.Drawing.Size(80, 31);
            this.mcButtonOK.TabIndex = 11;
            this.mcButtonOK.Text = "OK";
            this.mcButtonOK.UseVisualStyleBackColor = true;
            this.mcButtonOK.Click += new System.EventHandler(this.mcButtonOK_Click);
            // 
            // mcButtonCancel
            // 
            this.mcButtonCancel.Location = new System.Drawing.Point(184, 152);
            this.mcButtonCancel.Name = "mcButtonCancel";
            this.mcButtonCancel.Size = new System.Drawing.Size(64, 23);
            this.mcButtonCancel.TabIndex = 12;
            this.mcButtonCancel.Text = "Cancel";
            this.mcButtonCancel.UseVisualStyleBackColor = true;
            this.mcButtonCancel.Click += new System.EventHandler(this.mcButtonCancel_Click);
            // 
            // minecraftSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 225);
            this.Controls.Add(this.mcButtonCancel);
            this.Controls.Add(this.mcButtonOK);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mcLabelMaxRam);
            this.Controls.Add(this.mcLabelStartRam);
            this.Controls.Add(this.mcLabelFolder);
            this.Controls.Add(this.mcTextFolder);
            this.Controls.Add(this.mcCheckAutoJava);
            this.Controls.Add(this.mcRadio32bitJava);
            this.Controls.Add(this.mcRadio64bitJava);
            this.Controls.Add(this.mcCheckOnline);
            this.Controls.Add(this.mcCheckCMD);
            this.Controls.Add(this.mcComboMaxRam);
            this.Controls.Add(this.mcComboStartRam);
            this.Name = "minecraftSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Settings";
            this.Load += new System.EventHandler(this.minecraftSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mcComboStartRam;
        private System.Windows.Forms.ComboBox mcComboMaxRam;
        private System.Windows.Forms.CheckBox mcCheckCMD;
        private System.Windows.Forms.CheckBox mcCheckOnline;
        private System.Windows.Forms.RadioButton mcRadio64bitJava;
        private System.Windows.Forms.RadioButton mcRadio32bitJava;
        private System.Windows.Forms.CheckBox mcCheckAutoJava;
        private System.Windows.Forms.TextBox mcTextFolder;
        private System.Windows.Forms.FolderBrowserDialog mcFolderDialog;
        private System.Windows.Forms.Label mcLabelFolder;
        private System.Windows.Forms.Label mcLabelStartRam;
        private System.Windows.Forms.Label mcLabelMaxRam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button mcButtonOK;
        private System.Windows.Forms.Button mcButtonCancel;

    }
}