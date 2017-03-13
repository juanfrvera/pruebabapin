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
    public class IndicadorClaseSinSectorHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            nc.IndicadorClaseFilter filter = null;
            string jsonFilter = context.Request.QueryString["filter"];
            filter = JsonConvert.DeserializeObject<nc.IndicadorClaseFilter>(jsonFilter);

            string strId = context.Request.QueryString["Id"];
            int? id = null;
            int _id;
            if (int.TryParse(strId, out _id))
                id = _id;

            //Matias 20170125 - Ticket #ER905084
            filter.Activo = true;
            //FinMatias 20170125 - Ticket #ER905084
           
            List<nc.NodeResult> result = new List<nc.NodeResult>();
            if(id == null)
                result = IndicadorClaseService.Current.GetNodesResult(new nc.IndicadorClaseFilter() { Activo = filter.Activo, IdIndicadorClase = id, IdIndicadorTipo = filter.IdIndicadorTipo, OrderByProperty = "Id" });

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
