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
    /// Summary description for wsProyecto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class wsProyecto : System.Web.Services.WebService
    {

        [WebMethod]
        public string[] GetSimpleList(string prefixText, int count)
        { 
            List<nc.SimpleResult<int>> result = ProyectoService.Current.GetSimpleList(new nc.ProyectoFilter() { ProyectoDenominacion = prefixText + "%", PageSize = count, OrderByProperty = "ProyectoDenominacion" });
            List<string> retval = new List<string>(result.Count);
            foreach (nc.SimpleResult<int> r in result)
                retval.Add("|" + r.Text.TrimEnd() + "|" + r.ID);
            return retval.ToArray();
        }   
    }
}
