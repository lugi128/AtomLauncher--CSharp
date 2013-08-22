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
    public partial class minecraftSettings : Form
    {
        public minecraftSettings()
        {
            InitializeComponent();
        }

        private void minecraftSettings_Load(object sender, EventArgs e)
        {
            mcTextFolder.Text = Program.config["minecraft_location"];
            mcComboStartRam.Text = Program.config["minecraft_startRam"];
            mcComboMaxRam.Text = Program.config["minecraft_maxRam"];
            mcCheckCMD.Checked = Convert.ToBoolean(Program.config["minecraft_displayCMD"]);
            mcCheckOnline.Checked = Convert.ToBoolean(Program.config["minecraft_onlineMode"]);
            mcCheckAutoJava.Checked = Convert.ToBoolean(Program.config["minecraft_autoSelect"]);
            if (Convert.ToBoolean(Program.config["minecraft_force64Bit"]))
            {
                mcRadio64bitJava.Checked = true;
            }
        }

        private void mcCheckAutoJava_CheckedChanged(object sender, EventArgs e)
        {
            if (mcCheckAutoJava.Checked)
            {
                mcRadio32bitJava.Enabled = false;
                mcRadio64bitJava.Enabled = false;
            }
            else
            {
                mcRadio32bitJava.Enabled = true;
                mcRadio64bitJava.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mcFolderDialog.Description = "Select the Root Folder that minecraft is in.";
            mcFolderDialog.SelectedPath = mcTextFolder.Text;
            mcFolderDialog.ShowDialog();
            mcTextFolder.Text = mcFolderDialog.SelectedPath;
        }

        private void mcButtonCancel_Click(object sender, EventArgs e)
        {
            //Possibly add a way to keep the dialog from makeing the main window from falling.
            //Like Launcher.Activate(); or sotmhing.
            this.Close();
        }

        private void mcButtonOK_Click(object sender, EventArgs e)
        {
            //Save Changes in Configurations Here.
            //Possibly add a way to keep the dialog from makeing the main window from falling.
            //Like Launcher.Activate(); or sotmhing.
            this.Close();
        }
    }
}
