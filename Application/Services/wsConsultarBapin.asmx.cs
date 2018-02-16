using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
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
        public string GetConsultarBapin()
        {
            //string login, string password, long ejercicio, List<string> estados, long jurisdiccion, long bapin, long saf, string programas

            // Initialize soap request XML
            XmlDocument xmlSoapRequest = new XmlDocument();

            try
            {
                // Get raw request
                using (Stream receiveStream = HttpContext.Current.Request.InputStream)
                {
                    // Move to begining of input stream and read
                    receiveStream.Position = 0;
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        // Load into XML document
                        xmlSoapRequest.Load(readStream);
                    }
                }
            }
            catch (Exception ex)
            {
                SoapException se = new SoapException("XML read error",
                      SoapException.ClientFaultCode,
                      Context.Request.Url.AbsoluteUri,
                      ex);
            }

            string userName;
            string password;
            try
            {
                XmlDocument soapHeader = new XmlDocument();
                soapHeader.LoadXml(xmlSoapRequest.GetElementsByTagName("soap:Header").Item(0).InnerXml);
                userName = soapHeader.GetElementsByTagName("Username")[0].InnerText;
                password = soapHeader.GetElementsByTagName("Password")[0].InnerText;
            }
            catch(Exception ex)
            {
                SoapException se = new SoapException("Username or password inválido",
                                      SoapException.ClientFaultCode,
                                      Context.Request.Url.AbsoluteUri,
                                      ex);
                //log xmlSoapRequest.ChildNodes[0]
                throw se;
            }

            long ejercicio;
            try
            {
                ejercicio = Int64.Parse(xmlSoapRequest.GetElementsByTagName("tem:ejercicio")[0].InnerText);
            }
            catch (Exception ex)
            {
                SoapException se = new SoapException("ejercicio inválido",
                                      SoapException.ClientFaultCode,
                                      Context.Request.Url.AbsoluteUri,
                                      ex);
                throw se;
            }

            List<string> estados = new List<string>();
            try
            {
                estados = xmlSoapRequest.GetElementsByTagName("tem:estado").Cast<XmlNode>()
                               .Select(node => node.InnerText)
                               .ToList();
                if (estados.Count < 1) throw new Exception("Parámetro estados es requerido");
            }
            catch (Exception ex)
            {
                SoapException se = new SoapException("Parámetro estados inválido",
                                      SoapException.ClientFaultCode,
                                      Context.Request.Url.AbsoluteUri,
                                      ex);
                throw se;
            }

            long jurisdiccion;
            try
            {
                jurisdiccion = Int64.Parse(xmlSoapRequest.GetElementsByTagName("tem:jurisdiccion")[0].InnerText);
            }
            catch (Exception ex)
            {
                SoapException se = new SoapException("jurisdicción inválido",
                                      SoapException.ClientFaultCode,
                                      Context.Request.Url.AbsoluteUri,
                                      ex);
                throw se;
            }

            long bapin = 0;
            try
            {
                if (xmlSoapRequest.GetElementsByTagName("tem:bapin").Count > 0)
                {
                    bapin = Int64.Parse(xmlSoapRequest.GetElementsByTagName("tem:bapin")[0].InnerText);
                }
            }
            catch (Exception ex)
            {
                SoapException se = new SoapException("bapin inválido",
                                      SoapException.ClientFaultCode,
                                      Context.Request.Url.AbsoluteUri,
                                      ex);
                throw se;
            }

            long saf = 0;
            try
            {
                if (xmlSoapRequest.GetElementsByTagName("tem:bapin").Count > 0)
                {
                    saf = Int64.Parse(xmlSoapRequest.GetElementsByTagName("tem:saf")[0].InnerText);
                }
            }
            catch (Exception ex)
            {
                SoapException se = new SoapException("saf inválido",
                                      SoapException.ClientFaultCode,
                                      Context.Request.Url.AbsoluteUri,
                                      ex);
                throw se;
            }

            List<string> programas = new List<string>();
            try
            {
                if (xmlSoapRequest.GetElementsByTagName("tem:programas").Count > 0)
                {
                    programas = xmlSoapRequest.GetElementsByTagName("tem:programa").Cast<XmlNode>()
                                   .Select(node => node.InnerText)
                                   .ToList();
                }
            }
            catch (Exception ex)
            {
                SoapException se = new SoapException("Parámetro programas inválido",
                                      SoapException.ClientFaultCode,
                                      Context.Request.Url.AbsoluteUri,
                                      ex);
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
                  Context.Request.Url.AbsoluteUri,
                  ex);
                throw se;
            }

            try
            {
                var estadosList = String.Join("|", estados);
                var programasList = String.Join("|", programas);
                string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
                return DatabaseGeneralManager.ConsultarBapines(strConexion, ejercicio, estadosList, jurisdiccion, bapin, saf, programasList);
            }
            catch (Exception ex)
            {
                //Throw the exception    
                SoapException se = new SoapException("Fault occurred",
                  SoapException.ClientFaultCode,
                  Context.Request.Url.AbsoluteUri,
                  xmlSoapRequest.ChildNodes[0],
                  ex);
                throw se;
            }
        }
    }
}
