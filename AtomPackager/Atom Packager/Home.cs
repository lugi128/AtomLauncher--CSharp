using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading;

namespace Atom_Packager
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            homeLabelStatus.Text = "Ready, Input Folder or File to Package";
        }

        private void homeButtonStart_Click(object sender, EventArgs e)
        {
            Thread dsa = new Thread();
            string startPath = @"C:\Users\TrinaryAtom\Desktop\Ziped and filesetup\TestFol";
            string zipPath = @"C:\Users\TrinaryAtom\Desktop\Ziped and filesetup\TestFol.zip";

            ZipFile.CreateFromDirectory(startPath, zipPath);
        }
    }
}
