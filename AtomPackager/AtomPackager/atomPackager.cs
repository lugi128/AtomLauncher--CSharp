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
using System.Runtime.InteropServices;

namespace AtomPackager
{
    public partial class atomPackager : Form
    {
        public static string selectedPackage = "";

        public atomPackager()
        {
            InitializeComponent();
        }

        private void atomPackager_Load(object sender, EventArgs e)
        {
            Thread loadT = new Thread(loadingThread);
            loadT.Start();
        }

        private void loadingThread()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(atomProgram.appDirectoryFile) + @"\Packages");
            DirectoryInfo d = new DirectoryInfo(Path.GetDirectoryName(atomProgram.appDirectoryFile) + @"\Packages");
            DirectoryInfo[] Directories = d.GetDirectories();
            this.Invoke(new MethodInvoker(delegate
            {
                foreach (DirectoryInfo Dir in Directories)
                {
                    formComboPackages.Items.Add(Dir.Name);
                }
                formComboPackages.Text = Directories[0].Name;
            }));
        }

        private void scanAllMethod()
        {
            DirectoryInfo d = new DirectoryInfo(Path.GetDirectoryName(atomProgram.appDirectoryFile) + @"\Packages\" + selectedPackage);
            FileInfo[] Files = d.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    formListRepairItems.Items.Add(File.FullName.Replace(Path.GetDirectoryName(atomProgram.appDirectoryFile) + @"\Packages\" + selectedPackage + @"\", ""));
                }));
            }
        }

        private void formButtonAdd_Click(object sender, EventArgs e)
        {
            if (formListRepairItems.SelectedItems != null)
            {
                while (formListRepairItems.SelectedItems.Count > 0)
                {
                    string temp = formListRepairItems.SelectedItems[0].ToString();
                    formListRepairItems.Items.Remove(temp);
                    formListCriticalItems.Items.Add(temp);
                } 
            }
        }

        private void formButtonRemove_Click(object sender, EventArgs e)
        {
            if (formListCriticalItems.SelectedItems != null)
            {
                while (formListCriticalItems.SelectedItems.Count > 0)
                {
                    string temp = formListCriticalItems.SelectedItems[0].ToString();
                    formListCriticalItems.Items.Remove(temp);
                    formListRepairItems.Items.Add(temp);
                }
            }
        }

        private void formButtonSave_Click(object sender, EventArgs e)
        {
            foreach (string file in formListCriticalItems.Items)
            {

            }
        }

        private void formButtonLoad_Click(object sender, EventArgs e)
        {
            formListRepairItems.Items.Clear();
            formListCriticalItems.Items.Clear();
            selectedPackage = formComboPackages.Text;
            Thread loadT = new Thread(scanAllMethod);
            loadT.Start();
        }

        private void formButtonRefresh_Click(object sender, EventArgs e)
        {
            formComboPackages.Items.Clear();
            Directory.CreateDirectory(Path.GetDirectoryName(atomProgram.appDirectoryFile) + @"\Packages");
            DirectoryInfo d = new DirectoryInfo(Path.GetDirectoryName(atomProgram.appDirectoryFile) + @"\Packages");
            DirectoryInfo[] Directories = d.GetDirectories();
            this.Invoke(new MethodInvoker(delegate
            {
                foreach (DirectoryInfo Dir in Directories)
                {
                    formComboPackages.Items.Add(Dir.Name);
                }
                formComboPackages.Text = Directories[0].Name;
            }));
        }
    }
}
