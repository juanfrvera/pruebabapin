using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SistemaAccionService : EntityService<nc.SistemaAccion,nc.SistemaAccionFilter,nc.SistemaAccionResult,int>
    {        
		protected readonly SistemaAccionBusiness Business = new SistemaAccionBusiness();
        protected override IEntityBusiness<nc.SistemaAccion,nc.SistemaAccionFilter,nc.SistemaAccionResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
