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
using System.Text.RegularExpressions;

namespace AtomLauncher
{
    public partial class atomLauncherSettings : Form
    {
        public atomLauncherSettings()
        {
            InitializeComponent();
            formPanel.Font = atomProgram.smallCustom;
            formLabelLauncherSettingsTitle.Font = atomProgram.mediuCustom;
            formButtonOK.Font = atomProgram.mediuCustom;
        }

        private void fillForm(Dictionary<string, string> dict)
        {
            formNumAutoLoginTime.Value = Convert.ToInt32(dict["autoLoginTime"]);
            formCheckCustomFont.Checked = Convert.ToBoolean(dict["changeFont"]);
            formTextBackground.Text = dict["launcherBackground"];
            formTextUpdateURL.Text = dict["updateURL"];
            formTextVersionNum.Text = dict["launcherVersion"];
            formTextDataLocation.Text = dict["dataLocation"].TrimEnd(new char[] { '\\' });
            formTextUserDataName.Text = dict["userDataName"];
            formTextAppDataName.Text = dict["appDataName"];
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
        
        private void atomLauncherSettings_Load(object sender, EventArgs e)
        {
            fillForm(atomFileData.config);
            Thread fadeI = new Thread(fadeIn);
            fadeI.IsBackground = true;
            fadeI.Start();
        }

        private void formButtonDefaults_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> tmpDict = atomFileData.loadConfDefaults();
            fillForm(tmpDict);
        }

        private void formButtonCancel_Click(object sender, EventArgs e)
        {
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }

        private void formButtonOK_Click(object sender, EventArgs e)
        {
            Uri uriResult;
            if (formTextUserDataName.Text == formTextAppDataName.Text)
            {
                formLabelError.Text = "App and User data must have seperate names.";
            }
            else if (formTextVersionNum.Text == "")
            {
                formLabelError.Text = "Version Number cannot be blank.";
            }
            else if (formTextUpdateURL.Text != "" && !(Uri.TryCreate(formTextUpdateURL.Text, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)))
            {
                formLabelError.Text = "The Update URL is set to an incorrect format. You must declare Http:// or Https://";
            }
            else
            {
                atomFileData.config["autoLoginTime"] = formNumAutoLoginTime.Value.ToString();
                atomFileData.config["changeFont"] = formCheckCustomFont.Checked.ToString();
                atomFileData.config["launcherBackground"] = formTextBackground.Text;
                atomFileData.config["updateURL"] = formTextUpdateURL.Text;
                atomFileData.config["launcherVersion"] = formTextVersionNum.Text;
                if (formTextDataLocation.Text != "")
                {
                    atomFileData.config["dataLocation"] = formTextDataLocation.Text + @"\";
                }
                else
                {
                    atomFileData.config["dataLocation"] = formTextDataLocation.Text;
                }
                atomFileData.config["userDataName"] = formTextUserDataName.Text;
                atomFileData.config["appDataName"] = formTextAppDataName.Text;
                atomFileData.saveConfFile(atomFileData.configFile, atomFileData.config);
                Thread close = new Thread(fadeOutClose);
                close.IsBackground = true;
                close.Start();
            }
        }

        private void formTextVersionNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void formButtonBackground_Click(object sender, EventArgs e)
        {
            formFileDialog.FileName = "";
            formFileDialog.Filter = "Preferred Images|*.png|Other Images|*.bmp,*.gif,*.jpeg,*.tif,*.tiff";
            if (formTextBackground.Text != "")
            {
                formFileDialog.InitialDirectory = Path.GetDirectoryName(formTextBackground.Text);
            }
            else
            {
                formFileDialog.InitialDirectory = Path.GetDirectoryName(atomProgram.appDirectoryFile);
            }
            formFileDialog.Title = "Select Launcher Background";
            formFileDialog.ShowDialog();
            if (formFileDialog.FileName != "")
            {
                formTextBackground.Text = formFileDialog.FileName;
            }
            formFileDialog.Dispose();
        }

        private void formButtonBackgroundClear_Click(object sender, EventArgs e)
        {
            formTextBackground.Text = "";
        }

        private void formButtonDataLocation_Click(object sender, EventArgs e)
        {
            formFolderDialog.Description = "Select the where to store data files.";
            formFolderDialog.SelectedPath = formTextDataLocation.Text;
            formFolderDialog.ShowDialog();
            formTextDataLocation.Text = formFolderDialog.SelectedPath;
            formFolderDialog.Dispose();
        }

        private void formButtonDeleteAllData_Click(object sender, EventArgs e)
        {
            DialogResult yesnoDialog = MessageBox.Show("Are you sure you want to delete 'ALL' the data? This will delete all of the logins, apps, and app settings.\n\nLocation: " + atomFileData.config["dataLocation"], "Are you sure?", MessageBoxButtons.YesNo);
            if (yesnoDialog == DialogResult.Yes)
            {
                atomFileData.deleteLoop(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], true);
                atomFileData.deleteLoop(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], true);
                formLabelDetail.Text = "Click OK and restart launcher imiediatly for this to take effect.";
            }
        }

        private void formButtonDeleteUserData_Click(object sender, EventArgs e)
        {
            DialogResult yesnoDialog = MessageBox.Show("Are you sure you want to delete 'ALL' user data? This will delete all of the logins for each app.\n\nLocation: " + atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], "Are you sure?", MessageBoxButtons.YesNo);
            if (yesnoDialog == DialogResult.Yes)
            {
                atomFileData.deleteLoop(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], true);
                formLabelDetail.Text = "Click OK and restart launcher imiediatly for this to take effect.";
            }
        }

        private void formCheckCustomFont_CheckedChanged(object sender, EventArgs e)
        {
            if (formCheckCustomFont.Checked != Convert.ToBoolean(atomFileData.config["changeFont"]))
            {
                formLabelDetail.Text = "Click OK and restart launcher for this to take effect.";
            }
        }

        private void formTextBackground_TextChanged(object sender, EventArgs e)
        {
            if (formTextBackground.Text != atomFileData.config["launcherBackground"])
            {
                formLabelDetail.Text = "Click OK and restart launcher for this to take effect.";
            }
        }

        private void formTextDataLocation_TextChanged(object sender, EventArgs e)
        {
            if (formTextDataLocation.Text != atomFileData.config["dataLocation"].TrimEnd(new char[] { '\\' }))
            {
                formLabelDetail.Text = "Click OK and restart launcher for this to take effect.";
            }
        }

        private void formTextAppDataName_TextChanged(object sender, EventArgs e)
        {
            if (formTextAppDataName.Text != atomFileData.config["appDataName"])
            {
                formLabelDetail.Text = "Click OK and restart launcher for this to take effect.";
            }
        }

        private void formTextUserDataName_TextChanged(object sender, EventArgs e)
        {
            if (formTextUserDataName.Text != atomFileData.config["userDataName"])
            {
                formLabelDetail.Text = "Click OK and restart launcher for this to take effect.";
            }
        }
    }
}
