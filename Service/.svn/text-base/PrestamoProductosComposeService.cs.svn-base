using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoProductosComposeService : EntityComposeService<PrestamoProductosCompose, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoProductosComposeService current;
        private static object syncRoot = new Object();

        public static PrestamoProductosComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoProductosComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PrestamoProductosComposeService"; } }

        protected readonly PrestamoProductosComposeBusiness Business = PrestamoProductosComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoProductosCompose, PrestamoFilter, PrestamoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, params string[] args)
        {
            return PrestamoService.Current.Execute(id, actionName, contextUser, args);
        }

        public PrestamoProductosCompose GetById(Int32 idPrestamo)
        {
            return PrestamoProductosComposeBusiness.Current.GetById(idPrestamo);
        }
    }
}