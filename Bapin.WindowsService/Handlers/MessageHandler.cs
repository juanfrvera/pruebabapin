using ITsynch.ARMS.WinService.WebApiClient;
using log4net;
using System;
using System.Threading.Tasks;

namespace ITsynch.ARMS.WinService.Handlers
{
    public class MessageHandler : HandlerBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HandlerBase));

        public MessageHandler(string name, int pollingInterval)
            : base(name, pollingInterval)
        {
        }

        protected override async Task DoProcess()
        {
            OnStatusUpdated(false, "Processing Pending Messages...");

            try
            {
                var messagesClient = new MessageClient();

                try
                {
                    await messagesClient.SendPendingMessages();
                }
                finally
                {
                    OnStatusUpdated(false, "Finished Processing Pending Messages.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                OnStatusUpdated(false, "Failed Processing Pending Messages.");
                OnStatusUpdated(true, ARMSReportingService.BuildErrorDetails(ex));
            }
        }
    }
}
