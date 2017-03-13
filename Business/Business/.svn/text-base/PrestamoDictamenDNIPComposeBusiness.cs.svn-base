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
    public class PrestamoDictamenDNIPComposeBusiness : EntityComposeBusiness<PrestamoDictamenDNIPCompose, Prestamo, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoDictamenDNIPComposeBusiness current;
        private static object syncRoot = new Object();
        public static PrestamoDictamenDNIPComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoDictamenDNIPComposeBusiness();
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
        #region Gets
        public override PrestamoDictamenDNIPCompose GetNew(PrestamoResult example)
        {
            PrestamoDictamenDNIPCompose compose = base.GetNew();
            PrestamoBusiness.Current.Set(example, compose.prestamo);
            compose.prestamo = new PrestamoResult();
            compose.prestamoDictamen = new List<PrestamoDictamenResult>();

            return compose;
        }
        public override PrestamoDictamenDNIPCompose GetNew()
        {
            PrestamoDictamenDNIPCompose  compose = base.GetNew();
            compose.prestamo = new PrestamoResult();
            compose.prestamoDictamen = new List<PrestamoDictamenResult>();
            return compose;
        }
        public override int GetId(PrestamoDictamenDNIPCompose entity)
        {
            throw new NotImplementedException();
        }
        public override PrestamoDictamenDNIPCompose GetById(int id)
        {
            PrestamoDictamenDNIPCompose compose = new PrestamoDictamenDNIPCompose();
            compose.prestamo = PrestamoBusiness.Current.GetResult(new PrestamoFilter() { IdPrestamo = id }).SingleOrDefault();
            compose.prestamoDictamen = PrestamoDictamenBusiness.Current.GetResult(new PrestamoDictamenFilter() { IdPrestamo  = id });

            return compose;
        }

        public List<DictamenCompose> GetList(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Actions
        public override void Add(PrestamoDictamenDNIPCompose entity, IContextUser contextUser)
        {

        }
        public override void Update(PrestamoDictamenDNIPCompose entity, IContextUser contextUser)
        {

        }
        public override void Delete(PrestamoDictamenDNIPCompose entity, IContextUser contextUser)
        {
            PrestamoBusiness.Current.Delete(entity.prestamo.IdPrestamo , contextUser);
            
        }
        #endregion

        #region Validations
        public override void Validate(PrestamoDictamenDNIPCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
        }
        public override bool Can(PrestamoDictamenDNIPCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoBusiness.Current.Can(entity.prestamo.ToEntity (), actionName, contextUser, args);
        }
        #endregion
    }
}
