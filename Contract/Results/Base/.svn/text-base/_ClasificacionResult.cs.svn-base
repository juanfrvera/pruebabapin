using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ClasificacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdClasificacion;}}
		 public int IdClasificacion{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual Clasificacion ToEntity()
		{
		   Clasificacion _Clasificacion = new Clasificacion();
		_Clasificacion.IdClasificacion = this.IdClasificacion;
		 _Clasificacion.Nombre = this.Nombre;
		 _Clasificacion.Activo = this.Activo;
		 
		  return _Clasificacion;
		}		
		public virtual void Set(Clasificacion entity)
		{		   
		 this.IdClasificacion= entity.IdClasificacion ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Clasificacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdClasificacion.Equals(this.IdClasificacion))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Clasificacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		