using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorRubroService : EntityService<nc.IndicadorRubro,nc.IndicadorRubroFilter,nc.IndicadorRubroResult,int>
    {        
		protected readonly IndicadorRubroBusiness Business = new IndicadorRubroBusiness();
        protected override IEntityBusiness<nc.IndicadorRubro,nc.IndicadorRubroFilter,nc.IndicadorRubroResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
