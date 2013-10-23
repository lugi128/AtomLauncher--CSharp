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
using System.Threading;

namespace AtomLauncher
{
    public partial class atomMinecraftSettings : Form
    {

        public static string[] ramAmmount32 = { "512", "1024" };
        public static string[] ramAmmount = ramAmmount32;
        public static string typeStatus = "status";

        public atomMinecraftSettings()
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

        private void loadVer()
        {
            fadeIn();
            string gameName = atomLauncher.settingsGame;
            if (gameName == "AL_AddNewGame")
            {
                gameName = "Minecraft";
            }
            this.Invoke(new MethodInvoker(delegate { formButtonOK.Enabled = false; formButtonCancel.Enabled = false; formButtonClose.Enabled = false; formLabelVersionStatus.Text = "Version List Staus: Getting Version list... ... "; }));
            string status = atomMinecraft.getVersion(gameName);
            if (status == "Successful")
            {
                foreach (KeyValuePair<string, string[]> entry in atomMinecraft.versionList)
                {
                    if (entry.Key != "AL_LatestID")
                    {
                        this.Invoke(new MethodInvoker(delegate { formComboVersionSelect.Items.Add(entry.Key); }));
                    }
                }
                this.Invoke(new MethodInvoker(delegate { formLabelVersionStatus.Text = "Version List Staus: Loaded"; }));
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate { formLabelVersionStatus.Text = "Version List Staus: " + status; }));
            }
            this.Invoke(new MethodInvoker(delegate { formButtonOK.Enabled = true; formButtonCancel.Enabled = true; formButtonClose.Enabled = true; }));
        }

        private void fillForm(Dictionary<string, Dictionary<string, string[]>> dict, string gameName)
        {
            if (atomLauncher.settingsGame == "AL_AddNewGame")
            {
                gameName = "Minecraft";
                formTextGameName.Text = "";
            }
            else
            {
                formTextGameName.Text = gameName;
            }
            if (!formComboVersionSelect.Items.Contains(dict[gameName]["selectVer"][0]))
            {
                formComboVersionSelect.Items.Add(dict[gameName]["selectVer"][0]);
            }
            formComboVersionSelect.Text = dict[gameName]["selectVer"][0];
            formTextMinecraftLocation.Text = dict[gameName]["location"][0];
            formTextSaveLocation.Text = dict[gameName]["saveLoc"][0];
            formTextThumbnail.Text = dict[gameName]["thumbnailLoc"][0];
            formComboCPUPriority.Text = dict[gameName]["CPUPriority"][0];
            formCheckCMD.Checked = Convert.ToBoolean(dict[gameName]["displayCMD"][0]);
            formCheckOnline.Checked = Convert.ToBoolean(dict[gameName]["onlineMode"][0]);
            formCheckAutoJava.Checked = Convert.ToBoolean(dict[gameName]["autoSelect"][0]);
            formCheckUseNightly.Checked = Convert.ToBoolean(dict[gameName]["useNightly"][0]);
            formTextUsername.Text = dict[gameName]["offlineName"][0];
            if (Convert.ToBoolean(dict[gameName]["force64Bit"][0]))
            {
                formRadio64bitJava.Checked = true;
                formRadio32bitJava.Checked = false;
            }
            else
            {
                formRadio64bitJava.Checked = false;
                formRadio32bitJava.Checked = true;
            }
            if (!formCheckAutoJava.Checked)
            {
                if (formRadio32bitJava.Checked)
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
                if (typeStatus == "No64" || typeStatus == "No32or64")
                {
                    resetRamCombo(ramAmmount32);
                }
                else
                {
                    resetRamCombo(ramAmmount);
                }
            }
            if (!formCheckOnline.Checked)
            {
                formTextUsername.Enabled = true;
            }
            else
            {
                formTextUsername.Enabled = false;
            }
            formComboStartRam.Text = dict[gameName]["startRam"][0];
            formComboMaxRam.Text = dict[gameName]["maxRam"][0];
        }

        private void resetRamCombo(string[] newArray)
        {
            int x;
            int y;
            int.TryParse(formComboStartRam.Text, out y);
            int.TryParse(formComboMaxRam.Text, out x);
            formComboStartRam.Items.Clear();
            formComboMaxRam.Items.Clear();
            formComboStartRam.Items.AddRange(newArray);
            formComboMaxRam.Items.AddRange(newArray);
            if (Convert.ToInt32(newArray[newArray.Length - 1]) < y)
            {
                formComboStartRam.Text = newArray[ramAmmount32.Length - 1];
            }
            else
            {
                formComboStartRam.Text = y.ToString();
            }
            if (Convert.ToInt32(newArray[newArray.Length - 1]) < x)
            {
                formComboMaxRam.Text = newArray[newArray.Length - 1];
            }
            else
            {
                formComboMaxRam.Text = x.ToString();
            }
        }

        private void fadeIn()
        {
            while (this.Opacity != 1)
            {
                Thread.Sleep(10);
                this.Invoke(new MethodInvoker(delegate { this.Opacity += .04; }));
            }
        }
        private void fadeOutClose()
        {
            while (this.Opacity != 0)
            {
                Thread.Sleep(10);
                this.Invoke(new MethodInvoker(delegate { this.Opacity -= .04; }));
            }
            this.Invoke(new MethodInvoker(delegate { this.Close(); }));
        }
        
        private void minecraftSettings_Load(object sender, EventArgs e)
        {
            if (atomLauncher.settingsGame == "Minecraft")
            {
                formTextGameName.Enabled = false;
                formLabelGameName.Enabled = false;
                formTextAdditionalFiles.Enabled = false;
                formLabelAdditionalFiles.Enabled = false;
                formComboRunAddVersion.Enabled = false;
                formLabelRunAddVersion.Enabled = false;
            }
            ramAmmount = segmentRam();
            string mainDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            if (!File.Exists(mainDrive + @"Windows\System32\javaw.exe"))
            {
                typeStatus = "No32";
            }
            if (!File.Exists(mainDrive + @"Windows\SysWOW64\javaw.exe"))
            {
                if (typeStatus == "No32")
                {
                    typeStatus = "No32or64";
                }
                else
                {
                    typeStatus = "No64";
                }
            }
            if (atomProgram.is64Bit)
            {
                if (typeStatus == "No32")
                {
                    formLabelStatus.Text = "Note: 32bit Java Not Detected.";
                }
                else if (typeStatus == "No64")
                {
                    formLabelStatus.Text = "Note: 64bit Java Not Detected. Ram Limited.";
                }
                else if (typeStatus == "No32or64")
                {
                    formLabelStatus.Text = "WARNING!: No Java Detected.";
                }
            }
            else
            {
                if (typeStatus == "No32")
                {
                    formLabelStatus.Text = "WARNING!: No Java Detected. Running a 32bit Program.";
                }
                else
                {
                    formLabelStatus.Text = "Note: Running a 32bit Program.";
                }
            }
            fillForm(atomLauncher.gameData, atomLauncher.settingsGame);
            Thread webVer = new Thread(loadVer);
            webVer.IsBackground = true;
            webVer.Start();
        }

        private void formCheckAutoJava_CheckedChanged(object sender, EventArgs e)
        {
            if (formCheckAutoJava.Checked)
            {
                formRadio32bitJava.Enabled = false;
                formRadio64bitJava.Enabled = false;
                if (typeStatus == "No64" || typeStatus == "No32or64")
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
                formRadio32bitJava.Enabled = true;
                formRadio64bitJava.Enabled = true;
                if (formRadio32bitJava.Checked)
                {
                    resetRamCombo(ramAmmount32);
                }
                else
                {
                    resetRamCombo(ramAmmount);
                }
            }
        }

        private void formComboStartRam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x;
            int y;
            int.TryParse(formComboMaxRam.Text, out x);
            int.TryParse(formComboStartRam.Text, out y);
            if (x < y)
            {
                formComboMaxRam.Text = formComboStartRam.Text;
            }
        }

        private void formComboMaxRam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x;
            int y;
            int.TryParse(formComboMaxRam.Text, out x);
            int.TryParse(formComboStartRam.Text, out y);
            if (x < y)
            {
                formComboStartRam.Text = formComboMaxRam.Text;
            }
        }

        private void formRadio32bitJava_CheckedChanged(object sender, EventArgs e)
        {
            if (!formCheckAutoJava.Checked)
            {
                if (formRadio32bitJava.Checked)
                {
                    resetRamCombo(ramAmmount32);
                }
                else
                {
                    resetRamCombo(ramAmmount);
                }
            }
        }

        private void formButtonMinecraftLocation_Click(object sender, EventArgs e)
        {
            formFolderDialog.Description = "Select the Root Folder that minecraft is in.";
            formFolderDialog.SelectedPath = formTextMinecraftLocation.Text;
            formFolderDialog.ShowDialog();
            formTextMinecraftLocation.Text = formFolderDialog.SelectedPath;
        }

        private void formButtonSaveLocation_Click(object sender, EventArgs e)
        {
            formFolderDialog.Description = "Select the folder to save game data in.";
            formFolderDialog.SelectedPath = formTextMinecraftLocation.Text;
            formFolderDialog.ShowDialog();
            formTextSaveLocation.Text = formFolderDialog.SelectedPath;
        }

        private void formButtonDefaults_Click(object sender, EventArgs e)
        {
            string gameName = atomLauncher.settingsGame;
            if (atomLauncher.settingsGame == "AL_AddNewGame")
            {
                gameName = "Minecraft";
            }
            Dictionary<string, Dictionary<string, string[]>> tmpDict = new Dictionary<string, Dictionary<string, string[]>>();
            tmpDict = atomFileData.getGameData(atomFileData.gameDataFile, gameName, tmpDict, "Minecraft");
            fillForm(tmpDict, gameName);
        }

        private void formButtonCancel_Click(object sender, EventArgs e)
        {
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }

        private void formButtonOK_Click(object sender, EventArgs e)
        {
            if (formTextGameName.Text == "")
            {
                formLabelStatus.Text = "Please set the 'Custom Game Name'";
            }
            else if (formTextGameName.Text == "AL_AddNewGame")
            {
                formLabelStatus.Text = "Cannot use that 'Custom Game Name'";
            }
            else if (atomLauncher.settingsGame != "Minecraft" && formTextGameName.Text == "Minecraft")
            {
                formLabelStatus.Text = "Cannot use that 'Custom Game Name'";
            }
            else
            {
                if (!atomLauncher.gameData.ContainsKey(formTextGameName.Text))
                {
                    atomLauncher.gameData.Add(formTextGameName.Text, new Dictionary<string, string[]>());
                }
                if (atomLauncher.gameData.ContainsKey(atomLauncher.settingsGame))
                {
                    atomLauncher.gameData[formTextGameName.Text] = atomLauncher.gameData[atomLauncher.settingsGame];
                }
                else
                {
                    atomLauncher.gameData = atomFileData.getGameData(atomFileData.gameDataFile, formTextGameName.Text, atomLauncher.gameData, "Minecraft");
                }
                atomLauncher.gameData[formTextGameName.Text]["gameType"] = new string[] { "Minecraft" };
                atomLauncher.gameData[formTextGameName.Text]["location"] = new string[] { formTextMinecraftLocation.Text };
                atomLauncher.gameData[formTextGameName.Text]["saveLoc"] = new string[] { formTextSaveLocation.Text };
                atomLauncher.gameData[formTextGameName.Text]["thumbnailLoc"] = new string[] { formTextThumbnail.Text };
                atomLauncher.gameData[formTextGameName.Text]["startRam"] = new string[] { formComboStartRam.Text };
                atomLauncher.gameData[formTextGameName.Text]["maxRam"] = new string[] { formComboMaxRam.Text };
                atomLauncher.gameData[formTextGameName.Text]["displayCMD"] = new string[] { formCheckCMD.Checked.ToString() };
                atomLauncher.gameData[formTextGameName.Text]["CPUPriority"] = new string[] { formComboCPUPriority.Text };
                atomLauncher.gameData[formTextGameName.Text]["onlineMode"] = new string[] { formCheckOnline.Checked.ToString() };
                atomLauncher.gameData[formTextGameName.Text]["offlineName"] = new string[] { formTextUsername.Text };
                atomLauncher.gameData[formTextGameName.Text]["selectVer"] = new string[] { formComboVersionSelect.Text };
                atomLauncher.gameData[formTextGameName.Text]["autoSelect"] = new string[] { formCheckAutoJava.Checked.ToString() };
                atomLauncher.gameData[formTextGameName.Text]["useNightly"] = new string[] { formCheckUseNightly.Checked.ToString() };
                atomLauncher.gameData[formTextGameName.Text]["force64Bit"] = new string[] { formRadio64bitJava.Checked.ToString() };
                atomFileData.saveDictonary(atomFileData.gameDataFile, atomLauncher.gameData);
                if (atomLauncher.settingsGame != formTextGameName.Text)
                {
                    atomLauncher.gameData.Remove(atomLauncher.settingsGame);
                }
            }
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }

        private void formCheckOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (!formCheckOnline.Checked)
            {
                formTextUsername.Enabled = true;
            }
            else
            {
                formTextUsername.Enabled = false;
            }
        }

        private void formButtonThumbnail_Click(object sender, EventArgs e)
        {
            formFileDialog.FileName = "";
            formFileDialog.Filter = "Preferred Images|*.png|Other Images|*.bmp,*.gif,*.jpeg,*.tif,*.tiff";
            formFileDialog.InitialDirectory = formTextMinecraftLocation.Text;
            formFileDialog.ShowDialog();
            formFileDialog.Title = "Select Game Thumbnail";
            if (formFileDialog.FileName != "")
            {
                formTextThumbnail.Text = formFileDialog.FileName;
            }
        }

        private void formButtonThumbnailClear_Click(object sender, EventArgs e)
        {
            formTextThumbnail.Text = "";
        }

        private void formCheckUseNightly_CheckedChanged(object sender, EventArgs e)
        {
            string gameName = atomLauncher.settingsGame;
            if (atomLauncher.settingsGame == "AL_AddNewGame")
            {
                gameName = "Minecraft";
            }
            if (!Convert.ToBoolean(atomLauncher.gameData[gameName]["useNightly"][0]))
            {
                if (formCheckUseNightly.Checked)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure? They can provide bug fixes, but, at the same time could introduce more bugs.", "Are you sure?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        formCheckUseNightly.Checked = false;
                    }
                }
            }
        }

        private void formButtonDeleteAll_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text);
            FileInfo[] Files = d.GetFiles();
            DirectoryInfo[] Directories = d.GetDirectories();
            foreach (FileInfo file in Files)
            {
                File.Delete(file.FullName);
            }
            foreach (DirectoryInfo directory in Directories)
            {
                Directory.Delete(directory.FullName, true);
            }
        }

        private void formButtonDeleteAllButSaves_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text);
            DirectoryInfo[] Directories = d.GetDirectories("*", SearchOption.AllDirectories);
            FileInfo[] Files = d.GetFiles("*",SearchOption.AllDirectories);
            foreach (FileInfo file in Files)
            {
                if (!file.FullName.Contains("saves"))
                {
                    File.Delete(file.FullName);
                }
            }
            foreach (DirectoryInfo direct in Directories)
            {
                if (!direct.FullName.Contains("saves"))
                {
                    if (Directory.Exists(direct.FullName))
                    {
                        bool safeToDelete = true;
                        DirectoryInfo subD = new DirectoryInfo(direct.FullName);
                        DirectoryInfo[] subDirectories = subD.GetDirectories("*", SearchOption.AllDirectories);
                        foreach (DirectoryInfo subDirectory in subDirectories)
                        {
                            if (subDirectory.FullName.Contains("saves"))
                            {
                                safeToDelete = false;
                                break;
                            }
                        }
                        if (safeToDelete)
                        {
                            Directory.Delete(direct.FullName, true);
                        }
                    }
                }
            }
        }

        private void formButtonDeleteVerList_Click(object sender, EventArgs e)
        {
            File.Delete(formTextMinecraftLocation.Text + @"\versions\LatestVerList\versions.json");
        }

        private void formButtonDeleteLibraries_Click(object sender, EventArgs e)
        {
            Directory.Delete(formTextMinecraftLocation.Text + @"\libraries", true);
        }

        private void formButtonDeleteNatives_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text + @"\versions");
            DirectoryInfo[] Directories = d.GetDirectories("*-natives-AL74", SearchOption.AllDirectories);
            foreach (DirectoryInfo directory in Directories)
            {
                Directory.Delete(directory.FullName, true);
            }
        }

        private void formButtonDeleteAssets_Click(object sender, EventArgs e)
        {
            File.Delete(formTextMinecraftLocation.Text + @"\versions\LatestVerList\Minecraft.Resources.xml");
            Directory.Delete(formTextMinecraftLocation.Text + @"\assets", true);
        }

        private void formButtonDeleteSaves_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text);
            DirectoryInfo[] Directories = d.GetDirectories("saves", SearchOption.AllDirectories);
            foreach (DirectoryInfo directory in Directories)
            {
                Directory.Delete(directory.FullName, true);
            }
        }

        private void formButtonDeleteVerFiles_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text);
            FileInfo[] Files = d.GetFiles("*.json", SearchOption.AllDirectories);
            foreach (FileInfo file in Files)
            {
                File.Delete(file.FullName);
            }
        }
    }
}
