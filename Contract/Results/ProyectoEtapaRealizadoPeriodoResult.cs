using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;

namespace Contract
{
	[Serializable]
    public class ProyectoEtapaRealizadoPeriodoResult : _ProyectoEtapaRealizadoPeriodoResult
    {
        //Matias 20140121 - Tarea 107
        public Int32 IdMonedaProyectoEtapaRealizado { set; get; }
        public bool Bloqueado { set; get; }
        public bool UsaMonedaBase
        {
            get
            {
                return (this.IdMonedaProyectoEtapaRealizado == SolutionContext.Current.BaseCurrencyId);
            }
        }
        public decimal MontoPeriodo
        {
            get
            {
                if (!UsaMonedaBase)
                    return (decimal)Monto;
                return 0;
            }
        }
        public decimal CotizacionPeriodo
        {
            get
            {
                if (!UsaMonedaBase && Cotizacion != null)
                    return (decimal)Cotizacion;
                return 0;
            }
        }
        public decimal MontoCalculadoPeriodo
        {
            get
            {
                if (UsaMonedaBase)
                    return MontoCalculado;
                return (decimal)Monto * (decimal)CotizacionPeriodo;
            }
        }
        //FinMatias 20140121 - Tarea 107
    }
}
