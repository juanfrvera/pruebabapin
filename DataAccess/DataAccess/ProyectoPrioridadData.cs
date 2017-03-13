using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoPrioridadData : _ProyectoPrioridadData 
    { 
	   #region Singleton
	   private static volatile ProyectoPrioridadData current;
	   private static object syncRoot = new Object();

	   //private ProyectoPrioridadData() {}
	   public static ProyectoPrioridadData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPrioridadData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoPrioridad"; } }

       public ProyectoPrioridadResult GetUltimaPrioridad(Int32 idProyecto)
       {
           ProyectoPrioridadResult result = new ProyectoPrioridadResult();

           List<ProyectoPrioridadResult> priors= (from p in Context.Proyectos
                                                  join pl in Context.ProyectoPlans on p.IdProyectoPlan equals pl.IdProyectoPlan
                                                  join pp in Context.ProyectoPrioridads on pl.IdPlanPeriodo equals pp.IdPlanPeriodo
                                                  where p.IdProyecto == idProyecto && pp.IdProyecto == p.IdProyecto
                                                  select new ProyectoPrioridadResult()
                                                  {
                                                      IdProyectoPrioridad = pp.IdProyectoPrioridad, 
                                                      IdProyecto = pp.IdProyecto,
                                                      IdPlanPeriodo = pp.IdPlanPeriodo,
                                                      IdPrioridad = pp.IdPrioridad,
                                                      Puntaje = pp.Puntaje,
                                                      ReqArt15 = pp.ReqArt15,
                                                      IdClasificacion = pp.IdClasificacion,
                                                      Comentario = pp.Comentario,
                                                      PrioridadAsignada = pp.PrioridadAsignada,
                                                      ConfRequerimientos = pp.ConfRequerimientos
                                                  }).ToList();
           if (priors.Count > 0)
           {
               result = priors[0];
           }

           if (!result.PrioridadAsignada)
           {
               #region Obtiene la prioridad original

               var oris = (from p in Context.Proyectos
                           from t in Context.TablaCalculoPrioridades
                           from d in Context.Prioridads
                           where p.IdProyecto == idProyecto
                              && p.IdProceso == t.IdProceso
                              && p.IdEstado == t.IdEstado
                              && p.IdTipoProyecto == t.IdTipoProyecto
                              && t.IdPrioridad == d.IdPrioridad
                           orderby t.IdEstado, t.IdProceso descending
                           select new
                           {
                               idPrioridadActual = d.IdPrioridad,
                               prioridadActual = d.Nombre
                           }).ToList();

               result.IdPrioridadCalculadoOriginal = oris.Count > 0 ? oris[0].idPrioridadActual : 0;
               result.PrioridadCalculadoOriginal = oris.Count > 0 ? oris[0].prioridadActual : "";

               #endregion Obtiene la prioridad original

               #region Obtiene la prioridad asignada

               var asig = (from p in Context.ProyectoCalidads
                           from t in Context.TablaCalculoPrioridades
                           from d in Context.Prioridads
                           where p.IdProyecto == idProyecto
                              && p.IdProceso == t.IdProceso
                              && p.IdEstadoSugerido == t.IdEstado
                              && p.IdProyectoTipo == t.IdTipoProyecto
                              && t.IdPrioridad == d.IdPrioridad
                           select new
                           {
                               idPrioridadSugerida = d.IdPrioridad,
                               prioridadSugerida = d.Nombre
                           }).ToList();

               result.IdPrioridadCalculadoAsignada = asig.Count > 0 ? asig[0].idPrioridadSugerida : 0;
               result.PrioridadCalculadoAsignada = asig.Count > 0 ? asig[0].prioridadSugerida : "";

               #endregion Obtiene la prioridad asignada
           }
                      
           #region Obtiene Puntaje
           result.AplicarPrioridad = result.IdPrioridadCalculadoAsignada == (Int32)PrioridadEnum.Prioridad_4;
           if (result.AplicarPrioridad)
           {
               result.PuntajeCalculado = this.CalcularPuntaje(idProyecto);
           }
           #endregion Obtiene Puntaje

           return result;
       }

       public decimal CalcularPuntaje(Int32 idProyecto)
       {
           decimal retval = 0;

           retval = (from i in Context.ProyectoIndicadorPriorizacions
                     where i.IdProyecto == idProyecto
                     select new
                     {
                         Valor = i.Valor == null ? 0 : (decimal)i.Valor
                     }).ToList().Sum(v => v.Valor);

           return retval;
       }
    }
}

