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
    public class ProyectoFilesComposeService : EntityComposeService<ProyectoFilesCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoFilesComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoFilesComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoFilesComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoFilesComposeService"; } }

        protected readonly ProyectoFilesComposeBusiness Business = ProyectoFilesComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoFilesCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoFilesCompose GetById(Int32 idProyecto)
        {
            return ProyectoFilesComposeBusiness.Current.GetById(idProyecto);
        }
    }
}