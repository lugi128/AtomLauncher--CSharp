namespace AtomLauncher
{
    partial class atomLauncher
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
            this.formLabelTitle = new System.Windows.Forms.Label();
            this.formButtonClose = new System.Windows.Forms.Button();
            this.formButtonLogin = new System.Windows.Forms.Button();
            this.formBarBottom = new System.Windows.Forms.ProgressBar();
            this.formBarTop = new System.Windows.Forms.ProgressBar();
            this.formTextPass = new System.Windows.Forms.TextBox();
            this.formLabelStatus = new System.Windows.Forms.Label();
            this.atomButtonMinimize = new System.Windows.Forms.Button();
            this.formLabelTotalMB = new System.Windows.Forms.Label();
            this.formLabelFileMB = new System.Windows.Forms.Label();
            this.formLabelDLSpeed = new System.Windows.Forms.Label();
            this.formLabelDLFile = new System.Windows.Forms.Label();
            this.formPanelBottom = new System.Windows.Forms.Panel();
            this.formComboUsername = new System.Windows.Forms.ComboBox();
            this.formCheckAutoLogin = new System.Windows.Forms.CheckBox();
            this.formCheckSaveLogin = new System.Windows.Forms.CheckBox();
            this.formPanelLeft = new System.Windows.Forms.Panel();
            this.formLabelUnderConstruct = new System.Windows.Forms.Label();
            this.formLabelNewsTitle = new System.Windows.Forms.Label();
            this.formPanelRight = new System.Windows.Forms.Panel();
            this.formLabelGameSelected = new System.Windows.Forms.Label();
            this.formButtonLauncherSettings = new System.Windows.Forms.Button();
            this.formButtonAddGame = new System.Windows.Forms.Button();
            this.formButtonUpdate = new System.Windows.Forms.Button();
            this.formButtonAbout = new System.Windows.Forms.Button();
            this.formPanelBottom.SuspendLayout();
            this.formPanelLeft.SuspendLayout();
            this.formPanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // formLabelTitle
            // 
            this.formLabelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.formLabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabelTitle.ForeColor = System.Drawing.Color.White;
            this.formLabelTitle.Location = new System.Drawing.Point(4, 4);
            this.formLabelTitle.Name = "formLabelTitle";
            this.formLabelTitle.Size = new System.Drawing.Size(100, 20);
            this.formLabelTitle.TabIndex = 1;
            this.formLabelTitle.Text = "Atom Launcher";
            this.formLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formButtonClose
            // 
            this.formButtonClose.BackColor = System.Drawing.Color.White;
            this.formButtonClose.FlatAppearance.BorderSize = 0;
            this.formButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonClose.ForeColor = System.Drawing.Color.Black;
            this.formButtonClose.Location = new System.Drawing.Point(996, 4);
            this.formButtonClose.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonClose.Name = "formButtonClose";
            this.formButtonClose.Size = new System.Drawing.Size(20, 20);
            this.formButtonClose.TabIndex = 2;
            this.formButtonClose.TabStop = false;
            this.formButtonClose.Text = "X";
            this.formButtonClose.UseVisualStyleBackColor = false;
            this.formButtonClose.Click += new System.EventHandler(this.atomButtonClose_Click);
            // 
            // formButtonLogin
            // 
            this.formButtonLogin.BackColor = System.Drawing.Color.White;
            this.formButtonLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.formButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonLogin.Location = new System.Drawing.Point(932, 16);
            this.formButtonLogin.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonLogin.Name = "formButtonLogin";
            this.formButtonLogin.Size = new System.Drawing.Size(76, 40);
            this.formButtonLogin.TabIndex = 3;
            this.formButtonLogin.Text = "Login";
            this.formButtonLogin.UseVisualStyleBackColor = false;
            this.formButtonLogin.Click += new System.EventHandler(this.formButtonLogin_Click);
            // 
            // formBarBottom
            // 
            this.formBarBottom.BackColor = System.Drawing.Color.Black;
            this.formBarBottom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.formBarBottom.Location = new System.Drawing.Point(4, 44);
            this.formBarBottom.Name = "formBarBottom";
            this.formBarBottom.Size = new System.Drawing.Size(500, 11);
            this.formBarBottom.TabIndex = 4;
            // 
            // formBarTop
            // 
            this.formBarTop.BackColor = System.Drawing.Color.Black;
            this.formBarTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.formBarTop.Location = new System.Drawing.Point(4, 28);
            this.formBarTop.Name = "formBarTop";
            this.formBarTop.Size = new System.Drawing.Size(500, 11);
            this.formBarTop.TabIndex = 5;
            // 
            // formTextPass
            // 
            this.formTextPass.BackColor = System.Drawing.Color.White;
            this.formTextPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formTextPass.Location = new System.Drawing.Point(848, 36);
            this.formTextPass.Margin = new System.Windows.Forms.Padding(0);
            this.formTextPass.Name = "formTextPass";
            this.formTextPass.Size = new System.Drawing.Size(80, 20);
            this.formTextPass.TabIndex = 2;
            this.formTextPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.formTextPass.UseSystemPasswordChar = true;
            // 
            // formLabelStatus
            // 
            this.formLabelStatus.BackColor = System.Drawing.Color.Transparent;
            this.formLabelStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formLabelStatus.ForeColor = System.Drawing.Color.White;
            this.formLabelStatus.Location = new System.Drawing.Point(4, 0);
            this.formLabelStatus.Name = "formLabelStatus";
            this.formLabelStatus.Size = new System.Drawing.Size(1004, 15);
            this.formLabelStatus.TabIndex = 7;
            this.formLabelStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // atomButtonMinimize
            // 
            this.atomButtonMinimize.BackColor = System.Drawing.Color.White;
            this.atomButtonMinimize.FlatAppearance.BorderSize = 0;
            this.atomButtonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atomButtonMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atomButtonMinimize.ForeColor = System.Drawing.Color.Black;
            this.atomButtonMinimize.Location = new System.Drawing.Point(972, 4);
            this.atomButtonMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.atomButtonMinimize.Name = "atomButtonMinimize";
            this.atomButtonMinimize.Size = new System.Drawing.Size(20, 20);
            this.atomButtonMinimize.TabIndex = 8;
            this.atomButtonMinimize.TabStop = false;
            this.atomButtonMinimize.Text = "-";
            this.atomButtonMinimize.UseVisualStyleBackColor = false;
            this.atomButtonMinimize.Click += new System.EventHandler(this.atomButtonMinimize_Click);
            // 
            // formLabelTotalMB
            // 
            this.formLabelTotalMB.BackColor = System.Drawing.Color.Transparent;
            this.formLabelTotalMB.Font = new System.Drawing.Font("Lucida Console", 7F);
            this.formLabelTotalMB.ForeColor = System.Drawing.Color.White;
            this.formLabelTotalMB.Location = new System.Drawing.Point(504, 40);
            this.formLabelTotalMB.Name = "formLabelTotalMB";
            this.formLabelTotalMB.Size = new System.Drawing.Size(200, 16);
            this.formLabelTotalMB.TabIndex = 12;
            this.formLabelTotalMB.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formLabelFileMB
            // 
            this.formLabelFileMB.BackColor = System.Drawing.Color.Transparent;
            this.formLabelFileMB.Font = new System.Drawing.Font("Lucida Console", 7F);
            this.formLabelFileMB.ForeColor = System.Drawing.Color.White;
            this.formLabelFileMB.Location = new System.Drawing.Point(504, 24);
            this.formLabelFileMB.Name = "formLabelFileMB";
            this.formLabelFileMB.Size = new System.Drawing.Size(200, 16);
            this.formLabelFileMB.TabIndex = 12;
            this.formLabelFileMB.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formLabelDLSpeed
            // 
            this.formLabelDLSpeed.BackColor = System.Drawing.Color.Transparent;
            this.formLabelDLSpeed.Font = new System.Drawing.Font("Lucida Console", 7F);
            this.formLabelDLSpeed.ForeColor = System.Drawing.Color.White;
            this.formLabelDLSpeed.Location = new System.Drawing.Point(4, 12);
            this.formLabelDLSpeed.Name = "formLabelDLSpeed";
            this.formLabelDLSpeed.Size = new System.Drawing.Size(92, 16);
            this.formLabelDLSpeed.TabIndex = 12;
            this.formLabelDLSpeed.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formLabelDLFile
            // 
            this.formLabelDLFile.BackColor = System.Drawing.Color.Transparent;
            this.formLabelDLFile.Font = new System.Drawing.Font("Lucida Console", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabelDLFile.ForeColor = System.Drawing.Color.White;
            this.formLabelDLFile.Location = new System.Drawing.Point(92, 12);
            this.formLabelDLFile.Name = "formLabelDLFile";
            this.formLabelDLFile.Size = new System.Drawing.Size(412, 16);
            this.formLabelDLFile.TabIndex = 12;
            this.formLabelDLFile.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // formPanelBottom
            // 
            this.formPanelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.formPanelBottom.Controls.Add(this.formComboUsername);
            this.formPanelBottom.Controls.Add(this.formCheckAutoLogin);
            this.formPanelBottom.Controls.Add(this.formCheckSaveLogin);
            this.formPanelBottom.Controls.Add(this.formLabelStatus);
            this.formPanelBottom.Controls.Add(this.formLabelDLSpeed);
            this.formPanelBottom.Controls.Add(this.formButtonLogin);
            this.formPanelBottom.Controls.Add(this.formBarBottom);
            this.formPanelBottom.Controls.Add(this.formBarTop);
            this.formPanelBottom.Controls.Add(this.formTextPass);
            this.formPanelBottom.Controls.Add(this.formLabelTotalMB);
            this.formPanelBottom.Controls.Add(this.formLabelDLFile);
            this.formPanelBottom.Controls.Add(this.formLabelFileMB);
            this.formPanelBottom.Location = new System.Drawing.Point(4, 516);
            this.formPanelBottom.Name = "formPanelBottom";
            this.formPanelBottom.Size = new System.Drawing.Size(1012, 60);
            this.formPanelBottom.TabIndex = 13;
            // 
            // formComboUsername
            // 
            this.formComboUsername.BackColor = System.Drawing.Color.White;
            this.formComboUsername.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.formComboUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formComboUsername.ForeColor = System.Drawing.Color.Black;
            this.formComboUsername.FormattingEnabled = true;
            this.formComboUsername.Location = new System.Drawing.Point(704, 36);
            this.formComboUsername.Name = "formComboUsername";
            this.formComboUsername.Size = new System.Drawing.Size(140, 20);
            this.formComboUsername.TabIndex = 15;
            this.formComboUsername.SelectedIndexChanged += new System.EventHandler(this.formComboUsername_SelectedIndexChanged);
            // 
            // formCheckAutoLogin
            // 
            this.formCheckAutoLogin.AutoSize = true;
            this.formCheckAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.formCheckAutoLogin.Enabled = false;
            this.formCheckAutoLogin.ForeColor = System.Drawing.Color.White;
            this.formCheckAutoLogin.Location = new System.Drawing.Point(704, 16);
            this.formCheckAutoLogin.Name = "formCheckAutoLogin";
            this.formCheckAutoLogin.Size = new System.Drawing.Size(77, 17);
            this.formCheckAutoLogin.TabIndex = 13;
            this.formCheckAutoLogin.Text = "Auto Login";
            this.formCheckAutoLogin.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.formCheckAutoLogin.UseVisualStyleBackColor = false;
            // 
            // formCheckSaveLogin
            // 
            this.formCheckSaveLogin.AutoSize = true;
            this.formCheckSaveLogin.BackColor = System.Drawing.Color.Transparent;
            this.formCheckSaveLogin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.formCheckSaveLogin.ForeColor = System.Drawing.Color.White;
            this.formCheckSaveLogin.Location = new System.Drawing.Point(848, 16);
            this.formCheckSaveLogin.Name = "formCheckSaveLogin";
            this.formCheckSaveLogin.Size = new System.Drawing.Size(80, 17);
            this.formCheckSaveLogin.TabIndex = 13;
            this.formCheckSaveLogin.Text = "Save Login";
            this.formCheckSaveLogin.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.formCheckSaveLogin.UseVisualStyleBackColor = false;
            this.formCheckSaveLogin.CheckedChanged += new System.EventHandler(this.formCheckSaveLogin_CheckedChanged);
            // 
            // formPanelLeft
            // 
            this.formPanelLeft.BackColor = System.Drawing.Color.Transparent;
            this.formPanelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.formPanelLeft.Controls.Add(this.formLabelUnderConstruct);
            this.formPanelLeft.Controls.Add(this.formLabelNewsTitle);
            this.formPanelLeft.Location = new System.Drawing.Point(4, 28);
            this.formPanelLeft.Name = "formPanelLeft";
            this.formPanelLeft.Size = new System.Drawing.Size(716, 484);
            this.formPanelLeft.TabIndex = 14;
            // 
            // formLabelUnderConstruct
            // 
            this.formLabelUnderConstruct.BackColor = System.Drawing.Color.Transparent;
            this.formLabelUnderConstruct.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabelUnderConstruct.ForeColor = System.Drawing.Color.White;
            this.formLabelUnderConstruct.Location = new System.Drawing.Point(4, 24);
            this.formLabelUnderConstruct.Name = "formLabelUnderConstruct";
            this.formLabelUnderConstruct.Size = new System.Drawing.Size(708, 64);
            this.formLabelUnderConstruct.TabIndex = 2;
            this.formLabelUnderConstruct.Text = "Under Construction";
            this.formLabelUnderConstruct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formLabelNewsTitle
            // 
            this.formLabelNewsTitle.BackColor = System.Drawing.Color.Transparent;
            this.formLabelNewsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabelNewsTitle.ForeColor = System.Drawing.Color.White;
            this.formLabelNewsTitle.Location = new System.Drawing.Point(4, 4);
            this.formLabelNewsTitle.Name = "formLabelNewsTitle";
            this.formLabelNewsTitle.Size = new System.Drawing.Size(708, 16);
            this.formLabelNewsTitle.TabIndex = 1;
            this.formLabelNewsTitle.Text = "News / Information";
            this.formLabelNewsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // formPanelRight
            // 
            this.formPanelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.formPanelRight.Controls.Add(this.formLabelGameSelected);
            this.formPanelRight.Controls.Add(this.formButtonLauncherSettings);
            this.formPanelRight.Controls.Add(this.formButtonAddGame);
            this.formPanelRight.Location = new System.Drawing.Point(724, 28);
            this.formPanelRight.Name = "formPanelRight";
            this.formPanelRight.Size = new System.Drawing.Size(292, 484);
            this.formPanelRight.TabIndex = 14;
            // 
            // formLabelGameSelected
            // 
            this.formLabelGameSelected.BackColor = System.Drawing.Color.Transparent;
            this.formLabelGameSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabelGameSelected.ForeColor = System.Drawing.Color.White;
            this.formLabelGameSelected.Location = new System.Drawing.Point(4, 4);
            this.formLabelGameSelected.Name = "formLabelGameSelected";
            this.formLabelGameSelected.Size = new System.Drawing.Size(283, 16);
            this.formLabelGameSelected.TabIndex = 1;
            this.formLabelGameSelected.Text = "Game: Loading";
            this.formLabelGameSelected.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // formButtonLauncherSettings
            // 
            this.formButtonLauncherSettings.BackColor = System.Drawing.Color.White;
            this.formButtonLauncherSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.formButtonLauncherSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonLauncherSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonLauncherSettings.ForeColor = System.Drawing.Color.Black;
            this.formButtonLauncherSettings.Location = new System.Drawing.Point(148, 24);
            this.formButtonLauncherSettings.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonLauncherSettings.Name = "formButtonLauncherSettings";
            this.formButtonLauncherSettings.Size = new System.Drawing.Size(140, 24);
            this.formButtonLauncherSettings.TabIndex = 8;
            this.formButtonLauncherSettings.TabStop = false;
            this.formButtonLauncherSettings.Text = "Launcher Settings";
            this.formButtonLauncherSettings.UseVisualStyleBackColor = false;
            this.formButtonLauncherSettings.Visible = false;
            this.formButtonLauncherSettings.Click += new System.EventHandler(this.formButtonLauncherSettings_Click);
            // 
            // formButtonAddGame
            // 
            this.formButtonAddGame.BackColor = System.Drawing.Color.White;
            this.formButtonAddGame.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.formButtonAddGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonAddGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAddGame.ForeColor = System.Drawing.Color.Black;
            this.formButtonAddGame.Location = new System.Drawing.Point(4, 24);
            this.formButtonAddGame.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonAddGame.Name = "formButtonAddGame";
            this.formButtonAddGame.Size = new System.Drawing.Size(140, 24);
            this.formButtonAddGame.TabIndex = 8;
            this.formButtonAddGame.TabStop = false;
            this.formButtonAddGame.Text = "Add Custom Game";
            this.formButtonAddGame.UseVisualStyleBackColor = false;
            this.formButtonAddGame.Click += new System.EventHandler(this.formButtonAddGame_Click);
            // 
            // formButtonUpdate
            // 
            this.formButtonUpdate.BackColor = System.Drawing.Color.Cyan;
            this.formButtonUpdate.FlatAppearance.BorderSize = 0;
            this.formButtonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonUpdate.ForeColor = System.Drawing.Color.Black;
            this.formButtonUpdate.Location = new System.Drawing.Point(936, 4);
            this.formButtonUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonUpdate.Name = "formButtonUpdate";
            this.formButtonUpdate.Size = new System.Drawing.Size(8, 8);
            this.formButtonUpdate.TabIndex = 8;
            this.formButtonUpdate.TabStop = false;
            this.formButtonUpdate.UseVisualStyleBackColor = false;
            this.formButtonUpdate.Click += new System.EventHandler(this.formButtonUpdateStatus_Click);
            // 
            // formButtonAbout
            // 
            this.formButtonAbout.BackColor = System.Drawing.Color.White;
            this.formButtonAbout.FlatAppearance.BorderSize = 0;
            this.formButtonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAbout.ForeColor = System.Drawing.Color.Black;
            this.formButtonAbout.Location = new System.Drawing.Point(948, 4);
            this.formButtonAbout.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonAbout.Name = "formButtonAbout";
            this.formButtonAbout.Size = new System.Drawing.Size(20, 20);
            this.formButtonAbout.TabIndex = 8;
            this.formButtonAbout.TabStop = false;
            this.formButtonAbout.Text = "a";
            this.formButtonAbout.UseVisualStyleBackColor = false;
            this.formButtonAbout.Click += new System.EventHandler(this.formButtonAbout_Click);
            // 
            // atomLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::AtomLauncher.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1020, 580);
            this.Controls.Add(this.formPanelRight);
            this.Controls.Add(this.formPanelLeft);
            this.Controls.Add(this.formButtonUpdate);
            this.Controls.Add(this.formPanelBottom);
            this.Controls.Add(this.formButtonAbout);
            this.Controls.Add(this.atomButtonMinimize);
            this.Controls.Add(this.formButtonClose);
            this.Controls.Add(this.formLabelTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "atomLauncher";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atom Launcher";
            this.Load += new System.EventHandler(this.atomLauncher_Load);
            this.formPanelBottom.ResumeLayout(false);
            this.formPanelBottom.PerformLayout();
            this.formPanelLeft.ResumeLayout(false);
            this.formPanelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label formLabelTitle;
        private System.Windows.Forms.Button formButtonClose;
        private System.Windows.Forms.Button formButtonLogin;
        private System.Windows.Forms.TextBox formTextPass;
        private System.Windows.Forms.Button atomButtonMinimize;
        private System.Windows.Forms.Panel formPanelBottom;
        private System.Windows.Forms.Panel formPanelLeft;
        private System.Windows.Forms.Panel formPanelRight;
        private System.Windows.Forms.Label formLabelNewsTitle;
        internal System.Windows.Forms.ProgressBar formBarBottom;
        internal System.Windows.Forms.ProgressBar formBarTop;
        internal System.Windows.Forms.Label formLabelStatus;
        internal System.Windows.Forms.Label formLabelTotalMB;
        internal System.Windows.Forms.Label formLabelFileMB;
        internal System.Windows.Forms.Label formLabelDLSpeed;
        internal System.Windows.Forms.Label formLabelDLFile;
        private System.Windows.Forms.CheckBox formCheckSaveLogin;
        private System.Windows.Forms.CheckBox formCheckAutoLogin;
        private System.Windows.Forms.Button formButtonAddGame;
        private System.Windows.Forms.ComboBox formComboUsername;
        private System.Windows.Forms.Label formLabelGameSelected;
        private System.Windows.Forms.Button formButtonUpdate;
        private System.Windows.Forms.Label formLabelUnderConstruct;
        private System.Windows.Forms.Button formButtonAbout;
        private System.Windows.Forms.Button formButtonLauncherSettings;
    }
}

