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
    public partial class atomAddApp : Form
    {
        public atomAddApp()
        {
            InitializeComponent();
            formLabelTitle.Font = atomProgram.mediuCustom;
            formButtonCancel.Font = atomProgram.mediuCustom;
        }

        private void formButtonCancel_Click(object sender, EventArgs e)
        {
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
        }

        private void formPictureMinecraft_Click(object sender, EventArgs e)
        {
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
            atomLauncher.settingsApp = "AL_AddNewApp";
            atomMinecraftSettings mcSet = new atomMinecraftSettings();
            mcSet.ShowDialog();
            mcSet.Dispose();
            this.Close();
        }

        private void formPictureGeneral_Click(object sender, EventArgs e)
        {
            Thread close = new Thread(fadeOutClose);
            close.IsBackground = true;
            close.Start();
            atomLauncher.settingsApp = "AL_AddNewApp";
            atomGeneralSettings genSet = new atomGeneralSettings();
            genSet.ShowDialog();
            genSet.Dispose();
            this.Close();
        }

        private void atomAddApp_Load(object sender, EventArgs e)
        {
            Thread open = new Thread(fadeIn);
            open.IsBackground = true;
            open.Start();
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

        private void formPicture_MouseEnter(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            picBox.BackColor = atomLauncher.selectColor;
        }

        private void formPicture_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            picBox.BackColor = atomLauncher.noColor;
        }
    }
}
