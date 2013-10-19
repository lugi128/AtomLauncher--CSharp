using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace AtomLauncher
{
    /// <summary>
    /// All the code related to downloading, proccessing, and starting minecraft.
    /// </summary>
    class atomMinecraft
    {
        internal static Dictionary<string, string[]> versionList = new Dictionary<string, string[]>
        {
            //{"AL_LatestID", new string[] { version.latest.release, version.latest.snapshot }},
            //{"1.6.4",       new string[] { "time", "releaseTime", "Type" }}
        };

        Dictionary<string, string[]> dict = new Dictionary<string, string[]>{
            };
        internal static Dictionary<string, string[]> versionData = new Dictionary<string, string[]>
        {
            //{"id"                  , new string[] { "1.6.4" }},
            //{"time"                , new string[] { "2013-09-19T10:52:37-05:00" }},
            //{"releaseTime"         , new string[] { "2013-09-19T10:52:37-05:00" }},
            //{"Type"                , new string[] { "release" }},
            //{"minecraftArguments"  , new string[] { "--username ${auth_player_name} --session ${auth_session} --version ${version_name} --gameDir ${game_directory} --assetsDir ${game_assets}" }},
            //{"mainClass"           , new string[] { "net.minecraft.client.main.Main" }},
            //{"libraries"           , new string[] { "net\sf\jopt-simple\jopt-simple\4.5\jopt-simple-4.5.jar" "etc" "etc" }},
            //{"natives"             , new string[] { "net\sf\jopt-simple\jopt-simple\4.5\jopt-simple-4.5.jar" "etc" "etc" }},
        };
        
        static string mcLocation = "";
        static string mcSave = "";
        static string mcStartRam = "";
        static string mcMaxRam = "";
        static bool mcDisplayCMD = false;
        static string mcCPUPriority = "";
        static bool mcOnlineMode = true;
        static string mcOfflineName = "";
        static string mcSelectVer = "";
        static bool mcAutoSelect = true;
        static bool mcUseNightly = false;
        static bool mcForce64Bit = false;
        static string mcSessionID = "";
        static string mcPropperUsername = "";
        static string javaFile = @"javaw";
        static string buildArguments = "";

        /// <summary>
        /// Run this method to download, proccess, and open minecraft.
        /// </summary>
        /// <param name="username">Input a username here. Example: "username"</param>
        /// <param name="password">Input a password here. Example: "pass1234"</param>
        /// <returns></returns>
        internal static string start(string username = "", string password = "", bool saveLogin = false, bool autoLogin = false)
        {
            string status = "Successful";
            string gameLocation = atomLauncher.gameData[atomLauncher.gameSelect]["location"][0];
            int step = 0;
            while (step <= 8)
            {
                if (status != "Successful") { return status; }
                if (step == 0)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Checking Versions...");
                    if (atomLauncher.gameData[atomLauncher.gameSelect]["selectVer"][0].StartsWith("Latest: "))
                    {
                        status = getVersion(atomLauncher.gameSelect);
                    }
                    else
                    {
                        status = "Successful";
                    }
                }
                else if (step == 1)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Loading Settings...");
                    status = setSettings();
                }
                else if (step == 2)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Logging in " + username + "...");
                    status = setSession(username, password);
                }
                else if (step == 3)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Saving Data...");
                    status = setSaveData(username, password, mcPropperUsername, saveLogin, autoLogin);
                }
                else if (step == 4)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Loading Version Data...");
                    status = getVersionParam(mcUseNightly);
                }
                else if (step == 5)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Downloading Files...");
                    status = getFiles();
                }
                else if (step == 6)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Extracting Natives...");
                    status = getNatives();
                }
                else if (step == 7)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Setting up Command...");
                    status = compileCommand();
                }
                else if (step == 8)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Starting Game...");
                    status = runCommand();
                }
                step++;
            }
            return status;
        }

        /////////////////////////
        // Other Methods
        //

        /// <summary>
        /// Download the minecraft version.json if one isnt present.
        /// When file is present get full list of versions.
        /// Get latest versions on the list.
        /// </summary>
        /// <param name="selectedGame">Input the selected game to download/check for.</param>
        /// <returns>Status of exceptions or success</returns>
        internal static string getVersion(string selectedGame)
        {
            string subString = "";
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Load Version List");
                string fileName = atomLauncher.gameData[selectedGame]["location"][0] + @"\versions\LatestVerList\versions.json";
                if ((DateTime.Now - File.GetLastWriteTime(fileName)).TotalHours > 1)
                {
                    try
                    {
                        atomDownloading.Single("http://s3.amazonaws.com/Minecraft.Download/versions/versions.json", fileName);
                    }
                    catch (Exception ex)
                    {
                        subString = ex.Message;
                    }
                }
                if (File.Exists(fileName))
                {
                    versionList = otherJsonNet.getVersionList(fileName);
                }
                else
                {
                    status = subString + " / Version list file missing.";
                }
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Load Version List: " + ex.Message;
                }
            }
            return status;
        }

        /// <summary>
        /// Load Settings
        /// </summary>
        /// <returns>Status of exceptions or success</returns>
        private static string setSettings()
        {
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) { throw new System.Exception("Loading Settings"); }
                mcLocation = atomLauncher.gameData[atomLauncher.gameSelect]["location"][0];
                mcSave = atomLauncher.gameData[atomLauncher.gameSelect]["saveLoc"][0];
                mcStartRam = "-Xms" + atomLauncher.gameData[atomLauncher.gameSelect]["startRam"][0] + "m ";
                mcMaxRam = "-Xmx" + atomLauncher.gameData[atomLauncher.gameSelect]["maxRam"][0] + "m ";
                mcDisplayCMD = Convert.ToBoolean(atomLauncher.gameData[atomLauncher.gameSelect]["displayCMD"][0]);
                mcCPUPriority = atomLauncher.gameData[atomLauncher.gameSelect]["CPUPriority"][0];
                mcOnlineMode = Convert.ToBoolean(atomLauncher.gameData[atomLauncher.gameSelect]["onlineMode"][0]);
                mcOfflineName = atomLauncher.gameData[atomLauncher.gameSelect]["offlineName"][0];
                mcSelectVer = atomLauncher.gameData[atomLauncher.gameSelect]["selectVer"][0];
                if (mcSelectVer.StartsWith("Latest: "))
                {
                    if (mcSelectVer.EndsWith(" Recommended"))
                    {
                        mcSelectVer = versionList["AL_LatestID"][0];
                    }
                    else if (mcSelectVer.EndsWith(" Development"))
                    {
                        mcSelectVer = versionList["AL_LatestID"][1];
                    }
                }
                mcAutoSelect = Convert.ToBoolean(atomLauncher.gameData[atomLauncher.gameSelect]["autoSelect"][0]);
                mcUseNightly = Convert.ToBoolean(atomLauncher.gameData[atomLauncher.gameSelect]["useNightly"][0]);
                mcForce64Bit = Convert.ToBoolean(atomLauncher.gameData[atomLauncher.gameSelect]["force64Bit"][0]);
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Load Settings: " + ex.Message;
                }
            }
            return status;
        }

        /// <summary>
        /// Login User, Use the user credentials to login and retrieve the session ID.
        /// </summary>
        /// <param name="username">Input username here. Example: "username"</param>
        /// <param name="password">Input password here. Example: "pass1234"</param>
        /// <returns>Status of exceptions or success</returns>
        private static string setSession(string username = "", string password = "")
        {
            string status = "Successful";
            string mcSessionData = "";
            try
            {
                if (mcOnlineMode)
                {
                    using (WebClient client = new WebClient()) // Get Data from Minecraft with username and password
                    {
                        System.Collections.Specialized.NameValueCollection urlData = new System.Collections.Specialized.NameValueCollection();
                        //client.Headers["Content-Type"] = "application/string";
                        urlData.Add("user", username);
                        urlData.Add("password", password);
                        urlData.Add("version", "13");
                        byte[] responsebytes = client.UploadValues("https://login.minecraft.net", "POST", urlData);
                        mcSessionData = Encoding.UTF8.GetString(responsebytes);
                    }
                    if (mcSessionData.Contains(":"))
                    {
                        string[] sessionData = mcSessionData.Split(':');
                        mcPropperUsername = sessionData[2];
                        mcSessionID = sessionData[3];
                    }
                    else
                    {
                        if (mcSessionData == "Bad login")
                        {
                            mcSessionData = mcSessionData + ": Could be an Incorrect Username or Password.";
                        }
                        else if (mcSessionData == "Invalid salt version")
                        {
                            mcSessionData = mcSessionData + ": Username or Password has an invalid input.";
                        }
                        else if (mcSessionData == "")
                        {
                            mcSessionData = mcSessionData + ": ";
                        }
                        status = "Error: Web: " + mcSessionData;
                    }
                }
                else
                {
                    mcPropperUsername = mcOfflineName;
                }
            }
            catch (Exception ex)
            {
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    status = "Error: Internet Disconnected.";
                }
                else if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Session ID Ex: " + ex.Message;
                }
            }
            return status;
        }

        /// <summary>
        /// Save the login data.
        /// </summary>
        /// <param name="username">Input the users username</param>
        /// <param name="password">Input the users password</param>
        /// <param name="propperUsername">Input the users propper username</param>
        /// <param name="saveLogin">Input if the user prompted to save Login.</param>
        /// <param name="autoLogin">Input if the user prompted to have this user automatically Login.</param>
        /// <returns>Status of exceptions or success</returns>
        private static string setSaveData(string username, string password, string propperUsername, bool saveLogin = false, bool autoLogin = false)
        {
            string status = "Successful";
            try
            {
                if (mcOnlineMode) // Possibly add a way to auto login an offline user.
                {
                    if (atomLauncher.cancelPressed) throw new System.Exception("Saving Launcher Data");
                    if (saveLogin)
                    {
                        if (!atomLauncher.userData.ContainsKey(atomLauncher.gameSelect))
                        {
                            atomLauncher.userData.Add(atomLauncher.gameSelect, new Dictionary<string, string[]>());
                        }
                        atomLauncher.userData[atomLauncher.gameSelect][username] = new string[]
                        {
                            propperUsername,
                            otherCipher.Encrypt(password, otherCipher.uniqueMachineId()),
                            mcSessionID,
                            DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss")
                        };
                        atomFileData.saveDictonary(atomFileData.userDataFile, atomLauncher.userData, true);
                    }
                    else
                    {
                        if (atomLauncher.userData.ContainsKey(atomLauncher.gameSelect))
                        {
                            if (atomLauncher.userData[atomLauncher.gameSelect].ContainsKey(username))
                            {
                                atomLauncher.userData[atomLauncher.gameSelect].Remove(username);
                                atomFileData.saveDictonary(atomFileData.userDataFile, atomLauncher.userData, true);
                            }
                        }
                    }
                    if (autoLogin)
                    {
                        if (!atomLauncher.gameData.ContainsKey(atomLauncher.gameSelect))
                        {
                            atomLauncher.gameData.Add(atomLauncher.gameSelect, new Dictionary<string, string[]>());
                        }
                        if (atomLauncher.gameData[atomLauncher.gameSelect]["autoLoginUser"][0] != username)
                        {
                            atomLauncher.gameData[atomLauncher.gameSelect]["autoLoginUser"][0] = username;
                            atomFileData.saveDictonary(atomFileData.gameDataFile, atomLauncher.gameData);
                        }
                    }
                    else
                    {
                        if (atomLauncher.gameData[atomLauncher.gameSelect]["autoLoginUser"][0] != "")
                        {
                            atomLauncher.gameData[atomLauncher.gameSelect]["autoLoginUser"][0] = "";
                            atomFileData.saveDictonary(atomFileData.gameDataFile, atomLauncher.gameData);
                        }
                    }
                }
                atomFileData.saveConfFile(atomFileData.configFile, atomProgram.config);
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Launcher Data: " + ex.Message;
                }
            }
            return status;
        }

        /// <summary>
        /// Look for & Load JSON parameters 
        /// </summary>
        /// <param name="nightlyBuilds">Whether or not to use the latest builds for the libraries.</param>
        /// <returns>Status of exceptions or success</returns>
        private static string getVersionParam(bool nightlyBuilds = false)
        {
            string subString = "";
            string status = "Successful";
                if (atomLauncher.cancelPressed) throw new System.Exception("Load Version Data");
                string fileName = mcLocation + @"\versions\" + mcSelectVer + @"\" + mcSelectVer + ".json";
                if ((DateTime.Now - File.GetLastWriteTime(fileName)).TotalHours > 1)
                {
                    if (mcOnlineMode)
                    {
                        try
                        {
                            atomDownloading.Single("http://s3.amazonaws.com/Minecraft.Download/versions/" + mcSelectVer + "/" + mcSelectVer + ".json", fileName);
                        }
                        catch (Exception ex)
                        {
                            subString = ex.Message;
                        }
                    }
                    else
                    {
                        subString = "Offline Mode, File Missing. You need to login and download first, before offline mode can be used.";
                    }
                }
                if (File.Exists(fileName))
                {
                    versionData = otherJsonNet.getVersionData(fileName, nightlyBuilds);
                }
                else
                {
                    status = subString + " / Version data file missing.";
                }
            try
            {
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Load Json Parameters: " + ex.Message;
                }
            }
            return status;
        }

        /// <summary>
        /// Look for & Download required Files
        /// </summary>
        /// <returns>Status of exceptions or success</returns>
        private static string getFiles()
        {
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Downloading Files");
                Dictionary<int, string[]> fileInput = new Dictionary<int, string[]>();
                int x = 0;
                foreach (string entry in versionData["libraries"]) //maybe fix this to a proper for loop.
                {
                    fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/libraries/" + versionData["libraries"][x].Replace(@"\", "/"), @"libraries\" + versionData["libraries"][x] }); x++;
                }
                string fileName = mcLocation + @"\versions\LatestVerList\Minecraft.Resources.xml";
                string subString = "";
                if ((DateTime.Now - File.GetLastWriteTime(fileName)).TotalHours > 1)
                {
                    try
                    {
                        atomDownloading.Single("http://s3.amazonaws.com/Minecraft.Resources", fileName);
                    }
                    catch (Exception ex)
                    {
                        subString = ex.Message;
                    }
                }
                if (File.Exists(fileName))
                {
                    XDocument doc = XDocument.Load(fileName);

                    foreach (XElement el in doc.Root.Elements())
                    {
                        foreach (XElement element in el.Elements())
                        {
                            if (element.Name.LocalName == "Key")
                            {
                                if (!element.Value.EndsWith("/"))
                                {
                                    fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Resources/" + element.Value, @"assets\" + element.Value.Replace("/", @"\") }); x++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    status = subString + " / Resource File Missing.";
                }
                fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/versions/" + versionData["id"][0] + "/" + versionData["id"][0] + ".jar", @"versions\" + versionData["id"][0] + @"\" + versionData["id"][0] + ".jar" }); x++;
                Dictionary<int, string[]> downloadInput = atomFileData.fileCheck(fileInput, mcLocation);
                if (mcOnlineMode)
                {
                    atomDownloading.Multi(downloadInput, mcLocation);
                }
                else
                {
                    if (downloadInput.Count > 0)
                    {
                        status = "Offline Mode, Files Missing. You need to login and download first, before offline mode can be used.";
                    }
                }
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Downloading Files: " + ex.Message;
                }
            }
            return status;
        }

        /// <summary>
        /// Unzip Natives
        /// </summary>
        /// <returns>Status of exceptions or success</returns>
        private static string getNatives()
        {
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Extracting Natives");
                foreach (string entry in versionData["natives"])
                {
                    otherDotNetZip.Extract(mcLocation + @"\libraries\" + entry, mcLocation + @"\versions\" + versionData["id"][0] + @"\" + versionData["id"][0] + "-natives-AL74", "META-INF");
                }
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Extracting Natives: " + ex.Message;
                }
            }
            return status;
        }

        /// <summary>
        /// Create and construct Minecraft Command
        /// </summary>
        /// <returns>Status of exceptions or success</returns>
        private static string compileCommand()
        {
            string status = "Successful";
            try
            {
                //"C:\Program Files\Java\jre7\bin\java.exe" -Xmx512M -Djava.library.path=C:\Users\Sheryl\AppData\Roaming\.minecraft\versions\1.6.4\1.6.4-test -cp C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\net\sf\jopt-simple\jopt-simple\4.5\jopt-simple-4.5.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\com\paulscode\codecjorbis\20101023\codecjorbis-20101023.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\com\paulscode\codecwav\20101023\codecwav-20101023.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\com\paulscode\libraryjavasound\20101123\libraryjavasound-20101123.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\com\paulscode\librarylwjglopenal\20100824\librarylwjglopenal-20100824.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\com\paulscode\soundsystem\20120107\soundsystem-20120107.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\argo\argo\2.25_fixed\argo-2.25_fixed.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\org\bouncycastle\bcprov-jdk15on\1.47\bcprov-jdk15on-1.47.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\com\google\guava\guava\14.0\guava-14.0.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\org\apache\commons\commons-lang3\3.1\commons-lang3-3.1.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\commons-io\commons-io\2.4\commons-io-2.4.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\net\java\jinput\jinput\2.0.5\jinput-2.0.5.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\net\java\jutils\jutils\1.0.0\jutils-1.0.0.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\com\google\code\gson\gson\2.2.2\gson-2.2.2.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\org\lwjgl\lwjgl\lwjgl\2.9.0\lwjgl-2.9.0.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\libraries\org\lwjgl\lwjgl\lwjgl_util\2.9.0\lwjgl_util-2.9.0.jar;C:\Users\Sheryl\AppData\Roaming\.minecraft\versions\1.6.4\1.6.4.jar net.minecraft.client.main.Main --username TrinaryAtom --session token:ec432334f6d84ec09974a8be3e704aa6:4ed3978b990a4666ae8ae157210ac54e --version 1.6.4 --gameDir C:\Users\Sheryl\AppData\Roaming\.minecraft --assetsDir C:\Users\Sheryl\AppData\Roaming\.minecraft\assets
                if (atomLauncher.cancelPressed) throw new System.Exception("Setting up Command");
                if (mcDisplayCMD)
                {
                    javaFile = @"java";
                }
                if (!mcAutoSelect)
                {
                    string mainDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                    if (mcForce64Bit)
                    {
                        javaFile = mainDrive + @"Windows\SysWOW64\" + javaFile + ".exe";
                    }
                    else
                    {
                        javaFile = mainDrive + @"Windows\System32\" + javaFile + ".exe";
                    }
                }
                string mcNatives = "-Djava.library.path=" + mcLocation + @"\versions\" + mcSelectVer + @"\" + mcSelectVer + "-natives-AL74";
                string mcLibraries = "-cp ";
                foreach (string entry in versionData["libraries"])
                {
                    mcLibraries = mcLibraries + mcLocation + @"\libraries\" + entry + ";";
                }
                string mcJar = mcLocation + @"\versions\" + mcSelectVer + @"\" + mcSelectVer + ".jar";
                string mcClass = versionData["mainClass"][0];
                string mcArgs = versionData["minecraftArguments"][0];
                mcArgs = mcArgs.Replace("${auth_player_name}", mcPropperUsername);
                if (mcOnlineMode)
                {
                    mcArgs = mcArgs.Replace("${auth_session}", mcSessionID);
                }
                else
                {
                    mcArgs = mcArgs.Replace("--session ${auth_session}", "");
                }
                mcArgs = mcArgs.Replace("${version_name}", mcSelectVer);
                mcArgs = mcArgs.Replace("${game_directory}", mcSave);
                mcArgs = mcArgs.Replace("${game_assets}", mcLocation + @"\assets");
                buildArguments = mcStartRam + " " + mcMaxRam + " " + mcNatives + " " + mcLibraries + mcJar + " " + mcClass + " " + mcArgs;
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Setting up Command: " + ex.Message;
                }
            }
            return status;
        }

        /// <summary>
        /// Run the command, which should open Minecraft. Assuming everything else is filled in as intended.
        /// </summary>
        /// <returns>Status of exceptions or success</returns>
        private static string runCommand()
        {
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Starting Game");
                Process mcProc = new Process();
                mcProc.StartInfo.UseShellExecute = false; // Apperently fixes a problem on my laptop. // Get more info on this and perhaps make it automatic and/or optional.
                mcProc.StartInfo.FileName = javaFile;
                mcProc.StartInfo.Arguments = buildArguments;
                mcProc.Start();
                if (mcCPUPriority == "Realtime")
                {
                    mcProc.PriorityClass = ProcessPriorityClass.RealTime;
                }
                else if (mcCPUPriority == "High")
                {
                    mcProc.PriorityClass = ProcessPriorityClass.High;
                }
                else if (mcCPUPriority == "Above Normal")
                {
                    mcProc.PriorityClass = ProcessPriorityClass.AboveNormal;
                }
                else if (mcCPUPriority == "Below Normal")
                {
                    mcProc.PriorityClass = ProcessPriorityClass.BelowNormal;
                }
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Starting Game: " + ex.Message;
                }
            }
            return status;
        }
    }
}
