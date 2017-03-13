using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoComponenteService : EntityService<nc.PrestamoComponente,nc.PrestamoComponenteFilter,nc.PrestamoComponenteResult,int>
    {        
		protected readonly PrestamoComponenteBusiness Business = new PrestamoComponenteBusiness();
        protected override IEntityBusiness<nc.PrestamoComponente,nc.PrestamoComponenteFilter,nc.PrestamoComponenteResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
