using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoTipoService : EntityService<nc.ProyectoTipo,nc.ProyectoTipoFilter,nc.ProyectoTipoResult,int>
    {        
		protected readonly ProyectoTipoBusiness Business = new ProyectoTipoBusiness();
        protected override IEntityBusiness<nc.ProyectoTipo,nc.ProyectoTipoFilter,nc.ProyectoTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
