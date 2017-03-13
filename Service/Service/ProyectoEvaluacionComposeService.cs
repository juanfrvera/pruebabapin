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
    public class ProyectoEvaluacionComposeService : EntityComposeService<ProyectoEvaluacionCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoEvaluacionComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoEvaluacionComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEvaluacionComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoEvaluacionComposeService"; } }

        protected readonly ProyectoEvaluacionComposeBusiness Business = ProyectoEvaluacionComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoEvaluacionCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoEvaluacionCompose GetById(Int32 idProyecto)
        {
            return ProyectoEvaluacionComposeBusiness.Current.GetById(idProyecto);
        }
    }
}

