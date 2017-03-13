using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoEtapaEstimadoBusiness : _ProyectoEtapaEstimadoBusiness
    {
        #region Singleton
        private static volatile ProyectoEtapaEstimadoBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoEtapaEstimadoBusiness() {}
        public static ProyectoEtapaEstimadoBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEtapaEstimadoBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public List<ProyectoEtapaEstimadoResult> GetEtapasEstimadas(ProyectoEtapaFilter filter)
        {
            return ProyectoEtapaEstimadoData.Current.GetEtapasEstimadas(filter);
        }

        public bool ValidarEtapasEstimadas(ProyectoEtapaEstimadoResult ActualProyectoEtapaEstimada, ProyectoCronogramaCompose Entity, Int32 idResult)
        {
            // Valida Requerido
            bool retval = ActualProyectoEtapaEstimada.IdClasificacionGasto > 0 &&
                          ActualProyectoEtapaEstimada.IdFuenteFinanciamiento > 0 &&
                          ActualProyectoEtapaEstimada.IdMoneda > 0 &&
                          ActualProyectoEtapaEstimada.PeriodosUtilizados.Count > 0;

            bool alguno = false;
            foreach (ProyectoEtapaEstimadoPeriodoResult p in ActualProyectoEtapaEstimada.Periodos)
                alguno = alguno || p.MontoCalculado > 0;
            retval = retval && alguno;

            // Valida Repetido
            if (retval)
            {
                foreach (ProyectoEtapaEstimadoResult x in Entity.EtapasEstimadas.Where(ee => ee.IdProyectoEtapa == ActualProyectoEtapaEstimada.IdProyectoEtapa))
                {
                    bool repetido = (idResult == 0 || x.IdProyectoEtapaEstimado != idResult)
                                    && ActualProyectoEtapaEstimada.IdClasificacionGasto == x.IdClasificacionGasto
                                    && ActualProyectoEtapaEstimada.IdFuenteFinanciamiento == x.IdFuenteFinanciamiento;
                                    //&& ActualProyectoEtapaEstimada.IdProyectoOrigenFinanciamiento == x.IdProyectoOrigenFinanciamiento;
                    retval = !repetido;
                    if (!retval) break;
                }
            }

            return retval;
        }


        #region Actions

        public override void Update(ProyectoEtapaEstimado entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}
