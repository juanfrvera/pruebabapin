using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoAlcanceGeograficoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoAlcanceGeografico;}}
		 public int IdPrestamoAlcanceGeografico{get;set;}
		 public int IdPrestamo{get;set;}
		 public int IdClasificacionGeografica{get;set;}
		 
		 public string ClasificacionGeografica_Codigo{get;set;}	
	public string ClasificacionGeografica_Nombre{get;set;}	
	public int ClasificacionGeografica_IdClasificacionGeograficaTipo{get;set;}	
	public int? ClasificacionGeografica_IdClasificacionGeograficaPadre{get;set;}	
	public bool ClasificacionGeografica_Activo{get;set;}	
	public string ClasificacionGeografica_Descripcion{get;set;}	
	public string ClasificacionGeografica_BreadcrumbId{get;set;}	
	public string ClasificacionGeografica_BreadcrumOrden{get;set;}	
	public int? ClasificacionGeografica_Orden{get;set;}	
	public int? ClasificacionGeografica_Nivel{get;set;}	
	public string ClasificacionGeografica_DescripcionInvertida{get;set;}	
	public bool ClasificacionGeografica_Seleccionable{get;set;}	
	public string ClasificacionGeografica_BreadcrumbCode{get;set;}	
	public string ClasificacionGeografica_DescripcionCodigo{get;set;}	
	public int Prestamo_IdPrograma{get;set;}	
	public int Prestamo_Numero{get;set;}	
	public string Prestamo_Denominacion{get;set;}	
	public string Prestamo_Descripcion{get;set;}	
	public string Prestamo_Observacion{get;set;}	
	public DateTime Prestamo_FechaAlta{get;set;}	
	public DateTime Prestamo_FechaModificacion{get;set;}	
	public int Prestamo_IdUsuarioModificacion{get;set;}	
	public int? Prestamo_IdEstadoActual{get;set;}	
	public string Prestamo_ResponsablePolitico{get;set;}	
	public string Prestamo_ResponsableTecnico{get;set;}	
	public string Prestamo_CodigoVinculacion1{get;set;}	
	public string Prestamo_CodigoVinculacion2{get;set;}	
					
		public virtual PrestamoAlcanceGeografico ToEntity()
		{
		   PrestamoAlcanceGeografico _PrestamoAlcanceGeografico = new PrestamoAlcanceGeografico();
		_PrestamoAlcanceGeografico.IdPrestamoAlcanceGeografico = this.IdPrestamoAlcanceGeografico;
		 _PrestamoAlcanceGeografico.IdPrestamo = this.IdPrestamo;
		 _PrestamoAlcanceGeografico.IdClasificacionGeografica = this.IdClasificacionGeografica;
		 
		  return _PrestamoAlcanceGeografico;
		}		
		public virtual void Set(PrestamoAlcanceGeografico entity)
		{		   
		 this.IdPrestamoAlcanceGeografico= entity.IdPrestamoAlcanceGeografico ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdClasificacionGeografica= entity.IdClasificacionGeografica ;
		 		  
		}		
		public virtual bool Equals(PrestamoAlcanceGeografico entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoAlcanceGeografico.Equals(this.IdPrestamoAlcanceGeografico))return false;
		  if(!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
		  if(!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoAlcanceGeografico", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("ClasificacionGeografica","ClasificacionGeografica_Nombre")
			}));
		}
	}
}
		