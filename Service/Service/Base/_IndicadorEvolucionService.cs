using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorEvolucionService : EntityService<nc.IndicadorEvolucion,nc.IndicadorEvolucionFilter,nc.IndicadorEvolucionResult,int>
    {        
		protected readonly IndicadorEvolucionBusiness Business = new IndicadorEvolucionBusiness();
        protected override IEntityBusiness<nc.IndicadorEvolucion,nc.IndicadorEvolucionFilter,nc.IndicadorEvolucionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
