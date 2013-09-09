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
        string gameSelect = "minecraft";
        bool luancherLoaded = false;

        public static bool homeCancel = false; // Varible that changes when cancel is pressed.

        public Launcher()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            /////////
            // Startup Form Code
            //
                Thread spLoad = new Thread(loadThread);
                spLoad.IsBackground = true;
                spLoad.Start();
            //
            // End
            /////////
        }

        private void homeSaveLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (luancherLoaded) homeAutoLogin.Enabled = homeSaveLogin.Checked;
        }

        private void homeUserText_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] tmpPassAr = atomFileCode.readLoginFileUser(gameSelect, atomFileCode.usersFile, homeUserText.Text);
            homePassText.Text = tmpPassAr[2];
        }

        private void gameSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameSelect == "minecraft")
            {
                minecraftSettings mcSet = new minecraftSettings();
                mcSet.Show();
            }
        }

        private void homeStartButton_Click(object sender, EventArgs e)
        {
            if (homeStartButton.Text == "Cancel")
            {
                homeCancel = true;
                homeStartButton.Text = "Canceling..";
                homeStartButton.Enabled = false;
            }
            else
            {
                homeCancel = false;
                homeSetControl(false, true);
                Thread webt = new Thread(launchGame);
                webt.IsBackground = true;
                webt.Start();
            }
        }

        private void loadThread()
        {
            atomFileCode.removeLoginLine(atomFileCode.usersFile, "", "");
            Program.config = atomFileCode.loadConfFile(atomFileCode.conigFile);

            if (File.Exists(atomFileCode.usersFile))
            {
                //configFile has Selected "minecraft"
                //Change to form game type at this point.
                string[,] tmpArray = atomFileCode.readLoginFileAll(gameSelect, atomFileCode.usersFile);
                if (tmpArray[0, 0] != "false")
                {
                    for (int i = 0; i < tmpArray.GetLength(0); i++)
                    {
                        this.Invoke(new MethodInvoker(delegate { homeUserText.Items.Add(tmpArray[i, 1]); })); 
                    }
                    this.Invoke(new MethodInvoker(delegate { homeUserText.Text = tmpArray[0, 1]; })); 
                    if (Convert.ToBoolean(tmpArray[0, 3]))
                    {
                        this.Invoke(new MethodInvoker(delegate { homeAutoLogin.Checked = true; })); 
                    }
                    this.Invoke(new MethodInvoker(delegate { homeSaveLogin.Checked = true; })); 
                }
            }

            Thread chkv = new Thread(mC_checkVersionList);
            chkv.IsBackground = true;
            chkv.Start();

            if (homeAutoLogin.Checked == true)
            {
                Thread a = new Thread(autoLogin);          // Kick off a new thread
                a.IsBackground = true;
                a.Start();
            }
            else
            {
                homeSetControl(true, true);
            }
            luancherLoaded = true;
        }

        private void autoLogin()
        {
            homeSetControl(false, true);
            int timeSeconds = 5;
            int c = 0;
            while (true)
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Auto Login: " + timeSeconds; })); //Threading Friendly
                System.Threading.Thread.Sleep(1000);
                if (homeCancel == true)
                {
                    this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Auto Login Canceled"; })); //Threading Friendly
                    break;
                }
                if (c >= timeSeconds & homeCancel != true)
                {
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
            homeSetControl(true, true);
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
                string threadString = "";
                this.Invoke(new MethodInvoker(delegate { threadString = homeUserText.Text; })); //Threading Friendly, Required for some weird reason.
                string openStatus = mC_open(threadString, homePassText.Text, homeSaveLogin.Checked, homeAutoLogin.Checked);
                if (openStatus == "Successful")
                {
                    this.Invoke(new MethodInvoker(delegate { this.Close(); })); //Threading Freindly, Basic code is "this.Close()"
                }
                else
                {
                    homeSetControl(true, true);
                    this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = openStatus; })); //Threading Friendly
                }
            }
            finally
            {
                Monitor.Exit(threadLock); //Unlock for use of other threads.
            }
        }

        private void homeSetControl(bool trufal, bool strbool)
        {
            enableControls(trufal); //Threading Friendly
            this.Invoke(new MethodInvoker(delegate { homeStartButton.Enabled = strbool; })); //Threading Friendly
            if (trufal)
            {
                this.Invoke(new MethodInvoker(delegate { homeStartButton.Text = "Login"; })); //Threading Friendly
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate { homeStartButton.Text = "Cancel"; })); //Threading Friendly
            }
        }
        
        public void enableControls(bool trufal)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                homeAutoLogin.Enabled = trufal;
                homeMenuTools.Enabled = trufal;
                homeSaveLogin.Enabled = trufal;
                homeUserText.Enabled = trufal;
                homePassText.Enabled = trufal;
            }));
        }
    }
}
