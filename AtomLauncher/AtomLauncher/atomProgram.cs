using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace AtomLauncher
{
    static class atomProgram
    {
        public static string appData = Environment.GetEnvironmentVariable("APPDATA");
        public static bool debugApp = false; //Change this for testing purposes.
        public static string appDirectory = Assembly.GetExecutingAssembly().Location;
        public static bool is64Bit = Environment.Is64BitProcess;
        public static Dictionary<string, string> config;
        [STAThread]
        static void Main(string[] args)
        {
            //Disabled for custom styleing.
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve); //includes required included libraries.
            Application.Run(new atomLauncher());
        }

        //includes required included libraries.
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            String resourceName = "AtomLauncher." + new AssemblyName(args.Name).Name + ".dll";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}
