using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoOficinaPerfilFuncionarioResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoOficinaPerfilFuncionario;}}
		 public int IdProyectoOficinaPerfilFuncionario{get;set;}
		 public int IdProyectoOficinaPerfil{get;set;}
		 public int IdUsuario{get;set;}
		 
		 public int ProyectoOficinaPerfil_IdProyecto{get;set;}	
	public int ProyectoOficinaPerfil_IdOficina{get;set;}	
	public int ProyectoOficinaPerfil_IdPerfil{get;set;}	
	public string Usuario_NombreUsuario{get;set;}	
	public string Usuario_Clave{get;set;}	
	public bool Usuario_Activo{get;set;}	
	public bool Usuario_EsSectioralista{get;set;}	
	public int Usuario_IdLanguage{get;set;}	
	public bool Usuario_AccesoTotal{get;set;}	
					
		public virtual ProyectoOficinaPerfilFuncionario ToEntity()
		{
		   ProyectoOficinaPerfilFuncionario _ProyectoOficinaPerfilFuncionario = new ProyectoOficinaPerfilFuncionario();
		_ProyectoOficinaPerfilFuncionario.IdProyectoOficinaPerfilFuncionario = this.IdProyectoOficinaPerfilFuncionario;
		 _ProyectoOficinaPerfilFuncionario.IdProyectoOficinaPerfil = this.IdProyectoOficinaPerfil;
		 _ProyectoOficinaPerfilFuncionario.IdUsuario = this.IdUsuario;
		 
		  return _ProyectoOficinaPerfilFuncionario;
		}		
		public virtual void Set(ProyectoOficinaPerfilFuncionario entity)
		{		   
		 this.IdProyectoOficinaPerfilFuncionario= entity.IdProyectoOficinaPerfilFuncionario ;
		  this.IdProyectoOficinaPerfil= entity.IdProyectoOficinaPerfil ;
		  this.IdUsuario= entity.IdUsuario ;
		 		  
		}		
		public virtual bool Equals(ProyectoOficinaPerfilFuncionario entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoOficinaPerfilFuncionario.Equals(this.IdProyectoOficinaPerfilFuncionario))return false;
		  if(!entity.IdProyectoOficinaPerfil.Equals(this.IdProyectoOficinaPerfil))return false;
		  if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoOficinaPerfilFuncionario", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoOficinaPerfil","ProyectoOficinaPerfil_IdProyectoOficinaPerfil")
			,new DataColumnMapping("Usuario","Usuario_NombreUsuario")
			}));
		}
	}
}
		