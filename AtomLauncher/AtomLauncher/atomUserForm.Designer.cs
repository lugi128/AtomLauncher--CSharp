namespace AtomLauncher
{
    partial class atomUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(atomUserForm));
            this.formFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.formButtonOK = new System.Windows.Forms.Button();
            this.formButtonCancel = new System.Windows.Forms.Button();
            this.formLabelTitle = new System.Windows.Forms.Label();
            this.formFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.formButtonDelete = new System.Windows.Forms.Button();
            this.formTextUser = new System.Windows.Forms.TextBox();
            this.formTextPass = new System.Windows.Forms.TextBox();
            this.formCheckAutoLogin = new System.Windows.Forms.CheckBox();
            this.formLabelPass = new System.Windows.Forms.Label();
            this.formLabelUser = new System.Windows.Forms.Label();
            this.formButtonClose = new System.Windows.Forms.Button();
            this.formPanel = new System.Windows.Forms.Panel();
            this.formLabelError = new System.Windows.Forms.Label();
            this.formPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // formButtonOK
            // 
            this.formButtonOK.BackColor = System.Drawing.Color.White;
            this.formButtonOK.FlatAppearance.BorderSize = 0;
            this.formButtonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonOK.Location = new System.Drawing.Point(226, 60);
            this.formButtonOK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonOK.Name = "formButtonOK";
            this.formButtonOK.Size = new System.Drawing.Size(64, 24);
            this.formButtonOK.TabIndex = 5;
            this.formButtonOK.Text = "OK";
            this.formButtonOK.UseVisualStyleBackColor = false;
            this.formButtonOK.Click += new System.EventHandler(this.formButtonOK_Click);
            // 
            // formButtonCancel
            // 
            this.formButtonCancel.BackColor = System.Drawing.Color.White;
            this.formButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.formButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonCancel.Location = new System.Drawing.Point(170, 60);
            this.formButtonCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonCancel.Name = "formButtonCancel";
            this.formButtonCancel.Size = new System.Drawing.Size(52, 24);
            this.formButtonCancel.TabIndex = 4;
            this.formButtonCancel.Text = "Cancel";
            this.formButtonCancel.UseVisualStyleBackColor = false;
            this.formButtonCancel.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // formLabelTitle
            // 
            this.formLabelTitle.BackColor = System.Drawing.Color.Transparent;
            this.formLabelTitle.Font = new System.Drawing.Font("Lucida Console", 13.5F, System.Drawing.FontStyle.Bold);
            this.formLabelTitle.ForeColor = System.Drawing.Color.White;
            this.formLabelTitle.Location = new System.Drawing.Point(4, 388);
            this.formLabelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelTitle.Name = "formLabelTitle";
            this.formLabelTitle.Size = new System.Drawing.Size(286, 20);
            this.formLabelTitle.TabIndex = 20;
            this.formLabelTitle.Text = "atom User Form";
            this.formLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formButtonDelete
            // 
            this.formButtonDelete.BackColor = System.Drawing.SystemColors.Window;
            this.formButtonDelete.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.formButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonDelete.Location = new System.Drawing.Point(4, 60);
            this.formButtonDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formButtonDelete.Name = "formButtonDelete";
            this.formButtonDelete.Size = new System.Drawing.Size(84, 24);
            this.formButtonDelete.TabIndex = 7;
            this.formButtonDelete.Text = "Delete User";
            this.formButtonDelete.UseVisualStyleBackColor = false;
            this.formButtonDelete.Click += new System.EventHandler(this.formButtonDelete_Click);
            // 
            // formTextUser
            // 
            this.formTextUser.Location = new System.Drawing.Point(4, 12);
            this.formTextUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextUser.Name = "formTextUser";
            this.formTextUser.Size = new System.Drawing.Size(138, 16);
            this.formTextUser.TabIndex = 1;
            // 
            // formTextPass
            // 
            this.formTextPass.Location = new System.Drawing.Point(152, 12);
            this.formTextPass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formTextPass.Name = "formTextPass";
            this.formTextPass.Size = new System.Drawing.Size(138, 16);
            this.formTextPass.TabIndex = 2;
            this.formTextPass.UseSystemPasswordChar = true;
            // 
            // formCheckAutoLogin
            // 
            this.formCheckAutoLogin.AutoSize = true;
            this.formCheckAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.formCheckAutoLogin.ForeColor = System.Drawing.Color.White;
            this.formCheckAutoLogin.Location = new System.Drawing.Point(4, 32);
            this.formCheckAutoLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.formCheckAutoLogin.Name = "formCheckAutoLogin";
            this.formCheckAutoLogin.Size = new System.Drawing.Size(74, 14);
            this.formCheckAutoLogin.TabIndex = 3;
            this.formCheckAutoLogin.Text = "Auto Login";
            this.formCheckAutoLogin.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.formCheckAutoLogin.UseVisualStyleBackColor = false;
            // 
            // formLabelPass
            // 
            this.formLabelPass.BackColor = System.Drawing.Color.Transparent;
            this.formLabelPass.ForeColor = System.Drawing.Color.White;
            this.formLabelPass.Location = new System.Drawing.Point(150, 4);
            this.formLabelPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelPass.Name = "formLabelPass";
            this.formLabelPass.Size = new System.Drawing.Size(140, 8);
            this.formLabelPass.TabIndex = 24;
            this.formLabelPass.Text = "Password";
            this.formLabelPass.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // formLabelUser
            // 
            this.formLabelUser.BackColor = System.Drawing.Color.Transparent;
            this.formLabelUser.ForeColor = System.Drawing.Color.White;
            this.formLabelUser.Location = new System.Drawing.Point(4, 4);
            this.formLabelUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelUser.Name = "formLabelUser";
            this.formLabelUser.Size = new System.Drawing.Size(138, 8);
            this.formLabelUser.TabIndex = 24;
            this.formLabelUser.Text = "Username";
            this.formLabelUser.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.formButtonClose.TabIndex = 25;
            this.formButtonClose.TabStop = false;
            this.formButtonClose.UseVisualStyleBackColor = false;
            this.formButtonClose.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // formPanel
            // 
            this.formPanel.Controls.Add(this.formButtonOK);
            this.formPanel.Controls.Add(this.formButtonCancel);
            this.formPanel.Controls.Add(this.formButtonDelete);
            this.formPanel.Controls.Add(this.formTextPass);
            this.formPanel.Controls.Add(this.formTextUser);
            this.formPanel.Controls.Add(this.formLabelError);
            this.formPanel.Controls.Add(this.formLabelUser);
            this.formPanel.Controls.Add(this.formCheckAutoLogin);
            this.formPanel.Controls.Add(this.formLabelPass);
            this.formPanel.Font = new System.Drawing.Font("Lucida Console", 6.75F);
            this.formPanel.Location = new System.Drawing.Point(0, 408);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(296, 88);
            this.formPanel.TabIndex = 26;
            // 
            // formLabelError
            // 
            this.formLabelError.BackColor = System.Drawing.Color.Transparent;
            this.formLabelError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.formLabelError.Location = new System.Drawing.Point(6, 48);
            this.formLabelError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.formLabelError.Name = "formLabelError";
            this.formLabelError.Size = new System.Drawing.Size(288, 12);
            this.formLabelError.TabIndex = 24;
            this.formLabelError.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // atomUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(294, 498);
            this.ControlBox = false;
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.formButtonClose);
            this.Controls.Add(this.formLabelTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "atomUserForm";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Form";
            this.Load += new System.EventHandler(this.atomUserForm_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog formFolderDialog;
        private System.Windows.Forms.Button formButtonOK;
        private System.Windows.Forms.Button formButtonCancel;
        private System.Windows.Forms.Label formLabelTitle;
        private System.Windows.Forms.OpenFileDialog formFileDialog;
        private System.Windows.Forms.Button formButtonDelete;
        private System.Windows.Forms.TextBox formTextUser;
        private System.Windows.Forms.TextBox formTextPass;
        private System.Windows.Forms.CheckBox formCheckAutoLogin;
        private System.Windows.Forms.Label formLabelPass;
        private System.Windows.Forms.Label formLabelUser;
        private System.Windows.Forms.Button formButtonClose;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label formLabelError;

    }
}