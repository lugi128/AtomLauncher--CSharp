namespace AtomLauncher
{
    partial class atomAddApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(atomAddApp));
            this.formLabelTitle = new System.Windows.Forms.Label();
            this.formButtonCancel = new System.Windows.Forms.Button();
            this.formButtonAddCubeworld = new System.Windows.Forms.Button();
            this.formButtonAddTerraria = new System.Windows.Forms.Button();
            this.formButtonAddStarbound = new System.Windows.Forms.Button();
            this.formPictureGeneral = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.formButtonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.formPictureGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // formLabelTitle
            // 
            this.formLabelTitle.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold);
            this.formLabelTitle.ForeColor = System.Drawing.Color.White;
            this.formLabelTitle.Location = new System.Drawing.Point(4, 24);
            this.formLabelTitle.Name = "formLabelTitle";
            this.formLabelTitle.Size = new System.Drawing.Size(286, 24);
            this.formLabelTitle.TabIndex = 3;
            this.formLabelTitle.Text = "What type of App?";
            this.formLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formButtonCancel
            // 
            this.formButtonCancel.BackColor = System.Drawing.Color.White;
            this.formButtonCancel.FlatAppearance.BorderSize = 0;
            this.formButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formButtonCancel.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold);
            this.formButtonCancel.Location = new System.Drawing.Point(188, 228);
            this.formButtonCancel.Name = "formButtonCancel";
            this.formButtonCancel.Size = new System.Drawing.Size(90, 24);
            this.formButtonCancel.TabIndex = 6;
            this.formButtonCancel.Text = "Cancel";
            this.formButtonCancel.UseVisualStyleBackColor = false;
            this.formButtonCancel.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // formButtonAddCubeworld
            // 
            this.formButtonAddCubeworld.Enabled = false;
            this.formButtonAddCubeworld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAddCubeworld.Location = new System.Drawing.Point(200, 444);
            this.formButtonAddCubeworld.Name = "formButtonAddCubeworld";
            this.formButtonAddCubeworld.Size = new System.Drawing.Size(88, 24);
            this.formButtonAddCubeworld.TabIndex = 5;
            this.formButtonAddCubeworld.Text = "Cube World";
            this.formButtonAddCubeworld.UseVisualStyleBackColor = true;
            this.formButtonAddCubeworld.Visible = false;
            // 
            // formButtonAddTerraria
            // 
            this.formButtonAddTerraria.Enabled = false;
            this.formButtonAddTerraria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAddTerraria.Location = new System.Drawing.Point(200, 420);
            this.formButtonAddTerraria.Name = "formButtonAddTerraria";
            this.formButtonAddTerraria.Size = new System.Drawing.Size(88, 24);
            this.formButtonAddTerraria.TabIndex = 5;
            this.formButtonAddTerraria.Text = "Terraria";
            this.formButtonAddTerraria.UseVisualStyleBackColor = true;
            this.formButtonAddTerraria.Visible = false;
            // 
            // formButtonAddStarbound
            // 
            this.formButtonAddStarbound.Enabled = false;
            this.formButtonAddStarbound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAddStarbound.Location = new System.Drawing.Point(200, 468);
            this.formButtonAddStarbound.Name = "formButtonAddStarbound";
            this.formButtonAddStarbound.Size = new System.Drawing.Size(88, 24);
            this.formButtonAddStarbound.TabIndex = 5;
            this.formButtonAddStarbound.Text = "Starbound";
            this.formButtonAddStarbound.UseVisualStyleBackColor = true;
            this.formButtonAddStarbound.Visible = false;
            // 
            // formPictureGeneral
            // 
            this.formPictureGeneral.BackColor = System.Drawing.Color.Black;
            this.formPictureGeneral.Image = global::AtomLauncher.Properties.Resources.gen;
            this.formPictureGeneral.Location = new System.Drawing.Point(16, 52);
            this.formPictureGeneral.Name = "formPictureGeneral";
            this.formPictureGeneral.Size = new System.Drawing.Size(262, 80);
            this.formPictureGeneral.TabIndex = 7;
            this.formPictureGeneral.TabStop = false;
            this.formPictureGeneral.Click += new System.EventHandler(this.formPictureGeneral_Click);
            this.formPictureGeneral.MouseEnter += new System.EventHandler(this.formPicture_MouseEnter);
            this.formPictureGeneral.MouseLeave += new System.EventHandler(this.formPicture_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = global::AtomLauncher.Properties.Resources.mc;
            this.pictureBox2.Location = new System.Drawing.Point(16, 140);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(262, 80);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.formPictureMinecraft_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.formPicture_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.formPicture_MouseLeave);
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
            this.formButtonClose.TabIndex = 9;
            this.formButtonClose.TabStop = false;
            this.formButtonClose.UseVisualStyleBackColor = false;
            this.formButtonClose.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // atomAddApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(294, 498);
            this.Controls.Add(this.formButtonClose);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.formPictureGeneral);
            this.Controls.Add(this.formButtonCancel);
            this.Controls.Add(this.formButtonAddStarbound);
            this.Controls.Add(this.formButtonAddCubeworld);
            this.Controls.Add(this.formButtonAddTerraria);
            this.Controls.Add(this.formLabelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "atomAddApp";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add App";
            this.Load += new System.EventHandler(this.atomAddApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.formPictureGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label formLabelTitle;
        private System.Windows.Forms.Button formButtonCancel;
        private System.Windows.Forms.Button formButtonAddCubeworld;
        private System.Windows.Forms.Button formButtonAddTerraria;
        private System.Windows.Forms.Button formButtonAddStarbound;
        private System.Windows.Forms.PictureBox formPictureGeneral;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button formButtonClose;

    }
}