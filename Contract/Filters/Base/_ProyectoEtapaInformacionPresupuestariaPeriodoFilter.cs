using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoEtapaInformacionPresupuestariaPeriodoFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoEtapaInformacionPresupuestariaPeriodo", IsRequired = false)]public int? IdProyectoEtapaInformacionPresupuestariaPeriodo{get;set;}		
        [DataMember(Name = "IdProyectoEtapaInformacionPresupuestariaPeriodo_To", IsRequired = false)]		
        public int? IdProyectoEtapaInformacionPresupuestariaPeriodo_To{get;set;}		
        [DataMember(Name = "IdProyectoEtapaInformacionPresupuestaria", IsRequired = false)]public int? IdProyectoEtapaInformacionPresupuestaria{get;set;}		
        [DataMember(Name = "Periodo", IsRequired = false)]public int? Periodo{get;set;}		
        [DataMember(Name = "Periodo_To", IsRequired = false)]		
        public int? Periodo_To{get;set;}		
        [DataMember(Name = "Monto", IsRequired = false)]public decimal? Monto{get;set;}		
        [DataMember(Name = "Monto_To", IsRequired = false)]		
        public decimal? Monto_To{get;set;}		
        [DataMember(Name = "CotizacionIsNull", IsRequired = false)]
        public bool? CotizacionIsNull{get;set;}[DataMember(Name = "Cotizacion", IsRequired = false)]public decimal? Cotizacion{get;set;}		
        [DataMember(Name = "Cotizacion_To", IsRequired = false)]		
        public decimal? Cotizacion_To{get;set;}		
        [DataMember(Name = "MontoCalculado", IsRequired = false)]public decimal? MontoCalculado{get;set;}
        [DataMember(Name = "MontoCalculado_To", IsRequired = false)]		
        public decimal? MontoCalculado_To{get;set;}
        [DataMember(Name = "MontoInicial", IsRequired = false)]
        public decimal? MontoInicial { get; set; }
        [DataMember(Name = "MontoInicial_To", IsRequired = false)]
        public decimal? MontoInicial_To { get; set; }
        [DataMember(Name = "MontoVigente", IsRequired = false)]
        public decimal? MontoVigente { get; set; }
        [DataMember(Name = "MontoVigente_To", IsRequired = false)]
        public decimal? MontoVigente_To { get; set; }
        [DataMember(Name = "MontoDevengado", IsRequired = false)]
        public decimal? MontoDevengado { get; set; }
        [DataMember(Name = "MontoDevengado_To", IsRequired = false)]
        public decimal? MontoDevengado_To { get; set; }
        //MontoVigenteEstimativo      
        [DataMember(Name = "MontoVigenteEstimativo", IsRequired = false)]
        public bool? MontoVigenteEstimativo { get; set; }
        [DataMember(Name = "MontoVigenteEstimativo_To", IsRequired = false)]
        public bool? MontoVigenteEstimativo_To { get; set; }
        #endregion
    }
}
