using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorPriorizacionService : EntityService<nc.IndicadorPriorizacion,nc.IndicadorPriorizacionFilter,nc.IndicadorPriorizacionResult,int>
    {        
		protected readonly IndicadorPriorizacionBusiness Business = new IndicadorPriorizacionBusiness();
        protected override IEntityBusiness<nc.IndicadorPriorizacion,nc.IndicadorPriorizacionFilter,nc.IndicadorPriorizacionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
