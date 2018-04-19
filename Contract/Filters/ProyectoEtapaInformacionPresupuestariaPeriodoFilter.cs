using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoEtapaInformacionPresupuestariaPeriodoFilter : _ProyectoEtapaInformacionPresupuestariaPeriodoFilter
    {
        public Int32? IdProyecto { get; set; }
        public Int32? IdFase { get; set; }
        public Int32? IdPlanPeriodo { get; set; }
    }
}
