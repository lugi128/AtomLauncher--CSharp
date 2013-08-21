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

namespace AtomLauncher
{
    public partial class Launcher
    {
        WebClient aD_webClient;    // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        Stopwatch tw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        public string aD_fileName = "GameDownload.rar";
        public string aD_webLocation = "http://trinaryatom.com/_web_downloads/";
        public string aD_saveLocation = @".\";

        public void aD_DownloadFileArray(string urlAddress, string location)
        {
            tw.Reset();
            using (aD_webClient = new WebClient())
            {
                aD_webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(aD_Completed);
                aD_webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(aD_ProgressChanged);
                
                try
                {
                    // The variable that will be holding the url address
                    Uri URL;
                    // Make sure the url starts with "http://"
                    if (!urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                    {
                        URL = new Uri("http://" + urlAddress);
                    }
                    else
                    {
                        URL = new Uri(urlAddress);
                    }
                    //while (l < i)
                    //{
                    //    sw.Start(); // Start the stopwatch which we will be using to calculate the download speed
                    //    aD_webClient.DownloadFileAsync(URL, location); // Start downloading the file
                    //    while (homeBarTop.Value < 100) // Wait for Complete File
                    //    {
                    //        Thread.Sleep(1000);
                    //    }
                    //    Thread.Sleep(1000);
                    //    sw.Reset();
                    //    l++;
                    //    homeBarTop.Value = 0;
                    //}

                }
                catch (Exception ex)
                {
                    //not working? Exception not working.
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void aD_DownloadFile(string urlAddress, string location)
        {
            sw.Reset();
            using (aD_webClient = new WebClient())
            {
                aD_webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(aD_Completed);
                aD_webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(aD_ProgressChanged);

                try
                {
                    // The variable that will be holding the url address
                    Uri URL;

                    // Make sure the url starts with "http://"
                    if (!urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                    {
                        URL = new Uri("http://" + urlAddress);
                    }
                    else
                    {
                        URL = new Uri(urlAddress);
                    }

                    // Start the stopwatch which we will be using to calculate the download speed
                    sw.Start();

                    // Start downloading the file
                    aD_webClient.DownloadFileAsync(URL, location);

                }
                catch (Exception ex)
                {
                    //not working? Exception not working.
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void aD_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                if (aD_cancel == true)
                {
                    this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Canceled"; })); //Error
                    aD_webClient.CancelAsync();
                }
                else
                {
                    if (e.ProgressPercentage != 100) // prevents this from Accidentally running aD_Completed is triggered.
                    {
                        // Calculate download speed and output it to label3
                        if (homeLabelBottom.Text != (Convert.ToDouble(e.BytesReceived) / 1024 / sw.Elapsed.TotalSeconds).ToString("0"))
                            this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = (Convert.ToDouble(e.BytesReceived) / 1024 / sw.Elapsed.TotalSeconds).ToString("0.00") + " kb/s"; }));

                        // Update the progressbar percentage only when the value is not the same (to avoid updating the control constantly)
                        if (homeBarTop.Value != e.ProgressPercentage)
                            this.Invoke(new MethodInvoker(delegate { homeBarTop.Value = e.ProgressPercentage; }));

                        // Show the percentage on our label (update only if the value isn't the same to avoid updating the control constantly)
                        if (homeLabelBottom.Text != e.ProgressPercentage.ToString() + "%")
                            this.Invoke(new MethodInvoker(delegate { homeLabelBottom.Text = e.ProgressPercentage.ToString() + "%";}));

                        // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
                        this.Invoke(new MethodInvoker(delegate { homeLabelBar.Text = (Convert.ToDouble(e.BytesReceived) / 1024 / 1024).ToString("0.00") + " Mb's" + "  /  " + (Convert.ToDouble(e.TotalBytesToReceive) / 1024 / 1024).ToString("0.00") + " Mb's"; }));
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
            sw.Reset();
            if (e.Cancelled == true)
            {
                File.Delete(@"./GameDownload.rar");       // Delete the incomplete file if the download is canceled
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Canceled"; })); //Error
            }
            else if (e.Error != null)
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = e.Error.Message; })); //Error
            }
            else
            {
                if (homeBarTop.Value != 100)
                {
                    this.Invoke(new MethodInvoker(delegate { homeBarTop.Value = 100; }));
                }
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Completed"; }));
            }
        }
    }
}
