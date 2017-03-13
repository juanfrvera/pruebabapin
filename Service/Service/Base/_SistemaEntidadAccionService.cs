using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SistemaEntidadAccionService : EntityService<nc.SistemaEntidadAccion,nc.SistemaEntidadAccionFilter,nc.SistemaEntidadAccionResult,int>
    {        
		protected readonly SistemaEntidadAccionBusiness Business = new SistemaEntidadAccionBusiness();
        protected override IEntityBusiness<nc.SistemaEntidadAccion,nc.SistemaEntidadAccionFilter,nc.SistemaEntidadAccionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
