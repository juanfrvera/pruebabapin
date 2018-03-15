using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Contract;
using System.Configuration;
using Service;

using System.Web;
using System.Web.Services;
using System.IO;
using System.Xml;
using System.Web.Services.Protocols;

using System.ServiceModel.Channels;
using System.ServiceModel.Activation;
using System.Data;
using System.Data.Linq;
using System.Data.Common;

namespace UI.Web.Services
{
    [DataContract]
    public class RequestMessage
    {
        [DataMember(IsRequired = true, Order=1)]
        public long ejercicio { get; set; }
        [DataMember(IsRequired = true, Order = 2)]
        public List<estadoBapinType> estados { get; set; }
        [DataMember(IsRequired = true, Order = 3)]
        public long jurisdiccion { get; set; }
        [DataMember(Order = 4)]
        public long bapin { get; set; }
        [DataMember(Order = 5)]
        public long saf { get; set; }
        [DataMember(Order = 6)]
        public List<long> programas { get; set; }
        //long ejercicio, List<estadoBapinType> estados, long jurisdiccion, long bapin, long saf, List<long> programas
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Bapines" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Bapines.svc or Bapines.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class Bapines : IBapin
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
        public List<BapinResult> GetAllBapines(RequestMessage request)
        {
            //string username, string password, 
            var myService = OperationContext.Current.InstanceContext.GetServiceInstance();
            var message = OperationContext.Current.RequestContext.RequestMessage;
            var sessionId = OperationContext.Current.SessionId;

            // Initialize soap request XML
            XmlDocument xmlSoapRequest = new XmlDocument();
            try
            {
                //Load Raw soap message
                xmlSoapRequest.LoadXml(message.ToString());
            }
            catch (Exception ex)
            {
                SoapException se = new SoapException("XML read error",
                      SoapException.ClientFaultCode,
                      "Request.Url.AbsoluteUri",
                      ex);
            }

            string userName;
            string password;
            try
            {
                XmlDocument soapHeader = new XmlDocument();
                soapHeader.LoadXml(xmlSoapRequest.GetElementsByTagName("wsse:Security").Item(0).InnerXml);
                //wsse:Security
                userName = soapHeader.GetElementsByTagName("wsse:Username")[0].InnerText;
                password = soapHeader.GetElementsByTagName("wsse:Password")[0].InnerText;
            }
            catch (Exception ex)
            {
                SoapException se = new SoapException("Username or password inválido",
                                      SoapException.ClientFaultCode,
                                      "Context.Request.Url.AbsoluteUri",
                                      ex);
                //log xmlSoapRequest.ChildNodes[0]
                throw se;
            }

            try
            {
                UIContext.Current.LoginWS(userName, password);
            }
            catch (Exception ex)
            {
                //Throw the exception    
                SoapException se = new SoapException("Login error",
                  SoapException.ClientFaultCode,
                  "Context.Request.Url.AbsoluteUri",
                  ex);
                throw se;
            }

            List<BapinResult> lstBapines = new List<BapinResult>();

            /// bapin (Long)
            /// denominacion (String) 
            /// jurisdiccion (Long)
            /// saf (Long)
            /// programa (Long)
            /// subprograma (Long)
            /// fecha inicio (Date)
            /// fecha fin (Date)
            /// costo total (Importe)

            var estadosList = request.estados.Select(x => x.ToString()).ToList();

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            var xmlBapines = DatabaseGeneralManager.ConsultarBapines(strConexion, request.ejercicio, estadosList, request.jurisdiccion, request.bapin, request.saf, request.programas);
            
            xmlBapines.Namespace = "http://tempuri.org/";
            var dt = xmlBapines.Tables[0];

            List<BapinResult> items = dt.AsEnumerable().Select(row =>
                new BapinResult
                {
                    bapin = row.Field<long>("bapin"),
                    denominacion = row.Field<string>("denominacion"),
                    jurisdiccion = row.Field<long>("jurisdiccion"),
                    saf = row.Field<long>("saf"),
                    programa = row.Field<long>("programa"),
                    subprograma = row.Field<long>("subprograma"),
                    fecha_inicio = row.Field<DateTime?>("fecha_inicio"),
                    fecha_fin = row.Field<DateTime?>("fecha_fin"),
                    costo_total = row.Field<decimal>("costo_total"),
                    estado_dictamen = (EstadoDictamen)Enum.Parse(typeof(EstadoDictamen), row.Field<string>("estado_dictamen")),
                    ultimo_anio_demanda = row.Field<long>("ultimo_anio_demanda"),
                    ultimo_anio_plan = row.Field<long>("ultimo_anio_plan"),
                    ultimo_anio_plan_segun_ejecucion = row.Field<long>("ultimo_anio_plan_segun_ejecucion")
                }).ToList();

            return items;
        }
    }
}
