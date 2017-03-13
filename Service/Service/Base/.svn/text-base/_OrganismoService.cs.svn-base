using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _OrganismoService : EntityService<nc.Organismo,nc.OrganismoFilter,nc.OrganismoResult,int>
    {        
		protected readonly OrganismoBusiness Business = new OrganismoBusiness();
        protected override IEntityBusiness<nc.Organismo,nc.OrganismoFilter,nc.OrganismoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
