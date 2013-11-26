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
    public partial class atomUserForm : Form
    {
        internal bool editUser = false;
        private string userEncPass = "";

        public atomUserForm()
        {
            InitializeComponent();
            formLabelTitle.Font = atomProgram.mediuCustom;
            formPanel.Font = atomProgram.smallCustom;
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

        private void loadUser()
        {
            if (editUser)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    formLabelTitle.Text = "Edit User";
                    formTextUser.Text = atomLauncher.atomLaunch.formComboUsername.Text;
                    userEncPass = atomLauncher.userData[atomFileData.config["lastSelectedApp"]][formTextUser.Text][0];
                    formTextUser.Enabled = false;
                    formTextPass.Text = userEncPass;
                    if (atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["autoLoginUser"][0] != "")
                    {
                        formCheckAutoLogin.Checked = true;
                    }
                }));
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    formLabelTitle.Text = "Add User";
                }));
            }
            fadeIn();
        }

        private void threadOut()
        {
            this.Invoke(new MethodInvoker(delegate { formLabelError.Text = "Saving, Please wait..."; }));
            if (!atomLauncher.userData.ContainsKey(atomFileData.config["lastSelectedApp"]))
            {
                atomLauncher.userData.Add(atomFileData.config["lastSelectedApp"], new Dictionary<string, string[]>());
            }
            if (!atomLauncher.userData[atomFileData.config["lastSelectedApp"]].ContainsKey(formTextUser.Text))
            {
                atomLauncher.userData[atomFileData.config["lastSelectedApp"]][formTextUser.Text] = new string[]
                    {
                        otherCipher.Encrypt(formTextPass.Text, otherCipher.machineIDLookup()),
                        "",
                        "",
                        "",
                        "",
                        ""
                    };
                atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], atomLauncher.userData, true);
            }
            else
            {
                if (userEncPass != formTextPass.Text)
                {
                    atomLauncher.userData[atomFileData.config["lastSelectedApp"]][formTextUser.Text][0] = otherCipher.Encrypt(formTextPass.Text, otherCipher.machineIDLookup());
                    atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], atomLauncher.userData, true);
                }

            }
            if (formCheckAutoLogin.Checked)
            {
                if (atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["autoLoginUser"][0] != formTextUser.Text)
                {
                    atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["autoLoginUser"][0] = formTextUser.Text;
                    atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], atomLauncher.appData);
                }
            }
            else
            {
                if (atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["autoLoginUser"][0] != "")
                {
                    atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["autoLoginUser"][0] = "";
                    atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], atomLauncher.appData);
                }
            }
            this.Invoke(new MethodInvoker(delegate { formLabelError.Text = "Save Successful"; }));
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }

        private void atomUserForm_Load(object sender, EventArgs e)
        {
            Thread loadU = new Thread(loadUser);
            loadU.IsBackground = true;
            loadU.Start();
        }

        private void formButtonCancel_Click(object sender, EventArgs e)
        {
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }

        private void formButtonOK_Click(object sender, EventArgs e)
        {
            if (formTextUser.Text == "")
            {
                formLabelError.Text = "Set a Username";
            }
            else if (!editUser && atomLauncher.userData.ContainsKey(atomFileData.config["lastSelectedApp"]) && atomLauncher.userData[atomFileData.config["lastSelectedApp"]].ContainsKey(formTextUser.Text))
            {
                formLabelError.Text = "User Already Exists";
            }
            else
            {
                Thread close = new Thread(threadOut);
                close.IsBackground = true;
                close.Start();
            }
        }

        private void formButtonDelete_Click(object sender, EventArgs e)
        {
            if (atomLauncher.userData.ContainsKey(atomFileData.config["lastSelectedApp"]))
            {
                if (atomLauncher.userData[atomFileData.config["lastSelectedApp"]].ContainsKey(formTextUser.Text))
                {
                    atomLauncher.userData[atomFileData.config["lastSelectedApp"]].Remove(formTextUser.Text);
                    atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], atomLauncher.userData, true);
                }
            }
            if (atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["autoLoginUser"][0] == formTextUser.Text)
            {
                atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["autoLoginUser"][0] = "";
                atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["appDataName"], atomLauncher.appData);
            }
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }
    }
}
