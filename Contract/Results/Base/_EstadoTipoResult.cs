using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EstadoTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdEstadoTipo;}}
		 public int IdEstadoTipo{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual EstadoTipo ToEntity()
		{
		   EstadoTipo _EstadoTipo = new EstadoTipo();
		_EstadoTipo.IdEstadoTipo = this.IdEstadoTipo;
		 _EstadoTipo.Codigo = this.Codigo;
		 _EstadoTipo.Nombre = this.Nombre;
		 _EstadoTipo.Activo = this.Activo;
		 
		  return _EstadoTipo;
		}		
		public virtual void Set(EstadoTipo entity)
		{		   
		 this.IdEstadoTipo= entity.IdEstadoTipo ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(EstadoTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEstadoTipo.Equals(this.IdEstadoTipo))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
	}
}
		