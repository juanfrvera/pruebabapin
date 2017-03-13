using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PlanPeriodoVersionActivaService : EntityService<nc.PlanPeriodoVersionActiva,nc.PlanPeriodoVersionActivaFilter,nc.PlanPeriodoVersionActivaResult,int>
    {        
		protected readonly PlanPeriodoVersionActivaBusiness Business = new PlanPeriodoVersionActivaBusiness();
        protected override IEntityBusiness<nc.PlanPeriodoVersionActiva,nc.PlanPeriodoVersionActivaFilter,nc.PlanPeriodoVersionActivaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
