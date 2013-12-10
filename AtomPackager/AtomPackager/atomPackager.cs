using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace AtomPackager
{
    public partial class atomPackager : Form
    {
        public atomPackager()
        {
            InitializeComponent();
        }

        private void atomPackager_Load(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\Sheryl\Desktop\Packager\MinecraftDevelopment");
            FileInfo[] Files = d.GetFiles("*",SearchOption.AllDirectories);
            DirectoryInfo[] Directories = d.GetDirectories();
            Thread scanItems = new Thread(() => scanAllMethod(Files, Directories));
            scanItems.Start();
        }

        private void scanAllMethod(FileInfo[] Files, DirectoryInfo[] Directories)
        {
            foreach (FileInfo File in Files)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    formListScannedItems.Items.Add(File.FullName.Replace(@"C:\Users\Sheryl\Desktop\Packager\MinecraftDevelopment\",""));
                }));
            }
        }
    }
}
