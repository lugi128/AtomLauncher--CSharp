using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AtomLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string appData = Environment.GetEnvironmentVariable("APPDATA");
        public static bool is64Bit = Environment.Is64BitProcess;
        public static Dictionary<string, string> config;
        public static Dictionary<string, string> atomArgs;
        [STAThread]
        //Dictionary<string, string> 
        static void Main(string[] args)
        {
            atomArgs = atomFile.loadArgs(args);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Launcher());
        }
    }
}
