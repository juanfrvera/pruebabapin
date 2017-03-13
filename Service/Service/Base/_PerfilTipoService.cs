using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PerfilTipoService : EntityService<nc.PerfilTipo,nc.PerfilTipoFilter,nc.PerfilTipoResult,int>
    {        
		protected readonly PerfilTipoBusiness Business = new PerfilTipoBusiness();
        protected override IEntityBusiness<nc.PerfilTipo,nc.PerfilTipoFilter,nc.PerfilTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
