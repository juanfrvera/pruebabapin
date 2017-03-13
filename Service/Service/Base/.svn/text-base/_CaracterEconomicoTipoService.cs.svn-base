using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _CaracterEconomicoTipoService : EntityService<nc.CaracterEconomicoTipo,nc.CaracterEconomicoTipoFilter,nc.CaracterEconomicoTipoResult,int>
    {        
		protected readonly CaracterEconomicoTipoBusiness Business = new CaracterEconomicoTipoBusiness();
        protected override IEntityBusiness<nc.CaracterEconomicoTipo,nc.CaracterEconomicoTipoFilter,nc.CaracterEconomicoTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
