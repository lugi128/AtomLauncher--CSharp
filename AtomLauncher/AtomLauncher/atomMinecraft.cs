using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
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
            //{"1.6.4",       new string[] { "time", "releaseTime", "type" }}
        };

        internal static Dictionary<string, string[]> versionData = new Dictionary<string, string[]>
        {
            //{"id"                  , new string[] { "1.6.4" }},
            //{"time"                , new string[] { "2013-09-19T10:52:37-05:00" }},
            //{"releaseTime"         , new string[] { "2013-09-19T10:52:37-05:00" }},
            //{"type"                , new string[] { "release" }},
            //{"minecraftArguments"  , new string[] { "--username ${auth_player_name} --session ${auth_session} --version ${version_name} --appDir ${app_directory} --assetsDir ${app_assets} --uuid ${auth_uuid} --accessToken ${auth_access_token}" }},
            //{"mainClass"           , new string[] { "net.minecraft.client.main.Main" }},
            //{"assets"              , new string[] { "legacy" or "1.6.4" }},
            //{"libraries"           , new string[] { "net\sf\jopt-simple\jopt-simple\4.5\jopt-simple-4.5.jar" "etc" "etc" }},
            //{"urlLibraries"        , new string[] { "MODWEBSITE" "" "etc" }}, //for Mods the declare there own downloads.
            //{"natives"             , new string[] { "net\sf\jopt-simple\jopt-simple\4.5\jopt-simple-4.5.jar" "etc" "etc" }},
        };

        internal static Dictionary<string, string[]> assetsList = new Dictionary<string, string[]>
        {
            //{"objectFileLocation", new string[] { "hash", "size" }},
            //{"objectFileLocation", new string[] { "hash", "size" }},
            //{"objectFileLocation", new string[] { "hash", "size" }},
            //{"etc", new string[] { "etc", "etc" }},
            //{"etc", new string[] { "etc", "etc" }},
            //{"etc", new string[] { "etc", "etc" }},
        };

        internal static Dictionary<int, string[]> fileInput = new Dictionary<int, string[]>();
        internal static Dictionary<int, string[]> modInput = new Dictionary<int, string[]>();
        
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
        static bool mcForce64Bit = false;
        static string mcAccessToken = "";
        static string mcClientToken = ""; //Dev//Currently Unused
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
        internal static string start(string username = "", string password = "")
        {
            string status = "Successful";
            int step = 0;
            while (step <= 9)
            {
                if (status != "Successful") { return status; }
                if (step == 0)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Checking Versions...");
                    if (atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["selectVer"][0].StartsWith("Latest: "))
                    {
                        status = getVersion(atomFileData.config["lastSelectedApp"]);
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
                    status = setSaveData(username, password, mcUsername);
                }
                else if (step == 4)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Loading Version Data...");
                    status = getVersionParam();
                }
                else if (step == 5)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Checking Additional Files...");
                    status = checkAdditionalFiles();
                }
                else if (step == 6)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Downloading Files...");
                    status = getFiles();
                }
                else if (step == 7)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Extracting Natives...");
                    status = getNatives();
                }
                else if (step == 8)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Setting up Command...");
                    status = compileCommand();
                }
                else if (step == 9)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Starting App...");
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
        /// <param name="selectedApp">Input the selected app to download/check for.</param>
        /// <returns>Status of exceptions or success</returns>
        internal static string getVersion(string selectedApp)
        {
            string subString = "";
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Load Version List");
                string fileName = "";
                if (selectedApp == "AL_AddNewApp")
                {
                    fileName = atomProgram.appData + @"\.minecraft\versions\ALVerList\versions.json";
                }
                else
                {
                    fileName = atomLauncher.appData[selectedApp]["location"][0] + @"\versions\ALVerList\versions.json";
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
                    if (atomLauncher.cancelPressed)
                    {
                        status = "Canceled: " + subString + " / Version list file missing.";
                    }
                    else
                    {
                        status = "Error: " + subString + " / Version list file missing.";
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
                mcLocation = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["location"][0];
                mcSave = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["saveLoc"][0];
                mcStartRam = "-Xms" + atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["startRam"][0] + "m ";
                mcMaxRam = "-Xmx" + atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["maxRam"][0] + "m ";
                mcDisplayCMD = Convert.ToBoolean(atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["displayCMD"][0]);
                mcCPUPriority = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["CPUPriority"][0];
                mcOnlineMode = Convert.ToBoolean(atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["onlineMode"][0]);
                mcOfflineName = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["offlineName"][0];
                mcSelectVer = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["selectVer"][0];
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
                mcAutoSelect = Convert.ToBoolean(atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["autoSelect"][0]);
                mcForce64Bit = Convert.ToBoolean(atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["force64Bit"][0]);
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
                    string placedPassword = "";
                    if (inputPassword != "")
                    {
                        placedPassword = otherCipher.Decrypt(inputPassword, otherCipher.machineIDLookup());
                    }
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
                        password = placedPassword
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
        private static string setSaveData(string username, string password, string propperUsername)
        {
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Saving Launcher Data");
                if (mcOnlineMode)
                {
                    if (atomLauncher.userData.ContainsKey(atomFileData.config["lastSelectedApp"]))
                    {
                        if (atomLauncher.userData[atomFileData.config["lastSelectedApp"]].ContainsKey(username))
                        {
                            atomLauncher.userData[atomFileData.config["lastSelectedApp"]][username] = new string[]
                            {
                                password,
                                propperUsername,
                                DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"),
                                mcAccessToken,
                                mcClientToken,
                                mcUUID
                            };
                            atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], atomLauncher.userData, true);
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
        private static string getVersionParam()
        {
            string subString = "";
            string status = "Successful";
            try
            {
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
                    versionData = otherJsonNet.getVersionData(fileName);
                }
                else
                {
                    status = subString + " / Version data file missing.";
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
                    status = "Error: Load Json Parameters: " + ex.Message;
                }
            }
            return status;
        }

        /// <summary>
        /// Look for & Download optional or additional Files
        /// </summary>
        /// <returns>Status of exceptions or success</returns>
        private static string checkAdditionalFiles()
        {
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Checking Additional Files");
                fileInput = new Dictionary<int, string[]>();
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Checking Additional Files: " + ex.Message;
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
                int x = 0;
                int i = 0;
                foreach (string entry in versionData["libraries"])
                {
                    if (versionData["urlLibraries"][i] == "")
                    {
                        fileInput.Add(x, new string[] { "https://libraries.minecraft.net/" + entry.Replace(@"\", "/"), @"libraries\" + entry }); x++;
                        fileInput.Add(x, new string[] { "https://libraries.minecraft.net/" + entry.Replace(@"\", "/") + ".sha1", @"libraries\" + entry + ".sha" }); x++;
                    }
                    else
                    {
                        modInput.Add(x, new string[] { "URL" + entry.Replace(@"\", "/"), @"libraries\" + entry }); x++;
                        //Dev// rewrite bad, Possible idea, check to see if download is possbile, if not, ... error?
                    }
                    i++;
                }
                //Dev//
                // Create a method to check for multiple xml files.
                string fileName = mcLocation + @"\assets\indexes\" + versionData["assets"][0] + ".json";
                string subString = "";
                if ((DateTime.Now - File.GetLastWriteTime(fileName)).TotalHours > 8)
                {
                    //Dev//
                    //In the future, possibly check ETAG instead with all the files.
                    try
                    {
                        atomDownloading.Single("https://s3.amazonaws.com/Minecraft.Download/indexes/" + versionData["assets"][0] + ".json", fileName);
                    }
                    catch (Exception ex)
                    {
                        subString = ex.Message;
                    }
                }
                try
                {
                    if (File.Exists(fileName))
                    {
                        assetsList = otherJsonNet.getAssetsList(fileName);
                        foreach (KeyValuePair<string, string[]> entry in assetsList)
                        {
                            fileInput.Add(x, new string[] { "http://resources.download.minecraft.net/" + entry.Value[0].Truncate(2) + "/" + entry.Value[0], @"assets\objects\" + entry.Value[0].Truncate(2) + @"\" + entry.Value[0] }); x++;
                        }
                    }
                    else
                    {
                        status = subString + " Assets index missing.";
                    }
                }
                catch
                {
                    if (status == "")
                    {
                        status = "Minecraft Resources Error: Please login again.";
                    }
                }
                if (status == "Successful")
                {
                    fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/versions/" + versionData["id"][0] + "/" + versionData["id"][0] + ".jar", @"versions\" + versionData["id"][0] + @"\" + versionData["id"][0] + ".jar" }); x++;
                    Dictionary<int, string[]> downloadInput = atomFileData.fileCheck(fileInput, mcLocation);
                    Dictionary<int, string[]> modCheckInput = atomFileData.fileCheck(modInput, mcLocation);
                    if (modCheckInput.Count > 0)
                    {
                        status = "Error: Modifcation Files Missing, Please reinstall mod files.";
                    }
                    else
                    {
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
                    if (versionData["assets"][0] == "legacy")
                    {
                        int z = 0;
                        atomLauncher.atomLaunch.formText("formLabelStatus", "Checking and creating legacy files...");
                        foreach (KeyValuePair<string, string[]> entry in assetsList)
                        {
                            atomLauncher.atomLaunch.formText("formLabelFileMB", (z + 1) + " / " + assetsList.Count());
                            atomLauncher.atomLaunch.barValues((z + 1) * 100 / assetsList.Count(), 0);
                            if (!File.Exists(mcLocation + @"\assets\virtual\legacy\" + entry.Key.Replace("/", @"\")))
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(mcLocation + @"\assets\virtual\legacy\" + entry.Key.Replace("/", @"\")));
                                File.Copy(mcLocation + @"\assets\objects\" + entry.Value[0].Truncate(2) + @"\" + entry.Value[0], mcLocation + @"\assets\virtual\legacy\" + entry.Key.Replace("/", @"\"));
                                z++;
                            }
                            else
                            {
                                Random rnd = new Random();
                                z += rnd.Next(2, 26);
                                if (z >= assetsList.Count())
                                {
                                    break;
                                }
                            }
                        }
                        atomLauncher.atomLaunch.formText("formLabelFileMB", "");
                        atomLauncher.atomLaunch.barValues(0, 0);
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
                string mojangIntelTrick = "-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump";
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
                mcArgs = mcArgs.Replace("${assets_index_name}", versionData["assets"][0]);
                mcArgs = mcArgs.Replace("${version_name}", mcSelectVer);
                mcArgs = mcArgs.Replace("${user_properties}", "{}");
                mcArgs = mcArgs.Replace("${game_directory}", "\"" + mcSave + "\"");
                mcArgs = mcArgs.Replace("${game_assets}", "\"" + mcLocation + "\\assets\\virtual\\legacy\"");
                mcArgs = mcArgs.Replace("${assets_root}", "\"" + mcLocation + "\\assets\"");
                buildArguments = mojangIntelTrick + " " + mcStartRam + " " + mcMaxRam + " " + mcNatives + " " + mcLibraries + mcJar + " " + mcClass + " " + mcArgs;
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
                if (atomLauncher.cancelPressed) throw new System.Exception("Starting App");
                Process mcProc = new Process();
                mcProc.StartInfo.UseShellExecute = false; // Apperently fixes a problem on specific PCs. // Get more info on this and perhaps make it automatic and/or optional.
                mcProc.StartInfo.WorkingDirectory = mcLocation;
                //Dev//
                //To Read Java Errors//mcProc.StartInfo.RedirectStandardError = true;
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
                //Dev//
                //To Read Java Errors
                //mcProc.WaitForExit();
                //string teststring = mcProc.StandardError.ReadToEnd();
                //MessageBox.Show(teststring, "Java Error");
            }
            catch (Exception ex)
            {
                if (atomLauncher.cancelPressed)
                {
                    status = "Canceled: " + ex.Message;
                }
                else
                {
                    status = "Error: Starting App: " + ex.Message;
                }
            }
            return status;
        }
    }
}
