using Bapin.WindowsService.Handlers;
//using Bapin.WindowsService.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bapin.WindowsService
{
    public static class GlobalData
    {
        static GlobalData()
        {
            HandlerList = new List<HandlerBase>();
        }

        public static ICollection<HandlerBase> HandlerList { get; private set; }

        /*public static EmailConfiguration EmailConfiguration { get; set; }
        
        public static async Task Setup()
        {
            //await ReadSettings();
        }

        
        private static async Task ReadSettings()
        {
            try
            {
                WinServiceConfigurationService.LogActivity(false, "Reading SMTP configuration...");

                // Load application settings
                var settingsClient = new SettingsClient();
                try
                {
                    EmailConfiguration settings = await settingsClient.GetEmailConfiguration();
                    if (settings == null)
                    {
                        WinServiceConfigurationService.LogActivity(false, "Smtp configuration not founded.");
                        return;
                    }

                    EmailConfiguration = settings;
                }
                finally
                {
                    WinServiceConfigurationService.LogActivity(false, "Finished Reading SMTP configuration.");
                }
            }
            catch (Exception ex)
            {
                WinServiceConfigurationService.LogActivity(true, "Failed Reading SMTP configuration.");
                WinServiceConfigurationService.LogActivity(true, BapinReportingService.BuildErrorDetails(ex));
            }
        }
        */
    }
}
