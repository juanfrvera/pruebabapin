using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ClasificacionGastoService : _ClasificacionGastoService
    {
        #region Singleton
        private static volatile ClasificacionGastoService current;
        private static object syncRoot = new Object();

        //private ClasificacionGastoService() {}
        public static ClasificacionGastoService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ClasificacionGastoService();
                    }
                }
                return current;
            }
        }
        #endregion

        public List<ClasificacionGastoResult> GetClasificacionGastos(bool PorCodigo, string text)
        {
            return ClasificacionGastoBusiness.Current.GetClasificacionGastos(PorCodigo, text);
        }
        public ListPaged<NodeResult> GetNodesResult(ClasificacionGastoFilter filter)
        {
            return Business.GetNodesResult(filter);
        }
    }
}
