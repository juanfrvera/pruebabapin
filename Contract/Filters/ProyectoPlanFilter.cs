using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoPlanFilter : _ProyectoPlanFilter
    {
        public bool ValidarPlanPeriodoVersionActiva { get; set; }
    }
}
