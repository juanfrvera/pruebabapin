using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _SafFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Denominacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdSaf", IsRequired = false)]public int? IdSaf{get;set;}		

		  [DataMember(Name = "Codigo", IsRequired = false)]
		  public string Codigo
		  {
		   get{ if(_Codigo==null)_Codigo= string.Empty;
				return _Codigo; 
				}
		   set{ _Codigo=value;}
		  }
		 
		  [DataMember(Name = "Denominacion", IsRequired = false)]
		  public string Denominacion
		  {
		   get{ if(_Denominacion==null)_Denominacion= string.Empty;
				return _Denominacion; 
				}
		   set{ _Denominacion=value;}
		  }
		 [DataMember(Name = "IdTipoOrganismo", IsRequired = false)]public int? IdTipoOrganismo{get;set;}		
[DataMember(Name = "IdSectorIsNull", IsRequired = false)]
			  public bool? IdSectorIsNull{get;set;}[DataMember(Name = "IdSector", IsRequired = false)]public int? IdSector{get;set;}		
[DataMember(Name = "IdAdministracionTipoIsNull", IsRequired = false)]
			  public bool? IdAdministracionTipoIsNull{get;set;}[DataMember(Name = "IdAdministracionTipo", IsRequired = false)]public int? IdAdministracionTipo{get;set;}		
[DataMember(Name = "IdEntidadTipoIsNull", IsRequired = false)]
			  public bool? IdEntidadTipoIsNull{get;set;}[DataMember(Name = "IdEntidadTipo", IsRequired = false)]public int? IdEntidadTipo{get;set;}		
[DataMember(Name = "IdJurisdiccionIsNull", IsRequired = false)]
			  public bool? IdJurisdiccionIsNull{get;set;}[DataMember(Name = "IdJurisdiccion", IsRequired = false)]public int? IdJurisdiccion{get;set;}		
[DataMember(Name = "IdSubJurisdiccionIsNull", IsRequired = false)]
			  public bool? IdSubJurisdiccionIsNull{get;set;}[DataMember(Name = "IdSubJurisdiccion", IsRequired = false)]public int? IdSubJurisdiccion{get;set;}		
[DataMember(Name = "FechaAlta", IsRequired = false)]public DateTime? FechaAlta{get;set;}		
[DataMember(Name = "FechaAlta_To", IsRequired = false)]		
public DateTime? FechaAlta_To{get;set;}		
[DataMember(Name = "FechaBajaIsNull", IsRequired = false)]
			  public bool? FechaBajaIsNull{get;set;}[DataMember(Name = "FechaBaja", IsRequired = false)]public DateTime? FechaBaja{get;set;}		
[DataMember(Name = "FechaBaja_To", IsRequired = false)]		
public DateTime? FechaBaja_To{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
