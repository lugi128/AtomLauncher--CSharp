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
                        if (userLoggedIn)
                        {
                            if (frm2.Visible != true || frm2.debugCheckMinecraft == false)
                            {
                                Process.Start("javaw", "-Xms512m -Xmx1024m -cp " + appData + @"\.minecraft\bin\* -Djava.library.path=" + appData + @"\.minecraft\bin\natives net.minecraft.client.Minecraft " + mcName + " " + mcSession);
                                this.Close();
                            }
                        }
                        else
                        {
                            Thread t = new Thread(webLogin);          // Kick off a new thread
                            t.IsBackground = true;
                            t.Start();
                        }
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
                    string CombinedString = tbUsername.Text + ":" + tbPassword.Text + ":" + checkAutoLogin.Checked;
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
                    try
                    {
                        checkAutoLogin.Checked = Convert.ToBoolean(StringArray[2]);
                    }
                    catch
                    {
                        SetErrorText("Account Data, Refreshed.");
                        WriteLoginToFile();
                    }
                }
            // End
            /////////////////////////////////////


            private void autoLogin()
            {
                enableControls(false);
                SetButtonText("Cancel");
                int timeSeconds = 5;
                int c = 0;
                while (true)
                {
                    SetErrorText("Auto Login: " + timeSeconds);
                    System.Threading.Thread.Sleep(1000);
                    if (stopAutoLogin == true)
                    {
                        enableControls(true);
                        SetErrorText("Auto Login Canceled");
                        SetButtonText("Login");
                        break;
                    }
                    if (c >= timeSeconds & stopAutoLogin != true)
                    {
                        startControl(false);
                        SetButtonText("Login");
                        webLogin();
                        startControl(true);
                        this.Invoke(new Action(() => { startButton.PerformClick(); }));
                        break;
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
                        SetErrorText("Error:CONNECTING!!?.. patience, :)");
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

    /////////////////////////////////////
    // Start - 'string' Extensions. Example: randomString.Truncate(4)
        public static class StringExt
        {
            public static string Truncate(this string value, int maxLength)
            {
                return value.Length <= maxLength ? value : value.Substring(0, maxLength);
            }
        }
    // End
    /////////////////////////////////////

    /////////////////////////////////////
    // Start - Encrypt Section
        public static class StringCipher
        {
            /////////////////////////////////////
            // Start - Get Machine Id for Encrypt
                public static string machineIDLookup(bool reqHardware = false)
                {
                    string theHardware = "BaseBoard";
                    if (reqHardware == false)
                    {
                        theHardware = "DiskDrive";
                    }
                    StringBuilder builder = new StringBuilder();
                    String query = "SELECT * FROM Win32_" + theHardware;
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                    foreach (ManagementObject item in searcher.Get())
                    {
                        Object obj = item["SerialNumber"];
                        builder.Append(Convert.ToString(obj));
                    }
                    string builtString = builder.ToString();
                    builtString = Regex.Replace(builtString, "[^a-z0-9A-Z]", "");
                    builtString = builtString.ToLower();

                    return builtString;
                }
            // End
            /////////////////////////////////////

            /////////////////////////////////////
            // Start - Combine IDs
                public static string uniqueMachineId()
                {
                    return "" + machineIDLookup() + machineIDLookup(true); // Change the "" as needed. (Strongest change)
                }
            // End
            /////////////////////////////////////

            ////////////////////
            ////////////////////////////////////////
            // Section below is code that was extracted from other online sources and changed to work here.
            // The below code is slightly unknown.
            ////////////////////////////////////////
            ////////////////////

            /////////////////////////////////////
            // Start - Encrypt Code
                // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
                // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
                // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
                private const string initVector = "" + "8dfn27c6vhd81j9s"; // Change the "" as needed. Uses only up to 16 characters.
                private const int vectorInt = 16; // Max Character length of string. Don,t change unless you know what your doing.

                // This constant is used to determine the keysize of the encryption algorithm.
                private const int keysize = 256;

                public static string Encrypt(string plainText, string passPhrase)
                {
                    byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector.Truncate(vectorInt));
                    byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                    PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    RijndaelManaged symmetricKey = new RijndaelManaged();
                    symmetricKey.Mode = CipherMode.CBC;
                    ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                    MemoryStream memoryStream = new MemoryStream();
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    byte[] cipherTextBytes = memoryStream.ToArray();
                    memoryStream.Close();
                    cryptoStream.Close();
                    return Convert.ToBase64String(cipherTextBytes);
                }

                public static string Decrypt(string cipherText, string passPhrase)
                {
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector.Truncate(vectorInt));
                    byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                    PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    RijndaelManaged symmetricKey = new RijndaelManaged();
                    symmetricKey.Mode = CipherMode.CBC;
                    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                    MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                    memoryStream.Close();
                    cryptoStream.Close();
                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                }
            // End
            /////////////////////////////////////
        }
    // End
    /////////////////////////////////////
}