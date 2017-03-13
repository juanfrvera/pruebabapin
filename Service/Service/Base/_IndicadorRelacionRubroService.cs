using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorRelacionRubroService : EntityService<nc.IndicadorRelacionRubro,nc.IndicadorRelacionRubroFilter,nc.IndicadorRelacionRubroResult,int>
    {        
		protected readonly IndicadorRelacionRubroBusiness Business = new IndicadorRelacionRubroBusiness();
        protected override IEntityBusiness<nc.IndicadorRelacionRubro,nc.IndicadorRelacionRubroFilter,nc.IndicadorRelacionRubroResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
