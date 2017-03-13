using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _IndicadorEvolucionInstanciaService : EntityService<nc.IndicadorEvolucionInstancia,nc.IndicadorEvolucionInstanciaFilter,nc.IndicadorEvolucionInstanciaResult,int>
    {        
		protected readonly IndicadorEvolucionInstanciaBusiness Business = new IndicadorEvolucionInstanciaBusiness();
        protected override IEntityBusiness<nc.IndicadorEvolucionInstancia,nc.IndicadorEvolucionInstanciaFilter,nc.IndicadorEvolucionInstanciaResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
