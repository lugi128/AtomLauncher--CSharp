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

        public Dictionary<string, string[]> aJ_readJsonGame(string location)
        {
            Dictionary<string, string[]> tmpDict = new Dictionary<string, string[]>{
                {"Status"         , new string[] { "Failure" , "Version Json not found" }}
            };
            if (!File.Exists(location)) { homeCancel = true; return tmpDict; };

            tmpDict["Status"] = new string[] { "Failure", "Canceled" };
            if (homeCancel) return tmpDict;

            string[] fileArray = File.ReadAllLines(location);
            bool inLibraries = false;
            int exitSection = 0;
            string jsonLine = "";
            string locationLine = "";
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
                        jsonLine = Regex.Replace(fileArray[y], "[\t\n\r \",]", "");
                        string[] jsonKeyValue = jsonLine.Split(new char[] { ':' }, 2);
                        if (jsonKeyValue[0] == "name" && !jsonKeyValue[1].Contains("-nightly-") && jsonKeyValue[1] != "osx")
                        {
                            string[] colonSplit = jsonKeyValue[1].Split(new char[] { ':' }, 3);
                            string[] folderSplit = colonSplit[0].Split(new char[] { '.' });
                            for (int a = 0; a < folderSplit.Length; a++)
                            {
                                if (a == 0)
                                {
                                    locationLine = folderSplit[a];
                                }
                                else
                                {
                                    locationLine = locationLine + @"\" + folderSplit[a];
                                }
                            }
                            locationLine = locationLine + @"\" + colonSplit[1] + @"\" + colonSplit[2] + @"\" + colonSplit[1] + "-" + colonSplit[2];
                            if (fileArray[y].Contains("-platform"))
                            {
                                if (z > tmpNativeArray.Length - 1)
                                {
                                    Array.Resize(ref tmpNativeArray, tmpNativeArray.Length + 1);
                                }
                                tmpNativeArray[z] = locationLine + "-natives-windows.jar";
                                z++;
                            }
                            else
                            {
                                if (x > tmpLibrariesArray.Length - 1)
                                {
                                    Array.Resize(ref tmpLibrariesArray, tmpLibrariesArray.Length + 1);
                                }
                                tmpLibrariesArray[x] = locationLine + ".jar";
                                x++;
                            }
                        }
                    }
                    else
                    {
                        jsonLine = Regex.Replace(fileArray[y], "[\t\n\r \",]", "");
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
            //foreach (KeyValuePair<string, string[]> entry in tmpDict)
            //{
            //    if (entry.Key == "Libraries" || entry.Key == "Natives")
            //    {
            //        foreach (string line in entry.Value)
            //        {
            //            this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(line); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            //        }
            //    }
            //    else
            //    {
            //        this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText(entry.Value[0]); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            //    }
            //    this.Invoke(new MethodInvoker(delegate { homeTextBoxGeneral.AppendText("======================="); homeTextBoxGeneral.AppendText(Environment.NewLine); }));
            //}
            return tmpDict;
        }

        // This method is only developed for Minecraft's version file. It will not work with any other json file.
        public Dictionary<string, string[]> aJ_readJsonVer(string location)
        {
            Dictionary<string, string[]> tmpDict = new Dictionary<string, string[]>{
                {"Trash"          , new string[] { "None" }},
                {"Status"         , new string[] { "Failure" , "Version Does not exist."}}
            };
            if (!File.Exists(location)) { homeCancel = true; return tmpDict; };

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

            return tmpDict;
        }
    }
}
