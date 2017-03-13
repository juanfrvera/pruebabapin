using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _EstadoTipoService : EntityService<nc.EstadoTipo,nc.EstadoTipoFilter,nc.EstadoTipoResult,int>
    {        
		protected readonly EstadoTipoBusiness Business = new EstadoTipoBusiness();
        protected override IEntityBusiness<nc.EstadoTipo,nc.EstadoTipoFilter,nc.EstadoTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
