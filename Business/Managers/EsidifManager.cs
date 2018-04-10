using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Net;
using System.IO;

namespace Business.Managers
{
    public static class  EsidifManager
    {
        //private static string _url = SolutionContext.Current.ParameterManager.GetStringValue("URL_ESIDIF"); // "https://tws8-si.mecon.gov.ar/SD_Core/ws/"
        private static string _url { get { return SolutionContext.Current.ParameterManager.GetStringValue("URL_ESIDIF"); } }
        //private static string _url = "https://tws-si.mecon.gov.ar/SD_Core/ws/";
        //private static string _url = "http://Pipo-PC:8088/mockconsultarAPGBapinesSoap11/";

        private static HttpWebRequest CreateWebRequest(string action)
        {
            if(String.IsNullOrEmpty(EsidifManager._url))
            {
                throw new Exception("ParameterManager URL_ESIDIF null or empty");
            }
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(EsidifManager._url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        /// <summary>
        /// Together with the AcceptAllCertifications method right
        /// below this causes to bypass errors caused by SLL-Errors.
        /// </summary>
        private static void IgnoreBadCertificates()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        }

        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private static string  DoWebRequest(WebRequest webRequest)
        {
            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;

            try
            {
                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                    }

                    return soapResult;
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string readerString = reader.ReadToEnd();
                    XDocument doc = XDocument.Parse(readerString);
                    //string myNamespace = "https://ws-si.mecon.gov.ar/ws/error/";
                    //var a = doc.Descendants().Elements().Select(x => x.Name).ToArray();
                    //Console.WriteLine(a);
                    var errorCode = doc.Descendants().Elements("{https://ws-si.mecon.gov.ar/ws/error/}ErrorCode").FirstOrDefault().Value;
                    var errorDescription = doc.Descendants().Elements("{https://ws-si.mecon.gov.ar/ws/error/}ErrorDescription").FirstOrDefault().Value;
                    //doc.Descendants().Elements("{http://service.seguridad.esidif.mecon.gov.ar}ping").FirstOrDefault().Value;
                    return errorDescription;
                }
            }
            catch (Exception ex)
            {
                // Something more serious happened
                // like for example you don't have network access
                // we cannot talk about a server exception here as
                // the server probably was never reached
                throw (ex);
            }
        }

        public static string Ping()
        {
            var _action = "seguridad/pingService";

            IgnoreBadCertificates();

            XmlDocument soapEnvelopeXml = CreatePingSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            string soapResult = DoWebRequest(webRequest);

            XDocument doc = XDocument.Parse(soapResult);

            //{http://service.seguridad.esidif.mecon.gov.ar}ping
            return doc.Descendants().Elements("{http://service.seguridad.esidif.mecon.gov.ar}ping").FirstOrDefault().Value;
        }

        public static string ChangePassword()
        {
            var _action = "seguridad/changePasswordService";

            IgnoreBadCertificates();

            XmlDocument soapEnvelopeXml = CreateChangePasswordSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            string soapResult = DoWebRequest(webRequest);
            return soapResult;

            //XDocument doc = XDocument.Parse(soapResult);
            //return soapResult.ToString();
        }

        public static string ConsultarAPGBapines(DatosBapinType datosBapinType)
        {
            var _action = "entidades_basicas/consultarAPGBapinesService";

            IgnoreBadCertificates();

            XmlDocument soapEnvelopeXml = CreateConsultarBapinSoapEnvelope(datosBapinType);
            HttpWebRequest webRequest = CreateWebRequest(_action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            string soapResult = DoWebRequest(webRequest);
            XDocument doc = XDocument.Parse(soapResult);
            XNamespace ns = @"http://schemas.xmlsoap.org/soap/envelope/";
            var unwrappedResponse = doc.Descendants((XNamespace)"http://schemas.xmlsoap.org/soap/envelope/" + "Body").First().FirstNode;
            XmlSerializer oXmlSerializer = new XmlSerializer(typeof(ConsultarAperturasBapines), "http://bapin.jaxb.webServices.entidadesBasicas.esidif.mecon.gov.ar");

            //var responseObj = (ConsultarAperturasBapines)oXmlSerializer.Deserialize(unwrappedResponse.CreateReader());

            return unwrappedResponse.ToString();
            //return (responseObj !=null && responseObj.bapines != null) ? responseObj.bapines.ToList() : new List<APGBapin>();
        }

        public static IEnumerable<APGBapin> GetRewriteXML(XDocument xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(APGBapin));

            var nodes = xml.Descendants("RewriteRule")
                        .Select(rr => xmlSerializer.Deserialize(rr.CreateReader()) as APGBapin);

            return nodes;
        }

