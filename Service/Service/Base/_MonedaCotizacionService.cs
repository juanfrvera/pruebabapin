using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _MonedaCotizacionService : EntityService<nc.MonedaCotizacion,nc.MonedaCotizacionFilter,nc.MonedaCotizacionResult,int>
    {        
		protected readonly MonedaCotizacionBusiness Business = new MonedaCotizacionBusiness();
        protected override IEntityBusiness<nc.MonedaCotizacion,nc.MonedaCotizacionFilter,nc.MonedaCotizacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
