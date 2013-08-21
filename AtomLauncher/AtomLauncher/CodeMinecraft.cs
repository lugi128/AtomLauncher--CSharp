using System;
using System.Collections.Generic;
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

        /////////////////////////////////////
        // Start - Get Login Session from Minecraft.
        public string status = "";

        private string CMC_webLogin(string username, string password, bool save, bool auto)
        {
                /////////////////////////////////////
                // Start - Web Code, Unlearned, But it Works
                // Gets Session Id and other strings from Minecraft
                    string mcURLData = "WebClient Code Error";

                    //SaveSession? and possible load it if in the propper ammount of time from last login? Then bypass Webconnect.

                    using (WebClient client = new WebClient()) // Get Data from Minecraft with username and password
                    {
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
                // End
                /////////////////////////////////////

                /////////////////////////////////////
                // Start - Check Minecraft Session Status
                    if (mcURLData.Contains(":"))
                    {
                        string[] mcLoginData = mcURLData.Split(':');
                        CMC_mcName = mcLoginData[2];
                        CMC_mcSession = mcLoginData[3];
                        //Possible Error
                        //setDebugSession(mcSession);
                        //setDebugName(mcName);
                        //SetButtonText("Start");
                        if (save)
                        {
                            atomFile.writeLoginFile(username, password, atomFile.usersFile, "minecraft", auto);
                        }
                        else
                        {
                            atomFile.removeLoginLine(atomFile.usersFile, "minecraft");
                        }
                        return "Login";
                    }
                    else
                    {
                        return mcURLData;
                    }
                // End
                /////////////////////////////////////
        }
        // End
        /////////////////////////////////////

        public string CMC_open(string username, string password, bool save, bool auto)
        {
            status = CMC_webLogin(username, password, save, auto);
            if (status == "Login")
            {
                Process.Start(@"javaw", @"-Xms512m -Xmx1024m -cp " + Program.appData + @"\.minecraft\bin\* -Djava.library.path=" + Program.appData + @"\.minecraft\bin\natives net.minecraft.client.Minecraft " + CMC_mcName + " " + CMC_mcSession);
            }
            return status;
        }

    }
}
