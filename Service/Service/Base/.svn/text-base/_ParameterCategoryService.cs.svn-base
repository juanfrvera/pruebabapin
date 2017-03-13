using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ParameterCategoryService : EntityService<nc.ParameterCategory,nc.ParameterCategoryFilter,nc.ParameterCategoryResult,int>
    {        
		protected readonly ParameterCategoryBusiness Business = new ParameterCategoryBusiness();
        protected override IEntityBusiness<nc.ParameterCategory,nc.ParameterCategoryFilter,nc.ParameterCategoryResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
