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
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Change this to suite your needs.
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        string launcherUpdateURL = "http://launcher.atomicelectronics.net";
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This launcher is looking for a version number and a download url from the launcherUpdateURL
        // Version:::URL
        // 0.0.0.0:::http://www.url.com
        // MajorChange.StandardAdd.MinorAdd.BugFix
        // The version number is controlled by the properties window. (The config file, if present, overwrites it).
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static string fileChangeVersion = "1.0.3.15"; // Last version of which the code for the saved data was changed.
        public static bool cancelPressed = false;
        public static Dictionary<string, Dictionary<string, string[]>> gameData = new Dictionary<string, Dictionary<string, string[]>>();
        public static Dictionary<string, Dictionary<string, string[]>> userData = new Dictionary<string, Dictionary<string, string[]>>();
        public static atomLauncher atomLaunch;
        Color selectColor = Color.FromArgb(255, 255, 255);
        Color noColor = Color.FromArgb(100, 0, 0, 0);
        public static string downloadVersion = "";
        public static string launcherDownload = "";
        public static string settingsGame = "";
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
            if (formButtonLogin.Text == "Cancel")
            {
                cancelPressed = true;
                formButtonLogin.Text = "Canceling ...";
                formButtonLogin.Enabled = false;
            }
            else
            {
                cancelPressed = false;
                formSetControl(false, true);
                Thread webt = new Thread(launchGame);
                webt.IsBackground = true;
                webt.Start();
            }
        }

        private void formPicture_Click(object sender, EventArgs e)
        {
            formPanelRight_Click(sender, e);
            PictureBox pic = (PictureBox)sender;
            atomProgram.config["lastSelectedGame"] = pic.Name.Replace("formPicture", "");
            pic.BackColor = selectColor;
            formLabelGameSelected.Text = atomProgram.config["lastSelectedGame"];
            setInputBoxes();
        }

        private void formPanelRight_Click(object sender, EventArgs e)
        {
            if (formLabelGameSelected.Enabled)
            {
                foreach (Control x in this.formPanelRight.Controls)
                {
                    if (x is PictureBox)
                    {
                        if (!x.Name.StartsWith("formPictureLine"))
                        {
                            x.BackColor = noColor;
                        }
                    }
                }
                atomProgram.config["lastSelectedGame"] = "";
                if (gameData.Count < 1)
                {
                    formLabelGameSelected.Text = "No Games Added, Add one to launch.";
                }
                else
                {
                    formLabelGameSelected.Text = "Pick one to launch.";
                }
                setInputBoxes();
            }
        }

        private void atomButtonSettings_Click(object sender, EventArgs e)
        {
            cancelPressed = false;
            Button button = (Button)sender;
            settingsGame = button.Name.Replace("atomButtonSettings", "");
            atomMinecraftSettings mcSet = new atomMinecraftSettings();
            mcSet.ShowDialog();
            setRightPanel();
        }

        private void atomButtonTrash_Click(object sender, EventArgs e)
        {
            //
            // Do you want to delete related files? If so Which ones?
            //
            cancelPressed = false;
            Button button = (Button)sender;
            string trashGame = button.Name.Replace("atomButtonTrash", "");
            gameData.Remove(trashGame);
            userData.Remove(trashGame);
            atomFileData.saveDictonary(atomFileData.userDataFile, userData, true);
            atomFileData.saveDictonary(atomFileData.gameDataFile, gameData);
            if (trashGame == atomProgram.config["lastSelectedGame"])
            {
                atomProgram.config["lastSelectedGame"] = "";
                setInputBoxes();
            }
            setRightPanel();
        }

        private void formComboUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            formTextPass.Text = otherCipher.Decrypt(userData[atomProgram.config["lastSelectedGame"]][formComboUsername.Text][1], otherCipher.machineIDLookup());
        }

        private void formButtonAddGame_Click(object sender, EventArgs e)
        {
            cancelPressed = false;
            atomAddGame addP = new atomAddGame();
            addP.ShowDialog();
            setRightPanel();
        }

        private void formButtonUpdate_Click(object sender, EventArgs e)
        {
            // Should Create a form for this. For better control.
            DialogResult updateDialog = MessageBox.Show("Do you wish to update from " + atomProgram.config["launcherVersion"] + " to " + downloadVersion + "?", "Update?", MessageBoxButtons.YesNo);
            if (updateDialog == DialogResult.Yes)
            {
                DialogResult changelog = MessageBox.Show("Do you want to read the change log for " + atomProgram.config["launcherVersion"] + " to " + downloadVersion + "?", "Changelog?", MessageBoxButtons.YesNo);
                if (changelog == DialogResult.Yes)
                {
                    Process.Start("http://launcher.atomicelectronics.net/?page=changelog.php"); // possibly store change log on string downloads
                }
                cancelPressed = false;
                Thread updateF = new Thread(updateThread);
                updateF.IsBackground = true;
                updateF.Start();
            }
        }

        private void formButtonUpdateStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Status: " + updateStatus + "\n" + "Current Version: " + atomProgram.config["launcherVersion"] + "\n" + "Latest Version: " + downloadVersion, "Update Status");
        }

        private void formCheckSaveLogin_CheckedChanged(object sender, EventArgs e)
        {
            formCheckAutoLogin.Enabled = formCheckSaveLogin.Checked;
            if (formCheckSaveLogin.Checked)
            {
                if (gameData.ContainsKey(atomProgram.config["lastSelectedGame"]))
                {
                    if (gameData[atomProgram.config["lastSelectedGame"]]["autoLoginUser"][0] != "")
                    {
                        formComboUsername.Text = gameData[atomProgram.config["lastSelectedGame"]]["autoLoginUser"][0];
                        formCheckAutoLogin.Checked = true;
                    }
                }
            }
            else
            {
                formCheckAutoLogin.Checked = false;
            }
        }

        private void formButtonAbout_Click(object sender, EventArgs e)
        {
            atomAboutBox box = new atomAboutBox();
            box.ShowDialog();
        }

        private void formButtonLauncherSettings_Click(object sender, EventArgs e)
        {
            // Create Settings for Launcher here.
            //    Settings List.
            //    Change idle background image.
            //    Update Url Change.
            //    Debug on/off.
            //    Version Number Change.
            //    Manual Select Game.
            //    Delete User Data.
            //    Delete Game Data.
            //    Set all to Defaults.
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
                atomDownloading.Single(launcherDownload, Path.GetDirectoryName(atomProgram.appDirectory) + @"\Update" + Path.GetFileName(atomProgram.appDirectory));
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
                Process.Start(Path.GetDirectoryName(atomProgram.appDirectory) + @"\Update" + Path.GetFileName(atomProgram.appDirectory));
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
            if (File.Exists("Update" + Path.GetFileName(atomProgram.appDirectory)))
            {
                Dictionary<string, string> dict = atomFileData.loadConfDefaults();
                atomProgram.config["launcherVersion"] = dict["launcherVersion"];
                atomFileData.saveConfFile(atomFileData.configFile, atomProgram.config);
                string status = atomFileData.deleteLoop("Update" + Path.GetFileName(atomProgram.appDirectory));
                if (status != "")
                {
                    MessageBox.Show("Update Error: Deleting Update File: " + status, "Update File");
                }
            }
            if (!atomProgram.debugApp)
            {
                if (launcherUpdateURL != "")
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
                        using (WebClient client = new WebClient()) // Get Data from Minecraft with username and password
                        {
                            ALUpdateData = client.DownloadString(launcherUpdateURL);
                        }
                        string[] splitCharacter = { ":::" };
                        string[] ALUpdateStrings = ALUpdateData.Split(splitCharacter, StringSplitOptions.None);
                        downloadVersion = ALUpdateStrings[0];
                        launcherDownload = ALUpdateStrings[1];
                    }
                    catch (Exception ex)
                    {
                        status = "Error: " + ex.Message;
                    }
                    if (status == "")
                    {
                        if (atomUtility.compareVersions(atomProgram.config["launcherVersion"], downloadVersion))
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                formButtonUpdate.BackColor = System.Drawing.Color.White;
                                formButtonUpdate.Location = new System.Drawing.Point(828, 4);
                                formButtonUpdate.Size = new System.Drawing.Size(116, 20);
                                formButtonUpdate.Text = "Update Available";
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
        }

        private void loadingThread()
        {
            this.Invoke(new MethodInvoker(delegate { formSetControl(false, true); }));
            if (Path.GetFileName(atomProgram.appDirectory).StartsWith("Update"))
            {
                string status = atomFileData.deleteLoop(Path.GetFileName(atomProgram.appDirectory).Replace("Update", ""));
                if (status == "")
                {
                    File.Copy(Path.GetFileName(atomProgram.appDirectory), Path.GetFileName(atomProgram.appDirectory).Replace("Update", ""));
                    Process.Start(Path.GetFileName(atomProgram.appDirectory).Replace("Update", ""));
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
                atomProgram.config = atomFileData.loadConfFile(atomFileData.configFile);
                if (atomUtility.compareVersions(atomProgram.config["launcherVersion"], fileChangeVersion))
                {
                    string status = atomFileData.deleteLoop(atomFileData.gameDataFile);
                    status = status + atomFileData.deleteLoop(atomFileData.userDataFile);
                    status = status + atomFileData.deleteLoop(atomFileData.configFile);
                    if (status != "")
                    {
                        MessageBox.Show("File Error: Deleting File Data: " + status, "Data File");
                    }
                    MessageBox.Show("Update Notification: Updates to the opening and saveing of files have changed. The files saved to the computer have been deleted. Sorry for the inconvience.", "Update Notification");
                }
                gameData = atomFileData.getGameData(atomFileData.gameDataFile);
                userData = atomFileData.getUserData(atomFileData.userDataFile);
                atomProgram.debugApp = Convert.ToBoolean(atomProgram.config["debug"]);
                setRightPanel();
                Thread versionF = new Thread(versionThread);
                versionF.IsBackground = true;
                versionF.Start();
                while (this.Opacity != 1)
                {
                    Thread.Sleep(10);
                    this.Invoke(new MethodInvoker(delegate { this.Opacity += .04; }));
                }
                this.Invoke(new MethodInvoker(delegate { formSetControl(false, true); }));
                if (gameData.ContainsKey(atomProgram.config["lastSelectedGame"]))
                {
                    if (gameData[atomProgram.config["lastSelectedGame"]]["autoLoginUser"][0] != "")
                    {
                        autoLogin();
                    }
                }
                this.Invoke(new MethodInvoker(delegate
                {
                    formSetControl(true, true);
                    setInputBoxes();
                }));

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

        internal void setRightPanel()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                formPanelRight.Controls.Clear();
                formPanelRight.Controls.Add(this.formButtonAddGame);
                formPanelRight.Controls.Add(this.formButtonLauncherSettings);
                formPanelRight.Controls.Add(this.formLabelGameSelected);
                if (atomProgram.config["lastSelectedGame"] == "")
                {
                    if (gameData.Count < 1)
                    {
                        formLabelGameSelected.Text = "No Games Added, Add one to launch.";
                    }
                    else
                    {
                        formLabelGameSelected.Text = "Pick one to launch.";
                    }
                }
                else
                {
                    formLabelGameSelected.Text = atomProgram.config["lastSelectedGame"];
                }
                formPanelRight.VerticalScroll.Visible = false;
            }));
            int x = 0;
            foreach (KeyValuePair<string, Dictionary<string, string[]>> entry in gameData)
            {
                PictureBox picture = new PictureBox();
                picture.BackColor = noColor;
                picture.Image = global::AtomLauncher.Properties.Resources.mc;
                if (gameData[entry.Key]["thumbnailLoc"][0] != "")
                {
                    picture.ImageLocation = gameData[entry.Key]["thumbnailLoc"][0];
                }
                picture.Location = new System.Drawing.Point(4, 52 + (84 * x));
                picture.Name = "formPicture" + entry.Key;
                picture.Size = new System.Drawing.Size(260, 80);
                picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                picture.TabIndex = 0;
                picture.TabStop = false;
                picture.Click += new System.EventHandler(this.formPicture_Click);
                this.Invoke(new MethodInvoker(delegate { formPanelRight.Controls.Add(picture); }));

                Button setting = new Button();
                setting.BackColor = System.Drawing.Color.White;
                setting.FlatAppearance.BorderColor = System.Drawing.Color.White;
                setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                setting.ForeColor = System.Drawing.Color.Black;
                setting.Location = new System.Drawing.Point(264, 52 + (84 * x));
                setting.Margin = new System.Windows.Forms.Padding(0);
                setting.Name = "atomButtonSettings" + entry.Key;
                setting.Size = new System.Drawing.Size(24, 40);
                setting.TabIndex = 8;
                setting.TabStop = false;
                setting.Text = "S";
                setting.UseVisualStyleBackColor = false;
                setting.Click += new System.EventHandler(this.atomButtonSettings_Click);
                this.Invoke(new MethodInvoker(delegate { formPanelRight.Controls.Add(setting); }));

                Button trash = new Button();
                trash.BackColor = System.Drawing.Color.White;
                trash.FlatAppearance.BorderColor = System.Drawing.Color.White;
                trash.Click += new System.EventHandler(this.atomButtonTrash_Click);
                trash.Text = "T";
                trash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                trash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                trash.ForeColor = System.Drawing.Color.Black;
                trash.Location = new System.Drawing.Point(264, 92 + (84 * x));
                trash.Margin = new System.Windows.Forms.Padding(0);
                trash.Name = "atomButtonTrash" + entry.Key;
                trash.Size = new System.Drawing.Size(24, 40);
                trash.TabIndex = 8;
                trash.TabStop = false;
                trash.UseVisualStyleBackColor = false;
                this.Invoke(new MethodInvoker(delegate { formPanelRight.Controls.Add(trash); }));
                x++;
            }
            foreach (Control c in this.formPanelRight.Controls)
            {
                if (c is PictureBox)
                {
                    if (c.Name == "formPicture" + atomProgram.config["lastSelectedGame"])
                    {
                        c.BackColor = selectColor;
                        break;
                    }
                }
            }
        }

        private void autoLogin()
        {
            int timeSeconds = 5;
            int c = 0;
            while (true)
            {
                this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = "Auto Login: " + timeSeconds; })); //Threading Friendly
                System.Threading.Thread.Sleep(1000);
                if (atomLauncher.cancelPressed)
                {
                    this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = "Auto Login Canceled"; formSetControl(true, true); }));
                    break;
                }
                if (c >= timeSeconds)
                {
                    launchGame();
                    break;
                }
                else
                {
                    timeSeconds--;
                }
            }
        }

        private void setInputBoxes()
        {
            if (atomProgram.config["lastSelectedGame"] == "")
            {
                formComboUsername.Items.Clear();
                formComboUsername.Text = "";
                formTextPass.Text = "";
                if (formComboUsername.Enabled)
                {
                    formComboUsername.Enabled = false;
                    formTextPass.Enabled = false;
                    formCheckSaveLogin.Enabled = false;
                    formCheckSaveLogin.Checked = false;
                }
            }
            else
            {
                if (!formComboUsername.Enabled)
                {
                    formComboUsername.Enabled = true;
                    formTextPass.Enabled = true;
                    formCheckSaveLogin.Enabled = true;
                }
                int x = 0;
                if (userData.ContainsKey(atomProgram.config["lastSelectedGame"]))
                {
                    foreach (KeyValuePair<string, string[]> dict in userData[atomProgram.config["lastSelectedGame"]])
                    {
                        formComboUsername.Items.Add(dict.Key);
                        formCheckSaveLogin.Checked = true;
                        if (x == 0)
                        {
                            formComboUsername.Text = dict.Key;
                        }
                        x++;
                    }
                }
            }
        }

        private Object threadLock = new Object();
        private void launchGame()
        {
            if (!Monitor.TryEnter(threadLock)) //Lock to only one Thread at a time.
            {
                this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = "Code still working"; }));
                this.Invoke(new MethodInvoker(delegate { formSetControl(true, true); }));
                return;
            }
            try
            {
                string status = "Failed: Game Code Error.";
                
                    if (atomProgram.config["lastSelectedGame"] == "")
                    {
                        status = "Failed: No Game Selected.";
                    }
                    else if (!gameData.ContainsKey(atomProgram.config["lastSelectedGame"]))
                    {
                        status = "Failed: Game " + atomProgram.config["lastSelectedGame"] + " does not Exist in Database";
                    }
                    else if (gameData[atomProgram.config["lastSelectedGame"]]["gameType"][0] == "Minecraft")
                    {
                        string username = "";
                        this.Invoke(new MethodInvoker(delegate { username = formComboUsername.Text; }));
                        status = atomMinecraft.start(username, formTextPass.Text, formCheckSaveLogin.Checked, formCheckAutoLogin.Checked);
                    }
                int x = 10;
                if (status == "Successful")
                {
                    if (atomProgram.debugApp)
                    {
                        this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = "(" + x + ") " + status; formSetControl(true, false); }));
                        while (x-- >= 0)
                        {
                            Thread.Sleep(1000);
                            this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = "(" + x + ") " + status; }));
                        }
                        this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = status; formSetControl(true, true); }));
                    }
                    else
                    {
                        fadeOutClose();
                    }
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = "(" + x + ") " + status; formSetControl(true, false); }));
                    while (x-- > 0)
                    {
                        Thread.Sleep(1000);
                        this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = "(" + x + ") " + status; }));
                    }
                    this.Invoke(new MethodInvoker(delegate { formLabelStatus.Text = status; formSetControl(true, true); }));
                }
            }
            finally
            {
                Monitor.Exit(threadLock); //Unlock for use of other threads.
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
            formComboUsername.Enabled = userCanControl;
            formTextPass.Enabled = userCanControl;
            foreach (Control con in formPanelRight.Controls)
            {
                con.Enabled = userCanControl;
            }
            formCheckSaveLogin.Enabled = userCanControl;
            formButtonUpdate.Enabled = userCanControl;
            if (userCanControl)
            {
                formButtonLogin.Text = "Login";
            }
            else
            {
                formButtonLogin.Text = "Cancel";
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
            this.Controls.Find(name, true)[0].Text = text;
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
            this.formBarTop.Value = valuet;
            this.formBarBottom.Value = valueb;
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
    }
}
