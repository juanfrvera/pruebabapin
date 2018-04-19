using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoEtapaInformacionPresupuestariaBusiness : _ProyectoEtapaInformacionPresupuestariaBusiness
    {
        #region Singleton
        private static volatile ProyectoEtapaInformacionPresupuestariaBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoEtapaInformacionPresupuestariaBusiness() {}
        public static ProyectoEtapaInformacionPresupuestariaBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEtapaInformacionPresupuestariaBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public List<ProyectoEtapaInformacionPresupuestariaResult> GetEtapasInformacionPresupuestarias(ProyectoEtapaFilter filter)
        {
            return ProyectoEtapaInformacionPresupuestariaData.Current.GetEtapasInformacionPresupuestarias(filter);
        }

        public bool ValidarEtapasInformacionPresupuestarias(ProyectoEtapaInformacionPresupuestariaResult ActualProyectoEtapaInformacionPresupuestaria, ProyectoCronogramaCompose Entity, Int32 idResult)
        {
            // Valida Requerido
            bool retval = ActualProyectoEtapaInformacionPresupuestaria.IdClasificacionGasto > 0 &&
                          ActualProyectoEtapaInformacionPresupuestaria.IdFuenteFinanciamiento > 0 &&
                          ActualProyectoEtapaInformacionPresupuestaria.IdMoneda > 0 &&
                          ActualProyectoEtapaInformacionPresupuestaria.PeriodosUtilizados.Count > 0;

            bool alguno = false;
            foreach (ProyectoEtapaInformacionPresupuestariaPeriodoResult p in ActualProyectoEtapaInformacionPresupuestaria.Periodos)
                alguno = alguno || p.MontoInicial > 0 || p.MontoVigente > 0 || p.MontoDevengado > 0;
            retval = retval && alguno;

            // Valida Repetido
            if (retval)
            {
                foreach (ProyectoEtapaInformacionPresupuestariaResult x in Entity.EtapasInformacionPresupuestarias.Where(ee => ee.IdProyectoEtapa == ActualProyectoEtapaInformacionPresupuestaria.IdProyectoEtapa))
                {
                    bool repetido = (idResult == 0 || x.IdProyectoEtapaInformacionPresupuestaria != idResult)
                                    && ActualProyectoEtapaInformacionPresupuestaria.IdClasificacionGasto == x.IdClasificacionGasto
                                    && ActualProyectoEtapaInformacionPresupuestaria.IdFuenteFinanciamiento == x.IdFuenteFinanciamiento;
                                    //&& ActualProyectoEtapaInformacionPresupuestaria.IdProyectoOrigenFinanciamiento == x.IdProyectoOrigenFinanciamiento;
                    retval = !repetido;
                    if (!retval) break;
                }
            }

            return retval;
        }


        #region Actions

        public override void Update(ProyectoEtapaInformacionPresupuestaria entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}
