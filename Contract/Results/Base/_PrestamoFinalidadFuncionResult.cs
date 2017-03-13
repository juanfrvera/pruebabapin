using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoFinalidadFuncionResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoFinalidadFuncion;}}
		 public int IdPrestamoFinalidadFuncion{get;set;}
		 public int IdPrestamo{get;set;}
		 public int IdFinalidadFuncion{get;set;}
		 
		 public string FinalidadFuncion_Codigo{get;set;}	
	public string FinalidadFuncion_Denominacion{get;set;}	
	public bool FinalidadFuncion_Activo{get;set;}	
	public int? FinalidadFuncion_IdFinalidadFunciontipo{get;set;}	
	public int? FinalidadFuncion_IdFinalidadFuncionPadre{get;set;}	
	public string FinalidadFuncion_BreadcrumbId{get;set;}	
	public string FinalidadFuncion_BreadcrumbOrden{get;set;}	
	public int? FinalidadFuncion_Nivel{get;set;}	
	public int? FinalidadFuncion_Orden{get;set;}	
	public string FinalidadFuncion_Descripcion{get;set;}	
	public string FinalidadFuncion_DescripcionInvertida{get;set;}	
	public bool FinalidadFuncion_Seleccionable{get;set;}	
	public string FinalidadFuncion_BreadcrumbCode{get;set;}	
	public string FinalidadFuncion_DescripcionCodigo{get;set;}	
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
					
		public virtual PrestamoFinalidadFuncion ToEntity()
		{
		   PrestamoFinalidadFuncion _PrestamoFinalidadFuncion = new PrestamoFinalidadFuncion();
		_PrestamoFinalidadFuncion.IdPrestamoFinalidadFuncion = this.IdPrestamoFinalidadFuncion;
		 _PrestamoFinalidadFuncion.IdPrestamo = this.IdPrestamo;
		 _PrestamoFinalidadFuncion.IdFinalidadFuncion = this.IdFinalidadFuncion;
		 
		  return _PrestamoFinalidadFuncion;
		}		
		public virtual void Set(PrestamoFinalidadFuncion entity)
		{		   
		 this.IdPrestamoFinalidadFuncion= entity.IdPrestamoFinalidadFuncion ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdFinalidadFuncion= entity.IdFinalidadFuncion ;
		 		  
		}		
		public virtual bool Equals(PrestamoFinalidadFuncion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoFinalidadFuncion.Equals(this.IdPrestamoFinalidadFuncion))return false;
		  if(!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
		  if(!entity.IdFinalidadFuncion.Equals(this.IdFinalidadFuncion))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoFinalidadFuncion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("FinalidadFuncion","FinalidadFuncion_Descripcion")
			}));
		}
	}
}
		