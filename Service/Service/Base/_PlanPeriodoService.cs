using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PlanPeriodoService : EntityService<nc.PlanPeriodo,nc.PlanPeriodoFilter,nc.PlanPeriodoResult,int>
    {        
		protected readonly PlanPeriodoBusiness Business = new PlanPeriodoBusiness();
        protected override IEntityBusiness<nc.PlanPeriodo,nc.PlanPeriodoFilter,nc.PlanPeriodoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
