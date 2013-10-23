using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtomLauncher
{
    class atomUtility
    {
        internal static bool compareVersions(string versionOne, string versionTwo)
        {
            string[] verSplit = versionOne.Split('.');
            string[] downSplit = versionTwo.Split('.');
            int verLength = 0;
            foreach (string entry in verSplit) { if (verLength < entry.Length) { verLength = entry.Length; } }
            foreach (string entry in downSplit) { if (verLength < entry.Length) { verLength = entry.Length; } }
            for (int i = 0; i < verSplit.Length; i++) { verSplit[i] = verSplit[i].PadLeft(verLength, '0'); }
            for (int i = 0; i < downSplit.Length; i++) { downSplit[i] = downSplit[i].PadLeft(verLength, '0'); }
            if (Convert.ToDouble(string.Concat(verSplit)) < Convert.ToDouble(string.Concat(downSplit)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /////////////////////////////////////
    // Start - 'string' Extensions. Example: randomString.Truncate(4)
    internal static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
        public static string TruncateDots(this string value, int maxLength)
        {
            return value.Length <= maxLength ? value : "..." + value.Substring(value.Length - maxLength + 3);
        }
    }
    // End
    /////////////////////////////////////
}
