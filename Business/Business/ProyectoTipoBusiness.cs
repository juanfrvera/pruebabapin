using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoTipoBusiness : _ProyectoTipoBusiness
    {
        #region Singleton
        private static volatile ProyectoTipoBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoTipoBusiness() {}
        public static ProyectoTipoBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoTipoBusiness();
                    }
                }
                return current;
            }
        }
        #endregion
        public override ProyectoTipo GetNew()
        {
            ProyectoTipo entity = base.GetNew();
            entity.Activo = true;
            return entity;
        }

        #region Actions

        public override void Update(ProyectoTipo entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}
