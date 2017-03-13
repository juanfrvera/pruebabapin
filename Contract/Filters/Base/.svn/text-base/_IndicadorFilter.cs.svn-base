using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _IndicadorFilter : Filter
    {   
		#region Private
		private string _Observacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdIndicador", IsRequired = false)]public int? IdIndicador{get;set;}		
[DataMember(Name = "IdMedioVerificacionIsNull", IsRequired = false)]
			  public bool? IdMedioVerificacionIsNull{get;set;}[DataMember(Name = "IdMedioVerificacion", IsRequired = false)]public int? IdMedioVerificacion{get;set;}		

		  [DataMember(Name = "Observacion", IsRequired = false)]
		  public string Observacion
		  {
		   get{ if(_Observacion==null)_Observacion= string.Empty;
				return _Observacion; 
				}
		   set{ _Observacion=value;}
		  }
		 
		#endregion
    }
}
