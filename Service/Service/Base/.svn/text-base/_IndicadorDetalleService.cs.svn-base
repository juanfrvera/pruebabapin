using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorDetalleService : EntityService<nc.IndicadorDetalle,nc.IndicadorDetalleFilter,nc.IndicadorDetalleResult,int>
    {        
		protected readonly IndicadorDetalleBusiness Business = new IndicadorDetalleBusiness();
        protected override IEntityBusiness<nc.IndicadorDetalle,nc.IndicadorDetalleFilter,nc.IndicadorDetalleResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
