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
    public class ProyectoGeoLocalizacionComposeService : EntityComposeService<ProyectoGeoLocalizacionCompose, ProyectoGeoLocalizacionFilter, ProyectoGeoLocalizacionResult, int>
    {
        #region Singleton

        private static volatile ProyectoGeoLocalizacionComposeService current;

        private static object syncRoot = new Object();

        public static ProyectoGeoLocalizacionComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoGeoLocalizacionComposeService();
                    }
                }
                return current;
            }
        }

        #endregion

        protected readonly ProyectoGeoLocalizacionComposeBusiness Business = new ProyectoGeoLocalizacionComposeBusiness();

        protected override IEntityBusiness<ProyectoGeoLocalizacionCompose, ProyectoGeoLocalizacionFilter, ProyectoGeoLocalizacionResult, int> EntityBusiness
        {
            get { return this.Business; }
        }

        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return ProyectoGeoLocalizacionService.Current.Execute(id, actionName, contextUser, args);
        }
    }

    public class ProyectoGeoLocalizacionService : _ProyectoGeoLocalizacionService
    {
        #region Singleton

        private static volatile ProyectoGeoLocalizacionService current;

        private static object syncRoot = new Object();

        public static ProyectoGeoLocalizacionService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoGeoLocalizacionService();
                    }
                }
                return current;
            }
        }

        #endregion

        public virtual ProyectoGeoLocalizacionResult GetProyectoGeoLocalizacion(ProyectoGeoLocalizacionFilter filter)
        {
            return ProyectoGeoLocalizacionBusiness.Current.GetProyectoGeoLocalizacion(filter);
        }

        public virtual List<ProyectoGeoLocalizacionResult> GetProyectoGeoLocalizaciones(ProyectoGeoLocalizacionFilter filter)
        {
            return ProyectoGeoLocalizacionBusiness.Current.GetProyectoGeoLocalizaciones(filter);
        }
    }
}
