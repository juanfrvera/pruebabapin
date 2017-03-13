using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoSubComponenteResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoSubComponente;}}
		 public int IdPrestamoSubComponente{get;set;}
		 public int IdPrestamoComponente{get;set;}
		 public string Descripcion{get;set;}
		 
		 public int PrestamoComponente_IdPrestamo{get;set;}	
	public int PrestamoComponente_IdObjetivo{get;set;}	
					
		public virtual PrestamoSubComponente ToEntity()
		{
		   PrestamoSubComponente _PrestamoSubComponente = new PrestamoSubComponente();
		_PrestamoSubComponente.IdPrestamoSubComponente = this.IdPrestamoSubComponente;
		 _PrestamoSubComponente.IdPrestamoComponente = this.IdPrestamoComponente;
		 _PrestamoSubComponente.Descripcion = this.Descripcion;
		 
		  return _PrestamoSubComponente;
		}		
		public virtual void Set(PrestamoSubComponente entity)
		{		   
		 this.IdPrestamoSubComponente= entity.IdPrestamoSubComponente ;
		  this.IdPrestamoComponente= entity.IdPrestamoComponente ;
		  this.Descripcion= entity.Descripcion ;
		 		  
		}		
		public virtual bool Equals(PrestamoSubComponente entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoSubComponente.Equals(this.IdPrestamoSubComponente))return false;
		  if(!entity.IdPrestamoComponente.Equals(this.IdPrestamoComponente))return false;
		  if(!entity.Descripcion.Equals(this.Descripcion))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoSubComponente", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PrestamoComponente","PrestamoComponente_IdPrestamoComponente")
			,new DataColumnMapping("Descripcion","Descripcion")
			}));
		}
	}
}
		