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
            string[] ramAmmount = { "512", "1024" };
            mcComboStartRam.Items.AddRange(ramAmmount);
            mcComboMaxRam.Items.AddRange(ramAmmount);
            fillForm();
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

        private void mcComboStartRam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x;
            int y;
            int.TryParse(mcComboMaxRam.Text, out x);
            int.TryParse(mcComboStartRam.Text, out y);
            if (x < y)
            {
                mcComboMaxRam.Text = mcComboStartRam.Text;
            }
        }

        private void mcComboMaxRam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x;
            int y;
            int.TryParse(mcComboMaxRam.Text, out x);
            int.TryParse(mcComboStartRam.Text, out y);
            if (x < y)
            {
                mcComboStartRam.Text = mcComboMaxRam.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mcFolderDialog.Description = "Select the Root Folder that minecraft is in.";
            mcFolderDialog.SelectedPath = mcTextFolder.Text;
            mcFolderDialog.ShowDialog();
            mcTextFolder.Text = mcFolderDialog.SelectedPath;
        }

        private void mcButtonDefaults_Click(object sender, EventArgs e)
        {
            Program.config = atomFile.loadConfDefaults("minecraft");
            fillForm();
        }

        private void mcButtonCancel_Click(object sender, EventArgs e)
        {
            //Possibly add a way to keep the dialog from makeing the main window from falling.
            //Like Launcher.Activate(); or sotmhing.
            this.Close();
        }

        private void mcButtonOK_Click(object sender, EventArgs e)
        {
            Program.config["minecraft_location"] = mcTextFolder.Text;
            Program.config["minecraft_startRam"] = mcComboStartRam.Text;
            Program.config["minecraft_maxRam"] = mcComboMaxRam.Text;
            Program.config["minecraft_displayCMD"] = mcCheckCMD.Checked.ToString();
            Program.config["minecraft_CPUPriority"] = mcComboCPUPri.Text; // Needs a feild on the forms.
            Program.config["minecraft_onlineMode"] = mcCheckOnline.Checked.ToString();
            Program.config["minecraft_autoSelect"] = mcCheckAutoJava.Checked.ToString();
            Program.config["minecraft_force64Bit"] = mcRadio64bitJava.Checked.ToString();
            atomFile.saveConfFile(atomFile.conigFile, Program.config);
            //Possibly add a way to keep the dialog from makeing the main window from falling.
            //Like Launcher.Activate(); or sotmhing.
            this.Close();
        }

        private void fillForm()
        {
            mcTextFolder.Text = Program.config["minecraft_location"];
            mcComboStartRam.Text = Program.config["minecraft_startRam"];
            mcComboMaxRam.Text = Program.config["minecraft_maxRam"];
            mcComboCPUPri.Text = Program.config["minecraft_CPUPriority"];
            mcCheckCMD.Checked = Convert.ToBoolean(Program.config["minecraft_displayCMD"]);
            mcCheckOnline.Checked = Convert.ToBoolean(Program.config["minecraft_onlineMode"]);
            mcCheckAutoJava.Checked = Convert.ToBoolean(Program.config["minecraft_autoSelect"]);
            if (Convert.ToBoolean(Program.config["minecraft_force64Bit"]))
            {
                mcRadio64bitJava.Checked = true;
            }
        }

    }
}
