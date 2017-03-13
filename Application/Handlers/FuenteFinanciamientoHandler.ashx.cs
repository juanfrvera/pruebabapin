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
    public class FuenteFinanciamientoHandler : IHttpHandler
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

            List<nc.NodeResult> result = FuenteFinanciamientoService.Current.GetNodesResult(new nc.FuenteFinanciamientoFilter() { IdFuenteFinanciamientoPadre = id, IdFuenteFinanciamientoPadreIsNull = !id.HasValue, OrderByProperty = "BreadcrumbCodigo" });
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
