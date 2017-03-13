using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoOficinaFuncionarioResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoOficinaPerfilFuncionario;}}
		 public int IdPrestamoOficinaPerfilFuncionario{get;set;}
		 public int IdPrestamoOficinaPerfil{get;set;}
		 public int IdUsuario{get;set;}
		 
		 public int PrestamoOficinaPerfil_IdPrestamo{get;set;}	
	public int PrestamoOficinaPerfil_IdOficina{get;set;}	
	public int PrestamoOficinaPerfil_IdPerfil{get;set;}	
					
		public virtual PrestamoOficinaFuncionario ToEntity()
		{
		   PrestamoOficinaFuncionario _PrestamoOficinaFuncionario = new PrestamoOficinaFuncionario();
		_PrestamoOficinaFuncionario.IdPrestamoOficinaPerfilFuncionario = this.IdPrestamoOficinaPerfilFuncionario;
		 _PrestamoOficinaFuncionario.IdPrestamoOficinaPerfil = this.IdPrestamoOficinaPerfil;
		 _PrestamoOficinaFuncionario.IdUsuario = this.IdUsuario;
		 
		  return _PrestamoOficinaFuncionario;
		}		
		public virtual void Set(PrestamoOficinaFuncionario entity)
		{		   
		 this.IdPrestamoOficinaPerfilFuncionario= entity.IdPrestamoOficinaPerfilFuncionario ;
		  this.IdPrestamoOficinaPerfil= entity.IdPrestamoOficinaPerfil ;
		  this.IdUsuario= entity.IdUsuario ;
		 		  
		}		
		public virtual bool Equals(PrestamoOficinaFuncionario entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoOficinaPerfilFuncionario.Equals(this.IdPrestamoOficinaPerfilFuncionario))return false;
		  if(!entity.IdPrestamoOficinaPerfil.Equals(this.IdPrestamoOficinaPerfil))return false;
		  if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoOficinaFuncionario", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PrestamoOficinaPerfil","PrestamoOficinaPerfil_IdPrestamoOficinaPerfil")
			,new DataColumnMapping("Usuario","IdUsuario")
			}));
		}
	}
}
		