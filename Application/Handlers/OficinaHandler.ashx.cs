using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Service;
using System.Collections.Generic;
using nc = Contract;
using Newtonsoft.Json;
using System.Text;



namespace UI.Web
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class OficinaHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            nc.OficinaFilter filter = null;            
            int? id = null;
            try
            {
                string strId = context.Request.QueryString["Id"];
                int _id;
                if (int.TryParse(strId, out _id))id = _id;
                string jsonFilter = context.Request.QueryString["filter"];
                filter = JsonConvert.DeserializeObject<nc.OficinaFilter>(jsonFilter);
                if (filter == null) filter = new Contract.OficinaFilter();
                                
                if (id.HasValue == false)
                { //si esta en el root
                    filter.IdOficinaPadreIsNull = null;
                    filter.OrderByProperty = "BreadcrumbCodigo";
                    filter.Nivel = 2;
                    filter.Nivel_To = 2;
                    //filter.IdJurisdiccion = null;
                }
                else
                {                    
                    filter.IdOficinaPadre = id.Value;
                    filter.IdOficinaPadre_To = id.Value;
                    filter.OrderByProperty = "BreadcrumbCodigo"; 
                }
            }
            catch { }

            //Matias 20170119 - Ticket #ER326117
            filter.Activo = true;
            //FinMatias 20170119 - Ticket #ER326117

            List<nc.NodeResult> result =  OficinaService.Current.GetNodesResult(filter);
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            response.Write(json);
            response.End();
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
