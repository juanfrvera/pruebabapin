using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ClasificacionGastoTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdClasificacionGastoTipo;}}
		 public int IdClasificacionGastoTipo{get;set;}
		 public string Nombre{get;set;}
		 public int Nivel{get;set;}
		 
		 				
		public virtual ClasificacionGastoTipo ToEntity()
		{
		   ClasificacionGastoTipo _ClasificacionGastoTipo = new ClasificacionGastoTipo();
		_ClasificacionGastoTipo.IdClasificacionGastoTipo = this.IdClasificacionGastoTipo;
		 _ClasificacionGastoTipo.Nombre = this.Nombre;
		 _ClasificacionGastoTipo.Nivel = this.Nivel;
		 
		  return _ClasificacionGastoTipo;
		}		
		public virtual void Set(ClasificacionGastoTipo entity)
		{		   
		 this.IdClasificacionGastoTipo= entity.IdClasificacionGastoTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Nivel= entity.Nivel ;
		 		  
		}		
		public virtual bool Equals(ClasificacionGastoTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdClasificacionGastoTipo.Equals(this.IdClasificacionGastoTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Nivel.Equals(this.Nivel))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ClasificacionGastoTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Nivel","Nivel")
			}));
		}
	}
}
		