using ITsynch.ARMS.WinService.Handlers;
using ITsynch.Common.Extensions;
//using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Bapin.WindowsService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                     ConcurrencyMode = ConcurrencyMode.Multiple,
                     UseSynchronizationContext = false)]
    public class WinServiceConfigurationService : IWinServiceConfigurationService
    {
        //private static readonly ILog Log = LogManager.GetLogger(typeof(WinServiceConfigurationService));

        private static List<IWinServiceActivityCallback> callbackList = new List<IWinServiceActivityCallback>();

        public static void LogActivity(bool isError, string messageText)
        {
            foreach (var callback in callbackList.ToList())
            {
                try
                {
                    messageText = string.Format("{0:G} - {1}", DateTime.Now, messageText);
                    callback.LogActivity(messageText, isError);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    callbackList.Remove(callback);
                }
            }
        }

        public WinServiceConfiguration GetConfiguration()
        {
            var emailConfiguration = GlobalData.EmailConfiguration;
            return new WinServiceConfiguration
            {
                SmtpConfiguration = new SmtpConfiguration
                {
                    EmailAddress = emailConfiguration.EmailAddress,
                    EmailName = emailConfiguration.EmailName,
                    SmtpServer = emailConfiguration.SmtpServer,
                    SmtpPort = emailConfiguration.SmtpPort,
                    RequiresAuthentication = emailConfiguration.RequiresAuthentication,
                    UserName = emailConfiguration.UserName,
                },

                Handlers = GetHandlers().Select(x => GetHandlerInformation(x))
                                        .ToList(),
            };
        }

        public void StartLogging()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IWinServiceActivityCallback>();
            callback.LogActivity("Connected.", false);
            callbackList.Add(callback);
        }

        public void ChangeHandlerPolling(string name, int pollingInterval)
        {
            var handler = GetHandler(name);
            if (handler == null) return;

            if (pollingInterval < 1) return;
            handler.PollingInterval = pollingInterval;
        }

        public void StartProcessingHandle(string name)
        {
            var handler = GetHandler(name);
            if (handler == null) return;

            handler.StartProcess();
        }

        public void StopProcessingHandle(string name)
        {
            var handler = GetHandler(name);
            if (handler == null) return;

            handler.StopProcess();
        }

        private static HandlerInformation GetHandlerInformation(HandlerBase handler)
        {
            handler.ThrowIfNull(nameof(handler));

            return new HandlerInformation
            {
                Name = handler.Name,
                Enabled = handler.Enabled,
                PollingInterval = handler.PollingInterval,
            };
        }

        private static HandlerBase GetHandler(string name)
        {
            return GetHandlers().FirstOrDefault(x => string.Compare(x.Name, name, true, System.Globalization.CultureInfo.InvariantCulture) == 0);
        }

        private static IEnumerable<HandlerBase> GetHandlers()
        {
            return GlobalData.HandlerList.ToList();
        }
    }
}
