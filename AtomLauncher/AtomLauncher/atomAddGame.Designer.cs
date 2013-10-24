namespace AtomLauncher
{
    partial class atomAddGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.formButtonAddMinecraft = new System.Windows.Forms.Button();
            this.formButtonAddGeneral = new System.Windows.Forms.Button();
            this.formButtonCancel = new System.Windows.Forms.Button();
            this.formButtonAddCubeworld = new System.Windows.Forms.Button();
            this.formButtonAddTerraria = new System.Windows.Forms.Button();
            this.formButtonAddStarbound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "What type of custom launcher?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formButtonAddMinecraft
            // 
            this.formButtonAddMinecraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAddMinecraft.Location = new System.Drawing.Point(8, 40);
            this.formButtonAddMinecraft.Name = "formButtonAddMinecraft";
            this.formButtonAddMinecraft.Size = new System.Drawing.Size(72, 24);
            this.formButtonAddMinecraft.TabIndex = 4;
            this.formButtonAddMinecraft.Text = "Minecraft";
            this.formButtonAddMinecraft.UseVisualStyleBackColor = true;
            this.formButtonAddMinecraft.Click += new System.EventHandler(this.formButtonAddMinecraft_Click);
            // 
            // formButtonAddGeneral
            // 
            this.formButtonAddGeneral.Enabled = false;
            this.formButtonAddGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAddGeneral.Location = new System.Drawing.Point(104, 72);
            this.formButtonAddGeneral.Name = "formButtonAddGeneral";
            this.formButtonAddGeneral.Size = new System.Drawing.Size(64, 24);
            this.formButtonAddGeneral.TabIndex = 5;
            this.formButtonAddGeneral.Text = "General";
            this.formButtonAddGeneral.UseVisualStyleBackColor = true;
            // 
            // formButtonCancel
            // 
            this.formButtonCancel.Location = new System.Drawing.Point(176, 72);
            this.formButtonCancel.Name = "formButtonCancel";
            this.formButtonCancel.Size = new System.Drawing.Size(64, 24);
            this.formButtonCancel.TabIndex = 6;
            this.formButtonCancel.Text = "Cancel";
            this.formButtonCancel.UseVisualStyleBackColor = true;
            this.formButtonCancel.Click += new System.EventHandler(this.formButtonCancel_Click);
            // 
            // formButtonAddCubeworld
            // 
            this.formButtonAddCubeworld.Enabled = false;
            this.formButtonAddCubeworld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAddCubeworld.Location = new System.Drawing.Point(8, 72);
            this.formButtonAddCubeworld.Name = "formButtonAddCubeworld";
            this.formButtonAddCubeworld.Size = new System.Drawing.Size(88, 24);
            this.formButtonAddCubeworld.TabIndex = 5;
            this.formButtonAddCubeworld.Text = "Cube World";
            this.formButtonAddCubeworld.UseVisualStyleBackColor = true;
            // 
            // formButtonAddTerraria
            // 
            this.formButtonAddTerraria.Enabled = false;
            this.formButtonAddTerraria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAddTerraria.Location = new System.Drawing.Point(176, 40);
            this.formButtonAddTerraria.Name = "formButtonAddTerraria";
            this.formButtonAddTerraria.Size = new System.Drawing.Size(64, 24);
            this.formButtonAddTerraria.TabIndex = 5;
            this.formButtonAddTerraria.Text = "Terraria";
            this.formButtonAddTerraria.UseVisualStyleBackColor = true;
            // 
            // formButtonAddStarbound
            // 
            this.formButtonAddStarbound.Enabled = false;
            this.formButtonAddStarbound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formButtonAddStarbound.Location = new System.Drawing.Point(88, 40);
            this.formButtonAddStarbound.Name = "formButtonAddStarbound";
            this.formButtonAddStarbound.Size = new System.Drawing.Size(80, 24);
            this.formButtonAddStarbound.TabIndex = 5;
            this.formButtonAddStarbound.Text = "Starbound";
            this.formButtonAddStarbound.UseVisualStyleBackColor = true;
            // 
            // atomAddGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 106);
            this.Controls.Add(this.formButtonCancel);
            this.Controls.Add(this.formButtonAddStarbound);
            this.Controls.Add(this.formButtonAddCubeworld);
            this.Controls.Add(this.formButtonAddTerraria);
            this.Controls.Add(this.formButtonAddGeneral);
            this.Controls.Add(this.formButtonAddMinecraft);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "atomAddGame";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "atomAddGame";
            this.Load += new System.EventHandler(this.atomAddGame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button formButtonAddMinecraft;
        private System.Windows.Forms.Button formButtonAddGeneral;
        private System.Windows.Forms.Button formButtonCancel;
        private System.Windows.Forms.Button formButtonAddCubeworld;
        private System.Windows.Forms.Button formButtonAddTerraria;
        private System.Windows.Forms.Button formButtonAddStarbound;

    }
}