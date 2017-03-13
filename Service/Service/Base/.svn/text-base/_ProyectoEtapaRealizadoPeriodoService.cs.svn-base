using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEtapaRealizadoPeriodoService : EntityService<nc.ProyectoEtapaRealizadoPeriodo,nc.ProyectoEtapaRealizadoPeriodoFilter,nc.ProyectoEtapaRealizadoPeriodoResult,int>
    {        
		protected readonly ProyectoEtapaRealizadoPeriodoBusiness Business = new ProyectoEtapaRealizadoPeriodoBusiness();
        protected override IEntityBusiness<nc.ProyectoEtapaRealizadoPeriodo,nc.ProyectoEtapaRealizadoPeriodoFilter,nc.ProyectoEtapaRealizadoPeriodoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
