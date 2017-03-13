using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ActividadResult : IResult<int>
    {        
		public virtual int ID{get{return IdActividad;}}
		 public int IdActividad{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual Actividad ToEntity()
		{
		   Actividad _Actividad = new Actividad();
		_Actividad.IdActividad = this.IdActividad;
		 _Actividad.Nombre = this.Nombre;
		 _Actividad.Activo = this.Activo;
		 
		  return _Actividad;
		}		
		public virtual void Set(Actividad entity)
		{		   
		 this.IdActividad= entity.IdActividad ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Actividad entity)
        {
		   if(entity == null)return false;
         if(!entity.IdActividad.Equals(this.IdActividad))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Actividad", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		