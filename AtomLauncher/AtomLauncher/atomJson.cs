using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace AtomLauncher
{
    public partial class Launcher
    {

        Dictionary<string, string[]> aJ_mcVersions = new Dictionary<string, string[]>{
            //  {"versionsid1.6.2", new string[] { "1.6.2" , "release"       }},
            //  {"latestids"      , new string[] { "1.6.2" , "w13d12"        }},
                {"Trash"          , new string[] { "None" }},
                {"Status"         , new string[] { "None"   , "Error Aj_V_01" }}
        };
        Dictionary<string, string[]> aJ_mcVerGame = new Dictionary<string, string[]>{
                {"ID"                  , new string[] { "None" }},
                {"Type"                , new string[] { "None" }},
                {"ProcessArguments"    , new string[] { "None" }},
                {"MinecraftArguments"  , new string[] { "None" }},
                {"Libraries"           , new string[] { "None" }},
                {"Natives"             , new string[] { "None" }},
                {"mainClass"           , new string[] { "None" }},
                {"Status"              , new string[] { "None" , "Error Aj_vG_01" }}
        };

        public Dictionary<string, string[]> aJ_readJsonGame(string location)
        {
            Dictionary<string, string[]> tmpDict = new Dictionary<string, string[]>{
                {"Status"         , new string[] { "Failure" , "Version Json not found" }}
            };
            if (!File.Exists(location)) return tmpDict;

            tmpDict["Status"] = new string[] { "Failure", "Canceled" };
            if (homeCancel) return tmpDict;

            string[] fileArray = File.ReadAllLines(location);
            bool inLibraries = false;
            int exitSection = 0;
            string jsonLine = "";
            string[] tmpNativeArray = new string[] { "None" };
            string[] tmpLibrariesArray = new string[] { "None" };

            int x = 0;
            int z = 0;
            int i = 0;
            for (int y = 0; y < fileArray.Length; y++)
            {
                if (fileArray[y].Contains("\"libraries\":"))
                {
                    inLibraries = true;
                    exitSection = i;
                }
                else if (fileArray[y].Contains("\": \""))
                {
                    if (inLibraries)
                    {
                        jsonLine = Regex.Replace(fileArray[y], "[ \",]", "");
                        string[] jsonKeyValue = jsonLine.Split(new char[] { ':' }, 2);
                        if (jsonKeyValue[0] == "name" && !jsonKeyValue[1].Contains("-nightly-") && jsonKeyValue[1] != "osx")
                        {
                            if (fileArray[y + 1].Contains("\"natives\":"))
                            {
                                if (z > tmpNativeArray.Length - 1)
                                {
                                    Array.Resize(ref tmpNativeArray, tmpNativeArray.Length + 1);
                                }
                                tmpNativeArray[z] = jsonKeyValue[1];
                                z++;
                            }
                            else
                            {
                                if (x > tmpLibrariesArray.Length - 1)
                                {
                                    Array.Resize(ref tmpLibrariesArray, tmpLibrariesArray.Length + 1);
                                }
                                tmpLibrariesArray[x] = jsonKeyValue[1];
                                x++;
                            }
                            // Use
                            // Path.GetFileName(@""); 
                            // &
                            // Path.GetDirectoryName(@""));
                            // Later
                        }
                    }
                    else
                    {
                        jsonLine = Regex.Replace(fileArray[y], "[ \",]", "");
                        string[] jsonKeyValue = jsonLine.Split(new char[] { ':' }, 2);
                        if (jsonKeyValue[0] == "id")
                        {
                            tmpDict["ID"] = new string[] { jsonKeyValue[1] };
                        }
                        if (jsonKeyValue[0] == "Type")
                        {
                            tmpDict["Type"] = new string[] { jsonKeyValue[1] };
                        }
                        if (jsonKeyValue[0] == "processArguments")
                        {
                            tmpDict["ProcessArguments"] = new string[] { jsonKeyValue[1] };
                        }
                        if (jsonKeyValue[0] == "minecraftArguments")
                        {
                            string jsonLineMA = Regex.Replace(fileArray[y], "[\",]", ""); //Need the spaces to function correctly.
                            string[] jsonKeyValueMA = Regex.Split(jsonLineMA, ": ");
                            tmpDict["MinecraftArguments"] = new string[] { jsonKeyValueMA[1] };
                        }
                        if (jsonKeyValue[0] == "mainClass")
                        {
                            tmpDict["mainClass"] = new string[] { jsonKeyValue[1] };
                        }
                    }
                }
                if (fileArray[y].Contains("{") || fileArray[y].Contains("["))
                {
                    i++;
                }
                if (fileArray[y].Contains("}") || fileArray[y].Contains("]"))
                {
                    i--;
                    if (i == exitSection)
                    {
                        inLibraries = false;
                    }
                }
            }
            tmpDict["Libraries"] = tmpLibrariesArray;
            tmpDict["Natives"] = tmpNativeArray;
            tmpDict["Status"] = new string[] { "Successful", "GameVersion File Scanned" };

            //dev
               
                foreach (string entry in tmpDict["Libraries"])
                {
                    this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(entry); }));
                    this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                }
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("======================="); }));
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                foreach (string entry in tmpDict["Natives"])
                {
                    this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(entry); }));
                    this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                }
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("======================="); }));
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                foreach (KeyValuePair<string, string[]> entry in tmpDict)
                {
                    this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(entry.Key + " = " + entry.Value[0]); }));
                    this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                }
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("======================="); }));
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            //dev

            return tmpDict;
        }

        // This method is only developed for Minecraft's version file. It will not work with any other json file.
        public Dictionary<string, string[]> aJ_readJsonVer(string location)
        {
            Dictionary<string, string[]> tmpDict = new Dictionary<string, string[]>{
                {"Trash"          , new string[] { "None" }},
                {"Status"         , new string[] { "Failure" , "Version Does not exist."}}
            };
            if (!File.Exists(location)) return tmpDict;

            tmpDict["Status"] = new string[] { "Failure", "Canceled" };
            if (homeCancel) return tmpDict;

            string[] fileArray = File.ReadAllLines(location);
            string section = "";
            string jsonLine = "";
            string tmpDictKey = "Trash";

            for (int y = 0; y < fileArray.Length; y++)
            {
                if (fileArray[y].Contains("\"versions\":"))
                {
                    section = "versions";
                }
                else if (fileArray[y].Contains("\"latest\":"))
                {
                    section = "latest";
                }
                else if (fileArray[y].Contains("\": \""))
                {
                    if (section == "versions")
                    {
                        jsonLine = Regex.Replace(fileArray[y], "[ \",]", "");
                        string[] jsonKeyValue = jsonLine.Split(new char[] { ':' }, 2 );
                        if (jsonKeyValue[0] == "id")
                        {
                            tmpDictKey = "versionid" + jsonKeyValue[1];
                            tmpDict.Add(tmpDictKey, new string[] { jsonKeyValue[1], "" });
                        }
                        if (jsonKeyValue[0] == "type")
                        {
                            tmpDict[tmpDictKey] = new string[] { tmpDict[tmpDictKey][0], jsonKeyValue[1] };
                        }
                    }
                    if (section == "latest")
                    {
                        jsonLine = Regex.Replace(fileArray[y], "[ \",]", "");
                        string[] jsonKeyValue = jsonLine.Split(new char[] { ':' }, 2);
                        if (jsonKeyValue[0] == "snapshot")
                        {
                            tmpDictKey = "latestids";
                            tmpDict.Add(tmpDictKey, new string[] { "", jsonKeyValue[1] });
                        }
                        if (jsonKeyValue[0] == "release")
                        {
                            tmpDict["latestids"] = new string[] { jsonKeyValue[1], tmpDict[tmpDictKey][1] };
                        }
                    }
                }
            }
            tmpDict["Status"] = new string[] { "Successful", "Version File Scanned" };

            //dev
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("LatestIDs = " + tmpDict["latestids"][0] + " & " + tmpDict["latestids"][1]); }));
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("======================="); }));
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                foreach (KeyValuePair<string, string[]> entry in tmpDict)
                {
                    if (entry.Key.Contains("versionid"))
                    {
                        this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(entry.Key + " = " + entry.Value[0] + " - " + entry.Value[1]); }));
                        this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
                    }
                }
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("======================="); }));
                this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            //dev

            return tmpDict;
        }
    }
}
