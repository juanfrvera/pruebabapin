using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorService : EntityService<nc.Indicador,nc.IndicadorFilter,nc.IndicadorResult,int>
    {        
		protected readonly IndicadorBusiness Business = new IndicadorBusiness();
        protected override IEntityBusiness<nc.Indicador,nc.IndicadorFilter,nc.IndicadorResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
