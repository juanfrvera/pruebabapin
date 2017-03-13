using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ClasificacionGastoRubroResult : IResult<int>
    {        
		public virtual int ID{get{return IdClasificacionGastoRubro;}}
		 public int IdClasificacionGastoRubro{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 
		 				
		public virtual ClasificacionGastoRubro ToEntity()
		{
		   ClasificacionGastoRubro _ClasificacionGastoRubro = new ClasificacionGastoRubro();
		_ClasificacionGastoRubro.IdClasificacionGastoRubro = this.IdClasificacionGastoRubro;
		 _ClasificacionGastoRubro.Codigo = this.Codigo;
		 _ClasificacionGastoRubro.Nombre = this.Nombre;
		 
		  return _ClasificacionGastoRubro;
		}		
		public virtual void Set(ClasificacionGastoRubro entity)
		{		   
		 this.IdClasificacionGastoRubro= entity.IdClasificacionGastoRubro ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		 		  
		}		
		public virtual bool Equals(ClasificacionGastoRubro entity)
        {
		   if(entity == null)return false;
         if(!entity.IdClasificacionGastoRubro.Equals(this.IdClasificacionGastoRubro))return false;
		  if((entity.Codigo == null)?this.Codigo!=null:!entity.Codigo.Equals(this.Codigo))return false;
			 if((entity.Nombre == null)?this.Nombre!=null:!entity.Nombre.Equals(this.Nombre))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ClasificacionGastoRubro", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			}));
		}
	}
}
		