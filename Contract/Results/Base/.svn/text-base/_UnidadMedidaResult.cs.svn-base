using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _UnidadMedidaResult : IResult<int>
    {        
		public virtual int ID{get{return IdUnidadMedida;}}
		 public int IdUnidadMedida{get;set;}
		 public string Sigla{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual UnidadMedida ToEntity()
		{
		   UnidadMedida _UnidadMedida = new UnidadMedida();
		_UnidadMedida.IdUnidadMedida = this.IdUnidadMedida;
		 _UnidadMedida.Sigla = this.Sigla;
		 _UnidadMedida.Nombre = this.Nombre;
		 _UnidadMedida.Activo = this.Activo;
		 
		  return _UnidadMedida;
		}		
		public virtual void Set(UnidadMedida entity)
		{		   
		 this.IdUnidadMedida= entity.IdUnidadMedida ;
		  this.Sigla= entity.Sigla ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(UnidadMedida entity)
        {
		   if(entity == null)return false;
         if(!entity.IdUnidadMedida.Equals(this.IdUnidadMedida))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("UnidadMedida", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		