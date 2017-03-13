using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ModalidadContratacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdModalidadContratacion;}}
		 public int IdModalidadContratacion{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual ModalidadContratacion ToEntity()
		{
		   ModalidadContratacion _ModalidadContratacion = new ModalidadContratacion();
		_ModalidadContratacion.IdModalidadContratacion = this.IdModalidadContratacion;
		 _ModalidadContratacion.Nombre = this.Nombre;
		 _ModalidadContratacion.Activo = this.Activo;
		 
		  return _ModalidadContratacion;
		}		
		public virtual void Set(ModalidadContratacion entity)
		{		   
		 this.IdModalidadContratacion= entity.IdModalidadContratacion ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(ModalidadContratacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdModalidadContratacion.Equals(this.IdModalidadContratacion))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ModalidadContratacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		