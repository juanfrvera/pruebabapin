using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
    public class ProyectoGeoreferenciacionBusiness : _ProyectoGeoreferenciacionBusiness
    {
        #region Singleton
        private static volatile ProyectoGeoreferenciacionBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoGeoreferenciacionBusiness() {}
        public static ProyectoGeoreferenciacionBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoGeoreferenciacionBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public List<ProyectoGeoreferenciacionResult> GetGeoreferenciaciones(ProyectoGeoreferenciacionFilter filter)
        {
            return ProyectoGeoreferenciacionData.Current.GetGeoreferenciaciones(filter);
        }

        public override void Validate(ProyectoGeoreferenciacion entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdProyecto != default(int), "InvalidField", "Proyecto");
                        DataHelper.Validate(entity.IdGeoreferenciacion != default(int), "InvalidField", "Georeferenciacion");

                    }
                    DataHelper.Validate(entity.IdProyecto != default(int), "InvalidField", "Proyecto");
                    DataHelper.Validate(entity.IdGeoreferenciacion != default(int), "InvalidField", "Georeferenciacion");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdProyectoGeoreferenciacion != default(int), "InvalidField", "ProyectoGeoreferenciacion");

                    break;
            }
        }

        #region Actions

        public override void Update(ProyectoGeoreferenciacion entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}