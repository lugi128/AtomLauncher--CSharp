using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO;

namespace AtomLauncher
{
    public partial class Launcher
    {
        string CMC_mcName = "";
        string CMC_mcSession = "";

        public string status = "";

        public string CMC_open(string username, string password, bool save, bool auto)
        {
            if (Convert.ToBoolean(Program.config["minecraft_onlineMode"]))
            {
                status = CMC_webLogin(username, password, save, auto);
            }
            else
            {
                status = "Login";
            }
            if (homeCancel != true)
            {
                if (status == "Login")
                {
                    string javaCMD = @"javaw";
                    if (Convert.ToBoolean(Program.config["minecraft_displayCMD"]))
                    {
                        javaCMD = @"java";
                    }
                    if (!Convert.ToBoolean(Program.config["minecraft_onlineMode"]))
                    {
                        CMC_mcSession = "";
                        CMC_mcName = "Player";
                    }
                    if (!Convert.ToBoolean(Program.config["minecraft_autoSelect"]))
                    {
                        string mainDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                        if (!Convert.ToBoolean(Program.config["minecraft_force64Bit"]))
                        {
                            javaCMD = mainDrive + @"Windows\SysWOW64\" + javaCMD + ".exe";
                        }
                        else
                        {
                            javaCMD = mainDrive + @"Windows\System32\" + javaCMD + ".exe";
                        }
                    }

                    string srtRam = Program.config["minecraft_startRam"];
                    string maxRam = Program.config["minecraft_maxRam"];
                    string location = Program.config["minecraft_location"];

                    //Already used// string username = "namehere";
                    string nativesLoc = "-Djava.library.path=" + location + @"\versions\1.6.2\1.6.2-natives ";
                    string session = "--session token:" + CMC_mcSession;
                    string version = "1.6.2";
                    string buildArgs = nativesLoc + "-cp " + location + @"\libraries\net\sf\jopt-simple\jopt-simple\4.5\jopt-simple-4.5.jar;" + location + @"\libraries\com\paulscode\codecjorbis\20101023\codecjorbis-20101023.jar;" + location + @"\libraries\com\paulscode\codecwav\20101023\codecwav-20101023.jar;" + location + @"\libraries\com\paulscode\libraryjavasound\20101123\libraryjavasound-20101123.jar;" + location + @"\libraries\com\paulscode\librarylwjglopenal\20100824\librarylwjglopenal-20100824.jar;" + location + @"\libraries\com\paulscode\soundsystem\20120107\soundsystem-20120107.jar;" + location + @"\libraries\argo\argo\2.25_fixed\argo-2.25_fixed.jar;" + location + @"\libraries\org\bouncycastle\bcprov-jdk15on\1.47\bcprov-jdk15on-1.47.jar;" + location + @"\libraries\com\google\guava\guava\14.0\guava-14.0.jar;" + location + @"\libraries\org\apache\commons\commons-lang3\3.1\commons-lang3-3.1.jar;" + location + @"\libraries\commons-io\commons-io\2.4\commons-io-2.4.jar;" + location + @"\libraries\net\java\jinput\jinput\2.0.5\jinput-2.0.5.jar;" + location + @"\libraries\net\java\jutils\jutils\1.0.0\jutils-1.0.0.jar;" + location + @"\libraries\com\google\code\gson\gson\2.2.2\gson-2.2.2.jar;" + location + @"\libraries\org\lwjgl\lwjgl\lwjgl\2.9.0\lwjgl-2.9.0.jar;" + location + @"\libraries\org\lwjgl\lwjgl\lwjgl_util\2.9.0\lwjgl_util-2.9.0.jar;" + location + @"\versions\1.6.2\1.6.2.jar net.minecraft.client.main.Main --username " + CMC_mcName + " " + session + " --version " + version + " --gameDir " + location + @" --assetsDir " + location + @"\assets";


                    Process mcProc = new Process();
                    mcProc.StartInfo.FileName = javaCMD;
                    mcProc.StartInfo.Arguments = @"-Xms" + srtRam + "m -Xmx" + maxRam + "m " + buildArgs;//buildArgs//-cp " + location + @"\bin\* -Djava.library.path=" + location + @"\bin\natives net.minecraft.client.Minecraft " + CMC_mcName + " " + CMC_mcSession;
                    mcProc.Start();
                    if (Program.config["minecraft_CPUPriority"] == "Realtime")
                    {
                        mcProc.PriorityClass = ProcessPriorityClass.RealTime;
                    }
                    else if (Program.config["minecraft_CPUPriority"] == "High")
                    {
                        mcProc.PriorityClass = ProcessPriorityClass.High;
                    }
                    else if (Program.config["minecraft_CPUPriority"] == "Above Normal")
                    {
                        mcProc.PriorityClass = ProcessPriorityClass.AboveNormal;
                    }
                    else if (Program.config["minecraft_CPUPriority"] == "Below Normal")
                    {
                        mcProc.PriorityClass = ProcessPriorityClass.BelowNormal;
                    }
                }
                else
                {
                    status = status + " :Error: CodeMinecraft";
                }
            }
            else
            {
                status = status + ": Canceled";
            }
            homeSetControl(true, true);
            return status;
        }

        private void CMC_getFiles()
        {
            //Input code neccessary to download all of the minecraft files.
        }

        private string CMC_webLogin(string username, string password, bool save, bool auto)
        {
            string mcURLData = "WebClient Code Error";

            //SaveSession? and possible load it if in the propper ammount of time from last login? Then bypass Webconnect.

            using (WebClient client = new WebClient()) // Get Data from Minecraft with username and password
            {
                this.Invoke(new MethodInvoker(delegate { homeLabelTop.Text = "Connecting to Minecraft.net..."; }));
                try
                {
                    System.Collections.Specialized.NameValueCollection urlData = new System.Collections.Specialized.NameValueCollection();
                    urlData.Add("user", username);
                    urlData.Add("password", password);
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

            if (mcURLData.Contains(":"))
            {
                string[] mcLoginData = mcURLData.Split(':');
                CMC_mcName = mcLoginData[2];
                CMC_mcSession = mcLoginData[3];
                if (save)
                {
                    atomFile.writeLoginFile(username, password, atomFile.usersFile, "minecraft", auto);
                }
                else
                {
                    atomFile.removeLoginLine(atomFile.usersFile, "minecraft", username);
                }
                return "Login";
            }
            else
            {
                return mcURLData;
            }
        }
    }
}
