using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoOrigenFinanciamientoTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoOrigenFinancianmientoTipo;}}
		 public int IdProyectoOrigenFinancianmientoTipo{get;set;}
		 public string Nombre{get;set;}
		 
		 				
		public virtual ProyectoOrigenFinanciamientoTipo ToEntity()
		{
		   ProyectoOrigenFinanciamientoTipo _ProyectoOrigenFinanciamientoTipo = new ProyectoOrigenFinanciamientoTipo();
		_ProyectoOrigenFinanciamientoTipo.IdProyectoOrigenFinancianmientoTipo = this.IdProyectoOrigenFinancianmientoTipo;
		 _ProyectoOrigenFinanciamientoTipo.Nombre = this.Nombre;
		 
		  return _ProyectoOrigenFinanciamientoTipo;
		}		
		public virtual void Set(ProyectoOrigenFinanciamientoTipo entity)
		{		   
		 this.IdProyectoOrigenFinancianmientoTipo= entity.IdProyectoOrigenFinancianmientoTipo ;
		  this.Nombre= entity.Nombre ;
		 		  
		}		
		public virtual bool Equals(ProyectoOrigenFinanciamientoTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoOrigenFinancianmientoTipo.Equals(this.IdProyectoOrigenFinancianmientoTipo))return false;
		  if((entity.Nombre == null)?this.Nombre!=null:!entity.Nombre.Equals(this.Nombre))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoOrigenFinanciamientoTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoOrigenFinancianmientoTipo","IdProyectoOrigenFinancianmientoTipo")
			,new DataColumnMapping("Nombre","Nombre")
			}));
		}
	}
}
		