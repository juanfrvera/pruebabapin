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
     
    public class ProyectoEvaluacionComposeBusiness : EntityComposeBusiness<ProyectoEvaluacionCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoEvaluacionComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoEvaluacionComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEvaluacionComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override int GetId(ProyectoEvaluacionCompose entity)
        {
            return entity.IdProyecto;
        }

        public override ProyectoEvaluacionCompose GetById(int id)
        {
           
            ProyectoEvaluacionCompose proyectoEvaluacionCompose = new ProyectoEvaluacionCompose();
            proyectoEvaluacionCompose.Proyecto = ProyectoBusiness.Current.GetResultFromListWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();
            
            //Proyecto Evaluacion

            proyectoEvaluacionCompose.Evaluacion = ProyectoEvaluacionBusiness.Current.GetResult(new ProyectoEvaluacionFilter() { Id_Proyecto = id }).FirstOrDefault();


            proyectoEvaluacionCompose.IndicadoresEconomico = ProyectoIndicadorEconomicoBusiness.Current.GetResult(new ProyectoIndicadorEconomicoFilter() { IdProyecto = id }).ToList();
            proyectoEvaluacionCompose.IndicadoresPriorizacion = ProyectoIndicadorPriorizacionBusiness.Current.GetResult(new ProyectoIndicadorPriorizacionFilter() { IdProyecto = id }).ToList();
            proyectoEvaluacionCompose.IndicadoresObjetivosGobierno = ProyectoIndicadorObjetivosGobiernoBusiness.Current.GetResult(new ProyectoIndicadorObjetivosGobiernoFilter() { IdProyecto = id }).ToList();


            // ProyectoBeneficiarioIndicador
            List<ProyectoBeneficiarioIndicadorResult> pbi = 
                ProyectoBeneficiarioIndicadorBusiness.Current.GetResult(new ProyectoBeneficiarioIndicadorFilter() { IdProyecto = id }).ToList();

            /*pbi.ForEach( p => proyectoEvaluacionCompose.IndicadoresBeneficiario.Add(
                ProyectoBeneficiarioIndicadorComposeBusiness.Current.GetById(p.IdProyectoBeneficiarioIndicador)));*/
            foreach (ProyectoBeneficiarioIndicadorResult pbiItem in pbi)
            {
                ProyectoBeneficiarioIndicadorCompose pbic = ProyectoBeneficiarioIndicadorComposeBusiness.Current.GetById(pbiItem.IdProyectoBeneficiarioIndicador);
                pbic.Indicador = pbiItem;
                //pbic.Indicador.IdProyecto = pbiItem.IdProyecto;
                //pbic.Indicador.IdProyectoBeneficiarioIndicador = pbiItem.IdProyectoBeneficiarioIndicador;
                proyectoEvaluacionCompose.IndicadoresBeneficiario.Add(pbic);
            }

            // ProyectoBeneficioIndicador

            List<ProyectoBeneficioIndicadorResult> pbo =
                ProyectoBeneficioIndicadorBusiness.Current.GetResult(new ProyectoBeneficioIndicadorFilter() { IdProyecto = id }).ToList();

            pbo.ForEach(p => proyectoEvaluacionCompose.IndicadoresBeneficio.Add(
                ProyectoBeneficioIndicadorComposeBusiness.Current.GetById(p.IdProyectoBeneficioIndicador)));

            // ProyectoEvaluacionSectorialIndicador

            List<ProyectoEvaluacionSectorialIndicadorResult> pbs =
                ProyectoEvaluacionSectorialIndicadorBusiness.Current.GetResult(new ProyectoEvaluacionSectorialIndicadorFilter() { IdProyecto = id }).ToList();

            pbs.ForEach(p => proyectoEvaluacionCompose.IndicadoresEvaluacionSectorial.Add(
                ProyectoEvaluacionSectorialIndicadorComposeBusiness.Current.GetById(p.IdProyectoEvaluacionSectorialIndicador)));  

            return proyectoEvaluacionCompose;

        }

        public ProyectoEvaluacionCompose GetByIdForCopy(int id, int newId)
        {

            ProyectoEvaluacionCompose proyectoEvaluacionCompose = new ProyectoEvaluacionCompose();

            

            //Proyecto Evaluacion

            proyectoEvaluacionCompose.Evaluacion = ProyectoEvaluacionBusiness.Current.GetResult(new ProyectoEvaluacionFilter() { Id_Proyecto = id }).FirstOrDefault();

            proyectoEvaluacionCompose.IndicadoresEconomico = ProyectoIndicadorEconomicoBusiness.Current.GetResult(new ProyectoIndicadorEconomicoFilter() { IdProyecto = id }).ToList();

            proyectoEvaluacionCompose.IndicadoresEconomico.ForEach(p => p.IdProyecto = newId);

            proyectoEvaluacionCompose.IndicadoresPriorizacion = ProyectoIndicadorPriorizacionBusiness.Current.GetResult(new ProyectoIndicadorPriorizacionFilter() { IdProyecto = id }).ToList();

            proyectoEvaluacionCompose.IndicadoresPriorizacion.ForEach(p => p.IdProyecto = newId);

            proyectoEvaluacionCompose.IndicadoresObjetivosGobierno = ProyectoIndicadorObjetivosGobiernoBusiness.Current.GetResult(new ProyectoIndicadorObjetivosGobiernoFilter() { IdProyecto = id }).ToList();

            proyectoEvaluacionCompose.IndicadoresObjetivosGobierno.ForEach(p => p.IdProyecto = newId);

            // ProyectoBeneficiarioIndicador

            List<ProyectoBeneficiarioIndicadorResult> pbiList =
                ProyectoBeneficiarioIndicadorBusiness.Current.GetResult(new ProyectoBeneficiarioIndicadorFilter() { IdProyecto = id }).ToList();

            foreach (ProyectoBeneficiarioIndicadorResult pbi in pbiList)
            {
                ProyectoBeneficiarioIndicadorCompose pbic =
                ProyectoBeneficiarioIndicadorComposeBusiness.Current.GetByIdForCopy(pbi.IdProyectoBeneficiarioIndicador);
                pbic.Indicador.IdProyecto = newId;
                proyectoEvaluacionCompose.IndicadoresBeneficiario.Add(pbic);
            }

     
            List<ProyectoBeneficioIndicadorResult> pboList =
                ProyectoBeneficioIndicadorBusiness.Current.GetResult(new ProyectoBeneficioIndicadorFilter() { IdProyecto = id }).ToList();

            foreach (ProyectoBeneficioIndicadorResult pbo in pboList)
            {
                ProyectoBeneficioIndicadorCompose pboc =
                ProyectoBeneficioIndicadorComposeBusiness.Current.GetByIdForCopy(pbo.IdProyectoBeneficioIndicador);
                pboc.Indicador.IdProyecto = newId;
                proyectoEvaluacionCompose.IndicadoresBeneficio.Add(pboc);
            }
            proyectoEvaluacionCompose.Proyecto = ProyectoBusiness.Current.GetResultFromList(new ProyectoFilter() { IdProyecto = newId }).FirstOrDefault();
            return proyectoEvaluacionCompose;

        }

        #region Actions
        public override void Add(ProyectoEvaluacionCompose entity, IContextUser contextUser)
        {

  
            // Indicador Economico

            foreach (ProyectoIndicadorEconomicoResult pier in entity.IndicadoresEconomico)
            {
                pier.IdProyecto = entity.IdProyecto;
                ProyectoIndicadorEconomicoBusiness.Current.Add(pier.ToEntity(), contextUser);
            }

            // Indicador Priorizacion

            foreach (ProyectoIndicadorPriorizacionResult pipr in entity.IndicadoresPriorizacion)
            {
                pipr.IdProyecto = entity.IdProyecto;
                ProyectoIndicadorPriorizacionBusiness.Current.Add(pipr.ToEntity(), contextUser);
            }

            // Indicador ObjetivosGobierno

            foreach (ProyectoIndicadorObjetivosGobiernoResult pipr in entity.IndicadoresObjetivosGobierno)
            {
                pipr.IdProyecto = entity.IdProyecto;
                ProyectoIndicadorObjetivosGobiernoBusiness.Current.Add(pipr.ToEntity(), contextUser);
            }

            // Indicador Beneficio

            foreach (ProyectoBeneficioIndicadorCompose  pbic in entity.IndicadoresBeneficio)
            {
                pbic.Indicador.IdProyecto = entity.IdProyecto;
                ProyectoBeneficioIndicadorComposeBusiness.Current.Add(pbic, contextUser);
            }

            // Indicador Beneficiario

            foreach (ProyectoBeneficiarioIndicadorCompose pbic in entity.IndicadoresBeneficiario)
            {
                pbic.Indicador.IdProyecto = entity.IdProyecto;
                ProyectoBeneficiarioIndicadorComposeBusiness.Current.Add(pbic, contextUser);
            }

            //Agrego ProyectoEvaluacion

            entity.Evaluacion.Id_Proyecto = entity.IdProyecto;
            ProyectoEvaluacionBusiness.Current.Add(entity.Evaluacion.ToEntity(), contextUser);

            

            

        }
        public override void Update(ProyectoEvaluacionCompose entity, IContextUser contextUser)
        {

                // Modifico Proyecto Evaluacion
                ProyectoEvaluacion pe = entity.Evaluacion.ToEntity();
                pe.Id_Proyecto = entity.IdProyecto;
                if (entity.Evaluacion.Id_ProyectoEvaluacion <= 0)
                {
                    ProyectoEvaluacionBusiness.Current.Add(pe, contextUser);
                }
                else
                    ProyectoEvaluacionBusiness.Current.Update(pe, contextUser);

                entity.Evaluacion.Id_ProyectoEvaluacion = pe.Id_ProyectoEvaluacion;


                // ProyectoIndicadorEconomico

                List<int> actualProyectoIndicadorEconomicoIds = (from o in entity.IndicadoresEconomico where o.IdProyectoIndicadorEconomico > 0 select o.IdProyectoIndicadorEconomico).ToList();
                List<ProyectoIndicadorEconomico> oldProyectoIndicadorEconomicoDetail = ProyectoIndicadorEconomicoBusiness.Current.GetList(new ProyectoIndicadorEconomicoFilter() { IdProyecto = entity.IdProyecto });
                List<int> deleteProyectoIndicadorEconomicoIds = (from o in oldProyectoIndicadorEconomicoDetail where !actualProyectoIndicadorEconomicoIds.Contains(o.IdProyectoIndicadorEconomico) select o.IdProyectoIndicadorEconomico).ToList();
                ProyectoIndicadorEconomicoBusiness.Current.Delete(deleteProyectoIndicadorEconomicoIds.ToArray(), contextUser);


                foreach (ProyectoIndicadorEconomicoResult ivr in entity.IndicadoresEconomico)
                {

                    if (ivr.IdProyectoIndicadorEconomico < 1)
                    {
                        ivr.IdProyecto = entity.IdProyecto;
                        ProyectoIndicadorEconomicoBusiness.Current.Add(ivr.ToEntity(), contextUser);
                    }
                    else
                    {
                        ProyectoIndicadorEconomicoBusiness.Current.Update(ivr.ToEntity(), contextUser);
                    }
                }


                // ProyectoIndicadorPriorizacion

                List<int> actualProyectoIndicadorPriorizacionIds = (from o in entity.IndicadoresPriorizacion where o.IdProyectoIndicadorPriorizacion > 0 select o.IdProyectoIndicadorPriorizacion).ToList();
                List<ProyectoIndicadorPriorizacion> oldProyectoIndicadorPriorizacionDetail = ProyectoIndicadorPriorizacionBusiness.Current.GetList(new ProyectoIndicadorPriorizacionFilter() { IdProyecto = entity.IdProyecto });
                List<int> deleteProyectoIndicadorPriorizacionIds = (from o in oldProyectoIndicadorPriorizacionDetail where !actualProyectoIndicadorPriorizacionIds.Contains(o.IdProyectoIndicadorPriorizacion) select o.IdProyectoIndicadorPriorizacion).ToList();
                ProyectoIndicadorPriorizacionBusiness.Current.Delete(deleteProyectoIndicadorPriorizacionIds.ToArray(), contextUser);


                foreach (ProyectoIndicadorPriorizacionResult ivr in entity.IndicadoresPriorizacion)
                {

                    if (ivr.IdProyectoIndicadorPriorizacion < 1)
                    {
                        ivr.IdProyecto = entity.IdProyecto;
                        ProyectoIndicadorPriorizacionBusiness.Current.Add(ivr.ToEntity(), contextUser);
                    }
                    else
                    {
                        ProyectoIndicadorPriorizacionBusiness.Current.Update(ivr.ToEntity(), contextUser);
                    }
                }

                // ProyectoIndicadorObjetivosGobierno

                List<int> actualProyectoIndicadorObjetivosGobiernoIds = (from o in entity.IndicadoresObjetivosGobierno where o.IdProyectoIndicadorObjetivosGobierno > 0 select o.IdProyectoIndicadorObjetivosGobierno).ToList();
                List<ProyectoIndicadorObjetivosGobierno> oldProyectoIndicadorObjetivosGobiernoDetail = ProyectoIndicadorObjetivosGobiernoBusiness.Current.GetList(new ProyectoIndicadorObjetivosGobiernoFilter() { IdProyecto = entity.IdProyecto });
                List<int> deleteProyectoIndicadorObjetivosGobiernoIds = (from o in oldProyectoIndicadorObjetivosGobiernoDetail where !actualProyectoIndicadorObjetivosGobiernoIds.Contains(o.IdProyectoIndicadorObjetivosGobierno) select o.IdProyectoIndicadorObjetivosGobierno).ToList();
                ProyectoIndicadorObjetivosGobiernoBusiness.Current.Delete(deleteProyectoIndicadorObjetivosGobiernoIds.ToArray(), contextUser);


                foreach (ProyectoIndicadorObjetivosGobiernoResult ivr in entity.IndicadoresObjetivosGobierno)
                {

                    if (ivr.IdProyectoIndicadorObjetivosGobierno < 1)
                    {
                        ivr.IdProyecto = entity.IdProyecto;
                        ProyectoIndicadorObjetivosGobiernoBusiness.Current.Add(ivr.ToEntity(), contextUser);
                    }
                    else
                    {
                        ProyectoIndicadorObjetivosGobiernoBusiness.Current.Update(ivr.ToEntity(), contextUser);
                    }
                }

                // ProyectoBeneficiarioIndicadorCompose


			    List<int> actualProyectoBeneficiarioIndicadorIds = (from o in entity.IndicadoresBeneficiario 
                                                                    where o.Indicador.IdProyectoBeneficiarioIndicador > 0 
                                                                    select o.Indicador.IdProyectoBeneficiarioIndicador).ToList();
                
                List< ProyectoBeneficiarioIndicador> oldProyectoBeneficiarioIndicadorDetail =  
                    ProyectoBeneficiarioIndicadorBusiness.Current.GetList(new  ProyectoBeneficiarioIndicadorFilter() { IdProyecto = entity.IdProyecto });
                
                List<int> deleteProyectoBeneficiarioIndicadorIds = (from o in oldProyectoBeneficiarioIndicadorDetail 
                                                                    where !actualProyectoBeneficiarioIndicadorIds.Contains(o.IdProyectoBeneficiarioIndicador) 
                                                                    select o.IdProyectoBeneficiarioIndicador).ToList();

                ProyectoBeneficiarioIndicadorComposeBusiness.Current.Delete(deleteProyectoBeneficiarioIndicadorIds.ToArray(), contextUser);


                foreach (ProyectoBeneficiarioIndicadorCompose pbic in entity.IndicadoresBeneficiario)
                {
                    if (pbic.Indicador.IdProyectoBeneficiarioIndicador < 1)
                    {
                        pbic.Indicador.IdProyecto = entity.IdProyecto;
                        ProyectoBeneficiarioIndicadorComposeBusiness.Current.Add(pbic, contextUser);
                    }
                    else
                    {
                        ProyectoBeneficiarioIndicadorComposeBusiness.Current.Update(pbic, contextUser);
                    }
                }

                // ProyectoBeneficioIndicadorCompose

                List<int> actualProyectoBeneficioIndicadorIds = (from o in entity.IndicadoresBeneficio
                                                                 where o.Indicador.IdProyectoBeneficioIndicador > 0
                                                                 select o.Indicador.IdProyectoBeneficioIndicador).ToList();

                List<ProyectoBeneficioIndicador> oldProyectoBeneficioIndicadorDetail =
                    ProyectoBeneficioIndicadorBusiness.Current.GetList(new ProyectoBeneficioIndicadorFilter() { IdProyecto = entity.IdProyecto });

                List<int> deleteProyectoBeneficioIndicadorIds = (from o in oldProyectoBeneficioIndicadorDetail
                                                                 where !actualProyectoBeneficioIndicadorIds.Contains(o.IdProyectoBeneficioIndicador)
                                                                 select o.IdProyectoBeneficioIndicador).ToList();

                ProyectoBeneficioIndicadorComposeBusiness.Current.Delete(deleteProyectoBeneficioIndicadorIds.ToArray(), contextUser);

                foreach (ProyectoBeneficioIndicadorCompose pbic in entity.IndicadoresBeneficio)
                {
                    if (pbic.Indicador.IdProyectoBeneficioIndicador < 1)
                    {
                        pbic.Indicador.IdProyecto = entity.IdProyecto;
                        ProyectoBeneficioIndicadorComposeBusiness.Current.Add(pbic, contextUser);
                    }
                    else
                    {
                        ProyectoBeneficioIndicadorComposeBusiness.Current.Update(pbic, contextUser);
                    }
                }

                // ProyectoEvaluacionSectorialIndicadorCompose

                List<int> actualProyectoEvaluacionSectorialIndicadorIds = (from o in entity.IndicadoresEvaluacionSectorial
                                                                 where o.Indicador.IdProyectoEvaluacionSectorialIndicador > 0
                                                                 select o.Indicador.IdProyectoEvaluacionSectorialIndicador).ToList();

                List<ProyectoEvaluacionSectorialIndicador> oldProyectoEvaluacionSectorialIndicadorDetail =
                    ProyectoEvaluacionSectorialIndicadorBusiness.Current.GetList(new ProyectoEvaluacionSectorialIndicadorFilter() { IdProyecto = entity.IdProyecto });

                List<int> deleteProyectoEvaluacionSectorialIndicadorIds = (from o in oldProyectoEvaluacionSectorialIndicadorDetail
                                                                 where !actualProyectoEvaluacionSectorialIndicadorIds.Contains(o.IdProyectoEvaluacionSectorialIndicador)
                                                                 select o.IdProyectoEvaluacionSectorialIndicador).ToList();

                ProyectoEvaluacionSectorialIndicadorComposeBusiness.Current.Delete(deleteProyectoEvaluacionSectorialIndicadorIds.ToArray(), contextUser);

                foreach (ProyectoEvaluacionSectorialIndicadorCompose pbic in entity.IndicadoresEvaluacionSectorial)
                {
                    if (pbic.Indicador.IdProyectoEvaluacionSectorialIndicador < 1)
                    {
                        pbic.Indicador.IdProyecto = entity.IdProyecto;
                        ProyectoEvaluacionSectorialIndicadorComposeBusiness.Current.Add(pbic, contextUser);
                    }
                    else
                    {
                        ProyectoEvaluacionSectorialIndicadorComposeBusiness.Current.Update(pbic, contextUser);
                    }
                }


                //Matias 20131106 - Tarea 80
                ProyectoBusiness.Current.updateFechaUltimaModificacion(entity.IdProyecto, contextUser);
                //FinMatias 20131106 - Tarea 80
                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;    
        }
        public override void Delete(ProyectoEvaluacionCompose entity, IContextUser contextUser)
        {
            ProyectoEvaluacionBusiness.Current.Delete(entity.Evaluacion.Id_ProyectoEvaluacion, contextUser);
        }



        public virtual int CopyAndSave(int oldId, int newId, IContextUser contextUser)
        {

            ProyectoEvaluacionCompose pec = GetByIdForCopy(oldId, newId);
            if (pec.Evaluacion != null)
            {
                ProyectoEvaluacionComposeBusiness.current.Add(pec, contextUser);
                return 0;
            }
            return newId;

        }
        #endregion

        #region protected Methods
        protected override EntityBusiness<Proyecto, ProyectoFilter, ProyectoResult, int> EntityBusinessBase
        {
            get { return ProyectoBusiness.Current; }
        }

        #endregion

        #region Validations

        public override void Validate(ProyectoEvaluacionCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {

            
            foreach (ProyectoBeneficiarioIndicadorCompose pbic in entity.IndicadoresBeneficiario)
            {
                ProyectoBeneficiarioIndicadorComposeBusiness.Current.Validate(pbic, actionName, contextUser, args);
            }

            foreach (ProyectoBeneficioIndicadorCompose pboic in entity.IndicadoresBeneficio)
            {
                ProyectoBeneficioIndicadorComposeBusiness.Current.Validate(pboic, actionName, contextUser, args);
            }            
        }

        public override bool Can(ProyectoEvaluacionCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        #endregion

        public override bool Equals(ProyectoEvaluacionCompose source, ProyectoEvaluacionCompose target)
        {

            if (source.IndicadoresEconomico.Count() != target.IndicadoresEconomico.Count()) return false;

            foreach (ProyectoIndicadorEconomicoResult pier in source.IndicadoresEconomico)            
            {
                ProyectoIndicadorEconomicoResult pierTarget = target.IndicadoresEconomico.Where(p => p.IdProyectoIndicadorEconomico
                    == pier.IdProyectoIndicadorEconomico).SingleOrDefault();
                if (pierTarget == null) return false;

                if (!ProyectoIndicadorEconomicoBusiness.Current.Equals(pier, pierTarget)) return false;
            }

            if (source.IndicadoresPriorizacion.Count() != target.IndicadoresPriorizacion.Count()) return false;


            foreach (ProyectoIndicadorPriorizacionResult pipr in source.IndicadoresPriorizacion)
            {
                ProyectoIndicadorPriorizacionResult piprTarget = target.IndicadoresPriorizacion.Where(p => p.IdProyectoIndicadorPriorizacion
                    == pipr.IdProyectoIndicadorPriorizacion).SingleOrDefault();
                if (piprTarget == null) return false;

                if (!ProyectoIndicadorPriorizacionBusiness.Current.Equals(pipr, piprTarget)) return false;
            }

            if (source.IndicadoresObjetivosGobierno.Count() != target.IndicadoresObjetivosGobierno.Count()) return false;


            foreach (ProyectoIndicadorObjetivosGobiernoResult pipr in source.IndicadoresObjetivosGobierno)
            {
                ProyectoIndicadorObjetivosGobiernoResult piprTarget = target.IndicadoresObjetivosGobierno.Where(p => p.IdProyectoIndicadorObjetivosGobierno
                    == pipr.IdProyectoIndicadorObjetivosGobierno).SingleOrDefault();
                if (piprTarget == null) return false;

                if (!ProyectoIndicadorObjetivosGobiernoBusiness.Current.Equals(pipr, piprTarget)) return false;
            }

            if (!ProyectoEvaluacionBusiness.Current.Equals(source.Evaluacion, target.Evaluacion)) return false;

            if (source.IndicadoresBeneficiario.Count() != target.IndicadoresBeneficiario.Count()) return false;

            foreach (ProyectoBeneficiarioIndicadorCompose pbic in source.IndicadoresBeneficiario)
            {
                ProyectoBeneficiarioIndicadorCompose pbicTarget = target.IndicadoresBeneficiario.Where(p => p.Indicador.IdProyectoBeneficiarioIndicador
                    == pbic.Indicador.IdProyectoBeneficiarioIndicador).SingleOrDefault();
                if (pbicTarget == null) return false;

                if (!ProyectoBeneficiarioIndicadorComposeBusiness.Current.Equals(pbic, pbicTarget)) return false;
            }

            if (source.IndicadoresBeneficio.Count() != target.IndicadoresBeneficio.Count()) return false;

            foreach (ProyectoBeneficioIndicadorCompose pbisc in source.IndicadoresBeneficio)
            {
                ProyectoBeneficioIndicadorCompose pbiscTarget = target.IndicadoresBeneficio.Where(p => p.Indicador.IdProyectoBeneficioIndicador
                    == pbisc.Indicador.IdProyectoBeneficioIndicador).SingleOrDefault();
                if (pbiscTarget == null) return false;

                if (!ProyectoBeneficioIndicadorComposeBusiness.Current.Equals(pbisc, pbiscTarget)) return false;
            }    


            return true;
        }
    }
}
