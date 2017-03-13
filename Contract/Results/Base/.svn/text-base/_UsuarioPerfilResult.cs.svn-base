using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _UsuarioPerfilResult : IResult<int>
    {        
		public virtual int ID{get{return IdUsuarioPerfil;}}
		 public int IdUsuarioPerfil{get;set;}
		 public int IdUsuario{get;set;}
		 public int? IdPerfil{get;set;}
		 
		 public string Perfil_Nombre{get;set;}	
	public int? Perfil_IdPerfilTipo{get;set;}	
	public bool? Perfil_Activo{get;set;}	
	public bool? Perfil_EsDefault{get;set;}	
	public string Perfil_Codigo{get;set;}	
	public string Usuario_NombreUsuario{get;set;}	
	public string Usuario_Clave{get;set;}	
	public bool Usuario_Activo{get;set;}	
	public bool Usuario_EsSectioralista{get;set;}	
	public int Usuario_IdLanguage{get;set;}	
	public bool Usuario_AccesoTotal{get;set;}	
					
		public virtual UsuarioPerfil ToEntity()
		{
		   UsuarioPerfil _UsuarioPerfil = new UsuarioPerfil();
		_UsuarioPerfil.IdUsuarioPerfil = this.IdUsuarioPerfil;
		 _UsuarioPerfil.IdUsuario = this.IdUsuario;
		 _UsuarioPerfil.IdPerfil = this.IdPerfil;
		 
		  return _UsuarioPerfil;
		}		
		public virtual void Set(UsuarioPerfil entity)
		{		   
		 this.IdUsuarioPerfil= entity.IdUsuarioPerfil ;
		  this.IdUsuario= entity.IdUsuario ;
		  this.IdPerfil= entity.IdPerfil ;
		 		  
		}		
		public virtual bool Equals(UsuarioPerfil entity)
        {
		   if(entity == null)return false;
         if(!entity.IdUsuarioPerfil.Equals(this.IdUsuarioPerfil))return false;
		  if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		  if((entity.IdPerfil == null)?(this.IdPerfil.HasValue && this.IdPerfil.Value > 0):!entity.IdPerfil.Equals(this.IdPerfil))return false;
						 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("UsuarioPerfil", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Usuario","Usuario_NombreUsuario")
			,new DataColumnMapping("Perfil","Perfil_Nombre")
			}));
		}
	}
}
		