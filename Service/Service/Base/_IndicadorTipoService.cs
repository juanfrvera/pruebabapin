using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorTipoService : EntityService<nc.IndicadorTipo,nc.IndicadorTipoFilter,nc.IndicadorTipoResult,int>
    {        
		protected readonly IndicadorTipoBusiness Business = new IndicadorTipoBusiness();
        protected override IEntityBusiness<nc.IndicadorTipo,nc.IndicadorTipoFilter,nc.IndicadorTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
