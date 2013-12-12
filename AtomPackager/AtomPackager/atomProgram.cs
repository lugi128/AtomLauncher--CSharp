using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Drawing;

namespace AtomPackager
{
    static class atomProgram
    {
        public static string appDirectoryFile = Assembly.GetExecutingAssembly().Location;
        public static bool is64Bit = Environment.Is64BitProcess;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new atomPackager());
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) //includes required included libraries.
        {
            String resourceName = "AtomPackager." + new AssemblyName(args.Name).Name + ".dll";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                Byte[] assemblyData = new Byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            System.IO.File.AppendAllText(@".\APCrash.log", "[AtomPackager][" + DateTime.Now.Date + "][" + DateTime.Now.TimeOfDay + "]: " + e.Exception.ToString() + Environment.NewLine);
            MessageBox.Show("Error Saved to 'APCrash.log'. Report this please.\n\nTo Copy Press [Ctrl] + [C].\n\n" + e.Exception.ToString(), "Unhandled Thread Exception");
            Environment.Exit(0);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            System.IO.File.AppendAllText(@".\APCrash.log", "[AtomPackager][" + DateTime.Now.Date + "][" + DateTime.Now.TimeOfDay + "]: " + (e.ExceptionObject as Exception).ToString() + Environment.NewLine);
            MessageBox.Show("Error Saved to 'APCrash.log'. Report this please.\n\nTo Copy Press [Ctrl] + [C].\n\n" + (e.ExceptionObject as Exception).ToString(), "Unhandled UI Exception");
            Environment.Exit(0);
        }
    }
}
