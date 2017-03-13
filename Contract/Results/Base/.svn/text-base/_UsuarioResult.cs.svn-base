using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _UsuarioResult : IResult<int>
    {        
		public virtual int ID{get{return IdUsuario;}}
		 public int IdUsuario{get;set;}
		 public string NombreUsuario{get;set;}
		 public string Clave{get;set;}
		 public bool Activo{get;set;}
		 public bool EsSectioralista{get;set;}
		 public int IdLanguage{get;set;}
		 
		 public string Language_Name{get;set;}	
	public string Language_Code{get;set;}	
	public bool Usuario_EsUsuario{get;set;}	
	public bool Usuario_EsContacto{get;set;}	
	public string Usuario_Nombre{get;set;}	
	public string Usuario_Apellido{get;set;}	
	public string Usuario_NombreCompleto{get;set;}	
	public int Usuario_IdOficina{get;set;}	
	public int? Usuario_IdCargo{get;set;}	
	public string Usuario_Telefono{get;set;}	
	public string Usuario_TelefonoLaboral{get;set;}	
	public string Usuario_Fax{get;set;}	
	public string Usuario_EMailPersonal{get;set;}	
	public string Usuario_EMailLaboral{get;set;}	
	public string Usuario_CargoEspecifico{get;set;}	
	public string Usuario_NivelJerarquico{get;set;}	
	public string Usuario_Domicilio{get;set;}	
	public string Usuario_CodPostal{get;set;}	
	public int? Usuario_IdProvincia{get;set;}	
	public int? Usuario_IdLocalidad{get;set;}	
	public string Usuario_Sexo{get;set;}	
	public bool? Usuario_EnviarEMail{get;set;}	
	public bool? Usuario_EnviarNota{get;set;}	
	public DateTime Usuario_FechaAlta{get;set;}	
	public DateTime? Usuario_FechaBaja{get;set;}	
	public bool Usuario_Activo{get;set;}	
	public DateTime Usuario_FechaUltMod{get;set;}	
	public int Usuario_IdUsuarioUltMod{get;set;}	
					
		public virtual Usuario ToEntity()
		{
		   Usuario _Usuario = new Usuario();
		_Usuario.IdUsuario = this.IdUsuario;
		 _Usuario.NombreUsuario = this.NombreUsuario;
		 _Usuario.Clave = this.Clave;
		 _Usuario.Activo = this.Activo;
		 _Usuario.EsSectioralista = this.EsSectioralista;
		 _Usuario.IdLanguage = this.IdLanguage;
		 
		  return _Usuario;
		}		
		public virtual void Set(Usuario entity)
		{		   
		 this.IdUsuario= entity.IdUsuario ;
		  this.NombreUsuario= entity.NombreUsuario ;
		  this.Clave= entity.Clave ;
		  this.Activo= entity.Activo ;
		  this.EsSectioralista= entity.EsSectioralista ;
		  this.IdLanguage= entity.IdLanguage ;
		 		  
		}		
		public virtual bool Equals(Usuario entity)
        {
		   if(entity == null)return false;
         if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		  if(!entity.NombreUsuario.Equals(this.NombreUsuario))return false;
		  if(!entity.Clave.Equals(this.Clave))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.EsSectioralista.Equals(this.EsSectioralista))return false;
		  if(!entity.IdLanguage.Equals(this.IdLanguage))return false;
		 
		  return true;
        }
	}
}
		