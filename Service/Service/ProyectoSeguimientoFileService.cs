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
    public class ProyectoSeguimientoFilesComposeService : EntityComposeService<ProyectoSeguimientoFilesCompose, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int>
    {
        #region Singleton
        private static volatile ProyectoSeguimientoFilesComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoSeguimientoFilesComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoSeguimientoFilesComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoSeguimientoFilesComposeService"; } }

        protected readonly ProyectoSeguimientoFilesComposeBusiness Business = ProyectoSeguimientoFilesComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoSeguimientoFilesCompose, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return ProyectoSeguimientoService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoSeguimientoFilesCompose GetById(Int32 idProyectoSeguimiento)
        {
            return ProyectoSeguimientoFilesComposeBusiness.Current.GetById(idProyectoSeguimiento);
        }
    }
    public class ProyectoSeguimientoFileService : _ProyectoSeguimientoFileService
    {
        #region Singleton
        private static volatile ProyectoSeguimientoFileService current;
        private static object syncRoot = new Object();

        //private ProyectoSeguimientoFileService() {}
        public static ProyectoSeguimientoFileService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoSeguimientoFileService();
                    }
                }
                return current;
            }
        }
        #endregion
    }
}
