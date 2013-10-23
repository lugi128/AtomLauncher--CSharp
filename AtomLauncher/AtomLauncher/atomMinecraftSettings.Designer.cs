namespace AtomLauncher
{
    partial class atomMinecraftSettings
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
            this.formComboStartRam = new System.Windows.Forms.ComboBox();
            this.formComboMaxRam = new System.Windows.Forms.ComboBox();
            this.formCheckCMD = new System.Windows.Forms.CheckBox();
            this.formCheckOnline = new System.Windows.Forms.CheckBox();
            this.formRadio64bitJava = new System.Windows.Forms.RadioButton();
            this.formRadio32bitJava = new System.Windows.Forms.RadioButton();
            this.formCheckAutoJava = new System.Windows.Forms.CheckBox();
            this.formTextMinecraftLocation = new System.Windows.Forms.TextBox();
            this.formFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.formLabelMinecraftLocation = new System.Windows.Forms.Label();
            this.mcLabelStartRam = new System.Windows.Forms.Label();
            this.mcLabelMaxRam = new System.Windows.Forms.Label();
            this.formButtonMinecraftFolder = new System.Windows.Forms.Button();
            this.formButtonOK = new System.Windows.Forms.Button();
            this.formButtonCancel = new System.Windows.Forms.Button();
            this.formButtonDefaults = new System.Windows.Forms.Button();
            this.formComboCPUPriority = new System.Windows.Forms.ComboBox();
            this.formLabelCPUPriority = new System.Windows.Forms.Label();
            this.formLabelStatus = new System.Windows.Forms.Label();
            this.formTextUsername = new System.Windows.Forms.TextBox();
            this.formTextGameName = new System.Windows.Forms.TextBox();
            this.formLabelGameName = new System.Windows.Forms.Label();
            this.formTextAdditionalFiles = new System.Windows.Forms.TextBox();
            this.formLabelAdditionalFiles = new System.Windows.Forms.Label();
            this.formTextSaveLocation = new System.Windows.Forms.TextBox();
            this.formLabelSaveLocation = new System.Windows.Forms.Label();
            this.formButtonSaveLocation = new System.Windows.Forms.Button();
            this.formComboVersionSelect = new System.Windows.Forms.ComboBox();
            this.formLabelVersionSelect = new System.Windows.Forms.Label();
            this.formTabs = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.formCheckUseNightly = new System.Windows.Forms.CheckBox();
            this.formLabelVersionStatus = new System.Windows.Forms.Label();
            this.Folder = new System.Windows.Forms.TabPage();
            this.formLabelSaveLocationDetail = new System.Windows.Forms.Label();
            this.Files = new System.Windows.Forms.TabPage();
            this.formButtonThumbnailClear = new System.Windows.Forms.Button();
            this.formButtonThumbnail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.formLabelThumbnailDetail = new System.Windows.Forms.Label();
            this.formComboRunAddVersion = new System.Windows.Forms.ComboBox();
            this.formLabelThumbnail = new System.Windows.Forms.Label();
            this.formTextThumbnail = new System.Windows.Forms.TextBox();
            this.formLabelRunAddVersion = new System.Windows.Forms.Label();
            this.Java = new System.Windows.Forms.TabPage();
            this.Program = new System.Windows.Forms.TabPage();
            this.Delete = new System.Windows.Forms.TabPage();
            this.formButtonDeleteAll = new System.Windows.Forms.Button();
            this.formButtonDeleteVerList = new System.Windows.Forms.Button();
            this.formButtonDeleteVerFiles = new System.Windows.Forms.Button();
            this.formButtonDeleteNatives = new System.Windows.Forms.Button();
            this.formButtonDeleteSaves = new System.Windows.Forms.Button();
            this.formButtonDeleteAssets = new System.Windows.Forms.Button();
            this.formButtonDeleteAllButSaves = new System.Windows.Forms.Button();
            this.formButtonDeleteLibraries = new System.Windows.Forms.Button();
            this.formPanel = new System.Windows.Forms.Panel();
            this.formLabelMinecraftSettingsTitle = new System.Windows.Forms.Label();
            this.formButtonClose = new System.Windows.Forms.Button();
            this.formFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.formTabs.SuspendLayout();
            this.General.SuspendLayout();
            this.Folder.SuspendLayout();
            this.Files.SuspendLayout();
            this.Java.SuspendLayout();
            this.Program.SuspendLayout();
            this.Delete.SuspendLayout();
            this.formPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formComboStartRam
            // 
            this.formComboStartRam.DropDownHeight = 115;
            this.formComboStartRam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formComboStartRam.FormattingEnabled = true;
            this.formComboStartRam.IntegralHeight = false;
            this.formComboStartRam.ItemHeight = 13;
            this.formComboStartRam.Location = new System.Drawing.Point(8, 24);
            this.formComboStartRam.Name = "formComboStartRam";
            this.formComboStartRam.Size = new System.Drawing.Size(120, 21);
            this.formComboStartRam.TabIndex = 0;
            this.formComboStartRam.SelectedIndexChanged += new System.EventHandler(this.formComboStartRam_SelectedIndexChanged);
            // 
            // formComboMaxRam
            // 
            this.formComboMaxRam.DropDownHeight = 115;
            this.formComboMaxRam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formComboMaxRam.FormattingEnabled = true;
            this.formComboMaxRam.IntegralHeight = false;
            this.formComboMaxRam.ItemHeight = 13;
            this.formComboMaxRam.Location = new System.Drawing.Point(144, 24);
            this.formComboMaxRam.Name = "formComboMaxRam";
            this.formComboMaxRam.Size = new System.Drawing.Size(120, 21);
            this.formComboMaxRam.TabIndex = 1;
            this.formComboMaxRam.SelectedIndexChanged += new System.EventHandler(this.formComboMaxRam_SelectedIndexChanged);
            // 
            // formCheckCMD
            // 
            this.formCheckCMD.AutoSize = true;
            this.formCheckCMD.Location = new System.Drawing.Point(8, 56);
            this.formCheckCMD.Name = "formCheckCMD";
            this.formCheckCMD.Size = new System.Drawing.Size(87, 17);
            this.formCheckCMD.TabIndex = 2;
            this.formCheckCMD.Text = "Display CMD";
            this.formCheckCMD.UseVisualStyleBackColor = true;
            // 
            // formCheckOnline
            // 
            this.formCheckOnline.AutoSize = true;
            this.formCheckOnline.Location = new System.Drawing.Point(160, 8);
            this.formCheckOnline.Name = "formCheckOnline";
            this.formCheckOnline.Size = new System.Drawing.Size(86, 17);
            this.formCheckOnline.TabIndex = 3;
            this.formCheckOnline.Text = "Online Mode";
            this.formCheckOnline.UseVisualStyleBackColor = true;
            this.formCheckOnline.CheckedChanged += new System.EventHandler(this.formCheckOnline_CheckedChanged);
            // 
            // formRadio64bitJava
            // 
            this.formRadio64bitJava.AutoSize = true;
            this.formRadio64bitJava.Checked = true;
            this.formRadio64bitJava.Location = new System.Drawing.Point(16, 96);
            this.formRadio64bitJava.Name = "formRadio64bitJava";
            this.formRadio64bitJava.Size = new System.Drawing.Size(104, 17);
            this.formRadio64bitJava.TabIndex = 4;
            this.formRadio64bitJava.TabStop = true;
            this.formRadio64bitJava.Text = "Force 64bit Java";
            this.formRadio64bitJava.UseVisualStyleBackColor = true;
            // 
            // formRadio32bitJava
            // 
            this.formRadio32bitJava.AutoSize = true;
            this.formRadio32bitJava.Location = new System.Drawing.Point(16, 112);
            this.formRadio32bitJava.Name = "formRadio32bitJava";
            this.formRadio32bitJava.Size = new System.Drawing.Size(104, 17);
            this.formRadio32bitJava.TabIndex = 5;
            this.formRadio32bitJava.Text = "Force 32bit Java";
            this.formRadio32bitJava.UseVisualStyleBackColor = true;
            this.formRadio32bitJava.CheckedChanged += new System.EventHandler(this.formRadio32bitJava_CheckedChanged);
            // 
            // formCheckAutoJava
            // 
            this.formCheckAutoJava.AutoSize = true;
            this.formCheckAutoJava.Location = new System.Drawing.Point(8, 80);
            this.formCheckAutoJava.Name = "formCheckAutoJava";
            this.formCheckAutoJava.Size = new System.Drawing.Size(107, 17);
            this.formCheckAutoJava.TabIndex = 6;
            this.formCheckAutoJava.Text = "Auto Select Java";
            this.formCheckAutoJava.UseVisualStyleBackColor = true;
            this.formCheckAutoJava.CheckedChanged += new System.EventHandler(this.formCheckAutoJava_CheckedChanged);
            // 
            // formTextMinecraftLocation
            // 
            this.formTextMinecraftLocation.Location = new System.Drawing.Point(8, 24);
            this.formTextMinecraftLocation.Name = "formTextMinecraftLocation";
            this.formTextMinecraftLocation.Size = new System.Drawing.Size(256, 20);
            this.formTextMinecraftLocation.TabIndex = 7;
            // 
            // formLabelMinecraftLocation
            // 
            this.formLabelMinecraftLocation.AutoSize = true;
            this.formLabelMinecraftLocation.Location = new System.Drawing.Point(8, 8);
            this.formLabelMinecraftLocation.Name = "formLabelMinecraftLocation";
            this.formLabelMinecraftLocation.Size = new System.Drawing.Size(127, 13);
            this.formLabelMinecraftLocation.TabIndex = 8;
            this.formLabelMinecraftLocation.Text = "Minecraft Folder Location";
            // 
            // mcLabelStartRam
            // 
            this.mcLabelStartRam.AutoSize = true;
            this.mcLabelStartRam.Location = new System.Drawing.Point(8, 8);
            this.mcLabelStartRam.Name = "mcLabelStartRam";
            this.mcLabelStartRam.Size = new System.Drawing.Size(68, 13);
            this.mcLabelStartRam.TabIndex = 9;
            this.mcLabelStartRam.Text = "Starting Ram";
            // 
            // mcLabelMaxRam
            // 
            this.mcLabelMaxRam.AutoSize = true;
            this.mcLabelMaxRam.Location = new System.Drawing.Point(144, 8);
            this.mcLabelMaxRam.Name = "mcLabelMaxRam";
            this.mcLabelMaxRam.Size = new System.Drawing.Size(52, 13);
            this.mcLabelMaxRam.TabIndex = 9;
            this.mcLabelMaxRam.Text = "Max Ram";
            // 
            // formButtonMinecraftFolder
            // 
            this.formButtonMinecraftFolder.Location = new System.Drawing.Point(8, 48);
            this.formButtonMinecraftFolder.Name = "formButtonMinecraftFolder";
            this.formButtonMinecraftFolder.Size = new System.Drawing.Size(80, 24);
            this.formButtonMinecraftFolder.TabIndex = 10;
            this.formButtonMinecraftFolder.Text = "Select Folder";
            this.formButtonMinecraftFolder.UseVisualStyleBackColor = true;
            this.formButtonMinecraftFolder.Click += new System.EventHandler(this.formButtonMinecraftLocation_Click);
            // 
            // formButtonOK
            // 
            this.formButtonOK.BackColor = System.Drawing.Color.White;
            this.formButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonOK.Location = new System.Drawing.Point(192, 8);
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
            this.formButtonCancel.Location = new System.Drawing.Point(128, 8);
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
            this.formButtonDefaults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonDefaults.ForeColor = System.Drawing.Color.Black;
            this.formButtonDefaults.Location = new System.Drawing.Point(8, 8);
            this.formButtonDefaults.Name = "formButtonDefaults";
            this.formButtonDefaults.Size = new System.Drawing.Size(56, 24);
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
            this.formComboCPUPriority.Location = new System.Drawing.Point(8, 24);
            this.formComboCPUPriority.Name = "formComboCPUPriority";
            this.formComboCPUPriority.Size = new System.Drawing.Size(120, 21);
            this.formComboCPUPriority.TabIndex = 14;
            // 
            // formLabelCPUPriority
            // 
            this.formLabelCPUPriority.AutoSize = true;
            this.formLabelCPUPriority.Location = new System.Drawing.Point(8, 8);
            this.formLabelCPUPriority.Name = "formLabelCPUPriority";
            this.formLabelCPUPriority.Size = new System.Drawing.Size(63, 13);
            this.formLabelCPUPriority.TabIndex = 15;
            this.formLabelCPUPriority.Text = "CPU Priority";
            // 
            // formLabelStatus
            // 
            this.formLabelStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.formLabelStatus.Location = new System.Drawing.Point(8, 40);
            this.formLabelStatus.Name = "formLabelStatus";
            this.formLabelStatus.Size = new System.Drawing.Size(256, 24);
            this.formLabelStatus.TabIndex = 16;
            this.formLabelStatus.Text = "System OK.";
            this.formLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formTextUsername
            // 
            this.formTextUsername.Enabled = false;
            this.formTextUsername.Location = new System.Drawing.Point(160, 24);
            this.formTextUsername.Name = "formTextUsername";
            this.formTextUsername.Size = new System.Drawing.Size(104, 20);
            this.formTextUsername.TabIndex = 17;
            this.formTextUsername.Text = "Player";
            // 
            // formTextGameName
            // 
            this.formTextGameName.Location = new System.Drawing.Point(8, 24);
            this.formTextGameName.Name = "formTextGameName";
            this.formTextGameName.Size = new System.Drawing.Size(144, 20);
            this.formTextGameName.TabIndex = 7;
            // 
            // formLabelGameName
            // 
            this.formLabelGameName.AutoSize = true;
            this.formLabelGameName.Location = new System.Drawing.Point(8, 8);
            this.formLabelGameName.Name = "formLabelGameName";
            this.formLabelGameName.Size = new System.Drawing.Size(104, 13);
            this.formLabelGameName.TabIndex = 8;
            this.formLabelGameName.Text = "Custom Game Name";
            // 
            // formTextAdditionalFiles
            // 
            this.formTextAdditionalFiles.Enabled = false;
            this.formTextAdditionalFiles.Location = new System.Drawing.Point(8, 112);
            this.formTextAdditionalFiles.Name = "formTextAdditionalFiles";
            this.formTextAdditionalFiles.Size = new System.Drawing.Size(256, 20);
            this.formTextAdditionalFiles.TabIndex = 7;
            // 
            // formLabelAdditionalFiles
            // 
            this.formLabelAdditionalFiles.AutoSize = true;
            this.formLabelAdditionalFiles.Enabled = false;
            this.formLabelAdditionalFiles.Location = new System.Drawing.Point(8, 96);
            this.formLabelAdditionalFiles.Name = "formLabelAdditionalFiles";
            this.formLabelAdditionalFiles.Size = new System.Drawing.Size(102, 13);
            this.formLabelAdditionalFiles.TabIndex = 8;
            this.formLabelAdditionalFiles.Text = "Additional Files URL";
            // 
            // formTextSaveLocation
            // 
            this.formTextSaveLocation.Location = new System.Drawing.Point(8, 104);
            this.formTextSaveLocation.Name = "formTextSaveLocation";
            this.formTextSaveLocation.Size = new System.Drawing.Size(256, 20);
            this.formTextSaveLocation.TabIndex = 7;
            // 
            // formLabelSaveLocation
            // 
            this.formLabelSaveLocation.AutoSize = true;
            this.formLabelSaveLocation.Location = new System.Drawing.Point(8, 88);
            this.formLabelSaveLocation.Name = "formLabelSaveLocation";
            this.formLabelSaveLocation.Size = new System.Drawing.Size(123, 13);
            this.formLabelSaveLocation.TabIndex = 8;
            this.formLabelSaveLocation.Text = "Minecraft Save Location";
            // 
            // formButtonSaveLocation
            // 
            this.formButtonSaveLocation.Location = new System.Drawing.Point(8, 128);
            this.formButtonSaveLocation.Name = "formButtonSaveLocation";
            this.formButtonSaveLocation.Size = new System.Drawing.Size(80, 24);
            this.formButtonSaveLocation.TabIndex = 10;
            this.formButtonSaveLocation.Text = "Select Folder";
            this.formButtonSaveLocation.UseVisualStyleBackColor = true;
            this.formButtonSaveLocation.Click += new System.EventHandler(this.formButtonSaveLocation_Click);
            // 
            // formComboVersionSelect
            // 
            this.formComboVersionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formComboVersionSelect.FormattingEnabled = true;
            this.formComboVersionSelect.Items.AddRange(new object[] {
            "Latest: Recommended",
            "Latest: Development"});
            this.formComboVersionSelect.Location = new System.Drawing.Point(8, 64);
            this.formComboVersionSelect.Name = "formComboVersionSelect";
            this.formComboVersionSelect.Size = new System.Drawing.Size(144, 21);
            this.formComboVersionSelect.TabIndex = 14;
            // 
            // formLabelVersionSelect
            // 
            this.formLabelVersionSelect.AutoSize = true;
            this.formLabelVersionSelect.Location = new System.Drawing.Point(8, 48);
            this.formLabelVersionSelect.Name = "formLabelVersionSelect";
            this.formLabelVersionSelect.Size = new System.Drawing.Size(75, 13);
            this.formLabelVersionSelect.TabIndex = 15;
            this.formLabelVersionSelect.Text = "Select Version";
            // 
            // formTabs
            // 
            this.formTabs.Controls.Add(this.General);
            this.formTabs.Controls.Add(this.Folder);
            this.formTabs.Controls.Add(this.Files);
            this.formTabs.Controls.Add(this.Java);
            this.formTabs.Controls.Add(this.Program);
            this.formTabs.Controls.Add(this.Delete);
            this.formTabs.Location = new System.Drawing.Point(8, 39);
            this.formTabs.Name = "formTabs";
            this.formTabs.SelectedIndex = 0;
            this.formTabs.Size = new System.Drawing.Size(280, 192);
            this.formTabs.TabIndex = 18;
            // 
            // General
            // 
            this.General.Controls.Add(this.formCheckUseNightly);
            this.General.Controls.Add(this.formLabelVersionStatus);
            this.General.Controls.Add(this.formLabelGameName);
            this.General.Controls.Add(this.formTextUsername);
            this.General.Controls.Add(this.formTextGameName);
            this.General.Controls.Add(this.formComboVersionSelect);
            this.General.Controls.Add(this.formLabelVersionSelect);
            this.General.Controls.Add(this.formCheckOnline);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(272, 166);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // formCheckUseNightly
            // 
            this.formCheckUseNightly.AutoSize = true;
            this.formCheckUseNightly.Enabled = false;
            this.formCheckUseNightly.Location = new System.Drawing.Point(8, 88);
            this.formCheckUseNightly.Name = "formCheckUseNightly";
            this.formCheckUseNightly.Size = new System.Drawing.Size(122, 17);
            this.formCheckUseNightly.TabIndex = 6;
            this.formCheckUseNightly.Text = "Use Nightly Libraries";
            this.formCheckUseNightly.UseVisualStyleBackColor = true;
            this.formCheckUseNightly.CheckedChanged += new System.EventHandler(this.formCheckUseNightly_CheckedChanged);
            // 
            // formLabelVersionStatus
            // 
            this.formLabelVersionStatus.Location = new System.Drawing.Point(8, 112);
            this.formLabelVersionStatus.Name = "formLabelVersionStatus";
            this.formLabelVersionStatus.Size = new System.Drawing.Size(256, 48);
            this.formLabelVersionStatus.TabIndex = 18;
            this.formLabelVersionStatus.Text = "Version List Status:";
            // 
            // Folder
            // 
            this.Folder.Controls.Add(this.formLabelSaveLocationDetail);
            this.Folder.Controls.Add(this.formButtonMinecraftFolder);
            this.Folder.Controls.Add(this.formTextMinecraftLocation);
            this.Folder.Controls.Add(this.formLabelMinecraftLocation);
            this.Folder.Controls.Add(this.formTextSaveLocation);
            this.Folder.Controls.Add(this.formLabelSaveLocation);
            this.Folder.Controls.Add(this.formButtonSaveLocation);
            this.Folder.Location = new System.Drawing.Point(4, 22);
            this.Folder.Name = "Folder";
            this.Folder.Size = new System.Drawing.Size(272, 166);
            this.Folder.TabIndex = 3;
            this.Folder.Text = "Folder";
            this.Folder.UseVisualStyleBackColor = true;
            // 
            // formLabelSaveLocationDetail
            // 
            this.formLabelSaveLocationDetail.Location = new System.Drawing.Point(96, 128);
            this.formLabelSaveLocationDetail.Name = "formLabelSaveLocationDetail";
            this.formLabelSaveLocationDetail.Size = new System.Drawing.Size(168, 32);
            this.formLabelSaveLocationDetail.TabIndex = 11;
            this.formLabelSaveLocationDetail.Text = "Change this to partition save data between games.";
            // 
            // Files
            // 
            this.Files.Controls.Add(this.formButtonThumbnailClear);
            this.Files.Controls.Add(this.formButtonThumbnail);
            this.Files.Controls.Add(this.label1);
            this.Files.Controls.Add(this.formLabelThumbnailDetail);
            this.Files.Controls.Add(this.formComboRunAddVersion);
            this.Files.Controls.Add(this.formLabelThumbnail);
            this.Files.Controls.Add(this.formTextThumbnail);
            this.Files.Controls.Add(this.formLabelRunAddVersion);
            this.Files.Controls.Add(this.formLabelAdditionalFiles);
            this.Files.Controls.Add(this.formTextAdditionalFiles);
            this.Files.Location = new System.Drawing.Point(4, 22);
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(272, 166);
            this.Files.TabIndex = 4;
            this.Files.Text = "Files";
            this.Files.UseVisualStyleBackColor = true;
            // 
            // formButtonThumbnailClear
            // 
            this.formButtonThumbnailClear.Location = new System.Drawing.Point(88, 48);
            this.formButtonThumbnailClear.Name = "formButtonThumbnailClear";
            this.formButtonThumbnailClear.Size = new System.Drawing.Size(40, 24);
            this.formButtonThumbnailClear.TabIndex = 10;
            this.formButtonThumbnailClear.Text = "Clear";
            this.formButtonThumbnailClear.UseVisualStyleBackColor = true;
            this.formButtonThumbnailClear.Click += new System.EventHandler(this.formButtonThumbnailClear_Click);
            // 
            // formButtonThumbnail
            // 
            this.formButtonThumbnail.Location = new System.Drawing.Point(8, 48);
            this.formButtonThumbnail.Name = "formButtonThumbnail";
            this.formButtonThumbnail.Size = new System.Drawing.Size(80, 24);
            this.formButtonThumbnail.TabIndex = 10;
            this.formButtonThumbnail.Text = "Select Image";
            this.formButtonThumbnail.UseVisualStyleBackColor = true;
            this.formButtonThumbnail.Click += new System.EventHandler(this.formButtonThumbnail_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Under Construction";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formLabelThumbnailDetail
            // 
            this.formLabelThumbnailDetail.Location = new System.Drawing.Point(128, 48);
            this.formLabelThumbnailDetail.Name = "formLabelThumbnailDetail";
            this.formLabelThumbnailDetail.Size = new System.Drawing.Size(136, 24);
            this.formLabelThumbnailDetail.TabIndex = 8;
            this.formLabelThumbnailDetail.Text = "Max Resolution: 260x80";
            this.formLabelThumbnailDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // formComboRunAddVersion
            // 
            this.formComboRunAddVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formComboRunAddVersion.Enabled = false;
            this.formComboRunAddVersion.FormattingEnabled = true;
            this.formComboRunAddVersion.Items.AddRange(new object[] {
            "Default"});
            this.formComboRunAddVersion.Location = new System.Drawing.Point(8, 136);
            this.formComboRunAddVersion.Name = "formComboRunAddVersion";
            this.formComboRunAddVersion.Size = new System.Drawing.Size(120, 21);
            this.formComboRunAddVersion.TabIndex = 14;
            // 
            // formLabelThumbnail
            // 
            this.formLabelThumbnail.AutoSize = true;
            this.formLabelThumbnail.Location = new System.Drawing.Point(8, 8);
            this.formLabelThumbnail.Name = "formLabelThumbnail";
            this.formLabelThumbnail.Size = new System.Drawing.Size(87, 13);
            this.formLabelThumbnail.TabIndex = 8;
            this.formLabelThumbnail.Text = "Game Thumbnail";
            // 
            // formTextThumbnail
            // 
            this.formTextThumbnail.Location = new System.Drawing.Point(8, 24);
            this.formTextThumbnail.Name = "formTextThumbnail";
            this.formTextThumbnail.ReadOnly = true;
            this.formTextThumbnail.Size = new System.Drawing.Size(256, 20);
            this.formTextThumbnail.TabIndex = 7;
            // 
            // formLabelRunAddVersion
            // 
            this.formLabelRunAddVersion.Enabled = false;
            this.formLabelRunAddVersion.Location = new System.Drawing.Point(128, 136);
            this.formLabelRunAddVersion.Name = "formLabelRunAddVersion";
            this.formLabelRunAddVersion.Size = new System.Drawing.Size(136, 21);
            this.formLabelRunAddVersion.TabIndex = 8;
            this.formLabelRunAddVersion.Text = "Run from what version?";
            this.formLabelRunAddVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Java
            // 
            this.Java.Controls.Add(this.formCheckCMD);
            this.Java.Controls.Add(this.formCheckAutoJava);
            this.Java.Controls.Add(this.formRadio64bitJava);
            this.Java.Controls.Add(this.formRadio32bitJava);
            this.Java.Controls.Add(this.mcLabelStartRam);
            this.Java.Controls.Add(this.formComboStartRam);
            this.Java.Controls.Add(this.mcLabelMaxRam);
            this.Java.Controls.Add(this.formComboMaxRam);
            this.Java.Location = new System.Drawing.Point(4, 22);
            this.Java.Name = "Java";
            this.Java.Padding = new System.Windows.Forms.Padding(3);
            this.Java.Size = new System.Drawing.Size(272, 166);
            this.Java.TabIndex = 1;
            this.Java.Text = "Java";
            this.Java.UseVisualStyleBackColor = true;
            // 
            // Program
            // 
            this.Program.Controls.Add(this.formLabelCPUPriority);
            this.Program.Controls.Add(this.formComboCPUPriority);
            this.Program.Location = new System.Drawing.Point(4, 22);
            this.Program.Name = "Program";
            this.Program.Size = new System.Drawing.Size(272, 166);
            this.Program.TabIndex = 2;
            this.Program.Text = "Program";
            this.Program.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Controls.Add(this.formButtonDeleteAll);
            this.Delete.Controls.Add(this.formButtonDeleteVerList);
            this.Delete.Controls.Add(this.formButtonDeleteVerFiles);
            this.Delete.Controls.Add(this.formButtonDeleteNatives);
            this.Delete.Controls.Add(this.formButtonDeleteSaves);
            this.Delete.Controls.Add(this.formButtonDeleteAssets);
            this.Delete.Controls.Add(this.formButtonDeleteAllButSaves);
            this.Delete.Controls.Add(this.formButtonDeleteLibraries);
            this.Delete.Location = new System.Drawing.Point(4, 22);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(272, 166);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            // 
            // formButtonDeleteAll
            // 
            this.formButtonDeleteAll.Location = new System.Drawing.Point(8, 136);
            this.formButtonDeleteAll.Name = "formButtonDeleteAll";
            this.formButtonDeleteAll.Size = new System.Drawing.Size(256, 24);
            this.formButtonDeleteAll.TabIndex = 11;
            this.formButtonDeleteAll.Text = "Delete All";
            this.formButtonDeleteAll.UseVisualStyleBackColor = false;
            this.formButtonDeleteAll.Click += new System.EventHandler(this.formButtonDeleteAll_Click);
            // 
            // formButtonDeleteVerList
            // 
            this.formButtonDeleteVerList.Location = new System.Drawing.Point(144, 8);
            this.formButtonDeleteVerList.Name = "formButtonDeleteVerList";
            this.formButtonDeleteVerList.Size = new System.Drawing.Size(120, 24);
            this.formButtonDeleteVerList.TabIndex = 11;
            this.formButtonDeleteVerList.Text = "Delete Version List";
            this.formButtonDeleteVerList.UseVisualStyleBackColor = false;
            this.formButtonDeleteVerList.Click += new System.EventHandler(this.formButtonDeleteVerList_Click);
            // 
            // formButtonDeleteVerFiles
            // 
            this.formButtonDeleteVerFiles.Location = new System.Drawing.Point(8, 8);
            this.formButtonDeleteVerFiles.Name = "formButtonDeleteVerFiles";
            this.formButtonDeleteVerFiles.Size = new System.Drawing.Size(120, 24);
            this.formButtonDeleteVerFiles.TabIndex = 11;
            this.formButtonDeleteVerFiles.Text = "Delete Version Files";
            this.formButtonDeleteVerFiles.UseVisualStyleBackColor = false;
            this.formButtonDeleteVerFiles.Click += new System.EventHandler(this.formButtonDeleteVerFiles_Click);
            // 
            // formButtonDeleteNatives
            // 
            this.formButtonDeleteNatives.Location = new System.Drawing.Point(144, 40);
            this.formButtonDeleteNatives.Name = "formButtonDeleteNatives";
            this.formButtonDeleteNatives.Size = new System.Drawing.Size(120, 24);
            this.formButtonDeleteNatives.TabIndex = 11;
            this.formButtonDeleteNatives.Text = "Delete Natives";
            this.formButtonDeleteNatives.UseVisualStyleBackColor = false;
            this.formButtonDeleteNatives.Click += new System.EventHandler(this.formButtonDeleteNatives_Click);
            // 
            // formButtonDeleteSaves
            // 
            this.formButtonDeleteSaves.Location = new System.Drawing.Point(144, 72);
            this.formButtonDeleteSaves.Name = "formButtonDeleteSaves";
            this.formButtonDeleteSaves.Size = new System.Drawing.Size(120, 24);
            this.formButtonDeleteSaves.TabIndex = 11;
            this.formButtonDeleteSaves.Text = "Delete Saves";
            this.formButtonDeleteSaves.UseVisualStyleBackColor = false;
            this.formButtonDeleteSaves.Click += new System.EventHandler(this.formButtonDeleteSaves_Click);
            // 
            // formButtonDeleteAssets
            // 
            this.formButtonDeleteAssets.Location = new System.Drawing.Point(8, 72);
            this.formButtonDeleteAssets.Name = "formButtonDeleteAssets";
            this.formButtonDeleteAssets.Size = new System.Drawing.Size(120, 24);
            this.formButtonDeleteAssets.TabIndex = 11;
            this.formButtonDeleteAssets.Text = "Delete Assets";
            this.formButtonDeleteAssets.UseVisualStyleBackColor = false;
            this.formButtonDeleteAssets.Click += new System.EventHandler(this.formButtonDeleteAssets_Click);
            // 
            // formButtonDeleteAllButSaves
            // 
            this.formButtonDeleteAllButSaves.Location = new System.Drawing.Point(8, 104);
            this.formButtonDeleteAllButSaves.Name = "formButtonDeleteAllButSaves";
            this.formButtonDeleteAllButSaves.Size = new System.Drawing.Size(256, 24);
            this.formButtonDeleteAllButSaves.TabIndex = 11;
            this.formButtonDeleteAllButSaves.Text = "Delete All Except Saves";
            this.formButtonDeleteAllButSaves.UseVisualStyleBackColor = false;
            this.formButtonDeleteAllButSaves.Click += new System.EventHandler(this.formButtonDeleteAllButSaves_Click);
            // 
            // formButtonDeleteLibraries
            // 
            this.formButtonDeleteLibraries.Location = new System.Drawing.Point(8, 40);
            this.formButtonDeleteLibraries.Name = "formButtonDeleteLibraries";
            this.formButtonDeleteLibraries.Size = new System.Drawing.Size(120, 24);
            this.formButtonDeleteLibraries.TabIndex = 11;
            this.formButtonDeleteLibraries.Text = "Delete Libraries";
            this.formButtonDeleteLibraries.UseVisualStyleBackColor = false;
            this.formButtonDeleteLibraries.Click += new System.EventHandler(this.formButtonDeleteLibraries_Click);
            // 
            // formPanel
            // 
            this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formPanel.Controls.Add(this.formButtonDefaults);
            this.formPanel.Controls.Add(this.formButtonOK);
            this.formPanel.Controls.Add(this.formLabelStatus);
            this.formPanel.Controls.Add(this.formButtonCancel);
            this.formPanel.Location = new System.Drawing.Point(8, 232);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(280, 72);
            this.formPanel.TabIndex = 19;
            // 
            // formLabelMinecraftSettingsTitle
            // 
            this.formLabelMinecraftSettingsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabelMinecraftSettingsTitle.Location = new System.Drawing.Point(8, 8);
            this.formLabelMinecraftSettingsTitle.Name = "formLabelMinecraftSettingsTitle";
            this.formLabelMinecraftSettingsTitle.Size = new System.Drawing.Size(224, 24);
            this.formLabelMinecraftSettingsTitle.TabIndex = 20;
            this.formLabelMinecraftSettingsTitle.Text = "Minecraft Settings";
            this.formLabelMinecraftSettingsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formButtonClose
            // 
            this.formButtonClose.BackColor = System.Drawing.SystemColors.Control;
            this.formButtonClose.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.formButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonClose.Location = new System.Drawing.Point(264, 8);
            this.formButtonClose.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonClose.Name = "formButtonClose";
            this.formButtonClose.Size = new System.Drawing.Size(24, 24);
            this.formButtonClose.TabIndex = 12;
            this.formButtonClose.Text = "X";
            this.formButtonClose.UseVisualStyleBackColor = false;
            this.formButtonClose.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // atomMinecraftSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 314);
            this.ControlBox = false;
            this.Controls.Add(this.formLabelMinecraftSettingsTitle);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.formTabs);
            this.Controls.Add(this.formButtonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "atomMinecraftSettings";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Minecraft Settings";
            this.Load += new System.EventHandler(this.minecraftSettings_Load);
            this.formTabs.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.Folder.ResumeLayout(false);
            this.Folder.PerformLayout();
            this.Files.ResumeLayout(false);
            this.Files.PerformLayout();
            this.Java.ResumeLayout(false);
            this.Java.PerformLayout();
            this.Program.ResumeLayout(false);
            this.Program.PerformLayout();
            this.Delete.ResumeLayout(false);
            this.formPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox formComboStartRam;
        private System.Windows.Forms.ComboBox formComboMaxRam;
        private System.Windows.Forms.CheckBox formCheckCMD;
        private System.Windows.Forms.CheckBox formCheckOnline;
        private System.Windows.Forms.RadioButton formRadio64bitJava;
        private System.Windows.Forms.RadioButton formRadio32bitJava;
        private System.Windows.Forms.CheckBox formCheckAutoJava;
        private System.Windows.Forms.TextBox formTextMinecraftLocation;
        private System.Windows.Forms.FolderBrowserDialog formFolderDialog;
        private System.Windows.Forms.Label formLabelMinecraftLocation;
        private System.Windows.Forms.Label mcLabelStartRam;
        private System.Windows.Forms.Label mcLabelMaxRam;
        private System.Windows.Forms.Button formButtonMinecraftFolder;
        private System.Windows.Forms.Button formButtonOK;
        private System.Windows.Forms.Button formButtonCancel;
        private System.Windows.Forms.Button formButtonDefaults;
        private System.Windows.Forms.ComboBox formComboCPUPriority;
        private System.Windows.Forms.Label formLabelCPUPriority;
        private System.Windows.Forms.Label formLabelStatus;
        private System.Windows.Forms.TextBox formTextUsername;
        private System.Windows.Forms.TextBox formTextGameName;
        private System.Windows.Forms.Label formLabelGameName;
        private System.Windows.Forms.TextBox formTextAdditionalFiles;
        private System.Windows.Forms.Label formLabelAdditionalFiles;
        private System.Windows.Forms.TextBox formTextSaveLocation;
        private System.Windows.Forms.Label formLabelSaveLocation;
        private System.Windows.Forms.Button formButtonSaveLocation;
        private System.Windows.Forms.ComboBox formComboVersionSelect;
        private System.Windows.Forms.Label formLabelVersionSelect;
        private System.Windows.Forms.TabControl formTabs;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage Java;
        private System.Windows.Forms.TabPage Program;
        private System.Windows.Forms.TabPage Folder;
        private System.Windows.Forms.TabPage Files;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Button formButtonClose;
        private System.Windows.Forms.Label formLabelMinecraftSettingsTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label formLabelVersionStatus;
        private System.Windows.Forms.TabPage Delete;
        private System.Windows.Forms.Button formButtonDeleteLibraries;
        private System.Windows.Forms.Button formButtonDeleteAll;
        private System.Windows.Forms.Button formButtonDeleteVerList;
        private System.Windows.Forms.Button formButtonDeleteVerFiles;
        private System.Windows.Forms.Button formButtonDeleteNatives;
        private System.Windows.Forms.Button formButtonDeleteAllButSaves;
        private System.Windows.Forms.Button formButtonDeleteSaves;
        private System.Windows.Forms.Button formButtonDeleteAssets;
        private System.Windows.Forms.Button formButtonThumbnail;
        private System.Windows.Forms.Label formLabelThumbnail;
        private System.Windows.Forms.TextBox formTextThumbnail;
        private System.Windows.Forms.Label formLabelThumbnailDetail;
        private System.Windows.Forms.OpenFileDialog formFileDialog;
        private System.Windows.Forms.Button formButtonThumbnailClear;
        private System.Windows.Forms.CheckBox formCheckUseNightly;
        private System.Windows.Forms.ComboBox formComboRunAddVersion;
        private System.Windows.Forms.Label formLabelRunAddVersion;
        private System.Windows.Forms.Label formLabelSaveLocationDetail;

    }
}