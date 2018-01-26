using ITsynch.ARMS.WinService.WebApiClient;
using log4net;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;

namespace ITsynch.ARMS.WinService.Handlers
{
    public class ClearAttachmentsHandler : HandlerBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ClearAttachmentsHandler));

        public ClearAttachmentsHandler(string name, int pollingInterval)
            : base(name, pollingInterval)
        {
        }

        protected override async Task DoProcess()
        {
            OnStatusUpdated(false, "Deleting attachments...");

            try
            {
                var messageClient = new MessageClient();
                try
                {
                    var settings = (NameValueCollection)ConfigurationManager.GetSection("clearAttachmentsSettings");
                    int months;
                    if (!int.TryParse(settings["keepAttachments"], out months))
                    {
                        months = 0;
                    }

                    if (months > 0)
                    {
                        DateTime date = DateTime.Now.AddMonths(-months);
                        await messageClient.ClearAttachments(date);
                    }
                }
                finally
                {
                    OnStatusUpdated(false, "Finished Deleting attachments.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                OnStatusUpdated(false, "Failed Deleting attachments.");
                OnStatusUpdated(true, ARMSReportingService.BuildErrorDetails(ex));
            }
        }
    }
}
