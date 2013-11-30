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
            formTabs.Font = atomProgram.smallCustom;
            formPanel.Font = atomProgram.smallCustom;
            formLabelMinecraftSettingsTitle.Font = atomProgram.mediuCustom;
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
            string[] dirs = { "LatestVerList" };
            if (Directory.Exists(formTextMinecraftLocation.Text + @"\versions"))
            {
                dirs = Directory.GetDirectories(formTextMinecraftLocation.Text + @"\versions");
            }
            string selectedVersion = "";
            this.Invoke(new MethodInvoker(delegate 
            {
                selectedVersion = formComboVersionSelect.Text;
                formButtonOK.Enabled = false;
                formButtonCancel.Enabled = false;
                formButtonClose.Enabled = false;
                formComboVersionSelect.Enabled = false;
                formCheckShowDev.Enabled = false;
                formCheckShowBeta.Enabled = false;
                formCheckShowAlpha.Enabled = false;
                formLabelVersionStatus.Text = "Version List Staus: Getting Version list... ... ";
                formComboVersionSelect.Items.Clear();
                formComboVersionSelect.Items.Add("Latest: Recommended");
                if (formCheckShowDev.Checked) formComboVersionSelect.Items.Add("Latest: Development"); 
            }));
            string status = atomMinecraft.getVersion(atomLauncher.settingsApp);
            if (status == "Successful")
            {
                foreach (string d in dirs)
                {
                    if (!d.EndsWith("LatestVerList"))
                    {
                        if (!formComboVersionSelect.Items.Contains(Path.GetFileName(d)) && !atomMinecraft.versionList.ContainsKey(Path.GetFileName(d)))
                        {
                            this.Invoke(new MethodInvoker(delegate { formComboVersionSelect.Items.Add(Path.GetFileName(d)); }));
                        }
                    }
                }
                foreach (KeyValuePair<string, string[]> entry in atomMinecraft.versionList)
                {
                    if (entry.Key != "AL_LatestID")
                    {
                        if (!formComboVersionSelect.Items.Contains(entry.Key))
                        {
                            if (entry.Value[2] == "release")
                            {
                                this.Invoke(new MethodInvoker(delegate { formComboVersionSelect.Items.Add(entry.Key); }));
                            }
                            else if (entry.Value[2] == "snapshot" && formCheckShowDev.Checked)
                            {
                                this.Invoke(new MethodInvoker(delegate { formComboVersionSelect.Items.Add(entry.Key); }));
                            }
                            else if (entry.Value[2] == "old_beta" && formCheckShowBeta.Checked)
                            {
                                this.Invoke(new MethodInvoker(delegate { formComboVersionSelect.Items.Add(entry.Key); }));
                            }
                            else if (entry.Value[2] == "old_alpha" && formCheckShowAlpha.Checked)
                            {
                                this.Invoke(new MethodInvoker(delegate { formComboVersionSelect.Items.Add(entry.Key); }));
                            }
                        }
                    }
                }
                this.Invoke(new MethodInvoker(delegate
                {
                    formLabelVersionStatus.Text = "Version List Staus: Loaded";
                    if (!formComboVersionSelect.Items.Contains(selectedVersion))
                    {
                        formComboVersionSelect.Items.Add(selectedVersion);
                    }
                    formComboVersionSelect.Text = selectedVersion;
                }));
            }
            else
            {
                foreach (string d in dirs)
                {
                    if (!d.EndsWith("LatestVerList"))
                    {
                        if (!formComboVersionSelect.Items.Contains(Path.GetFileName(d)))
                        {
                            this.Invoke(new MethodInvoker(delegate { formComboVersionSelect.Items.Add(Path.GetFileName(d)); }));
                        }
                    }
                }
                this.Invoke(new MethodInvoker(delegate { formLabelVersionStatus.Text = "Version List Staus: " + status; }));
            }
            atomLauncher.atomLaunch.formText("formLabelStatus", "");
            atomLauncher.atomLaunch.formText("formLabelDLFile", "");
            atomLauncher.atomLaunch.formText("formLabelDLSpeed", "");
            atomLauncher.atomLaunch.formText("formLabelFileMB", "");
            atomLauncher.atomLaunch.formText("formLabelTotalMB", "");
            atomLauncher.atomLaunch.barValues(0, 0);
            this.Invoke(new MethodInvoker(delegate
            {
                formButtonOK.Enabled = true;
                formButtonCancel.Enabled = true;
                formButtonClose.Enabled = true;
                formComboVersionSelect.Enabled = true;
                formCheckShowDev.Enabled = true;
                formCheckShowBeta.Enabled = true;
                formCheckShowAlpha.Enabled = true;
            }));
        }

        private void fillForm(Dictionary<string, Dictionary<string, string[]>> dict, string appName)
        {
            if (appName == "AL_AddNewApp")
            {
                formTextAppName.Text = "";
            }
            else
            {
                formTextAppName.Text = appName;
            }
            if (!formComboVersionSelect.Items.Contains(dict[appName]["selectVer"][0]))
            {
                formComboVersionSelect.Items.Add(dict[appName]["selectVer"][0]);
            }
            formComboVersionSelect.Text = dict[appName]["selectVer"][0];
            formTextMinecraftLocation.Text = dict[appName]["location"][0];
            formTextSaveLocation.Text = dict[appName]["saveLoc"][0];
            formTextThumbnail.Text = dict[appName]["thumbnailLoc"][0];
            formComboCPUPriority.Text = dict[appName]["CPUPriority"][0];
            formCheckCMD.Checked = Convert.ToBoolean(dict[appName]["displayCMD"][0]);
            formCheckOnline.Checked = Convert.ToBoolean(dict[appName]["onlineMode"][0]);
            formCheckAutoJava.Checked = Convert.ToBoolean(dict[appName]["autoSelect"][0]);
            formCheckShowDev.Checked = Convert.ToBoolean(dict[appName]["showDev"][0]);
            formCheckShowBeta.Checked = Convert.ToBoolean(dict[appName]["showBeta"][0]);
            formCheckShowAlpha.Checked = Convert.ToBoolean(dict[appName]["showAlpha"][0]);
            formTextUsername.Text = dict[appName]["offlineName"][0];
            if (Convert.ToBoolean(dict[appName]["force64Bit"][0]))
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
            formComboStartRam.Text = dict[appName]["startRam"][0];
            formComboMaxRam.Text = dict[appName]["maxRam"][0];
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
            this.Invoke(new MethodInvoker(delegate
            {
                int x = atomLauncher.atomLaunch.Location.X + atomLauncher.atomLaunch.Width - this.Width - 8;
                int y = atomLauncher.atomLaunch.Location.Y + 8;
                if ((x + this.Width) > Screen.GetWorkingArea(this).Width)
                {
                    x = Screen.GetWorkingArea(this).Width - this.Width;
                }
                if ((y + this.Height) > Screen.GetWorkingArea(this).Height)
                {
                    y = Screen.GetWorkingArea(this).Height - this.Height;
                }
                if (x < 0)
                {
                    x = 0;
                }
                if (y < 0)
                {
                    y = 0;
                }
                Point tmpPoint = new Point(x, y);
                this.Location = tmpPoint;
            }));
            while (this.Opacity != 1)
            {
                Thread.Sleep(10);
                this.Invoke(new MethodInvoker(delegate { this.Opacity += .04; }));
            }
        }
        private Object fadeLock = new Object();
        private void fadeOutClose()
        {
            if (Monitor.TryEnter(fadeLock)) //Lock to only one Thread at a time.
            {
                while (this.Opacity != 0)
                {
                    Thread.Sleep(10);
                    this.Invoke(new MethodInvoker(delegate { this.Opacity -= .04; }));
                }
                Monitor.Exit(fadeLock);
                this.Invoke(new MethodInvoker(delegate { this.Close(); }));
            }
        }
        
        private void atomMinecraftSettings_Load(object sender, EventArgs e)
        {
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
                    formLabelStatus.Text = "WARNING!: No Java Detected. Running a 32bit Pr6aogram.";
                }
                else
                {
                    formLabelStatus.Text = "Note: Running a 32bit Program.";
                }
            }
            if (atomLauncher.settingsApp == "AL_AddNewApp")
            {
                Dictionary<string, Dictionary<string, string[]>> tmpDict = new Dictionary<string, Dictionary<string, string[]>>();
                tmpDict = atomFileData.getAppData(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], atomLauncher.settingsApp, tmpDict, "Minecraft");
                fillForm(tmpDict, atomLauncher.settingsApp);
            }
            else
            {
                fillForm(atomLauncher.appData, atomLauncher.settingsApp);
            }
            formCheckShowDev.CheckedChanged += new EventHandler(formCheckShowVer_CheckedChanged);
            formCheckShowBeta.CheckedChanged += new EventHandler(formCheckShowVer_CheckedChanged);
            formCheckShowAlpha.CheckedChanged += new EventHandler(formCheckShowVer_CheckedChanged);
            Thread fadeI = new Thread(fadeIn);
            fadeI.IsBackground = true;
            fadeI.Start();
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
        
        private void formCheckShowVer_CheckedChanged(object sender, EventArgs e)
        {
            Thread webVer = new Thread(loadVer);
            webVer.IsBackground = true;
            webVer.Start();
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
            formFolderDialog.Dispose();
        }

        private void formButtonSaveLocation_Click(object sender, EventArgs e)
        {
            formFolderDialog.Description = "Select the folder to save app data in.";
            formFolderDialog.SelectedPath = formTextMinecraftLocation.Text;
            formFolderDialog.ShowDialog();
            formTextSaveLocation.Text = formFolderDialog.SelectedPath;
            formFolderDialog.Dispose();
        }

        private void formButtonDefaults_Click(object sender, EventArgs e)
        {
            Dictionary<string, Dictionary<string, string[]>> tmpDict = new Dictionary<string, Dictionary<string, string[]>>();
            tmpDict = atomFileData.getAppData(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], atomLauncher.settingsApp, tmpDict, "Minecraft");
            fillForm(tmpDict, atomLauncher.settingsApp);
        }

        private void formButtonCancel_Click(object sender, EventArgs e)
        {
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }

        private void formButtonOK_Click(object sender, EventArgs e)
        {
            if (formTextAppName.Text == "")
            {
                formLabelStatus.Text = "Please set the 'Custom App Name'";
            }
            else if (formTextAppName.Text == "AL_AddNewApp")
            {
                formLabelStatus.Text = "Cannot use that 'Custom App Name'";
            }
            else if (atomLauncher.settingsApp != formTextAppName.Text && atomLauncher.appData.ContainsKey(formTextAppName.Text))
            {
                formLabelStatus.Text = "That 'Custom App Name' is already in use.";
            }
            else
            {
                if (atomLauncher.appData.ContainsKey(atomLauncher.settingsApp))
                {
                    atomLauncher.appData[formTextAppName.Text] = atomLauncher.appData[atomLauncher.settingsApp];
                    if (atomLauncher.userData.ContainsKey(atomLauncher.settingsApp))
                    {
                        atomLauncher.userData[formTextAppName.Text] = atomLauncher.userData[atomLauncher.settingsApp];
                    }
                }
                else
                {
                    atomLauncher.appData.Add(formTextAppName.Text, new Dictionary<string, string[]>());
                    atomLauncher.appData = atomFileData.getAppData(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], formTextAppName.Text, atomLauncher.appData, "Minecraft");
                }
                atomLauncher.appData[formTextAppName.Text]["appType"] = new string[] { "Minecraft" };
                atomLauncher.appData[formTextAppName.Text]["location"] = new string[] { formTextMinecraftLocation.Text };
                atomLauncher.appData[formTextAppName.Text]["saveLoc"] = new string[] { formTextSaveLocation.Text };
                atomLauncher.appData[formTextAppName.Text]["thumbnailLoc"] = new string[] { formTextThumbnail.Text };
                atomLauncher.appData[formTextAppName.Text]["startRam"] = new string[] { formComboStartRam.Text };
                atomLauncher.appData[formTextAppName.Text]["maxRam"] = new string[] { formComboMaxRam.Text };
                atomLauncher.appData[formTextAppName.Text]["displayCMD"] = new string[] { formCheckCMD.Checked.ToString() };
                atomLauncher.appData[formTextAppName.Text]["CPUPriority"] = new string[] { formComboCPUPriority.Text };
                atomLauncher.appData[formTextAppName.Text]["onlineMode"] = new string[] { formCheckOnline.Checked.ToString() };
                atomLauncher.appData[formTextAppName.Text]["offlineName"] = new string[] { formTextUsername.Text };
                atomLauncher.appData[formTextAppName.Text]["selectVer"] = new string[] { formComboVersionSelect.Text };
                atomLauncher.appData[formTextAppName.Text]["autoSelect"] = new string[] { formCheckAutoJava.Checked.ToString() };
                atomLauncher.appData[formTextAppName.Text]["showDev"] = new string[] { formCheckShowDev.Checked.ToString() };
                atomLauncher.appData[formTextAppName.Text]["showBeta"] = new string[] { formCheckShowBeta.Checked.ToString() };
                atomLauncher.appData[formTextAppName.Text]["showAlpha"] = new string[] { formCheckShowAlpha.Checked.ToString() };
                atomLauncher.appData[formTextAppName.Text]["force64Bit"] = new string[] { formRadio64bitJava.Checked.ToString() };
                if (atomLauncher.settingsApp != formTextAppName.Text)
                {
                    atomLauncher.appData.Remove(atomLauncher.settingsApp);
                    atomLauncher.userData.Remove(atomLauncher.settingsApp);
                }
                atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], atomLauncher.appData);
                atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], atomLauncher.userData, true);
                Thread close = new Thread(fadeOutClose);
                close.IsBackground = true;
                close.Start();
            }
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
            formFileDialog.Title = "Select App Thumbnail";
            if (formFileDialog.FileName != "")
            {
                formTextThumbnail.Text = formFileDialog.FileName;
            }
            formFileDialog.Dispose();
        }

        private void formButtonThumbnailClear_Click(object sender, EventArgs e)
        {
            formTextThumbnail.Text = "";
        }

        private void formButtonDeleteAll_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text);
            FileInfo[] Files = d.GetFiles();
            DirectoryInfo[] Directories = d.GetDirectories();
            Thread deleteItems = new Thread(() => deleteAllMethod(Files, Directories));
            deleteItems.Start();
        }

        private void formButtonDeleteAllButSaves_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text);
            Thread deleteExItems = new Thread(() => deleteAllExMethod(d, "saves"));
            deleteExItems.Start();
        }

        private void formButtonDeleteVerList_Click(object sender, EventArgs e)
        {
            FileInfo[] Files = { new FileInfo(formTextMinecraftLocation.Text + @"\versions\LatestVerList\versions.json") };
            Thread deleteFItems = new Thread(() => deleteFilesMethod(Files));
            deleteFItems.Start();
        }

        private void formButtonDeleteLibraries_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text + @"\libraries");
            FileInfo[] Files = d.GetFiles();
            DirectoryInfo[] Directories = d.GetDirectories();
            Thread deleteLibItems = new Thread(() => deleteAllMethod(Files, Directories));
            deleteLibItems.Start();
        }

        private void formButtonDeleteNatives_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text + @"\versions");
            FileInfo[] Files = d.GetFiles("*-natives-AL74*", SearchOption.AllDirectories);
            DirectoryInfo[] Directories = d.GetDirectories("*-natives-AL74", SearchOption.AllDirectories);
            foreach (DirectoryInfo directory in Directories)
            {
                Directory.Delete(directory.FullName, true);
            }
        }

        private void formButtonDeleteAssets_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text + @"\assets");
            DirectoryInfo[] Directories = d.GetDirectories();
            Thread deleteAsItems = new Thread(() => deleteDirecMethod(Directories));
            deleteAsItems.Start();
        }

        private void formButtonDeleteSaves_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text);
            DirectoryInfo[] Directories = d.GetDirectories("saves", SearchOption.AllDirectories);
            Thread deleteSavItems = new Thread(() => deleteDirecMethod(Directories));
            deleteSavItems.Start();
        }

        private void formButtonDeleteVerFiles_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(formTextMinecraftLocation.Text);
            FileInfo[] Files = d.GetFiles("*.json", SearchOption.AllDirectories);
            Thread deleteVerItems = new Thread(() => deleteFilesMethod(Files));
            deleteVerItems.Start();
        }

        private void deleteFilesMethod(FileInfo[] Files)
        {
            this.Invoke(new MethodInvoker(delegate { Enabled = false; }));
            int x = Files.Count();
            int y = x;
            foreach (FileInfo file in Files)
            {
                this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
                atomFileData.deleteLoop(file.FullName, true);
                x--;
            }
            if (y == 0) y = 1;
            this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
            this.Invoke(new MethodInvoker(delegate { Enabled = true; }));
        }
        private void deleteDirecMethod(DirectoryInfo[] Directories)
        {
            this.Invoke(new MethodInvoker(delegate { Enabled = false; }));
            int x = Directories.Count();
            int y = x;
            foreach (DirectoryInfo directory in Directories)
            {
                this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
                atomFileData.deleteFolLoop(directory.FullName, true, true);
                x--;
            }
            if (y == 0) y = 1;
            this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
            this.Invoke(new MethodInvoker(delegate { Enabled = true; }));
        }
        private void deleteAllMethod(FileInfo[] Files, DirectoryInfo[] Directories)
        {
            this.Invoke(new MethodInvoker(delegate { Enabled = false; }));
            int x = Files.Count() + Directories.Count();
            int y = x;
            foreach (FileInfo file in Files)
            {
                this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
                atomFileData.deleteLoop(file.FullName, true);
                x--;
            }
            foreach (DirectoryInfo directory in Directories)
            {
                this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
                atomFileData.deleteFolLoop(directory.FullName, true, true);
                x--;
            }
            if (y == 0) y = 1;
            this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
            this.Invoke(new MethodInvoker(delegate { Enabled = true; }));
        }
        private void deleteAllExMethod(DirectoryInfo Directory, string excludeString)
        {
            this.Invoke(new MethodInvoker(delegate { Enabled = false; }));
            var Directories = Directory.GetDirectories("*", SearchOption.AllDirectories).Where(file => !file.FullName.Contains(excludeString));
            var Files = Directory.GetFiles("*", SearchOption.AllDirectories).Where(file => !file.FullName.Contains(excludeString));
            int x = Files.Count() + Directories.Count();
            int y = x;
            foreach (FileInfo file in Files)
            {
                this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
                atomFileData.deleteLoop(file.FullName, true);
                x--;
            }
            foreach (DirectoryInfo directory in Directories)
            {
                this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
                atomFileData.deleteFolLoop(directory.FullName, true, true);
                x--;
            }
            if (y == 0) y = 1;
            this.Invoke(new MethodInvoker(delegate { formBarDelete.Value = (y - x) * 100 / y; }));
            this.Invoke(new MethodInvoker(delegate { Enabled = true; }));
        }
    }
}
