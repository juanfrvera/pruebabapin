using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoConvenioService : EntityService<nc.PrestamoConvenio,nc.PrestamoConvenioFilter,nc.PrestamoConvenioResult,int>
    {        
		protected readonly PrestamoConvenioBusiness Business = new PrestamoConvenioBusiness();
        protected override IEntityBusiness<nc.PrestamoConvenio,nc.PrestamoConvenioFilter,nc.PrestamoConvenioResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
