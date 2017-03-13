using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoDictamenEstadoData : _ProyectoDictamenEstadoData 
    { 
	   #region Singleton
	   private static volatile ProyectoDictamenEstadoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoDictamenEstadoData() {}
	   public static ProyectoDictamenEstadoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDictamenEstadoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoDictamenEstado"; } }
       protected override IQueryable<ProyectoDictamenEstadoResult> QueryResult(ProyectoDictamenEstadoFilter filter)
        {
		  return (from o in base.QueryResult(filter)
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
                       join _proyectoDictamenSeguimiento in this.Context.ProyectoDictamenSeguimientos on proyectoSeguimiento.IdProyectoSeguimiento equals _proyectoDictamenSeguimiento.IdProyectoSeguimiento into tproyectoDictamenSeguimiento from proyectoDictamenSeguimiento in tproyectoDictamenSeguimiento.DefaultIfEmpty()
                        join _psp in this.Context.ProyectoSeguimientoProyectos on proyectoDictamenSeguimiento.IdProyectoSeguimiento equals _psp.IdProyectoSeguimiento
                        into tpsp from psp in tpsp.DefaultIfEmpty()
                        where
                            (filter.IdProyectoDictamen == null || filter.IdProyectoDictamen == 0 || filter.IdProyectoDictamen == proyectoDictamenSeguimiento.IdProyectoDictamen)
                            && ( filter.IdProyecto == null || filter.IdProyecto == 0 || filter.IdProyecto == psp.IdProyecto )
                       select proyectoDictamenSeguimiento.IdProyectoDictamen 
                    ).Contains ( o.IdProyectoDictamen)
                )
				   select new ProyectoDictamenEstadoResult(){
					    IdProyectoDictamenEstado=o.IdProyectoDictamenEstado
					    ,IdProyectoDictamen=o.IdProyectoDictamen
					    ,IdEstado=o.IdEstado
					    ,Fecha=o.Fecha
					    ,Observacion=o.Observacion
					    ,IdUsuario=o.IdUsuario
					    ,Estado_Nombre= o.Estado_Nombre	
					    ,Estado_Codigo= o.Estado_Codigo	
					    ,Estado_Orden= o.Estado_Orden
					    ,Estado_Descripcion= o.Estado_Descripcion	
					    ,Estado_Activo= o.Estado_Activo	
					    ,ProyectoDictamen_IdProyectoCalificacion= o.ProyectoDictamen_IdProyectoCalificacion	
					    ,ProyectoDictamen_Fecha= o.ProyectoDictamen_Fecha	
					    ,ProyectoDictamen_FechaVencimiento= o.ProyectoDictamen_FechaVencimiento	
					    ,ProyectoDictamen_IdPlanPeriodo= o.ProyectoDictamen_IdPlanPeriodo	
					    ,ProyectoDictamen_Monto= o.ProyectoDictamen_Monto	
					    ,ProyectoDictamen_Ejercicio= o.ProyectoDictamen_Ejercicio	
					    ,ProyectoDictamen_DuracionMeses= o.ProyectoDictamen_DuracionMeses	
					    ,ProyectoDictamen_InformeTecnico= o.ProyectoDictamen_InformeTecnico	
					    ,ProyectoDictamen_FechaComiteTecnico= o.ProyectoDictamen_FechaComiteTecnico	
					    ,ProyectoDictamen_Observacion= o.ProyectoDictamen_Observacion	
					    ,ProyectoDictamen_Recomendacion= o.ProyectoDictamen_Recomendacion	
					    ,ProyectoDictamen_RespuestaOrganismo= o.ProyectoDictamen_RespuestaOrganismo	
					    ,ProyectoDictamen_FechaRepuesta= o.ProyectoDictamen_FechaRepuesta	
					    ,ProyectoDictamen_FechaEstado= o.ProyectoDictamen_FechaEstado	
					    ,ProyectoDictamen_Numero= o.ProyectoDictamen_Numero	
					    ,ProyectoDictamen_Denominacion= o.ProyectoDictamen_Denominacion	
					    ,ProyectoDictamen_IdProyectoDictamenEstadoUltimo= o.ProyectoDictamen_IdProyectoDictamenEstadoUltimo	
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
        }
    }
}
