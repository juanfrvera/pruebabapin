using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _TransferenciaFilter : Filter
    {   
		#region Private
		private string _Denominacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdTransferencia", IsRequired = false)]public int? IdTransferencia{get;set;}		
[DataMember(Name = "IdSubPrograma", IsRequired = false)]public int? IdSubPrograma{get;set;}		
[DataMember(Name = "Proyecto", IsRequired = false)]public int? Proyecto{get;set;}		
[DataMember(Name = "Proyecto_To", IsRequired = false)]		
public int? Proyecto_To{get;set;}		
[DataMember(Name = "Actividad", IsRequired = false)]public int? Actividad{get;set;}		
[DataMember(Name = "Actividad_To", IsRequired = false)]		
public int? Actividad_To{get;set;}		
[DataMember(Name = "Obra", IsRequired = false)]public int? Obra{get;set;}		
[DataMember(Name = "Obra_To", IsRequired = false)]		
public int? Obra_To{get;set;}		

		  [DataMember(Name = "Denominacion", IsRequired = false)]
		  public string Denominacion
		  {
		   get{ if(_Denominacion==null)_Denominacion= string.Empty;
				return _Denominacion; 
				}
		   set{ _Denominacion=value;}
		  }
		 [DataMember(Name = "IdClasificacionGasto", IsRequired = false)]public int? IdClasificacionGasto{get;set;}		
[DataMember(Name = "IdClasificacionGeografica", IsRequired = false)]public int? IdClasificacionGeografica{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
