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
    public class ProyectoAlcanceGeograficoBusiness : _ProyectoAlcanceGeograficoBusiness 
    {   
	   #region Singleton
	   private static volatile ProyectoAlcanceGeograficoBusiness current;
	   private static object syncRoot = new Object();

	   //private ProyectoAlcanceGeograficoBusiness() {}
	   public static ProyectoAlcanceGeograficoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoAlcanceGeograficoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    } 

    public class ProyectoAlcanceGeograficoComposeBusiness : EntityComposeBusiness<ProyectoAlcanceGeograficoCompose, Proyecto, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoAlcanceGeograficoComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoAlcanceGeograficoComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoAlcanceGeograficoComposeBusiness();
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

        protected override IEntityData<ProyectoAlcanceGeograficoCompose, ProyectoFilter, ProyectoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override ProyectoAlcanceGeograficoCompose GetNew(ProyectoResult example)
        {
            ProyectoAlcanceGeograficoCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.Localizaciones = new List<ProyectoLocalizacionResult>();
            compose.Alcances = new List<ProyectoAlcanceGeograficoResult>();
            compose.Georeferenciaciones = new List<ProyectoGeoreferenciacionResult>();
            return compose;
        }
        public override ProyectoAlcanceGeograficoCompose GetNew()
        {
            ProyectoAlcanceGeograficoCompose compose = base.GetNew();
            compose.Proyecto = null;
            compose.Localizaciones = new List<ProyectoLocalizacionResult>();
            compose.Alcances = new List<ProyectoAlcanceGeograficoResult>();
            compose.Georeferenciaciones = new List<ProyectoGeoreferenciacionResult>();
            return compose;
        }
        public override int  GetId(ProyectoAlcanceGeograficoCompose entity)
        {
            return entity.IdProyecto;
        }
        public override ProyectoAlcanceGeograficoCompose GetById(int id)
        {
            ProyectoAlcanceGeograficoCompose compose = new ProyectoAlcanceGeograficoCompose();
            compose.Proyecto = ProyectoBusiness.Current.GetResultFromListWithOfficePerfil(new ProyectoFilter() { IdProyecto = id }).FirstOrDefault();
            compose.Localizaciones = ProyectoLocalizacionBusiness.Current.GetResult(new ProyectoLocalizacionFilter() { IdProyecto = id });
            compose.Alcances = ProyectoAlcanceGeograficoBusiness.Current.GetResult(new ProyectoAlcanceGeograficoFilter() { IdProyecto = id });
            compose.Georeferenciaciones = ProyectoGeoreferenciacionBusiness.Current.GetGeoreferenciaciones(new ProyectoGeoreferenciacionFilter() { IdProyecto = id });
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(ProyectoAlcanceGeograficoCompose entity, IContextUser contextUser)
        {
            try
            {
                foreach (ProyectoLocalizacionResult plr in entity.Localizaciones)
                {
                    plr.IdProyecto = entity.IdProyecto;
                    plr.IdProyectoLocalizacion = 0;
                    ProyectoLocalizacion pl = plr.ToEntity();                    
                    ProyectoLocalizacionBusiness.Current.Add(pl, contextUser);
                    plr.IdProyectoLocalizacion = pl.IdProyectoLocalizacion;
                }

                foreach (ProyectoAlcanceGeograficoResult pagr in entity.Alcances)
                {
                    pagr.IdProyecto = entity.IdProyecto;
                    pagr.IdProyectoAlcanceGeografico = 0;
                    ProyectoAlcanceGeografico pag = pagr.ToEntity();                    
                    ProyectoAlcanceGeograficoBusiness.Current.Add(pag, contextUser);
                    pagr.IdProyectoAlcanceGeografico = pag.IdProyectoAlcanceGeografico;
                }

                foreach (ProyectoGeoreferenciacionResult pgr in entity.Georeferenciaciones)
                {
                    pgr.Georeferenciacion.IdGeoreferenciacion = 0;
                    Georeferenciacion g = pgr.Georeferenciacion.ToEntity();                    
                    GeoreferenciacionBusiness.Current.Add(g, contextUser);
                    pgr.Georeferenciacion.IdGeoreferenciacion = g.IdGeoreferenciacion;

                    // Guarda los puntos
                    foreach (GeoreferenciacionPuntoResult pr in pgr.Puntos)
                    {
                        GeoreferenciacionPunto p = pr.ToEntity();
                        p.IdGeoreferenciacionPunto = 0;
                        p.IdGeoreferenciacion = g.IdGeoreferenciacion;
                        GeoreferenciacionPuntoBusiness.Current.Add(p, contextUser);
                        pr.IdGeoreferenciacionPunto = p.IdGeoreferenciacionPunto;
                    }

                    // Guarda la relacion
                    ProyectoGeoreferenciacion pg = pgr.ToEntity();
                    pg.IdProyectoGeoreferenciacion = 0;
                    ProyectoGeoreferenciacionBusiness.Current.Add(pg, contextUser);
                    pgr.IdProyectoGeoreferenciacion = pg.IdProyectoGeoreferenciacion;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public override void Update(ProyectoAlcanceGeograficoCompose entity, IContextUser contextUser)
        {
            #region Localizaciones
            // Elimina los que ya no estan
            List<int> actualIdsLoc = (from o in entity.Localizaciones where o.IdProyectoLocalizacion > 0 select o.IdProyectoLocalizacion).ToList();
            List<ProyectoLocalizacion> oldDetailLoc = ProyectoLocalizacionBusiness.Current.GetList(new ProyectoLocalizacionFilter() { IdProyecto = entity.IdProyecto });
            List<ProyectoLocalizacion> deletesLoc = (from o in oldDetailLoc where !actualIdsLoc.Contains(o.IdProyectoLocalizacion) select o).ToList();
            ProyectoLocalizacionBusiness.Current.Delete(deletesLoc, contextUser);

            foreach (ProyectoLocalizacionResult plr in entity.Localizaciones)
            {
                ProyectoLocalizacion pl = plr.ToEntity();
                pl.IdProyecto = entity.IdProyecto;
                if (plr.IdProyectoLocalizacion <= 0)
                {
                    plr.IdProyectoLocalizacion = 0;
                    ProyectoLocalizacionBusiness.Current.Add(pl, contextUser);
                }
                else
                    ProyectoLocalizacionBusiness.Current.Update(pl, contextUser);
                plr.IdProyectoLocalizacion = pl.IdProyectoLocalizacion;
            }
            #endregion

            #region Alcances
            // Elimina los que ya no estan
            List<int> actualIdsAlc = (from o in entity.Alcances where o.IdProyectoAlcanceGeografico > 0 select o.IdProyectoAlcanceGeografico).ToList();
            List<ProyectoAlcanceGeografico> oldDetailAlc = ProyectoAlcanceGeograficoBusiness.Current.GetList(new ProyectoAlcanceGeograficoFilter() { IdProyecto = entity.IdProyecto });
            List<ProyectoAlcanceGeografico> deletesAlc = (from o in oldDetailAlc where !actualIdsAlc.Contains(o.IdProyectoAlcanceGeografico) select o).ToList();
            ProyectoAlcanceGeograficoBusiness.Current.Delete(deletesAlc, contextUser);

            foreach (ProyectoAlcanceGeograficoResult pagr in entity.Alcances)
            {
                ProyectoAlcanceGeografico pag = pagr.ToEntity();
                pag.IdProyecto = entity.IdProyecto;
                if (pag.IdProyectoAlcanceGeografico <= 0)
                {
                    pag.IdProyectoAlcanceGeografico = 0;
                    ProyectoAlcanceGeograficoBusiness.Current.Add(pag, contextUser);
                }
                else
                    ProyectoAlcanceGeograficoBusiness.Current.Update(pag, contextUser);
                pagr.IdProyectoAlcanceGeografico = pag.IdProyectoAlcanceGeografico;
            }
            #endregion

            #region Georeferenciaciones
            // Elimina los que ya no estan
            List<int> actualIdsGeo = (from o in entity.Georeferenciaciones where o.IdProyectoGeoreferenciacion > 0 select o.IdProyectoGeoreferenciacion).ToList();
            List<ProyectoGeoreferenciacion> oldDetailGeo = ProyectoGeoreferenciacionBusiness.Current.GetList(new ProyectoGeoreferenciacionFilter() { IdProyecto = entity.IdProyecto });
            List<ProyectoGeoreferenciacion> deletesGeo = (from o in oldDetailGeo where !actualIdsGeo.Contains(o.IdProyectoGeoreferenciacion) select o).ToList();
            List<int> actualIdsDeleteGeo = new List<int>();
            foreach (ProyectoGeoreferenciacion delPg in deletesGeo)
            {
                GeoreferenciacionPuntoBusiness.Current.Delete(new GeoreferenciacionPuntoFilter() { IdGeoreferenciacion = delPg.IdGeoreferenciacion }, contextUser);
                actualIdsDeleteGeo.Add(delPg.IdGeoreferenciacion);
            }
            ProyectoGeoreferenciacionBusiness.Current.Delete(deletesGeo, contextUser);
            GeoreferenciacionBusiness.Current.Delete(actualIdsDeleteGeo.ToArray(), contextUser);

            foreach (ProyectoGeoreferenciacionResult pgr in entity.Georeferenciaciones)
            {
                if (pgr.IdProyectoGeoreferenciacion <= 0)
                {
                    // Guarda la Georeferenciacion
                    Georeferenciacion g = pgr.Georeferenciacion.ToEntity();
                    g.IdGeoreferenciacion = 0;
                    GeoreferenciacionBusiness.Current.Add(g, contextUser);
                    pgr.IdGeoreferenciacion = g.IdGeoreferenciacion;

                    // Guarda los puntos
                    foreach (GeoreferenciacionPuntoResult pr in pgr.Puntos)
                    {
                        GeoreferenciacionPunto p = pr.ToEntity();
                        p.IdGeoreferenciacionPunto = 0;
                        p.IdGeoreferenciacion = g.IdGeoreferenciacion;
                        GeoreferenciacionPuntoBusiness.Current.Add(p, contextUser);
                        pr.IdGeoreferenciacionPunto = p.IdGeoreferenciacionPunto;
                    }

                    // Guarda la relacion
                    ProyectoGeoreferenciacion pg = pgr.ToEntity();
                    pg.IdProyectoGeoreferenciacion = 0;
                    ProyectoGeoreferenciacionBusiness.Current.Add(pg, contextUser);
                    pgr.IdProyectoGeoreferenciacion = pg.IdProyectoGeoreferenciacion;
                }
                else
                {
                    // Actualiza la georeferenciacion
                    ProyectoGeoreferenciacion pg = pgr.ToEntity();
  
                    Georeferenciacion g = GeoreferenciacionBusiness.Current.GetById(pgr.IdGeoreferenciacion);
                    g.IdGeoreferenciacionTipo = pgr.Georeferenciacion.IdGeoreferenciacionTipo;
                    GeoreferenciacionBusiness.Current.Update(g, contextUser);


                    // Elimina los que ya no estan
                    List<int> actualIdsPun = (from o in pgr.Puntos where o.IdGeoreferenciacionPunto > 0 select o.IdGeoreferenciacionPunto).ToList();
                    List<GeoreferenciacionPunto> oldDetailPun = GeoreferenciacionPuntoBusiness.Current.GetList(new GeoreferenciacionPuntoFilter() { IdGeoreferenciacion = pgr.IdGeoreferenciacion });
                    List<GeoreferenciacionPunto> deletesPun = (from o in oldDetailPun where !actualIdsPun.Contains(o.IdGeoreferenciacionPunto) select o).ToList();
                    GeoreferenciacionPuntoBusiness.Current.Delete(deletesPun, contextUser);

                    // Agrega los puntos actualizados
                    foreach (GeoreferenciacionPuntoResult pr in pgr.Puntos)
                    {
                        GeoreferenciacionPunto p = pr.ToEntity();
                        p.IdGeoreferenciacion = pg.IdGeoreferenciacion;
                        if (pr.IdGeoreferenciacionPunto <= 0)
                            GeoreferenciacionPuntoBusiness.Current.Add(p, contextUser);
                        else
                            GeoreferenciacionPuntoBusiness.Current.Update(p, contextUser);
                        pr.IdGeoreferenciacionPunto = p.IdGeoreferenciacionPunto;
                    }

                    // Actualiza la relación
                    //ProyectoGeoreferenciacionBusiness.Current.Update(pg, contextUser);
                }
            }
            #endregion
            //Matias 20131106 - Tarea 80
            ProyectoBusiness.Current.updateFechaUltimaModificacion(entity.IdProyecto, contextUser);
            //FinMatias 20131106 - Tarea 80
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(ProyectoAlcanceGeograficoCompose entity, IContextUser contextUser)
        {
            ProyectoLocalizacionBusiness.Current.Delete(new ProyectoLocalizacionFilter() { IdProyecto = entity.IdProyecto }, contextUser);
            ProyectoAlcanceGeograficoBusiness.Current.Delete(new ProyectoAlcanceGeograficoFilter() { IdProyecto = entity.IdProyecto }, contextUser);
            ProyectoGeoreferenciacionBusiness.Current.Delete(new ProyectoGeoreferenciacionFilter() { IdProyecto = entity.IdProyecto }, contextUser);
        }
        public virtual int CopyAndSave(int oldId, int newId, IContextUser contextUser)
        {
            ProyectoAlcanceGeograficoCompose oldEntity = ProyectoAlcanceGeograficoComposeBusiness.Current.GetById(oldId);
            ProyectoAlcanceGeograficoCompose newEntity = ProyectoAlcanceGeograficoComposeBusiness.Current.Copy(oldEntity, contextUser);
            newEntity.Proyecto = ProyectoBusiness.Current.GetResultFromList(new ProyectoFilter() { IdProyecto = newId }).FirstOrDefault();
            foreach (ProyectoLocalizacionResult r in newEntity.Localizaciones)
            {
                r.IdProyecto = newId;
                r.IdProyectoLocalizacion = 0;
            }
            foreach (ProyectoAlcanceGeograficoResult r in newEntity.Alcances)
            {
                r.IdProyecto = newId;
                r.IdProyectoAlcanceGeografico = 0;
            }
            Add(newEntity, contextUser);
            return newId;
        }
        public override ProyectoAlcanceGeograficoCompose Copy(ProyectoAlcanceGeograficoCompose entity, IContextUser contextUser)
        {
            ProyectoAlcanceGeograficoCompose newEntity = new ProyectoAlcanceGeograficoCompose();
            newEntity.Localizaciones = ProyectoLocalizacionBusiness.Current.CopiesResult(entity.Localizaciones);
            newEntity.Alcances = ProyectoAlcanceGeograficoBusiness.Current.CopiesResult(entity.Alcances);
            newEntity.Georeferenciaciones = new List<ProyectoGeoreferenciacionResult>();
            return newEntity;            
        }
        #endregion

        #region protected Methods

        #endregion

        #region Validations
        public override void Validate(ProyectoAlcanceGeograficoCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            foreach (ProyectoLocalizacionResult plr in entity.Localizaciones)
            {
                ProyectoLocalizacion pl = plr.ToEntity();
                pl.IdProyecto = entity.IdProyecto;
                ProyectoLocalizacionBusiness.Current.Validate(pl, actionName, contextUser, args);
            }

            foreach (ProyectoAlcanceGeograficoResult pagr in entity.Alcances)
            {
                ProyectoAlcanceGeografico pag = pagr.ToEntity();
                pag.IdProyecto = entity.IdProyecto;
                ProyectoAlcanceGeograficoBusiness.Current.Validate(pag, actionName, contextUser, args);
            }

            foreach (ProyectoGeoreferenciacionResult pgr in entity.Georeferenciaciones)
            {
                ProyectoGeoreferenciacion pg = pgr.ToEntity();
                pg.IdProyecto = entity.IdProyecto;
                ProyectoGeoreferenciacionBusiness.Current.Validate(pg, actionName, contextUser, args);
            }
        }

        public override bool Can(ProyectoAlcanceGeograficoCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            bool retval = false;
            foreach (ProyectoLocalizacionResult plr in entity.Localizaciones)
            {
                ProyectoLocalizacion pl = plr.ToEntity();
                pl.IdProyecto = entity.IdProyecto;
                retval = retval && ProyectoLocalizacionBusiness.Current.Can(pl, actionName, contextUser, args);
            }

            foreach (ProyectoAlcanceGeograficoResult pagr in entity.Alcances)
            {
                ProyectoAlcanceGeografico pag = pagr.ToEntity();
                pag.IdProyecto = entity.IdProyecto;
                retval = retval && ProyectoAlcanceGeograficoBusiness.Current.Can(pag, actionName, contextUser, args);
            }

            foreach (ProyectoGeoreferenciacionResult pgr in entity.Georeferenciaciones)
            {
                ProyectoGeoreferenciacion pg = pgr.ToEntity();
                pg.IdProyecto = entity.IdProyecto;
                retval = retval && ProyectoGeoreferenciacionBusiness.Current.Can(pg, actionName, contextUser, args);
            }
            return retval;
        }

        public override bool Equals(ProyectoAlcanceGeograficoCompose source, ProyectoAlcanceGeograficoCompose target)
        {
            bool eq = source.IdProyecto.Equals(target.IdProyecto);
            if (eq)
            {
                if(target.Localizaciones.Count() != source.Localizaciones.Count()) return false;
                bool eqLoc = true;
                foreach (ProyectoLocalizacionResult plr in source.Localizaciones)
                {
                    ProyectoLocalizacionResult plrTarget = target.Localizaciones.Where(p => p.IdProyectoLocalizacion == plr.IdProyectoLocalizacion).SingleOrDefault();
                    eqLoc = eqLoc && plrTarget!=null && plr.IdClasificacionGeografica == plrTarget.IdClasificacionGeografica && plr.IdProyecto == plrTarget.IdProyecto;
                }
                
                if (!eqLoc) return eqLoc;

                if (target.Alcances.Count() != source.Alcances.Count()) return false;
                bool eqAlc = true;
                foreach (ProyectoAlcanceGeograficoResult pagr in source.Alcances)
                {
                    ProyectoAlcanceGeograficoResult pagrTarget = target.Alcances.Where(a => a.IdProyectoAlcanceGeografico == pagr.IdProyectoAlcanceGeografico).SingleOrDefault();
                    eqAlc = eqAlc && pagrTarget != null && pagr.IdClasificacionGeografica == pagrTarget.IdClasificacionGeografica && pagr.IdProyecto == pagrTarget.IdProyecto;
                }
                if (!eqAlc) return eqAlc;

                if (target.Georeferenciaciones.Count() != source.Georeferenciaciones.Count()) return false;
                bool eqGeo = true;
                foreach (ProyectoGeoreferenciacionResult pgr in source.Georeferenciaciones)
                {
                    ProyectoGeoreferenciacionResult pgrTarget = target.Georeferenciaciones.Where(g => g.IdProyectoGeoreferenciacion == pgr.IdProyectoGeoreferenciacion).SingleOrDefault();
                    eqGeo = eqGeo && pgrTarget != null && pgr.IdGeoreferenciacion == pgrTarget.IdGeoreferenciacion && pgr.IdProyecto == pgrTarget.IdProyecto;
                    eqGeo = eqGeo && pgrTarget != null && pgr.Georeferenciacion.IdGeoreferenciacion == pgrTarget.Georeferenciacion.IdGeoreferenciacion &&
                                     pgr.Georeferenciacion.IdGeoreferenciacionTipo == pgrTarget.Georeferenciacion.IdGeoreferenciacionTipo;
                    if (eqGeo)
                    {
                        if (pgrTarget.Puntos.Count() != pgr.Puntos.Count()) return false;
                        foreach (GeoreferenciacionPuntoResult grp in pgr.Puntos)
                        {
                            GeoreferenciacionPunto a = grp.ToEntity();
                            if (pgrTarget.Puntos.Where(p => p.IdGeoreferenciacionPunto == grp.IdGeoreferenciacionPunto) != null)
                            {
                                GeoreferenciacionPuntoResult c = pgrTarget.Puntos.Where(p => p.IdGeoreferenciacionPunto == grp.IdGeoreferenciacionPunto).SingleOrDefault();
                                if (c == null) return false;
                                GeoreferenciacionPunto b = c.ToEntity();
                                eqGeo = eqGeo && a.IdGeoreferenciacionPunto == b.IdGeoreferenciacionPunto &&
                                                 a.IdGeoreferenciacion == b.IdGeoreferenciacion &&
                                                 a.Orden == b.Orden && a.Longitud == b.Longitud && a.Latitud == b.Latitud;
                            }
                        }
                    }
                    else
                        break;
                }

                eq = eqLoc && eqAlc && eqGeo;
            }
            return eq;
        }
        #endregion
    }
}
