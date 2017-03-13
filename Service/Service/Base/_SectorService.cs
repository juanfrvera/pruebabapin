using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SectorService : EntityService<nc.Sector,nc.SectorFilter,nc.SectorResult,int>
    {        
		protected readonly SectorBusiness Business = new SectorBusiness();
        protected override IEntityBusiness<nc.Sector,nc.SectorFilter,nc.SectorResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
