using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ProyectoEtapaRealizadoBusiness : _ProyectoEtapaRealizadoBusiness
    {
        #region Singleton
        private static volatile ProyectoEtapaRealizadoBusiness current;
        private static object syncRoot = new Object();

        //private ProyectoEtapaRealizadoBusiness() {}
        public static ProyectoEtapaRealizadoBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoEtapaRealizadoBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public List<ProyectoEtapaRealizadoResult> GetEtapasRealizadas(ProyectoEtapaFilter filter)
        {
            return ProyectoEtapaRealizadoData.Current.GetEtapasRealizadas(filter);
        }

        public bool ValidarEtapasRealizadas(ProyectoEtapaRealizadoResult ActualProyectoEtapaRealizada, ProyectoCronogramaCompose Entity, Int32 idResult)
        {
            // Valida Requerido
            bool retval = ActualProyectoEtapaRealizada.IdClasificacionGasto > 0 &&
                          ActualProyectoEtapaRealizada.IdFuenteFinanciamiento > 0 &&
                          ActualProyectoEtapaRealizada.IdMoneda > 0 &&
                          ActualProyectoEtapaRealizada.Periodos.Count > 0 &&
                          ActualProyectoEtapaRealizada.Periodos[0].Periodo > 0 &&
                          ActualProyectoEtapaRealizada.Periodos[0].Fecha != null &&
                          ActualProyectoEtapaRealizada.Periodos[0].Fecha != DateTime.MinValue &&
                          //ActualProyectoEtapaRealizada.Periodos[0].Fecha.Year == ActualProyectoEtapaRealizada.Periodos[0].Periodo && 
                          ActualProyectoEtapaRealizada.Periodos[0].MontoCalculado > 0;

            //Matias 20140404 - Tarea 123
            if (SolutionContext.Current.ParameterManager.GetBooleanValue("VALIDAR_PROYECTO_CRONOGRAMAREAL_FECHA"))
            {
                if (ActualProyectoEtapaRealizada.Periodos[0].Periodo != ActualProyectoEtapaRealizada.Periodos[0].Fecha.Year )
                {
                    //No coinciden el periodo y el año de la fecha ingresada para el gasto en curso.
                    retval = false;
                }                    

                foreach (ProyectoEtapaResult per in Entity.Etapas.Where(ee => ee.IdProyectoEtapa == ActualProyectoEtapaRealizada.IdProyectoEtapa ))
                {
                    if ((per.FechaInicioRealizada != null) && (per.FechaInicioRealizada != DateTime.MinValue) && (per.FechaInicioRealizada > ActualProyectoEtapaRealizada.Periodos[0].Fecha))
                    {
                        // Fecha de Inicio de la obra seteada y mayor que el gasto a ingresar.
                        retval = false;
                        break;
                    }
                    else
                        if ((per.FechaFinRealizada != null) && (per.FechaFinRealizada != DateTime.MinValue) && (per.FechaFinRealizada < ActualProyectoEtapaRealizada.Periodos[0].Fecha))
                        {
                            // Fecha de Fin de la obra seteada y menor que el gasto a ingresar.
                            retval = false;
                            break;
                        }
                }
            }
            //FinMatias 20140404 - Tarea 123

            // Valida Repetido
            if (retval)
            {
                foreach (ProyectoEtapaRealizadoResult x in Entity.EtapasRealizadas.Where(ee => ee.IdProyectoEtapa == ActualProyectoEtapaRealizada.IdProyectoEtapa))
                {
                    bool repetido = (idResult == 0 || x.IdProyectoEtapaRealizado != idResult)
                                    && ActualProyectoEtapaRealizada.IdClasificacionGasto == x.IdClasificacionGasto
                                    && ActualProyectoEtapaRealizada.IdFuenteFinanciamiento == x.IdFuenteFinanciamiento
                                    && ActualProyectoEtapaRealizada.IdMoneda == x.IdMoneda
                                    && ActualProyectoEtapaRealizada.Periodos.Count == x.Periodos.Count
                                    && (ActualProyectoEtapaRealizada.Periodos.Count > 0
                                    && ActualProyectoEtapaRealizada.Periodos[0].Periodo == x.Periodos[0].Periodo
                                    && ActualProyectoEtapaRealizada.Periodos[0].Fecha == x.Periodos[0].Fecha);
                    retval = !repetido;
                    if (!retval) break;
                }
            }

            return retval;
        }

        #region Actions

        public override void Update(ProyectoEtapaRealizado entity, IContextUser contextUser)
        {
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;

        }

        #endregion
    }
}