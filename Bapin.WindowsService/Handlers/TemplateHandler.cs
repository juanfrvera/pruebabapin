using System;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using Contract;
using Service;
using Business;
using Business.Managers;
using log4net;
using OfficeOpenXml;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

namespace Bapin.WindowsService.Handlers
{
    public class TemplateHandler : HandlerBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TemplateHandler));

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

                    //Get Template ID
                    var idLastTemplateVersion = (Int32?)SolutionContext.Current.ParameterManager.GetNumberValue("ID_TEMPLATE_IMPORTACION");
                    
                    if (idLastTemplateVersion.HasValue && idLastTemplateVersion.Value > 0)
                    {
                        TemplateProjectManager.UpdateTemplateProjects(idLastTemplateVersion.Value);
                    }
                    else
                    {
                        Log.Error("ID_TEMPLATE_IMPORTACION is null or empty");
                    }

                    //OnStatusUpdated(false, "idLastTemplateVersion. " + idLastTemplateVersion);
                    return;
                }
                finally
                {
                    OnStatusUpdated(false, "Finished Processing Template.");
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
