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
    public class ProyectoObjetivosComposeService : EntityComposeService<ProyectoObjetivosCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoObjetivosComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoObjetivosComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoObjetivosComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoObjetivosComposeService"; } }

        protected readonly ProyectoObjetivosComposeBusiness Business = ProyectoObjetivosComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoObjetivosCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoObjetivosCompose GetById(Int32 idProyecto)
        {
            return ProyectoObjetivosComposeBusiness.Current.GetById(idProyecto);
        }
    }
}
