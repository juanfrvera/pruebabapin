using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _TransferenciaService : EntityService<nc.Transferencia,nc.TransferenciaFilter,nc.TransferenciaResult,int>
    {        
		protected readonly TransferenciaBusiness Business = new TransferenciaBusiness();
        protected override IEntityBusiness<nc.Transferencia,nc.TransferenciaFilter,nc.TransferenciaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
