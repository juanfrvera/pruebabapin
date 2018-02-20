using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoEtapaEstimadoPeriodoData : _ProyectoEtapaEstimadoPeriodoData 
    {

        public override string IdFieldName { get { return "IdProyectoEtapaEstimadoPeriodo"; } }

        protected override IQueryable<ProyectoEtapaEstimadoPeriodoResult> QueryResult(ProyectoEtapaEstimadoPeriodoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoEtapaEstimados on o.IdProyectoEtapaEstimado equals t1.IdProyectoEtapaEstimado   
                     where ( filter.IdProyecto == null || filter.IdProyecto == 0 ||
                                ( from proyecto in this.Context.Proyectos
                                  join proyectoEtapa in this.Context.ProyectoEtapas on proyecto.IdProyecto equals proyectoEtapa.IdProyecto 
                                  join pee in this.Context.ProyectoEtapaEstimados on proyectoEtapa.IdProyectoEtapa equals pee.IdProyectoEtapa 
                                  where proyecto.IdProyecto == filter.IdProyecto 
                                  select pee.IdProyectoEtapaEstimado ).Contains (o.IdProyectoEtapaEstimado ) )
                      && (filter.IdFase == null || filter.IdFase == 0 ||
                            (from fase in this.Context.Fases 
                             join etapa in this.Context.Etapas on fase.IdFase equals etapa.IdFase 
                             join pe in this.Context.ProyectoEtapas on etapa.IdEtapa equals pe.IdEtapa 
                             join pee in this.Context.ProyectoEtapaEstimados on pe.IdProyectoEtapa equals pee.IdProyectoEtapa
                             where fase.IdFase == filter.IdFase 
                             select pee.IdProyectoEtapaEstimado).Contains(o.IdProyectoEtapaEstimado))
				   select new ProyectoEtapaEstimadoPeriodoResult(){
					 IdProyectoEtapaEstimadoPeriodo=o.IdProyectoEtapaEstimadoPeriodo
					 ,IdProyectoEtapaEstimado=o.IdProyectoEtapaEstimado
					 ,Periodo=o.Periodo
					 ,Monto=o.Monto
					 ,Cotizacion=o.Cotizacion
					 ,MontoCalculado=o.MontoCalculado
                     ,MontoInicial = o.MontoInicial
                     ,MontoVigente = o.MontoVigente
                     ,MontoDevengado = o.MontoDevengado
                     ,MontoVigenteEstimativo = o.MontoVigenteEstimativo
					,ProyectoEtapaEstimado_IdProyectoEtapa= t1.IdProyectoEtapa	
						,ProyectoEtapaEstimado_IdClasificacionGasto= t1.IdClasificacionGasto	
						,ProyectoEtapaEstimado_IdFuenteFinanciamiento= t1.IdFuenteFinanciamiento	
						//,ProyectoEtapaEstimado_IdProyectoOrigenFinanciamiento= t1.IdProyectoOrigenFinanciamiento	
						,ProyectoEtapaEstimado_IdMoneda= t1.IdMoneda	
						}
                    ).AsQueryable();
        }
    }
}
