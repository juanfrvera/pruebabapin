using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoCalificacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoCalificacion;}}
		 public int IdProyectoCalificacion{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual ProyectoCalificacion ToEntity()
		{
		   ProyectoCalificacion _ProyectoCalificacion = new ProyectoCalificacion();
		_ProyectoCalificacion.IdProyectoCalificacion = this.IdProyectoCalificacion;
		 _ProyectoCalificacion.Nombre = this.Nombre;
		 _ProyectoCalificacion.Activo = this.Activo;
		 
		  return _ProyectoCalificacion;
		}		
		public virtual void Set(ProyectoCalificacion entity)
		{		   
		 this.IdProyectoCalificacion= entity.IdProyectoCalificacion ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(ProyectoCalificacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoCalificacion.Equals(this.IdProyectoCalificacion))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoCalificacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		