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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(atomMinecraftSettings));
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
            this.formTextAppName = new System.Windows.Forms.TextBox();
            this.formLabelAppName = new System.Windows.Forms.Label();
            this.formTextAdditionalFiles = new System.Windows.Forms.TextBox();
            this.formLabelAdditionalFiles = new System.Windows.Forms.Label();
            this.formTextSaveLocation = new System.Windows.Forms.TextBox();
            this.formLabelSaveLocation = new System.Windows.Forms.Label();
            this.formButtonSaveLocation = new System.Windows.Forms.Button();
            this.formComboVersionSelect = new System.Windows.Forms.ComboBox();
            this.formLabelVersionSelect = new System.Windows.Forms.Label();
            this.formTabs = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.formCheckShowAlpha = new System.Windows.Forms.CheckBox();
            this.formCheckShowBeta = new System.Windows.Forms.CheckBox();
            this.formCheckShowDev = new System.Windows.Forms.CheckBox();
            this.formLabelVersionStatus = new System.Windows.Forms.Label();
            this.Files = new System.Windows.Forms.TabPage();
            this.formTextThumbnail = new System.Windows.Forms.TextBox();
            this.formLabelSaveLocationDetail = new System.Windows.Forms.Label();
            this.formButtonThumbnailClear = new System.Windows.Forms.Button();
            this.formButtonThumbnail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.formLabelThumbnailDetail = new System.Windows.Forms.Label();
            this.formLabelThumbnail = new System.Windows.Forms.Label();
            this.Java = new System.Windows.Forms.TabPage();
            this.Program = new System.Windows.Forms.TabPage();
            this.Delete = new System.Windows.Forms.TabPage();
            this.formButtonDeleteAll = new System.Windows.Forms.Button();
            this.formButtonDeleteVerList = new System.Windows.Forms.Button();
            this.formButtonDeleteVerFiles = new System.Windows.Forms.Button();
            this.formButtonDeleteNatives = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.formButtonDeleteSaves = new System.Windows.Forms.Button();
            this.formButtonDeleteAssets = new System.Windows.Forms.Button();
            this.formButtonDeleteAllButSaves = new System.Windows.Forms.Button();
            this.formButtonDeleteLibraries = new System.Windows.Forms.Button();
            this.formPanel = new System.Windows.Forms.Panel();
            this.formLabelMinecraftSettingsTitle = new System.Windows.Forms.Label();
            this.formFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.formButtonClose = new System.Windows.Forms.Button();
            this.formBarDelete = new System.Windows.Forms.ProgressBar();
            this.formTabs.SuspendLayout();
            this.General.SuspendLayout();
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
            this.formComboStartRam.ItemHeight = 9;
            this.formComboStartRam.Location = new System.Drawing.Point(8, 16);
            this.formComboStartRam.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formComboStartRam.Name = "formComboStartRam";
            this.formComboStartRam.Size = new System.Drawing.Size(124, 17);
            this.formComboStartRam.TabIndex = 0;
            this.formComboStartRam.SelectedIndexChanged += new System.EventHandler(this.formComboStartRam_SelectedIndexChanged);
            // 
            // formComboMaxRam
            // 
            this.formComboMaxRam.DropDownHeight = 115;
            this.formComboMaxRam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formComboMaxRam.FormattingEnabled = true;
            this.formComboMaxRam.IntegralHeight = false;
            this.formComboMaxRam.ItemHeight = 9;
            this.formComboMaxRam.Location = new System.Drawing.Point(148, 16);
            this.formComboMaxRam.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formComboMaxRam.Name = "formComboMaxRam";
            this.formComboMaxRam.Size = new System.Drawing.Size(124, 17);
            this.formComboMaxRam.TabIndex = 1;
            this.formComboMaxRam.SelectedIndexChanged += new System.EventHandler(this.formComboMaxRam_SelectedIndexChanged);
            // 
            // formCheckCMD
            // 
            this.formCheckCMD.AutoSize = true;
            this.formCheckCMD.Location = new System.Drawing.Point(148, 40);
            this.formCheckCMD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formCheckCMD.Name = "formCheckCMD";
            this.formCheckCMD.Size = new System.Drawing.Size(79, 14);
            this.formCheckCMD.TabIndex = 2;
            this.formCheckCMD.Text = "Display CMD";
            this.formCheckCMD.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formCheckCMD.UseVisualStyleBackColor = true;
            // 
            // formCheckOnline
            // 
            this.formCheckOnline.AutoSize = true;
            this.formCheckOnline.Location = new System.Drawing.Point(160, 32);
            this.formCheckOnline.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formCheckOnline.Name = "formCheckOnline";
            this.formCheckOnline.Size = new System.Drawing.Size(79, 14);
            this.formCheckOnline.TabIndex = 3;
            this.formCheckOnline.Text = "Online Mode";
            this.formCheckOnline.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formCheckOnline.UseVisualStyleBackColor = true;
            this.formCheckOnline.CheckedChanged += new System.EventHandler(this.formCheckOnline_CheckedChanged);
            // 
            // formRadio64bitJava
            // 
            this.formRadio64bitJava.AutoSize = true;
            this.formRadio64bitJava.Checked = true;
            this.formRadio64bitJava.Location = new System.Drawing.Point(16, 53);
            this.formRadio64bitJava.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formRadio64bitJava.Name = "formRadio64bitJava";
            this.formRadio64bitJava.Size = new System.Drawing.Size(103, 13);
            this.formRadio64bitJava.TabIndex = 4;
            this.formRadio64bitJava.TabStop = true;
            this.formRadio64bitJava.Text = "Force 64bit Java";
            this.formRadio64bitJava.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formRadio64bitJava.UseVisualStyleBackColor = true;
            // 
            // formRadio32bitJava
            // 
            this.formRadio32bitJava.AutoSize = true;
            this.formRadio32bitJava.Location = new System.Drawing.Point(16, 65);
            this.formRadio32bitJava.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formRadio32bitJava.Name = "formRadio32bitJava";
            this.formRadio32bitJava.Size = new System.Drawing.Size(103, 13);
            this.formRadio32bitJava.TabIndex = 5;
            this.formRadio32bitJava.Text = "Force 32bit Java";
            this.formRadio32bitJava.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formRadio32bitJava.UseVisualStyleBackColor = true;
            this.formRadio32bitJava.CheckedChanged += new System.EventHandler(this.formRadio32bitJava_CheckedChanged);
            // 
            // formCheckAutoJava
            // 
            this.formCheckAutoJava.AutoSize = true;
            this.formCheckAutoJava.Location = new System.Drawing.Point(8, 40);
            this.formCheckAutoJava.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formCheckAutoJava.Name = "formCheckAutoJava";
            this.formCheckAutoJava.Size = new System.Drawing.Size(104, 14);
            this.formCheckAutoJava.TabIndex = 6;
            this.formCheckAutoJava.Text = "Auto Select Java";
            this.formCheckAutoJava.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formCheckAutoJava.UseVisualStyleBackColor = true;
            this.formCheckAutoJava.CheckedChanged += new System.EventHandler(this.formCheckAutoJava_CheckedChanged);
            // 
            // formTextMinecraftLocation
            // 
            this.formTextMinecraftLocation.BackColor = System.Drawing.Color.White;
            this.formTextMinecraftLocation.Location = new System.Drawing.Point(8, 16);
            this.formTextMinecraftLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextMinecraftLocation.Name = "formTextMinecraftLocation";
            this.formTextMinecraftLocation.ReadOnly = true;
            this.formTextMinecraftLocation.Size = new System.Drawing.Size(264, 16);
            this.formTextMinecraftLocation.TabIndex = 7;
            // 
            // formLabelMinecraftLocation
            // 
            this.formLabelMinecraftLocation.Location = new System.Drawing.Point(8, 8);
            this.formLabelMinecraftLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelMinecraftLocation.Name = "formLabelMinecraftLocation";
            this.formLabelMinecraftLocation.Size = new System.Drawing.Size(264, 8);
            this.formLabelMinecraftLocation.TabIndex = 8;
            this.formLabelMinecraftLocation.Text = "Minecraft Folder Location";
            this.formLabelMinecraftLocation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // mcLabelStartRam
            // 
            this.mcLabelStartRam.Location = new System.Drawing.Point(8, 8);
            this.mcLabelStartRam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mcLabelStartRam.Name = "mcLabelStartRam";
            this.mcLabelStartRam.Size = new System.Drawing.Size(124, 8);
            this.mcLabelStartRam.TabIndex = 9;
            this.mcLabelStartRam.Text = "Starting Ram";
            this.mcLabelStartRam.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // mcLabelMaxRam
            // 
            this.mcLabelMaxRam.Location = new System.Drawing.Point(148, 8);
            this.mcLabelMaxRam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mcLabelMaxRam.Name = "mcLabelMaxRam";
            this.mcLabelMaxRam.Size = new System.Drawing.Size(124, 8);
            this.mcLabelMaxRam.TabIndex = 9;
            this.mcLabelMaxRam.Text = "Max Ram";
            this.mcLabelMaxRam.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formButtonMinecraftFolder
            // 
            this.formButtonMinecraftFolder.Location = new System.Drawing.Point(8, 32);
            this.formButtonMinecraftFolder.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonMinecraftFolder.Name = "formButtonMinecraftFolder";
            this.formButtonMinecraftFolder.Size = new System.Drawing.Size(88, 20);
            this.formButtonMinecraftFolder.TabIndex = 10;
            this.formButtonMinecraftFolder.Text = "Select Folder";
            this.formButtonMinecraftFolder.UseVisualStyleBackColor = true;
            this.formButtonMinecraftFolder.Click += new System.EventHandler(this.formButtonMinecraftLocation_Click);
            // 
            // formButtonOK
            // 
            this.formButtonOK.BackColor = System.Drawing.Color.White;
            this.formButtonOK.FlatAppearance.BorderSize = 0;
            this.formButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonOK.Location = new System.Drawing.Point(204, 36);
            this.formButtonOK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.formButtonCancel.FlatAppearance.BorderSize = 0;
            this.formButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonCancel.Location = new System.Drawing.Point(140, 36);
            this.formButtonCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.formButtonDefaults.FlatAppearance.BorderSize = 0;
            this.formButtonDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonDefaults.ForeColor = System.Drawing.Color.Black;
            this.formButtonDefaults.Location = new System.Drawing.Point(8, 36);
            this.formButtonDefaults.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.formComboCPUPriority.Location = new System.Drawing.Point(8, 16);
            this.formComboCPUPriority.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formComboCPUPriority.Name = "formComboCPUPriority";
            this.formComboCPUPriority.Size = new System.Drawing.Size(124, 17);
            this.formComboCPUPriority.TabIndex = 14;
            // 
            // formLabelCPUPriority
            // 
            this.formLabelCPUPriority.Location = new System.Drawing.Point(8, 8);
            this.formLabelCPUPriority.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelCPUPriority.Name = "formLabelCPUPriority";
            this.formLabelCPUPriority.Size = new System.Drawing.Size(120, 8);
            this.formLabelCPUPriority.TabIndex = 15;
            this.formLabelCPUPriority.Text = "CPU Priority";
            this.formLabelCPUPriority.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formLabelStatus
            // 
            this.formLabelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.formLabelStatus.Location = new System.Drawing.Point(8, 8);
            this.formLabelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelStatus.Name = "formLabelStatus";
            this.formLabelStatus.Size = new System.Drawing.Size(268, 24);
            this.formLabelStatus.TabIndex = 16;
            this.formLabelStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // formTextUsername
            // 
            this.formTextUsername.Enabled = false;
            this.formTextUsername.Location = new System.Drawing.Point(160, 16);
            this.formTextUsername.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextUsername.Name = "formTextUsername";
            this.formTextUsername.Size = new System.Drawing.Size(112, 16);
            this.formTextUsername.TabIndex = 17;
            this.formTextUsername.Text = "Player";
            // 
            // formTextAppName
            // 
            this.formTextAppName.Location = new System.Drawing.Point(8, 16);
            this.formTextAppName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextAppName.Name = "formTextAppName";
            this.formTextAppName.Size = new System.Drawing.Size(144, 16);
            this.formTextAppName.TabIndex = 7;
            // 
            // formLabelAppName
            // 
            this.formLabelAppName.Location = new System.Drawing.Point(8, 8);
            this.formLabelAppName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelAppName.Name = "formLabelAppName";
            this.formLabelAppName.Size = new System.Drawing.Size(124, 8);
            this.formLabelAppName.TabIndex = 8;
            this.formLabelAppName.Text = "Custom App Name";
            this.formLabelAppName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTextAdditionalFiles
            // 
            this.formTextAdditionalFiles.Enabled = false;
            this.formTextAdditionalFiles.Location = new System.Drawing.Point(8, 336);
            this.formTextAdditionalFiles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextAdditionalFiles.Name = "formTextAdditionalFiles";
            this.formTextAdditionalFiles.Size = new System.Drawing.Size(264, 16);
            this.formTextAdditionalFiles.TabIndex = 7;
            // 
            // formLabelAdditionalFiles
            // 
            this.formLabelAdditionalFiles.Enabled = false;
            this.formLabelAdditionalFiles.Location = new System.Drawing.Point(8, 328);
            this.formLabelAdditionalFiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelAdditionalFiles.Name = "formLabelAdditionalFiles";
            this.formLabelAdditionalFiles.Size = new System.Drawing.Size(264, 8);
            this.formLabelAdditionalFiles.TabIndex = 8;
            this.formLabelAdditionalFiles.Text = "Additional Files URL";
            this.formLabelAdditionalFiles.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTextSaveLocation
            // 
            this.formTextSaveLocation.BackColor = System.Drawing.Color.White;
            this.formTextSaveLocation.Location = new System.Drawing.Point(8, 68);
            this.formTextSaveLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextSaveLocation.Name = "formTextSaveLocation";
            this.formTextSaveLocation.ReadOnly = true;
            this.formTextSaveLocation.Size = new System.Drawing.Size(264, 16);
            this.formTextSaveLocation.TabIndex = 7;
            // 
            // formLabelSaveLocation
            // 
            this.formLabelSaveLocation.Location = new System.Drawing.Point(8, 60);
            this.formLabelSaveLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelSaveLocation.Name = "formLabelSaveLocation";
            this.formLabelSaveLocation.Size = new System.Drawing.Size(264, 8);
            this.formLabelSaveLocation.TabIndex = 8;
            this.formLabelSaveLocation.Text = "Minecraft Save Location";
            this.formLabelSaveLocation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formButtonSaveLocation
            // 
            this.formButtonSaveLocation.Location = new System.Drawing.Point(8, 84);
            this.formButtonSaveLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonSaveLocation.Name = "formButtonSaveLocation";
            this.formButtonSaveLocation.Size = new System.Drawing.Size(88, 20);
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
            this.formComboVersionSelect.Location = new System.Drawing.Point(8, 48);
            this.formComboVersionSelect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formComboVersionSelect.MaxDropDownItems = 16;
            this.formComboVersionSelect.Name = "formComboVersionSelect";
            this.formComboVersionSelect.Size = new System.Drawing.Size(144, 17);
            this.formComboVersionSelect.TabIndex = 14;
            // 
            // formLabelVersionSelect
            // 
            this.formLabelVersionSelect.Location = new System.Drawing.Point(8, 40);
            this.formLabelVersionSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelVersionSelect.Name = "formLabelVersionSelect";
            this.formLabelVersionSelect.Size = new System.Drawing.Size(144, 9);
            this.formLabelVersionSelect.TabIndex = 15;
            this.formLabelVersionSelect.Text = "Select Version";
            this.formLabelVersionSelect.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTabs
            // 
            this.formTabs.Controls.Add(this.General);
            this.formTabs.Controls.Add(this.Files);
            this.formTabs.Controls.Add(this.Java);
            this.formTabs.Controls.Add(this.Program);
            this.formTabs.Controls.Add(this.Delete);
            this.formTabs.Font = new System.Drawing.Font("Lucida Console", 6.75F);
            this.formTabs.Location = new System.Drawing.Point(4, 36);
            this.formTabs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTabs.Name = "formTabs";
            this.formTabs.SelectedIndex = 0;
            this.formTabs.Size = new System.Drawing.Size(288, 384);
            this.formTabs.TabIndex = 18;
            // 
            // General
            // 
            this.General.Controls.Add(this.formComboVersionSelect);
            this.General.Controls.Add(this.formLabelVersionSelect);
            this.General.Controls.Add(this.formTextUsername);
            this.General.Controls.Add(this.formCheckOnline);
            this.General.Controls.Add(this.formCheckShowAlpha);
            this.General.Controls.Add(this.formCheckShowBeta);
            this.General.Controls.Add(this.formCheckShowDev);
            this.General.Controls.Add(this.formLabelVersionStatus);
            this.General.Controls.Add(this.formLabelAppName);
            this.General.Controls.Add(this.formTextAppName);
            this.General.Location = new System.Drawing.Point(4, 19);
            this.General.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.General.Size = new System.Drawing.Size(280, 361);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // formCheckShowAlpha
            // 
            this.formCheckShowAlpha.AutoSize = true;
            this.formCheckShowAlpha.Location = new System.Drawing.Point(8, 92);
            this.formCheckShowAlpha.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formCheckShowAlpha.Name = "formCheckShowAlpha";
            this.formCheckShowAlpha.Size = new System.Drawing.Size(119, 14);
            this.formCheckShowAlpha.TabIndex = 6;
            this.formCheckShowAlpha.Text = "Show Alpha Versions";
            this.formCheckShowAlpha.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formCheckShowAlpha.UseVisualStyleBackColor = true;
            // 
            // formCheckShowBeta
            // 
            this.formCheckShowBeta.AutoSize = true;
            this.formCheckShowBeta.Location = new System.Drawing.Point(8, 80);
            this.formCheckShowBeta.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formCheckShowBeta.Name = "formCheckShowBeta";
            this.formCheckShowBeta.Size = new System.Drawing.Size(114, 14);
            this.formCheckShowBeta.TabIndex = 6;
            this.formCheckShowBeta.Text = "Show Beta Versions";
            this.formCheckShowBeta.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formCheckShowBeta.UseVisualStyleBackColor = true;
            // 
            // formCheckShowDev
            // 
            this.formCheckShowDev.AutoSize = true;
            this.formCheckShowDev.Location = new System.Drawing.Point(8, 68);
            this.formCheckShowDev.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formCheckShowDev.Name = "formCheckShowDev";
            this.formCheckShowDev.Size = new System.Drawing.Size(139, 14);
            this.formCheckShowDev.TabIndex = 6;
            this.formCheckShowDev.Text = "Show Development Builds";
            this.formCheckShowDev.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formCheckShowDev.UseVisualStyleBackColor = true;
            // 
            // formLabelVersionStatus
            // 
            this.formLabelVersionStatus.ForeColor = System.Drawing.Color.Blue;
            this.formLabelVersionStatus.Location = new System.Drawing.Point(8, 108);
            this.formLabelVersionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelVersionStatus.Name = "formLabelVersionStatus";
            this.formLabelVersionStatus.Size = new System.Drawing.Size(264, 40);
            this.formLabelVersionStatus.TabIndex = 18;
            this.formLabelVersionStatus.Text = "Version List Status:";
            // 
            // Files
            // 
            this.Files.Controls.Add(this.formTextThumbnail);
            this.Files.Controls.Add(this.formLabelSaveLocationDetail);
            this.Files.Controls.Add(this.formButtonThumbnailClear);
            this.Files.Controls.Add(this.formButtonThumbnail);
            this.Files.Controls.Add(this.formButtonMinecraftFolder);
            this.Files.Controls.Add(this.label1);
            this.Files.Controls.Add(this.formLabelThumbnailDetail);
            this.Files.Controls.Add(this.formTextMinecraftLocation);
            this.Files.Controls.Add(this.formLabelThumbnail);
            this.Files.Controls.Add(this.formLabelMinecraftLocation);
            this.Files.Controls.Add(this.formTextSaveLocation);
            this.Files.Controls.Add(this.formLabelSaveLocation);
            this.Files.Controls.Add(this.formLabelAdditionalFiles);
            this.Files.Controls.Add(this.formButtonSaveLocation);
            this.Files.Controls.Add(this.formTextAdditionalFiles);
            this.Files.Location = new System.Drawing.Point(4, 19);
            this.Files.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.formTextThumbnail.Location = new System.Drawing.Point(8, 120);
            this.formTextThumbnail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextThumbnail.Name = "formTextThumbnail";
            this.formTextThumbnail.ReadOnly = true;
            this.formTextThumbnail.Size = new System.Drawing.Size(264, 16);
            this.formTextThumbnail.TabIndex = 7;
            // 
            // formLabelSaveLocationDetail
            // 
            this.formLabelSaveLocationDetail.Location = new System.Drawing.Point(96, 84);
            this.formLabelSaveLocationDetail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelSaveLocationDetail.Name = "formLabelSaveLocationDetail";
            this.formLabelSaveLocationDetail.Size = new System.Drawing.Size(176, 32);
            this.formLabelSaveLocationDetail.TabIndex = 11;
            this.formLabelSaveLocationDetail.Text = "Change this to partition save data between apps.";
            // 
            // formButtonThumbnailClear
            // 
            this.formButtonThumbnailClear.Location = new System.Drawing.Point(96, 136);
            this.formButtonThumbnailClear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonThumbnailClear.Name = "formButtonThumbnailClear";
            this.formButtonThumbnailClear.Size = new System.Drawing.Size(44, 20);
            this.formButtonThumbnailClear.TabIndex = 10;
            this.formButtonThumbnailClear.Text = "Clear";
            this.formButtonThumbnailClear.UseVisualStyleBackColor = true;
            this.formButtonThumbnailClear.Click += new System.EventHandler(this.formButtonThumbnailClear_Click);
            // 
            // formButtonThumbnail
            // 
            this.formButtonThumbnail.Location = new System.Drawing.Point(8, 136);
            this.formButtonThumbnail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Under Construction";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formLabelThumbnailDetail
            // 
            this.formLabelThumbnailDetail.Location = new System.Drawing.Point(140, 136);
            this.formLabelThumbnailDetail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelThumbnailDetail.Name = "formLabelThumbnailDetail";
            this.formLabelThumbnailDetail.Size = new System.Drawing.Size(132, 20);
            this.formLabelThumbnailDetail.TabIndex = 8;
            this.formLabelThumbnailDetail.Text = "Max Resolution: 260x80";
            this.formLabelThumbnailDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // formLabelThumbnail
            // 
            this.formLabelThumbnail.Location = new System.Drawing.Point(8, 112);
            this.formLabelThumbnail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelThumbnail.Name = "formLabelThumbnail";
            this.formLabelThumbnail.Size = new System.Drawing.Size(264, 8);
            this.formLabelThumbnail.TabIndex = 8;
            this.formLabelThumbnail.Text = "App Thumbnail";
            this.formLabelThumbnail.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Java
            // 
            this.Java.Controls.Add(this.formRadio64bitJava);
            this.Java.Controls.Add(this.formRadio32bitJava);
            this.Java.Controls.Add(this.formCheckCMD);
            this.Java.Controls.Add(this.formCheckAutoJava);
            this.Java.Controls.Add(this.mcLabelStartRam);
            this.Java.Controls.Add(this.formComboStartRam);
            this.Java.Controls.Add(this.mcLabelMaxRam);
            this.Java.Controls.Add(this.formComboMaxRam);
            this.Java.Location = new System.Drawing.Point(4, 19);
            this.Java.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Java.Name = "Java";
            this.Java.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Java.Size = new System.Drawing.Size(280, 361);
            this.Java.TabIndex = 1;
            this.Java.Text = "Java";
            this.Java.UseVisualStyleBackColor = true;
            // 
            // Program
            // 
            this.Program.Controls.Add(this.formComboCPUPriority);
            this.Program.Controls.Add(this.formLabelCPUPriority);
            this.Program.Location = new System.Drawing.Point(4, 19);
            this.Program.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Program.Name = "Program";
            this.Program.Size = new System.Drawing.Size(280, 361);
            this.Program.TabIndex = 2;
            this.Program.Text = "Program";
            this.Program.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Controls.Add(this.formBarDelete);
            this.Delete.Controls.Add(this.formButtonDeleteAll);
            this.Delete.Controls.Add(this.formButtonDeleteVerList);
            this.Delete.Controls.Add(this.formButtonDeleteVerFiles);
            this.Delete.Controls.Add(this.formButtonDeleteNatives);
            this.Delete.Controls.Add(this.label2);
            this.Delete.Controls.Add(this.formButtonDeleteSaves);
            this.Delete.Controls.Add(this.formButtonDeleteAssets);
            this.Delete.Controls.Add(this.formButtonDeleteAllButSaves);
            this.Delete.Controls.Add(this.formButtonDeleteLibraries);
            this.Delete.Location = new System.Drawing.Point(4, 19);
            this.Delete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(280, 361);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            // 
            // formButtonDeleteAll
            // 
            this.formButtonDeleteAll.Location = new System.Drawing.Point(8, 88);
            this.formButtonDeleteAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteAll.Name = "formButtonDeleteAll";
            this.formButtonDeleteAll.Size = new System.Drawing.Size(264, 20);
            this.formButtonDeleteAll.TabIndex = 11;
            this.formButtonDeleteAll.Text = "Delete All";
            this.formButtonDeleteAll.UseVisualStyleBackColor = false;
            this.formButtonDeleteAll.Click += new System.EventHandler(this.formButtonDeleteAll_Click);
            // 
            // formButtonDeleteVerList
            // 
            this.formButtonDeleteVerList.Location = new System.Drawing.Point(144, 8);
            this.formButtonDeleteVerList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteVerList.Name = "formButtonDeleteVerList";
            this.formButtonDeleteVerList.Size = new System.Drawing.Size(128, 20);
            this.formButtonDeleteVerList.TabIndex = 11;
            this.formButtonDeleteVerList.Text = "Delete Version List";
            this.formButtonDeleteVerList.UseVisualStyleBackColor = false;
            this.formButtonDeleteVerList.Click += new System.EventHandler(this.formButtonDeleteVerList_Click);
            // 
            // formButtonDeleteVerFiles
            // 
            this.formButtonDeleteVerFiles.Location = new System.Drawing.Point(8, 8);
            this.formButtonDeleteVerFiles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteVerFiles.Name = "formButtonDeleteVerFiles";
            this.formButtonDeleteVerFiles.Size = new System.Drawing.Size(128, 20);
            this.formButtonDeleteVerFiles.TabIndex = 11;
            this.formButtonDeleteVerFiles.Text = "Delete Version Files";
            this.formButtonDeleteVerFiles.UseVisualStyleBackColor = false;
            this.formButtonDeleteVerFiles.Click += new System.EventHandler(this.formButtonDeleteVerFiles_Click);
            // 
            // formButtonDeleteNatives
            // 
            this.formButtonDeleteNatives.Location = new System.Drawing.Point(144, 28);
            this.formButtonDeleteNatives.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteNatives.Name = "formButtonDeleteNatives";
            this.formButtonDeleteNatives.Size = new System.Drawing.Size(128, 20);
            this.formButtonDeleteNatives.TabIndex = 11;
            this.formButtonDeleteNatives.Text = "Delete Natives";
            this.formButtonDeleteNatives.UseVisualStyleBackColor = false;
            this.formButtonDeleteNatives.Click += new System.EventHandler(this.formButtonDeleteNatives_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 216);
            this.label2.TabIndex = 15;
            this.label2.Text = "Use Caution, Still under construction. May error if somthing is wrong with the fi" +
                "les.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formButtonDeleteSaves
            // 
            this.formButtonDeleteSaves.Location = new System.Drawing.Point(144, 48);
            this.formButtonDeleteSaves.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteSaves.Name = "formButtonDeleteSaves";
            this.formButtonDeleteSaves.Size = new System.Drawing.Size(128, 20);
            this.formButtonDeleteSaves.TabIndex = 11;
            this.formButtonDeleteSaves.Text = "Delete Saves";
            this.formButtonDeleteSaves.UseVisualStyleBackColor = false;
            this.formButtonDeleteSaves.Click += new System.EventHandler(this.formButtonDeleteSaves_Click);
            // 
            // formButtonDeleteAssets
            // 
            this.formButtonDeleteAssets.Location = new System.Drawing.Point(8, 48);
            this.formButtonDeleteAssets.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteAssets.Name = "formButtonDeleteAssets";
            this.formButtonDeleteAssets.Size = new System.Drawing.Size(128, 20);
            this.formButtonDeleteAssets.TabIndex = 11;
            this.formButtonDeleteAssets.Text = "Delete Assets";
            this.formButtonDeleteAssets.UseVisualStyleBackColor = false;
            this.formButtonDeleteAssets.Click += new System.EventHandler(this.formButtonDeleteAssets_Click);
            // 
            // formButtonDeleteAllButSaves
            // 
            this.formButtonDeleteAllButSaves.Location = new System.Drawing.Point(8, 68);
            this.formButtonDeleteAllButSaves.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteAllButSaves.Name = "formButtonDeleteAllButSaves";
            this.formButtonDeleteAllButSaves.Size = new System.Drawing.Size(264, 20);
            this.formButtonDeleteAllButSaves.TabIndex = 11;
            this.formButtonDeleteAllButSaves.Text = "Delete All Except Saves";
            this.formButtonDeleteAllButSaves.UseVisualStyleBackColor = false;
            this.formButtonDeleteAllButSaves.Click += new System.EventHandler(this.formButtonDeleteAllButSaves_Click);
            // 
            // formButtonDeleteLibraries
            // 
            this.formButtonDeleteLibraries.Location = new System.Drawing.Point(8, 28);
            this.formButtonDeleteLibraries.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteLibraries.Name = "formButtonDeleteLibraries";
            this.formButtonDeleteLibraries.Size = new System.Drawing.Size(128, 20);
            this.formButtonDeleteLibraries.TabIndex = 11;
            this.formButtonDeleteLibraries.Text = "Delete Libraries";
            this.formButtonDeleteLibraries.UseVisualStyleBackColor = false;
            this.formButtonDeleteLibraries.Click += new System.EventHandler(this.formButtonDeleteLibraries_Click);
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
            this.formPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(288, 72);
            this.formPanel.TabIndex = 19;
            // 
            // formLabelMinecraftSettingsTitle
            // 
            this.formLabelMinecraftSettingsTitle.Font = new System.Drawing.Font("Lucida Console", 13.5F, System.Drawing.FontStyle.Bold);
            this.formLabelMinecraftSettingsTitle.Location = new System.Drawing.Point(4, 16);
            this.formLabelMinecraftSettingsTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelMinecraftSettingsTitle.Name = "formLabelMinecraftSettingsTitle";
            this.formLabelMinecraftSettingsTitle.Size = new System.Drawing.Size(284, 20);
            this.formLabelMinecraftSettingsTitle.TabIndex = 20;
            this.formLabelMinecraftSettingsTitle.Text = "Minecraft Settings";
            this.formLabelMinecraftSettingsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formButtonClose
            // 
            this.formButtonClose.BackColor = System.Drawing.Color.White;
            this.formButtonClose.BackgroundImage = global::AtomLauncher.Properties.Resources.xicon;
            this.formButtonClose.FlatAppearance.BorderSize = 0;
            this.formButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonClose.Location = new System.Drawing.Point(280, 0);
            this.formButtonClose.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonClose.Name = "formButtonClose";
            this.formButtonClose.Size = new System.Drawing.Size(14, 14);
            this.formButtonClose.TabIndex = 21;
            this.formButtonClose.TabStop = false;
            this.formButtonClose.UseVisualStyleBackColor = false;
            this.formButtonClose.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // formBarDelete
            // 
            this.formBarDelete.Location = new System.Drawing.Point(12, 340);
            this.formBarDelete.Name = "formBarDelete";
            this.formBarDelete.Size = new System.Drawing.Size(256, 12);
            this.formBarDelete.TabIndex = 16;
            // 
            // atomMinecraftSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 498);
            this.ControlBox = false;
            this.Controls.Add(this.formButtonClose);
            this.Controls.Add(this.formLabelMinecraftSettingsTitle);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.formTabs);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "atomMinecraftSettings";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Minecraft Settings";
            this.Load += new System.EventHandler(this.atomMinecraftSettings_Load);
            this.formTabs.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.Files.ResumeLayout(false);
            this.Files.PerformLayout();
            this.Java.ResumeLayout(false);
            this.Java.PerformLayout();
            this.Program.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox formTextAppName;
        private System.Windows.Forms.Label formLabelAppName;
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
        private System.Windows.Forms.TabPage Files;
        private System.Windows.Forms.Panel formPanel;
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
        private System.Windows.Forms.Label formLabelSaveLocationDetail;
        private System.Windows.Forms.Button formButtonClose;
        private System.Windows.Forms.CheckBox formCheckShowBeta;
        private System.Windows.Forms.CheckBox formCheckShowDev;
        private System.Windows.Forms.CheckBox formCheckShowAlpha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar formBarDelete;

    }
}