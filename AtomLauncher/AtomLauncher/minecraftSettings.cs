using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Management;

namespace AtomLauncher
{
    public partial class minecraftSettings : Form
    {

        public static string[] ramAmmount32 = { "512", "1024" };
        public static string[] ramAmmount = ramAmmount32;
        public static string mcSetStatus = "status";

        public minecraftSettings()
        {
            InitializeComponent();
        }

        private Int32 returnTotalRam()
        {
            UInt32 SizeinMB = 0;
            string Query = "SELECT MaxCapacity FROM Win32_PhysicalMemoryArray";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);
            foreach (ManagementObject WniPART in searcher.Get())
            {
                SizeinMB = Convert.ToUInt32(WniPART.Properties["MaxCapacity"].Value) / 1024;
                return Convert.ToInt32(SizeinMB);
            }
            return Convert.ToInt32(SizeinMB);
        }

        private string[] segmentRam()
        {
            string[] newArray = { "" };
            int ramCel = returnTotalRam() / 512;
            Array.Resize(ref newArray, ramCel);
            for (int i = 0; i < ramCel; i++)
            {
                newArray[i] = ((i + 1) * 512).ToString();
            }
            return newArray;
        }

        private void minecraftSettings_Load(object sender, EventArgs e)
        {
            ramAmmount = segmentRam();
            string mainDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            if (!File.Exists(mainDrive + @"Windows\System32\javaw.exe"))
            {
                mcSetStatus = "No32";
            }
            if (File.Exists(mainDrive + @"Windows\SysWOW64\javaw.exe"))
            {
                if (mcSetStatus == "No32")
                {
                    mcLabelStatus.Text = "Note: 32bit Java Not Detected.";
                }
            }
            else
            {
                if (mcSetStatus == "No32")
                {
                    mcLabelStatus.Text = "WARNING!: No Java Detected.";
                    if (Program.is64Bit)
                    {
                        mcSetStatus = "No32or64";
                    }
                }
                else if (Program.is64Bit)
                {
                    mcLabelStatus.Text = "Note: 64bit Java Not Detected.";
                    mcSetStatus = "No64";
                }
            }
            fillForm();
        }

        private void mcCheckAutoJava_CheckedChanged(object sender, EventArgs e)
        {
            if (mcCheckAutoJava.Checked)
            {
                mcRadio32bitJava.Enabled = false;
                mcRadio64bitJava.Enabled = false;
                if (mcSetStatus == "No64")
                {
                    resetRamCombo(ramAmmount32);
                }
                else
                {
                    resetRamCombo(ramAmmount);
                }
            }
            else
            {
                mcRadio32bitJava.Enabled = true;
                mcRadio64bitJava.Enabled = true;
                if (mcRadio32bitJava.Checked)
                {
                    resetRamCombo(ramAmmount32);
                }
                else
                {
                    resetRamCombo(ramAmmount);
                }
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

        private void resetRamCombo(string[] newArray)
        {
            int x;
            int y;
            int.TryParse(mcComboStartRam.Text, out y);
            int.TryParse(mcComboMaxRam.Text, out x);
            mcComboStartRam.Items.Clear();
            mcComboMaxRam.Items.Clear();
            mcComboStartRam.Items.AddRange(newArray);
            mcComboMaxRam.Items.AddRange(newArray);
            if (Convert.ToInt32(newArray[newArray.Length - 1]) < y)
            {
                mcComboStartRam.Text = newArray[ramAmmount32.Length - 1];
            }
            else
            {
                mcComboStartRam.Text = y.ToString();
            }
            if (Convert.ToInt32(newArray[newArray.Length - 1]) < x)
            {
                mcComboMaxRam.Text = newArray[newArray.Length - 1];
            }
            else
            {
                mcComboMaxRam.Text = x.ToString();
            }
        }

        private void mcRadio32bitJava_CheckedChanged(object sender, EventArgs e)
        {
            if (!mcCheckAutoJava.Checked)
            {
                if (mcRadio32bitJava.Checked)
                {
                    resetRamCombo(ramAmmount32);
                }
                else
                {
                    resetRamCombo(ramAmmount);
                }
            }
        }

        private void mcButtonFolder_Click(object sender, EventArgs e)
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
            Program.config["minecraft_CPUPriority"] = mcComboCPUPri.Text;
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
            mcComboCPUPri.Text = Program.config["minecraft_CPUPriority"];
            mcCheckCMD.Checked = Convert.ToBoolean(Program.config["minecraft_displayCMD"]);
            mcCheckOnline.Checked = Convert.ToBoolean(Program.config["minecraft_onlineMode"]);
            mcCheckAutoJava.Checked = Convert.ToBoolean(Program.config["minecraft_autoSelect"]);
            if (Convert.ToBoolean(Program.config["minecraft_force64Bit"]))
            {
                mcRadio64bitJava.Checked = true;
                mcRadio32bitJava.Checked = false;
            }
            else
            {
                mcRadio64bitJava.Checked = false;
                mcRadio32bitJava.Checked = true;
            }
            if (!mcCheckAutoJava.Checked)
            {
                if (mcRadio32bitJava.Checked)
                {
                    resetRamCombo(ramAmmount32);
                }
                else
                {
                    resetRamCombo(ramAmmount);
                }
            }
            else
            {
                if (mcSetStatus == "No64")
                {
                    resetRamCombo(ramAmmount32);
                }
                else
                {
                    resetRamCombo(ramAmmount);
                }
            }
            mcComboStartRam.Text = Program.config["minecraft_startRam"];
            mcComboMaxRam.Text = Program.config["minecraft_maxRam"];
        }

        private void mcCheckOnline_CheckedChanged(object sender, EventArgs e)
        {
            //username field enable and stuff.
        }
    }
}
