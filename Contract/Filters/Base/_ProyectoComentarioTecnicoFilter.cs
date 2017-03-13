using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoComentarioTecnicoFilter : Filter
    {   
		#region Private
		private string _Observacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoComentarioTecnico", IsRequired = false)]public int? IdProyectoComentarioTecnico{get;set;}		
[DataMember(Name = "IdProyectoComentarioTecnico_To", IsRequired = false)]		
public int? IdProyectoComentarioTecnico_To{get;set;}		
[DataMember(Name = "IdProyectoIsNull", IsRequired = false)]
			  public bool? IdProyectoIsNull{get;set;}[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdComentarioTecnico", IsRequired = false)]public int? IdComentarioTecnico{get;set;}		

		  [DataMember(Name = "Observacion", IsRequired = false)]
		  public string Observacion
		  {
		   get{ if(_Observacion==null)_Observacion= string.Empty;
				return _Observacion; 
				}
		   set{ _Observacion=value;}
		  }
		 [DataMember(Name = "IdUsuario", IsRequired = false)]public int? IdUsuario{get;set;}		
[DataMember(Name = "IdUsuario_To", IsRequired = false)]		
public int? IdUsuario_To{get;set;}		
[DataMember(Name = "Fecha", IsRequired = false)]public DateTime? Fecha{get;set;}		
[DataMember(Name = "Fecha_To", IsRequired = false)]		
public DateTime? Fecha_To{get;set;}		
[DataMember(Name = "FechaAlta", IsRequired = false)]public DateTime? FechaAlta{get;set;}		
[DataMember(Name = "FechaAlta_To", IsRequired = false)]		
public DateTime? FechaAlta_To{get;set;}		
[DataMember(Name = "IdPrestamoIsNull", IsRequired = false)]
			  public bool? IdPrestamoIsNull{get;set;}[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		

		#endregion
    }
}
