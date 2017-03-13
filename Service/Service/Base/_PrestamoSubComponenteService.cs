using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoSubComponenteService : EntityService<nc.PrestamoSubComponente,nc.PrestamoSubComponenteFilter,nc.PrestamoSubComponenteResult,int>
    {        
		protected readonly PrestamoSubComponenteBusiness Business = new PrestamoSubComponenteBusiness();
        protected override IEntityBusiness<nc.PrestamoSubComponente,nc.PrestamoSubComponenteFilter,nc.PrestamoSubComponenteResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
