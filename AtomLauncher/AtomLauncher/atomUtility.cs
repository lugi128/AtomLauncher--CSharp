using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AtomLauncher
{
    class atomUtility
    {
        internal static bool compareVersions(string versionOne, string versionTwo)
        {
            string[] oneSplit = versionOne.Split('.');
            string[] twoSplit = versionTwo.Split('.');
            int verLength = 0;
            foreach (string entry in oneSplit) { if (verLength < entry.Length) { verLength = entry.Length; } }
            foreach (string entry in twoSplit) { if (verLength < entry.Length) { verLength = entry.Length; } }
            for (int i = 0; i < oneSplit.Length; i++) { oneSplit[i] = oneSplit[i].PadLeft(verLength, '0'); }
            for (int i = 0; i < twoSplit.Length; i++) { twoSplit[i] = twoSplit[i].PadLeft(verLength, '0'); }
            if (Convert.ToDouble(string.Concat(oneSplit)) < Convert.ToDouble(string.Concat(twoSplit)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Compact(string text, Control ctrl)
        {
            using (Graphics dc = ctrl.CreateGraphics())
            {
                Size s = TextRenderer.MeasureText(dc, text, ctrl.Font);

                // control is large enough to display the whole text 
                if (s.Width <= ctrl.Width)
                    return text;

                int len = 0;
                int seg = text.Length;
                string fit = "";

                // find the longest string that fits into
                // the control boundaries using bisection method 
                while (seg > 1)
                {
                    seg -= seg / 2;

                    int left = len + seg;
                    int right = text.Length;

                    if (left > right)
                        continue;

                        right -= left;
                        left = 0;

                    // build and measure a candidate string with ellipsis
                    string tst = text.Substring(0, left) +
                        "...." + text.Substring(right);

                    s = TextRenderer.MeasureText(dc, tst, ctrl.Font);

                    // candidate string fits into control boundaries, 
                    // try a longer string
                    // stop when seg <= 1 
                    if (s.Width <= ctrl.Width)
                    {
                        len += seg;
                        fit = tst;
                    }
                }

                if (len == 0) // string can't fit into control
                {
                    return "....";
                }
                return fit;
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
    }
    // End
    /////////////////////////////////////
}
