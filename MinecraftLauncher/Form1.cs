using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;



///////////////////////////////////////////////
//                 ATTENTION                 //
//--!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!--//
//             WARNING NOT SECURE            //
//                                           //
//     To secure this programs encyption     //
//         change the string in line         //
// return "" + machineIDLookup() + machineIDLookup(true); // Change the "" as needed. (Strongest change)
//                     or                    //
// private const string initVector = "" + "8dfn27c6vhd81j9s"; // Change the "" as needed. Uses only up to 16 characters.
//        to somthing else other than        //
//     "" to somthing like "mycustomsalt"    //
//                                           //
//             WARNING NOT SECURE            //
//--!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!--//
//                                           //
///////////////////////////////////////////////

namespace MinecraftLauncher
{

    /////////////////////////////////////
    // Start - Minecraft Launcher
        public partial class Form1 : Form
        {
            /////////////////////////////////////
            // Start - Settings and Parameters
                string appData = Environment.GetEnvironmentVariable("APPDATA");
                Form2 frm2 = new Form2();
                public bool stopAutoLogin = false;
                public string mcName = "";
                public string mcSession = "";
                public bool userLoggedIn = false;
                public string usersFile = @"./AEUsers";
            // End
            /////////////////////////////////////

            /////////////////////////////////////
            // Start - Required Code

                public Form1()
                {
                    InitializeComponent();
                }

                private void Form1_Load(object sender, EventArgs e)
                {
                    checkAutoLogin.Checked = Properties.Settings.Default.ALogin;

                    if (File.Exists(usersFile))
                    {
                        checkLogin.Checked = true;
                        ReadLoginFromFile();
                    }
                    if (checkAutoLogin.Checked == true)
                    {
                        Thread a = new Thread(autoLogin);          // Kick off a new thread
                        a.IsBackground = true;
                        a.Start();
                    }
                }
            // End
            /////////////////////////////////////

            /////////////////////////////////////
            // Start - The Links between threads and Form Controls
                delegate void SetTextDelegate(string value);

                public void SetErrorText(string value)
                {
                    if (InvokeRequired)
                        Invoke(new SetTextDelegate(SetErrorText), value);
                    else
                        textError.Text = value;
                }
                public void SetButtonText(string value)
                {
                    if (InvokeRequired)
                        Invoke(new SetTextDelegate(SetButtonText), value);
                    else
                        startButton.Text = value;
                }
                public void setDebugSession(string value)
                {
                    if (InvokeRequired)
                        Invoke(new SetTextDelegate(setDebugSession), value);
                    else
                        frm2.debugTextSession = value;
                }
                public void setDebugName(string value)
                {
                    if (InvokeRequired)
                        Invoke(new SetTextDelegate(setDebugName), value);
                    else
                        frm2.debugTextUsername = value;
                }
            // End
            /////////////////////////////////////

            /////////////////////////////////////
            // Start - Form Controls
                private void startButton_Click(object sender, EventArgs e)
                {
                    if (startButton.Text == "Cancel")
                    {
                        stopAutoLogin = true;
                    }
                    else
                    {
                        loginStart();
                    }
                }

                private void exitToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    this.Close();
                }

