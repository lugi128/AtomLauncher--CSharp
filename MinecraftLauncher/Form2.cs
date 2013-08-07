using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinecraftLauncher
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string debugTextSession
        {
            get
            {
                return this.textSession.Text;
            }
            set
            {
                this.textSession.Text = value;
            }
        }
        public string debugTextUsername
        {
            get
            {
                return this.textUsername.Text;
            }
            set
            {
                this.textUsername.Text = value;
            }
        }

        public bool debugCheckMinecraft
        {
            get
            {
                return this.checkMinecraft.Checked;
            }
            set
            {
                this.checkMinecraft.Checked = value;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void checkMinecraft_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
