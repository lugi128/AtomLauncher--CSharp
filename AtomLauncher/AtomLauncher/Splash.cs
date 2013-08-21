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
    public partial class Splash : Form
    {
        public atomFile aF = new atomFile();

        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Thread spRun = new Thread(splashRun);
            spRun.IsBackground = true; //Closes thread if Splash gets closed.
            spRun.Start();
        }

        public void splashRun()
        {
            Thread spLoad = new Thread(loadThread);
            spLoad.IsBackground = true; //Closes thread if Splash gets closed.
            spLoad.Start();
            Thread.Sleep(Program.splashTime); // Minimum wait time. 
            spLoad.Join(); // Wait for loadThread to complete
            Thread lTh = new Thread(new ThreadStart(launcherThread));
            lTh.Start();
            Thread.Sleep(1000);
            this.Invoke(new MethodInvoker(delegate { this.Close(); })); //Threading Freindly, Basic code is "this.Close()"
        }

        public static void launcherThread()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Launcher());
        }

        public void loadThread()
        {
            atomFile.removeLoginLine(atomFile.usersFile, "", "");
            Program.config = aF.loadConfFile();
        }
    }
}
