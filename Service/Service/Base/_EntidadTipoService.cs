using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EntidadTipoService : EntityService<nc.EntidadTipo,nc.EntidadTipoFilter,nc.EntidadTipoResult,int>
    {        
		protected readonly EntidadTipoBusiness Business = new EntidadTipoBusiness();
        protected override IEntityBusiness<nc.EntidadTipo,nc.EntidadTipoFilter,nc.EntidadTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
