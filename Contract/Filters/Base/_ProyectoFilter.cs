using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoFilter : Filter
    {   
		#region Private
		private string _ProyectoDenominacion;
		 private string _ProyectoSituacionActual;
		 private string _ProyectoDescripcion;
		 private string _ProyectoObservacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdTipoProyecto", IsRequired = false)]public int? IdTipoProyecto{get;set;}		
[DataMember(Name = "IdSubPrograma", IsRequired = false)]public int? IdSubPrograma{get;set;}		
[DataMember(Name = "Codigo", IsRequired = false)]public int? Codigo{get;set;}		
[DataMember(Name = "Codigo_To", IsRequired = false)]		
public int? Codigo_To{get;set;}		

		  [DataMember(Name = "ProyectoDenominacion", IsRequired = false)]
		  public string ProyectoDenominacion
		  {
		   get{ if(_ProyectoDenominacion==null)_ProyectoDenominacion= string.Empty;
				return _ProyectoDenominacion; 
				}
		   set{ _ProyectoDenominacion=value;}
		  }
		 
		  [DataMember(Name = "ProyectoSituacionActual", IsRequired = false)]
		  public string ProyectoSituacionActual
		  {
		   get{ if(_ProyectoSituacionActual==null)_ProyectoSituacionActual= string.Empty;
				return _ProyectoSituacionActual; 
				}
		   set{ _ProyectoSituacionActual=value;}
		  }
		 
		  [DataMember(Name = "ProyectoDescripcion", IsRequired = false)]
		  public string ProyectoDescripcion
		  {
		   get{ if(_ProyectoDescripcion==null)_ProyectoDescripcion= string.Empty;
				return _ProyectoDescripcion; 
				}
		   set{ _ProyectoDescripcion=value;}
		  }
		 
		  [DataMember(Name = "ProyectoObservacion", IsRequired = false)]
		  public string ProyectoObservacion
		  {
		   get{ if(_ProyectoObservacion==null)_ProyectoObservacion= string.Empty;
				return _ProyectoObservacion; 
				}
		   set{ _ProyectoObservacion=value;}
		  }
		 [DataMember(Name = "IdEstado", IsRequired = false)]public int? IdEstado{get;set;}		
[DataMember(Name = "IdProcesoIsNull", IsRequired = false)]
			  public bool? IdProcesoIsNull{get;set;}[DataMember(Name = "IdProceso", IsRequired = false)]public int? IdProceso{get;set;}		
[DataMember(Name = "IdModalidadContratacionIsNull", IsRequired = false)]
			  public bool? IdModalidadContratacionIsNull{get;set;}[DataMember(Name = "IdModalidadContratacion", IsRequired = false)]public int? IdModalidadContratacion{get;set;}		
[DataMember(Name = "IdFinalidadFuncionIsNull", IsRequired = false)]
			  public bool? IdFinalidadFuncionIsNull{get;set;}[DataMember(Name = "IdFinalidadFuncion", IsRequired = false)]public int? IdFinalidadFuncion{get;set;}		
[DataMember(Name = "IdOrganismoPrioridadIsNull", IsRequired = false)]
			  public bool? IdOrganismoPrioridadIsNull{get;set;}[DataMember(Name = "IdOrganismoPrioridad", IsRequired = false)]public int? IdOrganismoPrioridad{get;set;}		
[DataMember(Name = "SubPrioridadIsNull", IsRequired = false)]
			  public bool? SubPrioridadIsNull{get;set;}[DataMember(Name = "SubPrioridad", IsRequired = false)]public int? SubPrioridad{get;set;}		
[DataMember(Name = "SubPrioridad_To", IsRequired = false)]		
public int? SubPrioridad_To{get;set;}		
[DataMember(Name = "EsBorrador", IsRequired = false)]public bool? EsBorrador{get;set;}		
[DataMember(Name = "EsProyectoIsNull", IsRequired = false)]
			  public bool? EsProyectoIsNull{get;set;}[DataMember(Name = "EsProyecto", IsRequired = false)]public bool? EsProyecto{get;set;}		
[DataMember(Name = "NroProyectoIsNull", IsRequired = false)]
			  public bool? NroProyectoIsNull{get;set;}[DataMember(Name = "NroProyecto", IsRequired = false)]public int? NroProyecto{get;set;}		
[DataMember(Name = "NroProyecto_To", IsRequired = false)]		
public int? NroProyecto_To{get;set;}		
[DataMember(Name = "AnioCorrienteIsNull", IsRequired = false)]
			  public bool? AnioCorrienteIsNull{get;set;}[DataMember(Name = "AnioCorriente", IsRequired = false)]public int? AnioCorriente{get;set;}		
[DataMember(Name = "AnioCorriente_To", IsRequired = false)]		
public int? AnioCorriente_To{get;set;}		
[DataMember(Name = "FechaInicioEjecucionCalculadaIsNull", IsRequired = false)]
			  public bool? FechaInicioEjecucionCalculadaIsNull{get;set;}[DataMember(Name = "FechaInicioEjecucionCalculada", IsRequired = false)]public DateTime? FechaInicioEjecucionCalculada{get;set;}		
[DataMember(Name = "FechaInicioEjecucionCalculada_To", IsRequired = false)]		
public DateTime? FechaInicioEjecucionCalculada_To{get;set;}		
[DataMember(Name = "FechaFinEjecucionCalculadaIsNull", IsRequired = false)]
			  public bool? FechaFinEjecucionCalculadaIsNull{get;set;}[DataMember(Name = "FechaFinEjecucionCalculada", IsRequired = false)]public DateTime? FechaFinEjecucionCalculada{get;set;}		
[DataMember(Name = "FechaFinEjecucionCalculada_To", IsRequired = false)]		
public DateTime? FechaFinEjecucionCalculada_To{get;set;}		
[DataMember(Name = "FechaAlta", IsRequired = false)]public DateTime? FechaAlta{get;set;}		
[DataMember(Name = "FechaAlta_To", IsRequired = false)]		
public DateTime? FechaAlta_To{get;set;}		
[DataMember(Name = "FechaModificacion", IsRequired = false)]public DateTime? FechaModificacion{get;set;}		
[DataMember(Name = "FechaModificacion_To", IsRequired = false)]		
public DateTime? FechaModificacion_To{get;set;}		
[DataMember(Name = "IdUsuarioModificacion", IsRequired = false)]public int? IdUsuarioModificacion{get;set;}		
[DataMember(Name = "IdUsuarioModificacion_To", IsRequired = false)]		
public int? IdUsuarioModificacion_To{get;set;}		
[DataMember(Name = "IdProyectoPlanIsNull", IsRequired = false)]
			  public bool? IdProyectoPlanIsNull{get;set;}[DataMember(Name = "IdProyectoPlan", IsRequired = false)]public int? IdProyectoPlan{get;set;}		
[DataMember(Name = "IdProyectoPlan_To", IsRequired = false)]		
public int? IdProyectoPlan_To{get;set;}		
[DataMember(Name = "EvaluarValidaciones", IsRequired = false)]public bool? EvaluarValidaciones{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		
[DataMember(Name = "IdEstadoDeDesicionIsNull", IsRequired = false)]
			  public bool? IdEstadoDeDesicionIsNull{get;set;}[DataMember(Name = "IdEstadoDeDesicion", IsRequired = false)]public int? IdEstadoDeDesicion{get;set;}		

		#endregion
    }
}
