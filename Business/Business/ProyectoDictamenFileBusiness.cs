using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoDictamenFileBusiness : _ProyectoDictamenFileBusiness
    {
        #region Singleton
        private static volatile ProyectoDictamenFileBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoDictamenFileBusiness() {}
        public static ProyectoDictamenFileBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoDictamenFileBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public List<ProyectoDictamenFileResult> GetWithFileInfo(Int32 IdProyectoDictamen)
        {
            return ProyectoDictamenFileData.Current.GetWithFileInfo(IdProyectoDictamen);
        }


        #region Actions

        public override void Update(ProyectoDictamenFile entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}
