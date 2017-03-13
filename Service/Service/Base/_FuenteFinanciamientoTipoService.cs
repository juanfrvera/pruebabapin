using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _FuenteFinanciamientoTipoService : EntityService<nc.FuenteFinanciamientoTipo,nc.FuenteFinanciamientoTipoFilter,nc.FuenteFinanciamientoTipoResult,int>
    {        
		protected readonly FuenteFinanciamientoTipoBusiness Business = new FuenteFinanciamientoTipoBusiness();
        protected override IEntityBusiness<nc.FuenteFinanciamientoTipo,nc.FuenteFinanciamientoTipoFilter,nc.FuenteFinanciamientoTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
