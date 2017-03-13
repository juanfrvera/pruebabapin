using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoSeguimientoLocalizacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoSeguimientoLocalizacion;}}
		 public int IdProyectoSeguimientoLocalizacion{get;set;}
		 public int IdProyectoSeguimiento{get;set;}
		 public int IdCalificacionGeografica{get;set;}
		 
		 public string CalificacionGeografica_Codigo{get;set;}	
	public string CalificacionGeografica_Nombre{get;set;}	
	public int CalificacionGeografica_IdClasificacionGeograficaTipo{get;set;}	
	public int? CalificacionGeografica_IdClasificacionGeograficaPadre{get;set;}	
	public bool CalificacionGeografica_Activo{get;set;}	
	public string CalificacionGeografica_Descripcion{get;set;}	
	public string CalificacionGeografica_BreadcrumbId{get;set;}	
	public string CalificacionGeografica_BreadcrumOrden{get;set;}	
	public int? CalificacionGeografica_Orden{get;set;}	
	public int? CalificacionGeografica_Nivel{get;set;}	
	public string CalificacionGeografica_DescripcionInvertida{get;set;}	
	public bool CalificacionGeografica_Seleccionable{get;set;}	
	public string CalificacionGeografica_BreadcrumbCode{get;set;}	
	public string CalificacionGeografica_DescripcionCodigo{get;set;}	
	public int ProyectoSeguimiento_IdSaf{get;set;}	
	public string ProyectoSeguimiento_Denominacion{get;set;}	
	public string ProyectoSeguimiento_Ruta{get;set;}	
	public string ProyectoSeguimiento_Malla{get;set;}	
	public int ProyectoSeguimiento_IdAnalista{get;set;}	
	public int? ProyectoSeguimiento_IdProyectoSeguimientoAnterior{get;set;}	
					
		public virtual ProyectoSeguimientoLocalizacion ToEntity()
		{
		   ProyectoSeguimientoLocalizacion _ProyectoSeguimientoLocalizacion = new ProyectoSeguimientoLocalizacion();
		_ProyectoSeguimientoLocalizacion.IdProyectoSeguimientoLocalizacion = this.IdProyectoSeguimientoLocalizacion;
		 _ProyectoSeguimientoLocalizacion.IdProyectoSeguimiento = this.IdProyectoSeguimiento;
		 _ProyectoSeguimientoLocalizacion.IdCalificacionGeografica = this.IdCalificacionGeografica;
		 
		  return _ProyectoSeguimientoLocalizacion;
		}		
		public virtual void Set(ProyectoSeguimientoLocalizacion entity)
		{		   
		 this.IdProyectoSeguimientoLocalizacion= entity.IdProyectoSeguimientoLocalizacion ;
		  this.IdProyectoSeguimiento= entity.IdProyectoSeguimiento ;
		  this.IdCalificacionGeografica= entity.IdCalificacionGeografica ;
		 		  
		}		
		public virtual bool Equals(ProyectoSeguimientoLocalizacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoSeguimientoLocalizacion.Equals(this.IdProyectoSeguimientoLocalizacion))return false;
		  if(!entity.IdProyectoSeguimiento.Equals(this.IdProyectoSeguimiento))return false;
		  if(!entity.IdCalificacionGeografica.Equals(this.IdCalificacionGeografica))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoSeguimientoLocalizacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoSeguimiento","ProyectoSeguimiento_Denominacion")
			,new DataColumnMapping("CalificacionGeografica","ClasificacionGeografica_Nombre")
			}));
		}
	}
}
		