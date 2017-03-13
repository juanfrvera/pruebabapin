using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PlanTipoService : EntityService<nc.PlanTipo,nc.PlanTipoFilter,nc.PlanTipoResult,int>
    {        
		protected readonly PlanTipoBusiness Business = new PlanTipoBusiness();
        protected override IEntityBusiness<nc.PlanTipo,nc.PlanTipoFilter,nc.PlanTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
