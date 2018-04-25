using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;
using Service;

namespace Business
{
    public class ProyectoCronogramaComposeBusiness : EntityComposeBusiness<ProyectoCronogramaCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoCronogramaComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoCronogramaComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoCronogramaComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Proyecto, ProyectoFilter, ProyectoResult, int> EntityBusinessBase
        {
            get { return ProyectoBusiness.Current; }
        }

        protected override IEntityData<ProyectoCronogramaCompose, ProyectoFilter, ProyectoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override ProyectoCronogramaCompose GetNew(ProyectoResult example)
        {
            ProyectoCronogramaCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.Etapas = new List<ProyectoEtapaResult>();
            compose.EtapasEstimadas = new List<ProyectoEtapaEstimadoResult>();
            compose.EtapasRealizadas = new List<ProyectoEtapaRealizadoResult>();
            compose.EtapasInformacionPresupuestarias = new List<ProyectoEtapaInformacionPresupuestariaResult>();
            return compose;
        }
        public override ProyectoCronogramaCompose GetNew()
        {
            ProyectoCronogramaCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.Etapas = new List<ProyectoEtapaResult>();
            compose.EtapasEstimadas = new List<ProyectoEtapaEstimadoResult>();
            compose.EtapasRealizadas = new List<ProyectoEtapaRealizadoResult>();
            compose.EtapasInformacionPresupuestarias = new List<ProyectoEtapaInformacionPresupuestariaResult>();
            return compose;
        }
        public override int GetId(ProyectoCronogramaCompose entity)
        {
            return entity.IdProyecto;
        }
        public override ProyectoCronogramaCompose GetById(int id)
        {
            return GetByIdFase(id, (int)FaseEnum.Ejecucion);
        }
        public ProyectoCronogramaCompose GetByIdFase(int id, int idFase)
        {
            // Informacion para editar
            ProyectoCronogramaCompose compose = new ProyectoCronogramaCompose();
            compose.Proyecto = ProyectoBusiness.Current.GetResultFromListWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();
            compose.IdFase = idFase;
            compose.Etapas = ProyectoEtapaBusiness.Current.GetEtapas(new ProyectoEtapaFilter() { IdProyecto = id, IdFase = idFase });
            compose.EtapasEstimadas = ProyectoEtapaEstimadoBusiness.Current.GetEtapasEstimadas(new ProyectoEtapaFilter() { IdProyecto = id, IdFase = idFase });
            compose.EtapasRealizadas = ProyectoEtapaRealizadoBusiness.Current.GetEtapasRealizadas(new ProyectoEtapaFilter() { IdProyecto = id, IdFase = idFase });
            compose.EtapasInformacionPresupuestarias = ProyectoEtapaInformacionPresupuestariaBusiness.Current.GetEtapasInformacionPresupuestarias(new ProyectoEtapaFilter() { IdProyecto = id, IdFase = idFase });

            // Informacion para Validaciones
            Proyecto p = ProyectoBusiness.Current.GetById(id);
            compose.ProyectoAnioCorriente = p.AnioCorriente;
            compose.ProyectoAnioCorrienteEstimado = p.AnioCorrienteEstimado;
            compose.ProyectoAnioCorrienteRealizado = p.AnioCorrienteRealizado;
            compose.ProyectoAnioReferencia = p.FechaInicioEjecucionCalculada == null ? p.FechaAlta.Year : ((DateTime)p.FechaInicioEjecucionCalculada).Year;
            compose.ProyectoIdProceso = p.IdProceso;
            compose.ProyectoIdTipoPlan = ProyectoPlanBusiness.Current.GetIdTipoPlan(p.IdProyecto);

            return compose;
        }
        #endregion

