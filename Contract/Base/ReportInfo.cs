using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace Contract
{
    [Serializable, DataContract(Name = "ReportHistoryInfo")]  
    public class ReportHistoryInfo
    {
        [XmlElement("Comments", IsNullable = true), DataMember(Name = "Comments")]
        public string Comments { get; set; }       
    }
    [Serializable, DataContract(Name = "ReportInfoParameter")]  
    public class ReportInfoParameter
    {
        [XmlElement("Name", IsNullable = true), DataMember(Name = "Name")]
        public string Name { get; set; }
        [XmlElement("Value", IsNullable = true), DataMember(Name = "Value")]
        public string Value { get; set; }
        private List<string> values;
        [XmlArray(ElementName = "Values"), XmlArrayItem(ElementName = "Value", Type = typeof(string))]
        public List<string> Values
        {
            get {
                if (values == null) values = new List<string>();
                return values; }
            set { values = value; }
        }
        public bool Visible { get; set; }
    }
    [Serializable, DataContract(Name = "ReportInfoDataSource")]
    public class ReportInfoDataSource : ISerializable, IXmlSerializable
    {
        public ReportInfoDataSource() { }
        public ReportInfoDataSource(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }
        [XmlElement("Name", IsNullable = true), DataMember(Name = "Name")]
        public string Name { get; set; }

        [XmlElement("TypeName", IsNullable = true), DataMember(Name = "TypeName")]
        public string TypeName { get; set; }


        [XmlIgnore]
        public object Value { get; set; }

        #region Serialization
        public ReportInfoDataSource(SerializationInfo info, StreamingContext ctxt)
        {
            this.Name = info.GetValue("Name", typeof(string)) as string;
            string xmlValue = info.GetValue("Value", typeof(string)) as string;
            TypeName = Value.GetType().Name;
            this.Value =DataHelper.DeserializeObject(Value.GetType(), xmlValue);     
        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", this.Name);
            string xmlValue = DataHelper.SerializeObject(Value.GetType(), this.Value);
            info.AddValue("Value", xmlValue);
        }

        #region IXmlSerializable Members

        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            XmlDocument doc = new XmlDocument();
            string xml = "";
            try
            {
                StringBuilder sb = new StringBuilder();
                (new XmlSerializer(Value.GetType())).Serialize(XmlWriter.Create(sb), this.Value);                
                doc.LoadXml(sb.ToString());
                xml=doc.DocumentElement.OuterXml;
            }
            catch (Exception exception)
            {
                string message = exception.Message;
            }
           
            writer.WriteElementString("Name", this.Name);

            TypeName = Value.GetType().FullName;
            writer.WriteElementString("TypeName", this.TypeName);

            writer.WriteStartElement("Value");
            writer.WriteRaw(xml);
            writer.WriteEndElement(); 
            
        }
        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            XmlDocument doc = new XmlDocument();
            if (reader.IsEmptyElement) return;
            try
            {
                this.Name = reader.ReadElementString();
                this.TypeName = reader.ReadElementString();
                Type typeValue = Type.GetType(TypeName);
                //string xmlValue = reader.ReadOuterXml();
                //doc.LoadXml(xmlValue);
                //string xml = doc.DocumentElement.ChildNodes[0].OuterXml;
                //this.Value = DataHelper.DeserializeObject(typeValue, xml);

                string xmlValue = reader.ReadElementString();
                //this.Value = reader.ReadElementString();// reader.ReadElementContentAs(typeValue, "");
            }
            catch (Exception exception)
            { 
                
            }
        }
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        #endregion
        #endregion
    }


    [Serializable, DataContract(Name = "ReportInfo")]
    public class ReportInfo : IXmlSerializable
    {
        [XmlElement("ReportFileName", IsNullable = true), DataMember(Name = "ReportFileName")]
        public string ReportFileName { get; set; }
        [XmlElement("Title", IsNullable = true), DataMember(Name = "Title")]
        public string Title { get; set; }

        private List<ReportInfoParameter> parameters;
        [XmlArray(ElementName = "Parameters"), XmlArrayItem(ElementName = "Parameter", Type = typeof(ReportInfoParameter))]
        public List<ReportInfoParameter> Parameters
        {
            get {
                if (parameters == null)
                    parameters = new List<ReportInfoParameter>();
                return parameters; }
            set { parameters = value; }
        }

        private List<ReportInfoDataSource> dataSources;
        [XmlArray(ElementName = "DataSources"), XmlArrayItem(ElementName = "DataSource", Type = typeof(ReportInfoDataSource))]
        public List<ReportInfoDataSource> DataSources
        {
            get {
                if (dataSources == null)
                    dataSources = new List<ReportInfoDataSource>();
                return dataSources; }
            set { dataSources = value; }
        }

        [XmlIgnore]
        public object Value { get; set; }

        #region Serialization
        #region IXmlSerializable Members

        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteElementString("ReportFileName", this.ReportFileName);
            writer.WriteElementString("Title", this.Title);
            
            System.Xml.Serialization.XmlSerializer reportInfoParameterSerializer = new System.Xml.Serialization.XmlSerializer(typeof(ReportInfoParameter));
            writer.WriteStartElement("Parameters");
            foreach (ReportInfoParameter parameter in Parameters)
            {
                try
                {
                    reportInfoParameterSerializer.Serialize(writer, parameter, null);
                }
                catch
                {
                }
            }
            writer.WriteEndElement();

            writer.WriteStartElement("DataSources");
            foreach (ReportInfoDataSource dataSource in DataSources)
            {
                writer.WriteStartElement("DataSource");
                WriteDataSource(writer, dataSource);
                writer.WriteEndElement(); 
            }
            writer.WriteEndElement();            
        }
        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            XmlDocument doc = new XmlDocument();
            if (reader.IsEmptyElement) return;
            try
            {
                reader.Read();
                this.ReportFileName = reader.ReadElementString("ReportFileName");
                this.Title = reader.ReadElementString("Title");

                System.Xml.Serialization.XmlSerializer reportInfoParameterSerializer = new System.Xml.Serialization.XmlSerializer(typeof(ReportInfoParameter));
                reader.ReadStartElement("Parameters");
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    try
                    {
                        ReportInfoParameter reportInfoParameter = (ReportInfoParameter)reportInfoParameterSerializer.Deserialize(reader);
                        if (reportInfoParameter != null) // May be I have to throw here ?
                            this.Parameters.Add(reportInfoParameter);
                    }
                    catch
                    {
                    }
                }
                reader.ReadEndElement();

                reader.ReadStartElement("DataSources");
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement("DataSource");
                    ReportInfoDataSource reportInfoDataSource = ReadDataSource(reader);
                    if (reportInfoDataSource != null) 
                        this.DataSources.Add(reportInfoDataSource);
                    reader.ReadEndElement();
                }
                reader.ReadEndElement();
            }
            catch (Exception exception)
            { 
                
            }
        }
        protected void WriteDataSource(System.Xml.XmlWriter writer,ReportInfoDataSource dataSource)
        {
            System.Xml.Serialization.XmlSerializer valueSerializer= null;
            try
            {
                
                Type typeValue = dataSource.Value.GetType();
                dataSource.TypeName = typeValue.FullName;
                valueSerializer = new System.Xml.Serialization.XmlSerializer(typeValue);
                
            }
            catch (Exception exception)
            {
                string message = exception.Message;
            }
            writer.WriteElementString("Name", dataSource.Name);
            writer.WriteElementString("TypeName", dataSource.TypeName);            
            writer.WriteStartElement("Value");
            if (valueSerializer != null) valueSerializer.Serialize(writer, dataSource.Value, null);
            writer.WriteEndElement(); 
        }
        protected ReportInfoDataSource ReadDataSource(System.Xml.XmlReader reader)
        { 
            ReportInfoDataSource dataSource = new ReportInfoDataSource();
            Type typeValue = null;
            if (reader.IsEmptyElement) return null;
            try
            {
                dataSource.Name = reader.ReadElementString("Name");
                dataSource.TypeName = reader.ReadElementString("TypeName");
                reader.ReadStartElement("Value");
                try
                {
                    typeValue = Type.GetType(dataSource.TypeName);
                    System.Xml.Serialization.XmlSerializer valueSerializer = new System.Xml.Serialization.XmlSerializer(typeValue);
                    dataSource.Value = valueSerializer.Deserialize(reader);
                    if (dataSource.Value == null)
                        dataSource.Value = Activator.CreateInstance(typeValue);
                }
                catch (Exception exception)
                {
                    if (dataSource.Value == null && typeValue != null)
                        dataSource.Value = Activator.CreateInstance(typeValue);
                    else
                        return null;
                }
                reader.ReadEndElement();
            }
            catch (Exception exception)
            {
            }
            return dataSource;
        }

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        #endregion
        #endregion
               
    }
}
