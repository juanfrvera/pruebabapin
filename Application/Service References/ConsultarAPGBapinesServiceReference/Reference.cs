﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI.Web.ConsultarAPGBapinesServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://services.entidadesBasicas.presupuesto.esidif.mecon.gov.ar", ConfigurationName="ConsultarAPGBapinesServiceReference.consultarAPGBapines")]
    public interface consultarAPGBapines {
        
        // CODEGEN: Generating message contract since the operation consultarAPGBapines is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="https://ws-si.mecon.gov.ar/ws/entidades_basicas/consultarAPGBapinesService", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapinesResponse consultarAPGBapines(UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapinesRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://webServices.entidadesBasicas.esidif.mecon.gov.ar")]
    public partial class datosBapinType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private long ejercicioField;
        
        private System.Nullable<estadoBapinType>[] estadosField;
        
        private long codigoBapinField;
        
        private bool codigoBapinFieldSpecified;
        
        private long jurisdiccionField;
        
        private long safField;
        
        private bool safFieldSpecified;
        
        private System.Nullable<long>[] programasField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public long ejercicio {
            get {
                return this.ejercicioField;
            }
            set {
                this.ejercicioField = value;
                this.RaisePropertyChanged("ejercicio");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("estado", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<estadoBapinType>[] estados {
            get {
                return this.estadosField;
            }
            set {
                this.estadosField = value;
                this.RaisePropertyChanged("estados");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public long codigoBapin {
            get {
                return this.codigoBapinField;
            }
            set {
                this.codigoBapinField = value;
                this.RaisePropertyChanged("codigoBapin");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool codigoBapinSpecified {
            get {
                return this.codigoBapinFieldSpecified;
            }
            set {
                this.codigoBapinFieldSpecified = value;
                this.RaisePropertyChanged("codigoBapinSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public long jurisdiccion {
            get {
                return this.jurisdiccionField;
            }
            set {
                this.jurisdiccionField = value;
                this.RaisePropertyChanged("jurisdiccion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public long saf {
            get {
                return this.safField;
            }
            set {
                this.safField = value;
                this.RaisePropertyChanged("saf");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool safSpecified {
            get {
                return this.safFieldSpecified;
            }
            set {
                this.safFieldSpecified = value;
                this.RaisePropertyChanged("safSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("programa", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Nullable<long>[] programas {
            get {
                return this.programasField;
            }
            set {
                this.programasField = value;
                this.RaisePropertyChanged("programas");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://webServices.entidadesBasicas.esidif.mecon.gov.ar")]
    public enum estadoBapinType {
        
        /// <remarks/>
        DEMANDA,
        
        /// <remarks/>
        PLAN,
        
        /// <remarks/>
        PLAN_SEGUN_EJECUCION,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bapin.jaxb.webServices.entidadesBasicas.esidif.mecon.gov.ar")]
    public partial class datosEsidifType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private long jurisdiccionEsidifField;
        
        private long subjurisdiccionEsidifField;
        
        private long entidadEsidifField;
        
        private long programaEsidifField;
        
        private long subprogramaEsidifField;
        
        private long proyectoEsidifField;
        
        private long actividadEsidifField;
        
        private long obraEsidifField;
        
        private long ubicacionGeograficaEsidifField;
        
        private bool ubicacionGeograficaEsidifFieldSpecified;
        
        private decimal ejecucionAcumuladaField;
        
        private bool ejecucionAcumuladaFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public long jurisdiccionEsidif {
            get {
                return this.jurisdiccionEsidifField;
            }
            set {
                this.jurisdiccionEsidifField = value;
                this.RaisePropertyChanged("jurisdiccionEsidif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public long subjurisdiccionEsidif {
            get {
                return this.subjurisdiccionEsidifField;
            }
            set {
                this.subjurisdiccionEsidifField = value;
                this.RaisePropertyChanged("subjurisdiccionEsidif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public long entidadEsidif {
            get {
                return this.entidadEsidifField;
            }
            set {
                this.entidadEsidifField = value;
                this.RaisePropertyChanged("entidadEsidif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public long programaEsidif {
            get {
                return this.programaEsidifField;
            }
            set {
                this.programaEsidifField = value;
                this.RaisePropertyChanged("programaEsidif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public long subprogramaEsidif {
            get {
                return this.subprogramaEsidifField;
            }
            set {
                this.subprogramaEsidifField = value;
                this.RaisePropertyChanged("subprogramaEsidif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public long proyectoEsidif {
            get {
                return this.proyectoEsidifField;
            }
            set {
                this.proyectoEsidifField = value;
                this.RaisePropertyChanged("proyectoEsidif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public long actividadEsidif {
            get {
                return this.actividadEsidifField;
            }
            set {
                this.actividadEsidifField = value;
                this.RaisePropertyChanged("actividadEsidif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public long obraEsidif {
            get {
                return this.obraEsidifField;
            }
            set {
                this.obraEsidifField = value;
                this.RaisePropertyChanged("obraEsidif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public long ubicacionGeograficaEsidif {
            get {
                return this.ubicacionGeograficaEsidifField;
            }
            set {
                this.ubicacionGeograficaEsidifField = value;
                this.RaisePropertyChanged("ubicacionGeograficaEsidif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ubicacionGeograficaEsidifSpecified {
            get {
                return this.ubicacionGeograficaEsidifFieldSpecified;
            }
            set {
                this.ubicacionGeograficaEsidifFieldSpecified = value;
                this.RaisePropertyChanged("ubicacionGeograficaEsidifSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=9)]
        public decimal ejecucionAcumulada {
            get {
                return this.ejecucionAcumuladaField;
            }
            set {
                this.ejecucionAcumuladaField = value;
                this.RaisePropertyChanged("ejecucionAcumulada");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ejecucionAcumuladaSpecified {
            get {
                return this.ejecucionAcumuladaFieldSpecified;
            }
            set {
                this.ejecucionAcumuladaFieldSpecified = value;
                this.RaisePropertyChanged("ejecucionAcumuladaSpecified");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bapin.jaxb.webServices.entidadesBasicas.esidif.mecon.gov.ar")]
    public partial class aperturaBapinType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private long codigoBapinField;
        
        private long jurisdiccionField;
        
        private bool jurisdiccionFieldSpecified;
        
        private long safField;
        
        private bool safFieldSpecified;
        
        private long programaField;
        
        private bool programaFieldSpecified;
        
        private long subprogramaField;
        
        private bool subprogramaFieldSpecified;
        
        private datosEsidifType datosEsidifField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public long codigoBapin {
            get {
                return this.codigoBapinField;
            }
            set {
                this.codigoBapinField = value;
                this.RaisePropertyChanged("codigoBapin");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public long jurisdiccion {
            get {
                return this.jurisdiccionField;
            }
            set {
                this.jurisdiccionField = value;
                this.RaisePropertyChanged("jurisdiccion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool jurisdiccionSpecified {
            get {
                return this.jurisdiccionFieldSpecified;
            }
            set {
                this.jurisdiccionFieldSpecified = value;
                this.RaisePropertyChanged("jurisdiccionSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public long saf {
            get {
                return this.safField;
            }
            set {
                this.safField = value;
                this.RaisePropertyChanged("saf");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool safSpecified {
            get {
                return this.safFieldSpecified;
            }
            set {
                this.safFieldSpecified = value;
                this.RaisePropertyChanged("safSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public long programa {
            get {
                return this.programaField;
            }
            set {
                this.programaField = value;
                this.RaisePropertyChanged("programa");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool programaSpecified {
            get {
                return this.programaFieldSpecified;
            }
            set {
                this.programaFieldSpecified = value;
                this.RaisePropertyChanged("programaSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public long subprograma {
            get {
                return this.subprogramaField;
            }
            set {
                this.subprogramaField = value;
                this.RaisePropertyChanged("subprograma");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool subprogramaSpecified {
            get {
                return this.subprogramaFieldSpecified;
            }
            set {
                this.subprogramaFieldSpecified = value;
                this.RaisePropertyChanged("subprogramaSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public datosEsidifType datosEsidif {
            get {
                return this.datosEsidifField;
            }
            set {
                this.datosEsidifField = value;
                this.RaisePropertyChanged("datosEsidif");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class consultarAPGBapinesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webServices.entidadesBasicas.esidif.mecon.gov.ar", Order=0)]
        public UI.Web.ConsultarAPGBapinesServiceReference.datosBapinType datosBapin;
        
        public consultarAPGBapinesRequest() {
        }
        
        public consultarAPGBapinesRequest(UI.Web.ConsultarAPGBapinesServiceReference.datosBapinType datosBapin) {
            this.datosBapin = datosBapin;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class consultarAPGBapinesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bapin.jaxb.webServices.entidadesBasicas.esidif.mecon.gov.ar", Order=0)]
        [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("bapin", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UI.Web.ConsultarAPGBapinesServiceReference.aperturaBapinType[] consultarAperturasBapinesResponse;
        
        public consultarAPGBapinesResponse() {
        }
        
        public consultarAPGBapinesResponse(UI.Web.ConsultarAPGBapinesServiceReference.aperturaBapinType[] consultarAperturasBapinesResponse) {
            this.consultarAperturasBapinesResponse = consultarAperturasBapinesResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface consultarAPGBapinesChannel : UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapines, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class consultarAPGBapinesClient : System.ServiceModel.ClientBase<UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapines>, UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapines {
        
        public consultarAPGBapinesClient() {
        }
        
        public consultarAPGBapinesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public consultarAPGBapinesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public consultarAPGBapinesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public consultarAPGBapinesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapinesResponse UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapines.consultarAPGBapines(UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapinesRequest request) {
            return base.Channel.consultarAPGBapines(request);
        }
        
        public UI.Web.ConsultarAPGBapinesServiceReference.aperturaBapinType[] consultarAPGBapines(UI.Web.ConsultarAPGBapinesServiceReference.datosBapinType datosBapin) {
            UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapinesRequest inValue = new UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapinesRequest();
            inValue.datosBapin = datosBapin;
            UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapinesResponse retVal = ((UI.Web.ConsultarAPGBapinesServiceReference.consultarAPGBapines)(this)).consultarAPGBapines(inValue);
            return retVal.consultarAperturasBapinesResponse;
        }
    }
}
