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
            this.mcButtonFolder = new System.Windows.Forms.Button();
            this.mcButtonOK = new System.Windows.Forms.Button();
            this.mcButtonCancel = new System.Windows.Forms.Button();
            this.mcButtonDefaults = new System.Windows.Forms.Button();
            this.mcComboCPUPri = new System.Windows.Forms.ComboBox();
            this.mcLabelCPUPri = new System.Windows.Forms.Label();
            this.mcLabelStatus = new System.Windows.Forms.Label();
            this.mcTextUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mcComboStartRam
            // 
            this.mcComboStartRam.DropDownHeight = 115;
            this.mcComboStartRam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcComboStartRam.FormattingEnabled = true;
            this.mcComboStartRam.IntegralHeight = false;
            this.mcComboStartRam.ItemHeight = 13;
            this.mcComboStartRam.Location = new System.Drawing.Point(8, 80);
            this.mcComboStartRam.Name = "mcComboStartRam";
            this.mcComboStartRam.Size = new System.Drawing.Size(112, 21);
            this.mcComboStartRam.TabIndex = 0;
            this.mcComboStartRam.SelectedIndexChanged += new System.EventHandler(this.mcComboStartRam_SelectedIndexChanged);
            // 
            // mcComboMaxRam
            // 
            this.mcComboMaxRam.DropDownHeight = 115;
            this.mcComboMaxRam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcComboMaxRam.FormattingEnabled = true;
            this.mcComboMaxRam.IntegralHeight = false;
            this.mcComboMaxRam.ItemHeight = 13;
            this.mcComboMaxRam.Location = new System.Drawing.Point(136, 80);
            this.mcComboMaxRam.Name = "mcComboMaxRam";
            this.mcComboMaxRam.Size = new System.Drawing.Size(112, 21);
            this.mcComboMaxRam.TabIndex = 1;
            this.mcComboMaxRam.SelectedIndexChanged += new System.EventHandler(this.mcComboMaxRam_SelectedIndexChanged);
            // 
            // mcCheckCMD
            // 
            this.mcCheckCMD.AutoSize = true;
            this.mcCheckCMD.Location = new System.Drawing.Point(8, 104);
            this.mcCheckCMD.Name = "mcCheckCMD";
            this.mcCheckCMD.Size = new System.Drawing.Size(129, 17);
            this.mcCheckCMD.TabIndex = 2;
            this.mcCheckCMD.Text = "Display CMD Window";
            this.mcCheckCMD.UseVisualStyleBackColor = true;
            // 
            // mcCheckOnline
            // 
            this.mcCheckOnline.AutoSize = true;
            this.mcCheckOnline.Location = new System.Drawing.Point(8, 128);
            this.mcCheckOnline.Name = "mcCheckOnline";
            this.mcCheckOnline.Size = new System.Drawing.Size(86, 17);
            this.mcCheckOnline.TabIndex = 3;
            this.mcCheckOnline.Text = "Online Mode";
            this.mcCheckOnline.UseVisualStyleBackColor = true;
            this.mcCheckOnline.CheckedChanged += new System.EventHandler(this.mcCheckOnline_CheckedChanged);
            // 
            // mcRadio64bitJava
            // 
            this.mcRadio64bitJava.AutoSize = true;
            this.mcRadio64bitJava.Checked = true;
            this.mcRadio64bitJava.Location = new System.Drawing.Point(16, 184);
            this.mcRadio64bitJava.Name = "mcRadio64bitJava";
            this.mcRadio64bitJava.Size = new System.Drawing.Size(104, 17);
            this.mcRadio64bitJava.TabIndex = 4;
            this.mcRadio64bitJava.TabStop = true;
            this.mcRadio64bitJava.Text = "Force 64bit Java";
            this.mcRadio64bitJava.UseVisualStyleBackColor = true;
            // 
            // mcRadio32bitJava
            // 
            this.mcRadio32bitJava.AutoSize = true;
            this.mcRadio32bitJava.Location = new System.Drawing.Point(16, 200);
            this.mcRadio32bitJava.Name = "mcRadio32bitJava";
            this.mcRadio32bitJava.Size = new System.Drawing.Size(104, 17);
            this.mcRadio32bitJava.TabIndex = 5;
            this.mcRadio32bitJava.Text = "Force 32bit Java";
            this.mcRadio32bitJava.UseVisualStyleBackColor = true;
            this.mcRadio32bitJava.CheckedChanged += new System.EventHandler(this.mcRadio32bitJava_CheckedChanged);
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
            this.mcLabelStartRam.Location = new System.Drawing.Point(8, 64);
            this.mcLabelStartRam.Name = "mcLabelStartRam";
            this.mcLabelStartRam.Size = new System.Drawing.Size(68, 13);
            this.mcLabelStartRam.TabIndex = 9;
            this.mcLabelStartRam.Text = "Starting Ram";
            // 
            // mcLabelMaxRam
            // 
            this.mcLabelMaxRam.AutoSize = true;
            this.mcLabelMaxRam.Location = new System.Drawing.Point(144, 64);
            this.mcLabelMaxRam.Name = "mcLabelMaxRam";
            this.mcLabelMaxRam.Size = new System.Drawing.Size(52, 13);
            this.mcLabelMaxRam.TabIndex = 9;
            this.mcLabelMaxRam.Text = "Max Ram";
            // 
            // mcButtonFolder
            // 
            this.mcButtonFolder.Location = new System.Drawing.Point(160, 8);
            this.mcButtonFolder.Name = "mcButtonFolder";
            this.mcButtonFolder.Size = new System.Drawing.Size(88, 24);
            this.mcButtonFolder.TabIndex = 10;
            this.mcButtonFolder.Text = "Select Folder";
            this.mcButtonFolder.UseVisualStyleBackColor = true;
            this.mcButtonFolder.Click += new System.EventHandler(this.mcButtonFolder_Click);
            // 
            // mcButtonOK
            // 
            this.mcButtonOK.Location = new System.Drawing.Point(128, 184);
            this.mcButtonOK.Name = "mcButtonOK";
            this.mcButtonOK.Size = new System.Drawing.Size(64, 31);
            this.mcButtonOK.TabIndex = 11;
            this.mcButtonOK.Text = "OK";
            this.mcButtonOK.UseVisualStyleBackColor = true;
            this.mcButtonOK.Click += new System.EventHandler(this.mcButtonOK_Click);
            // 
            // mcButtonCancel
            // 
            this.mcButtonCancel.BackColor = System.Drawing.Color.White;
            this.mcButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.mcButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mcButtonCancel.Location = new System.Drawing.Point(192, 184);
            this.mcButtonCancel.Name = "mcButtonCancel";
            this.mcButtonCancel.Size = new System.Drawing.Size(56, 32);
            this.mcButtonCancel.TabIndex = 12;
            this.mcButtonCancel.Text = "Cancel";
            this.mcButtonCancel.UseVisualStyleBackColor = false;
            this.mcButtonCancel.Click += new System.EventHandler(this.mcButtonCancel_Click);
            // 
            // mcButtonDefaults
            // 
            this.mcButtonDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mcButtonDefaults.Location = new System.Drawing.Point(192, 160);
            this.mcButtonDefaults.Name = "mcButtonDefaults";
            this.mcButtonDefaults.Size = new System.Drawing.Size(56, 23);
            this.mcButtonDefaults.TabIndex = 13;
            this.mcButtonDefaults.Text = "Defaults";
            this.mcButtonDefaults.UseVisualStyleBackColor = true;
            this.mcButtonDefaults.Click += new System.EventHandler(this.mcButtonDefaults_Click);
            // 
            // mcComboCPUPri
            // 
            this.mcComboCPUPri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcComboCPUPri.FormattingEnabled = true;
            this.mcComboCPUPri.Items.AddRange(new object[] {
            "Realtime",
            "High",
            "Above Normal",
            "Normal",
            "Below Normal"});
            this.mcComboCPUPri.Location = new System.Drawing.Point(136, 120);
            this.mcComboCPUPri.Name = "mcComboCPUPri";
            this.mcComboCPUPri.Size = new System.Drawing.Size(112, 21);
            this.mcComboCPUPri.TabIndex = 14;
            // 
            // mcLabelCPUPri
            // 
            this.mcLabelCPUPri.AutoSize = true;
            this.mcLabelCPUPri.Location = new System.Drawing.Point(144, 104);
            this.mcLabelCPUPri.Name = "mcLabelCPUPri";
            this.mcLabelCPUPri.Size = new System.Drawing.Size(63, 13);
            this.mcLabelCPUPri.TabIndex = 15;
            this.mcLabelCPUPri.Text = "CPU Priority";
            // 
            // mcLabelStatus
            // 
            this.mcLabelStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mcLabelStatus.Location = new System.Drawing.Point(8, 224);
            this.mcLabelStatus.Name = "mcLabelStatus";
            this.mcLabelStatus.Size = new System.Drawing.Size(240, 24);
            this.mcLabelStatus.TabIndex = 16;
            this.mcLabelStatus.Text = "System OK.";
            this.mcLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mcTextUsername
            // 
            this.mcTextUsername.Enabled = false;
            this.mcTextUsername.Location = new System.Drawing.Point(8, 144);
            this.mcTextUsername.Name = "mcTextUsername";
            this.mcTextUsername.Size = new System.Drawing.Size(120, 20);
            this.mcTextUsername.TabIndex = 17;
            this.mcTextUsername.Text = "Offline_Username";
            // 
            // minecraftSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 258);
            this.ControlBox = false;
            this.Controls.Add(this.mcTextUsername);
            this.Controls.Add(this.mcLabelStatus);
            this.Controls.Add(this.mcLabelCPUPri);
            this.Controls.Add(this.mcComboCPUPri);
            this.Controls.Add(this.mcButtonDefaults);
            this.Controls.Add(this.mcButtonCancel);
            this.Controls.Add(this.mcButtonOK);
            this.Controls.Add(this.mcButtonFolder);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
        private System.Windows.Forms.Button mcButtonFolder;
        private System.Windows.Forms.Button mcButtonOK;
        private System.Windows.Forms.Button mcButtonCancel;
        private System.Windows.Forms.Button mcButtonDefaults;
        private System.Windows.Forms.ComboBox mcComboCPUPri;
        private System.Windows.Forms.Label mcLabelCPUPri;
        private System.Windows.Forms.Label mcLabelStatus;
        private System.Windows.Forms.TextBox mcTextUsername;

    }
}