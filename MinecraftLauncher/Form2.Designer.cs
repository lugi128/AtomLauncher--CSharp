namespace MinecraftLauncher
{
    partial class Form2
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
            this.label2 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textSession = new System.Windows.Forms.TextBox();
            this.checkMinecraft = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Session ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username:";
            // 
            // textUsername
            // 
            this.textUsername.BackColor = System.Drawing.SystemColors.Control;
            this.textUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.Location = new System.Drawing.Point(24, 24);
            this.textUsername.Name = "textUsername";
            this.textUsername.ReadOnly = true;
            this.textUsername.Size = new System.Drawing.Size(176, 18);
            this.textUsername.TabIndex = 9;
            this.textUsername.TabStop = false;
            this.textUsername.Text = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ";
            // 
            // textSession
            // 
            this.textSession.BackColor = System.Drawing.SystemColors.Control;
            this.textSession.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSession.Location = new System.Drawing.Point(24, 64);
            this.textSession.Name = "textSession";
            this.textSession.ReadOnly = true;
            this.textSession.Size = new System.Drawing.Size(176, 18);
            this.textSession.TabIndex = 9;
            this.textSession.TabStop = false;
            this.textSession.Text = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ";
            // 
            // checkMinecraft
            // 
            this.checkMinecraft.AutoSize = true;
            this.checkMinecraft.Location = new System.Drawing.Point(16, 96);
            this.checkMinecraft.Name = "checkMinecraft";
            this.checkMinecraft.Size = new System.Drawing.Size(108, 17);
            this.checkMinecraft.TabIndex = 10;
            this.checkMinecraft.Text = "Disable Minecraft";
            this.checkMinecraft.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 121);
            this.Controls.Add(this.checkMinecraft);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textSession);
            this.Controls.Add(this.textUsername);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textSession;
        private System.Windows.Forms.CheckBox checkMinecraft;
    }
}