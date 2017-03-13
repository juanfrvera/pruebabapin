using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EstadoResult : IResult<int>
    {        
		public virtual int ID{get{return IdEstado;}}
		 public int IdEstado{get;set;}
		 public string Nombre{get;set;}
		 public string Codigo{get;set;}
		 public int Orden{get;set;}
		 public string Descripcion{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual Estado ToEntity()
		{
		   Estado _Estado = new Estado();
		_Estado.IdEstado = this.IdEstado;
		 _Estado.Nombre = this.Nombre;
		 _Estado.Codigo = this.Codigo;
		 _Estado.Orden = this.Orden;
		 _Estado.Descripcion = this.Descripcion;
		 _Estado.Activo = this.Activo;
		 
		  return _Estado;
		}		
		public virtual void Set(Estado entity)
		{		   
		 this.IdEstado= entity.IdEstado ;
		  this.Nombre= entity.Nombre ;
		  this.Codigo= entity.Codigo ;
		  this.Orden= entity.Orden ;
		  this.Descripcion= entity.Descripcion ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Estado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEstado.Equals(this.IdEstado))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if((entity.Descripcion == null)?this.Descripcion!=null:!entity.Descripcion.Equals(this.Descripcion))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Estado", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		