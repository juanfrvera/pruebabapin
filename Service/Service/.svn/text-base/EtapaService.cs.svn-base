using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class EtapaService : _EtapaService
    {
        #region Singleton
        private static volatile EtapaService current;
        private static object syncRoot = new Object();

        //private EtapaService() {}
        public static EtapaService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new EtapaService();
                    }
                }
                return current;
            }
        }
        #endregion

        protected const string ID_ETAPA_OBRA = "ID_ETAPA_OBRA";
        protected const string ID_ETAPA_BIENDEUSO = "ID_ETAPA_BIENDEUSO";
        public Etapa GetEtapaObra()
        {
            Int32 idEtapa = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_ETAPA_OBRA);
            return EtapaBusiness.Current.GetById(idEtapa);
        }
        public Etapa GetEtapaBienDeUso()
        {
            Int32 idEtapa = (Int32)SolutionContext.Current.ParameterManager.GetNumberValue(ID_ETAPA_BIENDEUSO);
            return EtapaBusiness.Current.GetById(idEtapa);
        }
    }
}
