using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _SubProcesoService : EntityService<nc.SubProceso,nc.SubProcesoFilter,nc.SubProcesoResult,int>
    {        
		protected readonly SubProcesoBusiness Business = new SubProcesoBusiness();
        protected override IEntityBusiness<nc.SubProceso,nc.SubProcesoFilter,nc.SubProcesoResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
