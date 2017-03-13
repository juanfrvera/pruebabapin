using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProcesoService : EntityService<nc.Proceso,nc.ProcesoFilter,nc.ProcesoResult,int>
    {        
		protected readonly ProcesoBusiness Business = new ProcesoBusiness();
        protected override IEntityBusiness<nc.Proceso,nc.ProcesoFilter,nc.ProcesoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
