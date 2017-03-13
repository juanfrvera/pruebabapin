using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoEtapaIndicadorComposeBusiness : IndicadoresEvolucionComposeBusiness<ProyectoEtapaIndicadorCompose, Indicador, IndicadorFilter, IndicadorResult, int>
    {
        #region Singleton
        private static volatile ProyectoEtapaIndicadorComposeBusiness current;
        private static object syncRoot = new Object();
        public static ProyectoEtapaIndicadorComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEtapaIndicadorComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Indicador, IndicadorFilter, IndicadorResult, int> EntityBusinessBase
        {
            get { return IndicadorBusiness.Current; }
        }

        internal List<ProyectoEtapaIndicadorCompose> GetIndicadoresEtapaProyecto(ProyectoEtapaFilter proyectoEtapaFilter)
        {
            return ProyectoEtapaData.Current.GetIndicadoresEtapaProyecto(proyectoEtapaFilter);
        }
        
        public bool ValidateEvoluciones(List<IndicadorEvolucionResult> Evoluciones)
        {
            return base.ValidateEvoluciones(Evoluciones);
        }

        #region Actions

        public override void Update(ProyectoEtapaIndicadorCompose entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}