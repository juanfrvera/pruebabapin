using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _TextCategoryService : EntityService<nc.TextCategory,nc.TextCategoryFilter,nc.TextCategoryResult,int>
    {        
		protected readonly TextCategoryBusiness Business = new TextCategoryBusiness();
        protected override IEntityBusiness<nc.TextCategory,nc.TextCategoryFilter,nc.TextCategoryResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
