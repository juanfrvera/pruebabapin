using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoCalificacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoCalificacion;}}
		 public int IdPrestamoCalificacion{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual PrestamoCalificacion ToEntity()
		{
		   PrestamoCalificacion _PrestamoCalificacion = new PrestamoCalificacion();
		_PrestamoCalificacion.IdPrestamoCalificacion = this.IdPrestamoCalificacion;
		 _PrestamoCalificacion.Nombre = this.Nombre;
		 _PrestamoCalificacion.Activo = this.Activo;
		 
		  return _PrestamoCalificacion;
		}		
		public virtual void Set(PrestamoCalificacion entity)
		{		   
		 this.IdPrestamoCalificacion= entity.IdPrestamoCalificacion ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(PrestamoCalificacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoCalificacion.Equals(this.IdPrestamoCalificacion))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoCalificacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		