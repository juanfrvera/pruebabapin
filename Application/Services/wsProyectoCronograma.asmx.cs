using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Service;
using nc = Contract;
using System.Collections.Generic;

namespace Application.Services
{
    /// <summary>
    /// Summary description for wsProyectoCronograma
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class wsProyectoCronograma : System.Web.Services.WebService
    {
        [WebMethod]
        public string[] GetCalificacionGastoPorCodigo(string prefixText, int count)
        {
            return GetCalificacionGastos(true, prefixText, count);
        }
        [WebMethod]
        public string[] GetCalificacionGastoPorDescripcion(string prefixText, int count)
        {
            return GetCalificacionGastos(false, prefixText, count);
        }
        
        private string[] GetCalificacionGastos(bool PorCodigo, string prefixText, int count)
        {
            List<nc.ClasificacionGastoResult> results = ClasificacionGastoService.Current.GetClasificacionGastos(PorCodigo, prefixText + "%");
            List<string> retval = new List<string>(results.Count);
            foreach (nc.ClasificacionGastoResult r in results)
            {
                retval.Add("|" + r.Codigo + "-" + r.Nombre + "|" + r.IdClasificacionGasto);
                if (retval.Count > 10) break;
            }
            return retval.ToArray();
        }     
    }
}
