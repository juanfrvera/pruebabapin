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
    public class PrestamoDictamenDNIPComposeService : EntityComposeService<PrestamoDictamenDNIPCompose, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoDictamenDNIPComposeService current;
        private static object syncRoot = new Object();

        //private ProyectoGeoreferenciacionService() {}
        public static PrestamoDictamenDNIPComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoDictamenDNIPComposeService();
                    }
                }
                return current;
            }
        }
        #endregion


        public override string ServiceName { get { return "PrestamoDictamenDNIPComposeService"; } }

        protected readonly PrestamoDictamenDNIPComposeBusiness Business = PrestamoDictamenDNIPComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoDictamenDNIPCompose, PrestamoFilter, PrestamoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoService.Current.Execute(id, actionName, contextUser, args);
        }

    }
}
