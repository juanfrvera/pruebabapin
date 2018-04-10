using System;
using System.Configuration;
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
    public class CodigoPresupuestarioHandler : HandlerBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CodigoPresupuestarioHandler));

        public CodigoPresupuestarioHandler(string name, int pollingInterval, DateTime? scheduledTime)
            : base(name, pollingInterval, scheduledTime)
        {
        }

        protected override void DoProcess()
        {
            try
            {
                //var codPresupuestarioClient = new codPresupuestarioClient();
                try
                {
                    //DO THE MAGIC
                    Log.Info("CodigoPresupuestarioHandler " + DateTime.Now.ToShortDateString());
                    string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
                    Log.Info("CodigoPresupuestarioHandler strConexion=" + strConexion);
                    DatabaseGeneralManager.ActualizarBapines(strConexion);
                    return;
                }
                finally
                {
                    OnStatusUpdated(false, "Finished Processing Codigo Presupuestario.");
                }
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                OnStatusUpdated(false, "Failed Processing Codigo Presupuestario.");
                OnStatusUpdated(true, BapinService.BuildErrorDetails(ex));
            }
        }
    }
}
