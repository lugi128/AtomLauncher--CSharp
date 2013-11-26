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
    public partial class atomGeneralSettings : Form
    {
        string mainDrive = "";

        public atomGeneralSettings()
        {
            InitializeComponent();
            formTabs.Font = atomProgram.smallCustom;
            formPanel.Font = atomProgram.smallCustom;
            formLabelGeneralSettingsTitle.Font = atomProgram.mediuCustom;
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
            formTextGeneralLocation.Text = dict[appName]["location"][0];
            formTextWorkingDirect.Text = dict[appName]["workingDirect"][0];
            formTextAppArguments.Text = dict[appName]["arguments"][0];
            formComboCPUPriority.Text = dict[appName]["CPUPriority"][0];
            formTextThumbnail.Text = dict[appName]["thumbnailLoc"][0];
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
        
        private void atomGeneralSettings_Load(object sender, EventArgs e)
        {
            mainDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
            if (atomLauncher.settingsApp == "AL_AddNewApp")
            {
                Dictionary<string, Dictionary<string, string[]>> tmpDict = new Dictionary<string, Dictionary<string, string[]>>();
                tmpDict = atomFileData.getAppData(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], atomLauncher.settingsApp, tmpDict, "General");
                fillForm(tmpDict, atomLauncher.settingsApp);
                //atomFileData.config["dataLocation"] + atomFileData.config["appDataName"]
            }
            else
            {
                fillForm(atomLauncher.appData, atomLauncher.settingsApp);
            }
            Thread fadeI = new Thread(fadeIn);
            fadeI.IsBackground = true;
            fadeI.Start();
        }

        private void formButtonAppArguments_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The arguments space can have custom inputs. Custom inputs are to allow the launcher to input that information either dynamically or automatically.\n\nCustom Input List:\n\n[username]\nUse this in place of your username in the arugments in order to use the username blank.\n\n[password]\nUse this in place of your password in the arugments in order to use the password blank. Dont worry, its all encrypted, unless the program receiveing it doesnt encrypt it.", "Argument Information");
        }

        private void formButtonAppWorkingDirect_Click(object sender, EventArgs e)
        {
            formFolderDialog.Description = "Select the working directory that the application is in.";
            formFolderDialog.SelectedPath = formTextWorkingDirect.Text;
            formFolderDialog.ShowDialog();
            formTextWorkingDirect.Text = formFolderDialog.SelectedPath;
            formFolderDialog.Dispose();
        }

        private void formButtonGeneralFile_Click(object sender, EventArgs e)
        {
            formFileDialog.FileName = "";
            formFileDialog.Filter = "";
            if (formTextGeneralLocation.Text != "")
            {
                formFileDialog.InitialDirectory = formTextGeneralLocation.Text;
            }
            else
            {
                formFileDialog.InitialDirectory = mainDrive;
            }
            formFileDialog.Title = "Select Application Exicutable";
            formFileDialog.ShowDialog();
            if (formFileDialog.FileName != "")
            {
                formTextGeneralLocation.Text = formFileDialog.FileName;
            }
            formFileDialog.Dispose();
        }

        private void formButtonDefaults_Click(object sender, EventArgs e)
        {
            Dictionary<string, Dictionary<string, string[]>> tmpDict = new Dictionary<string, Dictionary<string, string[]>>();
            tmpDict = atomFileData.getAppData(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], atomLauncher.settingsApp, tmpDict, "General");
            tmpDict["General"]["location"][0] = atomLauncher.appData["General"]["location"][0];
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
            else if (formTextGeneralLocation.Text == "")
            {
                formLabelStatus.Text = "Please set the 'Application Executible File'";
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
                    atomLauncher.appData = atomFileData.getAppData(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], formTextAppName.Text, atomLauncher.appData, "General");
                }
                atomLauncher.appData[formTextAppName.Text]["appType"] = new string[] { "General" };
                atomLauncher.appData[formTextAppName.Text]["location"] = new string[] { formTextGeneralLocation.Text };
                atomLauncher.appData[formTextAppName.Text]["workingDirect"] = new string[] { formTextWorkingDirect.Text };
                atomLauncher.appData[formTextAppName.Text]["arguments"] = new string[] { formTextAppArguments.Text };
                atomLauncher.appData[formTextAppName.Text]["CPUPriority"] = new string[] { formComboCPUPriority.Text };
                atomLauncher.appData[formTextAppName.Text]["thumbnailLoc"] = new string[] { formTextThumbnail.Text };
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

        private void formButtonThumbnail_Click(object sender, EventArgs e)
        {
            formFileDialog.FileName = "";
            formFileDialog.Filter = "Preferred Images|*.png|Other Images|*.bmp,*.gif,*.jpeg,*.tif,*.tiff";
            if (formTextGeneralLocation.Text != "")
            {
                formFileDialog.InitialDirectory = formTextGeneralLocation.Text;
            }
            else
            {
                formFileDialog.InitialDirectory = mainDrive;
            }
            formFileDialog.Title = "Select Application Thumbnail";
            formFileDialog.ShowDialog();
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
    }
}
