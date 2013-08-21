using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace AtomLauncher
{
    //
    // Warning Lots of temp code, Still building. Also needs lots of spelling corrections. :P
    //

    public partial class Launcher : Form
    {
        public bool aD_cancel = false; // Varible that changes when cancel is pressed.

        public Launcher()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            /////////
            // Startup Form Code
            //
            this.Activate(); // Makes sure the window shows its self.
            homeMenuMenu.Enabled = false; //Dev
            homeMenuOptions.Enabled = false; //Dev
            homeMenuGame.Enabled = false; //Dev
            //
            // End
            /////////

            if (File.Exists(atomFile.usersFile))
            {
                //configFile has Selected "minecraft"
                //Change to form game type at this point.
                string[,] tmpArray = atomFile.readLoginFileAll("minecraft", atomFile.usersFile);
                if (tmpArray[0,0] != "false")
                {
                    int dsa = tmpArray.GetLength(0);
                    homeLabelBar.Text = dsa.ToString() + " mc Accounts Found";
                    for (int i = 0; i < tmpArray.GetLength(0); i++)
                    {
                        homeUserText.Items.Add(tmpArray[i, 1]);
                    }
                    homeUserText.Text = tmpArray[0, 1];
                    homePassText.Text = tmpArray[0, 2];
                    if (Convert.ToBoolean(tmpArray[0,3]))
                    {
                        homeAutoLogin.Checked = true;
                    }
                    homeSaveLogin.Checked = true;
                }
            }
            if (homeAutoLogin.Checked == true)
            {
                Thread a = new Thread(autoLogin);          // Kick off a new thread
                a.IsBackground = true;
                a.Start();
                //autoLogin();
            }
        }

        private void homeSaveLogin_CheckedChanged(object sender, EventArgs e)
        {
            homeAutoLogin.Enabled = homeSaveLogin.Checked;
        }

        private void homeUserText_SelectedIndexChanged(object sender, EventArgs e)
        {
            //homePassText.Text = tmpArray[0, 2];
        }

        private void homeStartButton_Click(object sender, EventArgs e)
        {
            if (homeStartButton.Text == "Cancel")
            {
                aD_cancel = true;
                homeStartButton.Text = "Canceling..";
                homeStartButton.Enabled = false;
            }
            else
            {
                aD_cancel = false;
                enableControls(false);
                homeStartButton.Text = "Cancel";
                Thread webt = new Thread(launchGame);
                webt.IsBackground = true;
                webt.Start();
            }
        }

        private void controlRestore()
        {
            this.Invoke(new MethodInvoker(delegate { enableControls(true); })); //Threading Friendly
            this.Invoke(new MethodInvoker(delegate { homeStartButton.Enabled = true; })); //Threading Friendly
            this.Invoke(new MethodInvoker(delegate { homeStartButton.Text = "Login"; })); //Threading Friendly
        }

        private void autoLogin()
        {
            enableControls(false);
            this.Invoke(new MethodInvoker(delegate { homeStartButton.Text = "Cancel"; })); //Threading Friendly
            int timeSeconds = 5;
            int c = 0;
            while (true)
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Auto Login: " + timeSeconds; })); //Threading Friendly
                System.Threading.Thread.Sleep(1000);
                if (aD_cancel == true)
                {
                    this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Auto Login Canceled"; })); //Threading Friendly
                    enableControls(true);
                    this.Invoke(new MethodInvoker(delegate { homeStartButton.Text = "Login"; })); //Threading Friendly
                    break;
                }
                if (c >= timeSeconds & aD_cancel != true)
                {
                    enableControls(true);
                    this.Invoke(new MethodInvoker(delegate { homeStartButton.Text = "Login"; })); //Threading Friendly
                    Thread webt = new Thread(launchGame);
                    webt.IsBackground = true;
                    webt.Start();
                    break;
                }
                else
                {
                    timeSeconds--;
                }
            }
        }

        private Object threadLock = new Object();
        public void launchGame()
        {
            if (!Monitor.TryEnter(threadLock)) //Lock to only one Thread at a time.
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "WORKING!!?.. patience, :)"; })); //Threading Friendly
                return;
            }
            try
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Working..."; })); //Threading Friendly
                // aD_DownloadFile(aD_webLocation + aD_fileName, aD_saveLocation + aD_fileName);
                string openStatus = CMC_open(homeUserText.Text, homePassText.Text, homeSaveLogin.Checked, homeAutoLogin.Checked);
                if (openStatus == "Login")
                {
                    this.Invoke(new MethodInvoker(delegate { this.Close(); })); //Threading Freindly, Basic code is "this.Close()"
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = openStatus; })); //Threading Friendly
                }
            }
            finally
            {
                Monitor.Exit(threadLock); //Unlock for use of other threads.
            }
        }

        public void enableControls(bool trufal)
        {
            homeAutoLogin.Enabled = trufal;
            homeSaveLogin.Enabled = trufal;
            homeUserText.Enabled = trufal;
            homePassText.Enabled = trufal;
        }
    }
}
