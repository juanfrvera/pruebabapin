using Business;
using Contract;
using Contract.Others_Contracts;
using Service.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class ProyectoShapeFileComposeService : EntityComposeService<ProyectoShapeFileCompose, ProyectoShapeFileFilter, ProyectoShapeFileResult, int>
    {
        #region Singleton

        private static volatile ProyectoShapeFileComposeService current;

        private static object syncRoot = new Object();

        public static ProyectoShapeFileComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoShapeFileComposeService();
                    }
                }
                return current;
            }
        }

        #endregion

        protected readonly ProyectoShapeFileComposeBusiness Business = new ProyectoShapeFileComposeBusiness();

        protected override IEntityBusiness<ProyectoShapeFileCompose, ProyectoShapeFileFilter, ProyectoShapeFileResult, int> EntityBusiness
        {
            get { return this.Business; }
        }

        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return ProyectoShapeFileService.Current.Execute(id, actionName, contextUser, args);
        }
    }

    public class ProyectoShapeFileService : _ProyectoShapeFileService
    {
        #region Singleton

        private static volatile ProyectoShapeFileService current;

        private static object syncRoot = new Object();

        public static ProyectoShapeFileService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoShapeFileService();
                    }
                }
                return current;
            }
        }

        public virtual List<ProyectoShapeFileResult> GetShapes(ProyectoShapeFileFilter filter)
       {
           return ProyectoShapeFileBusiness.Current.GetShapes(filter);
       }
        
        #endregion
    }
}
