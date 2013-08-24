using System;
using System.Text;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace AtomLauncher
{

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //                                                             ATTENTION                                                            // 
    //                                            --!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!--                                           //
    //                                                        WARNING NOT SECURE                                                        //                                     //
    //                                                                                                                                  //
    //      To secure this programs encyption                                                                                           //
    //      change the string in line                                                                                                   //
    //      return "" + machineIDLookup() + machineIDLookup(true); // Change the "" as needed. (Strongest change)                       //
    //      or                                                                                                                          //
    //      private const string initVector = "" + "8dfn27c6vhd81j9s"; // Change the "" as needed. Uses only up to 16 characters.       //
    //      to somthing else other than                                                                                                 //
    //      "" to somthing like "mycustomsalt"                                                                                          //
    //                                                                                                                                  //
    //                                                        WARNING NOT SECURE                                                        //
    //                                            --!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!--                                           //
    //                                                                                                                                  //
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


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
