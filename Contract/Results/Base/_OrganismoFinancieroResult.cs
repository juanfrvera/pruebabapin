using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _OrganismoFinancieroResult : IResult<int>
    {        
		public virtual int ID{get{return IdOrganismoFinanciero;}}
		 public int IdOrganismoFinanciero{get;set;}
		 public string Sigla{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual OrganismoFinanciero ToEntity()
		{
		   OrganismoFinanciero _OrganismoFinanciero = new OrganismoFinanciero();
		_OrganismoFinanciero.IdOrganismoFinanciero = this.IdOrganismoFinanciero;
		 _OrganismoFinanciero.Sigla = this.Sigla;
		 _OrganismoFinanciero.Nombre = this.Nombre;
		 _OrganismoFinanciero.Activo = this.Activo;
		 
		  return _OrganismoFinanciero;
		}		
		public virtual void Set(OrganismoFinanciero entity)
		{		   
		 this.IdOrganismoFinanciero= entity.IdOrganismoFinanciero ;
		  this.Sigla= entity.Sigla ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(OrganismoFinanciero entity)
        {
		   if(entity == null)return false;
         if(!entity.IdOrganismoFinanciero.Equals(this.IdOrganismoFinanciero))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("OrganismoFinanciero", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		