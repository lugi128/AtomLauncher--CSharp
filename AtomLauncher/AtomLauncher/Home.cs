using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AtomLauncher
{
    public partial class Home : Form
    {
        public static string appData = Environment.GetEnvironmentVariable("APPDATA");
        public string testAtom;
        public atomFile aF = new atomFile();
        public Dictionary<string, string> config;

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            loadConfigs();
            //Disable Unuseable Controls
            enableDevControls(false);
        }

        private void homeStartButton_Click(object sender, EventArgs e)
        {
            Thread webt = new Thread(launchGame);
            webt.IsBackground = true;
            webt.Start();
        }

        public void launchGame()
        {
            this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Test"; })); //Threading Friendly, Basic code is "homeLabelTop.Text = "Test""
            Minecraft mc = new Minecraft();
            bool openSuccessful = mc.open();
            if (openSuccessful)
            {
                this.Invoke(new MethodInvoker(delegate { this.Close(); })); //Threading Freindly, Basic code is "this.Close()"
            }
        }

        public void loadConfigs()
        {
            config = aF.loadConfFile();
        }

        //Development Method
        public void enableDevControls(bool trufal)
        {
            //homeStartButton.Enabled = trufal;
            homeSaveLogin.Enabled = trufal;
            homeAutoLogin.Enabled = trufal;
            homeMenuMenu.Enabled = trufal;
            homeMenuOptions.Enabled = trufal;
            homePassTitle.Enabled = trufal;
            homePassText.Enabled = trufal;
            homeUserTitle.Enabled = trufal;
            homeUserText.Enabled = trufal;
        }

        //Development Method.
        public void textChange(string text)
        {
            homeLabelTop.Text = text;
        }
    }
}
