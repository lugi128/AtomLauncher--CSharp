using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

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
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new atomLauncher());
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)//includes required included libraries.
        {
            String resourceName = "AtomLauncher." + new AssemblyName(args.Name).Name + ".dll";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {

            MessageBox.Show("Copy this error and report it please.\n\nTo Copy Press [Ctrl] + [C].\n\n" + e.Exception.ToString(), "Unhandled Thread Exception");
            Environment.Exit(0);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Copy this error and report it please.\n\nTo Copy Press [Ctrl] + [C].\n\n" + (e.ExceptionObject as Exception).ToString(), "Unhandled UI Exception");
            Environment.Exit(0);
        }
    }
}
