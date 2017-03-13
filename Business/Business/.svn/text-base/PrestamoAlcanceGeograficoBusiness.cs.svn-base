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
    public class PrestamoAlcanceGeograficoBusiness : _PrestamoAlcanceGeograficoBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoAlcanceGeograficoBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoAlcanceGeograficoBusiness() {}
	   public static PrestamoAlcanceGeograficoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoAlcanceGeograficoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
    public class PrestamoAlcanceGeograficoComposeBusiness : EntityComposeBusiness<PrestamoAlcanceGeograficoCompose, Prestamo, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoAlcanceGeograficoComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoAlcanceGeograficoComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoAlcanceGeograficoComposeBusiness();
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

        protected override IEntityData<PrestamoAlcanceGeograficoCompose, PrestamoFilter, PrestamoResult, int> EntityData
        {
            get { return null; }
        }

        #region Gets
        public override PrestamoAlcanceGeograficoCompose GetNew(PrestamoResult example)
        {
            PrestamoAlcanceGeograficoCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.Alcances = new List<PrestamoAlcanceGeograficoResult>();
            return compose;
        }
        public override PrestamoAlcanceGeograficoCompose GetNew()
        {
            PrestamoAlcanceGeograficoCompose compose = base.GetNew();
            compose.Prestamo = null;
            compose.Alcances = new List<PrestamoAlcanceGeograficoResult>();
            return compose;
        }
        public override int GetId(PrestamoAlcanceGeograficoCompose entity)
        {
            return entity.IdPrestamo;
        }
        public override PrestamoAlcanceGeograficoCompose GetById(int id)
        {
            PrestamoAlcanceGeograficoCompose compose = new PrestamoAlcanceGeograficoCompose();
            compose.Prestamo = PrestamoBusiness.Current.GetResultFromList(new PrestamoFilter(){ IdPrestamo= id}).FirstOrDefault();
            compose.Alcances = PrestamoAlcanceGeograficoBusiness.Current.GetResult(new PrestamoAlcanceGeograficoFilter() { IdPrestamo = id });
            return compose;
        }
        #endregion

        #region Actions
        public override void Add(PrestamoAlcanceGeograficoCompose entity, IContextUser contextUser)
        {
            try
            {
                foreach (PrestamoAlcanceGeograficoResult pagr in entity.Alcances)
                {
                    pagr.IdPrestamo = entity.IdPrestamo;
                    PrestamoAlcanceGeografico pag = pagr.ToEntity();
                    PrestamoAlcanceGeograficoBusiness.Current.Add(pag, contextUser);
                    pagr.IdPrestamoAlcanceGeografico = pag.IdPrestamoAlcanceGeografico;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public override void Update(PrestamoAlcanceGeograficoCompose entity, IContextUser contextUser)
        {
            List<PrestamoAlcanceGeograficoResult> copy = PrestamoAlcanceGeograficoBusiness.Current.CopiesResult(entity.Alcances);
             try
            {
                #region Alcances
                // Elimina los que ya no estan
                List<int> actualIdsAlc = (from o in entity.Alcances where o.IdPrestamoAlcanceGeografico > 0 select o.IdPrestamoAlcanceGeografico).ToList();
                List<PrestamoAlcanceGeografico> oldDetailAlc = PrestamoAlcanceGeograficoBusiness.Current.GetList(new PrestamoAlcanceGeograficoFilter() { IdPrestamo = entity.IdPrestamo });
                List<PrestamoAlcanceGeografico> deletesAlc = (from o in oldDetailAlc where !actualIdsAlc.Contains(o.IdPrestamoAlcanceGeografico) select o).ToList();
                PrestamoAlcanceGeograficoBusiness.Current.Delete(deletesAlc, contextUser);

                foreach (PrestamoAlcanceGeograficoResult pagr in entity.Alcances)
                {
                    PrestamoAlcanceGeografico pag = pagr.ToEntity();
                    pag.IdPrestamo = entity.IdPrestamo;
                    if (pag.IdPrestamoAlcanceGeografico <= 0)
                    {
                        pag.IdPrestamoAlcanceGeografico = 0;
                        PrestamoAlcanceGeograficoBusiness.Current.Add(pag, contextUser);
                    }
                    else
                        PrestamoAlcanceGeograficoBusiness.Current.Update(pag, contextUser);
                    pagr.IdPrestamoAlcanceGeografico = pag.IdPrestamoAlcanceGeografico;
                }
                #endregion

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;

            }
            catch (Exception exception)
            {
                entity.Alcances = copy;
                throw exception;
            }
        }
        public override void Delete(PrestamoAlcanceGeograficoCompose entity, IContextUser contextUser)
        {
            PrestamoAlcanceGeograficoBusiness.Current.Delete(new PrestamoAlcanceGeograficoFilter() { IdPrestamo = entity.IdPrestamo }, contextUser);
        }
        #endregion

        #region protected Methods

        #endregion

        #region Validations
        public override void Validate(PrestamoAlcanceGeograficoCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {

            foreach (PrestamoAlcanceGeograficoResult pagr in entity.Alcances)
            {
                PrestamoAlcanceGeografico pag = pagr.ToEntity();
                pag.IdPrestamo = entity.IdPrestamo;
                PrestamoAlcanceGeograficoBusiness.Current.Validate(pag, actionName, contextUser, args);
            }

        }

        public override bool Can(PrestamoAlcanceGeograficoCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            bool retval = false;


            foreach (PrestamoAlcanceGeograficoResult pagr in entity.Alcances)
            {
                PrestamoAlcanceGeografico pag = pagr.ToEntity();
                pag.IdPrestamo = entity.IdPrestamo;
                retval = retval && PrestamoAlcanceGeograficoBusiness.Current.Can(pag, actionName, contextUser, args);
            }

            return retval;
        }

        public override bool Equals(PrestamoAlcanceGeograficoCompose source, PrestamoAlcanceGeograficoCompose target)
        {
            bool eq = source.IdPrestamo.Equals(target.IdPrestamo);
            if (eq)
            {
                if (source.Alcances.Count() != target.Alcances.Count()) return false;

                bool eqAlc = true;
                foreach (PrestamoAlcanceGeograficoResult pagr in source.Alcances)
                {
                    PrestamoAlcanceGeograficoResult pagrTarget = target.Alcances.Where(a => a.IdPrestamoAlcanceGeografico == pagr.IdPrestamoAlcanceGeografico).SingleOrDefault();
                    eqAlc = eqAlc && pagrTarget != null && pagr.IdClasificacionGeografica == pagrTarget.IdClasificacionGeografica && pagr.IdPrestamo == pagrTarget.IdPrestamo;
                }
                if (!eqAlc) return eqAlc;
            }
            return eq;
        }
        #endregion
    }
}
