using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoFinanciamientoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoFinanciamiento;}}
		 public int IdPrestamoFinanciamiento{get;set;}
		 public int IdPrestamoComponente{get;set;}
		 public int? IdPrestamoSubComponente{get;set;}
		 public int IdFuenteFinanciamiento{get;set;}
		 public decimal Monto{get;set;}
		 
		 public string FuenteFinanciamiento_Codigo{get;set;}	
	public string FuenteFinanciamiento_Nombre{get;set;}	
	public int FuenteFinanciamiento_IdFuenteFinanciamientoTipo{get;set;}	
	public bool FuenteFinanciamiento_Activo{get;set;}	
	public int? FuenteFinanciamiento_IdFuenteFinanciamientoPadre{get;set;}	
	public string FuenteFinanciamiento_BreadcrumbId{get;set;}	
	public string FuenteFinanciamiento_BreadcrumbOrden{get;set;}	
	public int? FuenteFinanciamiento_Nivel{get;set;}	
	public int? FuenteFinanciamiento_Orden{get;set;}	
	public string FuenteFinanciamiento_Descripcion{get;set;}	
	public string FuenteFinanciamiento_DescripcionInvertida{get;set;}	
	public bool FuenteFinanciamiento_Seleccionable{get;set;}	
	public string FuenteFinanciamiento_BreadcrumbCode{get;set;}	
	public string FuenteFinanciamiento_DescripcionCodigo{get;set;}	
	public int PrestamoComponente_IdPrestamo{get;set;}	
	public int PrestamoComponente_IdObjetivo{get;set;}	
					
		public virtual PrestamoFinanciamiento ToEntity()
		{
		   PrestamoFinanciamiento _PrestamoFinanciamiento = new PrestamoFinanciamiento();
		_PrestamoFinanciamiento.IdPrestamoFinanciamiento = this.IdPrestamoFinanciamiento;
		 _PrestamoFinanciamiento.IdPrestamoComponente = this.IdPrestamoComponente;
		 _PrestamoFinanciamiento.IdPrestamoSubComponente = this.IdPrestamoSubComponente;
		 _PrestamoFinanciamiento.IdFuenteFinanciamiento = this.IdFuenteFinanciamiento;
		 _PrestamoFinanciamiento.Monto = this.Monto;
		 
		  return _PrestamoFinanciamiento;
		}		
		public virtual void Set(PrestamoFinanciamiento entity)
		{		   
		 this.IdPrestamoFinanciamiento= entity.IdPrestamoFinanciamiento ;
		  this.IdPrestamoComponente= entity.IdPrestamoComponente ;
		  this.IdPrestamoSubComponente= entity.IdPrestamoSubComponente ;
		  this.IdFuenteFinanciamiento= entity.IdFuenteFinanciamiento ;
		  this.Monto= entity.Monto ;
		 		  
		}		
		public virtual bool Equals(PrestamoFinanciamiento entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoFinanciamiento.Equals(this.IdPrestamoFinanciamiento))return false;
		  if(!entity.IdPrestamoComponente.Equals(this.IdPrestamoComponente))return false;
		  if((entity.IdPrestamoSubComponente == null)?this.IdPrestamoSubComponente!=null:!entity.IdPrestamoSubComponente.Equals(this.IdPrestamoSubComponente))return false;
			 if(!entity.IdFuenteFinanciamiento.Equals(this.IdFuenteFinanciamiento))return false;
		  if(!entity.Monto.Equals(this.Monto))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoFinanciamiento", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PrestamoComponente","PrestamoComponente_IdPrestamoComponente")
			,new DataColumnMapping("PrestamoSubComponente","IdPrestamoSubComponente")
			,new DataColumnMapping("FuenteFinanciamiento","FuenteFinanciamiento_Nombre")
			,new DataColumnMapping("Monto","Monto")
			}));
		}
	}
}
		