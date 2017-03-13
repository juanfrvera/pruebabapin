using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ConfigurationService : EntityService<nc.Configuration,nc.ConfigurationFilter,nc.ConfigurationResult,int>
    {        
		protected readonly ConfigurationBusiness Business = new ConfigurationBusiness();
        protected override IEntityBusiness<nc.Configuration,nc.ConfigurationFilter,nc.ConfigurationResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
