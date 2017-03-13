using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PriorityService : EntityService<nc.Priority,nc.PriorityFilter,nc.PriorityResult,int>
    {        
		protected readonly PriorityBusiness Business = new PriorityBusiness();
        protected override IEntityBusiness<nc.Priority,nc.PriorityFilter,nc.PriorityResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
