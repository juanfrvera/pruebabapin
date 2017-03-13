using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _OficinaSafService : EntityService<nc.OficinaSaf,nc.OficinaSafFilter,nc.OficinaSafResult,int>
    {        
		protected readonly OficinaSafBusiness Business = new OficinaSafBusiness();
        protected override IEntityBusiness<nc.OficinaSaf,nc.OficinaSafFilter,nc.OficinaSafResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
