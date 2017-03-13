using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PerfilResult : IResult<int>
    {        
		public virtual int ID{get{return IdPerfil;}}
		 public int IdPerfil{get;set;}
		 public string Nombre{get;set;}
		 public int IdPerfilTipo{get;set;}
		 public bool Activo{get;set;}
		 public bool EsDefault{get;set;}
		 public string Codigo{get;set;}
		 
		 public string PerfilTipo_Nombre{get;set;}	
					
		public virtual Perfil ToEntity()
		{
		   Perfil _Perfil = new Perfil();
		_Perfil.IdPerfil = this.IdPerfil;
		 _Perfil.Nombre = this.Nombre;
		 _Perfil.IdPerfilTipo = this.IdPerfilTipo;
		 _Perfil.Activo = this.Activo;
		 _Perfil.EsDefault = this.EsDefault;
		 _Perfil.Codigo = this.Codigo;
		 
		  return _Perfil;
		}		
		public virtual void Set(Perfil entity)
		{		   
		 this.IdPerfil= entity.IdPerfil ;
		  this.Nombre= entity.Nombre ;
		  this.IdPerfilTipo= entity.IdPerfilTipo ;
		  this.Activo= entity.Activo ;
		  this.EsDefault= entity.EsDefault ;
		  this.Codigo= entity.Codigo ;
		 		  
		}		
		public virtual bool Equals(Perfil entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPerfil.Equals(this.IdPerfil))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.IdPerfilTipo.Equals(this.IdPerfilTipo))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.EsDefault.Equals(this.EsDefault))return false;
		  if((entity.Codigo == null)?this.Codigo!=null:!entity.Codigo.Equals(this.Codigo))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Perfil", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("PerfilTipo","PerfilTipo_Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("EsDefault","EsDefault")
			,new DataColumnMapping("Codigo","Codigo")
			}));
		}
	}
}
		