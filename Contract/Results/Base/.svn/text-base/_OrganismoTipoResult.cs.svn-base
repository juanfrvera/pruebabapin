using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _OrganismoTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdOrganismoTipo;}}
		 public int IdOrganismoTipo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual OrganismoTipo ToEntity()
		{
		   OrganismoTipo _OrganismoTipo = new OrganismoTipo();
		_OrganismoTipo.IdOrganismoTipo = this.IdOrganismoTipo;
		 _OrganismoTipo.Nombre = this.Nombre;
		 _OrganismoTipo.Activo = this.Activo;
		 
		  return _OrganismoTipo;
		}		
		public virtual void Set(OrganismoTipo entity)
		{		   
		 this.IdOrganismoTipo= entity.IdOrganismoTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(OrganismoTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdOrganismoTipo.Equals(this.IdOrganismoTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("OrganismoTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		