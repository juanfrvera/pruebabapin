using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoProductoBusiness : _ProyectoProductoBusiness
    {
        #region Singleton
        private static volatile ProyectoProductoBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoProductoBusiness() {}
        public static ProyectoProductoBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoProductoBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        #region Actions

        public override void Update(ProyectoProducto entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}
