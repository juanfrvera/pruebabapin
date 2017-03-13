using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoRelacionTipoService : EntityService<nc.ProyectoRelacionTipo,nc.ProyectoRelacionTipoFilter,nc.ProyectoRelacionTipoResult,int>
    {        
		protected readonly ProyectoRelacionTipoBusiness Business = new ProyectoRelacionTipoBusiness();
        protected override IEntityBusiness<nc.ProyectoRelacionTipo,nc.ProyectoRelacionTipoFilter,nc.ProyectoRelacionTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
