using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoSeguimientoEstadoData : _ProyectoSeguimientoEstadoData 
    { 
	   #region Singleton
	   private static volatile ProyectoSeguimientoEstadoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoEstadoData() {}
	   public static ProyectoSeguimientoEstadoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoEstadoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoSeguimientoEstado"; } }

       protected override IQueryable<ProyectoSeguimientoEstadoResult> QueryResult(ProyectoSeguimientoEstadoFilter filter)
       {
           var query = (
                from o in base.QueryResult(filter)
                join p in this.Context.Personas on o.IdUsuario equals p.IdPersona 
                where 
                (
                    (
                        (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 )
                        &&
                        ( filter.IdProyecto == null || filter.IdProyecto == 0 )
                    )
                    ||
                    (
                       from proyectoSeguimiento in this.Context.ProyectoSeguimientos
                       //on o.IdProyectoSeguimiento equals _proyectoSeguimiento.IdProyectoSeguimiento
                       //into tproyectoSeguimiento from proyectoSeguimiento in tproyectoSeguimiento.DefaultIfEmpty()
                        join _proyectoDictamenSeguimiento in this.Context.ProyectoDictamenSeguimientos
                            on proyectoSeguimiento.IdProyectoSeguimiento equals _proyectoDictamenSeguimiento.IdProyectoSeguimiento
                        into tproyectoDictamenSeguimiento from proyectoDictamenSeguimiento in tproyectoDictamenSeguimiento.DefaultIfEmpty()
                        join _psp in this.Context.ProyectoSeguimientoProyectos on proyectoDictamenSeguimiento.IdProyectoSeguimiento equals _psp.IdProyectoSeguimiento
                        into tpsp from psp in tpsp.DefaultIfEmpty()
                        where
                            (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || filter.IdProyectoDictamen == proyectoDictamenSeguimiento.IdProyectoDictamen)
                            && ( filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == psp.IdProyecto ) 
                        select proyectoSeguimiento.IdProyectoSeguimiento 
                    ).Contains ( o.IdProyectoSeguimiento )
                )
                   select new ProyectoSeguimientoEstadoResult(){
                      IdProyectoSeguimientoEstado = o.IdProyectoSeguimientoEstado
					 ,IdProyectoSeguimiento=o.IdProyectoSeguimiento
					 ,IdEstado=o.IdEstado
					 ,Fecha=o.Fecha
					 ,Observacion=o.Observacion
					 ,IdUsuario=o.IdUsuario
                     ,GeneraComentarioTecnico = o.GeneraComentarioTecnico
					,Estado_Nombre= o.Estado_Nombre	
						,Estado_Codigo= o.Estado_Codigo	
						,Estado_Orden= o.Estado_Orden	
						,Estado_Descripcion= o.Estado_Descripcion	
						,Estado_Activo= o.Estado_Activo	
						,ProyectoSeguimiento_IdSaf= o.ProyectoSeguimiento_IdSaf	
						,ProyectoSeguimiento_Denominacion= o.ProyectoSeguimiento_Denominacion	
						,ProyectoSeguimiento_Ruta= o.ProyectoSeguimiento_Ruta	
						,ProyectoSeguimiento_Malla= o.ProyectoSeguimiento_Malla	
						,ProyectoSeguimiento_IdAnalista= o.ProyectoSeguimiento_IdAnalista	
						,ProyectoSeguimiento_IdProyectoSeguimientoAnterior= o.ProyectoSeguimiento_IdProyectoSeguimientoAnterior	
						,ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo= o.ProyectoSeguimiento_IdProyectoSeguimientoEstadoUltimo	
						,Usuario_NombreUsuario= o.Usuario_NombreUsuario	
						,Usuario_Clave= o.Usuario_Clave	
						,Usuario_Activo= o.Usuario_Activo	
						,Usuario_EsSectioralista= o.Usuario_EsSectioralista	
						,Usuario_IdLanguage= o.Usuario_IdLanguage	
						,Usuario_AccesoTotal= o.Usuario_AccesoTotal	
                        ,Persona_Apellido = p.Apellido 
                        ,Persona_Nombre = p.Nombre 
						}
                
                
                ).AsQueryable();
           return query;
       }
    }
    
}
