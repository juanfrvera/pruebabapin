using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _PrestamoService : EntityService<nc.Prestamo,nc.PrestamoFilter,nc.PrestamoResult,int>
    {        
		protected readonly PrestamoBusiness Business = new PrestamoBusiness();
        protected override IEntityBusiness<nc.Prestamo,nc.PrestamoFilter,nc.PrestamoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