        #region Actions
        public override void Add(ProyectoCronogramaCompose entity, IContextUser contextUser)
        {
            try
            {
                // Etapas
                foreach (ProyectoEtapaResult per in entity.Etapas)
                {
                    per.IdProyecto = entity.IdProyecto;
                    ProyectoEtapa pe = per.ToEntity();
                    ProyectoEtapaBusiness.Current.Add(pe, contextUser);
                    per.IdProyectoEtapa = pe.IdProyectoEtapa;
                }

                // Estimadas
                foreach (ProyectoEtapaEstimadoResult peer in entity.EtapasEstimadas)
                {
                    ProyectoEtapaEstimado pee = peer.ToEntity();
                    ProyectoEtapaEstimadoBusiness.Current.Add(pee, contextUser);
                    peer.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado;

                    foreach (ProyectoEtapaEstimadoPeriodoResult pr in peer.Periodos)
                    {
                        ProyectoEtapaEstimadoPeriodo p = pr.ToEntity();
                        p.IdProyectoEtapaEstimadoPeriodo = 0;
                        p.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado;
                        ProyectoEtapaEstimadoPeriodoBusiness.Current.Add(p, contextUser);
                        pr.IdProyectoEtapaEstimadoPeriodo = p.IdProyectoEtapaEstimadoPeriodo;
                    }
                }

                // Realizado
                foreach (ProyectoEtapaRealizadoResult perr in entity.EtapasRealizadas)
                {
                    ProyectoEtapaRealizado per = perr.ToEntity();
                    ProyectoEtapaRealizadoBusiness.Current.Add(per, contextUser);
                    perr.IdProyectoEtapaRealizado = per.IdProyectoEtapaRealizado;

                    foreach (ProyectoEtapaRealizadoPeriodoResult pr in perr.Periodos)
                    {
                        ProyectoEtapaRealizadoPeriodo p = pr.ToEntity();
                        p.IdProyectoEtapaRealizadoPeriodo = 0;
                        p.IdProyectoEtapaRealizado = per.IdProyectoEtapaRealizado;
                        ProyectoEtapaRealizadoPeriodoBusiness.Current.Add(p, contextUser);
                        pr.IdProyectoEtapaRealizadoPeriodo = p.IdProyectoEtapaRealizadoPeriodo;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public override void Update(ProyectoCronogramaCompose entity, IContextUser contextUser)
        {
            //Matias 20170131 - Ticket #REQ571729
            
            //FinMatias 20170131 - Ticket #REQ571729
            
            foreach (ProyectoEtapaResult etapa in entity.Etapas)
            {
                //Guarda el anio Corriente de Proyecto
                Proyecto proyecto = ProyectoBusiness.Current.GetById(entity.IdProyecto);
                proyecto.AnioCorriente = entity.ProyectoAnioCorriente;
                proyecto.AnioCorrienteEstimado = entity.ProyectoAnioCorrienteEstimado;
                proyecto.AnioCorrienteRealizado = entity.ProyectoAnioCorrienteRealizado;
                proyecto.IdTipoProyecto = entity.Proyecto.IdTipoProyecto;
                ProyectoBusiness.Current.Update(proyecto, contextUser);

                // Por interfase no elimina ni agrega, solo actualiza
                ProyectoEtapa pe = etapa.ToEntity();
                pe.IdProyecto = entity.IdProyecto;
                ProyectoEtapaBusiness.Current.Update(pe, contextUser);

                #region Estimados
                // Elimina los que ya no estan
                List<int> actualIdsEst = (from o in entity.EtapasEstimadas where o.IdProyectoEtapaEstimado > 0 && o.IdProyectoEtapa == etapa.IdProyectoEtapa select o.IdProyectoEtapaEstimado).ToList();
                List<ProyectoEtapaEstimado> oldDetailEst = ProyectoEtapaEstimadoBusiness.Current.GetList(new ProyectoEtapaEstimadoFilter() { IdProyectoEtapa = etapa.IdProyectoEtapa });
                List<ProyectoEtapaEstimado> deletesEst = (from o in oldDetailEst where !actualIdsEst.Contains(o.IdProyectoEtapaEstimado) select o).ToList();
                foreach (ProyectoEtapaEstimado delPer in deletesEst)
                    ProyectoEtapaEstimadoPeriodoBusiness.Current.Delete(new ProyectoEtapaEstimadoPeriodoFilter() { IdProyectoEtapaEstimado = delPer.IdProyectoEtapaEstimado }, contextUser);
                ProyectoEtapaEstimadoBusiness.Current.Delete(deletesEst, contextUser);

                foreach (ProyectoEtapaEstimadoResult err in entity.EtapasEstimadas.Where(ee => ee.IdProyectoEtapa == etapa.IdProyectoEtapa))
                {
                    DataHelper.Validate(err.Periodos.Count > 0, "PeriodoRequerido", "FechaRealizada");


                    
                    err.Periodos = err.Periodos.Where( p => (p.MontoCalculado > 0 )).ToList();



                    ProyectoEtapaEstimado er = err.ToEntity();
                    er.IdProyectoEtapa = etapa.IdProyectoEtapa;
                    if (er.IdProyectoEtapaEstimado <= 0)
                    {
                        er.IdProyectoEtapaEstimado = 0;
                        ProyectoEtapaEstimadoBusiness.Current.Add(er, contextUser);

                        foreach (ProyectoEtapaEstimadoPeriodoResult pr in err.Periodos)
                        {
                            ProyectoEtapaEstimadoPeriodo p = pr.ToEntity();
                            p.IdProyectoEtapaEstimadoPeriodo = 0;
                            p.IdProyectoEtapaEstimado = er.IdProyectoEtapaEstimado;
                            ProyectoEtapaEstimadoPeriodoBusiness.Current.Add(p, contextUser);
                            pr.IdProyectoEtapaEstimadoPeriodo = p.IdProyectoEtapaEstimadoPeriodo;
                        }
                    }
                    else
                    {
                        ProyectoEtapaEstimadoBusiness.Current.Update(er, contextUser);

                        // Elimina los que ya no estan
                        List<int> actualIdsPer = (from o in err.Periodos where o.IdProyectoEtapaEstimadoPeriodo > 0 select o.IdProyectoEtapaEstimadoPeriodo).ToList();
                        List<ProyectoEtapaEstimadoPeriodo> oldDetailPer = ProyectoEtapaEstimadoPeriodoBusiness.Current.GetList(new ProyectoEtapaEstimadoPeriodoFilter() { IdProyectoEtapaEstimado = err.IdProyectoEtapaEstimado });
                        List<ProyectoEtapaEstimadoPeriodo> deletesPer = (from o in oldDetailPer where !actualIdsPer.Contains(o.IdProyectoEtapaEstimadoPeriodo) select o).ToList();
                        ProyectoEtapaEstimadoPeriodoBusiness.Current.Delete(deletesPer, contextUser);

                        foreach (ProyectoEtapaEstimadoPeriodoResult pr in err.Periodos)
                        {
                            ProyectoEtapaEstimadoPeriodo p = pr.ToEntity();
                            p.IdProyectoEtapaEstimado = err.IdProyectoEtapaEstimado;
                            if (pr.IdProyectoEtapaEstimadoPeriodo <= 0)
                                ProyectoEtapaEstimadoPeriodoBusiness.Current.Add(p, contextUser);
                            else
                                ProyectoEtapaEstimadoPeriodoBusiness.Current.Update(p, contextUser);
                            pr.IdProyectoEtapaEstimadoPeriodo = p.IdProyectoEtapaEstimadoPeriodo;
                        }
                    }
                }
                #endregion

                #region Realizados
                // Elimina los que ya no estan
                List<int> actualIdsReal = (from o in entity.EtapasRealizadas where o.IdProyectoEtapaRealizado > 0 && o.IdProyectoEtapa == etapa.IdProyectoEtapa select o.IdProyectoEtapaRealizado).ToList();
                List<ProyectoEtapaRealizado> oldDetailReal = ProyectoEtapaRealizadoBusiness.Current.GetList(new ProyectoEtapaRealizadoFilter() { IdProyectoEtapa = etapa.IdProyectoEtapa });
                List<ProyectoEtapaRealizado> deletesReal = (from o in oldDetailReal where !actualIdsReal.Contains(o.IdProyectoEtapaRealizado) select o).ToList();
                foreach (ProyectoEtapaRealizado delPer in deletesReal)
                    ProyectoEtapaRealizadoPeriodoBusiness.Current.Delete(new ProyectoEtapaRealizadoPeriodoFilter() { IdProyectoEtapaRealizado = delPer.IdProyectoEtapaRealizado }, contextUser);
                ProyectoEtapaRealizadoBusiness.Current.Delete(deletesReal, contextUser);

                foreach (ProyectoEtapaRealizadoResult err in entity.EtapasRealizadas.Where(er => er.IdProyectoEtapa == etapa.IdProyectoEtapa))
                {
                    DataHelper.Validate(err.Periodos.Count > 0, "PeriodoRequerido", "FechaRealizada");

                    ProyectoEtapaRealizado er = err.ToEntity();
                    er.IdProyectoEtapa = etapa.IdProyectoEtapa;
                    if (er.IdProyectoEtapaRealizado <= 0)
                    {
                        er.IdProyectoEtapaRealizado = 0;
                        ProyectoEtapaRealizadoBusiness.Current.Add(er, contextUser);

                        foreach (ProyectoEtapaRealizadoPeriodoResult pr in err.Periodos)
                        {
                            ProyectoEtapaRealizadoPeriodo p = pr.ToEntity();
                            p.IdProyectoEtapaRealizadoPeriodo = 0;
                            p.IdProyectoEtapaRealizado = er.IdProyectoEtapaRealizado;
                            ProyectoEtapaRealizadoPeriodoBusiness.Current.Add(p, contextUser);
                            pr.IdProyectoEtapaRealizadoPeriodo = p.IdProyectoEtapaRealizadoPeriodo;
                        }
                    }
                    else
                    {

                        err.Periodos = err.Periodos.Where( p => (p.MontoCalculado > 0 )).ToList();

                        ProyectoEtapaRealizadoBusiness.Current.Update(er, contextUser);

                        // Elimina los que ya no estan
                        List<int> actualIdsPer = (from o in err.Periodos where o.IdProyectoEtapaRealizadoPeriodo > 0 select o.IdProyectoEtapaRealizadoPeriodo).ToList();
                        List<ProyectoEtapaRealizadoPeriodo> oldDetailPer = ProyectoEtapaRealizadoPeriodoBusiness.Current.GetList(new ProyectoEtapaRealizadoPeriodoFilter() { IdProyectoEtapaRealizado = err.IdProyectoEtapaRealizado });
                        List<ProyectoEtapaRealizadoPeriodo> deletesPer = (from o in oldDetailPer where !actualIdsPer.Contains(o.IdProyectoEtapaRealizadoPeriodo) select o).ToList();
                        ProyectoEtapaRealizadoPeriodoBusiness.Current.Delete(deletesPer, contextUser);

                        foreach (ProyectoEtapaRealizadoPeriodoResult pr in err.Periodos)
                        {
                            ProyectoEtapaRealizadoPeriodo p = pr.ToEntity();
                            p.IdProyectoEtapaRealizado = err.IdProyectoEtapaRealizado;
                            if (pr.IdProyectoEtapaRealizadoPeriodo <= 0)
                                ProyectoEtapaRealizadoPeriodoBusiness.Current.Add(p, contextUser);
                            else
                                ProyectoEtapaRealizadoPeriodoBusiness.Current.Update(p, contextUser);
                            pr.IdProyectoEtapaRealizadoPeriodo = p.IdProyectoEtapaRealizadoPeriodo;
                        }
                    }
                }
                #endregion

                #region InformacionPresupuestaria
                // Elimina los que ya no estan
                List<int> actualIdsInfo = (from o in entity.EtapasInformacionPresupuestarias where o.IdProyectoEtapaInformacionPresupuestaria > 0 && o.IdProyectoEtapa == etapa.IdProyectoEtapa select o.IdProyectoEtapaInformacionPresupuestaria).ToList();
                List<ProyectoEtapaInformacionPresupuestaria> oldDetailInfo= ProyectoEtapaInformacionPresupuestariaBusiness.Current.GetList(new ProyectoEtapaInformacionPresupuestariaFilter() { IdProyectoEtapa = etapa.IdProyectoEtapa });
                List<ProyectoEtapaInformacionPresupuestaria> deletesInfo= (from o in oldDetailInfo where !actualIdsInfo.Contains(o.IdProyectoEtapaInformacionPresupuestaria) select o).ToList();
                foreach (ProyectoEtapaInformacionPresupuestaria delPer in deletesInfo)
                    ProyectoEtapaInformacionPresupuestariaPeriodoBusiness.Current.Delete(new ProyectoEtapaInformacionPresupuestariaPeriodoFilter() { IdProyectoEtapaInformacionPresupuestaria = delPer.IdProyectoEtapaInformacionPresupuestaria }, contextUser);
                ProyectoEtapaInformacionPresupuestariaBusiness.Current.Delete(deletesInfo, contextUser);

                foreach (ProyectoEtapaInformacionPresupuestariaResult err in entity.EtapasInformacionPresupuestarias.Where(ee => ee.IdProyectoEtapa == etapa.IdProyectoEtapa))
                {
                    DataHelper.Validate(err.Periodos.Count > 0, "PeriodoRequerido", "FechaRealizada");



                    err.Periodos = err.Periodos.Where(p => (p.MontoInicial > 0 || p.MontoDevengado > 0 || p.MontoVigente > 0 )).ToList();



                    ProyectoEtapaInformacionPresupuestaria er = err.ToEntity();
                    er.IdProyectoEtapa = etapa.IdProyectoEtapa;
                    if (er.IdProyectoEtapaInformacionPresupuestaria <= 0)
                    {
                        er.IdProyectoEtapaInformacionPresupuestaria = 0;
                        ProyectoEtapaInformacionPresupuestariaBusiness.Current.Add(er, contextUser);

                        foreach (ProyectoEtapaInformacionPresupuestariaPeriodoResult pr in err.Periodos)
                        {
                            ProyectoEtapaInformacionPresupuestariaPeriodo p = pr.ToEntity();
                            p.IdProyectoEtapaInformacionPresupuestariaPeriodo = 0;
                            p.IdProyectoEtapaInformacionPresupuestaria = er.IdProyectoEtapaInformacionPresupuestaria;
                            ProyectoEtapaInformacionPresupuestariaPeriodoBusiness.Current.Add(p, contextUser);
                            pr.IdProyectoEtapaInformacionPresupuestariaPeriodo = p.IdProyectoEtapaInformacionPresupuestariaPeriodo;
                        }
                    }
                    else
                    {
                        ProyectoEtapaInformacionPresupuestariaBusiness.Current.Update(er, contextUser);

                        // Elimina los que ya no estan
                        List<int> actualIdsPer = (from o in err.Periodos where o.IdProyectoEtapaInformacionPresupuestariaPeriodo > 0 select o.IdProyectoEtapaInformacionPresupuestariaPeriodo).ToList();
                        List<ProyectoEtapaInformacionPresupuestariaPeriodo> oldDetailPer = ProyectoEtapaInformacionPresupuestariaPeriodoBusiness.Current.GetList(new ProyectoEtapaInformacionPresupuestariaPeriodoFilter() { IdProyectoEtapaInformacionPresupuestaria = err.IdProyectoEtapaInformacionPresupuestaria });
                        List<ProyectoEtapaInformacionPresupuestariaPeriodo> deletesPer = (from o in oldDetailPer where !actualIdsPer.Contains(o.IdProyectoEtapaInformacionPresupuestariaPeriodo) select o).ToList();
                        ProyectoEtapaInformacionPresupuestariaPeriodoBusiness.Current.Delete(deletesPer, contextUser);

                        foreach (ProyectoEtapaInformacionPresupuestariaPeriodoResult pr in err.Periodos)
                        {
                            ProyectoEtapaInformacionPresupuestariaPeriodo p = pr.ToEntity();
                            p.IdProyectoEtapaInformacionPresupuestaria = err.IdProyectoEtapaInformacionPresupuestaria;
                            if (pr.IdProyectoEtapaInformacionPresupuestariaPeriodo <= 0)
                                ProyectoEtapaInformacionPresupuestariaPeriodoBusiness.Current.Add(p, contextUser);
                            else
                                ProyectoEtapaInformacionPresupuestariaPeriodoBusiness.Current.Update(p, contextUser);
                            pr.IdProyectoEtapaInformacionPresupuestariaPeriodo = p.IdProyectoEtapaInformacionPresupuestariaPeriodo;
                        }
                    }
                }
                #endregion

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }

            //Matias 20170131 - Ticket #REQ571729

            //FinMatias 20170131 - Ticket #REQ571729

        }
        public override void Delete(ProyectoCronogramaCompose entity, IContextUser contextUser)
        {
            foreach(ProyectoEtapaEstimadoResult i in entity.EtapasEstimadas )
                ProyectoEtapaEstimadoPeriodoBusiness.Current.Delete(new ProyectoEtapaEstimadoPeriodoFilter() { IdProyectoEtapaEstimado = i.IdProyectoEtapaEstimado }, contextUser);

            foreach (ProyectoEtapaRealizadoResult i in entity.EtapasRealizadas)
                ProyectoEtapaRealizadoPeriodoBusiness.Current.Delete(new ProyectoEtapaRealizadoPeriodoFilter() { IdProyectoEtapaRealizado = i.IdProyectoEtapaRealizado}, contextUser);

            foreach (ProyectoEtapaResult i in entity.Etapas)
            { 
                if(entity.EtapasEstimadas.Where(p => p.IdProyectoEtapa == i.IdProyectoEtapa).Count() > 0)
                    ProyectoEtapaEstimadoBusiness.Current.Delete(new ProyectoEtapaEstimadoFilter() { IdProyectoEtapa = i.IdProyectoEtapa }, contextUser);
                else
                    ProyectoEtapaRealizadoBusiness.Current.Delete(new ProyectoEtapaRealizadoFilter() { IdProyectoEtapa = i.IdProyectoEtapa }, contextUser);
            }

            ProyectoEtapaBusiness.Current.Delete(new ProyectoEtapaFilter() { IdProyecto = entity.IdProyecto }, contextUser);
        }
        public virtual int CopyProyectoCronogramaCompose(int oldId, int newId, int offset, ProyectoProductoIntermedioCompose EtapasReferencia, IContextUser contextUser)
        {
            ProyectoCronogramaCompose oldEntity = ProyectoCronogramaComposeBusiness.Current.GetById(oldId);
            ProyectoCronogramaCompose newEntity = ProyectoCronogramaComposeBusiness.Current.Copy(oldEntity, contextUser);
            newEntity.Proyecto = ProyectoBusiness.Current.GetResultFromList(new ProyectoFilter() { IdProyecto = newId }).FirstOrDefault();

            // TRADUCE LOS IDPROYECTOETAPA VIEJOS X NUEVOS
            Dictionary<int, int> OldIdNewId = new Dictionary<int,int>();
            foreach (ProyectoEtapaResult per in EtapasReferencia.Etapas)
                OldIdNewId.Add(per.IdCopyProyectoEtapa, per.IdProyectoEtapa);

            newEntity.Etapas = EtapasReferencia.Etapas;

            foreach (ProyectoEtapaEstimadoResult oee in newEntity.EtapasEstimadas)
            {
                oee.IdProyectoEtapaEstimado = 0;
                oee.IdProyectoEtapa = OldIdNewId[oee.IdProyectoEtapa];
                foreach (ProyectoEtapaEstimadoPeriodoResult poee in oee.Periodos)
                {
                    poee.IdProyectoEtapaEstimadoPeriodo = 0;
                    poee.IdProyectoEtapaEstimado = 0;
                    // Corrimiento
                    poee.Periodo = poee.Periodo + offset;
                }
            }
            //No se deben copiar
            //foreach (ProyectoEtapaRealizadoResult oer in newEntity.EtapasRealizadas)
            //{
            //    oer.IdProyectoEtapaRealizado = 0;
            //    oer.IdProyectoEtapa = OldIdNewId[oer.IdProyectoEtapa];
            //    foreach (ProyectoEtapaRealizadoPeriodoResult poer in oer.Periodos)
            //    {
            //        poer.IdProyectoEtapaRealizadoPeriodo = 0;
            //        poer.IdProyectoEtapaRealizado = 0;
            //        // Corrimiento
            //        poer.Periodo = poer.Periodo + offset;
            //    }
            //}

            ProyectoCronogramaComposeBusiness.current.Update(newEntity, contextUser);

            return newId;
        }
        private ProyectoCronogramaCompose Copy(ProyectoCronogramaCompose oldEntity, IContextUser contextUser)
        {
            ProyectoCronogramaCompose newEntity = new ProyectoCronogramaCompose();
            newEntity.Etapas = ProyectoEtapaBusiness.Current.CopiesResult(oldEntity.Etapas);
            foreach (ProyectoEtapaEstimadoResult re in oldEntity.EtapasEstimadas)
            {
                ProyectoEtapaEstimadoResult rex = ProyectoEtapaEstimadoBusiness.Current.CopyResult(re);
                rex.Periodos = ProyectoEtapaEstimadoPeriodoBusiness.Current.CopiesResult(re.Periodos);
                newEntity.EtapasEstimadas.Add(rex);
            }
            foreach (ProyectoEtapaRealizadoResult rr in oldEntity.EtapasRealizadas)
            {
                ProyectoEtapaRealizadoResult rrx = ProyectoEtapaRealizadoBusiness.Current.CopyResult(rr);
                rrx.Periodos = ProyectoEtapaRealizadoPeriodoBusiness.Current.CopiesResult(rr.Periodos);
                newEntity.EtapasRealizadas.Add(rrx);
            }
            return newEntity;
        }

        public List<CronogramaTotalPorAnio> GetTotalPorAnio (ProyectoFilter filter)
        {
            List<Int32> anios = ProyectoData.Current.AniosEstimadosRealizados(filter);
            anios.Sort();
            List<CronogramaTotalPorAnio> estimado=  ProyectoData.Current.GetTotalEstimadoPorAnio(filter);
            List<CronogramaTotalPorAnio> realizado= ProyectoData.Current.GetTotalRealizadoPorAnio(filter);
            List<CronogramaTotalPorAnio> EstimadoRealizado = estimado.Union (realizado ).ToList ();
            return (
                    from a in anios 
                    join _er in EstimadoRealizado on a equals _er.Anio into ter from er in ter.DefaultIfEmpty()
                    group er by new { Anio = a, NombreFase = er.NombreFase } into groupQuery
                    select new CronogramaTotalPorAnio ()
                    {
                        Anio = groupQuery.Key.Anio 
                        ,Estimado =  groupQuery.Sum (i=> i.Estimado) 
                        ,Realizado = groupQuery.Sum (i=> i.Realizado ) 
                        ,NombreFase = groupQuery.Key.NombreFase 
                    }
                ).OrderBy(i => i.NombreFase).ThenBy(i => i.Anio).ToList();

        }
        #endregion

        #region protected Methods
        private int idFaseAnterior; //nMatias 20170131 - Ticket #REQ571729

        #endregion

        #region Validations
        protected const string ID_PROCESO_EQ_BASICO = "ID_PROCESO_EQ_BASICO";

        public override void Validate(ProyectoCronogramaCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            //DataHelper.Validate(entity.ProyectoAnioCorriente != null, "Debe Seleccionar Año Corriente");
            DataHelper.Validate(entity.ProyectoAnioCorrienteEstimado != null, "Debe Seleccionar Año Corriente Estimado");
            DataHelper.Validate(entity.ProyectoAnioCorrienteRealizado != null, "Debe Seleccionar Año Corriente Realizado");
            foreach (ProyectoEtapaResult per in entity.Etapas)
            {
                ProyectoEtapa pe = per.ToEntity();
                pe.IdProyecto = entity.IdProyecto;
                ProyectoEtapaBusiness.Current.Validate(pe, actionName, contextUser, args);

                string error = "";
                DataHelper.Validate(ValidateEtapa(per, entity, ref error), error, "InvalidField");
            }

            foreach (ProyectoEtapaEstimadoResult peer in entity.EtapasEstimadas)
            {
                ProyectoEtapaEstimado pee = peer.ToEntity();
                ProyectoEtapaEstimadoBusiness.Current.Validate(pee, actionName, contextUser, args);

                DataHelper.Validate(ProyectoEtapaEstimadoBusiness.Current.ValidarEtapasEstimadas(peer, entity, peer.IdProyectoEtapaEstimado), "InvalidField", "InvalidField");
            }

            foreach (ProyectoEtapaRealizadoResult perr in entity.EtapasRealizadas)
            {
                ProyectoEtapaRealizado per = perr.ToEntity();
                ProyectoEtapaRealizadoBusiness.Current.Validate(per, actionName, contextUser, args);

                DataHelper.Validate(ProyectoEtapaRealizadoBusiness.Current.ValidarEtapasRealizadas(perr, entity, perr.IdProyectoEtapaRealizado), "InvalidField", "InvalidField");
            }
        }

        public bool ValidateEtapa(ProyectoEtapaResult ActualProyectoEtapa, ProyectoCronogramaCompose Entity, ref string error)
        {
            // Parametros
            Int32 idProcesoEquipamientoBasico = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_PROCESO_EQ_BASICO);

            // Controla el rango de fechas Estimadas
            //bool retval = ActualProyectoEtapa.FechaInicioEstimada != null && ActualProyectoEtapa.FechaFinEstimada != null;
            //if (!retval)
            //{
            //    error = SolutionContext.Current.TextManager.Translate("Rango estimado Obligatorio");
            //    return retval;
            //}

            bool retval = (ActualProyectoEtapa.FechaInicioEstimada ==null && ActualProyectoEtapa.FechaFinEstimada ==null) 
                || (  (ActualProyectoEtapa.FechaInicioEstimada !=null && ActualProyectoEtapa.FechaFinEstimada !=null) && 
                            ActualProyectoEtapa.FechaInicioEstimada <= ActualProyectoEtapa.FechaFinEstimada);           
            
            if (!retval)
            {
                error = SolutionContext.Current.TextManager.Translate("Rango Estimado Inválido");
                return retval;
            }

            //if ((ActualProyectoEtapa.FechaInicioEstimada != null) ^ (ActualProyectoEtapa.FechaFinEstimada != null))   //Matias 20170202 - Ticket #ER913481 
            if ((ActualProyectoEtapa.FechaInicioEstimada == null) || (ActualProyectoEtapa.FechaFinEstimada == null))    //Matias 20170202 - Ticket #ER913481 
            {
                retval = false;
                error = SolutionContext.Current.TextManager.Translate("Período Estimado inválido, falta una fecha del rango");
                return retval;
            }

            // Si EQ.Basico => dentro del mismo año
            if ((ActualProyectoEtapa.FechaInicioEstimada != null && ActualProyectoEtapa.FechaFinEstimada != null)       //Matias 20170202 - Ticket #ER913481 - Agregue validacion del NULL para evitar que se rompa.
                && Entity.ProyectoIdProceso == idProcesoEquipamientoBasico 
                && ((DateTime)ActualProyectoEtapa.FechaInicioEstimada).Year != ((DateTime)ActualProyectoEtapa.FechaFinEstimada).Year )
            {
                error = SolutionContext.Current.TextManager.Translate("Período Estimado inválido. El Equipamiento Básico debe ejecutarse dentro del mismo ejercicio (año)");
                return false;
            }



            // Controla que las etapas Estimadas esten en Rango
            foreach (ProyectoEtapaEstimadoResult peer in Entity.EtapasEstimadas.Where(ee => ee.IdProyectoEtapa == ActualProyectoEtapa.IdProyectoEtapa))
            {
                foreach (ProyectoEtapaEstimadoPeriodoResult ppp in peer.Periodos)
                {

                    if (ActualProyectoEtapa.FechaInicioEstimada != null && ActualProyectoEtapa.FechaFinEstimada != null)
                    {
                        if (ppp.MontoCalculado > 0 && ppp.Periodo < ((DateTime)ActualProyectoEtapa.FechaInicioEstimada).Year)                                         
                        {
                            retval = false;
                            error = SolutionContext.Current.TextManager.Translate("Período Estimado inválido, la fecha a modificar tiene gastos asociados previos.");
                            return retval;
                        }
                        if (ppp.MontoCalculado > 0 && ppp.Periodo > ((DateTime)ActualProyectoEtapa.FechaFinEstimada).Year)
                        {
                            retval = false;
                            error = SolutionContext.Current.TextManager.Translate("Período Estimado inválido, la fecha a modificar tiene gastos asociados posteriores.");
                            return retval;
                        }
                    }                    
                }
            }

            //if ((ActualProyectoEtapa.FechaInicioRealizada != null) ^ (ActualProyectoEtapa.FechaFinRealizada != null))
            if (ActualProyectoEtapa.FechaInicioRealizada == null && ActualProyectoEtapa.FechaFinRealizada != null)
            {
                retval = false;
                error = SolutionContext.Current.TextManager.Translate("Período Realizado inválido, falta la fecha de inicio");
                return retval;
            }

            // Controla el rango de fechas Realizadas
            if (ActualProyectoEtapa.FechaInicioRealizada != null && ActualProyectoEtapa.FechaFinRealizada != null)
                retval = retval && ActualProyectoEtapa.FechaInicioRealizada < ActualProyectoEtapa.FechaFinRealizada;
            if (!retval)
            {
                error = SolutionContext.Current.TextManager.Translate("Período Realizado inválido, la fecha de incio es mayor a la fecha de finalización");
                return retval;
            }



            // Controla que las etapas Estimadas esten en Rango
            foreach (ProyectoEtapaRealizadoResult peer in Entity.EtapasRealizadas.Where(ee => ee.IdProyectoEtapa == ActualProyectoEtapa.IdProyectoEtapa))
            {
                foreach (ProyectoEtapaRealizadoPeriodoResult ppp in peer.Periodos)
                {

                    if (ActualProyectoEtapa.FechaInicioRealizada != null && ActualProyectoEtapa.FechaFinRealizada != null)
                    {

                        if (ppp.MontoCalculado > 0 && ppp.Periodo < ((DateTime)ActualProyectoEtapa.FechaInicioRealizada).Year)
                        {
                            retval = false;
                            error = SolutionContext.Current.TextManager.Translate("Período Realizado inválido, la fecha a modificar tiene gastos asociados previos.");
                            return retval;
                        }
                        if (ppp.MontoCalculado > 0 && ppp.Periodo > ((DateTime)ActualProyectoEtapa.FechaFinRealizada).Year)
                        {
                            retval = false;
                            error = SolutionContext.Current.TextManager.Translate("Período Realizado inválido, la fecha a modificar tiene gastos asociados posteriores.");
                            return retval;
                        }
                    }
                }
            }

            //// Controla que las etapas Realizadas esten en Rango
            //foreach (ProyectoEtapaRealizadoResult perr in Entity.EtapasRealizadas.Where(ee => ee.IdProyectoEtapa == ActualProyectoEtapa.IdProyectoEtapa))
            //{
            //    foreach (ProyectoEtapaRealizadoPeriodoResult ppp in perr.Periodos)
            //    {
            //        if (ActualProyectoEtapa.FechaInicioRealizada != null && ppp.Periodo < ((DateTime)ActualProyectoEtapa.FechaInicioRealizada).Year)
            //            retval = false;
            //        if (ActualProyectoEtapa.FechaFinRealizada != null && ppp.Periodo > ((DateTime)ActualProyectoEtapa.FechaFinRealizada).Year)
            //            retval = false;
            //        if (!retval) break;
            //    }
            //    if (!retval) break;
            //}
            //if (!retval)
            //{
            //    error = SolutionContext.Current.TextManager.Translate("Período realizado inválido");
            //    return retval;
            //}
            return retval;
        }

        public override bool Can(ProyectoCronogramaCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            bool retval = true; // false;
            foreach (ProyectoEtapaResult per in entity.Etapas)
            {
                ProyectoEtapa pe = per.ToEntity();
                pe.IdProyecto = entity.IdProyecto;
                retval = retval && ProyectoEtapaBusiness.Current.Can(pe, actionName, contextUser, args);
            }

            foreach (ProyectoEtapaEstimadoResult peer in entity.EtapasEstimadas)
            {
                ProyectoEtapaEstimado pee = peer.ToEntity();
                retval = retval && ProyectoEtapaEstimadoBusiness.Current.Can(pee, actionName, contextUser, args);
            }

            foreach (ProyectoEtapaRealizadoResult perr in entity.EtapasRealizadas)
            {
                ProyectoEtapaRealizado per = perr.ToEntity();
                retval = retval && ProyectoEtapaRealizadoBusiness.Current.Can(per, actionName, contextUser, args);
            }
            return retval;
        }

        public override bool Equals(ProyectoCronogramaCompose source, ProyectoCronogramaCompose target)
        {
            bool eq = source.IdProyecto.Equals(target.IdProyecto);
            if (eq)
            {
                bool eqEt = true;

                if(target.Etapas.Count() != source.Etapas.Count()) return false;

                foreach (ProyectoEtapaResult per in source.Etapas)
                {
                    ProyectoEtapaResult perTarget = target.Etapas.Where(p => p.IdProyectoEtapa == per.IdProyectoEtapa).SingleOrDefault();

                    if (perTarget == null) return false;

                    eqEt = eqEt && per.Nombre == perTarget.Nombre
                                && per.CodigoVinculacion == perTarget.CodigoVinculacion
                                && per.IdEstado == perTarget.IdEstado
                                && per.FechaInicioEstimada == perTarget.FechaInicioEstimada
                                && per.FechaFinEstimada == perTarget.FechaFinEstimada
                                && per.FechaInicioRealizada == perTarget.FechaInicioRealizada
                                && per.FechaFinRealizada == perTarget.FechaFinRealizada
                                && per.IdEtapa == perTarget.IdEtapa
                                && per.IdProyecto == perTarget.IdProyecto;
                }

                if (!eqEt) return eqEt;


                bool eqEs = true;

                if( target.EtapasEstimadas.Count() != source.EtapasEstimadas.Count()) return false;

                foreach (ProyectoEtapaEstimadoResult perr in source.EtapasEstimadas)
                {
                    ProyectoEtapaEstimadoResult perrTarget = target.EtapasEstimadas.Where(g => g.IdProyectoEtapaEstimado == perr.IdProyectoEtapaEstimado).SingleOrDefault();

                    if (perrTarget == null) return false;
                    
                    eqEs = eqEs && perr.IdProyectoEtapa == perrTarget.IdProyectoEtapa && perr.IdProyectoEtapaEstimado == perrTarget.IdProyectoEtapaEstimado
                                  && perr.IdClasificacionGasto == perrTarget.IdClasificacionGasto
                                  && perr.IdFuenteFinanciamiento == perrTarget.IdFuenteFinanciamiento
                                  //&& perr.IdProyectoOrigenFinanciamiento == perrTarget.IdProyectoOrigenFinanciamiento
                                  && perr.IdMoneda == perrTarget.IdMoneda;
                    if (eqEs)
                    {
                        if (perr.Periodos.Count != perrTarget.Periodos.Count) return false;

                        foreach (ProyectoEtapaEstimadoPeriodoResult per in perr.Periodos)
                        {
                            ProyectoEtapaEstimadoPeriodo a = per.ToEntity();
                            if (perrTarget.Periodos.Where(p => p.IdProyectoEtapaEstimadoPeriodo == per.IdProyectoEtapaEstimadoPeriodo) != null)
                            {
                                ProyectoEtapaEstimadoPeriodoResult c = perrTarget.Periodos.Where(p => p.IdProyectoEtapaEstimadoPeriodo == per.IdProyectoEtapaEstimadoPeriodo).SingleOrDefault();

                                if (c == null) return false;

                                ProyectoEtapaEstimadoPeriodo b = c.ToEntity();

                                eqEs = eqEs && a.IdProyectoEtapaEstimadoPeriodo == b.IdProyectoEtapaEstimadoPeriodo &&
                                                 a.IdProyectoEtapaEstimado == b.IdProyectoEtapaEstimado &&
                                                 a.Monto == b.Monto && a.MontoCalculado == b.MontoCalculado &&
                                                 a.Periodo == b.Periodo && a.Cotizacion == b.Cotizacion;
                            }
                        }
                    }
                    else
                        break;
                }


                bool eqRel = true;

                if(target.EtapasRealizadas.Count() != source.EtapasRealizadas.Count()) return false;

                foreach (ProyectoEtapaRealizadoResult perr in source.EtapasRealizadas)
                {
                    ProyectoEtapaRealizadoResult perrTarget = target.EtapasRealizadas.Where(g => g.IdProyectoEtapaRealizado == perr.IdProyectoEtapaRealizado).SingleOrDefault();

                    if (perrTarget == null) return false;
                    
                    eqRel = eqRel && perr.IdProyectoEtapa == perrTarget.IdProyectoEtapa && perr.IdProyectoEtapaRealizado == perrTarget.IdProyectoEtapaRealizado
                                  && perr.IdClasificacionGasto == perrTarget.IdClasificacionGasto
                                  && perr.IdFuenteFinanciamiento == perrTarget.IdFuenteFinanciamiento
                                  //&& perr.IdProyectoOrigenFinanciamiento == perrTarget.IdProyectoOrigenFinanciamiento
                                  && perr.IdMoneda == perrTarget.IdMoneda;
                    if (eqRel)
                    {
                        if (perr.Periodos.Count != perrTarget.Periodos.Count) return false;

                        foreach (ProyectoEtapaRealizadoPeriodoResult per in perr.Periodos)
                        {
                            ProyectoEtapaRealizadoPeriodo a = per.ToEntity();
                            if (perrTarget.Periodos.Where(p => p.IdProyectoEtapaRealizadoPeriodo == per.IdProyectoEtapaRealizadoPeriodo) != null)
                            {
                                ProyectoEtapaRealizadoPeriodoResult c = perrTarget.Periodos.Where(p => p.IdProyectoEtapaRealizadoPeriodo == per.IdProyectoEtapaRealizadoPeriodo).SingleOrDefault();

                                if (c == null) return false;

                                ProyectoEtapaRealizadoPeriodo b = c.ToEntity();

                                eqRel = eqRel && a.IdProyectoEtapaRealizadoPeriodo == b.IdProyectoEtapaRealizadoPeriodo &&
                                                 a.IdProyectoEtapaRealizado == b.IdProyectoEtapaRealizado &&
                                                 a.Monto == b.Monto &&  a.MontoCalculado == b.MontoCalculado &&
                                                 a.Periodo == b.Periodo && a.Cotizacion == b.Cotizacion && a.Fecha == b.Fecha;
                            }
                        }
                    }
                    else
                        break;
                }

                eq = eqEt && eqRel && eqEs;
            }
            return eq;
        }
        #endregion
    }
}
