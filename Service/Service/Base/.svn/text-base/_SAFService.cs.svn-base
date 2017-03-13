using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SafService : EntityService<nc.Saf,nc.SafFilter,nc.SafResult,int>
    {        
		protected readonly SafBusiness Business = new SafBusiness();
        protected override IEntityBusiness<nc.Saf,nc.SafFilter,nc.SafResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
