using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoEtapaInformacionPresupuestariaPeriodoData : _ProyectoEtapaInformacionPresupuestariaPeriodoData 
    {

        public override string IdFieldName { get { return "IdProyectoEtapaInformacionPresupuestariaPeriodo"; } }

        protected override IQueryable<ProyectoEtapaInformacionPresupuestariaPeriodoResult> QueryResult(ProyectoEtapaInformacionPresupuestariaPeriodoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ProyectoEtapaInformacionPresupuestarias on o.IdProyectoEtapaInformacionPresupuestaria equals t1.IdProyectoEtapaInformacionPresupuestaria   
                     where ( filter.IdProyecto == null || filter.IdProyecto == 0 ||
                                ( from proyecto in this.Context.Proyectos
                                  join proyectoEtapa in this.Context.ProyectoEtapas on proyecto.IdProyecto equals proyectoEtapa.IdProyecto 
                                  join pee in this.Context.ProyectoEtapaInformacionPresupuestarias on proyectoEtapa.IdProyectoEtapa equals pee.IdProyectoEtapa 
                                  where proyecto.IdProyecto == filter.IdProyecto 
                                  select pee.IdProyectoEtapaInformacionPresupuestaria ).Contains (o.IdProyectoEtapaInformacionPresupuestaria ) )
                      && (filter.IdFase == null || filter.IdFase == 0 ||
                            (from fase in this.Context.Fases 
                             join etapa in this.Context.Etapas on fase.IdFase equals etapa.IdFase 
                             join pe in this.Context.ProyectoEtapas on etapa.IdEtapa equals pe.IdEtapa 
                             join pee in this.Context.ProyectoEtapaInformacionPresupuestarias on pe.IdProyectoEtapa equals pee.IdProyectoEtapa
                             where fase.IdFase == filter.IdFase 
                             select pee.IdProyectoEtapaInformacionPresupuestaria).Contains(o.IdProyectoEtapaInformacionPresupuestaria))
				   select new ProyectoEtapaInformacionPresupuestariaPeriodoResult(){
					 IdProyectoEtapaInformacionPresupuestariaPeriodo=o.IdProyectoEtapaInformacionPresupuestariaPeriodo
					 ,IdProyectoEtapaInformacionPresupuestaria=o.IdProyectoEtapaInformacionPresupuestaria
					 ,Periodo=o.Periodo
                     ,MontoInicial = o.MontoInicial
                     ,MontoVigente = o.MontoVigente
                     ,MontoDevengado = o.MontoDevengado
                     ,MontoVigenteEstimativo = o.MontoVigenteEstimativo
					,ProyectoEtapaInformacionPresupuestaria_IdProyectoEtapa= t1.IdProyectoEtapa	
						,ProyectoEtapaInformacionPresupuestaria_IdClasificacionGasto= t1.IdClasificacionGasto	
						,ProyectoEtapaInformacionPresupuestaria_IdFuenteFinanciamiento= t1.IdFuenteFinanciamiento	
						//,ProyectoEtapaInformacionPresupuestaria_IdProyectoOrigenFinanciamiento= t1.IdProyectoOrigenFinanciamiento	
						,ProyectoEtapaInformacionPresupuestaria_IdMoneda= t1.IdMoneda	
						}
                    ).AsQueryable();
        }
    }
}
