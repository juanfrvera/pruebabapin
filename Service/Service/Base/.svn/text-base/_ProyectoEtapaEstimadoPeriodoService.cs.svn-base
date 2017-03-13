using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEtapaEstimadoPeriodoService : EntityService<nc.ProyectoEtapaEstimadoPeriodo,nc.ProyectoEtapaEstimadoPeriodoFilter,nc.ProyectoEtapaEstimadoPeriodoResult,int>
    {        
		protected readonly ProyectoEtapaEstimadoPeriodoBusiness Business = new ProyectoEtapaEstimadoPeriodoBusiness();
        protected override IEntityBusiness<nc.ProyectoEtapaEstimadoPeriodo,nc.ProyectoEtapaEstimadoPeriodoFilter,nc.ProyectoEtapaEstimadoPeriodoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
