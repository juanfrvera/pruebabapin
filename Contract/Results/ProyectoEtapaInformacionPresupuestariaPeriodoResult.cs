using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;

namespace Contract
{
	[Serializable]
    public class ProyectoEtapaInformacionPresupuestariaPeriodoResult : _ProyectoEtapaInformacionPresupuestariaPeriodoResult
    {
        public Int32 IdMonedaProyectoEtapaInformacionPresupuestaria { set; get; }
        public bool Bloqueado { set; get; }
        public bool UsaMonedaBase
        {
            get
            {
                return (this.IdMonedaProyectoEtapaInformacionPresupuestaria == SolutionContext.Current.BaseCurrencyId);
            }
        }
    }
}
