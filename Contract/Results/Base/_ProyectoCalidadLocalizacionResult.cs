using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoCalidadLocalizacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoCalidadLocalizacion;}}
		 public int IdProyectoCalidadLocalizacion{get;set;}
		 public int IdProyectoCalidad{get;set;}
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
	public int ProyectoCalidad_IdProyecto{get;set;}	
	public bool ProyectoCalidad_DenominacionOK{get;set;}	
	public string ProyectoCalidad_DenominacionSugerida{get;set;}	
	public string ProyectoCalidad_DenominacionOriginal{get;set;}	
	public bool ProyectoCalidad_ProyectoTipoOk{get;set;}	
	public int? ProyectoCalidad_IdProyectoTipo{get;set;}	
	public int? ProyectoCalidad_EstadoOK{get;set;}	
	public int? ProyectoCalidad_IdEstadoSugerido{get;set;}	
	public bool ProyectoCalidad_ProcesoOk{get;set;}	
	public int? ProyectoCalidad_IdProceso{get;set;}	
	public bool ProyectoCalidad_FinalidadFuncionOk{get;set;}	
	public int? ProyectoCalidad_IdClasificacionFuncional{get;set;}	
	public bool ProyectoCalidad_ReqDictamen{get;set;}	
	public string ProyectoCalidad_Comenatrio{get;set;}	
	public int ProyectoCalidad_IdEstado{get;set;}	
	public DateTime? ProyectoCalidad_FechaEstado{get;set;}	
	public bool ProyectoCalidad_LocalizacionOK{get;set;}	
					
		public virtual ProyectoCalidadLocalizacion ToEntity()
		{
		   ProyectoCalidadLocalizacion _ProyectoCalidadLocalizacion = new ProyectoCalidadLocalizacion();
		_ProyectoCalidadLocalizacion.IdProyectoCalidadLocalizacion = this.IdProyectoCalidadLocalizacion;
		 _ProyectoCalidadLocalizacion.IdProyectoCalidad = this.IdProyectoCalidad;
		 _ProyectoCalidadLocalizacion.IdClasificacionGeografica = this.IdClasificacionGeografica;
		 
		  return _ProyectoCalidadLocalizacion;
		}		
		public virtual void Set(ProyectoCalidadLocalizacion entity)
		{		   
		 this.IdProyectoCalidadLocalizacion= entity.IdProyectoCalidadLocalizacion ;
		  this.IdProyectoCalidad= entity.IdProyectoCalidad ;
		  this.IdClasificacionGeografica= entity.IdClasificacionGeografica ;
		 		  
		}		
		public virtual bool Equals(ProyectoCalidadLocalizacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoCalidadLocalizacion.Equals(this.IdProyectoCalidadLocalizacion))return false;
		  if(!entity.IdProyectoCalidad.Equals(this.IdProyectoCalidad))return false;
		  if(!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoCalidadLocalizacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoCalidad","ProyectoCalidad_DenominacionSugerida")
			,new DataColumnMapping("ClasificacionGeografica","ClasificacionGeografica_Nombre")
			}));
		}
	}
}
		