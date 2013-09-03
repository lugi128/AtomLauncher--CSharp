using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Security.Cryptography;

namespace AtomLauncher
{
    public partial class Launcher
    {
        WebClient aD_webClient;    // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        Stopwatch tw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        bool downloadBusy = false;
        double ammDLedvsTime = 0;
        public string aD_fileName = "NoFile";
        public int aD_totalSize = 0;
        public double aD_totalRecieved = 0;
        public double aD_Recieved = 0;

        //
        //public string location = @".\";
        //                           Location of All Files
        //
        //Dictionary<int, string[]> urlAddress = new Dictionary<int, string[]>{
        //    {0, new string[] { "http://trinaryatom.com/_web_downloads/Test/", "test0.zip", "Folder" }},
        //    {1, new string[] { "http://trinaryatom.com/_web_downloads/Test/", "test1.zip", "Folder" }},
        //    {2, new string[] { "http://trinaryatom.com/_web_downloads/Test/", "test2.zip", "Folder" }},
        //    {3, new string[] { "http://trinaryatom.com/_web_downloads/Test/", "test3.zip", "Folder" }},
        //    {4, new string[] { "http://trinaryatom.com/_web_downloads/Test/", "test4.zip", "Folder" }},
        //    {5, new string[] { "http://trinaryatom.com/_web_downloads/Test/", "test5.zip", "Folder" }}
        //     #                  Website Location                               File         Sub Save Location
        //};
        public void aD_DownloadFileDict(Dictionary<int, string[]> urlAddress, string location)
        {
            this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Checking Files..."; }));
            this.Invoke(new MethodInvoker(delegate { homeBarTop.Style = ProgressBarStyle.Marquee; }));
            aD_totalSize = 0;
            aD_totalRecieved = 0;
            int l = 0;

            //////////////////////
            while (l < urlAddress.Count) //Get File sizes before downloading everything.
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelBottom.Text = urlAddress[l][1]; }));
                int ContentLength = 0;
                System.Net.WebRequest req = System.Net.HttpWebRequest.Create(urlAddress[l][0] + urlAddress[l][1]);
                req.Method = "HEAD";
                try
                {
                    using (System.Net.WebResponse resp = req.GetResponse())
                    {
                        int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength);
                    }
                }
                catch (Exception ex)
                {
                    homeCancel = true;
                    this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = ex.Message; }));
                    MessageBox.Show(ex.Message + " : File=" + urlAddress[l][0] + urlAddress[l][1]);
                }
                aD_totalSize = aD_totalSize + ContentLength;
                l++;
                this.Invoke(new MethodInvoker(delegate { homeBarBottom.Value = Convert.ToInt32((decimal)l / urlAddress.Count * 100); }));
                if (homeCancel)
                {
                    break;
                }
            }

            //////////////////////

            this.Invoke(new MethodInvoker(delegate { homeBarTop.Style = ProgressBarStyle.Blocks; }));
            if (homeCancel)
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Canceled File Check"; }));
                return;
            }
            this.Invoke(new MethodInvoker(delegate { homeBarBottom.Value = 0; }));
            this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Connecting..."; }));

            //////////////////////

            l = 0;
            while (l < urlAddress.Count) // Loop through the file array and download list.
            {
                if (urlAddress[l][0] != "")
                {
                    downloadBusy = true;
                    this.Invoke(new MethodInvoker(delegate { homeBarTop.Value = 0; }));
                    this.Invoke(new MethodInvoker(delegate { homeLabelBottom.Text = "Downloading " + urlAddress[l][1]; }));
                    aD_DownloadFile(urlAddress[l][0] + urlAddress[l][1], location + @"\" + urlAddress[l][2], urlAddress[l][1]); // Start downloading the file
                    while (downloadBusy) // Wait for Complete File
                    {
                        Thread.Sleep(100);
                        if (homeCancel)
                        {
                            break;
                        }
                    }
                }
                if (homeCancel)
                {
                    break;
                }
                l++;
                this.Invoke(new MethodInvoker(delegate { homeBarBottom.Value = Convert.ToInt32((decimal)l / urlAddress.Count * 100); }));
            }

            //////////////////////

            if (homeCancel)
            {
                if (aD_fileName == "NoFile")
                {
                    this.Invoke(new MethodInvoker(delegate { homeLabelBottom.Text = "Canceled"; }));
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate { homeLabelBottom.Text = "Canceled Download: " + urlAddress[l][1]; }));
                }
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate { homeBarTop.Value = 100; }));
                this.Invoke(new MethodInvoker(delegate { homeBarBottom.Value = 100; }));
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Download Complete"; }));
            }
            if (aD_totalSize != 0)
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelBottomBar.Text = (Convert.ToDouble(aD_totalRecieved) / 1024 / 1024).ToString("0.00") + " Mb's" + "  /  " + (Convert.ToDouble(aD_totalSize) / 1024 / 1024).ToString("0.00") + " Mb's"; }));
            }
        }
        
        public void aD_DownloadFileSingle(string urlAddress, string location, string file) // Doesnt work...
        {
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Downloading " + file); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            downloadBusy = true;
            aD_DownloadFile(urlAddress, location, file); // Start downloading the file
            while (downloadBusy) // Wait for Complete File
            {
                Thread.Sleep(100);
                if (homeCancel)
                {
                    break;
                }
            }
        }

        public void aD_DownloadFile(string urlAddress, string location, string file)
        {
            Directory.CreateDirectory(location);
            aD_fileName = location + @"\" + file;
            sw.Reset();
            if (homeCancel)
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Download Canceled"; }));
                return;
            }
            using (aD_webClient = new WebClient())
            {
                aD_webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(aD_Completed);
                aD_webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(aD_ProgressChanged);

                try
                {
                    // The variable that will be holding the url address
                    Uri URL = new Uri(urlAddress);
                    // Start the stopwatch which we will be using to calculate the download speed
                    sw.Start();
                    // Start downloading the file
                    aD_webClient.DownloadFileAsync(URL, aD_fileName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void aD_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                if (homeCancel == true)
                {
                    aD_webClient.CancelAsync();
                }
                else
                {
                    aD_Recieved = e.BytesReceived;
                    if (e.ProgressPercentage != 100) // prevents this from Accidentally running aD_Completed is triggered.
                    {
                        ammDLedvsTime = sw.Elapsed.TotalSeconds - ammDLedvsTime;

                        // Calculate download speed and output it to label3
                        if (homeLabelBottom.Text != (Convert.ToDouble(e.BytesReceived) / 1024 / ammDLedvsTime).ToString("0"))
                            this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = (Convert.ToDouble(e.BytesReceived) / 1024 / sw.Elapsed.TotalSeconds).ToString("0.00") + " kb/s"; }));

                        // Update the progressbar percentage only when the value is not the same (to avoid updating the control constantly)
                        if (homeBarTop.Value != e.ProgressPercentage)
                            this.Invoke(new MethodInvoker(delegate { homeBarTop.Value = e.ProgressPercentage; }));

                        // Update the label with how much data of the file has been downloaded so far and the total size of the file we are currently downloading
                        this.Invoke(new MethodInvoker(delegate { homeLabelTopBar.Text = (Convert.ToDouble(e.BytesReceived) / 1024 / 1024).ToString("0.00") + " Mb's" + "  /  " + (Convert.ToDouble(e.TotalBytesToReceive) / 1024 / 1024).ToString("0.00") + " Mb's"; }));

                        // Update the label with how much data has been downloaded so far and the total size of all the files we are currently downloading.
                        this.Invoke(new MethodInvoker(delegate { homeLabelBottomBar.Text = (Convert.ToDouble(aD_totalRecieved + aD_Recieved) / 1024 / 1024).ToString("0.00") + " Mb's" + "  /  " + (Convert.ToDouble(aD_totalSize) / 1024 / 1024).ToString("0.00") + " Mb's"; }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // The event that will trigger when the WebClient is completed
        private void aD_Completed(object sender, AsyncCompletedEventArgs e)
        {
            aD_totalRecieved = aD_totalRecieved + aD_Recieved;
            sw.Reset();
            if (e.Cancelled == true)
            {
                File.Delete(aD_fileName);       // Delete the incomplete file if the download is canceled
            }
            else if (e.Error != null)
            {
                homeCancel = true;
                File.Delete(aD_fileName);       // Delete the incomplete file if the download is canceled
                this.Invoke(new MethodInvoker(delegate { homeBarTop.Value = 0; }));
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = e.Error.Message; })); //Error
            }
            else
            {
                downloadBusy = false;
                if (!homeCancel)
                {
                    this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Completed"; }));
                }
                aD_fileName = "NoFile";
            }
        }
    }
}
