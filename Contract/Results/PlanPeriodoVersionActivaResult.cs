using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PlanPeriodoVersionActivaResult : _PlanPeriodoVersionActivaResult
    {
        public string PlanTipo_Nombre { get; set; }
        public int PlanTipo_Orden { get; set; }

        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("PlanPeriodoVersionActiva", new List<DataColumnMapping>(new DataColumnMapping[]{
                new DataColumnMapping("PlanTipo","PlanTipo_Nombre")
		,new DataColumnMapping("PlanPeriodo","PlanPeriodo_Nombre")
			,new DataColumnMapping("PlanVersion","PlanVersion_Nombre")
			}));
        }
    }
}
