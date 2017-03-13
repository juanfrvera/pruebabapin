using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service;
using nc = Contract;
using Contract;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {           

          //  List<Parameter> parameters = ParameterService.Current.GetList(new ParameterFilter() {  Name = "%suario%" });
          //parameters.ForEach(p => Show(p));

         
                   
          //List<AuditOperationResult> list= AuditOperationService.Current.GetResult(new AuditOperationFilter() { StartDate = DateTime.Now.AddDays(-30), StartDate_To = DateTime.Now });
          //list.ForEach(p => Show(p));


            ListPaged<AuditSession> listpaged = AuditSessionService.Current.GetList(new AuditSessionFilter() { OrderByProperty = "StartDate", OrderByDesc = true, PageSize = 10, PageNumber = 2 });
            listpaged.ForEach(p => Show(p));

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
    }

    




}
