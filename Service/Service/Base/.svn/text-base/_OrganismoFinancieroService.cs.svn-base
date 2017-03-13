using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _OrganismoFinancieroService : EntityService<nc.OrganismoFinanciero,nc.OrganismoFinancieroFilter,nc.OrganismoFinancieroResult,int>
    {        
		protected readonly OrganismoFinancieroBusiness Business = new OrganismoFinancieroBusiness();
        protected override IEntityBusiness<nc.OrganismoFinanciero,nc.OrganismoFinancieroFilter,nc.OrganismoFinancieroResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
