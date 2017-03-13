using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoFileBusiness : _PrestamoFileBusiness
    {
        #region Singleton
        private static volatile PrestamoFileBusiness current;
        private static object syncRoot = new Object();

        //private PrestamoFileBusiness() {}
        public static PrestamoFileBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoFileBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public List<PrestamoFileResult> GetWithFileInfo(Int32 IdPrestamo)
        {
            return PrestamoFileData.Current.GetWithFileInfo(IdPrestamo);
        }


        #region Actions

        public override void Update(PrestamoFile entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}
