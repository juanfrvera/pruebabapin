using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using Contract;

namespace Bapin.WindowsService
{
    static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        public static void HandleException(Exception e)
        {
            if (e == null) return;
            Log.Error(e);
            //TODO: Send error by mail
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // Attach unhandled exception handler
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionManager;

            // This is used to debug the start of the winservice, define SHOULDATTACH with a pre-processor directive to enable it.
#if DEBUG && SHOULDATTACH
            Debugger.Launch();
#endif

            if (!log4net.LogManager.GetCurrentLoggers().Any())
            {
                // Configure logging
                string logConfigurationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", string.Empty));
                var file = new System.IO.FileInfo(Path.Combine(logConfigurationPath, "log4net.config.xml"));
                XmlConfigurator.Configure(file);
            }
           
            Console.WriteLine("Bapin Service Main...");

            LoadInitialSettings();

            var service = new BapinService();
            
            bool consoleMode = RunConsoleMode(service);

            if (args.Length > 0)
            {
                for (int ii = 0; ii < args.Length; ii++)
                {
                    switch (args[ii].ToLowerInvariant())
                    {
                        case "/i":
                            service.InstallService();
                            return;
                        case "/u":
                            service.UninstallService();
                            return;
                        case "/d":
                            consoleMode = RunConsoleMode(service);
                            break;
                    }
                }
            }

            if (!consoleMode)
            {
                ServiceBase.Run(new[] { service });
                Console.WriteLine("Bapin ServiceBase Started...");
            }
        }

        private static bool RunConsoleMode(BapinService service)
        {
            if (service == null) throw null;
#if DEBUG
            service.StartService();

            Console.WriteLine("Bapin Service Started...");
            Console.WriteLine("<press any key to exit...>");
            Console.ReadKey();

            Application.Exit();
            return true;
#endif

            return false;
        }

        private static void UnhandledExceptionManager(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private static void LoadInitialSettings()
        {
            WinServiceContext.Current.LoadManagers();
        }
    }
}
