using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.IO;

namespace Test
{
    public static class TestEsidif
    {
        private static string _url = "https://tws8-si.mecon.gov.ar/SD_Core/ws/";
        //private static string _urlprod = "https://ws-si.mecon.gov.ar/SD_Core/ws/";

        public static void CallPingService()
        {
            Console.WriteLine("Call Ping Service...");

            var _action = "seguridad/pingService";

            IgnoreBadCertificates();
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            XmlDocument soapEnvelopeXml = CreatePingSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                Console.WriteLine(soapResult);

                XDocument doc = XDocument.Parse(soapResult);

                //{http://service.seguridad.esidif.mecon.gov.ar}ping
                var responseName = doc.Descendants().Elements("{http://service.seguridad.esidif.mecon.gov.ar}ping").FirstOrDefault().Name;
                var responseValue = doc.Descendants().Elements("{http://service.seguridad.esidif.mecon.gov.ar}ping").FirstOrDefault().Value;
                Console.WriteLine("Ping- Element:" + responseName + " Value:" + responseValue);
            }
        }

        public static void CallChangePasswordService()
        {
            Console.WriteLine("Call Change Password Service...");

            var _action = "seguridad/changePasswordService";

            IgnoreBadCertificates();

            //XmlDocument soapEnvelopeXml = CreateChangePasswordSoapEnvelope();
            XmlDocument soapEnvelopeXml = CreateChangePasswordSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

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
                    Console.WriteLine(soapResult);

                    XDocument doc = XDocument.Parse(soapResult);

                    //{http://service.seguridad.esidif.mecon.gov.ar}ping
                    var responseName = doc.Descendants().Elements("{http://service.seguridad.esidif.mecon.gov.ar}ping").FirstOrDefault().Name;
                    var responseValue = doc.Descendants().Elements("{http://service.seguridad.esidif.mecon.gov.ar}ping").FirstOrDefault().Value;
                    Console.WriteLine("Ping- Element:" + responseName + " Value:" + responseValue);
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                // Something more serious happened
                // like for example you don't have network access
                // we cannot talk about a server exception here as
                // the server probably was never reached
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
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
        public static void IgnoreBadCertificates()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        }

        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        } 
    }
}
