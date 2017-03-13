using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;
using System.Collections;

namespace Service
{
    public class ProyectoCalidadComposeService : EntityComposeService<ProyectoCalidadCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoCalidadComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoCalidadComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoCalidadComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoCalidadComposeService"; } }

        protected readonly ProyectoCalidadComposeBusiness Business = ProyectoCalidadComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoCalidadCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoCalidadCompose GetById(Int32 idProyecto)
        {
            return ProyectoCalidadComposeBusiness.Current.GetById(idProyecto);
        }

        public DetalleCalidadCompose GetDetalleCalidad(int idProyecto)
        {
            return ProyectoCalidadComposeBusiness.Current.GetDetalleCalidad(idProyecto);
        }
    }
}