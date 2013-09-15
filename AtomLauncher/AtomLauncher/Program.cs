using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

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
            atomArgs = atomFileCode.loadArgs(args);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve); //include DotNetLib
            Application.Run(new Launcher());
        }

        //include DotNetLib
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AtomLauncher.Ionic.Zip.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}
