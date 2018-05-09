using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Service;
using Contract;
using Business;
using Business.Managers;
using log4net;
using log4net.Config;
using System.IO;

namespace Test
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            // Configure logging
            string logConfigurationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", string.Empty));
            var file = new System.IO.FileInfo(Path.Combine(logConfigurationPath, "log4net.config.xml"));
            XmlConfigurator.Configure(file);

            LoadInitialSettings();

            //  List<Parameter> parameters = ParameterService.Current.GetList(new ParameterFilter() {  Name = "%suario%" });
            //parameters.ForEach(p => Show(p));
       
            //List<AuditOperationResult> list= AuditOperationService.Current.GetResult(new AuditOperationFilter() { StartDate = DateTime.Now.AddDays(-30), StartDate_To = DateTime.Now });
            //list.ForEach(p => Show(p));

            //ListPaged<AuditSession> listpaged = AuditSessionService.Current.GetList(new AuditSessionFilter() { OrderByProperty = "StartDate", OrderByDesc = true, PageSize = 10, PageNumber = 2 });
            //listpaged.ForEach(p => Show(p));

            
            //EsidifWSClient.CallWebService();
            //EsidifWSClient ws = new EsidifWSClient();

            Console.WriteLine("Testing webservices");

            Console.WriteLine("Calling ping ...");
            Log.Info("Calling ping ...");
            var ping= EsidifManager.Ping();
            Log.Info("Ping response: " + ping);
            Console.WriteLine(ping); 
            Console.WriteLine("");

            /*
            Console.WriteLine("Calling change password ...");
            Log.Info("Calling change password ...");
            Console.WriteLine(EsidifManager.ChangePassword());
            Console.WriteLine("");
            */

            Console.WriteLine("Calling Consultar APG Bapines ...");
            Console.WriteLine(EsidifManager.ConsultarAPGBapines(new DatosBapinType(){ 
                ejercicio = 2019,
                jurisdiccion = 80,
                estados = new EstadoBapinType?[] { EstadoBapinType.DEMANDA}
            }));

            Console.ReadKey();
        }
      
        static void Show(Parameter parameter)
        {
            Console.WriteLine(string.Format("Id:{0} name:{1} Code:{2}",parameter.IdParameter, parameter.Name, parameter.Code));
        }
        static void Show(AuditOperationResult result)
        {
            Console.WriteLine(string.Format("IP:{0} operation:{1}", result.AuditSession_IP, result.Operation));
        }
        static void Show(AuditSession entity)
        {
            Console.WriteLine(string.Format("IP:{0} Fecha:{1:dd/MM/yyyy}", entity.IP, entity.StartDate));
        }

        private static void LoadInitialSettings()
        {
            TestContext.Current.LoadManagers();
        }
    }
}
