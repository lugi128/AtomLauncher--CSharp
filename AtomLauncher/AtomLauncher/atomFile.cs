using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AtomLauncher
{
    public class atomFile
    {
        /////////////////////////////////////
        // Start - File Usage
        
        // config File Location.
        public static string usersFile = @".\ALData";
        public static string conigFile = @".\ALConfig.alcfg";
        
        public void saveConfFile(string[] setArray)
        {
        }

        public Dictionary<string,string> loadConfFile()
        {
            var dict = new Dictionary<string, string>();
            dict["minecraft_location"] = Program.appData + @"\.minecraft" ;
            dict["minecraft_startRam"] = "512"; //"-Xms" + "512" + "m";
            dict["minecraft_maxRam"] = "1024"; //"-Xmx" + "1024" + "m";
            dict["minecraft_displayCMD"] = "False";
            dict["minecraft_onlineMode"] = "True";
            dict["minecraft_autoSelect"] = "True";
            dict["minecraft_force64Bit"] = "False"; //other wise use 32bit
            if (File.Exists(conigFile))
            {
                string[] getArray = File.ReadAllLines(conigFile);
                for (int i = 0; i < getArray.Length; i++)
                {
                    if (getArray[i] != "" && !getArray[i].StartsWith("[") && getArray[i].Contains("="))
                    {
                        string[] splitArray = getArray[i].Split('=');
                        dict[splitArray[0]] = splitArray[1];
                    }
                }
                return dict;
            }
            else
            {
                return dict;
            }
        }

        public static Dictionary<string,string> loadArgs(string[] tmpAryArg)
        {
            var dict = new Dictionary<string, string>();
            if (tmpAryArg.Length > 0)
            {
                foreach (string txt in tmpAryArg)
                {
                    string[] tempSplit = txt.Split(new char[] { '=' }, 2);
                    dict[tempSplit[0]] = tempSplit[1];
                }
            }
            //int defSplashTime = 1000;
            //if (!dict.ContainsKey("splashTime"))
            //{
            //    dict["splashTime"] = defSplashTime.ToString();
            //}
            //if (!Int32.TryParse(dict["splashTime"], out Program.splashTime))
            //{
            //    Program.splashTime = defSplashTime;
            //}
            return dict;
        }

        // Username, Password, File name (Usually @"./AEUsers"), game ("minecraft")
        // possible multiple logins idea, return multiple dictionarys with array
        // also look for name of login as well. before saving.
        public static void writeLoginFile(string accName, string accPass, string location, string game, bool auto)
        {
            string saveString = StringCipher.Encrypt(game + ":" + accName + ":" + accPass + ":" + auto.ToString(), StringCipher.uniqueMachineId());
            bool gameSaved = false;
            if (File.Exists(location))
            {
                string[] EncryptedStrings = File.ReadAllLines(location);
                for (int i = 0; i < EncryptedStrings.Length; i++)
                {
                    if (EncryptedStrings[i] != "")
                    {
                        string DecryptedString = StringCipher.Decrypt(EncryptedStrings[i], StringCipher.uniqueMachineId());
                        string[] lineArray = DecryptedString.Split(new char[] { ':' }, 4);
                        if (lineArray[0] == game && lineArray[1] == accName)
                        {
                            EncryptedStrings[i] = saveString;
                            gameSaved = true;
                        }
                    }
                }
                if (gameSaved == false)
                {
                    Array.Resize(ref EncryptedStrings, EncryptedStrings.Length + 1);
                    EncryptedStrings[EncryptedStrings.Length - 1] = saveString;
                }
                File.WriteAllLines(location, EncryptedStrings);
            }
            else
            {
                File.WriteAllText(location, saveString);
            }
        }

        public static void removeLoginLine(string location, string game, string accName)
        {
            if (File.Exists(location))
            {
                string[] EncryptedStrings = File.ReadAllLines(location);
                string[] NewEncryptedStrings = {""};
                int x = 0;
                for (int i = 0; i < EncryptedStrings.Length; i++)
                {
                    if (EncryptedStrings[i] != "")
                    {
                        string DecryptedString = StringCipher.Decrypt(EncryptedStrings[i], StringCipher.uniqueMachineId());
                        string[] lineArray = DecryptedString.Split(new char[] { ':' }, 4);
                        if (lineArray[0] == game && lineArray[1] == accName)
                        {
                            x++;
                        }
                        else
                        {
                            if (i - x >= NewEncryptedStrings.Length)
                            {
                                Array.Resize(ref NewEncryptedStrings, NewEncryptedStrings.Length + 1);
                            }
                            NewEncryptedStrings[i - x] = EncryptedStrings[i];
                        }
                    }
                    else
                    {
                        x++;
                    }
                }
                File.WriteAllLines(location, NewEncryptedStrings);
            }
        }

        public static string[,] readLoginFileAll(string game, string location)
        {
            string[] lineArray = { "false" };
            string[,] multiLineA = { { "false", "false", "false", "false" } };
            int y = 4;
            if (File.Exists(location))
            {
                string[] EncryptedStrings = File.ReadAllLines(location);
                for (int x = 0; x < EncryptedStrings.Length; x++)
                {
                    if (EncryptedStrings[x] != "")
                    {
                        string DecryptedString = StringCipher.Decrypt(EncryptedStrings[x], StringCipher.uniqueMachineId());
                        lineArray = DecryptedString.Split(new char[] { ':' }, 4);
                        if (lineArray[0] == game)
                        {
                            for (int i = 0; i < lineArray.Length; i++)
                            {
                                if (x >= multiLineA.GetLength(0))
                                {
                                    int z = multiLineA.GetLength(0) + 1;
                                    ResizeArray(ref multiLineA, z, y);
                                }
                                multiLineA[x, i] = lineArray[i];
                            }
                        }
                    }
                }
            }
            return multiLineA;
        }

        public static string[] readLoginFileUser(string game, string location, string accName)
        {
            string[] lineArray = { "false" };
            if (File.Exists(location))
            {
                string[] EncryptedStrings = File.ReadAllLines(location);
                for (int x = 0; x < EncryptedStrings.Length; x++)
                {
                    if (EncryptedStrings[x] != "")
                    {
                        string DecryptedString = StringCipher.Decrypt(EncryptedStrings[x], StringCipher.uniqueMachineId());
                        lineArray = DecryptedString.Split(new char[] { ':' }, 4);
                        if (lineArray[0] == game && lineArray[1] == accName)
                        {
                            break;
                        }
                    }
                }
            }
            return lineArray;
        }

        public static void ResizeArray(ref string[,] Arr, int x, int y)
        {
            string[,] _arr = new string[x, y];
            int minRows = Math.Min(x, Arr.GetLength(0));
            int minCols = Math.Min(y, Arr.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    _arr[i, j] = Arr[i, j];
            Arr = _arr;
        }



        // End
        /////////////////////////////////////
    }
}
