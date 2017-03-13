using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoOrigenFinanciamientoBusiness : _ProyectoOrigenFinanciamientoBusiness
    {
        #region Singleton
        private static volatile ProyectoOrigenFinanciamientoBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoOrigenFinanciamientoBusiness() {}
        public static ProyectoOrigenFinanciamientoBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoOrigenFinanciamientoBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public List<ProyectoOrigenFinanciamientoResult> GetOrigenes(ProyectoOrigenFinanciamientoFilter filter)
        {
            return ProyectoOrigenFinanciamientoData.Current.GetOrigenes(filter);
        }

        #region Actions

        public override void Update(ProyectoOrigenFinanciamiento entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}
