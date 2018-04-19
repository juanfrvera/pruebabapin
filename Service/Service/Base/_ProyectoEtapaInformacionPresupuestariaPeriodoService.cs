using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEtapaInformacionPresupuestariaPeriodoService : EntityService<nc.ProyectoEtapaInformacionPresupuestariaPeriodo,nc.ProyectoEtapaInformacionPresupuestariaPeriodoFilter,nc.ProyectoEtapaInformacionPresupuestariaPeriodoResult,int>
    {        
		protected readonly ProyectoEtapaInformacionPresupuestariaPeriodoBusiness Business = new ProyectoEtapaInformacionPresupuestariaPeriodoBusiness();
        protected override IEntityBusiness<nc.ProyectoEtapaInformacionPresupuestariaPeriodo,nc.ProyectoEtapaInformacionPresupuestariaPeriodoFilter,nc.ProyectoEtapaInformacionPresupuestariaPeriodoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
