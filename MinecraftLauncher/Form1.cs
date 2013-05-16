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


///////////////////////////////////////////////
//                 ATTENTION                 //
//--!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!--//
//             WARNING NOT SECURE            //
//                                           //
//     To secure this programs encyption     //
//         change the string in line         //
// private const string saltString = "" + "8dfn27c6vhd81j9s"; // Change the "" as needed. Uses only up to 16 characters.
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
    // Start - File Usage
        public partial class Form1 : Form
        {
            /////////////////////////////////////
            // Start - Settings and Parameters
            // Accept all Certificats? // ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                string appData = Environment.GetEnvironmentVariable("APPDATA");
            // End
            /////////////////////////////////////

            /////////////////////////////////////
            // Start - File Usage

                // -------
                // Input Code Here
                // -------

            // End
            /////////////////////////////////////

            /////////////////////////////////////
            // Start - Auto Login

                // -------
                // Input Code Here, Need File usage first.
                // -------

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

                }
            // End
            /////////////////////////////////////

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
                    startButton();
                }
            }

            public string mcName = "";
            public string mcSession = "";

            /////////////////////////////////////
            // Start - Login Button Code
                private void loginButton_Click(object sender, EventArgs e) // It also freezes until web connect is done. I wonder if thats fixable.
                {
                    textError.Text = "Connecting..."; //Why doesnt this show up? - If there is a delay?
                    string userName = tbUsername.Text;
                    string userPass = tbPassword.Text;
            
                    /////////////////////////////////////
                    // Start - Create URL
                        string url = "https://login.minecraft.net/?user=" + userName + "&password=" + userPass + "&version=13"; //Place username and password in to url before using it.
                    // End
                    /////////////////////////////////////

                    /////////////////////////////////////
                    // Start - Web Code, Unlearned, But it Works
                    // Gets Session Id and other strings from Minecraft
                        string mcURLData = "";
                        using (WebClient client = new WebClient()) // Get Data from Minecraft with username and password
                        {
                            try
                            {
                                mcURLData = client.DownloadString(url); // Is this already "HTTPS" compliant? Seems so. But i need to be sure.
                            }
                            catch
                            {
                                textError.Text = "Cant connect to login.minecraft.net.";
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
                            textSession.Text = mcSession;
                            textUsername.Text = mcName;
                            textError.Text = "Seccessful Login";
                            startButton.Enabled = true;
                        }
                        else
                        {
                            textError.Text = mcURLData;
                        }
                    // End
                    /////////////////////////////////////
                }
            // End
            /////////////////////////////////////

            /////////////////////////////////////
            // Start - Start Button Code
                public void startButton_Click(object sender, EventArgs e)
                {
                    Process.Start("javaw", "-Xms512m -Xmx1024m -cp " + appData + @"\.minecraft\bin\* -Djava.library.path=" + appData + @"\.minecraft\bin\natives net.minecraft.client.Minecraft " + mcName + " " + mcSession);
                    this.Close();
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
                    return machineIDLookup() + machineIDLookup(true);
                }
            // End
            /////////////////////////////////////

            /////////////////////////////////////
            // Start - Encrypt Code
                // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
                // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
                // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
                private const string saltString = "" + "8dfn27c6vhd81j9s"; // Change the "" as needed. Uses only up to 16 characters.
                private static string initVector = saltString.Truncate(16); // Makes sure the string is limited to 16 characters.

                // This constant is used to determine the keysize of the encryption algorithm.
                private const int keysize = 256;

                public static string Encrypt(string plainText, string passPhrase)
                {
                    byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
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
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
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