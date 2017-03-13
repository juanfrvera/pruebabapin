using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _ProyectoCalidadLocalizacionData : EntityData<ProyectoCalidadLocalizacion,ProyectoCalidadLocalizacionFilter,ProyectoCalidadLocalizacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoCalidadLocalizacion entity)
		{			
			return entity.IdProyectoCalidadLocalizacion;
		}		
		public override ProyectoCalidadLocalizacion GetByEntity(ProyectoCalidadLocalizacion entity)
        {
            return this.GetById(entity.IdProyectoCalidadLocalizacion);
        }
        public override ProyectoCalidadLocalizacion GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoCalidadLocalizacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoCalidadLocalizacion> Query(ProyectoCalidadLocalizacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoCalidadLocalizacion == null || o.IdProyectoCalidadLocalizacion >=  filter.IdProyectoCalidadLocalizacion) && (filter.IdProyectoCalidadLocalizacion_To == null || o.IdProyectoCalidadLocalizacion <= filter.IdProyectoCalidadLocalizacion_To)
					  && (filter.IdProyectoCalidad == null || filter.IdProyectoCalidad == 0 || o.IdProyectoCalidad==filter.IdProyectoCalidad)
					  && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica==filter.IdClasificacionGeografica)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoCalidadLocalizacionResult> QueryResult(ProyectoCalidadLocalizacionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ClasificacionGeograficas on o.IdClasificacionGeografica equals t1.IdClasificacionGeografica   
				    join t2  in this.Context.ProyectoCalidads on o.IdProyectoCalidad equals t2.IdProyectoCalidad   
				   select new ProyectoCalidadLocalizacionResult(){
					 IdProyectoCalidadLocalizacion=o.IdProyectoCalidadLocalizacion
					 ,IdProyectoCalidad=o.IdProyectoCalidad
					 ,IdClasificacionGeografica=o.IdClasificacionGeografica
					,ClasificacionGeografica_Codigo= t1.Codigo	
						,ClasificacionGeografica_Nombre= t1.Nombre	
						,ClasificacionGeografica_IdClasificacionGeograficaTipo= t1.IdClasificacionGeograficaTipo	
						,ClasificacionGeografica_IdClasificacionGeograficaPadre= t1.IdClasificacionGeograficaPadre	
						,ClasificacionGeografica_Activo= t1.Activo	
						,ClasificacionGeografica_Descripcion= t1.Descripcion	
						,ClasificacionGeografica_BreadcrumbId= t1.BreadcrumbId	
						,ClasificacionGeografica_BreadcrumOrden= t1.BreadcrumOrden	
						,ClasificacionGeografica_Orden= t1.Orden	
						,ClasificacionGeografica_Nivel= t1.Nivel	
						,ClasificacionGeografica_DescripcionInvertida= t1.DescripcionInvertida	
						,ClasificacionGeografica_Seleccionable= t1.Seleccionable	
						,ClasificacionGeografica_BreadcrumbCode= t1.BreadcrumbCode	
						,ClasificacionGeografica_DescripcionCodigo= t1.DescripcionCodigo	
						,ProyectoCalidad_IdProyecto= t2.IdProyecto	
						,ProyectoCalidad_DenominacionOK= t2.DenominacionOK	
						,ProyectoCalidad_DenominacionSugerida= t2.DenominacionSugerida	
						,ProyectoCalidad_DenominacionOriginal= t2.DenominacionOriginal	
						,ProyectoCalidad_ProyectoTipoOk= t2.ProyectoTipoOk	
						,ProyectoCalidad_IdProyectoTipo= t2.IdProyectoTipo	
						,ProyectoCalidad_EstadoOK= t2.EstadoOK	
						,ProyectoCalidad_IdEstadoSugerido= t2.IdEstadoSugerido	
						,ProyectoCalidad_ProcesoOk= t2.ProcesoOk	
						,ProyectoCalidad_IdProceso= t2.IdProceso	
						,ProyectoCalidad_FinalidadFuncionOk= t2.FinalidadFuncionOk	
						,ProyectoCalidad_IdClasificacionFuncional= t2.IdClasificacionFuncional	
						,ProyectoCalidad_ReqDictamen= t2.ReqDictamen	
						,ProyectoCalidad_Comenatrio= t2.Comenatrio	
						,ProyectoCalidad_IdEstado= t2.IdEstado	
						,ProyectoCalidad_FechaEstado= t2.FechaEstado	
						,ProyectoCalidad_LocalizacionOK= t2.LocalizacionOK	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoCalidadLocalizacion Copy(nc.ProyectoCalidadLocalizacion entity)
        {           
            nc.ProyectoCalidadLocalizacion _new = new nc.ProyectoCalidadLocalizacion();
		 _new.IdProyectoCalidad= entity.IdProyectoCalidad;
		 _new.IdClasificacionGeografica= entity.IdClasificacionGeografica;
		return _new;			
        }
		public override int CopyAndSave(ProyectoCalidadLocalizacion entity,string renameFormat)
        {
            ProyectoCalidadLocalizacion  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoCalidadLocalizacion entity, int id)
        {            
            entity.IdProyectoCalidadLocalizacion = id;            
        }
		public override void Set(ProyectoCalidadLocalizacion source,ProyectoCalidadLocalizacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalidadLocalizacion= source.IdProyectoCalidadLocalizacion ;
		 target.IdProyectoCalidad= source.IdProyectoCalidad ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 		  
		}
		public override void Set(ProyectoCalidadLocalizacionResult source,ProyectoCalidadLocalizacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalidadLocalizacion= source.IdProyectoCalidadLocalizacion ;
		 target.IdProyectoCalidad= source.IdProyectoCalidad ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 
		}
		public override void Set(ProyectoCalidadLocalizacion source,ProyectoCalidadLocalizacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalidadLocalizacion= source.IdProyectoCalidadLocalizacion ;
		 target.IdProyectoCalidad= source.IdProyectoCalidad ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 	
		}		
		public override void Set(ProyectoCalidadLocalizacionResult source,ProyectoCalidadLocalizacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalidadLocalizacion= source.IdProyectoCalidadLocalizacion ;
		 target.IdProyectoCalidad= source.IdProyectoCalidad ;
		 target.IdClasificacionGeografica= source.IdClasificacionGeografica ;
		 target.ClasificacionGeografica_Codigo= source.ClasificacionGeografica_Codigo;	
			target.ClasificacionGeografica_Nombre= source.ClasificacionGeografica_Nombre;	
			target.ClasificacionGeografica_IdClasificacionGeograficaTipo= source.ClasificacionGeografica_IdClasificacionGeograficaTipo;	
			target.ClasificacionGeografica_IdClasificacionGeograficaPadre= source.ClasificacionGeografica_IdClasificacionGeograficaPadre;	
			target.ClasificacionGeografica_Activo= source.ClasificacionGeografica_Activo;	
			target.ClasificacionGeografica_Descripcion= source.ClasificacionGeografica_Descripcion;	
			target.ClasificacionGeografica_BreadcrumbId= source.ClasificacionGeografica_BreadcrumbId;	
			target.ClasificacionGeografica_BreadcrumOrden= source.ClasificacionGeografica_BreadcrumOrden;	
			target.ClasificacionGeografica_Orden= source.ClasificacionGeografica_Orden;	
			target.ClasificacionGeografica_Nivel= source.ClasificacionGeografica_Nivel;	
			target.ClasificacionGeografica_DescripcionInvertida= source.ClasificacionGeografica_DescripcionInvertida;	
			target.ClasificacionGeografica_Seleccionable= source.ClasificacionGeografica_Seleccionable;	
			target.ClasificacionGeografica_BreadcrumbCode= source.ClasificacionGeografica_BreadcrumbCode;	
			target.ClasificacionGeografica_DescripcionCodigo= source.ClasificacionGeografica_DescripcionCodigo;	
			target.ProyectoCalidad_IdProyecto= source.ProyectoCalidad_IdProyecto;	
			target.ProyectoCalidad_DenominacionOK= source.ProyectoCalidad_DenominacionOK;	
			target.ProyectoCalidad_DenominacionSugerida= source.ProyectoCalidad_DenominacionSugerida;	
			target.ProyectoCalidad_DenominacionOriginal= source.ProyectoCalidad_DenominacionOriginal;	
			target.ProyectoCalidad_ProyectoTipoOk= source.ProyectoCalidad_ProyectoTipoOk;	
			target.ProyectoCalidad_IdProyectoTipo= source.ProyectoCalidad_IdProyectoTipo;	
			target.ProyectoCalidad_EstadoOK= source.ProyectoCalidad_EstadoOK;	
			target.ProyectoCalidad_IdEstadoSugerido= source.ProyectoCalidad_IdEstadoSugerido;	
			target.ProyectoCalidad_ProcesoOk= source.ProyectoCalidad_ProcesoOk;	
			target.ProyectoCalidad_IdProceso= source.ProyectoCalidad_IdProceso;	
			target.ProyectoCalidad_FinalidadFuncionOk= source.ProyectoCalidad_FinalidadFuncionOk;	
			target.ProyectoCalidad_IdClasificacionFuncional= source.ProyectoCalidad_IdClasificacionFuncional;	
			target.ProyectoCalidad_ReqDictamen= source.ProyectoCalidad_ReqDictamen;	
			target.ProyectoCalidad_Comenatrio= source.ProyectoCalidad_Comenatrio;	
			target.ProyectoCalidad_IdEstado= source.ProyectoCalidad_IdEstado;	
			target.ProyectoCalidad_FechaEstado= source.ProyectoCalidad_FechaEstado;	
			target.ProyectoCalidad_LocalizacionOK= source.ProyectoCalidad_LocalizacionOK;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoCalidadLocalizacion source,ProyectoCalidadLocalizacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoCalidadLocalizacion.Equals(target.IdProyectoCalidadLocalizacion))return false;
		  if(!source.IdProyectoCalidad.Equals(target.IdProyectoCalidad))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoCalidadLocalizacionResult source,ProyectoCalidadLocalizacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoCalidadLocalizacion.Equals(target.IdProyectoCalidadLocalizacion))return false;
		  if(!source.IdProyectoCalidad.Equals(target.IdProyectoCalidad))return false;
		  if(!source.IdClasificacionGeografica.Equals(target.IdClasificacionGeografica))return false;
		  if((source.ClasificacionGeografica_Codigo == null)?target.ClasificacionGeografica_Codigo!=null: !( (target.ClasificacionGeografica_Codigo== String.Empty && source.ClasificacionGeografica_Codigo== null) || (target.ClasificacionGeografica_Codigo==null && source.ClasificacionGeografica_Codigo== String.Empty )) &&   !source.ClasificacionGeografica_Codigo.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_Nombre == null)?target.ClasificacionGeografica_Nombre!=null: !( (target.ClasificacionGeografica_Nombre== String.Empty && source.ClasificacionGeografica_Nombre== null) || (target.ClasificacionGeografica_Nombre==null && source.ClasificacionGeografica_Nombre== String.Empty )) &&   !source.ClasificacionGeografica_Nombre.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGeografica_IdClasificacionGeograficaTipo.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaTipo))return false;
					  if((source.ClasificacionGeografica_IdClasificacionGeograficaPadre == null)?(target.ClasificacionGeografica_IdClasificacionGeograficaPadre.HasValue && target.ClasificacionGeografica_IdClasificacionGeograficaPadre.Value > 0):!source.ClasificacionGeografica_IdClasificacionGeograficaPadre.Equals(target.ClasificacionGeografica_IdClasificacionGeograficaPadre))return false;
									  if(!source.ClasificacionGeografica_Activo.Equals(target.ClasificacionGeografica_Activo))return false;
					  if((source.ClasificacionGeografica_Descripcion == null)?target.ClasificacionGeografica_Descripcion!=null: !( (target.ClasificacionGeografica_Descripcion== String.Empty && source.ClasificacionGeografica_Descripcion== null) || (target.ClasificacionGeografica_Descripcion==null && source.ClasificacionGeografica_Descripcion== String.Empty )) &&   !source.ClasificacionGeografica_Descripcion.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_BreadcrumbId == null)?target.ClasificacionGeografica_BreadcrumbId!=null: !( (target.ClasificacionGeografica_BreadcrumbId== String.Empty && source.ClasificacionGeografica_BreadcrumbId== null) || (target.ClasificacionGeografica_BreadcrumbId==null && source.ClasificacionGeografica_BreadcrumbId== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumbId.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_BreadcrumOrden == null)?target.ClasificacionGeografica_BreadcrumOrden!=null: !( (target.ClasificacionGeografica_BreadcrumOrden== String.Empty && source.ClasificacionGeografica_BreadcrumOrden== null) || (target.ClasificacionGeografica_BreadcrumOrden==null && source.ClasificacionGeografica_BreadcrumOrden== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_Orden == null)?(target.ClasificacionGeografica_Orden.HasValue ):!source.ClasificacionGeografica_Orden.Equals(target.ClasificacionGeografica_Orden))return false;
						 if((source.ClasificacionGeografica_Nivel == null)?(target.ClasificacionGeografica_Nivel.HasValue ):!source.ClasificacionGeografica_Nivel.Equals(target.ClasificacionGeografica_Nivel))return false;
						 if((source.ClasificacionGeografica_DescripcionInvertida == null)?target.ClasificacionGeografica_DescripcionInvertida!=null: !( (target.ClasificacionGeografica_DescripcionInvertida== String.Empty && source.ClasificacionGeografica_DescripcionInvertida== null) || (target.ClasificacionGeografica_DescripcionInvertida==null && source.ClasificacionGeografica_DescripcionInvertida== String.Empty )) &&   !source.ClasificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionGeografica_Seleccionable.Equals(target.ClasificacionGeografica_Seleccionable))return false;
					  if((source.ClasificacionGeografica_BreadcrumbCode == null)?target.ClasificacionGeografica_BreadcrumbCode!=null: !( (target.ClasificacionGeografica_BreadcrumbCode== String.Empty && source.ClasificacionGeografica_BreadcrumbCode== null) || (target.ClasificacionGeografica_BreadcrumbCode==null && source.ClasificacionGeografica_BreadcrumbCode== String.Empty )) &&   !source.ClasificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionGeografica_DescripcionCodigo == null)?target.ClasificacionGeografica_DescripcionCodigo!=null: !( (target.ClasificacionGeografica_DescripcionCodigo== String.Empty && source.ClasificacionGeografica_DescripcionCodigo== null) || (target.ClasificacionGeografica_DescripcionCodigo==null && source.ClasificacionGeografica_DescripcionCodigo== String.Empty )) &&   !source.ClasificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.ClasificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoCalidad_IdProyecto.Equals(target.ProyectoCalidad_IdProyecto))return false;
					  if(!source.ProyectoCalidad_DenominacionOK.Equals(target.ProyectoCalidad_DenominacionOK))return false;
					  if((source.ProyectoCalidad_DenominacionSugerida == null)?target.ProyectoCalidad_DenominacionSugerida!=null: !( (target.ProyectoCalidad_DenominacionSugerida== String.Empty && source.ProyectoCalidad_DenominacionSugerida== null) || (target.ProyectoCalidad_DenominacionSugerida==null && source.ProyectoCalidad_DenominacionSugerida== String.Empty )) &&   !source.ProyectoCalidad_DenominacionSugerida.Trim().Replace ("\r","").Equals(target.ProyectoCalidad_DenominacionSugerida.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoCalidad_DenominacionOriginal == null)?target.ProyectoCalidad_DenominacionOriginal!=null: !( (target.ProyectoCalidad_DenominacionOriginal== String.Empty && source.ProyectoCalidad_DenominacionOriginal== null) || (target.ProyectoCalidad_DenominacionOriginal==null && source.ProyectoCalidad_DenominacionOriginal== String.Empty )) &&   !source.ProyectoCalidad_DenominacionOriginal.Trim().Replace ("\r","").Equals(target.ProyectoCalidad_DenominacionOriginal.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoCalidad_ProyectoTipoOk.Equals(target.ProyectoCalidad_ProyectoTipoOk))return false;
					  if((source.ProyectoCalidad_IdProyectoTipo == null)?(target.ProyectoCalidad_IdProyectoTipo.HasValue && target.ProyectoCalidad_IdProyectoTipo.Value > 0):!source.ProyectoCalidad_IdProyectoTipo.Equals(target.ProyectoCalidad_IdProyectoTipo))return false;
									  if((source.ProyectoCalidad_EstadoOK == null)?(target.ProyectoCalidad_EstadoOK.HasValue ):!source.ProyectoCalidad_EstadoOK.Equals(target.ProyectoCalidad_EstadoOK))return false;
						 if((source.ProyectoCalidad_IdEstadoSugerido == null)?(target.ProyectoCalidad_IdEstadoSugerido.HasValue ):!source.ProyectoCalidad_IdEstadoSugerido.Equals(target.ProyectoCalidad_IdEstadoSugerido))return false;
						 if(!source.ProyectoCalidad_ProcesoOk.Equals(target.ProyectoCalidad_ProcesoOk))return false;
					  if((source.ProyectoCalidad_IdProceso == null)?(target.ProyectoCalidad_IdProceso.HasValue && target.ProyectoCalidad_IdProceso.Value > 0):!source.ProyectoCalidad_IdProceso.Equals(target.ProyectoCalidad_IdProceso))return false;
									  if(!source.ProyectoCalidad_FinalidadFuncionOk.Equals(target.ProyectoCalidad_FinalidadFuncionOk))return false;
					  if((source.ProyectoCalidad_IdClasificacionFuncional == null)?(target.ProyectoCalidad_IdClasificacionFuncional.HasValue && target.ProyectoCalidad_IdClasificacionFuncional.Value > 0):!source.ProyectoCalidad_IdClasificacionFuncional.Equals(target.ProyectoCalidad_IdClasificacionFuncional))return false;
									  if(!source.ProyectoCalidad_ReqDictamen.Equals(target.ProyectoCalidad_ReqDictamen))return false;
					  if((source.ProyectoCalidad_Comenatrio == null)?target.ProyectoCalidad_Comenatrio!=null: !( (target.ProyectoCalidad_Comenatrio== String.Empty && source.ProyectoCalidad_Comenatrio== null) || (target.ProyectoCalidad_Comenatrio==null && source.ProyectoCalidad_Comenatrio== String.Empty )) &&   !source.ProyectoCalidad_Comenatrio.Trim().Replace ("\r","").Equals(target.ProyectoCalidad_Comenatrio.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoCalidad_IdEstado.Equals(target.ProyectoCalidad_IdEstado))return false;
					  if((source.ProyectoCalidad_FechaEstado == null)?(target.ProyectoCalidad_FechaEstado.HasValue ):!source.ProyectoCalidad_FechaEstado.Equals(target.ProyectoCalidad_FechaEstado))return false;
						 if(!source.ProyectoCalidad_LocalizacionOK.Equals(target.ProyectoCalidad_LocalizacionOK))return false;
					 		
		  return true;
        }
		#endregion
    }
}
