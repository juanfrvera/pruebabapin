using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EstadoDeDesicionResult : IResult<int>
    {        
		public virtual int ID{get{return IdEstadoDeDesicion;}}
		 public int IdEstadoDeDesicion{get;set;}
		 public string Nombre{get;set;}
		 public string Codigo{get;set;}
		 public int Orden{get;set;}
		 public string Descripcion{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual EstadoDeDesicion ToEntity()
		{
		   EstadoDeDesicion _EstadoDeDesicion = new EstadoDeDesicion();
		_EstadoDeDesicion.IdEstadoDeDesicion = this.IdEstadoDeDesicion;
		 _EstadoDeDesicion.Nombre = this.Nombre;
		 _EstadoDeDesicion.Codigo = this.Codigo;
		 _EstadoDeDesicion.Orden = this.Orden;
		 _EstadoDeDesicion.Descripcion = this.Descripcion;
		 _EstadoDeDesicion.Activo = this.Activo;
		 
		  return _EstadoDeDesicion;
		}		
		public virtual void Set(EstadoDeDesicion entity)
		{		   
		 this.IdEstadoDeDesicion= entity.IdEstadoDeDesicion ;
		  this.Nombre= entity.Nombre ;
		  this.Codigo= entity.Codigo ;
		  this.Orden= entity.Orden ;
		  this.Descripcion= entity.Descripcion ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(EstadoDeDesicion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEstadoDeDesicion.Equals(this.IdEstadoDeDesicion))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if((entity.Descripcion == null)?this.Descripcion!=null:!entity.Descripcion.Equals(this.Descripcion))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("EstadoDeDesicion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		