using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.IO.Compression;
using System.Threading;

namespace AtomLauncher
{
    class atomFileData
    {
        internal static string configFile = @"ALConfig.alcfg";
        internal static string addServLoc = @"AdditionalApps";
        public static Dictionary<string, string> config;
        public static Dictionary<string, Dictionary<string, string[]>> defaultDict = new Dictionary<string, Dictionary<string, string[]>>{
                {
                    "Minecraft", new Dictionary<string, string[]> { 
                        { "appType",        new string[] { "Minecraft" } }, //Used to Reference Defaults
                        { "servApp",        new string[] { "False" } },
                        { "location",       new string[] { atomProgram.appData + @"\.minecraft" } },
                        { "workingDirect",  new string[] { "" } },
                        { "CPUPriority",    new string[] { "Normal" } },
                        { "thumbnailLoc",   new string[] { "" } },
                        { "saveLoc",        new string[] { atomProgram.appData + @"\.minecraft" } },
                        { "startRam",       new string[] { "512" } },
                        { "maxRam",         new string[] { "1024" } },
                        { "displayCMD",     new string[] { "False" } },
                        { "autoLoginUser",  new string[] { "" } },
                        { "onlineMode",     new string[] { "True" } },
                        { "offlineName",    new string[] { "Player" } },
                        { "selectVer",      new string[] { "Latest: Recommended" } },
                        { "autoSelect",     new string[] { "True" } },
                        { "showDev",        new string[] { "False" } },
                        { "showBeta",       new string[] { "False" } },
                        { "showAlpha",      new string[] { "False" } },
                        { "force64Bit",     new string[] { "False" } }
                    } 
                },
                {
                    "General", new Dictionary<string, string[]> { 
                        { "appType",        new string[] { "General" } },
                        { "servApp",        new string[] { "False" } },
                        { "location",       new string[] { "" } },
                        { "workingDirect",  new string[] { "" } },
                        { "arguments",      new string[] { "" } },
                        { "autoLoginUser",  new string[] { "" } },
                        { "CPUPriority",    new string[] { "Normal" } },
                        { "thumbnailLoc",   new string[] { "" } }
                    } 
                }
            };

