using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Drawing;

namespace AtomLauncher
{
    static class atomProgram
    {
        public static string appData = Environment.GetEnvironmentVariable("APPDATA");
        public static string appDirectoryFile = Assembly.GetExecutingAssembly().Location;
        public static bool is64Bit = Environment.Is64BitProcess;
        internal static FontFamily customFontFamily;
        internal static Font smallCustom = new Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        internal static Font mediuCustom = new Font("Lucida Console", 13.5F, System.Drawing.FontStyle.Bold);
        //internal static Font LargeCustom;
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new atomLauncher());
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) //includes required included libraries.
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
            System.IO.File.AppendAllText(@".\ALCrash.log", "[AtomLauncher][" + DateTime.Now.Date + "][" + DateTime.Now.TimeOfDay + "]: " + e.Exception.ToString() + Environment.NewLine);
            MessageBox.Show("Error Saved to 'ALCrash.log'. Report this please.\n\nTo Copy Press [Ctrl] + [C].\n\n" + e.Exception.ToString(), "Unhandled Thread Exception");
            Environment.Exit(0);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            System.IO.File.AppendAllText(@".\ALCrash.log", "[AtomLauncher][" + DateTime.Now.Date + "][" + DateTime.Now.TimeOfDay + "]: " + (e.ExceptionObject as Exception).ToString() + Environment.NewLine);
            MessageBox.Show("Error Saved to 'ALCrash.log'. Report this please.\n\nTo Copy Press [Ctrl] + [C].\n\n" + (e.ExceptionObject as Exception).ToString(), "Unhandled UI Exception");
            Environment.Exit(0);
        }
    }
}
