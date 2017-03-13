using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _GestionTipoService : EntityService<nc.GestionTipo,nc.GestionTipoFilter,nc.GestionTipoResult,int>
    {        
		protected readonly GestionTipoBusiness Business = new GestionTipoBusiness();
        protected override IEntityBusiness<nc.GestionTipo,nc.GestionTipoFilter,nc.GestionTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
