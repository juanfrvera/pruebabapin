using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SubConvenioTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdSubconvenioTipo;}}
		 public int IdSubconvenioTipo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual SubConvenioTipo ToEntity()
		{
		   SubConvenioTipo _SubConvenioTipo = new SubConvenioTipo();
		_SubConvenioTipo.IdSubconvenioTipo = this.IdSubconvenioTipo;
		 _SubConvenioTipo.Nombre = this.Nombre;
		 _SubConvenioTipo.Activo = this.Activo;
		 
		  return _SubConvenioTipo;
		}		
		public virtual void Set(SubConvenioTipo entity)
		{		   
		 this.IdSubconvenioTipo= entity.IdSubconvenioTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(SubConvenioTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSubconvenioTipo.Equals(this.IdSubconvenioTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SubConvenioTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		