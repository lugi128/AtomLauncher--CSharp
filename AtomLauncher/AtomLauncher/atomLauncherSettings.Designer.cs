namespace AtomLauncher
{
    partial class atomLauncherSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(atomLauncherSettings));
            this.formFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.formButtonOK = new System.Windows.Forms.Button();
            this.formButtonCancel = new System.Windows.Forms.Button();
            this.formButtonDefaults = new System.Windows.Forms.Button();
            this.formLabelLauncherSettingsTitle = new System.Windows.Forms.Label();
            this.formFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.formButtonClose = new System.Windows.Forms.Button();
            this.formPanel = new System.Windows.Forms.Panel();
            this.formButtonDeleteAllData = new System.Windows.Forms.Button();
            this.formButtonDeleteUserData = new System.Windows.Forms.Button();
            this.formLabelUserDataName = new System.Windows.Forms.Label();
            this.formTextUserDataName = new System.Windows.Forms.TextBox();
            this.formLabelAppDataName = new System.Windows.Forms.Label();
            this.formTextAppDataName = new System.Windows.Forms.TextBox();
            this.formTextDataLocation = new System.Windows.Forms.TextBox();
            this.formButtonDataLocation = new System.Windows.Forms.Button();
            this.formLabelDataLocation = new System.Windows.Forms.Label();
            this.formLabelDataLocationDetail = new System.Windows.Forms.Label();
            this.formLabelVersionNum = new System.Windows.Forms.Label();
            this.formTextVersionNum = new System.Windows.Forms.TextBox();
            this.formLabelUpdateURL = new System.Windows.Forms.Label();
            this.formTextUpdateURL = new System.Windows.Forms.TextBox();
            this.formCheckCustomFont = new System.Windows.Forms.CheckBox();
            this.formTextBackground = new System.Windows.Forms.TextBox();
            this.formButtonBackgroundClear = new System.Windows.Forms.Button();
            this.formButtonBackground = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.formLabelBackgroundDetail = new System.Windows.Forms.Label();
            this.formLabelBackground = new System.Windows.Forms.Label();
            this.formNumAutoLoginTime = new System.Windows.Forms.NumericUpDown();
            this.formLabelDetail = new System.Windows.Forms.Label();
            this.formLabelError = new System.Windows.Forms.Label();
            this.formLabelAutoLoginTime = new System.Windows.Forms.Label();
            this.formPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formNumAutoLoginTime)).BeginInit();
            this.SuspendLayout();
            // 
            // formButtonOK
            // 
            this.formButtonOK.BackColor = System.Drawing.Color.White;
            this.formButtonOK.FlatAppearance.BorderSize = 0;
            this.formButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonOK.Font = new System.Drawing.Font("Lucida Console", 13.5F, System.Drawing.FontStyle.Bold);
            this.formButtonOK.Location = new System.Drawing.Point(204, 339);
            this.formButtonOK.Name = "formButtonOK";
            this.formButtonOK.Size = new System.Drawing.Size(72, 32);
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
            this.formButtonCancel.Location = new System.Drawing.Point(140, 347);
            this.formButtonCancel.Name = "formButtonCancel";
            this.formButtonCancel.Size = new System.Drawing.Size(56, 24);
            this.formButtonCancel.TabIndex = 12;
            this.formButtonCancel.Text = "Cancel";
            this.formButtonCancel.UseVisualStyleBackColor = false;
            this.formButtonCancel.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // formButtonDefaults
            // 
            this.formButtonDefaults.BackColor = System.Drawing.Color.LightGray;
            this.formButtonDefaults.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.formButtonDefaults.FlatAppearance.BorderSize = 0;
            this.formButtonDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonDefaults.ForeColor = System.Drawing.Color.Black;
            this.formButtonDefaults.Location = new System.Drawing.Point(10, 347);
            this.formButtonDefaults.Name = "formButtonDefaults";
            this.formButtonDefaults.Size = new System.Drawing.Size(64, 24);
            this.formButtonDefaults.TabIndex = 13;
            this.formButtonDefaults.Text = "Defaults";
            this.formButtonDefaults.UseVisualStyleBackColor = false;
            this.formButtonDefaults.Click += new System.EventHandler(this.formButtonDefaults_Click);
            // 
            // formLabelLauncherSettingsTitle
            // 
            this.formLabelLauncherSettingsTitle.Font = new System.Drawing.Font("Lucida Console", 13.5F, System.Drawing.FontStyle.Bold);
            this.formLabelLauncherSettingsTitle.ForeColor = System.Drawing.Color.White;
            this.formLabelLauncherSettingsTitle.Location = new System.Drawing.Point(4, 16);
            this.formLabelLauncherSettingsTitle.Name = "formLabelLauncherSettingsTitle";
            this.formLabelLauncherSettingsTitle.Size = new System.Drawing.Size(285, 20);
            this.formLabelLauncherSettingsTitle.TabIndex = 20;
            this.formLabelLauncherSettingsTitle.Text = "Launcher Settings";
            this.formLabelLauncherSettingsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.formButtonClose.TabIndex = 22;
            this.formButtonClose.TabStop = false;
            this.formButtonClose.UseVisualStyleBackColor = false;
            this.formButtonClose.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // formPanel
            // 
            this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formPanel.Controls.Add(this.formButtonDeleteAllData);
            this.formPanel.Controls.Add(this.formButtonDeleteUserData);
            this.formPanel.Controls.Add(this.formLabelUserDataName);
            this.formPanel.Controls.Add(this.formTextUserDataName);
            this.formPanel.Controls.Add(this.formLabelAppDataName);
            this.formPanel.Controls.Add(this.formTextAppDataName);
            this.formPanel.Controls.Add(this.formTextDataLocation);
            this.formPanel.Controls.Add(this.formButtonDataLocation);
            this.formPanel.Controls.Add(this.formLabelDataLocation);
            this.formPanel.Controls.Add(this.formLabelDataLocationDetail);
            this.formPanel.Controls.Add(this.formLabelVersionNum);
            this.formPanel.Controls.Add(this.formTextVersionNum);
            this.formPanel.Controls.Add(this.formLabelUpdateURL);
            this.formPanel.Controls.Add(this.formTextUpdateURL);
            this.formPanel.Controls.Add(this.formCheckCustomFont);
            this.formPanel.Controls.Add(this.formTextBackground);
            this.formPanel.Controls.Add(this.formButtonBackgroundClear);
            this.formPanel.Controls.Add(this.formButtonBackground);
            this.formPanel.Controls.Add(this.label1);
            this.formPanel.Controls.Add(this.formLabelBackgroundDetail);
            this.formPanel.Controls.Add(this.formLabelBackground);
            this.formPanel.Controls.Add(this.formNumAutoLoginTime);
            this.formPanel.Controls.Add(this.formLabelDetail);
            this.formPanel.Controls.Add(this.formLabelError);
            this.formPanel.Controls.Add(this.formLabelAutoLoginTime);
            this.formPanel.Controls.Add(this.formButtonDefaults);
            this.formPanel.Controls.Add(this.formButtonOK);
            this.formPanel.Controls.Add(this.formButtonCancel);
            this.formPanel.Font = new System.Drawing.Font("Lucida Console", 6.75F);
            this.formPanel.Location = new System.Drawing.Point(3, 36);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(288, 384);
            this.formPanel.TabIndex = 19;
            // 
            // formButtonDeleteAllData
            // 
            this.formButtonDeleteAllData.BackColor = System.Drawing.Color.White;
            this.formButtonDeleteAllData.Location = new System.Drawing.Point(136, 240);
            this.formButtonDeleteAllData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteAllData.Name = "formButtonDeleteAllData";
            this.formButtonDeleteAllData.Size = new System.Drawing.Size(128, 20);
            this.formButtonDeleteAllData.TabIndex = 33;
            this.formButtonDeleteAllData.Text = "Delete All Data";
            this.formButtonDeleteAllData.UseVisualStyleBackColor = false;
            this.formButtonDeleteAllData.Click += new System.EventHandler(this.formButtonDeleteAllData_Click);
            // 
            // formButtonDeleteUserData
            // 
            this.formButtonDeleteUserData.BackColor = System.Drawing.Color.White;
            this.formButtonDeleteUserData.Location = new System.Drawing.Point(136, 276);
            this.formButtonDeleteUserData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDeleteUserData.Name = "formButtonDeleteUserData";
            this.formButtonDeleteUserData.Size = new System.Drawing.Size(128, 20);
            this.formButtonDeleteUserData.TabIndex = 32;
            this.formButtonDeleteUserData.Text = "Delete User Data";
            this.formButtonDeleteUserData.UseVisualStyleBackColor = false;
            this.formButtonDeleteUserData.Click += new System.EventHandler(this.formButtonDeleteUserData_Click);
            // 
            // formLabelUserDataName
            // 
            this.formLabelUserDataName.ForeColor = System.Drawing.Color.White;
            this.formLabelUserDataName.Location = new System.Drawing.Point(4, 276);
            this.formLabelUserDataName.Name = "formLabelUserDataName";
            this.formLabelUserDataName.Size = new System.Drawing.Size(104, 8);
            this.formLabelUserDataName.TabIndex = 31;
            this.formLabelUserDataName.Text = "User Data Name";
            this.formLabelUserDataName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTextUserDataName
            // 
            this.formTextUserDataName.Location = new System.Drawing.Point(4, 284);
            this.formTextUserDataName.Name = "formTextUserDataName";
            this.formTextUserDataName.Size = new System.Drawing.Size(104, 16);
            this.formTextUserDataName.TabIndex = 30;
            this.formTextUserDataName.TextChanged += new System.EventHandler(this.formTextUserDataName_TextChanged);
            // 
            // formLabelAppDataName
            // 
            this.formLabelAppDataName.ForeColor = System.Drawing.Color.White;
            this.formLabelAppDataName.Location = new System.Drawing.Point(4, 240);
            this.formLabelAppDataName.Name = "formLabelAppDataName";
            this.formLabelAppDataName.Size = new System.Drawing.Size(104, 8);
            this.formLabelAppDataName.TabIndex = 29;
            this.formLabelAppDataName.Text = "App Data Name";
            this.formLabelAppDataName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTextAppDataName
            // 
            this.formTextAppDataName.Location = new System.Drawing.Point(4, 248);
            this.formTextAppDataName.Name = "formTextAppDataName";
            this.formTextAppDataName.Size = new System.Drawing.Size(104, 16);
            this.formTextAppDataName.TabIndex = 28;
            this.formTextAppDataName.TextChanged += new System.EventHandler(this.formTextAppDataName_TextChanged);
            // 
            // formTextDataLocation
            // 
            this.formTextDataLocation.Location = new System.Drawing.Point(4, 188);
            this.formTextDataLocation.Name = "formTextDataLocation";
            this.formTextDataLocation.ReadOnly = true;
            this.formTextDataLocation.Size = new System.Drawing.Size(276, 16);
            this.formTextDataLocation.TabIndex = 25;
            this.formTextDataLocation.TextChanged += new System.EventHandler(this.formTextDataLocation_TextChanged);
            // 
            // formButtonDataLocation
            // 
            this.formButtonDataLocation.BackColor = System.Drawing.Color.White;
            this.formButtonDataLocation.FlatAppearance.BorderSize = 0;
            this.formButtonDataLocation.Location = new System.Drawing.Point(4, 208);
            this.formButtonDataLocation.Name = "formButtonDataLocation";
            this.formButtonDataLocation.Size = new System.Drawing.Size(96, 20);
            this.formButtonDataLocation.TabIndex = 27;
            this.formButtonDataLocation.Text = "Select Folder";
            this.formButtonDataLocation.UseVisualStyleBackColor = false;
            this.formButtonDataLocation.Click += new System.EventHandler(this.formButtonDataLocation_Click);
            // 
            // formLabelDataLocation
            // 
            this.formLabelDataLocation.ForeColor = System.Drawing.Color.White;
            this.formLabelDataLocation.Location = new System.Drawing.Point(4, 180);
            this.formLabelDataLocation.Name = "formLabelDataLocation";
            this.formLabelDataLocation.Size = new System.Drawing.Size(264, 8);
            this.formLabelDataLocation.TabIndex = 26;
            this.formLabelDataLocation.Text = "Data Location";
            this.formLabelDataLocation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formLabelDataLocationDetail
            // 
            this.formLabelDataLocationDetail.ForeColor = System.Drawing.Color.White;
            this.formLabelDataLocationDetail.Location = new System.Drawing.Point(104, 204);
            this.formLabelDataLocationDetail.Name = "formLabelDataLocationDetail";
            this.formLabelDataLocationDetail.Size = new System.Drawing.Size(132, 24);
            this.formLabelDataLocationDetail.TabIndex = 24;
            this.formLabelDataLocationDetail.Text = "Leave blank to use directory of Launcher.";
            this.formLabelDataLocationDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formLabelVersionNum
            // 
            this.formLabelVersionNum.ForeColor = System.Drawing.Color.White;
            this.formLabelVersionNum.Location = new System.Drawing.Point(4, 140);
            this.formLabelVersionNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelVersionNum.Name = "formLabelVersionNum";
            this.formLabelVersionNum.Size = new System.Drawing.Size(96, 8);
            this.formLabelVersionNum.TabIndex = 23;
            this.formLabelVersionNum.Text = "Version Number";
            this.formLabelVersionNum.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTextVersionNum
            // 
            this.formTextVersionNum.Location = new System.Drawing.Point(4, 148);
            this.formTextVersionNum.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextVersionNum.Name = "formTextVersionNum";
            this.formTextVersionNum.Size = new System.Drawing.Size(96, 16);
            this.formTextVersionNum.TabIndex = 22;
            this.formTextVersionNum.Text = "888.888.888.888";
            this.formTextVersionNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.formTextVersionNum_KeyPress);
            // 
            // formLabelUpdateURL
            // 
            this.formLabelUpdateURL.ForeColor = System.Drawing.Color.White;
            this.formLabelUpdateURL.Location = new System.Drawing.Point(4, 104);
            this.formLabelUpdateURL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelUpdateURL.Name = "formLabelUpdateURL";
            this.formLabelUpdateURL.Size = new System.Drawing.Size(276, 8);
            this.formLabelUpdateURL.TabIndex = 23;
            this.formLabelUpdateURL.Text = "Update URL";
            this.formLabelUpdateURL.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formTextUpdateURL
            // 
            this.formTextUpdateURL.Location = new System.Drawing.Point(4, 112);
            this.formTextUpdateURL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextUpdateURL.Name = "formTextUpdateURL";
            this.formTextUpdateURL.Size = new System.Drawing.Size(276, 16);
            this.formTextUpdateURL.TabIndex = 22;
            // 
            // formCheckCustomFont
            // 
            this.formCheckCustomFont.AutoSize = true;
            this.formCheckCustomFont.ForeColor = System.Drawing.Color.White;
            this.formCheckCustomFont.Location = new System.Drawing.Point(140, 16);
            this.formCheckCustomFont.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formCheckCustomFont.Name = "formCheckCustomFont";
            this.formCheckCustomFont.Size = new System.Drawing.Size(119, 14);
            this.formCheckCustomFont.TabIndex = 21;
            this.formCheckCustomFont.Text = "Disable Custom Font";
            this.formCheckCustomFont.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formCheckCustomFont.UseVisualStyleBackColor = true;
            this.formCheckCustomFont.CheckedChanged += new System.EventHandler(this.formCheckCustomFont_CheckedChanged);
            // 
            // formTextBackground
            // 
            this.formTextBackground.BackColor = System.Drawing.Color.White;
            this.formTextBackground.ForeColor = System.Drawing.Color.Black;
            this.formTextBackground.Location = new System.Drawing.Point(4, 52);
            this.formTextBackground.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextBackground.Name = "formTextBackground";
            this.formTextBackground.ReadOnly = true;
            this.formTextBackground.Size = new System.Drawing.Size(276, 16);
            this.formTextBackground.TabIndex = 16;
            this.formTextBackground.TextChanged += new System.EventHandler(this.formTextBackground_TextChanged);
            // 
            // formButtonBackgroundClear
            // 
            this.formButtonBackgroundClear.BackColor = System.Drawing.Color.White;
            this.formButtonBackgroundClear.FlatAppearance.BorderSize = 0;
            this.formButtonBackgroundClear.Location = new System.Drawing.Point(96, 72);
            this.formButtonBackgroundClear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonBackgroundClear.Name = "formButtonBackgroundClear";
            this.formButtonBackgroundClear.Size = new System.Drawing.Size(44, 20);
            this.formButtonBackgroundClear.TabIndex = 20;
            this.formButtonBackgroundClear.Text = "Clear";
            this.formButtonBackgroundClear.UseVisualStyleBackColor = false;
            this.formButtonBackgroundClear.Click += new System.EventHandler(this.formButtonBackgroundClear_Click);
            // 
            // formButtonBackground
            // 
            this.formButtonBackground.BackColor = System.Drawing.Color.White;
            this.formButtonBackground.FlatAppearance.BorderSize = 0;
            this.formButtonBackground.Location = new System.Drawing.Point(4, 72);
            this.formButtonBackground.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonBackground.Name = "formButtonBackground";
            this.formButtonBackground.Size = new System.Drawing.Size(88, 20);
            this.formButtonBackground.TabIndex = 19;
            this.formButtonBackground.Text = "Select Image";
            this.formButtonBackground.UseVisualStyleBackColor = false;
            this.formButtonBackground.Click += new System.EventHandler(this.formButtonBackground_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(100, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Major Change . Standard Add . Minor Add . Bug Fix";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formLabelBackgroundDetail
            // 
            this.formLabelBackgroundDetail.ForeColor = System.Drawing.Color.White;
            this.formLabelBackgroundDetail.Location = new System.Drawing.Point(144, 68);
            this.formLabelBackgroundDetail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelBackgroundDetail.Name = "formLabelBackgroundDetail";
            this.formLabelBackgroundDetail.Size = new System.Drawing.Size(136, 24);
            this.formLabelBackgroundDetail.TabIndex = 17;
            this.formLabelBackgroundDetail.Text = "Max Resolution: 1022x582";
            this.formLabelBackgroundDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // formLabelBackground
            // 
            this.formLabelBackground.ForeColor = System.Drawing.Color.White;
            this.formLabelBackground.Location = new System.Drawing.Point(4, 44);
            this.formLabelBackground.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelBackground.Name = "formLabelBackground";
            this.formLabelBackground.Size = new System.Drawing.Size(276, 8);
            this.formLabelBackground.TabIndex = 18;
            this.formLabelBackground.Text = "Launcher Background";
            this.formLabelBackground.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formNumAutoLoginTime
            // 
            this.formNumAutoLoginTime.Location = new System.Drawing.Point(4, 16);
            this.formNumAutoLoginTime.Name = "formNumAutoLoginTime";
            this.formNumAutoLoginTime.Size = new System.Drawing.Size(96, 16);
            this.formNumAutoLoginTime.TabIndex = 15;
            // 
            // formLabelDetail
            // 
            this.formLabelDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.formLabelDetail.Location = new System.Drawing.Point(8, 300);
            this.formLabelDetail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelDetail.Name = "formLabelDetail";
            this.formLabelDetail.Size = new System.Drawing.Size(272, 20);
            this.formLabelDetail.TabIndex = 14;
            this.formLabelDetail.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // formLabelError
            // 
            this.formLabelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.formLabelError.Location = new System.Drawing.Point(8, 320);
            this.formLabelError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelError.Name = "formLabelError";
            this.formLabelError.Size = new System.Drawing.Size(272, 20);
            this.formLabelError.TabIndex = 14;
            this.formLabelError.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // formLabelAutoLoginTime
            // 
            this.formLabelAutoLoginTime.ForeColor = System.Drawing.Color.White;
            this.formLabelAutoLoginTime.Location = new System.Drawing.Point(4, 8);
            this.formLabelAutoLoginTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelAutoLoginTime.Name = "formLabelAutoLoginTime";
            this.formLabelAutoLoginTime.Size = new System.Drawing.Size(120, 8);
            this.formLabelAutoLoginTime.TabIndex = 14;
            this.formLabelAutoLoginTime.Text = "Auto Login Time";
            this.formLabelAutoLoginTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // atomLauncherSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(294, 498);
            this.ControlBox = false;
            this.Controls.Add(this.formButtonClose);
            this.Controls.Add(this.formLabelLauncherSettingsTitle);
            this.Controls.Add(this.formPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "atomLauncherSettings";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Launcher Settings";
            this.Load += new System.EventHandler(this.atomLauncherSettings_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formNumAutoLoginTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog formFolderDialog;
        private System.Windows.Forms.Button formButtonOK;
        private System.Windows.Forms.Button formButtonCancel;
        private System.Windows.Forms.Button formButtonDefaults;
        private System.Windows.Forms.Label formLabelLauncherSettingsTitle;
        private System.Windows.Forms.OpenFileDialog formFileDialog;
        private System.Windows.Forms.Button formButtonClose;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label formLabelAutoLoginTime;
        private System.Windows.Forms.NumericUpDown formNumAutoLoginTime;
        private System.Windows.Forms.TextBox formTextBackground;
        private System.Windows.Forms.Button formButtonBackgroundClear;
        private System.Windows.Forms.Button formButtonBackground;
        private System.Windows.Forms.Label formLabelBackgroundDetail;
        private System.Windows.Forms.Label formLabelBackground;
        private System.Windows.Forms.CheckBox formCheckCustomFont;
        private System.Windows.Forms.Label formLabelUpdateURL;
        private System.Windows.Forms.TextBox formTextUpdateURL;
        private System.Windows.Forms.Label formLabelVersionNum;
        private System.Windows.Forms.TextBox formTextVersionNum;
        private System.Windows.Forms.TextBox formTextDataLocation;
        private System.Windows.Forms.Button formButtonDataLocation;
        private System.Windows.Forms.Label formLabelDataLocation;
        private System.Windows.Forms.Label formLabelDataLocationDetail;
        private System.Windows.Forms.Label formLabelUserDataName;
        private System.Windows.Forms.TextBox formTextUserDataName;
        private System.Windows.Forms.Label formLabelAppDataName;
        private System.Windows.Forms.TextBox formTextAppDataName;
        private System.Windows.Forms.Button formButtonDeleteAllData;
        private System.Windows.Forms.Button formButtonDeleteUserData;
        private System.Windows.Forms.Label formLabelError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label formLabelDetail;

    }
}