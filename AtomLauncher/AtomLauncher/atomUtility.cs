using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtomLauncher
{
    class atomUtility
    {
        //Fill with random needed methods.
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
            return value.Length <= maxLength ? value : "..." + value.Substring(value.Length - maxLength);
        }
    }
    // End
    /////////////////////////////////////
}
