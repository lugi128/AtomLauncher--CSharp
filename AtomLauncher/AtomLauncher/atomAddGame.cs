using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AtomLauncher
{
    public partial class atomAddGame : Form
    {
        public atomAddGame()
        {
            InitializeComponent();
        }

        private void formButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formButtonAddMinecraft_Click(object sender, EventArgs e)
        {
            atomLauncher.settingsGame = "AL_AddNewGame";
            atomMinecraftSettings mcSet = new atomMinecraftSettings();
            mcSet.ShowDialog();
            mcSet.Dispose();
            this.Close();
        }
    }
}
