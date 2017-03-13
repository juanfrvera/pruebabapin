using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _AdministracionTipoService : EntityService<nc.AdministracionTipo,nc.AdministracionTipoFilter,nc.AdministracionTipoResult,int>
    {        
		protected readonly AdministracionTipoBusiness Business = new AdministracionTipoBusiness();
        protected override IEntityBusiness<nc.AdministracionTipo,nc.AdministracionTipoFilter,nc.AdministracionTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
