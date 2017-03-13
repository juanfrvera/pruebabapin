using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PlanVersionService : EntityService<nc.PlanVersion,nc.PlanVersionFilter,nc.PlanVersionResult,int>
    {        
		protected readonly PlanVersionBusiness Business = new PlanVersionBusiness();
        protected override IEntityBusiness<nc.PlanVersion,nc.PlanVersionFilter,nc.PlanVersionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
