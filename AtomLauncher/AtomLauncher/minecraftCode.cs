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
        string argLocation = Program.appData + @"\.minecraft";

        public string mC_open(string username, string password, bool save, bool auto)
        {
            string status = "";
            argLocation = Program.config["minecraft_location"];

            status = mC_checkVersionInfo();
            if (homeCancel) return status;

            //Download Missing Files
            if (Convert.ToBoolean(Program.config["minecraft_onlineMode"]))
            {
                status = mC_webLogin(username, password, save, auto);
                if (status == "Successful")
                {
                    status = mC_checkFiles();
                }
            }
            else
            {
                status = "Successful";
                mC_mcSession = "";
                mC_mcName = "Player";
            }

            // Compile Command and Run.
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
            FileInfo fi = new FileInfo(argLocation + @"\versions\LatestVerList\versions.json");
            if (fi.CreationTime < DateTime.Now.AddDays(-1))
            {
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Checking Latest Version"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                aD_DownloadFileSingle("http://s3.amazonaws.com/Minecraft.Download/versions/versions.json", argLocation + @"\versions\LatestVerList", "versions.json", true);

            }
            else
            {
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Version file is less than a day old. Not Refreshing."); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            }
            mC_mcVersions = aJ_readJsonVer(argLocation + @"\versions\LatestVerList\versions.json");
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(mC_mcVersions["Status"][0] + ", " + mC_mcVersions["Status"][1]); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
        }

        private string mC_checkVersionInfo()
        {
            if (!File.Exists(argLocation + @"\versions\" + mC_mcVersions["latestids"][0] + @"\" + mC_mcVersions["latestids"][0] + ".json"))
            {
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Latest Version does not exist."); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                aD_DownloadFileDict(new Dictionary<int, string[]> { { 0, new string[] { "http://s3.amazonaws.com/Minecraft.Download/versions/" + mC_mcVersions["latestids"][0] + "/", mC_mcVersions["latestids"][0] + ".json", @"versions\" + mC_mcVersions["latestids"][0] } } }, argLocation);
            }
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Scanning Jar Version"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            mC_mcVerGame = aJ_readJsonGame(argLocation + @"\versions\" + mC_mcVersions["latestids"][0] + @"\" + mC_mcVersions["latestids"][0] + ".json");

            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(mC_mcVerGame["Status"][0] + ", " + mC_mcVerGame["Status"][1]); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            return mC_mcVerGame["Status"][0] + ", " + mC_mcVerGame["Status"][1];
        }

        private string mC_checkFiles()
        {
            Dictionary<int, string[]> fileInput = new Dictionary<int, string[]>();

            int x = 0;
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Placeing Trees"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            foreach (string entry in mC_mcVerGame["Libraries"])
            {
                fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/libraries/" + Path.GetDirectoryName(mC_mcVerGame["Libraries"][x]).Replace(@"\", "/") + "/", Path.GetFileName(mC_mcVerGame["Libraries"][x]), @"libraries\" + Path.GetDirectoryName(mC_mcVerGame["Libraries"][x]) });
                x++;
            }

            int y = 0;
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Throwing Eggs"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            foreach (string entry in mC_mcVerGame["Natives"])
            {
                fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/libraries/" + Path.GetDirectoryName(mC_mcVerGame["Natives"][y]).Replace(@"\", "/") + "/", Path.GetFileName(mC_mcVerGame["Natives"][y]), @"libraries\" + Path.GetDirectoryName(mC_mcVerGame["Natives"][y]) });
                x++;
                y++;
            }

            fileInput.Add(x, new string[] { "http://s3.amazonaws.com/Minecraft.Download/versions/" + mC_mcVerGame["ID"][0] + "/", mC_mcVerGame["ID"][0] + ".jar", @"versions\" + mC_mcVerGame["ID"][0] });
            x++;

            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Growing Wheat"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            Dictionary<int, string[]> downloadInput = atomFileCode.checkReqFiles(fileInput, argLocation);

            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("Crafting Blocks"); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            aD_DownloadFileDict(downloadInput, argLocation);
            return "";
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
            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(javaCMD); homeTextBoxGeneral.AppendText(Environment.NewLine); }));


            // Download Minecraft and Assets research.
            // Discovered https://s3.amazonaws.com/Minecraft.Download/libraries/org/lwjgl/lwjgl/lwjgl-platform/2.9.0/lwjgl-platform-2.9.0-natives-windows.jar
            // https://s3.amazonaws.com/Minecraft.Download/versions/versions.json returns list of versions.
            // https://s3.amazonaws.com/Minecraft.Download/versions/id/id.json Where ID is the latest version will return required files. ... Awesome.
            // https://s3.amazonaws.com/Minecraft.Resources Returns Resources.
            // https://s3.amazonaws.com/Minecraft.Download/versions/1.6.2/1.6.2.jar
            // https://s3.amazonaws.com/MinecraftDownload Returns a list of files.
            // http://assets.minecraft.net also returns a list of files.

            string version = "1.6.2";
            string argSrtRam = "-Xms" + Program.config["minecraft_startRam"] + "m ";
            string argMaxRam = "-Xmx" + Program.config["minecraft_maxRam"] + "m ";
            string argNatives = "-Djava.library.path=" + argLocation + @"\versions\" + version + @"\" + version + "-natives";

            string argWildLib = "-cp " + //Experimental
                argLocation + @"\libraries\*;";

            string argLibraries =
                // -----Minecraft Libraries-----------------------------------------------------------------
                argLocation + @"\libraries\net\sf\jopt-simple\jopt-simple\4.5\jopt-simple-4.5.jar;" +
                argLocation + @"\libraries\com\paulscode\codecjorbis\20101023\codecjorbis-20101023.jar;" +
                argLocation + @"\libraries\com\paulscode\codecwav\20101023\codecwav-20101023.jar;" +
                argLocation + @"\libraries\com\paulscode\libraryjavasound\20101123\libraryjavasound-20101123.jar;" +
                argLocation + @"\libraries\com\paulscode\librarylwjglopenal\20100824\librarylwjglopenal-20100824.jar;" +
                argLocation + @"\libraries\com\paulscode\soundsystem\20120107\soundsystem-20120107.jar;" +
                argLocation + @"\libraries\org\lwjgl\lwjgl\lwjgl\2.9.0\lwjgl-2.9.0.jar;" +
                argLocation + @"\libraries\org\lwjgl\lwjgl\lwjgl_util\2.9.0\lwjgl_util-2.9.0.jar;" +
                argLocation + @"\libraries\argo\argo\2.25_fixed\argo-2.25_fixed.jar;" +
                argLocation + @"\libraries\org\bouncycastle\bcprov-jdk15on\1.47\bcprov-jdk15on-1.47.jar;" +
                argLocation + @"\libraries\com\google\guava\guava\14.0\guava-14.0.jar;" +
                argLocation + @"\libraries\org\apache\commons\commons-lang3\3.1\commons-lang3-3.1.jar;" +
                argLocation + @"\libraries\commons-io\commons-io\2.4\commons-io-2.4.jar;" +
                argLocation + @"\libraries\net\java\jinput\jinput\2.0.5\jinput-2.0.5.jar;" +
                argLocation + @"\libraries\net\java\jutils\jutils\1.0.0\jutils-1.0.0.jar;" +
                argLocation + @"\libraries\com\google\code\gson\gson\2.2.2\gson-2.2.2.jar;";
            // -----------------------------------------------------------------------------------------

            string mineLib = "-cp " + argLibraries;

            string forgeLib = "-cp " + argLibraries +
                // -----Forge Libraries---------------------------------------------------------------------
                argLocation + @"\libraries\net\minecraftforge\minecraftforge\9.10.0.842\minecraftforge-9.10.0.842.jar;" +
                argLocation + @"\libraries\net\minecraft\launchwrapper\1.3\launchwrapper-1.3.jar;" +
                argLocation + @"\libraries\org\ow2\asm\asm-all\4.1\asm-all-4.1.jar;" +
                argLocation + @"\libraries\org\scala-lang\scala-library\2.10.2\scala-library-2.10.2.jar;" +
                argLocation + @"\libraries\org\scala-lang\scala-compiler\2.10.2\scala-compiler-2.10.2.jar;" +
                argLocation + @"\libraries\lzma\lzma\0.0.1\lzma-0.0.1.jar;";
            // -----------------------------------------------------------------------------------------

            string libJar = argLocation + @"\versions\" + version + @"\" + version + ".jar";
            string MCString = "net.minecraft.client.main.Main"; //net.minecraft.client.main.Main :: Minecraft //net.minecraft.launchwrapper.Launch :: Forge
            string argUser = "--username " + mC_mcName;
            string argSession = "--session " + mC_mcSession; //Removed "token:" out of "--session token:" ... No idea why other people were doing it.
            string argVersion = "--version " + version;
            string gameDir = "--gameDir " + argLocation;
            string assetsDir = "--assetsDir " + argLocation + @"\assets";

            string buildArgs = argSrtRam + " " + argMaxRam + " " + argNatives + " "
                + mineLib // change to mineLib for 1.6.2 Vanilla. Change to forgeLib for Forge Libraries.
                + libJar + " " + MCString + " " + argUser + " " + argVersion + " " + gameDir + " " + assetsDir
                + " --tweakClass cpw.mods.fml.common.launcher.FMLTweaker"; // This is for forge, when vanilla runs it ignores this.

            string pre16Args = argSrtRam + " " + argMaxRam + " -cp " + argLocation + @"\bin\* -Djava.library.path=" + argLocation + @"\bin\natives net.minecraft.client.Minecraft " + mC_mcName + " " + mC_mcSession;
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
