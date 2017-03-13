using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SubConvenioTipoService : EntityService<nc.SubConvenioTipo,nc.SubConvenioTipoFilter,nc.SubConvenioTipoResult,int>
    {        
		protected readonly SubConvenioTipoBusiness Business = new SubConvenioTipoBusiness();
        protected override IEntityBusiness<nc.SubConvenioTipo,nc.SubConvenioTipoFilter,nc.SubConvenioTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
