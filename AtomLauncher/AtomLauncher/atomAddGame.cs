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
    public partial class atomAddGame : Form
    {
        public atomAddGame()
        {
            InitializeComponent();
        }

        private void formButtonCancel_Click(object sender, EventArgs e)
        {
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }

        private void formButtonAddMinecraft_Click(object sender, EventArgs e)
        {
            atomLauncher.settingsGame = "AL_AddNewGame";
            atomMinecraftSettings mcSet = new atomMinecraftSettings();
            mcSet.ShowDialog();
            mcSet.Dispose();
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }

        private void atomAddGame_Load(object sender, EventArgs e)
        {
            Thread open = new Thread(fadeIn);
            open.IsBackground = true;
            open.Start();
        }

        private void fadeIn()
        {
            while (this.Opacity != 1)
            {
                Thread.Sleep(10);
                this.Invoke(new MethodInvoker(delegate { this.Opacity += .04; }));
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
    }
}
