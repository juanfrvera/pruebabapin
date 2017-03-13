using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ParameterService : EntityService<nc.Parameter,nc.ParameterFilter,nc.ParameterResult,int>
    {        
		protected readonly ParameterBusiness Business = new ParameterBusiness();
        protected override IEntityBusiness<nc.Parameter,nc.ParameterFilter,nc.ParameterResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
