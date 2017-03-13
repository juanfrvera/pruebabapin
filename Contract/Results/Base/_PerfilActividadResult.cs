using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PerfilActividadResult : IResult<int>
    {        
		public virtual int ID{get{return IdPerfilActividad;}}
		 public int IdPerfilActividad{get;set;}
		 public int IdPerfil{get;set;}
		 public int IdActividad{get;set;}
		 
		 public string Actividad_Nombre{get;set;}	
	public bool Actividad_Activo{get;set;}	
	public string Perfil_Nombre{get;set;}	
	public int Perfil_IdPerfilTipo{get;set;}	
	public bool Perfil_Activo{get;set;}	
	public bool Perfil_EsDefault{get;set;}	
	public string Perfil_Codigo{get;set;}	
					
		public virtual PerfilActividad ToEntity()
		{
		   PerfilActividad _PerfilActividad = new PerfilActividad();
		_PerfilActividad.IdPerfilActividad = this.IdPerfilActividad;
		 _PerfilActividad.IdPerfil = this.IdPerfil;
		 _PerfilActividad.IdActividad = this.IdActividad;
		 
		  return _PerfilActividad;
		}		
		public virtual void Set(PerfilActividad entity)
		{		   
		 this.IdPerfilActividad= entity.IdPerfilActividad ;
		  this.IdPerfil= entity.IdPerfil ;
		  this.IdActividad= entity.IdActividad ;
		 		  
		}		
		public virtual bool Equals(PerfilActividad entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPerfilActividad.Equals(this.IdPerfilActividad))return false;
		  if(!entity.IdPerfil.Equals(this.IdPerfil))return false;
		  if(!entity.IdActividad.Equals(this.IdActividad))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PerfilActividad", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Perfil","Perfil_Nombre")
			,new DataColumnMapping("Actividad","Actividad_Nombre")
			}));
		}
	}
}
		