using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoDemoraFilter : Filter
    {   
		#region Private
		private string _Justificacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoDemora", IsRequired = false)]public int? IdProyectoDemora{get;set;}		
[DataMember(Name = "IdProyectoDemora_To", IsRequired = false)]		
public int? IdProyectoDemora_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		

		  [DataMember(Name = "Justificacion", IsRequired = false)]
		  public string Justificacion
		  {
		   get{ if(_Justificacion==null)_Justificacion= string.Empty;
				return _Justificacion; 
				}
		   set{ _Justificacion=value;}
		  }
		 [DataMember(Name = "Fecha", IsRequired = false)]public DateTime? Fecha{get;set;}		
[DataMember(Name = "Fecha_To", IsRequired = false)]		
public DateTime? Fecha_To{get;set;}		

		#endregion
    }
}
