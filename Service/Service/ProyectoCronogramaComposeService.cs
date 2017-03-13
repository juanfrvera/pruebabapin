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
    public class ProyectoCronogramaComposeService : EntityComposeService<ProyectoCronogramaCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoCronogramaComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoCronogramaComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoCronogramaComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoCronogramaComposeService"; } }

        protected readonly ProyectoCronogramaComposeBusiness Business = ProyectoCronogramaComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoCronogramaCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoCronogramaCompose GetById(Int32 idProyecto)
        {
            return ProyectoCronogramaComposeBusiness.Current.GetById(idProyecto);
        }

        public ProyectoCronogramaCompose GetByIdFase(Int32 idProyecto, Int32 idFase)
        {
            return ProyectoCronogramaComposeBusiness.Current.GetByIdFase(idProyecto, idFase);
        }

        public static bool ValidateEtapa(ProyectoEtapaResult ActualProyectoEtapa, ProyectoCronogramaCompose Entity, ref string error)
        {
            return ProyectoCronogramaComposeBusiness.Current.ValidateEtapa(ActualProyectoEtapa, Entity, ref error);
        }

        public List<CronogramaTotalPorAnio> GetTotalPorAnio(ProyectoFilter filter)
        {
            return ProyectoCronogramaComposeBusiness.Current.GetTotalPorAnio(filter);
        }
    }
}