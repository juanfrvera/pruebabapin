using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PlanVersionFilter : _PlanVersionFilter
    {
        public int? IdPlanPeriodoActivo { get; set; }
    }
}
