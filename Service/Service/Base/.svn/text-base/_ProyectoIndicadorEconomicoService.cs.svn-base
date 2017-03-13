using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoIndicadorEconomicoService : EntityService<nc.ProyectoIndicadorEconomico,nc.ProyectoIndicadorEconomicoFilter,nc.ProyectoIndicadorEconomicoResult,int>
    {        
		protected readonly ProyectoIndicadorEconomicoBusiness Business = new ProyectoIndicadorEconomicoBusiness();
        protected override IEntityBusiness<nc.ProyectoIndicadorEconomico,nc.ProyectoIndicadorEconomicoFilter,nc.ProyectoIndicadorEconomicoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
