using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProgramaFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPrograma", IsRequired = false)]public int? IdPrograma{get;set;}		
[DataMember(Name = "IdSAF", IsRequired = false)]public int? IdSAF{get;set;}		

		  [DataMember(Name = "Codigo", IsRequired = false)]
		  public string Codigo
		  {
		   get{ if(_Codigo==null)_Codigo= string.Empty;
				return _Codigo; 
				}
		   set{ _Codigo=value;}
		  }
		 
		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 [DataMember(Name = "FechaAlta", IsRequired = false)]public DateTime? FechaAlta{get;set;}		
[DataMember(Name = "FechaAlta_To", IsRequired = false)]		
public DateTime? FechaAlta_To{get;set;}		
[DataMember(Name = "FechaBajaIsNull", IsRequired = false)]
			  public bool? FechaBajaIsNull{get;set;}[DataMember(Name = "FechaBaja", IsRequired = false)]public DateTime? FechaBaja{get;set;}		
[DataMember(Name = "FechaBaja_To", IsRequired = false)]		
public DateTime? FechaBaja_To{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		
[DataMember(Name = "IdSectorialistaIsNull", IsRequired = false)]
			  public bool? IdSectorialistaIsNull{get;set;}[DataMember(Name = "IdSectorialista", IsRequired = false)]public int? IdSectorialista{get;set;}		

		#endregion
    }
}
