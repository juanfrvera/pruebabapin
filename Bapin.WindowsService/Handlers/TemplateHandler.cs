//using log4net;
using System;
using System.Threading;
using System.Threading.Tasks;
using Contract;

namespace Bapin.WindowsService.Handlers
{
    public class TemplateHandler : HandlerBase
    {
        //private static readonly ILog Log = LogManager.GetLogger(typeof(HandlerBase));

        public TemplateHandler(string name, int pollingInterval, DateTime? scheduledTime)
            : base(name, pollingInterval, scheduledTime)
        {
        }

        protected override void DoProcess()
        {
            //OnStatusUpdated(false, "Processing Update Template...");

            try
            {
                //var templateClient = new TemplateClient();
                try
                {
                    //await templateClient.FireUpdateTemplate();
                    //OnStatusUpdated(false, "Processing Template.");

                    //DO THE MAGIC
                    var idLastTemplateVersion = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue("ID_TEMPLATE_IMPORTACION");
                    OnStatusUpdated(false, "idLastTemplateVersion. " + idLastTemplateVersion);
                    return;
                }
                finally
                {
                    //OnStatusUpdated(false, "Finished Processing Template.");
                }
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                OnStatusUpdated(false, "Failed Processing Template.");
                OnStatusUpdated(true, BapinService.BuildErrorDetails(ex));
            }
        }
    }
}
