using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _GeoreferenciacionPuntoService : EntityService<nc.GeoreferenciacionPunto,nc.GeoreferenciacionPuntoFilter,nc.GeoreferenciacionPuntoResult,int>
    {        
		protected readonly GeoreferenciacionPuntoBusiness Business = new GeoreferenciacionPuntoBusiness();
        protected override IEntityBusiness<nc.GeoreferenciacionPunto,nc.GeoreferenciacionPuntoFilter,nc.GeoreferenciacionPuntoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
