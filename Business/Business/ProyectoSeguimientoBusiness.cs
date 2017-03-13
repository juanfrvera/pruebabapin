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
    public class ProyectoSeguimientoBusiness : _ProyectoSeguimientoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoSeguimientoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoBusiness() {}
	   public static ProyectoSeguimientoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override void Delete(int id, IContextUser contextUser)
       {
           ProyectoSeguimientoProyectoBusiness.Current.Delete(new ProyectoSeguimientoProyectoFilter() { IdProyectoSeguimiento = id}, contextUser);
           ProyectoSeguimientoFileBusiness.Current.Delete(new ProyectoSeguimientoFileFilter() { IdProyectoSeguimiento = id }, contextUser);
           ProyectoSeguimientoLocalizacionBusiness.Current.Delete(new ProyectoSeguimientoLocalizacionFilter() { IdProyectoSeguimiento = id }, contextUser);
           ProyectoSeguimiento ps = GetById(id);
           ps.IdProyectoSeguimientoEstadoUltimo = null;
           Update(ps, contextUser);
           ProyectoSeguimientoEstadoBusiness.Current.Delete(new ProyectoSeguimientoEstadoFilter() { IdProyectoSeguimiento = id }, contextUser);
           base.Delete(id, contextUser);
       }
       
    }

    public class ProyectoSeguimientoComposeBusiness : EntityComposeBusiness<ProyectoSeguimientoCompose, ProyectoSeguimiento, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int>
    {
        #region Singleton
        private static volatile ProyectoSeguimientoComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoSeguimientoComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoSeguimientoComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<ProyectoSeguimiento, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int> EntityBusinessBase
        {
            get { return ProyectoSeguimientoBusiness.Current; }
        }
        #region Gets
        public override ProyectoSeguimientoCompose GetNew(ProyectoSeguimientoResult example)
        {
            ProyectoSeguimientoCompose compose = base.GetNew();
            compose.ProyectoSeguimiento = example;
            compose.ProyectoSeguimientoLocalizacion = AlcanceGeograficoToProyectoSeguimientoLocalizacion();
            return compose;
        }
        public override ProyectoSeguimientoCompose GetNew()
        {
            ProyectoSeguimientoResult example = new ProyectoSeguimientoResult();
            ProyectoSeguimientoBusiness.Current.Set(ProyectoSeguimientoBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
        public override int GetId(ProyectoSeguimientoCompose entity)
        {
            return entity.ProyectoSeguimiento.IdProyectoSeguimiento;
        }
        public override ProyectoSeguimientoCompose GetById(int id)
        {
            ProyectoSeguimientoCompose compose = new ProyectoSeguimientoCompose();
            compose.ProyectoSeguimiento = ProyectoSeguimientoBusiness.Current.GetResult(new ProyectoSeguimientoFilter() { IdProyectoSeguimiento = id }).SingleOrDefault();
            compose.ProyectoSeguimientoEstado = ProyectoSeguimientoEstadoBusiness.Current.GetResult(new ProyectoSeguimientoEstadoFilter() { IdProyectoSeguimiento = id }).OrderByDescending(i => i.Fecha).ToList ();
            compose.ProyectoSeguimientoLocalizacion = AlcanceGeograficoToProyectoSeguimientoLocalizacion(id); ;
            compose.ProyectoSeguimientoProyecto = ProyectoSeguimientoProyectoBusiness.Current.GetResult(new ProyectoSeguimientoProyectoFilter() { IdProyectoSeguimiento = id });
            return compose;
        }


        #endregion

        #region Actions
        public override void Add(ProyectoSeguimientoCompose entity, IContextUser contextUser)
        {
        
                //Crea el ProyectoSeguimiento
                ProyectoSeguimiento proyectoSeguimiento = entity.ProyectoSeguimiento.ToEntity();
                ProyectoSeguimientoBusiness.Current.Add(proyectoSeguimiento, contextUser);
                entity.ProyectoSeguimiento.IdProyectoSeguimiento = proyectoSeguimiento.IdProyectoSeguimiento;

                foreach (ProyectoSeguimientoProyectoResult  pspr in entity.ProyectoSeguimientoProyecto )
                {
                    pspr.IdProyectoSeguimiento = entity.ProyectoSeguimiento.IdProyectoSeguimiento;
                    ProyectoSeguimientoProyecto psp = pspr.ToEntity();
                    ProyectoSeguimientoProyectoBusiness.Current.Add(psp, contextUser);
                    pspr.IdProyectoSeguimientoProyecto = psp.IdProyectoSeguimientoProyecto;
                }
                foreach (ProyectoSeguimientoLocalizacionResult pslr in entity.ProyectoSeguimientoLocalizacion)
                {
                    if (pslr.Selected)
                    {
                        pslr.IdProyectoSeguimiento = entity.ProyectoSeguimiento.IdProyectoSeguimiento;
                        ProyectoSeguimientoLocalizacion psl = pslr.ToEntity();
                        ProyectoSeguimientoLocalizacionBusiness.Current.Add(psl, contextUser);
                        pslr.IdProyectoSeguimientoLocalizacion = psl.IdProyectoSeguimientoLocalizacion; 
                    }
                }
                ProyectoSeguimientoProyectoResult p = entity.ProyectoSeguimientoProyecto.FirstOrDefault();
                Int32? IdProyecto = p != null ? p.IdProyecto : null as Int32?;
                ComentarioTecnico c = ComentarioTecnicoBusiness.Current.FirstOrDefault(new ComentarioTecnicoFilter ());
                Int32? IdComentarioTecnico = c!=null? c.IdComentarioTecnico : null as Int32? ;
                foreach (ProyectoSeguimientoEstadoResult pser in entity.ProyectoSeguimientoEstado)
                {
                    pser.IdProyectoSeguimiento = entity.ProyectoSeguimiento.IdProyectoSeguimiento;
                    ProyectoSeguimientoEstado pse = pser.ToEntity();
                    ProyectoSeguimientoEstadoBusiness.Current.Add(pse, contextUser);
                    pser.IdProyectoSeguimientoEstado = pse.IdProyectoSeguimientoEstado; 
                    
                    GenerarComentarioTecnico(pser,IdProyecto,IdComentarioTecnico , contextUser);
                    GenerarMensaje(pser, IdProyecto, entity.ProyectoSeguimientoProyecto.Select(i => i.IdProyecto).ToList(), contextUser);
                }

                if (entity.ProyectoSeguimientoEstado.Count() > 0)
                {
                    if (!entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo.HasValue)
                    {
                        //entity.ProyectoSeguimientoEstado.OrderByDescending(i => i.Fecha);
                        entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo = entity.ProyectoSeguimientoEstado.Last().IdProyectoSeguimientoEstado;
                        proyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo = entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo;
                        ProyectoSeguimientoBusiness.Current.Update(proyectoSeguimiento, contextUser);
                    }

                }
               
        }
        public override void Update(ProyectoSeguimientoCompose entity, IContextUser contextUser)
        {
       

                ProyectoSeguimiento proyectoSeguimiento = ProyectoSeguimientoBusiness.Current.GetById(entity.ProyectoSeguimiento.IdProyectoSeguimiento);
                ProyectoSeguimientoBusiness.Current.Set(entity.ProyectoSeguimiento, proyectoSeguimiento);
                ProyectoSeguimientoBusiness.Current.Update(proyectoSeguimiento, contextUser);

                

                //Elimino los que ya no forman parte
                List<int> actualIdsSeguimientoProyecto = (from o in entity.ProyectoSeguimientoProyecto where o.IdProyectoSeguimientoProyecto > 0 select o.IdProyectoSeguimientoProyecto).ToList();
                List<ProyectoSeguimientoProyecto> oldDetailSeguimientoProyecto = ProyectoSeguimientoProyectoBusiness.Current.GetList(new ProyectoSeguimientoProyectoFilter() { IdProyectoSeguimiento = entity.ProyectoSeguimiento.IdProyectoSeguimiento });
                List<ProyectoSeguimientoProyecto> deletetsSeguimientoProyecto = (from o in oldDetailSeguimientoProyecto where !actualIdsSeguimientoProyecto.Contains(o.IdProyectoSeguimientoProyecto) select o).ToList();
                ProyectoSeguimientoProyectoBusiness.Current.Delete(deletetsSeguimientoProyecto, contextUser);

                foreach (ProyectoSeguimientoProyectoResult pspr in entity.ProyectoSeguimientoProyecto)
                {
                    
                    if (pspr.IdProyectoSeguimientoProyecto < 1)
                    {
                        //Agrego los nuevos
                        pspr.IdProyectoSeguimiento = entity.ProyectoSeguimiento.IdProyectoSeguimiento;
                        ProyectoSeguimientoProyecto psp = pspr.ToEntity();
                        ProyectoSeguimientoProyectoBusiness.Current.Add(psp, contextUser);
                        pspr.IdProyectoSeguimientoProyecto = psp.IdProyectoSeguimientoProyecto;
                    }
                    
                }
                //Elimino los que ya no forman parte
                List<int> actualIdsSeguimientoLocalizacion = (from o in entity.ProyectoSeguimientoLocalizacion where o.IdProyectoSeguimientoLocalizacion > 0 select o.IdProyectoSeguimientoLocalizacion).ToList();
                List<ProyectoSeguimientoLocalizacion> oldDetailSeguimientoLocalizacion = ProyectoSeguimientoLocalizacionBusiness.Current.GetList(new ProyectoSeguimientoLocalizacionFilter() { IdProyectoSeguimiento = entity.ProyectoSeguimiento.IdProyectoSeguimiento });
                List<ProyectoSeguimientoLocalizacion> deletetsSeguimientoLocalizacion = (from o in oldDetailSeguimientoLocalizacion where !actualIdsSeguimientoLocalizacion.Contains(o.IdProyectoSeguimientoLocalizacion)  select o).ToList();
                ProyectoSeguimientoLocalizacionBusiness.Current.Delete(deletetsSeguimientoLocalizacion, contextUser);

                foreach (ProyectoSeguimientoLocalizacionResult pslr in entity.ProyectoSeguimientoLocalizacion)
                {

                    if (pslr.IdProyectoSeguimientoLocalizacion < 1 && pslr.Selected)
                    {
                        //Agrego los nuevos
                        pslr.IdProyectoSeguimiento = entity.ProyectoSeguimiento.IdProyectoSeguimiento;
                        ProyectoSeguimientoLocalizacion psl = pslr.ToEntity();
                        ProyectoSeguimientoLocalizacionBusiness.Current.Add(psl, contextUser);
                        pslr.IdProyectoSeguimientoLocalizacion = psl.IdProyectoSeguimientoLocalizacion;
                    }
                    else
                        if ( pslr.IdProyectoSeguimientoLocalizacion > 1 && !pslr.Selected )
                        {
                            ProyectoSeguimientoLocalizacionBusiness.Current.Delete(pslr.IdProyectoSeguimientoLocalizacion , contextUser);
                            pslr.IdProyectoSeguimientoLocalizacion = 0;
                        }
                }

                //Elimino los que ya no forman parte
                List<int> actualIdsSeguimientoEstado = (from o in entity.ProyectoSeguimientoEstado where o.IdProyectoSeguimientoEstado > 0 select o.IdProyectoSeguimientoEstado).ToList();
                List<ProyectoSeguimientoEstado> oldDetailSeguimientoEstado = ProyectoSeguimientoEstadoBusiness.Current.GetList(new ProyectoSeguimientoEstadoFilter() { IdProyectoSeguimiento = entity.ProyectoSeguimiento.IdProyectoSeguimiento });
                List<ProyectoSeguimientoEstado> deletetsSeguimientoEstado = (from o in oldDetailSeguimientoEstado where !actualIdsSeguimientoEstado.Contains(o.IdProyectoSeguimientoEstado) select o).ToList();
                if ((from o in deletetsSeguimientoEstado
                     where o.IdProyectoSeguimientoEstado == entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo
                     select o
                         ).Count() > 0)
                {
                    ProyectoSeguimientoEstadoResult se = entity.ProyectoSeguimientoEstado.LastOrDefault();
                    proyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo = (int?)(se != null ? se.IdProyectoSeguimientoEstado : null as int?);
                    ProyectoSeguimientoBusiness.Current.Update(proyectoSeguimiento, contextUser);
                }
            
                ProyectoSeguimientoEstadoBusiness.Current.Delete(deletetsSeguimientoEstado, contextUser);


                ProyectoSeguimientoProyectoResult PrimerProyecto = null ;
                if (entity.ProyectoSeguimientoProyecto.Count > 0)
                    PrimerProyecto = entity.ProyectoSeguimientoProyecto.First();

                ProyectoSeguimientoProyectoResult p = entity.ProyectoSeguimientoProyecto.FirstOrDefault();
                Int32? IdProyecto = p != null ? p.IdProyecto : null as Int32?;

                ComentarioTecnicoFilter comentarioTecnicoFilter = new ComentarioTecnicoFilter();
                comentarioTecnicoFilter.Nombre = "Evaluación";
                ComentarioTecnico c = ComentarioTecnicoBusiness.Current.FirstOrDefault(comentarioTecnicoFilter);
                Int32? IdComentarioTecnico = c != null ? c.IdComentarioTecnico : null as Int32?;

                foreach (ProyectoSeguimientoEstadoResult pser in entity.ProyectoSeguimientoEstado)
                {
                    if (pser.IdProyectoSeguimientoEstado < 1)
                    {
                        //Agrego los nuevos
                        pser.IdProyectoSeguimiento = entity.ProyectoSeguimiento.IdProyectoSeguimiento;
                        ProyectoSeguimientoEstado pse = pser.ToEntity();
                        pse.GeneraComentarioTecnico = pser.GeneraComentarioTecnico;
                        ProyectoSeguimientoEstadoBusiness.Current.Add(pse, contextUser);
                        pser.IdProyectoSeguimientoEstado = pse.IdProyectoSeguimientoEstado;
                        //Matias 20170223 - Ticket #ER678458 - Nuevo for para procesar todos los proyectos
                        foreach (ProyectoSeguimientoProyectoResult pspr in entity.ProyectoSeguimientoProyecto)
                        {
                            GenerarComentarioTecnico(pser, pspr.IdProyecto /*IdProyecto - Matias 20170223 - Ticket #ER678458*/, IdComentarioTecnico, contextUser);
                            GenerarMensaje(pser, pspr.IdProyecto /*IdProyecto - Matias 20170223 - Ticket #ER678458*/, entity.ProyectoSeguimientoProyecto.Select(i => i.IdProyecto).ToList(), contextUser);
                        }
                    }
                    else
                    {
                        ProyectoSeguimientoEstado pse = ProyectoSeguimientoEstadoBusiness.Current.GetById(pser.IdProyectoSeguimientoEstado);
                        ProyectoSeguimientoEstadoBusiness.Current.Set(pser, pse);
                        ProyectoSeguimientoEstadoBusiness.Current.Update(pse, contextUser);
                    }
                }

                if (entity.ProyectoSeguimientoEstado.Count() > 0)
                {
                    if (!entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo.HasValue)
                    {
                        //entity.ProyectoSeguimientoEstado.OrderByDescending(i => i.Fecha);
                        entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo = entity.ProyectoSeguimientoEstado.Last().IdProyectoSeguimientoEstado;
                        proyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo = entity.ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo;
                        ProyectoSeguimientoBusiness.Current.Update(proyectoSeguimiento, contextUser);
                    }

                }
                
                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(ProyectoSeguimientoCompose entity, IContextUser contextUser)
        {
            ProyectoSeguimientoBusiness.Current.Delete(entity.ProyectoSeguimiento.IdProyectoSeguimiento, contextUser);
        }

        #endregion

        #region Validations
        public override void Validate(ProyectoSeguimientoCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            ProyectoSeguimientoBusiness.Current.Validate(entity.ProyectoSeguimiento, actionName, contextUser, args);
            DataHelper.Validate(entity.ProyectoSeguimientoEstado.Count > 0, "Debe Asignar un Estado al Seguimiento");
        }

        public override bool Can(ProyectoSeguimientoCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoSeguimientoBusiness.Current.Can(ProyectoSeguimientoBusiness.Current.ToEntity(entity.ProyectoSeguimiento), actionName, contextUser, args);

        }
        public override bool Equals(ProyectoSeguimientoCompose source, ProyectoSeguimientoCompose target)
        {
            bool eq = source.ProyectoSeguimiento.IdProyectoSeguimiento.Equals(target.ProyectoSeguimiento.IdProyectoSeguimiento);
            if (eq)
            {
                bool eqPr = ProyectoSeguimientoBusiness.Current.Equals(source.ProyectoSeguimiento , target.ProyectoSeguimiento);
                if (!eqPr) return false;

                if( target.ProyectoSeguimientoEstado.Count() != source.ProyectoSeguimientoEstado.Count())return false;
               
                bool eqSet = true;
                foreach (ProyectoSeguimientoEstadoResult  pser in source.ProyectoSeguimientoEstado)
                {
                    ProyectoSeguimientoEstadoResult pserTarget = target.ProyectoSeguimientoEstado.Where(p => p.IdProyectoSeguimientoEstado == pser.IdProyectoSeguimientoEstado).SingleOrDefault();
                    eqSet = eqSet && ProyectoSeguimientoEstadoBusiness.Current.Equals (pser,pserTarget);
                                //&& pser.Nombre == pserTarget.Nombre
                                //&& pser.CodigoVinculacion == pserTarget.CodigoVinculacion
                                //&& pser.IdEstado == pserTarget.IdEstado
                                //&& pser.FechaInicioEstimada == pserTarget.FechaInicioEstimada
                                //&& pser.FechaFinEstimada == pserTarget.FechaFinEstimada
                                //&& pser.FechaInicioRealizada == pserTarget.FechaInicioRealizada
                                //&& pser.FechaFinRealizada == pserTarget.FechaFinRealizada
                                //&& pser.IdEtapa == pserTarget.IdEtapa
                                //&& pser.IdProyecto == pserTarget.IdProyecto;
                    
                }
                if (!eqSet) return eqSet;

                if (target.ProyectoSeguimientoLocalizacion.Count() != source.ProyectoSeguimientoLocalizacion.Count()) return false;
               
                bool eqSl = true;
                foreach (ProyectoSeguimientoLocalizacionResult pslr in source.ProyectoSeguimientoLocalizacion)
                {
                    if (pslr.Selected)
                    {
                        if (pslr.IdProyectoSeguimientoLocalizacion == 0)
                            return false;
                        else
                        {
                            ProyectoSeguimientoLocalizacionResult pslrTarget = target.ProyectoSeguimientoLocalizacion.Where(g => g.IdProyectoSeguimientoLocalizacion == pslr.IdProyectoSeguimientoLocalizacion).SingleOrDefault();
                            if (!ProyectoSeguimientoLocalizacionBusiness.Current.Equals(pslr, pslrTarget)) return false;
                        }
                  
                    }
                    else
                    {
                        if (pslr.IdProyectoSeguimientoLocalizacion != 0)
                        {
                            ProyectoSeguimientoLocalizacionResult pslrTarget = target.ProyectoSeguimientoLocalizacion.Where(g => g.IdProyectoSeguimientoLocalizacion == pslr.IdProyectoSeguimientoLocalizacion).SingleOrDefault();
                            if (!ProyectoSeguimientoLocalizacionBusiness.Current.Equals(pslr, pslrTarget)) return false;
                        }
                    }

                    //if (pslr.Selected)
                    //{
                    //    if(pslr.IdProyectoSeguimientoLocalizacion == 0) return false;
                    //    ProyectoSeguimientoLocalizacionResult pslrTarget = target.ProyectoSeguimientoLocalizacion.Where(g => g.IdProyectoSeguimientoLocalizacion == pslr.IdProyectoSeguimientoLocalizacion).SingleOrDefault();
                    //    eqSl = eqSl && ProyectoSeguimientoLocalizacionBusiness.Current.Equals(pslr, pslrTarget);
                    //    //&& perr.IdProyectoEtapa == perrTarget.IdProyectoEtapa && perr.IdProyectoEtapaEstimado == perrTarget.IdProyectoEtapaEstimado
                    //    //&& perr.IdClasificacionGasto == perrTarget.IdClasificacionGasto
                    //    //&& perr.IdFuenteFinanciamiento == perrTarget.IdFuenteFinanciamiento
                    //    ////&& perr.IdProyectoOrigenFinanciamiento == perrTarget.IdProyectoOrigenFinanciamiento
                    //    //&& perr.IdMoneda == perrTarget.IdMoneda;
                    //}
                }
                if (!eqSl) return eqSl;

                if (target.ProyectoSeguimientoProyecto.Count() != source.ProyectoSeguimientoProyecto.Count()) return false;
               
                bool eqSpr = true;
                foreach (ProyectoSeguimientoProyectoResult pspr in source.ProyectoSeguimientoProyecto)
                {
                    ProyectoSeguimientoProyectoResult psprTarget = target.ProyectoSeguimientoProyecto.Where(g => g.IdProyectoSeguimientoProyecto == pspr.IdProyectoSeguimientoProyecto).SingleOrDefault();
                    eqSpr = eqSpr && ProyectoSeguimientoProyectoBusiness.Current.Equals ( pspr, psprTarget );
                        
                                  //&& perr.IdProyectoEtapa == perrTarget.IdProyectoEtapa && perr.IdProyectoEtapaRealizado == perrTarget.IdProyectoEtapaRealizado
                                  //&& perr.IdClasificacionGasto == perrTarget.IdClasificacionGasto
                                  //&& perr.IdFuenteFinanciamiento == perrTarget.IdFuenteFinanciamiento
                                  ////&& perr.IdProyectoOrigenFinanciamiento == perrTarget.IdProyectoOrigenFinanciamiento
                                  //&& perr.IdMoneda == perrTarget.IdMoneda;
                }
                if (!eqSpr) return eqSpr;

            }
            return eq;
        }

        #endregion
        #region Private
        private void GenerarComentarioTecnico(ProyectoSeguimientoEstadoResult  pser,Int32? IdProyecto,Int32? IdComentarioTecnico ,IContextUser contextUser)
        {
            if (!pser.GeneraComentarioTecnico || IdProyecto.HasValue == false || IdComentarioTecnico.HasValue == false ) return;
            ProyectoComentarioTecnico pct = new ProyectoComentarioTecnico ();
            pct.IdUsuario = pser.IdUsuario;
            pct.Observacion = pser.Observacion;
            pct.Fecha = pser.Fecha;
            pct.FechaAlta = pser.Fecha; //Matias 20170223 - Ticket #ER678458
            pct.IdProyecto = IdProyecto.Value ;
            pct.IdComentarioTecnico = IdComentarioTecnico.Value;
            ProyectoComentarioTecnicoBusiness.Current.Save(pct, contextUser);
        }
        private void GenerarMensaje(ProyectoSeguimientoEstadoResult pser, Int32? IdProyecto,List<Int32>ListIdsProyectos,  IContextUser contextUser)
        {
            if (!pser.EnviarMensaje) return;
            Message  m = new Message ();
            m.Body = pser.Observacion;
            m.Subject = "Evaluación de Factibilidad";
            m.StartDate = DateTime.Now;
            m.SendDate = DateTime.Now;
            m.IsManual = true;
            m.IdUserFrom = contextUser.User.IdUsuario ;
            m.IdProyecto = IdProyecto;
            m.IdPriority = (int)PriorityEnum.Alta;
            m.IdMediaFrom = (int)MessageMediaEnum.Web;
            MessageBusiness.Current.Save(m, contextUser);

            List<Int32> idsUsuarios ;
            idsUsuarios = ProyectoOficinaPerfilBusiness.Current.GetIdFuncionariosProyectos(new ProyectoOficinaPerfilFilter() { IdsProyecto = ListIdsProyectos });
            idsUsuarios = idsUsuarios.Distinct().ToList();
            foreach (Int32 idUsuario in idsUsuarios)
            {
                MessageSend ms = new MessageSend();
                ms.IdMessage = m.IdMessage;
                ms.IdUserTo = idUsuario;
                ms.IdMediaTo = (int)MessageMediaEnum.Web;
                ms.IsRead = false;
                ms.ReadDate = null;
                MessageSendBusiness.Current.Save(ms, contextUser);
            }
        }
        public List<ProyectoSeguimientoLocalizacionResult> AlcanceGeograficoToProyectoSeguimientoLocalizacion()
        {
            return AlcanceGeograficoToProyectoSeguimientoLocalizacion(null);
        }
        public List<ProyectoSeguimientoLocalizacionResult> AlcanceGeograficoToProyectoSeguimientoLocalizacion(Int32 Id)
        {
            List<Int32> list = new List<int> ();
            list.Add (Id) ;
            return AlcanceGeograficoToProyectoSeguimientoLocalizacion(list);
        }
        public List<ProyectoSeguimientoLocalizacionResult> AlcanceGeograficoToProyectoSeguimientoLocalizacion(List<Int32> Ids)
        {
            List<ProyectoSeguimientoLocalizacionResult> lpslr = new List<ProyectoSeguimientoLocalizacionResult>();

            if (Ids != null)
            {
                lpslr = ProyectoSeguimientoLocalizacionBusiness.Current.GetResult(new ProyectoSeguimientoLocalizacionFilter() { IdsProyectoSeguimiento = Ids });
            }
            List<ClasificacionGeograficaResult> lcgr = ClasificacionGeograficaBusiness.Current.GetResult(new ClasificacionGeograficaFilter() { IdClasificacionGeograficaTipo = (Int32)ClasificacionGeograficaTipoEnum.Provincia }).Where(i=> !lpslr.Select (j=> j.IdCalificacionGeografica).Contains(i.IdClasificacionGeografica)).ToList () ;
            
            ProyectoSeguimientoLocalizacionResult pslr ;
            foreach (ClasificacionGeograficaResult cgr in lcgr)
            {
                pslr = new ProyectoSeguimientoLocalizacionResult();
                pslr.CalificacionGeografica_Activo = cgr.Activo;
                pslr.CalificacionGeografica_BreadcrumbCode = cgr.BreadcrumbCode;
                pslr.CalificacionGeografica_BreadcrumbId = cgr.BreadcrumbId;
                pslr.CalificacionGeografica_BreadcrumOrden = cgr.BreadcrumOrden;
                pslr.CalificacionGeografica_Codigo = cgr.Codigo;
                pslr.CalificacionGeografica_Descripcion = cgr.Descripcion;
                pslr.CalificacionGeografica_DescripcionCodigo = cgr.DescripcionCodigo;
                pslr.CalificacionGeografica_DescripcionInvertida = cgr.DescripcionInvertida;
                pslr.CalificacionGeografica_IdClasificacionGeograficaPadre = cgr.IdClasificacionGeograficaPadre;
                pslr.CalificacionGeografica_IdClasificacionGeograficaTipo = cgr.IdClasificacionGeograficaTipo;
                pslr.CalificacionGeografica_Nivel = cgr.Nivel;
                pslr.CalificacionGeografica_Nombre = cgr.Nombre;
                pslr.CalificacionGeografica_Orden = cgr.Orden;
                pslr.CalificacionGeografica_Seleccionable = cgr.Seleccionable;
                pslr.IdCalificacionGeografica = cgr.IdClasificacionGeografica;
                pslr.Selected = false;

                lpslr.Add(pslr);
            }
            return  lpslr;
        }
        #endregion

    }

}
