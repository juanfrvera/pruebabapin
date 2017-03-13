using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ModalidadFinancieraResult : IResult<int>
    {        
		public virtual int ID{get{return IdModalidadFinanciera;}}
		 public int IdModalidadFinanciera{get;set;}
		 public int IdOrganismoFinanciero{get;set;}
		 public string Sigla{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 public string OrganismoFinanciero_Sigla{get;set;}	
	public string OrganismoFinanciero_Nombre{get;set;}	
	public bool OrganismoFinanciero_Activo{get;set;}	
					
		public virtual ModalidadFinanciera ToEntity()
		{
		   ModalidadFinanciera _ModalidadFinanciera = new ModalidadFinanciera();
		_ModalidadFinanciera.IdModalidadFinanciera = this.IdModalidadFinanciera;
		 _ModalidadFinanciera.IdOrganismoFinanciero = this.IdOrganismoFinanciero;
		 _ModalidadFinanciera.Sigla = this.Sigla;
		 _ModalidadFinanciera.Nombre = this.Nombre;
		 _ModalidadFinanciera.Activo = this.Activo;
		 
		  return _ModalidadFinanciera;
		}		
		public virtual void Set(ModalidadFinanciera entity)
		{		   
		 this.IdModalidadFinanciera= entity.IdModalidadFinanciera ;
		  this.IdOrganismoFinanciero= entity.IdOrganismoFinanciero ;
		  this.Sigla= entity.Sigla ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(ModalidadFinanciera entity)
        {
		   if(entity == null)return false;
         if(!entity.IdModalidadFinanciera.Equals(this.IdModalidadFinanciera))return false;
		  if(!entity.IdOrganismoFinanciero.Equals(this.IdOrganismoFinanciero))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ModalidadFinanciera", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("OrganismoFinanciero","OrganismoFinanciero_Nombre")
			,new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		