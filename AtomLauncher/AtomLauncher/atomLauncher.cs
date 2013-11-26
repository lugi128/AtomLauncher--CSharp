using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AtomLauncher
{
    public partial class atomLauncher : Form
    {
        // Commented Areas that start with //Dev// are under construction or future features.

        public static string fileChangeVersion = "2.0.0.0"; // Last version of which the code for the saved data was changed.
        public static bool cancelPressed = false;
        public static Dictionary<string, Dictionary<string, string[]>> appData = new Dictionary<string, Dictionary<string, string[]>>();
        public static Dictionary<string, Dictionary<string, string[]>> userData = new Dictionary<string, Dictionary<string, string[]>>();
        public static atomLauncher atomLaunch;
        public static Color selectColor = Color.FromArgb(255, 255, 255);
        public static Color noColor = Color.FromArgb(100, 0, 0, 0);
        public static string downloadVersion = "";
        public static string versionChangeLog = "";
        public static string launcherDownload = "";
        public static string settingsApp = "";
        public static string updateStatus = "Starting Update...";

        public atomLauncher()
        {
            InitializeComponent();
            atomLaunch = this;
        }

        private void atomLauncher_Load(object sender, EventArgs e)
        {
            Thread loadF = new Thread(loadingThread);
            loadF.IsBackground = true;
            loadF.Start();
        }

        private void formButtonLogin_Click(object sender, EventArgs e)
        {
            if (formButtonLogin.Tag.ToString() == "Cancel")
            {
                cancelPressed = true;
                formButtonLogin.Enabled = false;
                formButtonLogin.BackgroundImage = global::AtomLauncher.Properties.Resources.canceling;
                formButtonLogin.Tag = "Canceling";
            }
            else
            {
                cancelPressed = false;
                formSetControl(false, true);
                Thread webt = new Thread(launchApp);
                webt.IsBackground = true;
                webt.Start();
            }
        }

        private void formPicture_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            if (pic.BackColor == noColor)
            {
                atomFileData.config["lastSelectedApp"] = pic.Name.Replace("formPicture", "");
                foreach (Control x in this.formPanelRight.Controls)
                {
                    if (x.Name.EndsWith(atomFileData.config["lastSelectedApp"]))
                    {
                        x.BackColor = selectColor;
                    }
                    else
                    {
                        x.BackColor = noColor;
                    }
                }
                formLabelAppSelected.Text = atomFileData.config["lastSelectedApp"];
                setInputBox();
            }
        }

        private void formButtonEditUser_Click(object sender, EventArgs e)
        {
            cancelPressed = false;
            atomUserForm editU = new atomUserForm();
            editU.editUser = true;
            editU.ShowDialog();
            setInputBox();
        }

        private void formButtonAddUser_Click(object sender, EventArgs e)
        {
            cancelPressed = false;
            atomUserForm addU = new atomUserForm();
            addU.ShowDialog();
            setInputBox();
        }

        private void atomButtonSettings_Click(object sender, EventArgs e)
        {
            cancelPressed = false;
            Button button = (Button)sender;
            settingsApp = button.Name.Replace("atomButtonSettings", "");
            string selectedType = appData[settingsApp]["appType"][0];
            if (selectedType == "Minecraft")
            {
                atomMinecraftSettings mcSet = new atomMinecraftSettings();
                mcSet.ShowDialog();
            }
            else if (selectedType == "General")
            {
                atomGeneralSettings genSet = new atomGeneralSettings();
                genSet.ShowDialog();
            }
            else
            {
                formLabelStatus.Text = "Error: App Type Missing.";
            }
            setRightPanel();
        }
        private void atomButtonSettings_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = global::AtomLauncher.Properties.Resources.setting;
        }
        private void atomButtonSettings_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = global::AtomLauncher.Properties.Resources.settingopen;
        }

        private void atomButtonTrash_Click(object sender, EventArgs e)
        {
            //Dev//
            //
            // Do you want to delete related files? If so Which ones?
            // Or, popup saying "Are you sure? This wont delete the files"
            // 
            cancelPressed = false;
            Button button = (Button)sender;
            string trashApp = button.Name.Replace("atomButtonTrash", "");
            appData.Remove(trashApp);
            userData.Remove(trashApp);
            atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], userData, true);
            atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], appData);
            setRightPanel();
            setInputBox();
            atomFileData.saveConfFile(atomFileData.configFile, atomFileData.config);
        }
        private void atomButtonTrash_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = global::AtomLauncher.Properties.Resources.trash;
        }
        private void atomButtonTrash_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundImage = global::AtomLauncher.Properties.Resources.trashopen;
        }

        private void formButtonAddApp_Click(object sender, EventArgs e)
        {
            cancelPressed = false;
            atomAddApp addA = new atomAddApp();
            addA.ShowDialog();
            setRightPanel();
            setInputBox();
        }

        private void formButtonUpdate_Click(object sender, EventArgs e)
        {
            //Dev//
            // Should Create a form for this. For better control.
            DialogResult updateDialog = MessageBox.Show("Do you wish to update from " + atomFileData.config["launcherVersion"] + " to " + downloadVersion + "?", "Update?", MessageBoxButtons.YesNo);
            if (updateDialog == DialogResult.Yes)
            {
                DialogResult changelog = MessageBox.Show("Do you want to read the change log for " + atomFileData.config["launcherVersion"] + " to " + downloadVersion + "?", "Changelog?", MessageBoxButtons.YesNo);
                if (changelog == DialogResult.Yes)
                {
                    Process.Start(versionChangeLog);
                }
                cancelPressed = false;
                Thread updateF = new Thread(updateThread);
                updateF.IsBackground = true;
                updateF.Start();
            }
        }

        private void formButtonUpdateStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Status: " + updateStatus + "\n" + "Current Version: " + atomFileData.config["launcherVersion"] + "\n" + "Latest Version: " + downloadVersion, "Update Status");
        }

        private void formButtonAbout_Click(object sender, EventArgs e)
        {
            atomAboutBox box = new atomAboutBox();
            box.ShowDialog();
        }

        private void formButtonLauncherSettings_Click(object sender, EventArgs e)
        {
            cancelPressed = false;
            atomLauncherSettings addLS = new atomLauncherSettings();
            addLS.ShowDialog();
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        // 
        // Methods used by above 
        // 

        private void updateThread()
        {
            string status = "";
            this.Invoke(new MethodInvoker(delegate { formSetControl(false, true); }));
            try
            {
                atomDownloading.Single(launcherDownload, Path.GetDirectoryName(atomProgram.appDirectoryFile) + @"\Update" + Path.GetFileName(atomProgram.appDirectoryFile));
            }
            catch (Exception ex)
            {
                if (cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Update Download: " + ex.Message;
                }
            }
            if (status == "")
            {
                Process.Start(Path.GetDirectoryName(atomProgram.appDirectoryFile) + @"\Update" + Path.GetFileName(atomProgram.appDirectoryFile));
                fadeOutClose();
            }
            else
            {
                MessageBox.Show(status, "Update Download Error");
                this.Invoke(new MethodInvoker(delegate { formSetControl(true, true); }));
            }
        }

        private void versionThread()
        {
            if (File.Exists("Update" + Path.GetFileName(atomProgram.appDirectoryFile)))
            {
                Dictionary<string, string> dict = atomFileData.loadConfDefaults();
                atomFileData.config["launcherVersion"] = dict["launcherVersion"];
                atomFileData.saveConfFile(atomFileData.configFile, atomFileData.config);
                string status = atomFileData.deleteLoop("Update" + Path.GetFileName(atomProgram.appDirectoryFile));
                if (status != "")
                {
                    MessageBox.Show("Update Error: Deleting Update File: " + status, "Update File");
                }
            }
            if (atomFileData.config["updateURL"] != "")
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    updateStatus = "Checking version...";
                    formButtonUpdate.BackColor = Color.FromArgb(255, 255, 0);
                }));
                string status = "";
                try
                {
                    string ALUpdateData = "";
                    using (WebClient client = new WebClient())
                    {
                        ALUpdateData = client.DownloadString(atomFileData.config["updateURL"]);
                    }
                    string[] ALUpdateStrings = ALUpdateData.Split(new string[] { ":::" }, StringSplitOptions.None);
                    downloadVersion = ALUpdateStrings[0];
                    launcherDownload = ALUpdateStrings[1];
                    versionChangeLog = ALUpdateStrings[2];
                }
                catch (Exception ex)
                {
                    status = "Error: " + ex.Message;
                }
                if (status == "")
                {
                    if (atomUtility.compareVersions(atomFileData.config["launcherVersion"], downloadVersion))
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            formButtonUpdate.BackColor = System.Drawing.Color.White;
                            formButtonUpdate.Location = new System.Drawing.Point(880, 8);
                            formButtonUpdate.Size = new System.Drawing.Size(74, 14);
                            formButtonUpdate.BackgroundImage = global::AtomLauncher.Properties.Resources.update;
                            formButtonUpdate.Click -= new System.EventHandler(this.formButtonUpdateStatus_Click);
                            formButtonUpdate.Click += new System.EventHandler(this.formButtonUpdate_Click);
                        }));
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            formButtonUpdate.BackColor = Color.FromArgb(0, 255, 0);
                            updateStatus = "Up to date.";
                        }));
                    }
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        formButtonUpdate.BackColor = Color.FromArgb(255, 0, 0);
                        updateStatus = status;
                    }));
                }
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    formButtonUpdate.Enabled = false;
                    formButtonUpdate.Visible = false;
                }));
            }
        }

        private void loadingThread()
        {
            if (Path.GetFileName(atomProgram.appDirectoryFile).StartsWith("Update"))
            {
                string status = atomFileData.deleteLoop(Path.GetFileName(atomProgram.appDirectoryFile).Replace("Update", ""));
                if (status == "")
                {
                    File.Copy(Path.GetFileName(atomProgram.appDirectoryFile), Path.GetFileName(atomProgram.appDirectoryFile).Replace("Update", ""));
                    Process.Start(Path.GetFileName(atomProgram.appDirectoryFile).Replace("Update", ""));
                }
                else
                {
                    MessageBox.Show("Update Failed: " + status, "Update Status");
                }
                this.Invoke(new MethodInvoker(delegate
                {
                    this.Close();
                }));
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    formSetControl(false, true);
                    formBarTop.Width = 0;
                    formBarBottom.Width = 0;
                    formLabelTotalMB.Text = "";
                    formLabelDLFile.Text = "";
                    formLabelDLSpeed.Text = "";
                    formLabelFileMB.Text = "";
                    formLabelStatus.Text = "";
                }));
                atomFileData.config = atomFileData.loadConfFile(atomFileData.configFile);
                if (atomUtility.compareVersions(atomFileData.config["launcherVersion"], fileChangeVersion))
                {
                    //Dev// Fix Admin rights.
                    string status = atomFileData.deleteLoop(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"]);
                    status = status + atomFileData.deleteLoop(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"]);
                    status = status + atomFileData.deleteLoop(atomFileData.configFile);
                    if (status != "")
                    {
                        MessageBox.Show("File Error: Deleting File Data: " + status, "Data File");
                    }
                    MessageBox.Show("Update Notification: Updates to the opening and saveing of files have changed. The files saved to the computer have been deleted. Sorry for the inconvience.", "Update Notification");
                }
                if (!Convert.ToBoolean(atomFileData.config["changeFont"]))
                {
                    atomProgram.customFontFamily = atomCustomFont.loadFont();
                    atomProgram.smallCustom = new System.Drawing.Font(atomProgram.customFontFamily, 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    atomProgram.mediuCustom = new System.Drawing.Font(atomProgram.customFontFamily, 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        formPanelBottom.Font = atomProgram.smallCustom;
                        formPanelInputs.Font = atomProgram.mediuCustom;
                        formPanelTop.Font = atomProgram.mediuCustom;
                        formLabelAppSelected.Font = atomProgram.mediuCustom;
                    }));
                }
                appData = atomFileData.getAppData(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"]);
                userData = atomFileData.getUserData(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"]);
                foreach (KeyValuePair<string, Dictionary<string, string[]>> entry in userData)
                {
                    bool toBreak = false;
                    foreach (KeyValuePair<string, string[]> subEntry in entry.Value)
                    {
                        otherCipher.Decrypt(subEntry.Value[0], otherCipher.machineIDLookup()); //Test Decryption for errors.
                        toBreak = true;
                        break;
                    }
                    if (toBreak)
                    {
                        break;
                    }
                }
                if (atomFileData.config["launcherBackground"] != "")
                {
                    if (File.Exists(atomFileData.config["launcherBackground"]))
                    {
                        BackgroundImage = Image.FromFile(atomFileData.config["launcherBackground"]);
                    }
                    else
                    {
                        atomFileData.config["launcherBackground"] = "";
                    }
                }
                setRightPanel();
                Thread versionF = new Thread(versionThread);
                versionF.IsBackground = true;
                versionF.Start();
                this.Invoke(new MethodInvoker(delegate { formSetControl(false, true); setInputBox(); this.Opacity += .01; }));
                Thread.Sleep(1000);
                while (this.Opacity != 1)
                {
                    Thread.Sleep(10);
                    this.Invoke(new MethodInvoker(delegate { this.Opacity += .04; }));
                }
                if (appData.ContainsKey(atomFileData.config["lastSelectedApp"]))
                {
                    if (appData[atomFileData.config["lastSelectedApp"]]["autoLoginUser"][0] != "" && userData.ContainsKey(atomFileData.config["lastSelectedApp"]) && userData[atomFileData.config["lastSelectedApp"]].ContainsKey(appData[atomFileData.config["lastSelectedApp"]]["autoLoginUser"][0]))
                    {
                        autoLogin();
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate
                        {
                            formSetControl(true, true);
                        }));
                    }
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        formSetControl(true, true);
                    }));
                }
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

        internal void setRightPanel()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                formPanelRight.Visible = false;
                formPanelRight.Controls.Clear();
            }));
            int x = 0;
            foreach (KeyValuePair<string, Dictionary<string, string[]>> entry in appData)
            {
                PictureBox picture = new PictureBox();
                picture.BackColor = noColor;
                if (appData[entry.Key]["appType"][0] == "Minecraft")
                {
                    picture.BackgroundImage = global::AtomLauncher.Properties.Resources.mc;
                }
                else
                {
                    picture.BackgroundImage = global::AtomLauncher.Properties.Resources.gen;
                }
                if (appData[entry.Key]["thumbnailLoc"][0] != "")
                {
                    picture.BackgroundImage = Image.FromFile(appData[entry.Key]["thumbnailLoc"][0]);
                }
                picture.Location = new Point(4, 4 + (84 * x));
                picture.Name = "formPicture" + entry.Key;
                picture.Size = new Size(260, 80);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BackgroundImageLayout = ImageLayout.Zoom;
                picture.TabIndex = 0;
                picture.TabStop = false;
                picture.Click += new EventHandler(this.formPicture_Click);
                this.Invoke(new MethodInvoker(delegate { formPanelRight.Controls.Add(picture); }));

                Button setting = new Button();
                setting.BackColor = noColor;
                setting.FlatAppearance.BorderSize = 0;
                setting.BackgroundImage = global::AtomLauncher.Properties.Resources.setting;
                setting.FlatStyle = FlatStyle.Flat;
                setting.ForeColor = Color.Black;
                setting.Location = new Point(264, 4 + (84 * x));
                setting.Margin = new Padding(0);
                setting.Name = "atomButtonSettings" + entry.Key;
                setting.Size = new Size(26, 40);
                setting.TabIndex = 8;
                setting.TabStop = false;
                setting.UseVisualStyleBackColor = false;
                setting.MouseLeave += new EventHandler(this.atomButtonSettings_MouseLeave);
                setting.MouseEnter += new EventHandler(this.atomButtonSettings_MouseEnter);
                setting.Click += new EventHandler(this.atomButtonSettings_Click);
                this.Invoke(new MethodInvoker(delegate { formPanelRight.Controls.Add(setting); }));

                Button trash = new Button();
                trash.BackColor = noColor;
                trash.FlatAppearance.BorderSize = 0;
                trash.BackgroundImage = global::AtomLauncher.Properties.Resources.trash;
                trash.FlatStyle = FlatStyle.Flat;
                trash.ForeColor = Color.Black;
                trash.Location = new Point(264, 44 + (84 * x));
                trash.Margin = new Padding(0);
                trash.Name = "atomButtonTrash" + entry.Key;
                trash.Size = new Size(26, 40);
                trash.TabIndex = 8;
                trash.TabStop = false;
                trash.UseVisualStyleBackColor = false;
                trash.MouseLeave += new EventHandler(this.atomButtonTrash_MouseLeave);
                trash.MouseEnter += new EventHandler(this.atomButtonTrash_MouseEnter);
                trash.Click += new EventHandler(this.atomButtonTrash_Click);
                this.Invoke(new MethodInvoker(delegate { formPanelRight.Controls.Add(trash); }));
                x++;
            }
            this.Invoke(new MethodInvoker(delegate
            { 
                if (appData.Count < 1)
                {
                    formLabelAppSelected.Text = "No App, Add to launch.";
                    atomFileData.config["lastSelectedApp"] = "";
                }
                else
                {
                    if (!appData.ContainsKey(atomFileData.config["lastSelectedApp"]))
                    {
                        foreach (Control c in this.formPanelRight.Controls)
                        {
                            if (c is PictureBox)
                            {
                                if (c.Name.StartsWith("formPicture"))
                                {
                                    atomFileData.config["lastSelectedApp"] = c.Name.Replace("formPicture", "");
                                    break;
                                }
                            }
                        }
                    }
                    formLabelAppSelected.Text = atomFileData.config["lastSelectedApp"];
                }
            }));
            int y = 0;
            foreach (Control c in this.formPanelRight.Controls)
            {
                if (c.Name.EndsWith(atomFileData.config["lastSelectedApp"]))
                {
                    c.BackColor = selectColor;
                    y++;
                }
                if (y > 2)
                {
                    break;
                }
            }
            this.Invoke(new MethodInvoker(delegate { formPanelRight.Visible = true; }));
        }

        private void autoLogin()
        {
            int timeSeconds = Convert.ToInt32(atomFileData.config["autoLoginTime"]);
            int c = 0;
            while (true)
            {
                this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = formComboUsername.Text + " - Auto Login: " + timeSeconds; })); //Threading Friendly
                Thread.Sleep(1000);
                if (atomLauncher.cancelPressed)
                {
                    this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = "Auto Login Canceled"; formSetControl(true, true); }));
                    break;
                }
                if (c >= timeSeconds)
                {
                    launchApp();
                    break;
                }
                else
                {
                    timeSeconds--;
                }
            }
        }

        private void setInputBox()
        {
            formComboUsername.Items.Clear();
            formComboUsername.Text = "";
            int x = 0;
            if (userData.ContainsKey(atomFileData.config["lastSelectedApp"]))
            {
                foreach (KeyValuePair<string, string[]> dict in userData[atomFileData.config["lastSelectedApp"]])
                {
                    formComboUsername.Items.Add(dict.Key);
                    if (x == 0)
                    {
                        formComboUsername.Text = dict.Key;
                        x++;
                    }
                }
                if (x > 0)
                {
                    formButtonEditUser.Visible = true;
                }
                else
                {
                    formButtonEditUser.Visible = false;
                }
            }
            else
            {
                formButtonEditUser.Visible = false;
            }
            if (appData.Count > 0)
            {
                formPanelInputs.Visible = true;
            }
            else
            {
                formPanelInputs.Visible = false;
            }
        }

        private Object threadLock = new Object();
        private void launchApp()
        {
            if (Monitor.TryEnter(threadLock)) //Lock to only one Thread at a time.
            {
                try
                {
                    string status = "Failed: App Code Error.";
                    this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = "Working..."; }));
                    if (atomFileData.config["lastSelectedApp"] == "")
                    {
                        status = "Failed: No App Selected.";
                    }
                    else if (!appData.ContainsKey(atomFileData.config["lastSelectedApp"]))
                    {
                        status = "Failed: App " + atomFileData.config["lastSelectedApp"] + " does not Exist in Database";
                    }
                    else if (appData[atomFileData.config["lastSelectedApp"]]["appType"][0] == "Minecraft")
                    {
                        string username = "";
                        this.Invoke(new MethodInvoker(delegate { username = formComboUsername.Text; }));
                        string password = "";
                        if (username != "")
                        {
                            this.Invoke(new MethodInvoker(delegate { password = userData[atomFileData.config["lastSelectedApp"]][formComboUsername.Text][0]; }));
                        }
                        status = atomMinecraft.start(username, password);
                    }
                    else if (appData[atomFileData.config["lastSelectedApp"]]["appType"][0] == "General")
                    {
                        string username = "";
                        this.Invoke(new MethodInvoker(delegate { username = formComboUsername.Text; }));
                        string password = "";
                        if (username != "")
                        {
                            this.Invoke(new MethodInvoker(delegate { password = userData[atomFileData.config["lastSelectedApp"]][formComboUsername.Text][0]; }));
                        }
                        status = atomGeneral.start(username, password);
                    }
                    int x = 10;
                    if (status == "Successful")
                    {
                            fadeOutClose();
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = status; formLabelLoginCount.Text = x.ToString(); formSetControl(true, false); }));
                        while (x-- > 0)
                        {
                            Thread.Sleep(1000);
                            this.Invoke(new MethodInvoker(delegate { formLabelLoginCount.Text = x.ToString(); }));
                        }
                        this.Invoke(new MethodInvoker(delegate { formSetControl(true, true); }));
                    }
                }
                finally
                {
                    Monitor.Exit(threadLock); //Unlock for use of other threads.
                }
            }
        }

        /// <summary>
        /// Controls the form to be disabled or enabled. Also changes the main button text.
        /// </summary>
        /// <param name="userCanControl">Set this to true if you want the user to be able to control the form.</param>
        /// <param name="loginButtonControl">Set this to true if you want the Main button to be controllable.</param>
        private void formSetControl(bool userCanControl, bool loginButtonControl)
        {
            formButtonLogin.Enabled = loginButtonControl;
            formButtonLogin.Visible = loginButtonControl;
            formLabelLoginCount.Visible = !loginButtonControl;
            formPanelUser.Visible = userCanControl;
            foreach (Control con in formPanelRight.Controls)
            {
                con.Enabled = userCanControl;
            }
            formButtonUpdate.Enabled = userCanControl;
            if (userCanControl)
            {
                formButtonLogin.BackgroundImage = global::AtomLauncher.Properties.Resources.login;
                formButtonLogin.Tag = "Login";
            }
            else
            {
                formButtonLogin.BackgroundImage = global::AtomLauncher.Properties.Resources.cancel;
                formButtonLogin.Tag = "Cancel";
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        //
        // Required Code below.
        // Form Controls below.
        // Remove Win Forms Border, need this to correct minimizing window and moveing window.
        //
        private delegate void UpdateControlTextCallback(string name, string text);
        private delegate void UpdateControlIntCallback(int valuet, int valueb);
        public void formText(String name, String text) //Sets the text from other classes and threads.
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateControlTextCallback(formText), name, text);
                return;
            }
            if (name == "formLabelDLFile")
            {
                this.formLabelDLFile.Text = atomUtility.Compact(text, this.formLabelDLFile);
            }
            else
            {
                this.Controls.Find(name, true)[0].Text = text;
            }
                
        }
        public void barValues(int valuet, int valueb) //Sets the values from other classes and threads.
        {
            if (valuet > 100) valuet = 100;
            if (valueb > 100) valueb = 100;
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateControlIntCallback(barValues), valuet, valueb);
                return;
            }
            this.formBarTop.Width = (566 * valuet) / 100;
            this.formBarBottom.Width = (566 * valueb) / 100;
        }

        private void atomButtonClose_Click(object sender, EventArgs e)
        {
            fadeOutClose();
        }
        private void atomButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        const int WS_CLIPCHILDREN = 0x2000000;
        const int WS_MINIMIZEBOX = 0x20000;
        const int WS_MAXIMIZEBOX = 0x10000;
        const int WS_SYSMENU = 0x80000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = WS_CLIPCHILDREN | WS_MINIMIZEBOX | WS_SYSMENU;
                cp.ClassStyle = CS_DBLCLKS;
                return cp;
            }
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }

        private void atomLauncher_ResizeEnd(object sender, EventArgs e)
        {
            int x = this.Location.X;
            int y = this.Location.Y;
            bool change = false;
            if (x < (0 - (this.Width / 3) * 2))
            {
                x = (0 - (this.Width / 3) * 2);
                change = true;
            }
            if (x > Screen.PrimaryScreen.Bounds.Right - (this.Width / 3))
            {
                x = Screen.PrimaryScreen.Bounds.Right - (this.Width / 3);
                change = true;
            }
            if (y > Screen.PrimaryScreen.Bounds.Bottom - (this.Height / 3))
            {
                y = Screen.PrimaryScreen.Bounds.Bottom - (this.Height / 3);
                change = true;
            }
            if (change)
            {
                this.Location = new Point(x, y);
            }
        }
    }
}
