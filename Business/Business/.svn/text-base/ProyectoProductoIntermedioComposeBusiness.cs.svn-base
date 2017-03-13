using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
    public class ProyectoProductoIntermedioComposeBusiness : EntityComposeBusiness<ProyectoProductoIntermedioCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoProductoIntermedioComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoProductoIntermedioComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoProductoIntermedioComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected const string CANTIDAD_MAXIMA_ETAPAS = "CANTIDAD_MAXIMA_ETAPAS";
        protected const string ID_PROCESO_EQ_BASICO = "ID_PROCESO_EQ_BASICO";
        protected override EntityBusiness<Proyecto, ProyectoFilter, ProyectoResult, int> EntityBusinessBase
        {
            get { return ProyectoBusiness.Current; }
        }
        protected override IEntityData<ProyectoProductoIntermedioCompose, ProyectoFilter, ProyectoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override ProyectoProductoIntermedioCompose GetNew(ProyectoResult example)
        {
            ProyectoProductoIntermedioCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.Etapas = new List<ProyectoEtapaResult>();
            compose.IndicadoresEtapa = new List<ProyectoEtapaIndicadorCompose>();
            return compose;
        }
        public override ProyectoProductoIntermedioCompose GetNew()
        {
            ProyectoProductoIntermedioCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.Etapas = new List<ProyectoEtapaResult>();
            compose.IndicadoresEtapa = new List<ProyectoEtapaIndicadorCompose>();
            return compose;
        }
        public override int GetId(ProyectoProductoIntermedioCompose entity)
        {
            return entity.IdProyecto;
        }
        public override ProyectoProductoIntermedioCompose GetById(int id)
        {
            ProyectoResult proyecto = ProyectoBusiness.Current.GetResultFromListWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();
            ProyectoProductoIntermedioCompose compose = new ProyectoProductoIntermedioCompose();
            compose.Proyecto = proyecto;            
            compose.EsProyecto = proyecto.EsProyecto == null ? false : (bool)proyecto.EsProyecto;
            compose.MarcaPlan = GetMarcaPlanProyecto(proyecto.IdProyecto);
            compose.EsEquipamientoBasico = proyecto.IdProceso != null && (Int32)proyecto.IdProceso == (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROCESO_EQ_BASICO);
            compose.NroProyecto = proyecto.NroProyecto == null ? 0 : (Int32)proyecto.NroProyecto;             
            compose.Etapas = ProyectoEtapaBusiness.Current.GetEtapas(new ProyectoEtapaFilter() { IdProyecto = id });
            compose.EtapasCantidadMaxima = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(CANTIDAD_MAXIMA_ETAPAS);
            compose.IndicadoresEtapa = ProyectoEtapaIndicadorComposeBusiness.Current.GetIndicadoresEtapaProyecto(new ProyectoEtapaFilter() { IdProyecto = id });

            // Elimina la validacion
            foreach (ProyectoEtapaIndicadorCompose peic in compose.IndicadoresEtapa)
            {
                foreach (IndicadorEvolucionResult ier in peic.Evoluciones)
                    ier.ValidarCantidadEstados = false;
            }

            return compose;
        }
        public bool GetMarcaPlanProyecto(Int32 IdProyecto)
        {
            return ProyectoData.Current.GetMarcaPlanProyecto(IdProyecto);
        }
        #endregion

        #region Actions
        public override void Add(ProyectoProductoIntermedioCompose entity, IContextUser contextUser)
        {
            Dictionary<Int32, Int32> nuevasEtapas = new Dictionary<int, int>();

            foreach (ProyectoEtapaResult per in entity.Etapas)
            {
                per.IdProyecto = entity.IdProyecto;
                ProyectoEtapa pe = per.ToEntity();
                Int32 tempId = pe.IdProyectoEtapa;
                pe.IdProyectoEtapa = 0;
                ProyectoEtapaBusiness.Current.Add(pe, contextUser);
                per.IdProyectoEtapa = pe.IdProyectoEtapa;
                if(!nuevasEtapas.ContainsKey(tempId))nuevasEtapas.Add(tempId, pe.IdProyectoEtapa);
            }

            foreach (ProyectoEtapaIndicadorCompose indicador in entity.IndicadoresEtapa)
            {
                Indicador indi = new Indicador();
                indi.IdIndicador = (Int32)indicador.Indicador.IdIndicador;
                indi.IdMedioVerificacion = indicador.Indicador.Indicador_IdMedioVerificacion;
                indi.Observacion = indicador.Indicador.Indicador_Observacion;
                IndicadorBusiness.Current.Add(indi, contextUser);
                indicador.Indicador.IdIndicador = indi.IdIndicador;

                ProyectoEtapaIndicador pei = indicador.Indicador.ToEntity();
                Int32 tempIdKey = pei.IdProyectoEtapa;
                pei.IdProyectoEtapa = nuevasEtapas[tempIdKey];
                indicador.Indicador.IdProyectoEtapa = nuevasEtapas[tempIdKey];
                pei.IdProyectoEtapaIndicador = 0;
                ProyectoEtapaIndicadorBusiness.Current.Add(pei, contextUser);
                indicador.Indicador.IdProyectoEtapaIndicador = pei.IdProyectoEtapaIndicador;

                foreach (IndicadorEvolucionResult ier in indicador.Evoluciones)
                {
                    IndicadorEvolucion ie = ier.ToEntity();
                    ie.IdIndicador = indi.IdIndicador;
                    ie.IdIndicadorEvolucion = 0;
                    IndicadorEvolucionBusiness.Current.Add(ie, contextUser);
                    ier.IdIndicadorEvolucion = ie.IdIndicadorEvolucion;
                }
            }
        }
        public override void Update(ProyectoProductoIntermedioCompose entity, IContextUser contextUser)
        {
            #region Etapas
            // Elimina los que ya no estan
            List<int> actualIds = (from o in entity.Etapas where o.IdProyectoEtapa > 0 select o.IdProyectoEtapa).ToList();
            List<ProyectoEtapa> oldDetail = ProyectoEtapaBusiness.Current.GetList(new ProyectoEtapaFilter() { IdProyecto = entity.IdProyecto });
            List<ProyectoEtapa> deletes = (from o in oldDetail where !actualIds.Contains(o.IdProyectoEtapa) select o).ToList();
            ProyectoEtapaBusiness.Current.Delete(deletes, contextUser);
            Dictionary<Int32, Int32> nuevasEtapas = new Dictionary<int, int>();

            foreach (ProyectoEtapaResult etapa in entity.Etapas)
            {
                //Guarda los datos de Proyecto
                Proyecto proyecto = ProyectoBusiness.Current.GetById(entity.IdProyecto);
                proyecto.EsProyecto = entity.EsProyecto;
                proyecto.NroProyecto = entity.NroProyecto;
                ProyectoBusiness.Current.Update(proyecto, contextUser);

                // Etapas
                ProyectoEtapa pe = etapa.ToEntity();
                pe.IdProyecto = entity.IdProyecto;
                if (pe.IdProyectoEtapa <= 0)
                {
                    Int32 tempId = pe.IdProyectoEtapa;
                    ProyectoEtapaBusiness.Current.Add(pe, contextUser);
                    etapa.IdProyectoEtapa = pe.IdProyectoEtapa;
                    nuevasEtapas.Add(tempId, pe.IdProyectoEtapa);
                }
                else
                {
                    nuevasEtapas.Add(pe.IdProyectoEtapa, pe.IdProyectoEtapa);
                    ProyectoEtapaBusiness.Current.Update(pe, contextUser);
                }
            }
            #endregion
            
            #region Indicadores
            // Elimina los que ya no estan
            List<int> actualIdsIND = (from o in entity.IndicadoresEtapa where o.ID > 0 select o.Indicador.IdProyectoEtapaIndicador).ToList();
            List<ProyectoEtapaIndicador> oldDetailIND = ProyectoEtapaIndicadorBusiness.Current.GetByIdProyecto(entity.IdProyecto);
            List<ProyectoEtapaIndicador> deletesIND = (from o in oldDetailIND where !actualIdsIND.Contains(o.IdProyectoEtapaIndicador) select o).ToList();
            ProyectoEtapaIndicadorBusiness.Current.Delete(deletesIND, contextUser);

            foreach (ProyectoEtapaIndicadorCompose indicador in entity.IndicadoresEtapa)
            {
                Indicador indi = new Indicador();
                indi.IdIndicador = (Int32)indicador.Indicador.IdIndicador;
                indi.IdMedioVerificacion = indicador.Indicador.Indicador_IdMedioVerificacion;
                indi.Observacion = indicador.Indicador.Indicador_Observacion;
                if (indi.IdIndicador <= 0)
                {
                    IndicadorBusiness.Current.Add(indi, contextUser);
                    indicador.Indicador.IdIndicador = indi.IdIndicador;
                }
                else
                {
                    IndicadorBusiness.Current.Update(indi, contextUser);
                }

                ProyectoEtapaIndicador pei = indicador.Indicador.ToEntity();
                if (pei.IdProyectoEtapaIndicador <= 0)
                {
                    Int32 tempIdKey = pei.IdProyectoEtapa;
                    pei.IdProyectoEtapa = nuevasEtapas[tempIdKey];
                    indicador.Indicador.IdProyectoEtapa = nuevasEtapas[tempIdKey];
                    ProyectoEtapaIndicadorBusiness.Current.Add(pei, contextUser);
                    indicador.Indicador.IdProyectoEtapaIndicador = pei.IdProyectoEtapaIndicador;
                }
                else
                {
                    ProyectoEtapaIndicadorBusiness.Current.Update(pei, contextUser);
                }

                #region Evoluciones
                List<int> actualIdsEVO = (from o in indicador.Evoluciones where o.IdIndicadorEvolucion > 0 select o.IdIndicadorEvolucion).ToList();
                List<IndicadorEvolucion> evolucionesOldEVO = ProyectoEtapaIndicadorData.Current.GetIndicadoresEvolucionByIdIndicador(indicador.Indicador.IdProyectoEtapaIndicador);
                List<int> idsToDeleteEVO = (from o in evolucionesOldEVO where !actualIdsEVO.Contains(o.IdIndicadorEvolucion) select o.IdIndicadorEvolucion).ToList();
                IndicadorEvolucionBusiness.Current.Delete(idsToDeleteEVO.ToArray(), contextUser);

                foreach (IndicadorEvolucionResult ier in indicador.Evoluciones)
                {
                    if (ier.IdIndicadorEvolucion < 1)
                    {
                        IndicadorEvolucion ie = ier.ToEntity();
                        ie.IdIndicador = indi.IdIndicador;
                        IndicadorEvolucionBusiness.Current.Add(ie, contextUser);
                    }
                    else
                    {
                        IndicadorEvolucion ie = ier.ToEntity();
                        IndicadorEvolucionBusiness.Current.Update(ie, contextUser);
                    }
                }
                #endregion
            }

            #endregion indicadores

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(ProyectoProductoIntermedioCompose entity, IContextUser contextUser) { }
        public virtual ProyectoProductoIntermedioCompose CopyProyectoProductoIntermedio(int oldId, int newId, int offset, IContextUser contextUser)
        {
            ProyectoProductoIntermedioCompose oldEntity = ProyectoProductoIntermedioComposeBusiness.Current.GetById(oldId);
            ProyectoProductoIntermedioCompose newEntity = ProyectoProductoIntermedioComposeBusiness.Current.Copy(oldEntity, contextUser);
            newEntity.Proyecto = ProyectoBusiness.Current.GetResultFromList(new ProyectoFilter() { IdProyecto = newId }).FirstOrDefault();
            
            foreach (ProyectoEtapaResult per in newEntity.Etapas)
            {                
                //IMPORTANTE GUARDA EL ID ANTERIOR
                per.IdCopyProyectoEtapa = per.IdProyectoEtapa;

                per.IdProyecto = newId; 
                per.IdProyectoEtapa = 0;

                // Datos que no se copian
                per.IdEstado = null;
                per.CodigoVinculacion = null;
                //las fechas realizadas no se deben copiar
                per.FechaInicioRealizada = null;// = per.FechaInicioRealizada != null ? (DateTime?)((DateTime)per.FechaInicioRealizada).AddYears(offset) : null;
                per.FechaFinRealizada = null;// per.FechaFinRealizada != null ? (DateTime?)((DateTime)per.FechaFinRealizada).AddYears(offset) : null;
    
                // Corrimiento
                per.FechaInicioEstimada = per.FechaInicioEstimada != null ? (DateTime?)((DateTime)per.FechaInicioEstimada).AddYears(offset) : null;
                per.FechaFinEstimada = per.FechaFinEstimada != null ? (DateTime?)((DateTime)per.FechaFinEstimada).AddYears(offset) : null;
            }
            ProyectoProductoIntermedioComposeBusiness.Current.Add(newEntity, contextUser);
            return newEntity;
        }
        public override ProyectoProductoIntermedioCompose Copy(ProyectoProductoIntermedioCompose entity, IContextUser contextUser)
        {
            ProyectoProductoIntermedioCompose newEntity = new ProyectoProductoIntermedioCompose();
            newEntity.Etapas = ProyectoEtapaBusiness.Current.CopiesResult(entity.Etapas);
            return newEntity;
        }
        #endregion

        #region protected Methods

        #endregion

        #region Validations

        public override void Validate(ProyectoProductoIntermedioCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            //if (entity.NroProyecto != null && entity.Proyecto.EvaluarValidaciones)
            //{
            //    DataHelper.Validate(entity.Etapas.Where(r => r.EsObra ==true ).Count() == 1,"Debe Ingresar Una Obra");                
            //}
            foreach (ProyectoEtapaResult per in entity.Etapas)
            {
                ProyectoEtapa pe = per.ToEntity();
                pe.IdProyecto = entity.IdProyecto;
                ProyectoEtapaBusiness.Current.Validate(pe, actionName, contextUser, args);
            }

            foreach (ProyectoEtapaIndicadorCompose peic in entity.IndicadoresEtapa)
            {
                ProyectoEtapaIndicador pei = peic.Indicador.ToEntity();
                ProyectoEtapaIndicadorBusiness.Current.Validate(pei, actionName, contextUser, args);
                DataHelper.Validate(ProyectoProductoIntermedioComposeBusiness.Current.ValidateEvoluciones(peic.Evoluciones), "Invalid", "Evoluciones");
            }
        }

        private bool ValidateEvoluciones(List<IndicadorEvolucionResult> Evoluciones)
        {
            var tabla =
                        from evolucion in Evoluciones
                        group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
                        select new
                        {
                            IdClasificacionGeografica = evolucionGroup.Key,
                            CantBase = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Base),
                            CantIntermedio = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Intermedio),
                            CantFinal = evolucionGroup.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Final)
                        };

            if (Evoluciones.Where(e => e.ValidarCantidadEstados).Count() > 0)
            {
                foreach (var linea in tabla)
                {
                    if (!((linea.CantBase == 1) && ((linea.CantIntermedio > 1) || (linea.CantFinal == 1))))
                    {
                        return false;
                    }
                }
            }

            var tabla2 =
            from evolucion in Evoluciones
            group evolucion by evolucion.IdClasificacionGeografica into evolucionGroup
            select new
            {
                IdClasificacionGeografica = evolucionGroup.Key,
                MonthGroups =
                                from o in evolucionGroup
                                group o by o.FechaReal into mg
                                select new { Fecha = mg.Key, CantIntermedio = mg.Count(i => i.IdIndicadorEvolucionInstancia == (int)IndicadorEvolucionInstanciaEnum.Intermedio) }

            };

            foreach (var linea2 in tabla2)
            {

                if (linea2.MonthGroups.Count(p => p.CantIntermedio > 1) > 0)
                {
                    return false;
                }
            }
            return true;
        }


        public override bool Can(ProyectoProductoIntermedioCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            bool retval = true; // false;
            foreach (ProyectoEtapaResult per in entity.Etapas)
            {
                ProyectoEtapa pe = per.ToEntity();
                pe.IdProyecto = entity.IdProyecto;
                retval = retval && ProyectoEtapaBusiness.Current.Can(pe, actionName, contextUser, args);
            }

            if (ActionConfig.DELETE == actionName)
            {
                retval = retval && !entity.MarcaPlan;
            }

            //foreach (ProyectoEtapaIndicadorCompose peer in entity.IndicadoresEtapa)
            //{
            //    ProyectoEtapaEstimado pee = peer.ToEntity();
            //    retval = retval && ProyectoEtapaEstimadoBusiness.Current.Can(pee, actionName, contextUser, args);
            //}

            return retval;
        }

        public override bool Equals(ProyectoProductoIntermedioCompose source, ProyectoProductoIntermedioCompose target)
        {
            bool eq = source.IdProyecto.Equals(target.IdProyecto) &&
                      source.EsProyecto == target.EsProyecto &&
                      source.NroProyecto == target.NroProyecto;
            if (eq)
            {
                if(source.Etapas.Count != target.Etapas.Count) return false;
                bool eqEt = true;
                foreach (ProyectoEtapaResult per in source.Etapas)
                {
                    ProyectoEtapaResult perTarget = target.Etapas.Where(p => p.IdProyectoEtapa == per.IdProyectoEtapa).SingleOrDefault();

                    if (perTarget == null) return false;

                    eqEt =  per.Nombre == perTarget.Nombre
                                && per.CodigoVinculacion == perTarget.CodigoVinculacion
                                && per.IdEstado == perTarget.IdEstado
                                && per.FechaInicioEstimada == perTarget.FechaInicioEstimada
                                && per.FechaFinEstimada == perTarget.FechaFinEstimada
                                && per.FechaInicioRealizada == perTarget.FechaInicioRealizada
                                && per.FechaFinRealizada == perTarget.FechaFinRealizada
                                && per.IdEtapa == perTarget.IdEtapa
                                && per.IdProyecto == perTarget.IdProyecto
                                && per.NroEtapa == perTarget.NroEtapa;
                }
                if (!eqEt) return eqEt;

                // VALIDAR INDICADORES    
                if(source.IndicadoresEtapa.Count() != target.IndicadoresEtapa.Count()) return false;
                bool eqIE = true;
                foreach (ProyectoEtapaIndicadorCompose ie in source.IndicadoresEtapa)
                {
                    ProyectoEtapaIndicadorCompose ieTarget = target.IndicadoresEtapa.Where(p => p.ID == ie.ID).SingleOrDefault();
                    eqIE = eqIE && ie.Indicador.Equals(ieTarget.Indicador);

                    if (eqIE)
                    { 
                        // VALIDAR EVOLUCIONES
                        if (ieTarget.Evoluciones.Count() != ie.Evoluciones.Count()) return false;

                        foreach (IndicadorEvolucionResult evo in ie.Evoluciones)
                        {
                            IndicadorEvolucionResult evoTarget = ieTarget.Evoluciones.Where(o => o.IdIndicadorEvolucion == evo.IdIndicadorEvolucion).SingleOrDefault();
                            eqIE = eqIE && evo.Equals(evoTarget);
                        }
                    }
                }
                if (!eqIE) return eqIE;

                eq = eqEt && eqIE;
            }
            return eq;
        }

        public bool Can(ProyectoProductoIntermedioCompose entity, int IdProyectoEtapa, string actionName, IContextUser contextUser)
        {
            bool retval = true; 
            foreach (ProyectoEtapaResult per in entity.Etapas)
            {
                ProyectoEtapa pe = per.ToEntity();
                pe.IdProyecto = entity.IdProyecto;
                retval = retval && ProyectoEtapaBusiness.Current.Can(pe, actionName, contextUser, new Hashtable());
            }

            if (ActionConfig.DELETE == actionName)
            {
                //Matias Tarea x - 20170105
                //Agrega validacion para no eliminar una etapa (obra/act) si tiene gastos estimados
                decimal? TotalEstimado = entity.Etapas.Where(e => e.IdProyectoEtapa == IdProyectoEtapa).SingleOrDefault().TotalEstimado;
                retval = retval && (TotalEstimado == null || TotalEstimado == 0);
                //Matias Tarea x - 20170105

                decimal? TotalRealizado = entity.Etapas.Where(e => e.IdProyectoEtapa == IdProyectoEtapa).SingleOrDefault().TotalRealizado;
                retval = retval && (TotalRealizado == null || TotalRealizado == 0);//&& !entity.MarcaPlan 
            }

            return retval;
        }

        #endregion
    }
}