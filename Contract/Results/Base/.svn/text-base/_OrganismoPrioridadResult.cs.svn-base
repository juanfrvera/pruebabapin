using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _OrganismoPrioridadResult : IResult<int>
    {        
		public virtual int ID{get{return IdOrganismoPrioridad;}}
		 public int IdOrganismoPrioridad{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual OrganismoPrioridad ToEntity()
		{
		   OrganismoPrioridad _OrganismoPrioridad = new OrganismoPrioridad();
		_OrganismoPrioridad.IdOrganismoPrioridad = this.IdOrganismoPrioridad;
		 _OrganismoPrioridad.Nombre = this.Nombre;
		 _OrganismoPrioridad.Activo = this.Activo;
		 
		  return _OrganismoPrioridad;
		}		
		public virtual void Set(OrganismoPrioridad entity)
		{		   
		 this.IdOrganismoPrioridad= entity.IdOrganismoPrioridad ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(OrganismoPrioridad entity)
        {
		   if(entity == null)return false;
         if(!entity.IdOrganismoPrioridad.Equals(this.IdOrganismoPrioridad))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("OrganismoPrioridad", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		