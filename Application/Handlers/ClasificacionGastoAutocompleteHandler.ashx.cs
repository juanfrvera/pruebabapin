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
    public class ClasificacionGastoAutocompleteHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            nc.ClasificacionGastoFilter filter = null;
            string query = "";
            int aux;
            SelectOptionEnum selectOption = SelectOptionEnum.Undefined;
            ShowOptionEnum showOption = ShowOptionEnum.Undefined;
            
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.ContentEncoding = Encoding.UTF8;
            
            try
            {
                query = context.Request.QueryString["query"];
                string jsonFilter = context.Request.QueryString["filter"];
                filter = JsonConvert.DeserializeObject<nc.ClasificacionGastoFilter>(jsonFilter);
                if (int.TryParse(context.Request.QueryString["SelectOption"], out aux))
                    selectOption = (SelectOptionEnum)aux;
                if (int.TryParse(context.Request.QueryString["ShowOption"], out aux))
                    showOption = (ShowOptionEnum)aux;
            }
            catch { }

            if (filter == null) filter = new nc.ClasificacionGastoFilter();
            if (DataHelper.IsCode(query))
            {
                filter.BreadcrumbCode = "%" + query + "%";
                filter.OrderByProperty = "BreadcrumbCode";
            }
            else
            {
                filter.Nombre = "%" + query + "%";
                filter.OrderByProperty = "Descripcion";
            }
            if (selectOption == SelectOptionEnum.OnlySelectedDefined || selectOption == SelectOptionEnum.SelectedDefinedAndActualValue)
                filter.Seleccionable = true;
            if (showOption == ShowOptionEnum.Actives)
                filter.Activo = true;
            filter.PageSize=20;

            NodeList nodes = new NodeList();
            nodes.Nodes = ClasificacionGastoService.Current.GetNodesResult(filter);
            string json = JsonConvert.SerializeObject(nodes, Formatting.Indented);
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
