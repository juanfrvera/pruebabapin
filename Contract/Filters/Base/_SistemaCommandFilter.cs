using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _SistemaCommandFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 private string _Descripcion;
		 private string _CommandText;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdSistemaCommand", IsRequired = false)]public int? IdSistemaCommand{get;set;}		
[DataMember(Name = "IdSistemaCommand_To", IsRequired = false)]		
public int? IdSistemaCommand_To{get;set;}		

		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 
		  [DataMember(Name = "Descripcion", IsRequired = false)]
		  public string Descripcion
		  {
		   get{ if(_Descripcion==null)_Descripcion= string.Empty;
				return _Descripcion; 
				}
		   set{ _Descripcion=value;}
		  }
		 [DataMember(Name = "IdsistemaEntidad", IsRequired = false)]public int? IdsistemaEntidad{get;set;}		

		  [DataMember(Name = "CommandText", IsRequired = false)]
		  public string CommandText
		  {
		   get{ if(_CommandText==null)_CommandText= string.Empty;
				return _CommandText; 
				}
		   set{ _CommandText=value;}
		  }
		 [DataMember(Name = "CommandType", IsRequired = false)]public int? CommandType{get;set;}		
[DataMember(Name = "CommandType_To", IsRequired = false)]		
public int? CommandType_To{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
