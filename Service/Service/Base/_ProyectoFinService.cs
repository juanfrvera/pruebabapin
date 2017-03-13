using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _ProyectoFinService : EntityService<nc.ProyectoFin,nc.ProyectoFinFilter,nc.ProyectoFinResult,int>
    {        
		protected readonly ProyectoFinBusiness Business = new ProyectoFinBusiness();
        protected override IEntityBusiness<nc.ProyectoFin,nc.ProyectoFinFilter,nc.ProyectoFinResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
