using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoSubConvenioService : EntityService<nc.PrestamoSubConvenio,nc.PrestamoSubConvenioFilter,nc.PrestamoSubConvenioResult,int>
    {        
		protected readonly PrestamoSubConvenioBusiness Business = new PrestamoSubConvenioBusiness();
        protected override IEntityBusiness<nc.PrestamoSubConvenio,nc.PrestamoSubConvenioFilter,nc.PrestamoSubConvenioResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
