using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using Bapin.WindowsService.Configuration;
using Bapin.WindowsService.Handlers;
using log4net;

namespace Bapin.WindowsService
{
    public partial class BapinService : ServiceBase
    {
        private const string HANDLERSCONFIGURATIONSECTION = "handlersConfiguration";
        private static readonly ILog Log = LogManager.GetLogger(typeof(BapinService));
        private List<HandlerBase> handlers = new List<HandlerBase>();

        public BapinService()
        {
            InitializeComponent();
        }

        public delegate void StatusUpdatedEventHandler(bool isError, string messageText);

        public static string BuildErrorDetails(Exception e)
        {
            StringBuilder details = new StringBuilder();
            while (e != null)
            {
                details.AppendLine(e.Message);
                details.AppendLine(e.StackTrace);
                e = e.InnerException;
                if (e != null)
                    details.AppendLine(string.Format("Caused by:{0}", e.Message));
            }

            return details.ToString();
        }

        public static void LogException(Exception exc, BapinService.StatusUpdatedEventHandler handler)
        {
            try
            {
                if (handler != null)
                {
                    handler.Invoke(true, exc.Message);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        public bool IsServiceInstalled()
        {
            return ServiceController.GetServices().Any(s => s.ServiceName == ServiceName);
        }

        public void InstallService()
        {
            if (IsServiceInstalled())
            {
                UninstallService();
            }

            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        public void UninstallService()
        {
            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
        }

        internal void StartService()
        {
            OnStart(new string[0]);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                SetupHandlers();

                Console.WriteLine("Bapin Services Up and Running [Console]...");

                Log.Info("Bapin Services Up and Running...");
            }
            catch (Exception e)
            {
                Program.HandleException(e);
            }
        }

        protected override void OnStop()
        {
            //SetupHandlers();

            foreach(var handler in handlers)
            {
                handler.StopProcess();
            }
        }

        private static void StatusUpdated(bool isError, string messageText)
        {
            //TODO: log error or info
            Log.Info("Bapin Info: " + messageText + " isError: " + isError);
        }

        private void SetupHandlers()
        {
            var handlesConfiguration = ConfigurationManager.GetSection(HANDLERSCONFIGURATIONSECTION) as HandlerConfigurationSection;
            if (handlesConfiguration == null || handlesConfiguration.HandlerConfigurations == null) return;

            foreach (HandlerConfigurationElement handlerConfiguration in handlesConfiguration.HandlerConfigurations)
            {
                var handler = (HandlerBase)Activator.CreateInstance(handlerConfiguration.Type,
                                                                    handlerConfiguration.Name,
                                                                    handlerConfiguration.PollingInterval,
                                                                    handlerConfiguration.ScheduledTime);

                // Bind status updates
                handler.StatusUpdated += StatusUpdated;

                // Update global handler list
                handlers.Add(handler);
                //GlobalData.HandlerList.Add(handler);

                // Start running enabled handlers
                if (handlerConfiguration.Enabled)
                {
                    handler.StartProcess();
                }
            }
        }
    }
}
