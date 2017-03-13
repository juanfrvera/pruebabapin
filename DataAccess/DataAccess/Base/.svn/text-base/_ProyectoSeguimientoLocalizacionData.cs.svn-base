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
    public abstract class _ProyectoSeguimientoLocalizacionData : EntityData<ProyectoSeguimientoLocalizacion,ProyectoSeguimientoLocalizacionFilter,ProyectoSeguimientoLocalizacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoSeguimientoLocalizacion entity)
		{			
			return entity.IdProyectoSeguimientoLocalizacion;
		}		
		public override ProyectoSeguimientoLocalizacion GetByEntity(ProyectoSeguimientoLocalizacion entity)
        {
            return this.GetById(entity.IdProyectoSeguimientoLocalizacion);
        }
        public override ProyectoSeguimientoLocalizacion GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoSeguimientoLocalizacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoSeguimientoLocalizacion> Query(ProyectoSeguimientoLocalizacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoSeguimientoLocalizacion == null || o.IdProyectoSeguimientoLocalizacion >=  filter.IdProyectoSeguimientoLocalizacion) && (filter.IdProyectoSeguimientoLocalizacion_To == null || o.IdProyectoSeguimientoLocalizacion <= filter.IdProyectoSeguimientoLocalizacion_To)
					  && (filter.IdProyectoSeguimiento == null || filter.IdProyectoSeguimiento == 0 || o.IdProyectoSeguimiento==filter.IdProyectoSeguimiento)
					  && (filter.IdCalificacionGeografica == null || filter.IdCalificacionGeografica == 0 || o.IdCalificacionGeografica==filter.IdCalificacionGeografica)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoSeguimientoLocalizacionResult> QueryResult(ProyectoSeguimientoLocalizacionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ClasificacionGeograficas on o.IdCalificacionGeografica equals t1.IdClasificacionGeografica   
				    join t2  in this.Context.ProyectoSeguimientos on o.IdProyectoSeguimiento equals t2.IdProyectoSeguimiento   
				   select new ProyectoSeguimientoLocalizacionResult(){
					 IdProyectoSeguimientoLocalizacion=o.IdProyectoSeguimientoLocalizacion
					 ,IdProyectoSeguimiento=o.IdProyectoSeguimiento
					 ,IdCalificacionGeografica=o.IdCalificacionGeografica
					,CalificacionGeografica_Codigo= t1.Codigo	
						,CalificacionGeografica_Nombre= t1.Nombre	
						,CalificacionGeografica_IdClasificacionGeograficaTipo= t1.IdClasificacionGeograficaTipo	
						,CalificacionGeografica_IdClasificacionGeograficaPadre= t1.IdClasificacionGeograficaPadre	
						,CalificacionGeografica_Activo= t1.Activo	
						,CalificacionGeografica_Descripcion= t1.Descripcion	
						,CalificacionGeografica_BreadcrumbId= t1.BreadcrumbId	
						,CalificacionGeografica_BreadcrumOrden= t1.BreadcrumOrden	
						,CalificacionGeografica_Orden= t1.Orden	
						,CalificacionGeografica_Nivel= t1.Nivel	
						,CalificacionGeografica_DescripcionInvertida= t1.DescripcionInvertida	
						,CalificacionGeografica_Seleccionable= t1.Seleccionable	
						,CalificacionGeografica_BreadcrumbCode= t1.BreadcrumbCode	
						,CalificacionGeografica_DescripcionCodigo= t1.DescripcionCodigo	
						,ProyectoSeguimiento_IdSaf= t2.IdSaf	
						,ProyectoSeguimiento_Denominacion= t2.Denominacion	
						,ProyectoSeguimiento_Ruta= t2.Ruta	
						,ProyectoSeguimiento_Malla= t2.Malla	
						,ProyectoSeguimiento_IdAnalista= t2.IdAnalista	
						,ProyectoSeguimiento_IdProyectoSeguimientoAnterior= t2.IdProyectoSeguimientoAnterior	
						//,ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo= t2.IdProyectoSeguimientoEstadoUltimo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoSeguimientoLocalizacion Copy(nc.ProyectoSeguimientoLocalizacion entity)
        {           
            nc.ProyectoSeguimientoLocalizacion _new = new nc.ProyectoSeguimientoLocalizacion();
		 _new.IdProyectoSeguimiento= entity.IdProyectoSeguimiento;
		 _new.IdCalificacionGeografica= entity.IdCalificacionGeografica;
		return _new;			
        }
		public override int CopyAndSave(ProyectoSeguimientoLocalizacion entity,string renameFormat)
        {
            ProyectoSeguimientoLocalizacion  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoSeguimientoLocalizacion entity, int id)
        {            
            entity.IdProyectoSeguimientoLocalizacion = id;            
        }
		public override void Set(ProyectoSeguimientoLocalizacion source,ProyectoSeguimientoLocalizacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoLocalizacion= source.IdProyectoSeguimientoLocalizacion ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdCalificacionGeografica= source.IdCalificacionGeografica ;
		 		  
		}
		public override void Set(ProyectoSeguimientoLocalizacionResult source,ProyectoSeguimientoLocalizacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoLocalizacion= source.IdProyectoSeguimientoLocalizacion ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdCalificacionGeografica= source.IdCalificacionGeografica ;
		 
		}
		public override void Set(ProyectoSeguimientoLocalizacion source,ProyectoSeguimientoLocalizacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoLocalizacion= source.IdProyectoSeguimientoLocalizacion ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdCalificacionGeografica= source.IdCalificacionGeografica ;
		 	
		}		
		public override void Set(ProyectoSeguimientoLocalizacionResult source,ProyectoSeguimientoLocalizacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoSeguimientoLocalizacion= source.IdProyectoSeguimientoLocalizacion ;
		 target.IdProyectoSeguimiento= source.IdProyectoSeguimiento ;
		 target.IdCalificacionGeografica= source.IdCalificacionGeografica ;
		 target.CalificacionGeografica_Codigo= source.CalificacionGeografica_Codigo;	
			target.CalificacionGeografica_Nombre= source.CalificacionGeografica_Nombre;	
			target.CalificacionGeografica_IdClasificacionGeograficaTipo= source.CalificacionGeografica_IdClasificacionGeograficaTipo;	
			target.CalificacionGeografica_IdClasificacionGeograficaPadre= source.CalificacionGeografica_IdClasificacionGeograficaPadre;	
			target.CalificacionGeografica_Activo= source.CalificacionGeografica_Activo;	
			target.CalificacionGeografica_Descripcion= source.CalificacionGeografica_Descripcion;	
			target.CalificacionGeografica_BreadcrumbId= source.CalificacionGeografica_BreadcrumbId;	
			target.CalificacionGeografica_BreadcrumOrden= source.CalificacionGeografica_BreadcrumOrden;	
			target.CalificacionGeografica_Orden= source.CalificacionGeografica_Orden;	
			target.CalificacionGeografica_Nivel= source.CalificacionGeografica_Nivel;	
			target.CalificacionGeografica_DescripcionInvertida= source.CalificacionGeografica_DescripcionInvertida;	
			target.CalificacionGeografica_Seleccionable= source.CalificacionGeografica_Seleccionable;	
			target.CalificacionGeografica_BreadcrumbCode= source.CalificacionGeografica_BreadcrumbCode;	
			target.CalificacionGeografica_DescripcionCodigo= source.CalificacionGeografica_DescripcionCodigo;	
			target.ProyectoSeguimiento_IdSaf= source.ProyectoSeguimiento_IdSaf;	
			target.ProyectoSeguimiento_Denominacion= source.ProyectoSeguimiento_Denominacion;	
			target.ProyectoSeguimiento_Ruta= source.ProyectoSeguimiento_Ruta;	
			target.ProyectoSeguimiento_Malla= source.ProyectoSeguimiento_Malla;	
			target.ProyectoSeguimiento_IdAnalista= source.ProyectoSeguimiento_IdAnalista;	
			target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior= source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior;	
			//target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo= source.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoSeguimientoLocalizacion source,ProyectoSeguimientoLocalizacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoSeguimientoLocalizacion.Equals(target.IdProyectoSeguimientoLocalizacion))return false;
		  if(!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento))return false;
		  if(!source.IdCalificacionGeografica.Equals(target.IdCalificacionGeografica))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoSeguimientoLocalizacionResult source,ProyectoSeguimientoLocalizacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoSeguimientoLocalizacion.Equals(target.IdProyectoSeguimientoLocalizacion))return false;
		  if(!source.IdProyectoSeguimiento.Equals(target.IdProyectoSeguimiento))return false;
		  if(!source.IdCalificacionGeografica.Equals(target.IdCalificacionGeografica))return false;
		  if((source.CalificacionGeografica_Codigo == null)?target.CalificacionGeografica_Codigo!=null: !( (target.CalificacionGeografica_Codigo== String.Empty && source.CalificacionGeografica_Codigo== null) || (target.CalificacionGeografica_Codigo==null && source.CalificacionGeografica_Codigo== String.Empty )) &&   !source.CalificacionGeografica_Codigo.Trim().Replace ("\r","").Equals(target.CalificacionGeografica_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.CalificacionGeografica_Nombre == null)?target.CalificacionGeografica_Nombre!=null: !( (target.CalificacionGeografica_Nombre== String.Empty && source.CalificacionGeografica_Nombre== null) || (target.CalificacionGeografica_Nombre==null && source.CalificacionGeografica_Nombre== String.Empty )) &&   !source.CalificacionGeografica_Nombre.Trim().Replace ("\r","").Equals(target.CalificacionGeografica_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.CalificacionGeografica_IdClasificacionGeograficaTipo.Equals(target.CalificacionGeografica_IdClasificacionGeograficaTipo))return false;
					  if((source.CalificacionGeografica_IdClasificacionGeograficaPadre == null)?(target.CalificacionGeografica_IdClasificacionGeograficaPadre.HasValue && target.CalificacionGeografica_IdClasificacionGeograficaPadre.Value > 0):!source.CalificacionGeografica_IdClasificacionGeograficaPadre.Equals(target.CalificacionGeografica_IdClasificacionGeograficaPadre))return false;
									  if(!source.CalificacionGeografica_Activo.Equals(target.CalificacionGeografica_Activo))return false;
					  if((source.CalificacionGeografica_Descripcion == null)?target.CalificacionGeografica_Descripcion!=null: !( (target.CalificacionGeografica_Descripcion== String.Empty && source.CalificacionGeografica_Descripcion== null) || (target.CalificacionGeografica_Descripcion==null && source.CalificacionGeografica_Descripcion== String.Empty )) &&   !source.CalificacionGeografica_Descripcion.Trim().Replace ("\r","").Equals(target.CalificacionGeografica_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.CalificacionGeografica_BreadcrumbId == null)?target.CalificacionGeografica_BreadcrumbId!=null: !( (target.CalificacionGeografica_BreadcrumbId== String.Empty && source.CalificacionGeografica_BreadcrumbId== null) || (target.CalificacionGeografica_BreadcrumbId==null && source.CalificacionGeografica_BreadcrumbId== String.Empty )) &&   !source.CalificacionGeografica_BreadcrumbId.Trim().Replace ("\r","").Equals(target.CalificacionGeografica_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.CalificacionGeografica_BreadcrumOrden == null)?target.CalificacionGeografica_BreadcrumOrden!=null: !( (target.CalificacionGeografica_BreadcrumOrden== String.Empty && source.CalificacionGeografica_BreadcrumOrden== null) || (target.CalificacionGeografica_BreadcrumOrden==null && source.CalificacionGeografica_BreadcrumOrden== String.Empty )) &&   !source.CalificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","").Equals(target.CalificacionGeografica_BreadcrumOrden.Trim().Replace ("\r","")))return false;
						 if((source.CalificacionGeografica_Orden == null)?(target.CalificacionGeografica_Orden.HasValue ):!source.CalificacionGeografica_Orden.Equals(target.CalificacionGeografica_Orden))return false;
						 if((source.CalificacionGeografica_Nivel == null)?(target.CalificacionGeografica_Nivel.HasValue ):!source.CalificacionGeografica_Nivel.Equals(target.CalificacionGeografica_Nivel))return false;
						 if((source.CalificacionGeografica_DescripcionInvertida == null)?target.CalificacionGeografica_DescripcionInvertida!=null: !( (target.CalificacionGeografica_DescripcionInvertida== String.Empty && source.CalificacionGeografica_DescripcionInvertida== null) || (target.CalificacionGeografica_DescripcionInvertida==null && source.CalificacionGeografica_DescripcionInvertida== String.Empty )) &&   !source.CalificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.CalificacionGeografica_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.CalificacionGeografica_Seleccionable.Equals(target.CalificacionGeografica_Seleccionable))return false;
					  if((source.CalificacionGeografica_BreadcrumbCode == null)?target.CalificacionGeografica_BreadcrumbCode!=null: !( (target.CalificacionGeografica_BreadcrumbCode== String.Empty && source.CalificacionGeografica_BreadcrumbCode== null) || (target.CalificacionGeografica_BreadcrumbCode==null && source.CalificacionGeografica_BreadcrumbCode== String.Empty )) &&   !source.CalificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.CalificacionGeografica_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.CalificacionGeografica_DescripcionCodigo == null)?target.CalificacionGeografica_DescripcionCodigo!=null: !( (target.CalificacionGeografica_DescripcionCodigo== String.Empty && source.CalificacionGeografica_DescripcionCodigo== null) || (target.CalificacionGeografica_DescripcionCodigo==null && source.CalificacionGeografica_DescripcionCodigo== String.Empty )) &&   !source.CalificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.CalificacionGeografica_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoSeguimiento_IdSaf.Equals(target.ProyectoSeguimiento_IdSaf))return false;
					  if((source.ProyectoSeguimiento_Denominacion == null)?target.ProyectoSeguimiento_Denominacion!=null: !( (target.ProyectoSeguimiento_Denominacion== String.Empty && source.ProyectoSeguimiento_Denominacion== null) || (target.ProyectoSeguimiento_Denominacion==null && source.ProyectoSeguimiento_Denominacion== String.Empty )) &&   !source.ProyectoSeguimiento_Denominacion.Trim().Replace ("\r","").Equals(target.ProyectoSeguimiento_Denominacion.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoSeguimiento_Ruta == null)?target.ProyectoSeguimiento_Ruta!=null: !( (target.ProyectoSeguimiento_Ruta== String.Empty && source.ProyectoSeguimiento_Ruta== null) || (target.ProyectoSeguimiento_Ruta==null && source.ProyectoSeguimiento_Ruta== String.Empty )) &&   !source.ProyectoSeguimiento_Ruta.Trim().Replace ("\r","").Equals(target.ProyectoSeguimiento_Ruta.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoSeguimiento_Malla == null)?target.ProyectoSeguimiento_Malla!=null: !( (target.ProyectoSeguimiento_Malla== String.Empty && source.ProyectoSeguimiento_Malla== null) || (target.ProyectoSeguimiento_Malla==null && source.ProyectoSeguimiento_Malla== String.Empty )) &&   !source.ProyectoSeguimiento_Malla.Trim().Replace ("\r","").Equals(target.ProyectoSeguimiento_Malla.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoSeguimiento_IdAnalista.Equals(target.ProyectoSeguimiento_IdAnalista))return false;
					  if((source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior == null)?(target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.HasValue && target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.Value > 0):!source.ProyectoSeguimiento_IdProyectoSeguimientoAnterior.Equals(target.ProyectoSeguimiento_IdProyectoSeguimientoAnterior))return false;
									//  if((source.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo == null)?(target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo.HasValue && target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo.Value > 0):!source.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo.Equals(target.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo))return false;
									 		
		  return true;
        }
		#endregion
    }
}
