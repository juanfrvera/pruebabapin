using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ClasificacionGastoService : EntityService<nc.ClasificacionGasto,nc.ClasificacionGastoFilter,nc.ClasificacionGastoResult,int>
    {        
		protected readonly ClasificacionGastoBusiness Business = new ClasificacionGastoBusiness();
        protected override IEntityBusiness<nc.ClasificacionGasto,nc.ClasificacionGastoFilter,nc.ClasificacionGastoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
