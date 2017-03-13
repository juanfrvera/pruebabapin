using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoPrioridadFilter : Filter
    {   
		#region Private
		private string _Comentario;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoPrioridad", IsRequired = false)]public int? IdProyectoPrioridad{get;set;}		
[DataMember(Name = "IdProyectoPrioridad_To", IsRequired = false)]		
public int? IdProyectoPrioridad_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdPlanPeriodo", IsRequired = false)]public int? IdPlanPeriodo{get;set;}		
[DataMember(Name = "IdPrioridadIsNull", IsRequired = false)]
			  public bool? IdPrioridadIsNull{get;set;}[DataMember(Name = "IdPrioridad", IsRequired = false)]public int? IdPrioridad{get;set;}		
[DataMember(Name = "Puntaje", IsRequired = false)]public int? Puntaje{get;set;}		
[DataMember(Name = "Puntaje_To", IsRequired = false)]		
public int? Puntaje_To{get;set;}		
[DataMember(Name = "ReqArt15IsNull", IsRequired = false)]
			  public bool? ReqArt15IsNull{get;set;}[DataMember(Name = "ReqArt15", IsRequired = false)]public bool? ReqArt15{get;set;}		
[DataMember(Name = "IdClasificacionIsNull", IsRequired = false)]
			  public bool? IdClasificacionIsNull{get;set;}[DataMember(Name = "IdClasificacion", IsRequired = false)]public int? IdClasificacion{get;set;}		

		  [DataMember(Name = "Comentario", IsRequired = false)]
		  public string Comentario
		  {
		   get{ if(_Comentario==null)_Comentario= string.Empty;
				return _Comentario; 
				}
		   set{ _Comentario=value;}
		  }
		 [DataMember(Name = "PrioridadAsignada", IsRequired = false)]public bool? PrioridadAsignada{get;set;}		
[DataMember(Name = "ConfRequerimientos", IsRequired = false)]public bool? ConfRequerimientos{get;set;}		

		#endregion
    }
}
