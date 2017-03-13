using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PersonaFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 private string _Apellido;
		 private string _NombreCompleto;
		 private string _Telefono;
		 private string _TelefonoLaboral;
		 private string _Fax;
		 private string _EMailPersonal;
		 private string _EMailLaboral;
		 private string _CargoEspecifico;
		 private string _NivelJerarquico;
		 private string _Domicilio;
		 private string _CodPostal;
		 private string _Sexo;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPersona", IsRequired = false)]public int? IdPersona{get;set;}		
[DataMember(Name = "EsUsuario", IsRequired = false)]public bool? EsUsuario{get;set;}		
[DataMember(Name = "EsContacto", IsRequired = false)]public bool? EsContacto{get;set;}		

		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 
		  [DataMember(Name = "Apellido", IsRequired = false)]
		  public string Apellido
		  {
		   get{ if(_Apellido==null)_Apellido= string.Empty;
				return _Apellido; 
				}
		   set{ _Apellido=value;}
		  }
		 
		  [DataMember(Name = "NombreCompleto", IsRequired = false)]
		  public string NombreCompleto
		  {
		   get{ if(_NombreCompleto==null)_NombreCompleto= string.Empty;
				return _NombreCompleto; 
				}
		   set{ _NombreCompleto=value;}
		  }
		 [DataMember(Name = "IdOficina", IsRequired = false)]public int? IdOficina{get;set;}		
[DataMember(Name = "IdCargoIsNull", IsRequired = false)]
			  public bool? IdCargoIsNull{get;set;}[DataMember(Name = "IdCargo", IsRequired = false)]public int? IdCargo{get;set;}		

		  [DataMember(Name = "Telefono", IsRequired = false)]
		  public string Telefono
		  {
		   get{ if(_Telefono==null)_Telefono= string.Empty;
				return _Telefono; 
				}
		   set{ _Telefono=value;}
		  }
		 
		  [DataMember(Name = "TelefonoLaboral", IsRequired = false)]
		  public string TelefonoLaboral
		  {
		   get{ if(_TelefonoLaboral==null)_TelefonoLaboral= string.Empty;
				return _TelefonoLaboral; 
				}
		   set{ _TelefonoLaboral=value;}
		  }
		 
		  [DataMember(Name = "Fax", IsRequired = false)]
		  public string Fax
		  {
		   get{ if(_Fax==null)_Fax= string.Empty;
				return _Fax; 
				}
		   set{ _Fax=value;}
		  }
		 
		  [DataMember(Name = "EMailPersonal", IsRequired = false)]
		  public string EMailPersonal
		  {
		   get{ if(_EMailPersonal==null)_EMailPersonal= string.Empty;
				return _EMailPersonal; 
				}
		   set{ _EMailPersonal=value;}
		  }
		 
		  [DataMember(Name = "EMailLaboral", IsRequired = false)]
		  public string EMailLaboral
		  {
		   get{ if(_EMailLaboral==null)_EMailLaboral= string.Empty;
				return _EMailLaboral; 
				}
		   set{ _EMailLaboral=value;}
		  }
		 
		  [DataMember(Name = "CargoEspecifico", IsRequired = false)]
		  public string CargoEspecifico
		  {
		   get{ if(_CargoEspecifico==null)_CargoEspecifico= string.Empty;
				return _CargoEspecifico; 
				}
		   set{ _CargoEspecifico=value;}
		  }
		 
		  [DataMember(Name = "NivelJerarquico", IsRequired = false)]
		  public string NivelJerarquico
		  {
		   get{ if(_NivelJerarquico==null)_NivelJerarquico= string.Empty;
				return _NivelJerarquico; 
				}
		   set{ _NivelJerarquico=value;}
		  }
		 
		  [DataMember(Name = "Domicilio", IsRequired = false)]
		  public string Domicilio
		  {
		   get{ if(_Domicilio==null)_Domicilio= string.Empty;
				return _Domicilio; 
				}
		   set{ _Domicilio=value;}
		  }
		 
		  [DataMember(Name = "CodPostal", IsRequired = false)]
		  public string CodPostal
		  {
		   get{ if(_CodPostal==null)_CodPostal= string.Empty;
				return _CodPostal; 
				}
		   set{ _CodPostal=value;}
		  }
		 [DataMember(Name = "IdClasificacionGeograficaIsNull", IsRequired = false)]
			  public bool? IdClasificacionGeograficaIsNull{get;set;}[DataMember(Name = "IdClasificacionGeografica", IsRequired = false)]public int? IdClasificacionGeografica{get;set;}		

		  [DataMember(Name = "Sexo", IsRequired = false)]
		  public string Sexo
		  {
		   get{ if(_Sexo==null)_Sexo= string.Empty;
				return _Sexo; 
				}
		   set{ _Sexo=value;}
		  }
		 [DataMember(Name = "EnviarEMailIsNull", IsRequired = false)]
			  public bool? EnviarEMailIsNull{get;set;}[DataMember(Name = "EnviarEMail", IsRequired = false)]public bool? EnviarEMail{get;set;}		
[DataMember(Name = "EnviarNotaIsNull", IsRequired = false)]
			  public bool? EnviarNotaIsNull{get;set;}[DataMember(Name = "EnviarNota", IsRequired = false)]public bool? EnviarNota{get;set;}		
[DataMember(Name = "FechaAlta", IsRequired = false)]public DateTime? FechaAlta{get;set;}		
[DataMember(Name = "FechaAlta_To", IsRequired = false)]		
public DateTime? FechaAlta_To{get;set;}		
[DataMember(Name = "FechaBajaIsNull", IsRequired = false)]
			  public bool? FechaBajaIsNull{get;set;}[DataMember(Name = "FechaBaja", IsRequired = false)]public DateTime? FechaBaja{get;set;}		
[DataMember(Name = "FechaBaja_To", IsRequired = false)]		
public DateTime? FechaBaja_To{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		
[DataMember(Name = "FechaUltMod", IsRequired = false)]public DateTime? FechaUltMod{get;set;}		
[DataMember(Name = "FechaUltMod_To", IsRequired = false)]		
public DateTime? FechaUltMod_To{get;set;}		
[DataMember(Name = "IdUsuarioUltMod", IsRequired = false)]public int? IdUsuarioUltMod{get;set;}		
[DataMember(Name = "IdUsuarioUltMod_To", IsRequired = false)]		
public int? IdUsuarioUltMod_To{get;set;}		

		#endregion
    }
}