        /// <summary>
        /// Return defaults for the config file or Dictonary config.
        /// </summary>
        /// <param name="app">Select the the title for the config to load.</param>
        /// <returns>Return defaults for the config file or Dictonary config.</returns>
        internal static Dictionary<string, string> loadConfDefaults()
        {
            Dictionary<string, string> dict = new Dictionary<string, string> {
                {"lastSelectedApp", ""},
                {"changeFont", "false"},
                {"autoLoginTime", "5"},
                {"launcherBackground", ""},
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Change this to suite your needs.
                    // Change it to @"" for it to ignore updateing.
                    // Or, in the config file change the version to some high number, like 999.0.0.0
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    {"updateURL", @""},
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // This launcher is looking for a version number and a download url from the launcherUpdateURL
                    // If there is a URL present it will only require the version number. Feel free to add the rest, in order, at your leasure.
                    // Version:::ChangeLog:::DownloadURL
                    // 0.0.0.0:::http://www.downloadurl.com:::http://www.siteurl.com/download
                    // MajorChange.StandardAdd.MinorAdd.BugFix
                    // The version number is controlled by the properties window. (The config file, if present, overwrites it).
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                {"launcherVersion", Assembly.GetExecutingAssembly().GetName().Version.ToString()},
                {"dataLocation", Path.GetDirectoryName(atomProgram.appDirectoryFile) + @"\"},
                {"userDataName", "ALUData"},
                {"appDataName", "ALAData"}
                //{"debug", "false"} Unused
            };
            return dict;
        }
        /// <summary>
        /// Load the config file. If none, load defaults.
        /// </summary>
        /// <param name="location">Location of config file Example: "C:\LOCATION\file.config"</param>
        /// <returns>Returns the loaded config file.</returns>
        internal static Dictionary<string, string> loadConfFile(string pathFile)
        {
            var dict = new Dictionary<string, string>();
            dict = loadConfDefaults();
            if (File.Exists(pathFile))
            {
                string[] getArray = File.ReadAllLines(pathFile);
                for (int i = 0; i < getArray.Length; i++)
                {
                    if (getArray[i] != "" && getArray[i].Contains("=") && !getArray[i].StartsWith(";") && !getArray[i].StartsWith("["))
                    {
                        string[] splitArray = getArray[i].Split(new string[] { "=" }, 2, StringSplitOptions.None);
                        dict[splitArray[0]] = splitArray[1];
                    }
                }
            }
            return dict;
        }
        /// <summary>
        /// Save the the dictonary to a config file.
        /// </summary>
        /// <param name="location">Location to save to. Example: "C:\LOCATION\file.config"</param>
        /// <param name="dict">Input a dictonary of "string, string" here </param>
        internal static void saveConfFile(string pathFile, Dictionary<string, string> dict)
        {
            string[] setArray = { "" };
            int x = 0;
            foreach (KeyValuePair<string, string> entry in dict)
            {
                if (x > setArray.Length - 1)
                {
                    Array.Resize(ref setArray, setArray.Length + 1);
                }
                setArray[x] = entry.Key + "=" + entry.Value;
                x++;
            }
            File.WriteAllLines(pathFile, setArray);
        }

        public static Dictionary<int, string[]> fileCheck(Dictionary<int, string[]> dict, string location)
        {
            Dictionary<int, string[]> tmpDict = new Dictionary<int, string[]>();
            int l = 0;
            int x = 0;
            while (l < dict.Count)
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Checking Files");
                if (File.Exists(location + @"\" + dict[l][1]))
                {
                    //Dev//
                    //string localChecksum = "ff344e7bc6007fade349565d545fd3e7"; //Development Temp.
                    //string fileChecksum = "";
                    //using (var md5 = MD5.Create())
                    //{
                    //    using (var stream = File.OpenRead(location + @"\" + urlAddress[l][2] + @"\" + urlAddress[l][1]))
                    //    {
                    //        fileChecksum = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                    //    }
                    //}
                    //if (l == 1)
                    //{
                    //    if (fileChecksum != localChecksum)
                    //    {
                    //        doSkip = true;
                    //        tmpDict.Add(x, urlAddress[l]);
                    //        x++;
                    //    }
                    //}
                }
                else
                {
                    tmpDict.Add(x, dict[l]);
                    x++;
                }
                l++;
            }
            return tmpDict;
        }

        /// <summary>
        /// Load and set the App Data and Settings
        /// </summary>
        /// <param name="pathFile">Set this to the file that stores the data.</param>
        /// <param name="defaultApp">Input app you wish to reset. If this is set, it will not load from file. It requires a dictonary to be input.</param>
        /// <param name="returnDict">Input dictonary to be parsed and defaults set for a specific app.</param>
        /// <param name="appType">Input the name to get the defaults of.</param>
        /// <returns></returns>
        internal static Dictionary<string, Dictionary<string, string[]>> getAppData(string pathFile, string defaultApp = "", Dictionary<string, Dictionary<string, string[]>> returnDict = null, string appType = "")
        {
            if (defaultApp != "")
            {
                if (returnDict == null)
                {
                    throw new System.Exception("Error: Need a Dictonary to set defaults for " + defaultApp);
                }
                if (appType == "")
                {
                    throw new System.Exception("Error: Select App Type");
                }
                returnDict[defaultApp] = defaultDict[appType];
                return returnDict;
            }
            else
            {
                Dictionary<string, Dictionary<string, string[]>> loadedDict = new Dictionary<string, Dictionary<string, string[]>>();
                if (File.Exists(pathFile))
                {
                    loadedDict = loadDictonary(pathFile);

                    foreach (KeyValuePair<string, Dictionary<string, string[]>> app in loadedDict)
                    {
                        foreach (KeyValuePair<string, string[]> item in defaultDict[app.Value["appType"][0]])
                        {
                            if (!loadedDict[app.Key].ContainsKey(item.Key))
                            {
                                loadedDict[app.Key][item.Key] = item.Value;
                            }
                        }
                    }
                }
                return loadedDict;
            }
        }
        internal static Dictionary<string, Dictionary<string, string[]>> getSerApps(string pathFolder, Dictionary<string, Dictionary<string, string[]>> returnDict)
        {
            if (File.Exists(pathFolder))
            {
                Dictionary<string, Dictionary<string, string[]>> loadedDict = loadDictonary(pathFolder);
                foreach (KeyValuePair<string, Dictionary<string, string[]>> app in loadedDict)
                {
                    if (!returnDict.ContainsKey(app.Key))
                    {
                        returnDict.Add(app.Key, app.Value);
                    }
                    else
                    {
                        returnDict[app.Key] = app.Value;
                    }
                    foreach (KeyValuePair<string, string[]> item in defaultDict[app.Value["appType"][0]])
                    {
                        if (!returnDict[app.Key].ContainsKey(item.Key))
                        {
                            returnDict[app.Key][item.Key] = item.Value;
                        }
                    }
                }
            }
            return returnDict;
        }
        internal static Dictionary<string, Dictionary<string, string[]>> getUserData(string pathFile)
        {
            Dictionary<string, Dictionary<string, string[]>> loadedDict = new Dictionary<string, Dictionary<string, string[]>>();//{
            //    {
            //        "Minecraft", new Dictionary<string, string[]> { 
            //            { "UserName", new string[] {"Encrypted Password", "Propper Username", "Last Saved Date and Time", "Access Token", "Client Token", "Universally Unique Identifier"} }
            //        } 
            //    }
            //};
            if (File.Exists(pathFile))
            {
                loadedDict = loadDictonary(pathFile, true);
            }
            return loadedDict;
        }
        
        /// <summary>
        /// Save the programs Dictonary
        /// </summary>
        /// <param name="pathFile">The save location and file name.</param>
        /// <param name="data">The input dictonary</param>
        /// <param name="arrayThree">The Format of the dictonary to save. UserData is true. AppData is false</param>
        internal static void saveDictonary(string pathFile, Dictionary<string, Dictionary<string, string[]>> inData, bool arraySix = false)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pathFile));
                using (var file = File.Create(pathFile))
                using (var deflate = new DeflateStream(file, CompressionMode.Compress))
                using (var writer = new BinaryWriter(deflate))
                {
                    writer.Write(inData.Count);
                    foreach (var pair in inData)
                    {
                        writer.Write(pair.Key);
                        writer.Write(pair.Value.Count);
                        foreach (var subpair in pair.Value)
                        {
                            writer.Write(subpair.Key);
                            writer.Write(subpair.Value[0]);
                            if (arraySix)
                            {
                                writer.Write(subpair.Value[1]);
                                writer.Write(subpair.Value[2]);
                                writer.Write(subpair.Value[3]);
                                writer.Write(subpair.Value[4]);
                                writer.Write(subpair.Value[5]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nPerhaps set program to run as Adminstrator?", "Saveing Data Error");
            }
        }
        /// <summary>
        /// Reads the saved dictonary.
        /// </summary>
        /// <param name="pathFile">The read location and file name.</param>
        /// <param name="arrayThree">The Format of the dictonary to read. UserData is true. AppData is false</param>
        /// <returns></returns>
        internal static Dictionary<string, Dictionary<string, string[]>> loadDictonary(string pathFile, bool arraySix = false)
        {
            using (var file = File.OpenRead(pathFile))
            using (var deflate = new DeflateStream(file, CompressionMode.Decompress))
            using (var reader = new BinaryReader(deflate))
            {
                int count = reader.ReadInt32();
                var data = new Dictionary<string, Dictionary<string, string[]>>(count);
                while (count-- > 0)
                {
                    Dictionary<string, string[]> subdata = new Dictionary<string, string[]>();
                    string stringDict = reader.ReadString();
                    int subCount = reader.ReadInt32();
                    while (subCount-- > 0)
                    {
                        if (arraySix) 
                        {
                            subdata.Add(reader.ReadString(), new string[] { reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString() });
                        }
                        else 
                        { 
                            subdata.Add(reader.ReadString(), new string[] { reader.ReadString() }); 
                        };
                    }
                    data.Add(stringDict, subdata);
                }
                return data;
            }
        }
        
        public static void queueDelete(string pathFILE)
        {
            Thread delQuT = new Thread(() => deleteLoop(pathFILE, true));
            delQuT.Start();
        }
        public static string deleteLoop(string pathFILE, bool displayMessageBox = false, int attemtps = 10)
        {
            string status = "";
            int x = 0;
            while (true)
            {
                bool tempBool = tryToDelete(pathFILE);
                if (tempBool)
                {
                    break;
                }
                Thread.Sleep(500);
                if (x > attemtps)
                {
                    try
                    {
                        File.Delete(pathFILE);
                    }
                    catch (Exception ex)
                    {
                        status = ex.Message;
                        if (displayMessageBox) MessageBox.Show("File: " + pathFILE + "\n\nError: " + ex.Message + "\n\nMake sure Your have proper file permissons to delete these files, or, make sure a program isnt exicuting them.");
                    }
                    break;
                }
                x++;
            }
            return status;
        }
        public static bool tryToDelete(string pathFILE)
        {
            if (File.Exists(pathFILE))
            {
                try
                {
                    File.Delete(pathFILE);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public static string deleteFolLoop(string pathFOLDER, bool recursive = true, bool displayMessageBox = false, int attemtps = 10)
        {
            string status = "";
            int x = 0;
            while (true)
            {
                bool tempBool = tryToDeleteFol(pathFOLDER, recursive);
                if (tempBool)
                {
                    break;
                }
                Thread.Sleep(500);
                if (x > attemtps)
                {
                    try
                    {
                        Directory.Delete(pathFOLDER, recursive);
                    }
                    catch (Exception ex)
                    {
                        status = ex.Message;
                        if (displayMessageBox) MessageBox.Show("File: " + pathFOLDER + "\n\nError: " + ex.Message + "\n\nMake sure Your have proper file permissons to delete these files, or, make sure a program isnt exicuting them.");
                    }
                    break;
                }
                x++;
            }
            return status;
        }
        public static bool tryToDeleteFol(string pathFOLDER, bool recursive)
        {
            if (Directory.Exists(pathFOLDER))
            {
                try
                {
                    Directory.Delete(pathFOLDER, recursive);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
