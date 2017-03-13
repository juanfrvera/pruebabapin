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
    public class DestinatarioAutocompleteSimpleHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            nc.UsuarioFilter filter = null;
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
                filter = JsonConvert.DeserializeObject<nc.UsuarioFilter>(jsonFilter);
                if (int.TryParse(context.Request.QueryString["SelectOption"], out aux))
                    selectOption = (SelectOptionEnum)aux;
                if (int.TryParse(context.Request.QueryString["ShowOption"], out aux))
                    showOption = (ShowOptionEnum)aux;
            }
            catch { }

            if (filter == null) filter = new nc.UsuarioFilter();

           // filter.BusquedaIndicador = query;

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
            
            if (showOption == ShowOptionEnum.Actives)
                filter.Activo = true;
            
            filter.PageSize = 20;
            filter.NombreCompleto = "%" + query + "%"; //Matias 20131204 - Tarea 96 - Agregué el << "%" + >> inicial para poder buscar completo (x NyAp).
            filter.OrderByProperty = "Persona_NombreCompleto";
            SimpleList<int> list = new SimpleList<int>();

            list.Items = UsuarioService.Current.GetSimpleList(filter);

            //List<nc.SimpleResult<int>> result = UsuarioService.Current.GetSimpleList(new nc.UsuarioFilter() { NombreCompleto = prefixText + "%", PageSize = count, OrderByProperty = "Persona_NombreCompleto", Activo = true });                    
            //List<UsuarioResult> result = UsuarioService.Current.GetResult(filter);


            /*
            foreach (IndicadorClaseResult item in result)
            {
                list.Items.Add(new SimpleResult<int> { ID = item.ID, Text = "[" + item.Sigla.Trim() + "] " + item.Nombre.Trim() + " (" + item.Unidad_Sigla.Trim() + ")" });
            }
            */
            

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
    