using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _NumerationService : EntityService<nc.Numeration,nc.NumerationFilter,nc.NumerationResult,int>
    {        
		protected readonly NumerationBusiness Business = new NumerationBusiness();
        protected override IEntityBusiness<nc.Numeration,nc.NumerationFilter,nc.NumerationResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
