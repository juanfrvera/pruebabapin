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
    public class ProyectoDictamenFilesComposeService : EntityComposeService<ProyectoDictamenFilesCompose, ProyectoDictamenFilter, ProyectoDictamenResult, int>
    {
        #region Singleton
        private static volatile ProyectoDictamenFilesComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoDictamenFilesComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoDictamenFilesComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoDictamenFilesComposeService"; } }

        protected readonly ProyectoDictamenFilesComposeBusiness Business = ProyectoDictamenFilesComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoDictamenFilesCompose, ProyectoDictamenFilter, ProyectoDictamenResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return ProyectoDictamenService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoDictamenFilesCompose GetById(Int32 idProyectoDictamen)
        {
            return ProyectoDictamenFilesComposeBusiness.Current.GetById(idProyectoDictamen);
        }
    }
    public class ProyectoDictamenFileService : _ProyectoDictamenFileService
    {
        #region Singleton
        private static volatile ProyectoDictamenFileService current;
        private static object syncRoot = new Object();

        //private ProyectoDictamenFileService() {}
        public static ProyectoDictamenFileService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoDictamenFileService();
                    }
                }
                return current;
            }
        }
        #endregion
    }
}
