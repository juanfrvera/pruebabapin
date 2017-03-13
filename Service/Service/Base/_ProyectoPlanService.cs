using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoPlanService : EntityService<nc.ProyectoPlan,nc.ProyectoPlanFilter,nc.ProyectoPlanResult,int>
    {        
		protected readonly ProyectoPlanBusiness Business = new ProyectoPlanBusiness();
        protected override IEntityBusiness<nc.ProyectoPlan,nc.ProyectoPlanFilter,nc.ProyectoPlanResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