                private void debugToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    frm2.Show();
                }
                private void tbUsername_KeyDown(object sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        tbPassword.Focus();
                        e.Handled = true;
                    }
                }

                private void tbPassword_KeyDown(object sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        e.Handled = true;
                        startButton.Focus();
                        startButton_Click(sender, e);
                    }
                }

                //Threading Freindly Methods
                delegate void SetContDelegate(bool value);

                private void enableControls(bool value)
                {
                    if (InvokeRequired)
                        Invoke(new SetContDelegate(enableControls), value);
                    else
                        menuToolStripMenuItem.Enabled = value;
                    tbUsername.Enabled = value;
                    tbPassword.Enabled = value;
                    checkAutoLogin.Enabled = value;
                    checkLogin.Enabled = value;
                }
                private void startControl(bool value)
                {
                    if (InvokeRequired)
                        Invoke(new SetContDelegate(startControl), value);
                    else
                        startButton.Enabled = value;
                }
            // End
            /////////////////////////////////////

            /////////////////////////////////////
            // Start - File Usage
                void WriteLoginToFile()
                {
                    Properties.Settings.Default.ALogin = checkAutoLogin.Checked;
                    Properties.Settings.Default.Save();
                    string CombinedString = tbUsername.Text + ":" + tbPassword.Text;
                    string EncryptedString = StringCipher.Encrypt(CombinedString, StringCipher.uniqueMachineId());
                    System.IO.File.WriteAllText(usersFile, EncryptedString);
                }

                void ReadLoginFromFile()
                {
                    string EncryptedString = System.IO.File.ReadAllText(usersFile);
                    string DecryptedString = StringCipher.Decrypt(EncryptedString, StringCipher.uniqueMachineId());
                    string[] StringArray = DecryptedString.Split(new char[] { ':' }, 3);
                    tbUsername.Text = StringArray[0];
                    tbPassword.Text = StringArray[1];
                }
            // End
            /////////////////////////////////////

			private void loginStart()
			{
				if (userLoggedIn)
				{
                    if (frm2.debugCheckMinecraft == false)
                    {
                        Process.Start("javaw", "-Xms512m -Xmx1024m -cp " + appData + @"\.minecraft\bin\* -Djava.library.path=" + appData + @"\.minecraft\bin\natives net.minecraft.client.Minecraft " + mcName + " " + mcSession);
                        this.Close();
                    }
                    else
                    {
                        SetErrorText("Debug Enabled.");
                    }
				}
				else
				{
					Thread t = new Thread(webLogin);          // Kick off a new thread
					t.IsBackground = true;
					t.Start();
				}
			}

            private void autoLogin()
            {
                enableControls(false);
                SetButtonText("Cancel");
                int timeSeconds = 5;
                int loginAttempts = 1;
                int c = 0;
                while (true)
                {
                    if (loginAttempts > 1)
                    {
                        SetErrorText("Attempt " + loginAttempts + ". Auto Login in " + timeSeconds + ".");
                    }
                    else
                    {
                        SetErrorText("Auto Login in " + timeSeconds + ".");
                    }
                    System.Threading.Thread.Sleep(1000);
                    if (stopAutoLogin == true || userLoggedIn == true)
                    {
                        enableControls(true);
                        SetErrorText("Auto Login Canceled");
                        SetButtonText("Login");
                        break;
                    }
                    if (c >= timeSeconds & stopAutoLogin != true)
                    {
                        webLogin();
                        if (userLoggedIn)
                        {
                            SetButtonText("Start");
                            this.Invoke(new Action(() => { startButton.PerformClick(); }));
                        }
                        loginAttempts++;
                        timeSeconds = 5;
                        if (loginAttempts > 5)
                        {
                            enableControls(true);
                            SetErrorText("Auto Login Canceled. Max Attempts Reached.");
                            SetButtonText("Login");
                            break;
                        }
                    }
                    else
                    {
                        timeSeconds--;
                    }
                }
            }


            /////////////////////////////////////
            // Start - Get Login Session from Minecraft.
                private Object threadLock = new Object();

                private void webLogin()
                {
                    if (!Monitor.TryEnter(threadLock)) //Lock to only one Thread at a time.
                    {
                        SetErrorText("CONNECTING!!?.. patience, :)");
                        return;
                    }
                    try
                    {
                    SetErrorText("Connecting...");
                    string userName = tbUsername.Text;
                    string userPass = tbPassword.Text;
                    /////////////////////////////////////
                    // Start - Web Code, Unlearned, But it Works
                    // Gets Session Id and other strings from Minecraft
                        string mcURLData = "WebClient Code Error";
                        using (WebClient client = new WebClient()) // Get Data from Minecraft with username and password
                        {
                            try
                            {
                                System.Collections.Specialized.NameValueCollection urlData = new System.Collections.Specialized.NameValueCollection();
                                urlData.Add("user", userName);
                                urlData.Add("password", userPass);
                                urlData.Add("version", "13");
                                byte[] responsebytes = client.UploadValues("https://login.minecraft.net", "POST", urlData);
                                mcURLData = Encoding.UTF8.GetString(responsebytes);
                                SetErrorText("Test...");
                            }
                            catch
                            {
                                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                                {
                                    mcURLData = "Internet Disconnected.";
                                }
                                else
                                {
                                    mcURLData = "Can't connect to login.minecraft.net.";
                                }
                            }
                        }
                    // End
                    /////////////////////////////////////

                    /////////////////////////////////////
                    // Start - Check Minecraft Session Status
                        if (mcURLData.Contains(":"))
                        {
                            string[] mcLoginData = mcURLData.Split(':');
                            mcName = mcLoginData[2];
                            mcSession = mcLoginData[3];
                            //Possible Error
                            setDebugSession(mcSession);
                            setDebugName(mcName);
                            SetErrorText("Successful Login");
                            SetButtonText("Start");
                            userLoggedIn = true;
                            if (checkLogin.Checked == true)
                            {
                                WriteLoginToFile();
                            }
                            else if (File.Exists(usersFile))
                            {
                                File.Delete(usersFile);
                            }
                        }
                        else
                        {
                            SetErrorText(mcURLData);
                        }
                    // End
                    /////////////////////////////////////
                    }
                    finally
                    {
                        Monitor.Exit(threadLock); //Unlock for use of other threads.
                    }
                }
            // End
            /////////////////////////////////////
        }
    // End
    /////////////////////////////////////
}