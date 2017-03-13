using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoSeguimientoLocalizacionData : _ProyectoSeguimientoLocalizacionData 
    { 
	   #region Singleton
	   private static volatile ProyectoSeguimientoLocalizacionData current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoLocalizacionData() {}
	   public static ProyectoSeguimientoLocalizacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoLocalizacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoSeguimientoLocalizacion"; } }

       protected override IQueryable<ProyectoSeguimientoLocalizacionResult> QueryResult(ProyectoSeguimientoLocalizacionFilter filter)
       {
           return 
               (
                    from o in base.QueryResult(filter)
                    where
                    (
                        (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 )
                        && (filter.IdProyecto == null || filter.IdProyecto == 0 )
                        && (filter.IdsProyectoSeguimiento == null || filter.IdsProyectoSeguimiento.Count == 0 )
                    )
                    ||
                    (from proyectoSeguimiento in this.Context.ProyectoSeguimientos 
                        //on
                        //    o.IdProyectoSeguimiento equals _proyectoSeguimiento.IdProyectoSeguimiento 
                        //into tproyectoSeguimiento from proyectoSeguimiento in tproyectoSeguimiento.DefaultIfEmpty()
                        join _proyectoDictamenSeguimiento in this.Context.ProyectoDictamenSeguimientos 
                        on
                            proyectoSeguimiento.IdProyectoSeguimiento equals _proyectoDictamenSeguimiento.IdProyectoSeguimiento
                        into tproyectoDictamenSeguimiento from proyectoDictamenSeguimiento in tproyectoDictamenSeguimiento.DefaultIfEmpty()
                        join _psp in this.Context.ProyectoSeguimientoProyectos on proyectoSeguimiento.IdProyectoSeguimiento equals _psp.IdProyectoSeguimiento
                        into tpsp from psp in tpsp.DefaultIfEmpty()
                        where
                            (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || filter.IdProyectoDictamen == proyectoDictamenSeguimiento.IdProyectoDictamen )
                            && (filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == psp.IdProyecto )
                            && (filter.IdsProyectoSeguimiento == null || filter.IdsProyectoSeguimiento.Count  == 0 || filter.IdsProyectoSeguimiento.Contains ( o.IdProyectoSeguimiento ))
                        select proyectoSeguimiento.IdProyectoSeguimiento 
                    ).Contains ( o.IdProyectoSeguimiento ) 
                    select new ProyectoSeguimientoLocalizacionResult(){
					 IdProyectoSeguimientoLocalizacion=o.IdProyectoSeguimientoLocalizacion
					 ,IdProyectoSeguimiento=o.IdProyectoSeguimiento
					 ,IdCalificacionGeografica=o.IdCalificacionGeografica
					,CalificacionGeografica_Codigo= o.CalificacionGeografica_Codigo	
						,CalificacionGeografica_Nombre= o.CalificacionGeografica_Nombre	
						,CalificacionGeografica_IdClasificacionGeograficaTipo= o.CalificacionGeografica_IdClasificacionGeograficaTipo	
						,CalificacionGeografica_IdClasificacionGeograficaPadre= o.CalificacionGeografica_IdClasificacionGeograficaPadre	
						,CalificacionGeografica_Activo= o.CalificacionGeografica_Activo	
						,CalificacionGeografica_Descripcion= o.CalificacionGeografica_Descripcion	
						,CalificacionGeografica_BreadcrumbId= o.CalificacionGeografica_BreadcrumbId	
						,CalificacionGeografica_BreadcrumOrden= o.CalificacionGeografica_BreadcrumOrden	
						,CalificacionGeografica_Orden= o.CalificacionGeografica_Orden	
						,CalificacionGeografica_Nivel= o.CalificacionGeografica_Nivel	
						,CalificacionGeografica_DescripcionInvertida= o.CalificacionGeografica_DescripcionInvertida	
						,CalificacionGeografica_Seleccionable= o.CalificacionGeografica_Seleccionable	
						,CalificacionGeografica_BreadcrumbCode= o.CalificacionGeografica_BreadcrumbCode	
						,CalificacionGeografica_DescripcionCodigo= o.CalificacionGeografica_DescripcionCodigo	
						,ProyectoSeguimiento_IdSaf= o.ProyectoSeguimiento_IdSaf	
						,ProyectoSeguimiento_Denominacion= o.ProyectoSeguimiento_Denominacion	
						,ProyectoSeguimiento_Ruta= o.ProyectoSeguimiento_Ruta	
						,ProyectoSeguimiento_Malla= o.ProyectoSeguimiento_Malla	
						,ProyectoSeguimiento_IdAnalista= o.ProyectoSeguimiento_IdAnalista	
						,ProyectoSeguimiento_IdProyectoSeguimientoAnterior= o.ProyectoSeguimiento_IdProyectoSeguimientoAnterior
	                    ,Selected = true 
						}
               ).AsQueryable ();
       }
        public override bool Equals(ProyectoSeguimientoLocalizacionResult source,ProyectoSeguimientoLocalizacionResult target)
        {
            return (base.Equals(source,target) && source.Selected == target.Selected);
        }
    }
}
