using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace AtomLauncher
{
    public partial class Launcher
    {
        //aJ_readJsonVer
        Dictionary<string, string[]> mC_mcVersions = new Dictionary<string, string[]>{
            //  {"versionsid1.6.2", new string[] { "1.6.2" , "release"       }},
            //  {"latestids"      , new string[] { "1.6.2" , "w13d12"        }},
                {"Trash"          , new string[] { "None" }},
                {"Status"         , new string[] { "None"   , "Error Aj_V_01" }}
        };

        //aJ_readJsonGame
        Dictionary<string, string[]> mC_mcVerGame = new Dictionary<string, string[]>{
                {"ID"                  , new string[] { "None" }},
                {"Type"                , new string[] { "None" }},
                {"ProcessArguments"    , new string[] { "None" }},
                {"MinecraftArguments"  , new string[] { "None" }},
              //{"Libraries"           , new string[] { "net/sf/jopt-simple/jopt-simple/4.5/jopt-simple-4.5.jar" "etc" "etc" }},
                {"Libraries"           , new string[] { "None" }},
              //{"Natives"             , new string[] { "net/sf/jopt-simple/jopt-simple/4.5/jopt-simple-4.5.jar" "etc" "etc" }},
                {"Natives"             , new string[] { "None" }},
                {"mainClass"           , new string[] { "None" }},
                {"Status"              , new string[] { "None" , "Error Aj_vG_01" }}
        };

        string mC_mcName = "";
        string mC_mcSession = "";
        string mcLocation = Program.appData + @"\.minecraft";

        public string mC_open(string username, string password, bool save, bool auto)
        {
            string status = "";
            mcLocation = Program.config["minecraft_location"];

            status = mC_checkVersionInfo();
            if (homeCancel) return status;

            if (Convert.ToBoolean(Program.config["minecraft_onlineMode"]))
            {
                status = mC_webLogin(username, password, save, auto);
                if (status == "Successful")
                {
                    mC_checkFiles();
                }
            }
            else
            {
                status = "Successful";
                mC_mcSession = "";
                mC_mcName = "Player";
            }

            if (homeCancel != true)
            {
                if (status == "Successful")
                {
                    mC_compileRun();
                }
                else
                {
                    status = status + " - Error, Code: CM_1";
                }
            }
            else
            {
                status = status + ": Canceled";
            }
            return status;
        }

        private void mC_checkVersionList()
        {
            FileInfo fi = new FileInfo(mcLocation + @"\versions\LatestVerList\versions.json");
            if (fi.CreationTime < DateTime.Now.AddDays(-1))
            {
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Checking Latest Version"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                aD_DownloadFileSingle("http://s3.amazonaws.com/Minecraft.Download/versions/versions.json", mcLocation + @"\versions\LatestVerList", "versions.json", true);
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Version file is less than a day old. Not Refreshing."); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            }
            mC_mcVersions = aJ_readJsonVer(mcLocation + @"\versions\LatestVerList\versions.json");
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(mC_mcVersions["Status"][0] + ", " + mC_mcVersions["Status"][1]); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
        }

        private string mC_checkVersionInfo()
        {
            if (!File.Exists(mcLocation + @"\versions\" + mC_mcVersions["latestids"][0] + @"\" + mC_mcVersions["latestids"][0] + ".json"))
            {
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Latest Version does not exist."); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                aD_DownloadFileDict(new Dictionary<int, string[]> { { 0, new string[] { "http://s3.amazonaws.com/Minecraft.Download/versions/" + mC_mcVersions["latestids"][0] + "/", mC_mcVersions["latestids"][0] + ".json", @"versions\" + mC_mcVersions["latestids"][0] } } }, mcLocation);
            }
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Scanning Jar Version"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            mC_mcVerGame = aJ_readJsonGame(mcLocation + @"\versions\" + mC_mcVersions["latestids"][0] + @"\" + mC_mcVersions["latestids"][0] + ".json");

            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(mC_mcVerGame["Status"][0] + ", " + mC_mcVerGame["Status"][1]); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            return mC_mcVerGame["Status"][0] + ", " + mC_mcVerGame["Status"][1];
        }

        private string mC_checkFiles()
        {
            //if custom version, download from custom site.
            //Forge apperently has a 304, I cant figure that out at all.
            Dictionary<int, string[]> fileInput = new Dictionary<int, string[]>();

            int x = 0;
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Placeing Trees"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            foreach (string entry in mC_mcVerGame["Libraries"]) //maybe fix this to a proper for loop.
            {
                fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/libraries/" + Path.GetDirectoryName(mC_mcVerGame["Libraries"][x]).Replace(@"\", "/") + "/", Path.GetFileName(mC_mcVerGame["Libraries"][x]), @"libraries\" + Path.GetDirectoryName(mC_mcVerGame["Libraries"][x]) });
                x++;
            }

            int y = 0;
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Throwing Eggs"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            foreach (string entry in mC_mcVerGame["Natives"]) //maybe fix this to a proper for loop.
            {
                fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/libraries/" + Path.GetDirectoryName(mC_mcVerGame["Natives"][y]).Replace(@"\", "/") + "/", Path.GetFileName(mC_mcVerGame["Natives"][y]), @"libraries\" + Path.GetDirectoryName(mC_mcVerGame["Natives"][y]) });
                x++;
                y++;
            }

            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Ignite Portal"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/versions/" + mC_mcVerGame["ID"][0] + "/", mC_mcVerGame["ID"][0] + ".jar", @"versions\" + mC_mcVerGame["ID"][0] });
            x++;

            // Development, for adding Asset Files.
            //this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Feed Wolf"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            //XDocument coordinates = XDocument.Load("Minecraft.Resources");
            //foreach (var coordinate in coordinates.Descendants("Contents"))
            //{
            //    // <Key>READ_ME_I_AM_VERY_IMPORTANT</Key>
            //    // <LastModified>2013-04-30T09:25:54.000Z</LastModified>
            //    // <ETag>"49e6d7e2967d1a471341335c49f46c6c"</ETag>
            //    // <Size>561</Size>
            //    // <StorageClass>STANDARD</StorageClass>
            //    string key = coordinate.Attribute("Key").Value;

            //    // do whatever you want to do with those items of information now
            //}

            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Growing Wheat"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            Dictionary<int, string[]> downloadInput = atomFileCode.checkReqFiles(fileInput, mcLocation);

            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Crafting Blocks"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            aD_DownloadFileDict(downloadInput, mcLocation);
            return "Successful";
        }

        private string mC_webLogin(string username, string password, bool save, bool auto)
        {
            string mcURLData = "WebClient Code Error";

            //SaveSession? and possible load it if in the propper ammount of time from last login? Then bypass Webconnect.

            using (WebClient client = new WebClient()) // Get Data from Minecraft with username and password
            {
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Connecting Redstone... ... "); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
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
                mC_mcName = mcLoginData[2];
                mC_mcSession = mcLoginData[3];
                if (save)
                {
                    atomFileCode.writeLoginFile(username, password, atomFileCode.usersFile, "minecraft", auto);
                }
                else
                {
                    atomFileCode.removeLoginLine(atomFileCode.usersFile, "minecraft", username);
                }
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Lamp On"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                return "Successful";
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Minecraft No Like Redstone."); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                return mcURLData;
            }
        }

        private void mC_compileRun()
        {
            string javaCMD = @"javaw";
            if (Convert.ToBoolean(Program.config["minecraft_displayCMD"]))
            {
                javaCMD = @"java";
            }
            if (!Convert.ToBoolean(Program.config["minecraft_autoSelect"]))
            {
                string mainDrive = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                if (!Convert.ToBoolean(Program.config["minecraft_force64Bit"]))
                {
                    javaCMD = mainDrive + @"Windows\System32\" + javaCMD + ".exe";
                }
                else
                {
                    javaCMD = mainDrive + @"Windows\SysWOW64\" + javaCMD + ".exe";
                }
            }

            foreach (string entry in mC_mcVerGame["Natives"])
            {
                dotNetZip.Extract(mcLocation + @"\libraries\" + entry, mcLocation + @"\versions\" + mC_mcVerGame["ID"][0] + @"\" + mC_mcVerGame["ID"][0] + "-natives-AL74", "META-INF");
            }

            string mcSrtRam = "-Xms" + Program.config["minecraft_startRam"] + "m ";
            string mcMaxRam = "-Xmx" + Program.config["minecraft_maxRam"] + "m ";
            string mcNatives = "-Djava.library.path=" + mcLocation + @"\versions\" + mC_mcVerGame["ID"][0] + @"\" + mC_mcVerGame["ID"][0] + "-natives-AL74";

            string mcLibraries = "-cp ";
            foreach (string entry in mC_mcVerGame["Libraries"])
            {
                mcLibraries = mcLibraries + mcLocation + @"\libraries\" + entry + ";";
            }

            string forgeLib = "-cp " + mcLibraries +
                // -----Forge Libraries---------------------------------------------------------------------
                mcLocation + @"\libraries\net\minecraftforge\minecraftforge\9.10.0.842\minecraftforge-9.10.0.842.jar;" +
                mcLocation + @"\libraries\net\minecraft\launchwrapper\1.3\launchwrapper-1.3.jar;" +
                mcLocation + @"\libraries\org\ow2\asm\asm-all\4.1\asm-all-4.1.jar;" +
                mcLocation + @"\libraries\org\scala-lang\scala-library\2.10.2\scala-library-2.10.2.jar;" +
                mcLocation + @"\libraries\org\scala-lang\scala-compiler\2.10.2\scala-compiler-2.10.2.jar;" +
                mcLocation + @"\libraries\lzma\lzma\0.0.1\lzma-0.0.1.jar;";
                // -----------------------------------------------------------------------------------------

            string mcLibJar = mcLocation + @"\versions\" + mC_mcVerGame["ID"][0] + @"\" + mC_mcVerGame["ID"][0] + ".jar";

            string mcClass = mC_mcVerGame["mainClass"][0]; //net.minecraft.client.main.Main :: Minecraft //net.minecraft.launchwrapper.Launch :: Forge

            string mcArgs = mC_mcVerGame["MinecraftArguments"][0];
            mcArgs = mcArgs.Replace("${auth_player_name}", mC_mcName);
            mcArgs = mcArgs.Replace("${auth_session}", mC_mcSession);
            mcArgs = mcArgs.Replace("${version_name}", mC_mcVerGame["ID"][0]);
            mcArgs = mcArgs.Replace("${game_directory}", mcLocation);
            mcArgs = mcArgs.Replace("${game_assets}", mcLocation + @"\assets");

            string buildArgs = mcSrtRam + " " + mcMaxRam + " " + mcNatives + " " + mcLibraries + mcLibJar + " " + mcClass + " " + mcArgs;
            string pre16Args = mcSrtRam + " " + mcMaxRam + " -cp " + mcLocation + @"\bin\* -Djava.library.path=" + mcLocation + @"\bin\natives net.minecraft.client.Minecraft " + mC_mcName + " " + mC_mcSession;

            Process mcProc = new Process();
            mcProc.StartInfo.UseShellExecute = false; // Apperently fixes a problem on my laptop. // Get more info on this and perhaps make it automatic and/or optional.
            mcProc.StartInfo.FileName = javaCMD;
            mcProc.StartInfo.Arguments = buildArgs;
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
    }
}
