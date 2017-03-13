using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;
using System.Collections;

namespace Service
{
    public class PrestamoComponenteService : _PrestamoComponenteService
    {
        #region Singleton
        private static volatile PrestamoComponenteService current;
        private static object syncRoot = new Object();

        //private PrestamoComponenteService() {}
        public static PrestamoComponenteService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoComponenteService();
                    }
                }
                return current;
            }
        }
        #endregion
    }
    public class PrestamoComponenteComposeService : EntityComposeService<PrestamoComponenteCompose, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoComponenteComposeService current;
        private static object syncRoot = new Object();

        public static PrestamoComponenteComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoComponenteComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PrestamoComponenteComposeService"; } }

        protected readonly PrestamoComponenteComposeBusiness Business = PrestamoComponenteComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoComponenteCompose, PrestamoFilter, PrestamoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoService.Current.Execute(id, actionName, contextUser, args);
        }

        public PrestamoComponenteCompose GetById(Int32 idPrestamo)
        {
            return PrestamoComponenteComposeBusiness.Current.GetById(idPrestamo);
        }
    }
}