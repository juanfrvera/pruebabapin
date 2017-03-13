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
using Contract;



namespace UI.Web
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ClasificacionGeograficaHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;

            string strId = context.Request.QueryString["Id"];
            int? id = null;
            int _id;
            if (int.TryParse(strId, out _id))
                id = _id;

            ListPaged<NodeResult> result = ClasificacionGeograficaService.Current.GetNodesResult(new nc.ClasificacionGeograficaFilter() { IdClasificacionGeograficaPadre = id, IdClasificacionGeograficaPadreIsNull = !id.HasValue, OrderByProperty = "Codigo"});
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            response.Write(json);
            response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
