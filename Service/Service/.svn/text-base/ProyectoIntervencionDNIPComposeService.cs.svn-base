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
    public class ProyectoIntervencionDNIPComposeService : EntityComposeService<ProyectoIntervencionDNIPCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoIntervencionDNIPComposeService current;
        private static object syncRoot = new Object();

        //private ProyectoGeoreferenciacionService() {}
        public static ProyectoIntervencionDNIPComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoIntervencionDNIPComposeService();
                    }
                }
                return current;
            }
        }
        #endregion


        public override string ServiceName { get { return "ProyectoIntervencionDNIPComposeService"; } }

        protected readonly ProyectoIntervencionDNIPComposeBusiness Business = ProyectoIntervencionDNIPComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoIntervencionDNIPCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }

    }
}
