using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Business.Managers
{
    [Serializable]
    [XmlRoot("consultarAperturasBapinesResponse")]
    public class ConsultarAperturasBapines
    {
        [XmlElement("bapin", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public APGBapin[] bapines { get; set; }

        public ConsultarAperturasBapines()
        {
        }
    }
}
