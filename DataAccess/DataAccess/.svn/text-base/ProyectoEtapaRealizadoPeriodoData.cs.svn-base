using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoEtapaRealizadoPeriodoData : _ProyectoEtapaRealizadoPeriodoData 
    { 
	   #region Singleton
	   private static volatile ProyectoEtapaRealizadoPeriodoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaRealizadoPeriodoData() {}
	   public static ProyectoEtapaRealizadoPeriodoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaRealizadoPeriodoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoEtapaRealizadoPeriodo"; } }


        protected override IQueryable<ProyectoEtapaRealizadoPeriodoResult> QueryResult(ProyectoEtapaRealizadoPeriodoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoEtapaRealizados on o.IdProyectoEtapaRealizado equals t1.IdProyectoEtapaRealizado
                  where (filter.IdProyecto == null || filter.IdProyecto == 0 ||
                          (from proyecto in this.Context.Proyectos
                           join proyectoEtapa in this.Context.ProyectoEtapas on proyecto.IdProyecto equals proyectoEtapa.IdProyecto
                           join pee in this.Context.ProyectoEtapaRealizados on proyectoEtapa.IdProyectoEtapa equals pee.IdProyectoEtapa
                           where proyecto.IdProyecto == filter.IdProyecto 
                           select pee.IdProyectoEtapaRealizado).Contains(o.IdProyectoEtapaRealizado))
                  && (filter.IdFase == null || filter.IdFase == 0 ||
                          (from fase in this.Context.Fases
                           join etapa in this.Context.Etapas on fase.IdFase equals etapa.IdFase
                           join pe in this.Context.ProyectoEtapas on etapa.IdEtapa equals pe.IdEtapa
                           join pee in this.Context.ProyectoEtapaRealizados on pe.IdProyectoEtapa equals pee.IdProyectoEtapa
                           where fase.IdFase == filter.IdFase 
                           select pee.IdProyectoEtapaRealizado).Contains(o.IdProyectoEtapaRealizado))
				   select new ProyectoEtapaRealizadoPeriodoResult(){
					 IdProyectoEtapaRealizadoPeriodo=o.IdProyectoEtapaRealizadoPeriodo
					 ,IdProyectoEtapaRealizado=o.IdProyectoEtapaRealizado
					 ,Periodo=o.Periodo
					 ,Fecha=o.Fecha
					 ,Monto=o.Monto
					 ,Cotizacion=o.Cotizacion
					 ,MontoCalculado=o.MontoCalculado
					,ProyectoEtapaRealizado_IdProyectoEtapa= t1.IdProyectoEtapa	
						,ProyectoEtapaRealizado_IdClasificacionGasto= t1.IdClasificacionGasto	
						,ProyectoEtapaRealizado_IdFuenteFinanciamiento= t1.IdFuenteFinanciamiento	
						//,ProyectoEtapaRealizado_IdProyectoOrigenFinanciamiento= t1.IdProyectoOrigenFinanciamiento	
						,ProyectoEtapaRealizado_IdMoneda= t1.IdMoneda	
						}
                    ).AsQueryable();
        }
         
    }
}
