using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoEtapaEstimadoService : EntityService<nc.ProyectoEtapaEstimado,nc.ProyectoEtapaEstimadoFilter,nc.ProyectoEtapaEstimadoResult,int>
    {        
		protected readonly ProyectoEtapaEstimadoBusiness Business = new ProyectoEtapaEstimadoBusiness();
        protected override IEntityBusiness<nc.ProyectoEtapaEstimado,nc.ProyectoEtapaEstimadoFilter,nc.ProyectoEtapaEstimadoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
