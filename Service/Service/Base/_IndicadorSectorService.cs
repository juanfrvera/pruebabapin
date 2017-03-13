using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorSectorService : EntityService<nc.IndicadorSector,nc.IndicadorSectorFilter,nc.IndicadorSectorResult,int>
    {        
		protected readonly IndicadorSectorBusiness Business = new IndicadorSectorBusiness();
        protected override IEntityBusiness<nc.IndicadorSector,nc.IndicadorSectorFilter,nc.IndicadorSectorResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
