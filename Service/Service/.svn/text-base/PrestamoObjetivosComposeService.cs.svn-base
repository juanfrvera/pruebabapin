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
    public class PrestamoObjetivosComposeService : EntityComposeService<PrestamoObjetivosCompose, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoObjetivosComposeService current;
        private static object syncRoot = new Object();

        public static PrestamoObjetivosComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoObjetivosComposeService();
                    }
                }
                return current;
            }
        }
        #endregion


        public override string ServiceName { get { return "PrestamoObjetivosComposeService"; } }

        protected readonly PrestamoObjetivosComposeBusiness Business = PrestamoObjetivosComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoObjetivosCompose, PrestamoFilter, PrestamoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoService.Current.Execute(id, actionName, contextUser, args);
        }

    }
}