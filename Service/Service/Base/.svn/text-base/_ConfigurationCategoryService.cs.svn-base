using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ConfigurationCategoryService : EntityService<nc.ConfigurationCategory,nc.ConfigurationCategoryFilter,nc.ConfigurationCategoryResult,int>
    {        
		protected readonly ConfigurationCategoryBusiness Business = new ConfigurationCategoryBusiness();
        protected override IEntityBusiness<nc.ConfigurationCategory,nc.ConfigurationCategoryFilter,nc.ConfigurationCategoryResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
