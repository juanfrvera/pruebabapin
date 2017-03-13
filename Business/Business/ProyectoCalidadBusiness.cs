using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoCalidadBusiness : _ProyectoCalidadBusiness
    {
        #region Singleton
        private static volatile ProyectoCalidadBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoCalidadBusiness() {}
        public static ProyectoCalidadBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoCalidadBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        internal ProyectoCalidadResult GetCalidadActual(int idProyecto)
        {
            return this.Data.GetCalidadActual(idProyecto);
        }

        public ProyectoCalidadResult GetCalidadSugerida(int idProyecto)
        {
            return this.Data.GetCalidadSugerida(idProyecto);
        }

        public override ListPaged<ProyectoCalidadResult> GetResult(ProyectoCalidadFilter filter)
        {
            if (!filter.IgnorarProvincias)
                return GetListadoExtendido(filter);
            return base.GetResult(filter);
        }

        public ListPaged<ProyectoCalidadResult> GetListadoExtendido(ProyectoCalidadFilter proyectoCalidadFilter)
        {
            return ProyectoCalidadData.Current.GetListadoExtendido(proyectoCalidadFilter);
        }


        #region Actions

        public override void Update(ProyectoCalidad entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}