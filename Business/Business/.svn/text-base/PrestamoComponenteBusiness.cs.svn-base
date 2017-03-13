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
    public class PrestamoComponenteBusiness : _PrestamoComponenteBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoComponenteBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoComponenteBusiness() {}
	   public static PrestamoComponenteBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoComponenteBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       internal List<PrestamoObjetivoComponenteCompose> GetPrestamoObjetivoComponenteCompose(PrestamoComponenteFilter prestamoComponenteFilter)
       {
           List<PrestamoObjetivoComponenteCompose> rv = new List<PrestamoObjetivoComponenteCompose>();

           List<PrestamoComponenteResult> componentes = PrestamoComponenteBusiness.current.GetResult(new PrestamoComponenteFilter() { IdPrestamo = prestamoComponenteFilter.IdPrestamo });
           foreach (PrestamoComponenteResult pcr in componentes)
           {
               PrestamoObjetivoComponenteCompose n = PrestamoObjetivoComponenteComposeBusiness.Current.GetById(pcr.IdPrestamoComponente);
               rv.Add(n);
           }
           return rv;
       }
    }

    public class PrestamoObjetivoComponenteComposeBusiness : ObjetivoComposeBusiness<PrestamoObjetivoComponenteCompose, Objetivo, ObjetivoFilter, ObjetivoResult, int>
    {
        #region Singleton
        private static volatile PrestamoObjetivoComponenteComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoObjetivoComponenteComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoObjetivoComponenteComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Objetivo, ObjetivoFilter, ObjetivoResult, int> EntityBusinessBase
        {
            get { return ObjetivoBusiness.Current; }
        }

        public override PrestamoObjetivoComponenteCompose GetById(int id)
        {
            PrestamoObjetivoComponenteCompose obj = new PrestamoObjetivoComponenteCompose();
            obj.Componente = PrestamoComponenteBusiness.Current.GetResult(new PrestamoComponenteFilter() { IdPrestamoComponente = id }).FirstOrDefault();
            obj.Indicadores = PrestamoObjetivoComponenteComposeBusiness.Current.GetObjetivoIndicadoresComposeByIdObjetivo(obj.Componente.IdObjetivo, true);
            obj.Supuestos = PrestamoObjetivoComponenteComposeBusiness.Current.GetObjetivoSupuestosByIdObjetivo(obj.Componente.IdObjetivo);
            return obj;
        }

        #region Actions
        public override void Add(PrestamoObjetivoComponenteCompose entity, IContextUser contextUser)
        {
            Objetivo objetivo = ObjetivoBusiness.Current.GetNew();
            objetivo.Nombre = entity.Componente.Objetivo_Nombre;
            ObjetivoBusiness.Current.Add(objetivo, contextUser);

            entity.Componente.IdObjetivo = objetivo.IdObjetivo;
            PrestamoComponente pc = entity.Componente.ToEntity();
            PrestamoComponenteBusiness.Current.Add(pc , contextUser);
            entity.Componente.IdPrestamoComponente = pc.IdPrestamoComponente;

            Add(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Add(entity.Indicadores, objetivo.IdObjetivo, contextUser);
        }
        public override void Update(PrestamoObjetivoComponenteCompose entity, IContextUser contextUser)
        {
            PrestamoComponente componente = PrestamoComponenteBusiness.Current.GetById(entity.Componente.IdPrestamoComponente);
            PrestamoComponenteBusiness.Current.Set(entity.Componente, componente);
            PrestamoComponenteBusiness.Current.Update(componente, contextUser);

            Objetivo objetivo = ObjetivoBusiness.Current.GetById(componente.IdObjetivo);
            objetivo.Nombre = entity.Componente.Objetivo_Nombre;
            ObjetivoBusiness.Current.Update(objetivo, contextUser);

            Update(entity.Supuestos, objetivo.IdObjetivo, contextUser);
            Update(entity.Indicadores, objetivo.IdObjetivo, contextUser);

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(PrestamoObjetivoComponenteCompose entity, IContextUser contextUser)
        {
            Delete(entity.Supuestos, contextUser);
            Delete(entity.Indicadores, contextUser);
            PrestamoComponenteBusiness.Current.Delete(entity.Componente.IdPrestamoComponente, contextUser);
            ObjetivoBusiness.Current.Delete(entity.Componente.IdObjetivo, contextUser);
        }
        #endregion

        public override bool Equals(PrestamoObjetivoComponenteCompose source, PrestamoObjetivoComponenteCompose target)
        {
            if (!source.Componente.Equals(target.Componente.ToEntity())) return false;
            if (!EqualsObjetivoIndicadorCompose(source.Indicadores, target.Indicadores)) return false;
            if (!EqualsObjetivoSupuesto(source.Supuestos, target.Supuestos)) return false;

            return true;
        }
    }

    public class PrestamoComponenteComposeBusiness : EntityComposeBusiness<PrestamoComponenteCompose, Prestamo, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoComponenteComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoComponenteComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoComponenteComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Prestamo, PrestamoFilter, PrestamoResult, int> EntityBusinessBase
        {
            get { return PrestamoBusiness.Current; }
        }

        protected override IEntityData<PrestamoComponenteCompose, PrestamoFilter, PrestamoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override PrestamoComponenteCompose GetNew(PrestamoResult example)
        {
            PrestamoComponenteCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.Componentes = new List<PrestamoObjetivoComponenteCompose>();
            compose.Subcomponentes = new List<PrestamoSubComponenteResult>();
            compose.Financiamientos = new List<PrestamoFinanciamientoResult>();
            compose.Desembolsos = new List<PrestamoDesembolsoResult>();
            return compose;
        }
        public override PrestamoComponenteCompose GetNew()
        {
            PrestamoComponenteCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.Componentes = new List<PrestamoObjetivoComponenteCompose>();
            compose.Subcomponentes = new List<PrestamoSubComponenteResult>();
            compose.Financiamientos = new List<PrestamoFinanciamientoResult>();
            compose.Desembolsos = new List<PrestamoDesembolsoResult>(); return compose;
        }
        public override int GetId(PrestamoComponenteCompose entity)
        {
            return entity.IdPrestamo;
        }
        public override PrestamoComponenteCompose GetById(int id)
        {
            PrestamoComponenteCompose compose = new PrestamoComponenteCompose();
            compose.Prestamo = PrestamoBusiness.Current.GetResultFromList(new PrestamoFilter(){ IdPrestamo= id}).FirstOrDefault();
            compose.Componentes = PrestamoComponenteBusiness.Current.GetPrestamoObjetivoComponenteCompose(new PrestamoComponenteFilter() { IdPrestamo = id });
            compose.Subcomponentes = PrestamoSubComponenteBusiness.Current.GetResultByPrestamoId(id);
            compose.Financiamientos = PrestamoFinanciamientoBusiness.Current.GetResultByPrestamoId(id);
            compose.Desembolsos = PrestamoDesembolsoBusiness.Current.GetResult(new PrestamoDesembolsoFilter() { IdPrestamo = id });
            compose.Convenio = PrestamoConvenioBusiness.Current.GetResult(new PrestamoConvenioFilter() { IdPrestamo = id }).SingleOrDefault();
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(PrestamoComponenteCompose entity, IContextUser contextUser)
        {
            try
            {
                Dictionary<int, int> clavesTraducir = new Dictionary<int, int>();
                foreach (PrestamoObjetivoComponenteCompose c in entity.Componentes)
                {
                    Int32 key = c.Componente.IdPrestamoComponente;
                    PrestamoObjetivoComponenteComposeBusiness.Current.Add(c, contextUser);
                    clavesTraducir.Add(key, c.Componente.IdPrestamoComponente);
                }
                foreach (PrestamoSubComponenteResult s in entity.Subcomponentes)
                {
                    s.IdPrestamoComponente = clavesTraducir[s.IdPrestamoComponente];
                    PrestamoSubComponente e = s.ToEntity();
                    PrestamoSubComponenteBusiness.Current.Add(e, contextUser);
                    s.IdPrestamoSubComponente = e.IdPrestamoSubComponente;
                }
                foreach (PrestamoFinanciamientoResult f in entity.Financiamientos)
                {
                    f.IdPrestamoComponente = clavesTraducir[f.IdPrestamoComponente];
                    PrestamoFinanciamiento e = f.ToEntity();
                    PrestamoFinanciamientoBusiness.Current.Add(e, contextUser);
                    f.IdPrestamoFinanciamiento = e.IdPrestamoFinanciamiento;
                }
                foreach (PrestamoDesembolsoResult d in entity.Desembolsos)
                {
                    d.IdPrestamo = entity.IdPrestamo;
                    PrestamoDesembolso e = d.ToEntity();
                    PrestamoDesembolsoBusiness.Current.Add(e, contextUser);
                    d.IdPrestamoDesembolso = e.IdPrestamoDesembolso;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Update(PrestamoComponenteCompose entity, IContextUser contextUser)
        {
            #region Desembolsos
            List<int> actualIdsDes = (from o in entity.Desembolsos where o.IdPrestamoDesembolso > 0 select o.IdPrestamoDesembolso).ToList();
            List<PrestamoDesembolso> oldDetailDes = PrestamoDesembolsoBusiness.Current.GetList(new PrestamoDesembolsoFilter() { IdPrestamo = entity.IdPrestamo });
            List<PrestamoDesembolso> deletesDes = (from o in oldDetailDes where !actualIdsDes.Contains(o.IdPrestamoDesembolso) select o).ToList();
            PrestamoDesembolsoBusiness.Current.Delete(deletesDes, contextUser);

            foreach (PrestamoDesembolsoResult d in entity.Desembolsos)
            {
                d.IdPrestamo = entity.IdPrestamo;
                PrestamoDesembolso e = d.ToEntity();
                if (d.IdPrestamoDesembolso <= 0)
                    PrestamoDesembolsoBusiness.Current.Add(e, contextUser);
                else
                    PrestamoDesembolsoBusiness.Current.Update(e, contextUser);
                d.IdPrestamoDesembolso = e.IdPrestamoDesembolso;
            }
            #endregion
            
            #region Componentes
            List<int> actualIdsComp = (from o in entity.Componentes where o.Componente.IdPrestamoComponente > 0 select o.Componente.IdPrestamoComponente).ToList();
            List<PrestamoComponente> oldDetailComp = PrestamoComponenteBusiness.Current.GetList(new PrestamoComponenteFilter() { IdPrestamo = entity.IdPrestamo });
            List<PrestamoComponente> deletesComp = (from o in oldDetailComp where !actualIdsComp.Contains(o.IdPrestamoComponente) select o).ToList();
            List<int> actualIdsDeleteComp = new List<int>();
            foreach (PrestamoComponente delPg in deletesComp)
            {
                PrestamoSubComponenteBusiness.Current.Delete(new PrestamoSubComponenteFilter() { IdPrestamoComponente = delPg.IdPrestamoComponente }, contextUser);
                PrestamoFinanciamientoBusiness.Current.Delete(new PrestamoFinanciamientoFilter() { IdPrestamoComponente = delPg.IdPrestamoComponente }, contextUser);
                PrestamoObjetivoComponenteCompose c = PrestamoObjetivoComponenteComposeBusiness.Current.GetById(delPg.IdPrestamoComponente);
                PrestamoObjetivoComponenteComposeBusiness.Current.Delete(c, contextUser);

                entity.Financiamientos.RemoveAll(f => f.IdPrestamoComponente == delPg.IdPrestamoComponente);
                entity.Subcomponentes.RemoveAll(s => s.IdPrestamoComponente == delPg.IdPrestamoComponente);
            }

            Dictionary<int, int> clavesTraducir = new Dictionary<int, int>();
            foreach (PrestamoObjetivoComponenteCompose c in entity.Componentes)
            {
                Int32 key = c.Componente.IdPrestamoComponente;
                if(c.Componente.IdPrestamoComponente <=0)
                    PrestamoObjetivoComponenteComposeBusiness.Current.Add(c, contextUser);
                else
                    PrestamoObjetivoComponenteComposeBusiness.Current.Update(c, contextUser);
                clavesTraducir.Add(key, c.Componente.IdPrestamoComponente);
            }
            #endregion

            #region SubComponentes
            List<int> actualIdsSub = (from o in entity.Subcomponentes where o.IdPrestamoSubComponente > 0 select o.IdPrestamoSubComponente).ToList();
            List<PrestamoSubComponente> oldDetailSub = PrestamoSubComponenteBusiness.Current.GetByPrestamoId(entity.IdPrestamo);
            List<PrestamoSubComponente> deletesSub = (from o in oldDetailSub where !actualIdsSub.Contains(o.IdPrestamoSubComponente) select o).ToList();
            PrestamoSubComponenteBusiness.Current.Delete(deletesSub, contextUser);

            Dictionary<int, int> clavesTraducirSC = new Dictionary<int, int>();
            foreach (PrestamoSubComponenteResult s in entity.Subcomponentes)
            {
                Int32 key = s.IdPrestamoSubComponente;
                s.IdPrestamoComponente = clavesTraducir[s.IdPrestamoComponente];
                PrestamoSubComponente e = s.ToEntity();
                if(e.IdPrestamoSubComponente <= 0)
                    PrestamoSubComponenteBusiness.Current.Add(e, contextUser);
                else
                    PrestamoSubComponenteBusiness.Current.Update(e, contextUser);
                s.IdPrestamoSubComponente = e.IdPrestamoSubComponente;
                clavesTraducirSC.Add(key, s.IdPrestamoSubComponente);
            }
            #endregion 

            #region Financiamiento
            List<int> actualIdsFin = (from o in entity.Financiamientos where o.IdPrestamoFinanciamiento > 0 select o.IdPrestamoFinanciamiento).ToList();
            List<PrestamoFinanciamiento> oldDetailFin = PrestamoFinanciamientoBusiness.Current.GetByPrestamoId(entity.IdPrestamo);
            List<PrestamoFinanciamiento> deletesFin = (from o in oldDetailFin where !actualIdsFin.Contains(o.IdPrestamoFinanciamiento) select o).ToList();
            PrestamoFinanciamientoBusiness.Current.Delete(deletesFin, contextUser);

            foreach (PrestamoFinanciamientoResult f in entity.Financiamientos)
            {
                f.IdPrestamoComponente = clavesTraducir[f.IdPrestamoComponente];
                f.IdPrestamoSubComponente = (f.IdPrestamoSubComponente!=null && f.IdPrestamoSubComponente != 0) ? (Int32?)clavesTraducirSC[(Int32)f.IdPrestamoSubComponente] : (Int32?)0;
                PrestamoFinanciamiento e = f.ToEntity();
                if(e.IdPrestamoFinanciamiento <= 0)
                    PrestamoFinanciamientoBusiness.Current.Add(e, contextUser);
                else
                    PrestamoFinanciamientoBusiness.Current.Update(e, contextUser);
                f.IdPrestamoFinanciamiento = e.IdPrestamoFinanciamiento;
            }
            #endregion

            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }
        public override void Delete(PrestamoComponenteCompose entity, IContextUser contextUser)
        {

        }
        #endregion

        #region Validations

        public override void Validate(PrestamoComponenteCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            //Matias 20140428 - Tarea 140
            decimal total = 0;
            foreach (PrestamoFinanciamientoResult f in entity.Financiamientos)
                total += f.Monto;
            DataHelper.Validate((entity.Convenio != null && entity.Convenio.MontoTotal >= total), SolutionContext.Current.TextManager.Translate("VALIDAR_PRESTAMO_MONTOTOTAL_COMPONENTES"));
            //FinMatias 20140428 - Tarea 140

            //Matias 20140428 - Tarea 141
            decimal? totalAcum = 0;
            foreach (PrestamoDesembolsoResult d in entity.Desembolsos)
                totalAcum += d.MontoAcumulado;
            DataHelper.Validate((entity.Convenio != null && entity.Convenio.MontoPrestamo >= totalAcum), SolutionContext.Current.TextManager.Translate("VALIDAR_PRESTAMO_MONTOPRESTAMO_DESESMBOLSOS"));
            //FinMatias 20140428 - Tarea 141
        }

        public override bool Can(PrestamoComponenteCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return true;
        }

        public override bool Equals(PrestamoComponenteCompose source, PrestamoComponenteCompose target)
        {

            bool eq = source.IdPrestamo == target.IdPrestamo;

            if (eq)
            {
                #region Componentes

                if (source.Componentes.Count() != target.Componentes.Count()) return false;
                bool eqObj = true;

                foreach (PrestamoObjetivoComponenteCompose com in source.Componentes)
                {
                    PrestamoObjetivoComponenteCompose e = com;
                    if (target.Componentes.Where(p => p.Componente.IdObjetivo == e.Componente.IdObjetivo).Count() == 1)
                    {
                        PrestamoObjetivoComponenteCompose b = target.Componentes.Where(p => p.Componente.IdObjetivo == e.Componente.IdObjetivo).SingleOrDefault();
                        eqObj = e.Componente.IdPrestamo == b.Componente.IdPrestamo &&
                                         e.Descripcion == b.Descripcion;


                        //eqObj = eqObj && e.Supuestos.Count == b.Supuestos.Count;
                        //foreach (ObjetivoSupuestoResult xe in e.Supuestos)
                        //{
                        //    if (b.Supuestos.Where(x => x.IdObjetivoSupuesto == xe.IdObjetivoSupuesto) != null)
                        //    {
                        //        ObjetivoSupuestoResult xb = b.Supuestos.Where(x => x.IdObjetivoSupuesto == xe.IdObjetivoSupuesto).SingleOrDefault();
                        //        eqObj = eqObj && xb.Descripcion == xe.Descripcion;
                        //    }
                        //}
                        eqObj = eqObj && PrestamoObjetivoComponenteComposeBusiness.Current.Equals(com, b);
                    }
                    else
                        eqObj = false;
                }
                #endregion

                #region Sub Componentes

                if (source.Subcomponentes.Count() != target.Subcomponentes.Count()) return false;

                bool eqSub = true;
                foreach (PrestamoSubComponenteResult sub in source.Subcomponentes)
                {
                    PrestamoSubComponenteResult e = sub;
                    if (target.Subcomponentes.Where(p => p.IdPrestamoSubComponente == e.IdPrestamoSubComponente).Count() == 1 )
                    {
                        PrestamoSubComponenteResult b = target.Subcomponentes.Where(p => p.IdPrestamoSubComponente == e.IdPrestamoSubComponente).SingleOrDefault();
                        //eqSub = eqSub && e.Descripcion == b.Descripcion;
                        eqSub = PrestamoSubComponenteBusiness.Current.Equals(e, b);
                    }
                    else
                        eqSub = false;
                }
                #endregion

                #region Finianciamiento

                if (source.Financiamientos.Count() != target.Financiamientos.Count()) return false;
                bool eqFin = true;
                foreach (PrestamoFinanciamientoResult fin in source.Financiamientos)
                {
                    PrestamoFinanciamientoResult e = fin;
                    if (target.Financiamientos.Where(p => p.IdPrestamoFinanciamiento == e.IdPrestamoFinanciamiento).Count() == 1)
                    {
                        PrestamoFinanciamientoResult b = target.Financiamientos.Where(p => p.IdPrestamoFinanciamiento == e.IdPrestamoFinanciamiento).SingleOrDefault();
                        //eqFin = e.IdPrestamoComponente == b.IdPrestamoComponente &&
                        //                 e.IdFuenteFinanciamiento == b.IdFuenteFinanciamiento &&
                        //                 e.IdPrestamoSubComponente == b.IdPrestamoSubComponente &&
                        //                 e.Monto == b.Monto;
                        eqFin = PrestamoFinanciamientoBusiness.Current.Equals(e, b);
                    }
                    else
                        eqFin = false;
                }
                #endregion

                #region Desembolso

                if (source.Financiamientos.Count() != target.Financiamientos.Count()) return false;
                bool eqDes = true;
                foreach (PrestamoDesembolsoResult des in source.Desembolsos)
                {
                    PrestamoDesembolsoResult e = des;
                    if (target.Desembolsos.Where(p => p.IdPrestamoDesembolso == e.IdPrestamoDesembolso).Count() == 1)
                    {
                        PrestamoDesembolsoResult b = target.Desembolsos.Where(p => p.IdPrestamoDesembolso == e.IdPrestamoDesembolso).SingleOrDefault();
                        //eqDes = e.Fecha == b.Fecha &&
                        //                 e.Observacion == b.Observacion &&
                        //                 e.MontoAcumulado == b.MontoAcumulado;
                        eqDes = PrestamoDesembolsoBusiness.Current.Equals(e, b);
                    }
                    else
                        eqDes = false;
                }
                #endregion

                eq = eqObj && eqFin && eqSub && eqDes;
            }

            return eq;
        }

        #endregion
    }
}
  