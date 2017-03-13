using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProcesoFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProceso", IsRequired = false)]public int? IdProceso{get;set;}		
[DataMember(Name = "IdProyectoTipo", IsRequired = false)]public int? IdProyectoTipo{get;set;}		

		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 [DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
