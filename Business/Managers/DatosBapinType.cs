using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Business.Managers
{
    [Serializable]
    [XmlRoot("datosBapin", ElementName="datosBapin")]
    public class DatosBapinType
    {
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 0)]
        public long ejercicio { get; set; }

        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("estado", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<EstadoBapinType>[] estados { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public long codigoBapin { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool codigoBapinSpecified { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 3)]
        public long jurisdiccion { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 4)]
        public long saf { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool safSpecified { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("programa", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<long>[] programas { get; set; }
    }

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://webServices.entidadesBasicas.esidif.mecon.gov.ar")]
    public enum EstadoBapinType
    {
        DEMANDA,
        PLAN,
        PLAN_SEGUN_EJECUCION,
    }
    

}
