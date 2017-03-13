using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _MonedaService : EntityService<nc.Moneda,nc.MonedaFilter,nc.MonedaResult,int>
    {        
		protected readonly MonedaBusiness Business = new MonedaBusiness();
        protected override IEntityBusiness<nc.Moneda,nc.MonedaFilter,nc.MonedaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
