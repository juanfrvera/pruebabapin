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
    public class ProyectoPrincipiosFormulacionComposeService : EntityComposeService<ProyectoPrincipiosFormulacionCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoPrincipiosFormulacionComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoPrincipiosFormulacionComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoPrincipiosFormulacionComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoPrincipiosFormulacionComposeService"; } }

        protected readonly ProyectoPrincipiosFormulacionComposeBusiness Business = ProyectoPrincipiosFormulacionComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoPrincipiosFormulacionCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoPrincipiosFormulacionCompose GetById(Int32 idProyecto)
        {
            return ProyectoPrincipiosFormulacionComposeBusiness.Current.GetById(idProyecto);
        }
    }
}

