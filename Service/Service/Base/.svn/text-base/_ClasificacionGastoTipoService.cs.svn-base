using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ClasificacionGastoTipoService : EntityService<nc.ClasificacionGastoTipo,nc.ClasificacionGastoTipoFilter,nc.ClasificacionGastoTipoResult,int>
    {        
		protected readonly ClasificacionGastoTipoBusiness Business = new ClasificacionGastoTipoBusiness();
        protected override IEntityBusiness<nc.ClasificacionGastoTipo,nc.ClasificacionGastoTipoFilter,nc.ClasificacionGastoTipoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
