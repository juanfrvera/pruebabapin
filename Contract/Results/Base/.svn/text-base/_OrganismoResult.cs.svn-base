using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _OrganismoResult : IResult<int>
    {        
		public virtual int ID{get{return IdOrganismo;}}
		 public int IdOrganismo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual Organismo ToEntity()
		{
		   Organismo _Organismo = new Organismo();
		_Organismo.IdOrganismo = this.IdOrganismo;
		 _Organismo.Nombre = this.Nombre;
		 _Organismo.Activo = this.Activo;
		 
		  return _Organismo;
		}		
		public virtual void Set(Organismo entity)
		{		   
		 this.IdOrganismo= entity.IdOrganismo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Organismo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdOrganismo.Equals(this.IdOrganismo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Organismo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		