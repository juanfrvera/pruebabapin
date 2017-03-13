using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _CaracterEconomicoService : EntityService<nc.CaracterEconomico,nc.CaracterEconomicoFilter,nc.CaracterEconomicoResult,int>
    {        
		protected readonly CaracterEconomicoBusiness Business = new CaracterEconomicoBusiness();
        protected override IEntityBusiness<nc.CaracterEconomico,nc.CaracterEconomicoFilter,nc.CaracterEconomicoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
