using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
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
            //{"minecraftArguments"  , new string[] { "--username ${auth_player_name} --session ${auth_session} --version ${version_name} --gameDir ${game_directory} --assetsDir ${game_assets} --uuid ${auth_uuid} --accessToken ${auth_access_token}" }},
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
        static string mcAccessToken = "";
        static string mcClientToken = ""; //Currently Unused
        static string mcUUID = "";
        static string mcUsername = "";
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
            string gameLocation = atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["location"][0];
            int step = 0;
            while (step <= 8)
            {
                if (status != "Successful") { return status; }
                if (step == 0)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Checking Versions...");
                    if (atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["selectVer"][0].StartsWith("Latest: "))
                    {
                        status = getVersion(atomFileData.config["lastSelectedGame"]);
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
                    status = setSaveData(username, password, mcUsername, saveLogin, autoLogin);
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
                string fileName = "";
                if (selectedGame == "AL_AddNewGame")
                {
                    fileName = atomProgram.appData + @"\.minecraft\versions\LatestVerList\versions.json";
                }
                else
                {
                    fileName = atomLauncher.gameData[selectedGame]["location"][0] + @"\versions\LatestVerList\versions.json";
                }
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
                mcLocation = atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["location"][0];
                mcSave = atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["saveLoc"][0];
                mcStartRam = "-Xms" + atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["startRam"][0] + "m ";
                mcMaxRam = "-Xmx" + atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["maxRam"][0] + "m ";
                mcDisplayCMD = Convert.ToBoolean(atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["displayCMD"][0]);
                mcCPUPriority = atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["CPUPriority"][0];
                mcOnlineMode = Convert.ToBoolean(atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["onlineMode"][0]);
                mcOfflineName = atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["offlineName"][0];
                mcSelectVer = atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["selectVer"][0];
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
                mcAutoSelect = Convert.ToBoolean(atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["autoSelect"][0]);
                mcUseNightly = Convert.ToBoolean(atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["useNightly"][0]);
                mcForce64Bit = Convert.ToBoolean(atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["force64Bit"][0]);
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
        private static string setSession(string inputUsername = "", string inputPassword = "")
        {
            string status = "Successful";
            var responsePayload = "";
            try
            {
                if (mcOnlineMode)
                {
                    WebRequest request = WebRequest.Create("https://authserver.mojang.com/authenticate");   //Start WebRequest
                    request.Method = "POST";                                                                //Method type, POST
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(new                           //Object to Upload
                    {
                        agent = new                 // optional /                                           //This seems to be required for minecraft despite them saying its optional.
                        {                           //          /
                            name = "Minecraft",     // -------- / So far this is the only encountered value
                            version = 1             // -------- / This number might be increased by the vanilla client in the future
                        },                          //          /
                        username = inputUsername,   // Can be an email address or player name for unmigrated accounts
                        password = inputPassword,
                        //clientToken = "TOKEN"     // Client Identifier: optional
                    });
                    byte[] uploadBytes = Encoding.UTF8.GetBytes(json);                                      //Convert UploadObject to ByteArray
                    request.ContentType = "application/json";                                               //Set Client Header ContentType to "application/json"
                    request.ContentLength = uploadBytes.Length;                                             //Set Client Header ContentLength to size of upload
                    using (Stream dataStream = request.GetRequestStream())                                  //Start/Close Upload
                    {
                        dataStream.Write(uploadBytes, 0, uploadBytes.Length);                               //Upload the ByteArray
                    }
                    using (WebResponse response = request.GetResponse())                                    //Start/Close Download
                    {
                        using (Stream dataStream = response.GetResponseStream())                            //Start/Close Download Content
                        {                        
                            using (StreamReader reader = new StreamReader(dataStream))                      //Start/Close Reading the Stream
                            {
                                responsePayload = reader.ReadToEnd();                                       //Save Downloaded Content
                            }
                        }
                    }
                    dynamic responseJson = JsonConvert.DeserializeObject(responsePayload);                  //Convert string to dynamic josn object
                    if (responseJson.accessToken != null)                                                   //Detect if this is an error Payload
                    {
                        mcAccessToken = responseJson.accessToken;                                           //Assign Access Token
                        mcClientToken = responseJson.clientToken;                                           //Assign Client Token
                        if (responseJson.selectedProfile.id != null)                                        //Detect if this is an error Payload
                        {
                            mcUUID = responseJson.selectedProfile.id;                                       //Assign User ID
                            mcUsername = responseJson.selectedProfile.name;                                 //Assign Selected Profile Name
                        }
                        else
                        {
                            status = "Error: WebPayLoad: Missing UUID and Username";
                        }
                    }
                    else if (responseJson.errorMessage != null)
                    {
                        status = "Error: WebPayLoad: " + responseJson.errorMessage;
                    }
                    else
                    {
                        status = "Error: WebPayLoad: Had an error and the payload was empty.";
                    }
                }
                else
                {
                    mcUsername = mcOfflineName;
                }
            }
            catch (WebException webEx)
            {
                try
                {
                    using (Stream dataStream = webEx.Response.GetResponseStream())                             //Start/Close Download Content
                    {
                        using (StreamReader reader = new StreamReader(dataStream))                          //Start/Close Reading the Stream
                        {
                            responsePayload = reader.ReadToEnd();                                           //Save Downloaded Content
                        }
                    }
                    dynamic responseJson = JsonConvert.DeserializeObject(responsePayload);                  //Convert string to dynamic josn object
                    status = "Web Ex: " + responseJson.errorMessage + " - " + webEx.Message;  
                }
                catch
                {
                    status = "Web Ex: " + webEx.Message;  
                }
            }
            catch (Exception ex)
            {
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    status = "Error: Internet Disconnected. Use Offline Mode in order to play without internet.";
                }
                else if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Web: " + ex.Message;
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
                        if (!atomLauncher.userData.ContainsKey(atomFileData.config["lastSelectedGame"]))
                        {
                            atomLauncher.userData.Add(atomFileData.config["lastSelectedGame"], new Dictionary<string, string[]>());
                        }
                        atomLauncher.userData[atomFileData.config["lastSelectedGame"]][username] = new string[]
                        {
                            propperUsername,
                            otherCipher.Encrypt(password, otherCipher.machineIDLookup()),
                            DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"),
                            mcAccessToken,
                            mcClientToken,
                            mcUUID
                        };
                        atomFileData.saveDictonary(atomFileData.userDataFile, atomLauncher.userData, true);
                    }
                    else
                    {
                        if (atomLauncher.userData.ContainsKey(atomFileData.config["lastSelectedGame"]))
                        {
                            if (atomLauncher.userData[atomFileData.config["lastSelectedGame"]].ContainsKey(username))
                            {
                                atomLauncher.userData[atomFileData.config["lastSelectedGame"]].Remove(username);
                                atomFileData.saveDictonary(atomFileData.userDataFile, atomLauncher.userData, true);
                            }
                        }
                    }
                    if (autoLogin)
                    {
                        if (!atomLauncher.gameData.ContainsKey(atomFileData.config["lastSelectedGame"]))
                        {
                            atomLauncher.gameData.Add(atomFileData.config["lastSelectedGame"], new Dictionary<string, string[]>());
                        }
                        if (atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["autoLoginUser"][0] != username)
                        {
                            atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["autoLoginUser"][0] = username;
                            atomFileData.saveDictonary(atomFileData.gameDataFile, atomLauncher.gameData);
                        }
                    }
                    else
                    {
                        if (atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["autoLoginUser"][0] != "")
                        {
                            atomLauncher.gameData[atomFileData.config["lastSelectedGame"]]["autoLoginUser"][0] = "";
                            atomFileData.saveDictonary(atomFileData.gameDataFile, atomLauncher.gameData);
                        }
                    }
                }
                atomFileData.saveConfFile(atomFileData.configFile, atomFileData.config);
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
                if (atomLauncher.cancelPressed) throw new System.Exception("Checking Minecraft Files");
                Dictionary<int, string[]> fileInput = new Dictionary<int, string[]>();
                int x = 0;
                foreach (string entry in versionData["libraries"])
                {
                    fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/libraries/" + versionData["libraries"][x].Replace(@"\", "/"), @"libraries\" + versionData["libraries"][x] }); x++;
                }
                string filename = mcLocation + @"\versions\LatestVerList\Minecraft.Resources";
                string[] fileNames = { filename + ".0.xml" };
                string subString = "";
                if ((DateTime.Now - File.GetLastWriteTime(fileNames[0])).TotalHours > 1)
                {
                    atomFileData.deleteLoop(mcLocation + @"\assets\sounds.json"); //In the future, possibly check ETAG instead with all the files.
                    try
                    {
                        string pageMarker = "";
                        int y = 0;
                        while (true)
                        {
                            bool isTruncated = false;
                            atomDownloading.Single("http://s3.amazonaws.com/Minecraft.Resources" + pageMarker, fileNames[y]);
                            XDocument doc = XDocument.Load(fileNames[y]);
                            foreach (XElement el in doc.Root.Elements())
                            {
                                if (el.Name.LocalName == "IsTruncated")
                                {
                                    isTruncated = Convert.ToBoolean(el.Value);
                                    break;
                                }
                            }
                            if (isTruncated)
                            {
                                XElement el = doc.Root.Elements().Last();
                                foreach (XElement element in el.Elements())
                                {
                                    if (element.Name.LocalName == "Key")
                                    {
                                        pageMarker = "?marker=" + element.Value;
                                    }
                                }
                                y++;
                                if (y > fileNames.Length - 1)
                                {
                                    Array.Resize(ref fileNames, fileNames.Length + 1);
                                }
                                fileNames[y] = filename + "." + y + ".xml";
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        subString = ex.Message;
                    }
                }
                try
                {
                    //foreach xml file
                    foreach (string file in fileNames)
                    {
                        if (File.Exists(file))
                        {
                            XDocument doc = XDocument.Load(file);
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
                            break;
                        }
                    }
                }
                catch
                {
                    foreach (string file in fileNames)
                    {
                        status = status + atomFileData.deleteLoop(file);
                    }
                    if (status == "")
                    {
                        status = "Minecraft Resources Error: Please login again.";
                    }
                }
                if (status == "Successful")
                {
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
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Checking Minecraft Files: " + ex.Message;
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
                string mcNatives = "-Djava.library.path=\"" + mcLocation + @"\versions\" + mcSelectVer + @"\" + mcSelectVer + "-natives-AL74\"";
                string mcLibraries = "-cp ";
                foreach (string entry in versionData["libraries"])
                {
                    mcLibraries = mcLibraries + "\"" + mcLocation + @"\libraries\" + entry + "\";";
                }
                string mcJar = "\"" + mcLocation + @"\versions\" + mcSelectVer + @"\" + mcSelectVer + ".jar\"";
                string mcClass = versionData["mainClass"][0];
                string mcArgs = versionData["minecraftArguments"][0];
                mcArgs = mcArgs.Replace("${auth_player_name}", mcUsername);
                if (mcOnlineMode)
                {
                    mcArgs = mcArgs.Replace("${auth_session}", "token:" + mcAccessToken + ":" + mcUUID);
                    mcArgs = mcArgs.Replace("${auth_uuid}", mcUUID);
                    mcArgs = mcArgs.Replace("${auth_access_token}", mcAccessToken);
                }
                else
                {
                    mcArgs = mcArgs.Replace("${auth_session}", "OFFLINE_MODE");
                    mcArgs = mcArgs.Replace("${auth_uuid}", "OFFLINE_MODE");
                    mcArgs = mcArgs.Replace("${auth_access_token}", "OFFLINE_MODE");
                }
                mcArgs = mcArgs.Replace("${version_name}", mcSelectVer);
                mcArgs = mcArgs.Replace("${game_directory}", "\"" + mcSave + "\"");
                mcArgs = mcArgs.Replace("${game_assets}", "\"" + mcLocation + "\\assets\"");
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
                mcProc.StartInfo.UseShellExecute = false; // Apperently fixes a problem on specific PCs. // Get more info on this and perhaps make it automatic and/or optional.
                mcProc.StartInfo.WorkingDirectory = mcLocation;
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
