namespace AtomLauncher
{
    partial class atomGeneralSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(atomGeneralSettings));
            this.formFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.formButtonOK = new System.Windows.Forms.Button();
            this.formButtonCancel = new System.Windows.Forms.Button();
            this.formButtonDefaults = new System.Windows.Forms.Button();
            this.formComboCPUPriority = new System.Windows.Forms.ComboBox();
            this.formLabelCPUPriority = new System.Windows.Forms.Label();
            this.formLabelStatus = new System.Windows.Forms.Label();
            this.formTextAppName = new System.Windows.Forms.TextBox();
            this.formLabelAppName = new System.Windows.Forms.Label();
            this.formTextPack = new System.Windows.Forms.TextBox();
            this.formLabelPack = new System.Windows.Forms.Label();
            this.formTabs = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.formButtonAppArguments = new System.Windows.Forms.Button();
            this.formTextGeneralLocation = new System.Windows.Forms.TextBox();
            this.formButtonGeneralFile = new System.Windows.Forms.Button();
            this.formLabelGeneralLocation = new System.Windows.Forms.Label();
            this.formLabelAppArguments = new System.Windows.Forms.Label();
            this.formTextAppArguments = new System.Windows.Forms.TextBox();
            this.Files = new System.Windows.Forms.TabPage();
            this.formTextThumbnail = new System.Windows.Forms.TextBox();
            this.formButtonThumbnailClear = new System.Windows.Forms.Button();
            this.formButtonThumbnail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.formLabelThumbnailDetail = new System.Windows.Forms.Label();
            this.formLabelThumbnail = new System.Windows.Forms.Label();
            this.Program = new System.Windows.Forms.TabPage();
            this.formTextWorkingDirect = new System.Windows.Forms.TextBox();
            this.formButtonWorkingDirect = new System.Windows.Forms.Button();
            this.formLabelWorkingDirect = new System.Windows.Forms.Label();
            this.formLabelWorkingDirectDetail = new System.Windows.Forms.Label();
            this.formPanel = new System.Windows.Forms.Panel();
            this.formLabelGeneralSettingsTitle = new System.Windows.Forms.Label();
            this.formFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.formButtonClose = new System.Windows.Forms.Button();
            this.formTabs.SuspendLayout();
            this.General.SuspendLayout();
            this.Files.SuspendLayout();
            this.Program.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formButtonOK
            // 
            this.formButtonOK.BackColor = System.Drawing.Color.White;
            this.formButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonOK.Location = new System.Drawing.Point(204, 36);
            this.formButtonOK.Name = "formButtonOK";
            this.formButtonOK.Size = new System.Drawing.Size(72, 24);
            this.formButtonOK.TabIndex = 11;
            this.formButtonOK.Text = "OK";
            this.formButtonOK.UseVisualStyleBackColor = false;
            this.formButtonOK.Click += new System.EventHandler(this.formButtonOK_Click);
            // 
            // formButtonCancel
            // 
            this.formButtonCancel.BackColor = System.Drawing.Color.White;
            this.formButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.formButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonCancel.Location = new System.Drawing.Point(140, 36);
            this.formButtonCancel.Name = "formButtonCancel";
            this.formButtonCancel.Size = new System.Drawing.Size(56, 24);
            this.formButtonCancel.TabIndex = 12;
            this.formButtonCancel.Text = "Cancel";
            this.formButtonCancel.UseVisualStyleBackColor = false;
            this.formButtonCancel.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // formButtonDefaults
            // 
            this.formButtonDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.formButtonDefaults.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.formButtonDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonDefaults.ForeColor = System.Drawing.Color.Black;
            this.formButtonDefaults.Location = new System.Drawing.Point(8, 36);
            this.formButtonDefaults.Name = "formButtonDefaults";
            this.formButtonDefaults.Size = new System.Drawing.Size(64, 24);
            this.formButtonDefaults.TabIndex = 13;
            this.formButtonDefaults.Text = "Defaults";
            this.formButtonDefaults.UseVisualStyleBackColor = false;
            this.formButtonDefaults.Click += new System.EventHandler(this.formButtonDefaults_Click);
            // 
            // formComboCPUPriority
            // 
            this.formComboCPUPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formComboCPUPriority.FormattingEnabled = true;
            this.formComboCPUPriority.Items.AddRange(new object[] {
            "Realtime",
            "High",
            "Above Normal",
            "Normal",
            "Below Normal"});
            this.formComboCPUPriority.Location = new System.Drawing.Point(8, 8);
            this.formComboCPUPriority.Name = "formComboCPUPriority";
            this.formComboCPUPriority.Size = new System.Drawing.Size(120, 17);
            this.formComboCPUPriority.TabIndex = 14;
            // 
            // formLabelCPUPriority
            // 
            this.formLabelCPUPriority.Location = new System.Drawing.Point(128, 8);
            this.formLabelCPUPriority.Name = "formLabelCPUPriority";
            this.formLabelCPUPriority.Size = new System.Drawing.Size(140, 16);
            this.formLabelCPUPriority.TabIndex = 15;
            this.formLabelCPUPriority.Text = "CPU Priority";
            this.formLabelCPUPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formLabelStatus
            // 
            this.formLabelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.formLabelStatus.Location = new System.Drawing.Point(8, 8);
            this.formLabelStatus.Name = "formLabelStatus";
            this.formLabelStatus.Size = new System.Drawing.Size(268, 24);
            this.formLabelStatus.TabIndex = 16;
            this.formLabelStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // formTextAppName
            // 
            this.formTextAppName.Location = new System.Drawing.Point(8, 16);
            this.formTextAppName.Name = "formTextAppName";
            this.formTextAppName.Size = new System.Drawing.Size(144, 16);
            this.formTextAppName.TabIndex = 7;
            // 
            // formLabelAppName
            // 
            this.formLabelAppName.Location = new System.Drawing.Point(8, 8);
            this.formLabelAppName.Name = "formLabelAppName";
            this.formLabelAppName.Size = new System.Drawing.Size(144, 8);
            this.formLabelAppName.TabIndex = 8;
            this.formLabelAppName.Text = "Custom App Name";
            this.formLabelAppName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTextPack
            // 
            this.formTextPack.Enabled = false;
            this.formTextPack.Location = new System.Drawing.Point(8, 336);
            this.formTextPack.Name = "formTextPack";
            this.formTextPack.Size = new System.Drawing.Size(264, 16);
            this.formTextPack.TabIndex = 7;
            // 
            // formLabelPack
            // 
            this.formLabelPack.Enabled = false;
            this.formLabelPack.Location = new System.Drawing.Point(8, 328);
            this.formLabelPack.Name = "formLabelPack";
            this.formLabelPack.Size = new System.Drawing.Size(264, 8);
            this.formLabelPack.TabIndex = 8;
            this.formLabelPack.Text = "Additional Files URL";
            this.formLabelPack.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTabs
            // 
            this.formTabs.Controls.Add(this.General);
            this.formTabs.Controls.Add(this.Files);
            this.formTabs.Controls.Add(this.Program);
            this.formTabs.Font = new System.Drawing.Font("Lucida Console", 6.75F);
            this.formTabs.Location = new System.Drawing.Point(4, 36);
            this.formTabs.Name = "formTabs";
            this.formTabs.SelectedIndex = 0;
            this.formTabs.Size = new System.Drawing.Size(288, 384);
            this.formTabs.TabIndex = 18;
            // 
            // General
            // 
            this.General.Controls.Add(this.formButtonAppArguments);
            this.General.Controls.Add(this.formTextGeneralLocation);
            this.General.Controls.Add(this.formButtonGeneralFile);
            this.General.Controls.Add(this.formLabelGeneralLocation);
            this.General.Controls.Add(this.formLabelAppName);
            this.General.Controls.Add(this.formTextAppName);
            this.General.Controls.Add(this.formLabelAppArguments);
            this.General.Controls.Add(this.formTextAppArguments);
            this.General.Location = new System.Drawing.Point(4, 19);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(280, 361);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // formButtonAppArguments
            // 
            this.formButtonAppArguments.Location = new System.Drawing.Point(232, 104);
            this.formButtonAppArguments.Name = "formButtonAppArguments";
            this.formButtonAppArguments.Size = new System.Drawing.Size(40, 16);
            this.formButtonAppArguments.TabIndex = 20;
            this.formButtonAppArguments.Text = "Info";
            this.formButtonAppArguments.UseVisualStyleBackColor = true;
            this.formButtonAppArguments.Click += new System.EventHandler(this.formButtonAppArguments_Click);
            // 
            // formTextGeneralLocation
            // 
            this.formTextGeneralLocation.BackColor = System.Drawing.Color.White;
            this.formTextGeneralLocation.ForeColor = System.Drawing.Color.Black;
            this.formTextGeneralLocation.Location = new System.Drawing.Point(8, 48);
            this.formTextGeneralLocation.Name = "formTextGeneralLocation";
            this.formTextGeneralLocation.ReadOnly = true;
            this.formTextGeneralLocation.Size = new System.Drawing.Size(264, 16);
            this.formTextGeneralLocation.TabIndex = 17;
            // 
            // formButtonGeneralFile
            // 
            this.formButtonGeneralFile.Location = new System.Drawing.Point(8, 64);
            this.formButtonGeneralFile.Name = "formButtonGeneralFile";
            this.formButtonGeneralFile.Size = new System.Drawing.Size(76, 20);
            this.formButtonGeneralFile.TabIndex = 16;
            this.formButtonGeneralFile.Text = "Select File";
            this.formButtonGeneralFile.UseVisualStyleBackColor = true;
            this.formButtonGeneralFile.Click += new System.EventHandler(this.formButtonGeneralFile_Click);
            // 
            // formLabelGeneralLocation
            // 
            this.formLabelGeneralLocation.Location = new System.Drawing.Point(8, 40);
            this.formLabelGeneralLocation.Name = "formLabelGeneralLocation";
            this.formLabelGeneralLocation.Size = new System.Drawing.Size(264, 8);
            this.formLabelGeneralLocation.TabIndex = 15;
            this.formLabelGeneralLocation.Text = "Application Executible File";
            this.formLabelGeneralLocation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formLabelAppArguments
            // 
            this.formLabelAppArguments.Location = new System.Drawing.Point(8, 96);
            this.formLabelAppArguments.Name = "formLabelAppArguments";
            this.formLabelAppArguments.Size = new System.Drawing.Size(264, 8);
            this.formLabelAppArguments.TabIndex = 17;
            this.formLabelAppArguments.Text = "Application Arguments";
            this.formLabelAppArguments.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTextAppArguments
            // 
            this.formTextAppArguments.Location = new System.Drawing.Point(8, 104);
            this.formTextAppArguments.Name = "formTextAppArguments";
            this.formTextAppArguments.Size = new System.Drawing.Size(224, 16);
            this.formTextAppArguments.TabIndex = 16;
            // 
            // Files
            // 
            this.Files.Controls.Add(this.formTextPack);
            this.Files.Controls.Add(this.formTextThumbnail);
            this.Files.Controls.Add(this.formButtonThumbnailClear);
            this.Files.Controls.Add(this.formButtonThumbnail);
            this.Files.Controls.Add(this.label1);
            this.Files.Controls.Add(this.formLabelThumbnailDetail);
            this.Files.Controls.Add(this.formLabelThumbnail);
            this.Files.Controls.Add(this.formLabelPack);
            this.Files.Location = new System.Drawing.Point(4, 19);
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(280, 361);
            this.Files.TabIndex = 4;
            this.Files.Text = "Files";
            this.Files.UseVisualStyleBackColor = true;
            // 
            // formTextThumbnail
            // 
            this.formTextThumbnail.BackColor = System.Drawing.Color.White;
            this.formTextThumbnail.ForeColor = System.Drawing.Color.Black;
            this.formTextThumbnail.Location = new System.Drawing.Point(8, 16);
            this.formTextThumbnail.Name = "formTextThumbnail";
            this.formTextThumbnail.ReadOnly = true;
            this.formTextThumbnail.Size = new System.Drawing.Size(264, 16);
            this.formTextThumbnail.TabIndex = 7;
            // 
            // formButtonThumbnailClear
            // 
            this.formButtonThumbnailClear.Location = new System.Drawing.Point(96, 32);
            this.formButtonThumbnailClear.Name = "formButtonThumbnailClear";
            this.formButtonThumbnailClear.Size = new System.Drawing.Size(44, 20);
            this.formButtonThumbnailClear.TabIndex = 10;
            this.formButtonThumbnailClear.Text = "Clear";
            this.formButtonThumbnailClear.UseVisualStyleBackColor = true;
            this.formButtonThumbnailClear.Click += new System.EventHandler(this.formButtonThumbnailClear_Click);
            // 
            // formButtonThumbnail
            // 
            this.formButtonThumbnail.Location = new System.Drawing.Point(8, 32);
            this.formButtonThumbnail.Name = "formButtonThumbnail";
            this.formButtonThumbnail.Size = new System.Drawing.Size(88, 20);
            this.formButtonThumbnail.TabIndex = 10;
            this.formButtonThumbnail.Text = "Select Image";
            this.formButtonThumbnail.UseVisualStyleBackColor = true;
            this.formButtonThumbnail.Click += new System.EventHandler(this.formButtonThumbnail_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Under Construction";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formLabelThumbnailDetail
            // 
            this.formLabelThumbnailDetail.Location = new System.Drawing.Point(140, 32);
            this.formLabelThumbnailDetail.Name = "formLabelThumbnailDetail";
            this.formLabelThumbnailDetail.Size = new System.Drawing.Size(132, 20);
            this.formLabelThumbnailDetail.TabIndex = 8;
            this.formLabelThumbnailDetail.Text = "Max Resolution: 260x80";
            this.formLabelThumbnailDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // formLabelThumbnail
            // 
            this.formLabelThumbnail.Location = new System.Drawing.Point(8, 8);
            this.formLabelThumbnail.Name = "formLabelThumbnail";
            this.formLabelThumbnail.Size = new System.Drawing.Size(264, 8);
            this.formLabelThumbnail.TabIndex = 8;
            this.formLabelThumbnail.Text = "App Thumbnail";
            this.formLabelThumbnail.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Program
            // 
            this.Program.Controls.Add(this.formTextWorkingDirect);
            this.Program.Controls.Add(this.formButtonWorkingDirect);
            this.Program.Controls.Add(this.formLabelWorkingDirect);
            this.Program.Controls.Add(this.formLabelWorkingDirectDetail);
            this.Program.Controls.Add(this.formLabelCPUPriority);
            this.Program.Controls.Add(this.formComboCPUPriority);
            this.Program.Location = new System.Drawing.Point(4, 19);
            this.Program.Name = "Program";
            this.Program.Size = new System.Drawing.Size(280, 361);
            this.Program.TabIndex = 2;
            this.Program.Text = "Program";
            this.Program.UseVisualStyleBackColor = true;
            // 
            // formTextWorkingDirect
            // 
            this.formTextWorkingDirect.Location = new System.Drawing.Point(8, 44);
            this.formTextWorkingDirect.Name = "formTextWorkingDirect";
            this.formTextWorkingDirect.Size = new System.Drawing.Size(264, 16);
            this.formTextWorkingDirect.TabIndex = 18;
            // 
            // formButtonWorkingDirect
            // 
            this.formButtonWorkingDirect.Location = new System.Drawing.Point(8, 60);
            this.formButtonWorkingDirect.Name = "formButtonWorkingDirect";
            this.formButtonWorkingDirect.Size = new System.Drawing.Size(96, 20);
            this.formButtonWorkingDirect.TabIndex = 20;
            this.formButtonWorkingDirect.Text = "Select Folder";
            this.formButtonWorkingDirect.UseVisualStyleBackColor = true;
            this.formButtonWorkingDirect.Click += new System.EventHandler(this.formButtonAppWorkingDirect_Click);
            // 
            // formLabelWorkingDirect
            // 
            this.formLabelWorkingDirect.Location = new System.Drawing.Point(8, 36);
            this.formLabelWorkingDirect.Name = "formLabelWorkingDirect";
            this.formLabelWorkingDirect.Size = new System.Drawing.Size(264, 8);
            this.formLabelWorkingDirect.TabIndex = 19;
            this.formLabelWorkingDirect.Text = "Working Directory";
            this.formLabelWorkingDirect.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formLabelWorkingDirectDetail
            // 
            this.formLabelWorkingDirectDetail.Location = new System.Drawing.Point(104, 60);
            this.formLabelWorkingDirectDetail.Name = "formLabelWorkingDirectDetail";
            this.formLabelWorkingDirectDetail.Size = new System.Drawing.Size(132, 20);
            this.formLabelWorkingDirectDetail.TabIndex = 15;
            this.formLabelWorkingDirectDetail.Text = "Leave blank to use directory of App.";
            this.formLabelWorkingDirectDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formPanel
            // 
            this.formPanel.BackColor = System.Drawing.Color.Black;
            this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formPanel.Controls.Add(this.formButtonDefaults);
            this.formPanel.Controls.Add(this.formButtonOK);
            this.formPanel.Controls.Add(this.formLabelStatus);
            this.formPanel.Controls.Add(this.formButtonCancel);
            this.formPanel.Font = new System.Drawing.Font("Lucida Console", 6.75F);
            this.formPanel.Location = new System.Drawing.Point(4, 424);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(286, 70);
            this.formPanel.TabIndex = 19;
            // 
            // formLabelGeneralSettingsTitle
            // 
            this.formLabelGeneralSettingsTitle.Font = new System.Drawing.Font("Lucida Console", 13.5F, System.Drawing.FontStyle.Bold);
            this.formLabelGeneralSettingsTitle.Location = new System.Drawing.Point(4, 16);
            this.formLabelGeneralSettingsTitle.Name = "formLabelGeneralSettingsTitle";
            this.formLabelGeneralSettingsTitle.Size = new System.Drawing.Size(284, 20);
            this.formLabelGeneralSettingsTitle.TabIndex = 20;
            this.formLabelGeneralSettingsTitle.Text = "General Settings";
            this.formLabelGeneralSettingsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formButtonClose
            // 
            this.formButtonClose.BackColor = System.Drawing.Color.White;
            this.formButtonClose.BackgroundImage = global::AtomLauncher.Properties.Resources.xicon;
            this.formButtonClose.FlatAppearance.BorderSize = 0;
            this.formButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonClose.Location = new System.Drawing.Point(279, 0);
            this.formButtonClose.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonClose.Name = "formButtonClose";
            this.formButtonClose.Size = new System.Drawing.Size(14, 14);
            this.formButtonClose.TabIndex = 22;
            this.formButtonClose.TabStop = false;
            this.formButtonClose.UseVisualStyleBackColor = false;
            this.formButtonClose.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // atomGeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 498);
            this.ControlBox = false;
            this.Controls.Add(this.formButtonClose);
            this.Controls.Add(this.formLabelGeneralSettingsTitle);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.formTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "atomGeneralSettings";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "General Settings";
            this.Load += new System.EventHandler(this.atomGeneralSettings_Load);
            this.formTabs.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.Files.ResumeLayout(false);
            this.Files.PerformLayout();
            this.Program.ResumeLayout(false);
            this.Program.PerformLayout();
            this.formPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog formFolderDialog;
        private System.Windows.Forms.Button formButtonOK;
        private System.Windows.Forms.Button formButtonCancel;
        private System.Windows.Forms.Button formButtonDefaults;
        private System.Windows.Forms.ComboBox formComboCPUPriority;
        private System.Windows.Forms.Label formLabelCPUPriority;
        private System.Windows.Forms.Label formLabelStatus;
        private System.Windows.Forms.TextBox formTextAppName;
        private System.Windows.Forms.Label formLabelAppName;
        private System.Windows.Forms.TextBox formTextPack;
        private System.Windows.Forms.Label formLabelPack;
        private System.Windows.Forms.TabControl formTabs;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage Program;
        private System.Windows.Forms.TabPage Files;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label formLabelGeneralSettingsTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button formButtonThumbnail;
        private System.Windows.Forms.Label formLabelThumbnail;
        private System.Windows.Forms.TextBox formTextThumbnail;
        private System.Windows.Forms.Label formLabelThumbnailDetail;
        private System.Windows.Forms.OpenFileDialog formFileDialog;
        private System.Windows.Forms.Button formButtonThumbnailClear;
        private System.Windows.Forms.Button formButtonGeneralFile;
        private System.Windows.Forms.Label formLabelGeneralLocation;
        private System.Windows.Forms.Button formButtonWorkingDirect;
        private System.Windows.Forms.TextBox formTextWorkingDirect;
        private System.Windows.Forms.Label formLabelWorkingDirect;
        private System.Windows.Forms.Label formLabelAppArguments;
        private System.Windows.Forms.TextBox formTextAppArguments;
        private System.Windows.Forms.TextBox formTextGeneralLocation;
        private System.Windows.Forms.Label formLabelWorkingDirectDetail;
        private System.Windows.Forms.Button formButtonAppArguments;
        private System.Windows.Forms.Button formButtonClose;

    }
}