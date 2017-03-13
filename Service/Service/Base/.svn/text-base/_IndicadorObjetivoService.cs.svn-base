using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorObjetivoService : EntityService<nc.IndicadorObjetivo,nc.IndicadorObjetivoFilter,nc.IndicadorObjetivoResult,int>
    {        
		protected readonly IndicadorObjetivoBusiness Business = new IndicadorObjetivoBusiness();
        protected override IEntityBusiness<nc.IndicadorObjetivo,nc.IndicadorObjetivoFilter,nc.IndicadorObjetivoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
