using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Configuration;
using Contract;
using Service;
using nc = Contract;
using System.Collections.Generic;
using UI.Web;

namespace Application.Services
{
    /// <summary>
    /// Summary description for wsUsuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class wsConsultarBapin : System.Web.Services.WebService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ejercicio">(Long)  [*]</param>
        /// <param name="estado">(string Enumerativo: DEMANDA, PLAN, PLAN_SEGUN_EJECUCION) (lista string pipe separator) [*]</param>
        /// <param name="jurisdicción">(Long) [*]</param>
        /// <param name="bapin">(Long) </param>
        /// <param name="saf">(Long)</param>
        /// <param name="programas">(string) (lista long pipe separator)</param>
        /// <returns>xml -->
        /// bapin (Long)
        /// denominacion (String) 
        /// jurisdicción (Long)
        /// saf (Long)
        /// programa (Long)
        /// subprograma (Long)
        /// fecha inicio (Date)
        /// fecha fin (Date)
        /// costo total (Importe) (*)
        /// estado dictamen (Enumerativo: NND,SDF,AOP, ADO,ASO (**))
        /// último año demanda (Long)
        /// último año plan (Long)
        /// último año plan según ejecución(Long)
        /// </returns>
        [WebMethod]
        public string GetConsultarBapin(string login, string password, long ejercicio, string estado, long jurisdiccion, long bapin, long saf, string programas)
        {
            UIContext.Current.LoginWS(login, password);

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            return DatabaseGeneralManager.ConsultarBapines(strConexion, ejercicio, estado, jurisdiccion, bapin, saf, programas);
        }        
    }
}
