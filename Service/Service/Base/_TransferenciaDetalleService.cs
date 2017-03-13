using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _TransferenciaDetalleService : EntityService<nc.TransferenciaDetalle,nc.TransferenciaDetalleFilter,nc.TransferenciaDetalleResult,int>
    {        
		protected readonly TransferenciaDetalleBusiness Business = new TransferenciaDetalleBusiness();
        protected override IEntityBusiness<nc.TransferenciaDetalle,nc.TransferenciaDetalleFilter,nc.TransferenciaDetalleResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
