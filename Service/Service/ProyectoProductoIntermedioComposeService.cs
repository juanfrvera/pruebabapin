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
    public class ProyectoProductoIntermedioComposeService : EntityComposeService<ProyectoProductoIntermedioCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoProductoIntermedioComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoProductoIntermedioComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoProductoIntermedioComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoProductoIntermedioComposeService"; } }

        protected readonly ProyectoProductoIntermedioComposeBusiness Business = ProyectoProductoIntermedioComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoProductoIntermedioCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoProductoIntermedioCompose GetById(Int32 idProyecto)
        {
            return ProyectoProductoIntermedioComposeBusiness.Current.GetById(idProyecto);
        }

        public bool Can(ProyectoProductoIntermedioCompose entity, int IdProyectoEtapa, string actionName, IContextUser contextUser)
        {
            return ProyectoProductoIntermedioComposeBusiness.Current.Can(entity, IdProyectoEtapa, actionName, contextUser);
        }
    }
}