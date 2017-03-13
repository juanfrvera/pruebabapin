using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PlanPeriodoFilter : _PlanPeriodoFilter
    {
        public bool? EsPlanPeriodoVersionActivo { get; set; }
    }
}
