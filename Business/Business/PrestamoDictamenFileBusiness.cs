using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoDictamenFileBusiness : _PrestamoDictamenFileBusiness
    {
        #region Singleton
        private static volatile PrestamoDictamenFileBusiness current;
        private static object syncRoot = new Object();

        //private PrestamoDictamenFileBusiness() {}
        public static PrestamoDictamenFileBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoDictamenFileBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public List<PrestamoDictamenFileResult> GetWithFileInfo(Int32 IdPrestamoDictamen)
        {
            return PrestamoDictamenFileData.Current.GetWithFileInfo(IdPrestamoDictamen);
        }


        #region Actions

        public override void Update(PrestamoDictamenFile entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}
