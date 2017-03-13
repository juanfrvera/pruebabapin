using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoSeguimientoFilter : Filter
    {   
		#region Private
		private string _Denominacion;
		 private string _Ruta;
		 private string _Malla;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoSeguimiento", IsRequired = false)]public int? IdProyectoSeguimiento{get;set;}		
[DataMember(Name = "IdSaf", IsRequired = false)]public int? IdSaf{get;set;}		

		  [DataMember(Name = "Denominacion", IsRequired = false)]
		  public string Denominacion
		  {
		   get{ if(_Denominacion==null)_Denominacion= string.Empty;
				return _Denominacion; 
				}
		   set{ _Denominacion=value;}
		  }
		 
		  [DataMember(Name = "Ruta", IsRequired = false)]
		  public string Ruta
		  {
		   get{ if(_Ruta==null)_Ruta= string.Empty;
				return _Ruta; 
				}
		   set{ _Ruta=value;}
		  }
		 
		  [DataMember(Name = "Malla", IsRequired = false)]
		  public string Malla
		  {
		   get{ if(_Malla==null)_Malla= string.Empty;
				return _Malla; 
				}
		   set{ _Malla=value;}
		  }
		 [DataMember(Name = "IdAnalista", IsRequired = false)]public int? IdAnalista{get;set;}		
[DataMember(Name = "IdProyectoSeguimientoAnteriorIsNull", IsRequired = false)]
			  public bool? IdProyectoSeguimientoAnteriorIsNull{get;set;}[DataMember(Name = "IdProyectoSeguimientoAnterior", IsRequired = false)]public int? IdProyectoSeguimientoAnterior{get;set;}		
[DataMember(Name = "IdProyectoSeguimientoEstadoUltimoIsNull", IsRequired = false)]
			  public bool? IdProyectoSeguimientoEstadoUltimoIsNull{get;set;}[DataMember(Name = "IdProyectoSeguimientoEstadoUltimo", IsRequired = false)]public int? IdProyectoSeguimientoEstadoUltimo{get;set;}		

		#endregion
    }
}