        public static string ConsultarAPGBapines2()
        {
            /*
            // This is the client proxy
            consultarAPGBapines proxy = new consultarAPGBapinesClient();

            Business.ConsultarAPGBapinesServiceReference.datosBapinType datosBapin = new datosBapinType()
            {
                ejercicio = 2018
            };
            // Based on all of the examples I saw, I thought I would be able to 
            // call the methods directly, such as proxy.getLoginInfo(), 
            // proxy.LogIn(), etc. But, that is not how it works in this example.
            // I will need to create the Request and Response Objects
            // This object will contain the login info: roles, databases, etc.
//            consultarAPGBapines loginInfo = new consultarAPGBapines(datosBapin);
            // This request object contains the loginInfo object 
            consultarAPGBapinesRequest loginRequest = new consultarAPGBapinesRequest(datosBapin);
            // This response object will contain the loginInfo object populated 
            // with roles, databases, etc.
            consultarAPGBapinesResponse loginResponse;
            // Send the request
            loginResponse = proxy.consultarAPGBapines(loginRequest);
            // Get the loginInfo data from the response
            aperturaBapinType[] response;
            response = loginResponse.consultarAperturasBapinesResponse;

            return response.FirstOrDefault().codigoBapin.ToString();
            */
            return string.Empty;

            /*
            foreach (DatabaseInfo db in response.loginInfo.databases)
            {
                Debug.WriteLine("Database: " + db.name);
            }
            foreach (string role in response.loginInfo.loginRoles)
            {
                Debug.WriteLine("Role: " + role);
            }
            */

            // This is the client proxy
            /*
            consultarAPGBapinesClient proxy = new consultarAPGBapinesClient();

            Business.ConsultarAPGBapinesServiceReference.datosBapinType datosBapin = new datosBapinType()
            {
                ejercicio = 2018
            };

            consultarAPGBapinesRequest request = new consultarAPGBapinesRequest(datosBapin);

            consultarAPGBapinesResponse consultaResponse;
            consultaResponse = proxy.consultarAPGBapines(request);

            // Get the loginInfo data from the response
            aperturaBapinType[] response;
            response = consultaResponse.consultarAperturasBapinesResponse;

            var a = response.FirstOrDefault();
            aperturaBapinType[] abt = proxy.consultarAPGBapines(datosBapin);
            return abt.Select(x => x.codigoBapin.ToString()).FirstOrDefault();*/
        }

        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;
                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);
                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }
        private static XmlDocument CreateConsultarBapinSoapEnvelope(DatosBapinType datosBapinType)
        {
            XmlSerializer xsBapinTypeDocument = new XmlSerializer(typeof(DatosBapinType));
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsBapinTypeDocument.Serialize(writer, datosBapinType);
                    xml = sww.ToString(); // Your XML
                }
            }

            XmlDocument docXMLBody = new XmlDocument();
            docXMLBody.LoadXml(xml);

            XmlDocument soapEnvelopeDocument = new XmlDocument();
            //soapEnvelopeDocument.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema""><SOAP-ENV:Body><HelloWorld xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><int1 xsi:type=""xsd:integer"">12</int1><int2 xsi:type=""xsd:integer"">32</int2></HelloWorld></SOAP-ENV:Body></SOAP-ENV:Envelope>");
            string apgServiceString = String.Format(
                "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:web=\"http://webServices.entidadesBasicas.esidif.mecon.gov.ar\">" +
                "   <soapenv:Header xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">" +
                "         <wsse:Security xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">" +
                "         <wsse:UsernameToken>" +
                "            <wsse:Username>BAPIN</wsse:Username>" +
                "            <wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">BapinEsidif2018</wsse:Password>" +
                "         </wsse:UsernameToken>" +
                "      </wsse:Security><wsa:MessageID>uuid:b24aa249-c882-47be-b69d-9eda71aef318</wsa:MessageID>" +
                "      <wsa:Action>https://ws-si.mecon.gov.ar/ws/entidades_basicas/consultarAPGBapinesService</wsa:Action>" +
                "   </soapenv:Header>" +
                "   <soapenv:Body>" +
                "   </soapenv:Body>" +
                "</soapenv:Envelope>");
            /*
            "      <web:datosBapin>" +
            "         <ejercicio>2018</ejercicio>" +
            "         <estados>" +
            "            <!--1 or more repetitions:-->" +
            "            <estado>DEMANDA</estado>" +
            "         </estados>" +
            "         <!--Optional:-->" +
            "         <codigoBapin>0</codigoBapin>" +
            "         <jurisdiccion>5</jurisdiccion>" +
            "         <!--Optional:-->" +
            "         <!--<saf>320</saf>-->" +
            "         <!--Optional:-->" +
            "         <!--<programas>-->" +
            "            <!--1 or more repetitions:-->" +
            "            <!--<programa>5</programa>-->" +
            "         <!--</programas>-->" +
            "      </web:datosBapin>" +
            */

            soapEnvelopeDocument.LoadXml(apgServiceString);

            //create Url node
            XmlNode nodeUrl = soapEnvelopeDocument.CreateNode(XmlNodeType.Element, "web", "datosBapin", "http://webServices.entidadesBasicas.esidif.mecon.gov.ar");
            nodeUrl.InnerXml = docXMLBody.DocumentElement.InnerXml;
            //add to parent node

            //soapEnvelopeDocument.DocumentElement.AppendChild(nodeUrl);
            var myNodeList = soapEnvelopeDocument.GetElementsByTagName("soapenv:Body");
            myNodeList.Item(0).AppendChild(nodeUrl);

            return soapEnvelopeDocument;
        }

        private static XmlDocument CreatePingSoapEnvelope()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            //soapEnvelopeDocument.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema""><SOAP-ENV:Body><HelloWorld xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><int1 xsi:type=""xsd:integer"">12</int1><int2 xsi:type=""xsd:integer"">32</int2></HelloWorld></SOAP-ENV:Body></SOAP-ENV:Envelope>");
            string pingServiceString = String.Format("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:lang=\"http://lang.java\">" +
                                        "    <soapenv:Header>" +
                                        "      <wsse:Security xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">" +
                                        "         <wsse:UsernameToken>" +
                                        "            <wsse:Username>[Username]</wsse:Username>" +
                                        "            <wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">[Password]</wsse:Password>" +
                                        "         </wsse:UsernameToken>" +
                                        "      </wsse:Security>" +
                                        "      <wsa:To xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">http://esidif.mecon.gov.ar/</wsa:To>" +
                                        "      <wsa:Action xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">https://ws-si.mecon.gov.ar/ws/seguridad/pingService</wsa:Action>" +
                                        "      <wsa:MessageID xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">urn:uuid:0461a658-9ec0-492d-8eed-bdd66938e4e9</wsa:MessageID>" +
                                        "   </soapenv:Header>" +
                                        "   <soapenv:Body>" +
                                        "   </soapenv:Body>" +
                                        "</soapenv:Envelope>");
            pingServiceString = pingServiceString.Replace("[Username]", "BAPIN");
            pingServiceString = pingServiceString.Replace("[Password]", "SVQN50kM6m");
            soapEnvelopeDocument.LoadXml(pingServiceString);
            return soapEnvelopeDocument;
        }

        private static XmlDocument CreateChangePasswordSoapEnvelope()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            //soapEnvelopeDocument.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema""><SOAP-ENV:Body><HelloWorld xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><int1 xsi:type=""xsd:integer"">12</int1><int2 xsi:type=""xsd:integer"">32</int2></HelloWorld></SOAP-ENV:Body></SOAP-ENV:Envelope>");
            string changePasswordServiceString = String.Format(
                                "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                                "	<SOAP-ENV:Header xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">" +
                                "		<wsse:Security" +
                                "			xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"" +
                                "			xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\"" +
                                "			SOAP-ENV:mustUnderstand=\"1\">" +
                                "			<wsse:UsernameToken wsu:Id=\"UsernameToken-5BF196167B4B2DE1EA14569303255361\">" +
                                "				<wsse:Username>webservice</wsse:Username>" +
                                "				<wsse:Password" +
                                "					Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">WebService2011</wsse:Password>" +
                                "			</wsse:UsernameToken>" +
                                "		</wsse:Security>" +
                                "		<wsa:To SOAP-ENV:mustUnderstand=\"1\">http://eSidif.mecon.gov.ar/</wsa:To>" +
                                "		<wsa:Action>https://ws-si.mecon.gov.ar/ws/seguridad/changePasswordService</wsa:Action>" +
                                "		<wsa:MessageID>urn:uuid:eb56e086-1aad-4f26-85cd-5e517eb4a5aa</wsa:MessageID>" +
                                "	</SOAP-ENV:Header>" +
                                "	<SOAP-ENV:Body>" +
                                "		<ns3:login xmlns:ns3=\"http://service.seguridad.esidif.mecon.gov.ar\">webservice</ns3:login>" +
                                "		<ns3:actualPassword xmlns:ns3=\"http://password.seguridad.esidif.mecon.gov.ar\">" +
                                "			<password>WebService2011</password>" +
                                "		</ns3:actualPassword>" +
                                "		<ns3:nuevaPassword xmlns:ns3=\"http://password.seguridad.esidif.mecon.gov.ar\">" +
                                "			<password>WebService2022</password>" +
                                "		</ns3:nuevaPassword>" +
                                "	</SOAP-ENV:Body>" +
                                "</SOAP-ENV:Envelope>");
            changePasswordServiceString = changePasswordServiceString.Replace("[Username]", "BAPIN");
            changePasswordServiceString = changePasswordServiceString.Replace("[Password]", "SVQN50kM6m");
            changePasswordServiceString = changePasswordServiceString.Replace("[ActualPassword]", "SVQN50kM6m");
            changePasswordServiceString = changePasswordServiceString.Replace("[NuevaPassword]", "SVQN50kM6m");
            soapEnvelopeDocument.LoadXml(changePasswordServiceString);
            return soapEnvelopeDocument;
        }

    }

}
