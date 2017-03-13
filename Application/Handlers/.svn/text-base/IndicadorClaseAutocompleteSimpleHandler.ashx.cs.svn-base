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
    public class IndicadorClaseAutocompleteSimpleHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            nc.IndicadorClaseFilter filter = null;
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
                filter = JsonConvert.DeserializeObject<nc.IndicadorClaseFilter>(jsonFilter);
                if (filter.IdIndicadorRubro <= 0)
                        filter.IdIndicadorRubro = null;
                if (int.TryParse(context.Request.QueryString["SelectOption"], out aux))
                    selectOption = (SelectOptionEnum)aux;
                if (int.TryParse(context.Request.QueryString["ShowOption"], out aux))
                    showOption = (ShowOptionEnum)aux;
            }
            catch { }

            if (filter == null) filter = new nc.IndicadorClaseFilter();

            filter.BusquedaIndicador = query;

            //if (DataHelper.IsCode(query))
            //{
            //    filter.BreadcrumbCode = "%" + query + "%";
            //    filter.OrderByProperty = "BreadcrumbCode";
            //}
            //else
            //{
            //    filter.Nombre = "%" + query + "%";
            //    filter.OrderByProperty = "Descripcion";
            //}

            //if (selectOption == SelectOptionEnum.OnlySelectedDefined || selectOption == SelectOptionEnum.SelectedDefinedAndActualValue)
            //    filter.Seleccionable = true;
            
                filter.Activo = true;

            //Matias 20170125 - Ticket #ER905084
            //if (showOption == ShowOptionEnum.Actives)
            //  filter.Activo = true;
            if ((showOption == ShowOptionEnum.Actives) || (showOption == ShowOptionEnum.ActivesAndActualValue))
                filter.Activo = true;
            //FinMatias 20170119 - Ticket #ER905084

            filter.PageSize = 20;

            SimpleList<int> list = new SimpleList<int>();

            
            List<IndicadorClaseResult> result = IndicadorClaseService.Current.GetResult(filter);

            foreach (IndicadorClaseResult item in result)
            {
                list.Items.Add(new SimpleResult<int> { ID = item.ID, Text = "[" + item.Sigla.Trim() + "] " + item.Nombre.Trim() + " (" + item.Unidad_Sigla.Trim() + ")" });
            }
            
            

            //list.Items = IndicadorClaseService.Current.GetSimpleList(filter);
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
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