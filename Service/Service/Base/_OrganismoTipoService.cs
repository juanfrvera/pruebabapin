using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _OrganismoTipoService : EntityService<nc.OrganismoTipo,nc.OrganismoTipoFilter,nc.OrganismoTipoResult,int>
    {        
		protected readonly OrganismoTipoBusiness Business = new OrganismoTipoBusiness();
        protected override IEntityBusiness<nc.OrganismoTipo,nc.OrganismoTipoFilter,nc.OrganismoTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
