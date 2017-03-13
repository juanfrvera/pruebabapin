using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class OficinaSafBusiness : _OficinaSafBusiness
    {
        #region Singleton
        private static volatile OficinaSafBusiness current;
        private static object syncRoot = new Object();

        //private OficinaSafBusiness() {}
        public static OficinaSafBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new OficinaSafBusiness();
                    }
                }
                return current;
            }
        }
        #endregion


        #region Actions

        public override void Delete(int[] ids, IContextUser contextUser)
        {
            foreach (int id in ids)
            {
                List<OficinaSafPrograma> deletets = OficinaSafProgramaBusiness.Current.GetList(new OficinaSafProgramaFilter() { IdOficinaSaf = id });
                OficinaSafProgramaBusiness.Current.Delete(deletets, contextUser);
                base.Delete(id, contextUser);
            }
        }

        public override void Update(OficinaSaf entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}
