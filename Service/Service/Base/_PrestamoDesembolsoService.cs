using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoDesembolsoService : EntityService<nc.PrestamoDesembolso,nc.PrestamoDesembolsoFilter,nc.PrestamoDesembolsoResult,int>
    {        
		protected readonly PrestamoDesembolsoBusiness Business = new PrestamoDesembolsoBusiness();
        protected override IEntityBusiness<nc.PrestamoDesembolso,nc.PrestamoDesembolsoFilter,nc.PrestamoDesembolsoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
