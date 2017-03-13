using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoEtapaIndicadorFilter : Filter
    {   
		#region Private
		private string _Descripcion;
		 private string _NroExpediente;
		 private string _Contratista;
		 private string _PlazoEjecucion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoEtapaIndicador", IsRequired = false)]public int? IdProyectoEtapaIndicador{get;set;}		
[DataMember(Name = "IdProyectoEtapaIndicador_To", IsRequired = false)]		
public int? IdProyectoEtapaIndicador_To{get;set;}		
[DataMember(Name = "IdProyectoEtapa", IsRequired = false)]public int? IdProyectoEtapa{get;set;}		

		  [DataMember(Name = "Descripcion", IsRequired = false)]
		  public string Descripcion
		  {
		   get{ if(_Descripcion==null)_Descripcion= string.Empty;
				return _Descripcion; 
				}
		   set{ _Descripcion=value;}
		  }
		 [DataMember(Name = "IdUnidadMediaIsNull", IsRequired = false)]
			  public bool? IdUnidadMediaIsNull{get;set;}[DataMember(Name = "IdUnidadMedia", IsRequired = false)]public int? IdUnidadMedia{get;set;}		
[DataMember(Name = "IdUnidadMedia_To", IsRequired = false)]		
public int? IdUnidadMedia_To{get;set;}		
[DataMember(Name = "IdIndicadorIsNull", IsRequired = false)]
			  public bool? IdIndicadorIsNull{get;set;}[DataMember(Name = "IdIndicador", IsRequired = false)]public int? IdIndicador{get;set;}		

		  [DataMember(Name = "NroExpediente", IsRequired = false)]
		  public string NroExpediente
		  {
		   get{ if(_NroExpediente==null)_NroExpediente= string.Empty;
				return _NroExpediente; 
				}
		   set{ _NroExpediente=value;}
		  }
		 [DataMember(Name = "FechaLicitacionIsNull", IsRequired = false)]
			  public bool? FechaLicitacionIsNull{get;set;}[DataMember(Name = "FechaLicitacion", IsRequired = false)]public DateTime? FechaLicitacion{get;set;}		
[DataMember(Name = "FechaLicitacion_To", IsRequired = false)]		
public DateTime? FechaLicitacion_To{get;set;}		
[DataMember(Name = "FechaContratacionIsNull", IsRequired = false)]
			  public bool? FechaContratacionIsNull{get;set;}[DataMember(Name = "FechaContratacion", IsRequired = false)]public DateTime? FechaContratacion{get;set;}		
[DataMember(Name = "FechaContratacion_To", IsRequired = false)]		
public DateTime? FechaContratacion_To{get;set;}		

		  [DataMember(Name = "Contratista", IsRequired = false)]
		  public string Contratista
		  {
		   get{ if(_Contratista==null)_Contratista= string.Empty;
				return _Contratista; 
				}
		   set{ _Contratista=value;}
		  }
		 [DataMember(Name = "FechaInicioObraIsNull", IsRequired = false)]
			  public bool? FechaInicioObraIsNull{get;set;}[DataMember(Name = "FechaInicioObra", IsRequired = false)]public DateTime? FechaInicioObra{get;set;}		
[DataMember(Name = "FechaInicioObra_To", IsRequired = false)]		
public DateTime? FechaInicioObra_To{get;set;}		

		  [DataMember(Name = "PlazoEjecucion", IsRequired = false)]
		  public string PlazoEjecucion
		  {
		   get{ if(_PlazoEjecucion==null)_PlazoEjecucion= string.Empty;
				return _PlazoEjecucion; 
				}
		   set{ _PlazoEjecucion=value;}
		  }
		 [DataMember(Name = "IdMonedaIsNull", IsRequired = false)]
			  public bool? IdMonedaIsNull{get;set;}[DataMember(Name = "IdMoneda", IsRequired = false)]public int? IdMoneda{get;set;}		
[DataMember(Name = "IdMoneda_To", IsRequired = false)]		
public int? IdMoneda_To{get;set;}		
[DataMember(Name = "MagnitudIsNull", IsRequired = false)]
			  public bool? MagnitudIsNull{get;set;}[DataMember(Name = "Magnitud", IsRequired = false)]public int? Magnitud{get;set;}		
[DataMember(Name = "Magnitud_To", IsRequired = false)]		
public int? Magnitud_To{get;set;}		
[DataMember(Name = "MontoContratoIsNull", IsRequired = false)]
			  public bool? MontoContratoIsNull{get;set;}[DataMember(Name = "MontoContrato", IsRequired = false)]public decimal? MontoContrato{get;set;}		
[DataMember(Name = "MontoContrato_To", IsRequired = false)]		
public decimal? MontoContrato_To{get;set;}		
[DataMember(Name = "MontoVigenteIsNull", IsRequired = false)]
			  public bool? MontoVigenteIsNull{get;set;}[DataMember(Name = "MontoVigente", IsRequired = false)]public decimal? MontoVigente{get;set;}		
[DataMember(Name = "MontoVigente_To", IsRequired = false)]		
public decimal? MontoVigente_To{get;set;}		

		#endregion
    }
}
