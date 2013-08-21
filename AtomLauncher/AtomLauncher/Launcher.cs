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
            this.Activate(); // Makes sure the window shows its self.
            //Disable Unuseable Controls
            enableDevControls(false);

            if (File.Exists(atomFile.usersFile))
            {
                //configFile has Selected "minecraft"
                //Change to form game type at this point.
                string[] tmpArray = atomFile.readLoginFile("minecraft", atomFile.usersFile);
                if (tmpArray[0] != "false")
                {
                    homeUserText.Text = tmpArray[1];
                    homePassText.Text = tmpArray[2];
                    if (Convert.ToBoolean(tmpArray[3]))
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

        private void homeStartButton_Click(object sender, EventArgs e)
        {
            if (homeStartButton.Text == "Cancel")
            {
                aD_cancel = true;
                homeStartButton.Text = "Start";
            }
            else
            {
                aD_cancel = false;
                homeStartButton.Text = "Cancel";
                Thread webt = new Thread(launchGame);
                webt.IsBackground = true;
                webt.Start();
            }
        }

        private void autoLogin()
        {
            //enableControls(false);
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
                    this.Invoke(new MethodInvoker(delegate { homeStartButton.Text = "Start"; })); //Threading Friendly
                    break;
                }
                if (c >= timeSeconds & aD_cancel != true)
                {
                    this.Invoke(new MethodInvoker(delegate { homeStartButton.Text = "Start"; })); //Threading Friendly
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
                    //this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = openStatus; })); //Threading Friendly
                }
            }
            finally
            {
                Monitor.Exit(threadLock); //Unlock for use of other threads.
            }
        }

        //Development Method
        public void enableDevControls(bool trufal)
        {
            homeMenuMenu.Enabled = trufal;
            homeMenuOptions.Enabled = trufal;
            homeMenuGame.Enabled = trufal;
        }
    }
}
