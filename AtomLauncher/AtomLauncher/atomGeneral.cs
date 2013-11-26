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
    /// All the code related to downloading, proccessing, and starting general.
    /// </summary>
    class atomGeneral
    {
        static string genLocation = "";
        static string genWorkingDirect = "";
        static string genArguments = "";
        static string genCPUPriority = "";

        /// <summary>
        /// Run this method to download, proccess, and open general.
        /// </summary>
        /// <param name="username">Input a username here. Example: "username"</param>
        /// <param name="password">Input a password here. Example: "pass1234"</param>
        /// <returns></returns>
        internal static string start(string username = "", string password = "")
        {
            string status = "Successful";
            string appLocation = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["location"][0];
            int step = 0;
            while (step <= 8)
            {
                if (status != "Successful") { return status; }
                if (step == 1)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Loading Settings...");
                    status = setSettings();
                }
                else if (step == 2)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Saving Data...");
                    status = setSaveData(username, password);
                }
                else if (step == 3)
                {
                    atomLauncher.atomLaunch.formText("formLabelStatus", "Setting up Command...");
                    status = compileCommand(username, password);
                }
                else if (step == 4)
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
        /// Load Settings
        /// </summary>
        /// <returns>Status of exceptions or success</returns>
        private static string setSettings()
        {
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) { throw new System.Exception("Loading Settings"); }
                genLocation = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["location"][0];
                genWorkingDirect = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["workingDirect"][0];
                genArguments = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["arguments"][0];
                genCPUPriority = atomLauncher.appData[atomFileData.config["lastSelectedApp"]]["CPUPriority"][0];
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
        /// Save the login data.
        /// </summary>
        /// <param name="username">Input the users username</param>
        /// <param name="password">Input the users password</param>
        /// <param name="propperUsername">Input the users propper username</param>
        /// <param name="saveLogin">Input if the user prompted to save Login.</param>
        /// <param name="autoLogin">Input if the user prompted to have this user automatically Login.</param>
        /// <returns>Status of exceptions or success</returns>
        private static string setSaveData(string username, string password)
        {
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Saving Launcher Data");
                if (atomLauncher.userData.ContainsKey(atomFileData.config["lastSelectedApp"]))
                {
                    if (atomLauncher.userData[atomFileData.config["lastSelectedApp"]].ContainsKey(username))
                    {
                        atomLauncher.userData[atomFileData.config["lastSelectedApp"]][username] = new string[]
                            {
                                password,
                                "",
                                DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"),
                                "",
                                "",
                                ""
                            };
                        atomFileData.saveDictonary(atomFileData.config["dataLocation"] + atomFileData.config["userDataName"], atomLauncher.userData, true);
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
        /// Create and construct General Command
        /// </summary>
        /// <returns>Status of exceptions or success</returns>
        private static string compileCommand(string username, string password)
        {
            string status = "Successful";
            try
            {
                if (atomLauncher.cancelPressed) throw new System.Exception("Setting up Command");
                if (genWorkingDirect == "")
                {
                    genWorkingDirect = Path.GetDirectoryName(genLocation);
                }
                genArguments = genArguments.Replace("[username]", username);
                if (password != "")
                {
                    password = otherCipher.Decrypt(password, otherCipher.machineIDLookup());
                }
                genArguments = genArguments.Replace("[password]", password);
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
        /// Run the command, which should open General. Assuming everything else is filled in as intended.
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
                mcProc.StartInfo.WorkingDirectory = genWorkingDirect;
                mcProc.StartInfo.FileName = genLocation;
                mcProc.StartInfo.Arguments = genArguments;
                mcProc.Start();
                if (genCPUPriority == "Realtime")
                {
                    mcProc.PriorityClass = ProcessPriorityClass.RealTime;
                }
                else if (genCPUPriority == "High")
                {
                    mcProc.PriorityClass = ProcessPriorityClass.High;
                }
                else if (genCPUPriority == "Above Normal")
                {
                    mcProc.PriorityClass = ProcessPriorityClass.AboveNormal;
                }
                else if (genCPUPriority == "Below Normal")
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
                    status = "Error: Starting App: " + ex.Message;
                }
            }
            return status;
        }
    }
}
