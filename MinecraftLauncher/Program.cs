using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

///////////////////////////////////////////
//               ATTENTION               //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//           WARNING NOT SECURE          //
//                                       //
//   To secure this programs encyption   //
//       change the string in line       //
// "private const string saltString = "" + defaultString; // Change the "" as needed. Uses only up to 16 characters."
//      to somthing else other than      //
//   "" to somthing like "mycustomsalt"  //
//                                       //
//           WARNING NOT SECURE          //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                       //
///////////////////////////////////////////

namespace ConsoleApplication1
{
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            // ACTIVE ON TESTING
            //if (maxLength == null) 
            //{
            //    maxLength = 5;
            //}
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }

    /////////////////////////////////////
    // Start - Advanced Console Methods
        public static class ConsoleAdv
        {
            /////////////////////////////////////
            // Start - ReadLine with options. (Bool = Hide Line with ****, String = "what is written before user input.")
                public static string ReadLine(bool readBool = false, string defaultS = "")
                {
                    string lineString = "";
                    if (defaultS != "")
                    {
                        if (readBool == true)
                        {
                            lineString = defaultS;
                            string passString = new string('*', defaultS.Length);
                            Console.Write(passString);
                        }
                        else
                        {
                            lineString = defaultS;
                            Console.Write(defaultS);
                        }
                    }
                    while (true) // Make into Method
                    {
                        var keyPress = Console.ReadKey(true);
                        if (keyPress.Key != ConsoleKey.Backspace && keyPress.Key != ConsoleKey.Enter)
                        {
                            lineString += keyPress.KeyChar;
                            if (readBool == true)
                            {
                                Console.Write("*");
                            }
                            else
                            {
                                Console.Write(keyPress.KeyChar);
                            }
                        }
                        else if (keyPress.Key == ConsoleKey.Backspace && lineString.Length > 0)
                        {
                            lineString = lineString.Substring(0, (lineString.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (keyPress.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                    return lineString;
                }
            // End --- ReadLine with options.
            /////////////////////////////////////
        }
    // End --- Advanced Console Methods
    /////////////////////////////////////

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
        // End --- Get Machine Id for Encrypt
        /////////////////////////////////////

        /////////////////////////////////////
        // Start - Combine IDs
            public static string uniqueMachineId()
            {
                return machineIDLookup() + machineIDLookup(true);
            }
        // End --- Combine IDs
        /////////////////////////////////////

        /////////////////////////////////////
        // Start - Encrypt Code
            // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
            // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
            // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
            private const string defaultSalt = "8dfn27c6vhd81j9s"; // Do not touch. Makes sure string is atleast 16 characters.
            private const string saltString = "" + defaultSalt; // Change the "" as needed. Uses only up to 16 characters.
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
        // End --- Encrypt Code
        /////////////////////////////////////
    }

    class Program
    {
        //Found this on Stack overflow with the relevant information i needed to start this.
        // Link = http://stackoverflow.com/questions/10440483/launch-jar-from-c-sharp
        // Might come in handy later.
        //
        //public static bool IsLinux
        //{
        //    get
        //    {
        //        int p = (int)Environment.OSVersion.Platform;
        //        return (p == 4) || (p == 6) || (p == 128);
        //    }
        //}

        /////////////////////////////////////
        // Start - File Usage

            // Input Code Here

        // End --- File Usage
        /////////////////////////////////////

        /////////////////////////////////////
        // Start - Console Code
            static void Main(string[] args)
            {
                /////////////
                // TEST CODE
                    if (false) // Change to true to run this code.
                    {
                        Console.WriteLine("");

                        Console.WriteLine("Your unique machine ID is:");
                        string stringMachineID = StringCipher.uniqueMachineId();
                        Console.WriteLine(stringMachineID);
                        string password = stringMachineID;
                        Console.WriteLine("");
                        Console.WriteLine("Please enter a string to encrypt:");
                        string plaintext = ConsoleAdv.ReadLine(true);
                        Console.WriteLine("");

                        Console.WriteLine("Your encrypted string is:");
                        string encryptedstring = StringCipher.Encrypt(plaintext, password);
                        Console.WriteLine(encryptedstring);
                        Console.WriteLine("");

                        Console.WriteLine("Your decrypted string is:");
                        string decryptedstring = StringCipher.Decrypt(encryptedstring, password);
                        Console.WriteLine(decryptedstring);
                        Console.WriteLine("");

                        Console.ReadLine();
                    }
                // TEST CODE
                /////////////

                /////////////////////////////////////
                // Start - Settings and Parameters
                    Console.CursorVisible = false;
                    // Accept all Certificats? // ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    string appData = Environment.GetEnvironmentVariable("APPDATA");
                    string inputError = "";
                // End --- Settings and Parameters
                /////////////////////////////////////

                /////////////////////////////////////
                // Start - Load AutoLogin

                    // Input Code Here

                // End --- Load AutoLogin
                /////////////////////////////////////

                /////////////////////////////////////
                // Start - Program Loop
                    while (true)
                    {
                        /////////////////////////////////////
                        // Start - Menu
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("  Choose an option");
                            Console.WriteLine("  [1] - Login to Minecraft");
                            Console.WriteLine("  [2] - Settings -- Unused");
                            Console.WriteLine("  [3] - Exit");
                            Console.WriteLine("");
                            Console.WriteLine("  " + inputError);
                            var userInput = Console.ReadKey();
                            Console.Clear();
                        // End --- Menu
                        /////////////////////////////////////

                        /////////////////////////////////////
                        // Start - Login to Minecraft
                            if (userInput.KeyChar == '1')
                            {
                                /////////////////////////////////////
                                // Start - Get Username
                                    Console.CursorVisible = true;
                                    Console.WriteLine("");
                                    Console.Write(" Username: ");
                                string userName = ConsoleAdv.ReadLine(defaultS:"PersonMan");
                                // End --- Get Username
                                /////////////////////////////////////

                                /////////////////////////////////////
                                // Start - Get Password
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.Write(" Password: ");
                                    string userPassw = ConsoleAdv.ReadLine(true);
                                    Console.Clear();
                                // End --- Get Password
                                /////////////////////////////////////

                                /////////////////////////////////////
                                // Start - Create URL
                                    string url = "https://login.minecraft.net/?user=" + userName + "&password=" + userPassw + "&version=13"; //Place username and password in to url before using it.
                                // End --- Create URL
                                /////////////////////////////////////

                                /////////////////////////////////////
                                // Start - Web Code, Unlearned, But it Works
                                // Gets Session Id and other strings from Minecraft
                                    string mcURLData;
                                    using (WebClient client = new WebClient()) // Get Data from Minecraft with username and password
                                    {
                                        try
                                        {
                                            mcURLData = client.DownloadString(url); // Is this already "HTTPS" compliant? Seems so. But i need to be sure.
                                        }
                                        catch
                                        {
                                            mcURLData = "noInternetMC";
                                        }
                                    }
                                // End --- Web Code
                                /////////////////////////////////////

                                /////////////////////////////////////
                                // Start - Check Minecraft Session Status
                                    Console.CursorVisible = false;
                                    bool userLogin = false;
                                    if (mcURLData.Contains(":"))
                                    {
                                        userLogin = true;
                                    }
                                    else if (mcURLData == "Bad login")
                                    {
                                        inputError = "Password or Username is incorrect.";
                                    }
                                    else if (mcURLData == "User not premium")
                                    {
                                        inputError = "You have not purchased Minecraft";
                                    }
                                    else if (mcURLData == "Account migrated, use e-mail as username.")
                                    {
                                        inputError = "Use your Email Address, not your username.";
                                    }
                                    else if (mcURLData == "noInternetMC")
                                    {
                                        inputError = "Cant connect to login.minecraft.net.";
                                    }
                                // End --- Check Minecraft Session Status
                                /////////////////////////////////////

                                /////////////////////////////////////
                                // Start - Run Minecraft
                                    if (userLogin == true)
                                    {
                                        string[] mcLoginData = mcURLData.Split(':');
                                        string mcName = mcLoginData[2];
                                        string mcSession = mcLoginData[3];
                                        Console.WriteLine("");
                                        Console.WriteLine("  Username: " + mcName); //Display Username
                                        Console.WriteLine(" SessionID: " + mcSession); //Display Session ID
                                        Console.WriteLine("");
                                        Console.WriteLine(" Login Successful!");
                                        Console.WriteLine("");
                                        Console.WriteLine(" Press any key to Start");
                                        var unusedVarb = Console.ReadKey();
                                        Process.Start("javaw", "-Xms512m -Xmx1024m -cp " + appData + @"\.minecraft\bin\* -Djava.library.path=" + appData + @"\.minecraft\bin\natives net.minecraft.client.Minecraft " + mcName + " " + mcSession);
                                        break;
                                    }
                                // End --- Run Minecraft
                                /////////////////////////////////////
                            }
                        // End --- Login to Minecraft
                        /////////////////////////////////////

                        /////////////////////////////////////
                        // Start - Close Program, Break Program Loop
                            else if (userInput.KeyChar == '3')
                            {
                                break;
                            }
                        // End --- Close Program, Break Program Loop
                        /////////////////////////////////////

                        /////////////////////////////////////
                        // Start - Option Doesnt Exsist
                            else
                            {
                                inputError = "Invalid Input: " + userInput.KeyChar;
                            }
                        // End --- Option Doesnt Exsist
                        /////////////////////////////////////

                    }
                // End --- Program Loop
                /////////////////////////////////////

            }
        // End --- Console Code
        /////////////////////////////////////
    }
}
