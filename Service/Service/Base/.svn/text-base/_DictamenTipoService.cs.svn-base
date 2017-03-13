using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _DictamenTipoService : EntityService<nc.DictamenTipo,nc.DictamenTipoFilter,nc.DictamenTipoResult,int>
    {        
		protected readonly DictamenTipoBusiness Business = new DictamenTipoBusiness();
        protected override IEntityBusiness<nc.DictamenTipo,nc.DictamenTipoFilter,nc.DictamenTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }		
		public override string ServiceName{get { return "DictamenTipoService"; }}
    }	
}
