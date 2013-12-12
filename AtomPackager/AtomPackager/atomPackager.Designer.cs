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
            this.formListRepairItems = new System.Windows.Forms.ListBox();
            this.formListCriticalItems = new System.Windows.Forms.ListBox();
            this.formComboPackages = new System.Windows.Forms.ComboBox();
            this.formButtonRefresh = new System.Windows.Forms.Button();
            this.formButtonHelp = new System.Windows.Forms.Button();
            this.formButtonSave = new System.Windows.Forms.Button();
            this.formButtonLoad = new System.Windows.Forms.Button();
            this.formButtonAdd = new System.Windows.Forms.Button();
            this.formButtonRemove = new System.Windows.Forms.Button();
            this.formButtonSettings = new System.Windows.Forms.Button();
            this.formLabelRepair = new System.Windows.Forms.Label();
            this.formLabelCritical = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // formListRepairItems
            // 
            this.formListRepairItems.AllowDrop = true;
            this.formListRepairItems.FormattingEnabled = true;
            this.formListRepairItems.Location = new System.Drawing.Point(4, 20);
            this.formListRepairItems.Name = "formListRepairItems";
            this.formListRepairItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.formListRepairItems.Size = new System.Drawing.Size(276, 407);
            this.formListRepairItems.TabIndex = 0;
            // 
            // formListCriticalItems
            // 
            this.formListCriticalItems.AllowDrop = true;
            this.formListCriticalItems.FormattingEnabled = true;
            this.formListCriticalItems.Location = new System.Drawing.Point(324, 20);
            this.formListCriticalItems.Name = "formListCriticalItems";
            this.formListCriticalItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.formListCriticalItems.Size = new System.Drawing.Size(276, 407);
            this.formListCriticalItems.TabIndex = 0;
            // 
            // formComboPackages
            // 
            this.formComboPackages.FormattingEnabled = true;
            this.formComboPackages.Location = new System.Drawing.Point(68, 6);
            this.formComboPackages.Name = "formComboPackages";
            this.formComboPackages.Size = new System.Drawing.Size(152, 21);
            this.formComboPackages.TabIndex = 1;
            // 
            // formButtonRefresh
            // 
            this.formButtonRefresh.Location = new System.Drawing.Point(4, 4);
            this.formButtonRefresh.Name = "formButtonRefresh";
            this.formButtonRefresh.Size = new System.Drawing.Size(60, 24);
            this.formButtonRefresh.TabIndex = 2;
            this.formButtonRefresh.Text = "Refresh";
            this.formButtonRefresh.UseVisualStyleBackColor = true;
            this.formButtonRefresh.Click += new System.EventHandler(this.formButtonRefresh_Click);
            // 
            // formButtonHelp
            // 
            this.formButtonHelp.Enabled = false;
            this.formButtonHelp.Location = new System.Drawing.Point(496, 4);
            this.formButtonHelp.Name = "formButtonHelp";
            this.formButtonHelp.Size = new System.Drawing.Size(56, 24);
            this.formButtonHelp.TabIndex = 3;
            this.formButtonHelp.Text = "Help";
            this.formButtonHelp.UseVisualStyleBackColor = true;
            // 
            // formButtonSave
            // 
            this.formButtonSave.Location = new System.Drawing.Point(572, 488);
            this.formButtonSave.Name = "formButtonSave";
            this.formButtonSave.Size = new System.Drawing.Size(44, 24);
            this.formButtonSave.TabIndex = 4;
            this.formButtonSave.Text = "Save";
            this.formButtonSave.UseVisualStyleBackColor = true;
            this.formButtonSave.Click += new System.EventHandler(this.formButtonSave_Click);
            // 
            // formButtonLoad
            // 
            this.formButtonLoad.Location = new System.Drawing.Point(224, 4);
            this.formButtonLoad.Name = "formButtonLoad";
            this.formButtonLoad.Size = new System.Drawing.Size(52, 24);
            this.formButtonLoad.TabIndex = 2;
            this.formButtonLoad.Text = "Load";
            this.formButtonLoad.UseVisualStyleBackColor = true;
            this.formButtonLoad.Click += new System.EventHandler(this.formButtonLoad_Click);
            // 
            // formButtonAdd
            // 
            this.formButtonAdd.Location = new System.Drawing.Point(284, 20);
            this.formButtonAdd.Name = "formButtonAdd";
            this.formButtonAdd.Size = new System.Drawing.Size(36, 24);
            this.formButtonAdd.TabIndex = 2;
            this.formButtonAdd.Text = "--->";
            this.formButtonAdd.UseVisualStyleBackColor = true;
            this.formButtonAdd.Click += new System.EventHandler(this.formButtonAdd_Click);
            // 
            // formButtonRemove
            // 
            this.formButtonRemove.Location = new System.Drawing.Point(284, 60);
            this.formButtonRemove.Name = "formButtonRemove";
            this.formButtonRemove.Size = new System.Drawing.Size(36, 24);
            this.formButtonRemove.TabIndex = 2;
            this.formButtonRemove.Text = "<---";
            this.formButtonRemove.UseVisualStyleBackColor = true;
            this.formButtonRemove.Click += new System.EventHandler(this.formButtonRemove_Click);
            // 
            // formButtonSettings
            // 
            this.formButtonSettings.Enabled = false;
            this.formButtonSettings.Location = new System.Drawing.Point(560, 4);
            this.formButtonSettings.Name = "formButtonSettings";
            this.formButtonSettings.Size = new System.Drawing.Size(56, 24);
            this.formButtonSettings.TabIndex = 3;
            this.formButtonSettings.Text = "Settings";
            this.formButtonSettings.UseVisualStyleBackColor = true;
            // 
            // formLabelRepair
            // 
            this.formLabelRepair.AutoSize = true;
            this.formLabelRepair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabelRepair.Location = new System.Drawing.Point(4, 4);
            this.formLabelRepair.Name = "formLabelRepair";
            this.formLabelRepair.Size = new System.Drawing.Size(64, 13);
            this.formLabelRepair.TabIndex = 5;
            this.formLabelRepair.Text = "On Repair";
            // 
            // formLabelCritical
            // 
            this.formLabelCritical.AutoSize = true;
            this.formLabelCritical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formLabelCritical.Location = new System.Drawing.Point(324, 4);
            this.formLabelCritical.Name = "formLabelCritical";
            this.formLabelCritical.Size = new System.Drawing.Size(46, 13);
            this.formLabelCritical.TabIndex = 5;
            this.formLabelCritical.Text = "Critical";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "URL to Packages";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(284, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "http://www.website.com/pack/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type of Package";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "General",
            "Minecraft"});
            this.comboBox1.Location = new System.Drawing.Point(8, 112);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Minecraft";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(4, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(612, 456);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(604, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.formLabelRepair);
            this.tabPage2.Controls.Add(this.formButtonRemove);
            this.tabPage2.Controls.Add(this.formListRepairItems);
            this.tabPage2.Controls.Add(this.formButtonAdd);
            this.tabPage2.Controls.Add(this.formLabelCritical);
            this.tabPage2.Controls.Add(this.formListCriticalItems);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(604, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Critical Files";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.listBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(604, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Optional Files";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(4, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(284, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "http://www.website.com/APVerList";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Root URL to Packages Version List";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(604, 430);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Versions";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Optional";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(284, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 24);
            this.button2.TabIndex = 9;
            this.button2.Text = "<---";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(4, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(276, 407);
            this.listBox1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(284, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 24);
            this.button3.TabIndex = 8;
            this.button3.Text = "--->";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(324, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Required";
            // 
            // listBox2
            // 
            this.listBox2.AllowDrop = true;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(324, 20);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox2.Size = new System.Drawing.Size(276, 407);
            this.listBox2.TabIndex = 6;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(604, 430);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Required Files for Optional";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // atomPackager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 516);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.formButtonSave);
            this.Controls.Add(this.formButtonSettings);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.formButtonHelp);
            this.Controls.Add(this.formButtonLoad);
            this.Controls.Add(this.formButtonRefresh);
            this.Controls.Add(this.formComboPackages);
            this.Name = "atomPackager";
            this.Text = "atomPackager";
            this.Load += new System.EventHandler(this.atomPackager_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox formComboPackages;
        private System.Windows.Forms.Button formButtonRefresh;
        private System.Windows.Forms.Button formButtonHelp;
        private System.Windows.Forms.Button formButtonSave;
        private System.Windows.Forms.Button formButtonLoad;
        private System.Windows.Forms.ListBox formListRepairItems;
        private System.Windows.Forms.ListBox formListCriticalItems;
        private System.Windows.Forms.Button formButtonAdd;
        private System.Windows.Forms.Button formButtonRemove;
        private System.Windows.Forms.Button formButtonSettings;
        private System.Windows.Forms.Label formLabelRepair;
        private System.Windows.Forms.Label formLabelCritical;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TabPage tabPage5;

    }
}