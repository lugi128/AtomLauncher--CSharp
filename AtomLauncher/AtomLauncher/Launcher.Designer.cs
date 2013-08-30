namespace AtomLauncher
{
    partial class Launcher
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
            this.homeStartButton = new System.Windows.Forms.Button();
            this.homeAutoLogin = new System.Windows.Forms.CheckBox();
            this.homeSaveLogin = new System.Windows.Forms.CheckBox();
            this.homeBarTop = new System.Windows.Forms.ProgressBar();
            this.homePassText = new System.Windows.Forms.TextBox();
            this.homeUserTitle = new System.Windows.Forms.Label();
            this.homePassTitle = new System.Windows.Forms.Label();
            this.homeMenu = new System.Windows.Forms.MenuStrip();
            this.homeMenuMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.homeMenuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.homeMenuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.homeMenuToolsLauncherConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.homeMenuToolsGameSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.homeLabelBottom = new System.Windows.Forms.Label();
            this.homeLabelTop = new System.Windows.Forms.Label();
            this.homeBarBottom = new System.Windows.Forms.ProgressBar();
            this.homeLabelBottomBar = new System.Windows.Forms.Label();
            this.homeUserText = new System.Windows.Forms.ComboBox();
            this.homeLabelTopBar = new System.Windows.Forms.Label();
            this.homeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // homeStartButton
            // 
            this.homeStartButton.Enabled = false;
            this.homeStartButton.Location = new System.Drawing.Point(200, 72);
            this.homeStartButton.Name = "homeStartButton";
            this.homeStartButton.Size = new System.Drawing.Size(87, 31);
            this.homeStartButton.TabIndex = 0;
            this.homeStartButton.Text = "Login";
            this.homeStartButton.UseVisualStyleBackColor = true;
            this.homeStartButton.Click += new System.EventHandler(this.homeStartButton_Click);
            // 
            // homeAutoLogin
            // 
            this.homeAutoLogin.AutoSize = true;
            this.homeAutoLogin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.homeAutoLogin.Enabled = false;
            this.homeAutoLogin.Location = new System.Drawing.Point(204, 52);
            this.homeAutoLogin.Name = "homeAutoLogin";
            this.homeAutoLogin.Size = new System.Drawing.Size(83, 17);
            this.homeAutoLogin.TabIndex = 1;
            this.homeAutoLogin.Text = "Auto Login?";
            this.homeAutoLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.homeAutoLogin.UseVisualStyleBackColor = true;
            // 
            // homeSaveLogin
            // 
            this.homeSaveLogin.AutoSize = true;
            this.homeSaveLogin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.homeSaveLogin.Enabled = false;
            this.homeSaveLogin.Location = new System.Drawing.Point(200, 28);
            this.homeSaveLogin.Name = "homeSaveLogin";
            this.homeSaveLogin.Size = new System.Drawing.Size(86, 17);
            this.homeSaveLogin.TabIndex = 2;
            this.homeSaveLogin.Text = "Save Login?";
            this.homeSaveLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.homeSaveLogin.UseVisualStyleBackColor = true;
            this.homeSaveLogin.CheckedChanged += new System.EventHandler(this.homeSaveLogin_CheckedChanged);
            // 
            // homeBarTop
            // 
            this.homeBarTop.Location = new System.Drawing.Point(4, 148);
            this.homeBarTop.MarqueeAnimationSpeed = 10;
            this.homeBarTop.Name = "homeBarTop";
            this.homeBarTop.Size = new System.Drawing.Size(284, 11);
            this.homeBarTop.TabIndex = 3;
            this.homeBarTop.Tag = "";
            // 
            // homePassText
            // 
            this.homePassText.Enabled = false;
            this.homePassText.Location = new System.Drawing.Point(4, 84);
            this.homePassText.Name = "homePassText";
            this.homePassText.PasswordChar = '*';
            this.homePassText.Size = new System.Drawing.Size(192, 20);
            this.homePassText.TabIndex = 5;
            this.homePassText.UseSystemPasswordChar = true;
            // 
            // homeUserTitle
            // 
            this.homeUserTitle.AutoSize = true;
            this.homeUserTitle.Enabled = false;
            this.homeUserTitle.Location = new System.Drawing.Point(4, 28);
            this.homeUserTitle.Name = "homeUserTitle";
            this.homeUserTitle.Size = new System.Drawing.Size(55, 13);
            this.homeUserTitle.TabIndex = 6;
            this.homeUserTitle.Text = "Username";
            // 
            // homePassTitle
            // 
            this.homePassTitle.AutoSize = true;
            this.homePassTitle.Enabled = false;
            this.homePassTitle.Location = new System.Drawing.Point(4, 68);
            this.homePassTitle.Name = "homePassTitle";
            this.homePassTitle.Size = new System.Drawing.Size(53, 13);
            this.homePassTitle.TabIndex = 7;
            this.homePassTitle.Text = "Password";
            // 
            // homeMenu
            // 
            this.homeMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.homeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeMenuMenu,
            this.homeMenuGame,
            this.homeMenuTools});
            this.homeMenu.Location = new System.Drawing.Point(0, 0);
            this.homeMenu.Name = "homeMenu";
            this.homeMenu.Size = new System.Drawing.Size(293, 24);
            this.homeMenu.TabIndex = 8;
            this.homeMenu.Text = "menuStrip1";
            // 
            // homeMenuMenu
            // 
            this.homeMenuMenu.Enabled = false;
            this.homeMenuMenu.Name = "homeMenuMenu";
            this.homeMenuMenu.Size = new System.Drawing.Size(50, 20);
            this.homeMenuMenu.Text = "Menu";
            // 
            // homeMenuGame
            // 
            this.homeMenuGame.Enabled = false;
            this.homeMenuGame.Name = "homeMenuGame";
            this.homeMenuGame.Size = new System.Drawing.Size(50, 20);
            this.homeMenuGame.Text = "Game";
            // 
            // homeMenuTools
            // 
            this.homeMenuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeMenuToolsLauncherConfig,
            this.homeMenuToolsGameSettings});
            this.homeMenuTools.Enabled = false;
            this.homeMenuTools.Name = "homeMenuTools";
            this.homeMenuTools.Size = new System.Drawing.Size(48, 20);
            this.homeMenuTools.Text = "Tools";
            // 
            // homeMenuToolsLauncherConfig
            // 
            this.homeMenuToolsLauncherConfig.Enabled = false;
            this.homeMenuToolsLauncherConfig.Name = "homeMenuToolsLauncherConfig";
            this.homeMenuToolsLauncherConfig.Size = new System.Drawing.Size(162, 22);
            this.homeMenuToolsLauncherConfig.Text = "Launcher Config";
            // 
            // homeMenuToolsGameSettings
            // 
            this.homeMenuToolsGameSettings.Name = "homeMenuToolsGameSettings";
            this.homeMenuToolsGameSettings.Size = new System.Drawing.Size(162, 22);
            this.homeMenuToolsGameSettings.Text = "Game Settings";
            this.homeMenuToolsGameSettings.Click += new System.EventHandler(this.gameSettingsToolStripMenuItem_Click);
            // 
            // homeLabelBottom
            // 
            this.homeLabelBottom.Location = new System.Drawing.Point(4, 128);
            this.homeLabelBottom.Name = "homeLabelBottom";
            this.homeLabelBottom.Size = new System.Drawing.Size(284, 13);
            this.homeLabelBottom.TabIndex = 9;
            this.homeLabelBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homeLabelTop
            // 
            this.homeLabelTop.Location = new System.Drawing.Point(4, 108);
            this.homeLabelTop.Name = "homeLabelTop";
            this.homeLabelTop.Size = new System.Drawing.Size(284, 13);
            this.homeLabelTop.TabIndex = 9;
            this.homeLabelTop.Text = "^.^";
            this.homeLabelTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homeBarBottom
            // 
            this.homeBarBottom.Location = new System.Drawing.Point(4, 184);
            this.homeBarBottom.Name = "homeBarBottom";
            this.homeBarBottom.Size = new System.Drawing.Size(284, 11);
            this.homeBarBottom.TabIndex = 3;
            this.homeBarBottom.Tag = "";
            // 
            // homeLabelBottomBar
            // 
            this.homeLabelBottomBar.Location = new System.Drawing.Point(4, 200);
            this.homeLabelBottomBar.Name = "homeLabelBottomBar";
            this.homeLabelBottomBar.Size = new System.Drawing.Size(284, 13);
            this.homeLabelBottomBar.TabIndex = 9;
            this.homeLabelBottomBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homeUserText
            // 
            this.homeUserText.Enabled = false;
            this.homeUserText.FormattingEnabled = true;
            this.homeUserText.Location = new System.Drawing.Point(4, 44);
            this.homeUserText.Name = "homeUserText";
            this.homeUserText.Size = new System.Drawing.Size(192, 21);
            this.homeUserText.TabIndex = 10;
            this.homeUserText.SelectedIndexChanged += new System.EventHandler(this.homeUserText_SelectedIndexChanged);
            // 
            // homeLabelTopBar
            // 
            this.homeLabelTopBar.Location = new System.Drawing.Point(4, 164);
            this.homeLabelTopBar.Name = "homeLabelTopBar";
            this.homeLabelTopBar.Size = new System.Drawing.Size(284, 13);
            this.homeLabelTopBar.TabIndex = 9;
            this.homeLabelTopBar.Text = "Welcome!";
            this.homeLabelTopBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 221);
            this.Controls.Add(this.homeUserText);
            this.Controls.Add(this.homeLabelTop);
            this.Controls.Add(this.homeLabelTopBar);
            this.Controls.Add(this.homeLabelBottomBar);
            this.Controls.Add(this.homeLabelBottom);
            this.Controls.Add(this.homePassTitle);
            this.Controls.Add(this.homeUserTitle);
            this.Controls.Add(this.homePassText);
            this.Controls.Add(this.homeBarBottom);
            this.Controls.Add(this.homeBarTop);
            this.Controls.Add(this.homeSaveLogin);
            this.Controls.Add(this.homeAutoLogin);
            this.Controls.Add(this.homeStartButton);
            this.Controls.Add(this.homeMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.homeMenu;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atom Launcher";
            this.Load += new System.EventHandler(this.Home_Load);
            this.homeMenu.ResumeLayout(false);
            this.homeMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button homeStartButton;
        private System.Windows.Forms.TextBox homePassText;
        private System.Windows.Forms.Label homeUserTitle;
        private System.Windows.Forms.Label homePassTitle;
        private System.Windows.Forms.MenuStrip homeMenu;
        private System.Windows.Forms.ToolStripMenuItem homeMenuMenu;
        private System.Windows.Forms.ToolStripMenuItem homeMenuTools;
        private System.Windows.Forms.ToolStripMenuItem homeMenuGame;
        public System.Windows.Forms.CheckBox homeSaveLogin;
        public System.Windows.Forms.CheckBox homeAutoLogin;
        public System.Windows.Forms.ProgressBar homeBarTop;
        public System.Windows.Forms.ProgressBar homeBarBottom;
        public System.Windows.Forms.Label homeLabelBottom;
        public System.Windows.Forms.Label homeLabelTop;
        public System.Windows.Forms.Label homeLabelBottomBar;
        private System.Windows.Forms.ToolStripMenuItem homeMenuToolsLauncherConfig;
        private System.Windows.Forms.ToolStripMenuItem homeMenuToolsGameSettings;
        private System.Windows.Forms.ComboBox homeUserText;
        public System.Windows.Forms.Label homeLabelTopBar;
    }
}

